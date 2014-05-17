using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenUp.Common
{
    /// <summary>
    /// Trace拦截器,记录异常调用日志,调用方法必须是virtual才能拦截
    /// </summary>
    public class TraceBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodReturn = getNext().Invoke(input, getNext);
            if (methodReturn.Exception != null)//执行错误
            {
                StringBuilder outStr = new StringBuilder();
                outStr.Append(string.Format("Method:{0}.{1}(", getTargetName(input.Target.ToString()), input.MethodBase.Name));
                outStr.Append(string.Join(",", input.Inputs.Cast<object>()));
                outStr.AppendLine(")");

                log4net.LogManager.GetLogger("ServiceTrace").Error(outStr.ToString(), methodReturn.Exception);
            }

            return methodReturn;
        }

        private string getTargetName(string wrapperTargetName)
        {
            int start = wrapperTargetName.IndexOf("_") + 1;
            int end = wrapperTargetName.LastIndexOf("_");
            return wrapperTargetName.Substring(start, end - start);
        }
        public bool WillExecute
        {
            get { return true; }
        }
    }

}
