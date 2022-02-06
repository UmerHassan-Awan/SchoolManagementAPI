using SchoolMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolMS_API.Controllers
{
    [RoutePrefix("api/Locations")]
    public class LocationController : ApiController
    {
        #region Objects
        Cls_Location objLocation = new Cls_Location();
        Cls_APIResponse objResp = new Cls_APIResponse();
        #endregion

        [HttpGet]
        [Route("GetAllLocations")]
        public Cls_APIResponse GetAllLocations()
        {
            try
            {
                Cls_Location Detail = objLocation.GetAllLocations_Data();

                objResp.Data = Detail;
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
