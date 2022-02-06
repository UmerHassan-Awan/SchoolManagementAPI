using SchoolMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolMS_API.Controllers
{
    [RoutePrefix("api/ClassManag")]
    public class ClassController : ApiController
    {
        #region Objects
        Cls_Class objSclClass = new Cls_Class();
        Cls_APIResponse objResp = new Cls_APIResponse();
        #endregion

        [HttpGet]
        [Route("GetAllClasses")]
        public Cls_APIResponse GetAllClasses()
        {
            try 
            {
                List<Cls_Class> ClassList = objSclClass.GetAllClasses();
                
                objResp.Data = ClassList;
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
        [Route("AddNewClass")]
        public Cls_APIResponse AddNewClass([FromBody] Cls_Class rawData)
        {
            try 
            {
                objResp.Message = objSclClass.AddNewClass(rawData);
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
        [Route("UpdateClass")]
        public Cls_APIResponse UpdateClass([FromBody] Cls_Class rawData)
        {
            try
            {
                objResp.Message = objSclClass.UpdateClass(rawData);
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
        [Route("DeleteClass")]
        public Cls_APIResponse DeleteClass(int classID, int userID)
        {
            try
            {
                objResp.Message = objSclClass.DeleteClass(classID, userID);
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
        [Route("GetClasessBy_BranchID")]
        public Cls_APIResponse GetClasessBy_BranchID(int branchID)
        {
            try
            {
                List<Cls_Class> ClassList = objSclClass.GetAllClassesBy_BranchID(branchID);

                objResp.Data = ClassList;
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
        [Route("GetClasessByID")]
        public Cls_APIResponse GetClasessByID(int classID)
        {
            try
            {
                Cls_Class ClassDetail = objSclClass.GetClassBy_ClassID(classID);

                objResp.Data = ClassDetail;
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
