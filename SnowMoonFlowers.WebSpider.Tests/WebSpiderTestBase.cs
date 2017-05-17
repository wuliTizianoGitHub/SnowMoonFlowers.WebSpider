using System;
using Abp.TestBase;
using SnowMoonFlowers.WebSpider.EntityFramework;
using EntityFramework.DynamicFilters;
using SnowMoonFlowers.WebSpider.Tests.InitialData;
using Castle.MicroKernel.Registration;
using System.Data.Common;
using Effort;

namespace SnowMoonFlowers.WebSpider.Tests
{
    public abstract class WebSpiderTestBase : AbpIntegratedTestBase<WebSpiderTestModule>
    {
        protected WebSpiderTestBase()
        {
            //Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            UsingDbContext(context => new WebSpiderInitialDataBuilder().Build(context));
           
        }

        protected override void PreInitialize()
        {
            //需要注册Effort的信息，使用Effort就必须注册，并且是在初始化之前
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>().UsingFactoryMethod(DbConnectionFactory.CreateTransient).LifestyleSingleton()
                );
            base.PreInitialize();
        }

        public void UsingDbContext(Action<WebSpiderDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<WebSpiderDbContext>())
            {
                context.DisableAllFilters();
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<WebSpiderDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<WebSpiderDbContext>())
            {
                context.DisableAllFilters();
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
