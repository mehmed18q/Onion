using Onion.Data.Music;
using Onion.Service.DTO.Song;

namespace Onion.Service.Interfaces
{
	public interface ISongService : IDisposable
	{
		List<Song> GetAllSingerSongs(int singerId);
		void AddSong(Song song);
		Song? GetSongById(int songId);
		void EditSong(Song song);
		List<Song> GetLatestSongsForHeader();
		AllSongsDTO GetAllSongs(AllSongsDTO filter);
		SingleSongDTO? GetSingleSong(int songId);
		Task<bool> IsExistSongById(int songId);
		Task<bool> HasUserLikedSong(int songId, string userIP);
		void DisLikeSong(int songId, string userIP);
		void LikeSong(int songId, string userIP);
		Task<bool> HasUserVisitedSong(int songId, string userIP);
		void AddVisitForSong(int songId, string userIP);
		List<Song> GetFavoritesSongs();
		List<Song> GetSongsOrderedByVisit();
	}

}
