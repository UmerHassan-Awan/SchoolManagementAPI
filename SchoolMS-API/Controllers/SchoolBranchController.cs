using SchoolMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolMS_API.Controllers
{
    [RoutePrefix("api/SchoolBranch")]
    public class SchoolBranchController : ApiController
    {
        #region Objects
        Cls_SchoolBranch objSclBranch = new Cls_SchoolBranch();
        Cls_APIResponse objResp = new Cls_APIResponse();
        #endregion

        [HttpGet]
        [Route("GetAllSchool_Branches")]
        public Cls_APIResponse GetAllSchool_Branches()
        {
            try
            {
                List<Cls_SchoolBranch> List = objSclBranch.GetAllSchoolBranches();

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
        [Route("AddSchoolBranch")]
        public Cls_APIResponse AddSchoolBranch([FromBody] Cls_SchoolBranch rawData)
        {
            try
            {
                objResp.Message = objSclBranch.AddNewSchool_Branch(rawData);
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
        [Route("UpdateSchoolBranch")]
        public Cls_APIResponse UpdateSchoolBranch([FromBody] Cls_SchoolBranch rawData)
        {
            try
            {
                objResp.Message = objSclBranch.UpdateSchool_Branch(rawData);
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
        [Route("GetAllBranchesBy_SchoolID")]
        public Cls_APIResponse GetAllBranchesBy_SchoolID(string sclID)
        {
            try
            {
                List<Cls_SchoolBranch> List = objSclBranch.GetAllSchoolBranches_BySchoolID(Convert.ToInt32(sclID));

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

        [HttpGet]
        [Route("GetBranchByID")]
        public Cls_APIResponse GetBranchByID(int branchID)
        {
            try
            {
                Cls_SchoolBranch SclDetail = objSclBranch.GetSchoolBranchBy_BranchID(branchID);

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

        [HttpGet]
        [Route("DeleteBranch")]
        public Cls_APIResponse DeleteBranch(int branchID)
        {
            try
            {
                objResp.Message = objSclBranch.DeleteBranch(branchID);
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
