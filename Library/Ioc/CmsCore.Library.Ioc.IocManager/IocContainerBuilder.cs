using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using CmsCore.Libary.Data.MySqlDao;
using CmsCore.Libary.Data.MySqlDao.Interfaces;
using CmsCore.Libary.Data.MySqlDao.Layers;
using CmsCore.Library.Business;
using CmsCore.Library.Business.Interfaces;
using CmsCore.Library.Data.Interfaces;
using CmsCore.Library.Facade;
using CmsCore.Library.Facade.Interfaces;
using CmsCore.Library.Ioc.IocManager.Interceptors;

namespace CmsCore.Library.Ioc.IocManager
{
    public static class IocContainerBuilder
    {
        public static ContainerBuilder GetContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new TestInterceptor());

            builder
                .Register<IDbAccess>(c => new MySqlAccess(
                    "Server=127.0.0.1; Port=3306; Database=testDb; Uid=root; Pwd=volblood;Allow User Variables=True"
                    , "testDb"))
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TestInterceptor))
                .InstancePerDependency();

            builder.Register<IEntityAccess>(c => new MySqlEntityDao(c.Resolve<IDbAccess>()))
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TestInterceptor))
                .InstancePerDependency();

            builder.Register<IEntityDao>(c => new EntityDao(c.Resolve<IDbAccess>()))
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TestInterceptor))
                .InstancePerDependency();

            builder.Register<IEntityBusiness>(c => new EntityBusiness(c.Resolve<IEntityDao>()))
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TestInterceptor))
                .InstancePerDependency();

            builder.Register<ISetupFacade>(c => new SetupFacade(c.Resolve<IEntityBusiness>()))
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TestInterceptor))
                .InstancePerDependency();

            return builder;
        }
    }
}