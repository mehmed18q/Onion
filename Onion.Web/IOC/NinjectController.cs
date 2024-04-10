using Azure;
using Ninject;
using Onion.Web.UOW;

namespace Onion.Web.IOC
{
    public class NinjectController : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectController()
        {
            ninjectKernel = new StandardKernel();

            Bind();
        }

        private void Bind()
        {
            ninjectKernel.Bind<OnionContext>().To<OnionContext>();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            ninjectKernel.Bind<IEmailSender>().To<EmailSender>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? throw new HttpException(404, "not found") : (IController)ninjectKernel.Get(controllerType);
        }
    }

}
