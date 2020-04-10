using Autofac;
using Autofac.Integration.WebApi;
using Ordering.Core.Interface;
using Ordering.Services.Services;
using System.Reflection;
using System.Web.Http;

namespace Ordering.Web.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterDependencies(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<OrderService>().As<IOrderService>();

            var container = builder.Build();
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}