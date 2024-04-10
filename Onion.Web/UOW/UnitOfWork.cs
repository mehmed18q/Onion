using Onion.Data.Access;
using Onion.Data.Account;
using Onion.Data.Music;
using Onion.Data.Site;
using Onion.Repository.ApplicationContext;
using Onion.Repository.DataTransfer;
using Onion.Service.Implementation;
using Onion.Service.Interfaces;

namespace Onion.Web.UOW
{
	public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
	{
		private readonly ApplicationDbContext _context = context;

		private IUserService _UserService;

		public IUserService UserService
		{
			get
			{
				_UserService ??= new UserService(new BaseRepository<User>(_context), new BaseRepository<Role>(_context));

				return _UserService;
			}
		}

		private IRoleService _RoleService;
		public IRoleService RoleService
		{
			get
			{
				_RoleService ??= new RoleService(new BaseRepository<Role>(_context));

				return _RoleService;
			}
		}

		private ISliderService _sliderService;
		public ISliderService SliderService
		{
			get
			{
				_sliderService ??= new SliderService(new Repository<Slider>(context));

				return _sliderService;
			}
		}

		private ISingerService _singerService;

		public ISingerService SingerService
		{
			get
			{
				_singerService ??= new SingerService(new Repository<Singer>(context));

				return _singerService;
			}
		}

		private ISongService _songService;

		public ISongService SongService
		{
			get
			{
				_songService ??= new SongService(new Repository<Song>(context), new Repository<SongLike>(context), new Repository<SongVisit>(context));

				return _songService;
			}
		}

		public void Dispose() => _context.Dispose();

		public async Task SaveChanges() => await _context.SaveChangesAsync();
	}
}
