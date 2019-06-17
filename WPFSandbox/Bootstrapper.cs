using Autofac;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using WPFSandbox.ViewModels;

namespace WPFSandbox
{
    public class Bootstrapper : BootstrapperBase
    {
        private static IContainer container;

        public Bootstrapper()
        {
            this.Initialize();
        }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WindowManager>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ShellViewModel>()
                .SingleInstance().AsSelf();

            builder.RegisterType<ChildOneViewModel>();            

            builder.RegisterType<EventAggregator>()
                .AsImplementedInterfaces()
                .SingleInstance();

            //GetType().Assembly.GetTypes()
            //    .Where(t => t.IsClass)
            //    .Where(t=> t.Name.EndsWith("ViewModel"))
            //    .ToList()
            //    .ForEach(vm => builder.RegisterType(vm,)

            container = builder.Build();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            var type = typeof(IEnumerable<>).MakeGenericType(service);
            return container.Resolve(type) as IEnumerable<object>;
        }

        protected override object GetInstance(Type service, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (container.IsRegistered(service))
                    return container.Resolve(service);
            }
            else
            {
                if (container.IsRegisteredWithKey(key, service))
                    return container.ResolveKeyed(key, service);
            }

            var msgFormat = "Could not locate any instances of contract {0}.";
            var msg = string.Format(msgFormat, key ?? service.Name);
            throw new Exception(msg);
        }

        protected override void BuildUp(object instance)
        {
            container.InjectProperties(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
