using Onion.Data.Music;
using Onion.Repository.DataTransfer;
using Onion.Service.Interfaces;

namespace Onion.Service.Implementation
{
	public class SingerService(IBaseRepository<Singer> singerRepository) : ISingerService
	{
		private readonly IBaseRepository<Singer> _singerRepository = singerRepository;

		public List<Singer> GetAllSingers()
		{
			return _singerRepository.Get(null).ToList();
		}

		public void AddSinger(Singer singer)
		{
			_singerRepository.Insert(singer);
		}

		public Singer? GetSingerById(int singerId)
		{
			return _singerRepository.GetById(singerId);
		}

		public void EditSinger(Singer singer)
		{
			_singerRepository.Update(singer);
		}

		public void Dispose()
		{
			_singerRepository.Dispose();
		}
	}

}
