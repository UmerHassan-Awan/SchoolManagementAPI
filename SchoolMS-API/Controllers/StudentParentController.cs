using SchoolMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolMS_API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Parent")]
    public class StudentParentController : ApiController
    {
        #region Objects
        Cls_StudentParents objParent = new Cls_StudentParents();
        #endregion


    }
}
