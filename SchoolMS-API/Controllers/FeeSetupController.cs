using SchoolMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolMS_API.Controllers
{
    [RoutePrefix("api/FeeSetupManag")]
    public class FeeSetupController : ApiController
    {
        #region Objects
        Cls_FeeSetup objFeeSetup = new Cls_FeeSetup();
        Cls_APIResponse objResp = new Cls_APIResponse();
        #endregion

        [HttpPost]
        [Route("AddFees")]
        public Cls_APIResponse AddFees([FromBody] Cls_FeeSetup rawData)
        {
            try
            {
                objResp.Message = objFeeSetup.AddNewFees(rawData);
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
        [Route("GetAllFeeses")]
        public Cls_APIResponse GetAllFeeses()
        {
            try
            {
                List<Cls_FeeSetup> List = objFeeSetup.GetAllFeeses();

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
        [Route("GetFeesByID")]
        public Cls_APIResponse GetFeesByID(int feesID)
        {
            try
            {
                Cls_FeeSetup FeeDetail = objFeeSetup.GetFees_ByID(feesID);

                objResp.Data = FeeDetail;
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
        [Route("UpdateFees")]
        public Cls_APIResponse UpdateFees([FromBody] Cls_FeeSetup rawData)
        {
            try
            {
                objResp.Message = objFeeSetup.UpdateFees(rawData);
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
        [Route("DeleteFees")]
        public Cls_APIResponse DeleteFees(int feesID, int userID)
        {
            try
            {
                objResp.Message = objFeeSetup.DeleteFees(feesID, userID);
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
