using SevenUp.Business;
using SevenUp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SevenUpWeb.Controllers
{
    public class AccountController : ApiController
    {
        AccountService service = InterceptHelper.Create<AccountService>();

        //Get api/account/phonequery?phoneNum=1234
        [HttpGet]
        public int PhoneQuery(string phoneNum)
        {
            return service.PhoneExsitedQuery(phoneNum);
        }
    }
}
