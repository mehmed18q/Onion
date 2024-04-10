using Onion.Service.Interfaces;

namespace Onion.Web.UOW
{
	public interface IUnitOfWork : IDisposable
	{
		Task SaveChanges();

		IUserService UserService { get; }

		IRoleService RoleService { get; }

		ISliderService SliderService { get; }

		ISingerService SingerService { get; }

		ISongService SongService { get; }
	}
}
