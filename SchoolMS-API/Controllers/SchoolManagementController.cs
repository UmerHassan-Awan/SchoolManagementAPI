using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolMS_API.Models;

namespace SchoolMS_API.Controllers
{
    [Authorize]
    [RoutePrefix("api/SchoolManag")]
    public class SchoolManagementController : ApiController
    {
        #region Objects
        Cls_School_Information objSclInfo = new Cls_School_Information();
        Cls_APIResponse objResp = new Cls_APIResponse();
        #endregion

        [HttpGet]
        [Route("GetAllSchools")]
        public Cls_APIResponse GetAllSchools()
        {
            try
            {
                List<Cls_School_Information> List = objSclInfo.GetAllSchools();

                objResp.Data = List;
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

        [HttpPost]
        [Route("AddNewSchool")]
        public Cls_APIResponse AddNewSchool([FromBody] Cls_School_Information rawData)
        {
            try
            {
                objResp.Message = objSclInfo.AddNewSchool(rawData);
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

        [HttpPost]
        [Route("UpdateSchool")]
        public Cls_APIResponse UpdateSchool([FromBody] Cls_School_Information rawData)
        {
            try
            {
                objResp.Message = objSclInfo.UpdateSchool(rawData);
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

        [HttpGet]
        [Route("DeleteSchool")]
        public Cls_APIResponse DeleteSchool(int id)
        {
            try
            {
                objResp.Message = objSclInfo.DeleteSchool(id);
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

        [HttpGet]
        [Route("GetSchoolByID")]
        public Cls_APIResponse GetSchoolByID(int SclID)
        {
            try
            {
                Cls_School_Information SclDetail = objSclInfo.GetSchoolByID(SclID);

                objResp.Data = SclDetail;
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
