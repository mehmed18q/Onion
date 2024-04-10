using Onion.Web.UOW;
namespace Onion.Web.IOC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //System.Reflection.Assembly.GetExecutingAssembly()
            //            .GetTypes()
            //            .Where(item => item.GetInterfaces()
            //            .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IBaseRepository<>)) && !item.IsAbstract && !item.IsInterface)
            //            .ToList()
            //            .ForEach(assignedTypes =>
            //            {
            //                Type serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IBaseRepository<>));
            //                services.AddScoped(serviceType, assignedTypes);
            //            });
        }
    }
}
