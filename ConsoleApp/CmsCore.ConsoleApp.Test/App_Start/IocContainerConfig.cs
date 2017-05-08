using Autofac;
using CmsCore.Library.Ioc.IocManager;

namespace CmsCore.ConsoleApp.Test
{
    public static class IocContainerConfig
    {
        public static IContainer GetContainer()
        {
            return IocContainerBuilder.GetContainerBuilder().Build();
        }
    }
}