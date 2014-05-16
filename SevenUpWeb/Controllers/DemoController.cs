using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SevenUp.Common;
using SevenUp.Business;
namespace SevenUpWeb.Controllers
{
    public class DemoController : ApiController
    {
        //Get api/Demo/Hello?name=jack
        [HttpGet]
        public string Hello(string name)
        {
            return "hello " + name;
        }

        //Get Demo/orders/1234  重写默认路由
        [HttpGet]
        [Route("Demo/orders/{id}")]
        public string CustomRoute(string id)
        {
            return "CustomRoute " + id;
        }


        //Get api/Demo/TestError?num=12
        //GetError api/Demo/TestError?num=111
        [HttpGet]
        public string TestError(int num)
        {
            DemoService service = InterceptHelper.Create<DemoService>();
            //num大约100时抛出异常记录日志
            return service.TestError(num);
        }

    }
}
