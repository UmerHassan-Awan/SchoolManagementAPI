using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using SchoolMS_API.Models;
using SchoolMS_API.Providers;
using SchoolMS_API.Results;

namespace SchoolMS_API.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        #region Objects
        Cls_Contacts objContacts = new Cls_Contacts();
        Cls_APIResponse objResp = new Cls_APIResponse();
        #endregion

        [HttpPost]
        [Route("GetLoginUser")]
        public Cls_APIResponse GetLoginUser([FromBody] Cls_Contacts rawData)
        {
            try
            {
                Cls_Contacts Result = objContacts.GetUserLogin(rawData);

                if (Result != null)
                {
                    Result.AccessToken = TokenHelper.GenerateToken(rawData);
                }

                objResp.Data = Result;
                objResp.StatusCode = 1;

                return objResp;
            }
            catch (Exception ex) 
            {
                objResp.StatusCode = 0;
                objResp.Message = ex.Message;
                return objResp;
            }
        }
    }
}
