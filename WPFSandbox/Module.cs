using System.Linq;
using Autofac;

namespace WPFSandbox
{
    public class Module : Autofac.Module
    {
        public Module()
        {
            
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //builder.RegisterType<App>().AsSelf().SingleInstance();

            var collection = GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"));

            foreach (var item in collection)
            {
                builder.RegisterType(item).AsSelf().AsImplementedInterfaces();
            }
        }
    }
}
