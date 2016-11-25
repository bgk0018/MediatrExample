using MediatR;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrExample
{
    public static class BootstrapApplication
    {
        public static UnityContainer Init()
        {
            UnityContainer container = new UnityContainer();

            container.RegisterType<IMediator, Mediator>();
            container.RegisterTypes(AllClasses.FromAssemblies(typeof(Controller).Assembly), WithMappings.FromAllInterfaces, GetName, GetLifetimeManager);
            container.RegisterInstance(Console.Out);
            container.RegisterInstance<SingleInstanceFactory>(t => container.Resolve(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));

            return container;
        }

        static bool IsNotificationHandler(Type type)
        {
            return type.GetInterfaces().Any(x => x.IsGenericType && (x.GetGenericTypeDefinition() == typeof(INotificationHandler<>) || x.GetGenericTypeDefinition() == typeof(IAsyncNotificationHandler<>)));
        }

        static LifetimeManager GetLifetimeManager(Type type)
        {
            return IsNotificationHandler(type) ? new ContainerControlledLifetimeManager() : null;
        }

        static string GetName(Type type)
        {
            return IsNotificationHandler(type) ? string.Format("HandlerFor" + type.Name) : string.Empty;
        }
    }
}
