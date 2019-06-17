using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<App>().AsSelf().SingleInstance();

            IEnumerable<Type> collection = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"));

            foreach (var item in collection)
            {
                builder.RegisterType(item).AsSelf().AsImplementedInterfaces();
            }

            return builder.Build();
        }
    }
}
