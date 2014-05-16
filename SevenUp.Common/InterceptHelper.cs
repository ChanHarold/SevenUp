using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenUp.Common
{
    public static class InterceptHelper
    {
        public static T Create<T>() where T : class
        {
            return Intercept.NewInstance<T>(
                    new VirtualMethodInterceptor(),
                    new[] { new TraceBehavior() });
        }

        public static T Create<T>(params object[] args) where T : class
        {
            return Intercept.NewInstance<T>(
                    new VirtualMethodInterceptor(),
                    new[] { new TraceBehavior() }, args);
        }
    }

}
