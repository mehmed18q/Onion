using Onion.Data.Common;
using Onion.Data.Music;
using Onion.Repository.DataTransfer;
using Onion.Service.DTO.Paging;
using Onion.Service.DTO.Song;
using Onion.Service.Extensions;
using Onion.Service.Interfaces;

namespace Onion.Service.Implementation
{
	public class SongService(IBaseRepository<Song> songRepository, IBaseRepository<SongAttractiveness> songAttractivenessRepository) : ISongService
	{
		private readonly IBaseRepository<Song> _songRepository = songRepository;

		private readonly IBaseRepository<SongAttractiveness> _songAttractivenessRepository = songAttractivenessRepository;

		public List<Song> GetAllSingerSongs(int singerId)
		{
			return _songRepository.Get(s => s.SingerId == singerId).ToList();
		}

		public void AddSong(Song song)
		{
			_songRepository.Insert(song);
		}

		public Song? GetSongById(int songId)
		{
			return _songRepository.GetById(songId);
		}

		public void EditSong(Song song)
		{
			_songRepository.Update(song);
		}

		public List<Song> GetLatestSongsForHeader()
		{
			return _songRepository.Get(s => s.IsActive && !s.IsDeleted).OrderByDescending(s => s.CreateDate).Take(8).ToList();
		}

		public AllSongsDTO GetAllSongs(AllSongsDTO filter)
		{
			IQueryable<Song> query = _songRepository.Get(null).AsQueryable();

			int count = (int)Math.Ceiling(query.Count() / (double)filter.TakeEntity);

			BasePaging pager = Pager.Build(count, filter.PageId, filter.TakeEntity);

			List<Song> songs = [.. query.OrderByDescending(s => s.Id).Paging(pager)];

			return new AllSongsDTO().SetSongs(songs).SetPaging(pager);
		}

		public SingleSongDTO? GetSingleSong(int songId)
		{
			Song? song = _songRepository.GetById(songId);

			if (song == null)
			{
				return null;
			}

			List<Song> otherSongs = _songRepository.Get(s => s.IsActive && !s.IsDeleted && s.SingerId == song.SingerId && s.Id != songId).OrderByDescending(s => s.CreateDate).Take(4).ToList();

			return new SingleSongDTO
			{
				Song = song,
				Songs = otherSongs
			};
		}

		public async Task<bool> IsExistSongById(int songId)
		{
			return await _songRepository.Any(s => s.Id == songId);
		}

		public async Task<bool> HasUserLikedSong(int songId, string userIP)
		{
			return await _songAttractivenessRepository.Any(s => s.SongId == songId && s.UserIP == userIP && s.AttractivenessType == AttractivenessType.Like);
		}

		public void DisLikeSong(int songId, string userIP)
		{
			SongAttractiveness? like = _songAttractivenessRepository.Get(s => s.SongId == songId && s.UserIP == userIP && s.AttractivenessType == AttractivenessType.Like).SingleOrDefault();

			if (like != null)
			{
				_songAttractivenessRepository.Delete(like);
			}
		}

		public void LikeSong(int songId, string userIP)
		{
			_songAttractivenessRepository.Insert(new SongAttractiveness
			{
				SongId = songId,
				UserIP = userIP,
				AttractivenessType = AttractivenessType.Like
			});
		}

		public async Task<bool> HasUserVisitedSong(int songId, string userIP)
		{
			return await _songAttractivenessRepository.Any(s => s.SongId == songId && s.UserIP == userIP && s.AttractivenessType == AttractivenessType.Visit);
		}

		public void AddVisitForSong(int songId, string userIP)
		{
			_songAttractivenessRepository.Insert(new SongAttractiveness
			{
				SongId = songId,
				UserIP = userIP,
				AttractivenessType = AttractivenessType.Visit
			});
		}

		public List<Song> GetFavoritesSongs()
		{
			return _songRepository.Get(s => s.IsActive && !s.IsDeleted).OrderByDescending(s => s.SongAttractiveness?.Count(x => x.AttractivenessType == AttractivenessType.Like)).Take(12).ToList();
		}

		public List<Song> GetSongsOrderedByVisit()
		{
			return _songRepository.Get(s => s.IsActive && !s.IsDeleted).OrderByDescending(s => s.SongAttractiveness?.Count(x => x.AttractivenessType == AttractivenessType.Visit)).Take(12).ToList();
		}

		public void Dispose()
		{
			_songRepository.Dispose();
		}
	}

}
