using System;
using Castle.DynamicProxy;

namespace CmsCore.Library.Ioc.IocManager.Interceptors
{
    public class TestInterceptor:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Hello From Interceptor");

            try
            {
                invocation.Proceed();

                Console.WriteLine("Exit From Interceptor");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}