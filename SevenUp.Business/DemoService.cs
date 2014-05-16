using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenUp.Business
{
    public class DemoService
    {
        public virtual string Hello(string name)
        {
            return "Hello " + name;
        }

        public virtual string TestError(int num)
        {
            if (num > 100)
                throw new  ArgumentOutOfRangeException ("num不能大于100");
            else
                return "ok";
        }
        
    }
}
