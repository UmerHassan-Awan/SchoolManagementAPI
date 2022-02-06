using SchoolMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolMS_API.Controllers
{
    [RoutePrefix("api/ClassSectManag")]
    public class ClassSectionsController : ApiController
    {
        #region Objects
        Cls_ClassSections objClasSection = new Cls_ClassSections();
        Cls_APIResponse objResp = new Cls_APIResponse();
        #endregion

        [HttpGet]
        [Route("GetAllClassSections")]
        public Cls_APIResponse GetAllClassSections()
        {
            try
            {
                List<Cls_ClassSections> ClassSecList = objClasSection.GetAllClassSections();

                objResp.Data = ClassSecList;
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
        [Route("AddClassSection")]
        public Cls_APIResponse AddClassSection([FromBody] Cls_ClassSections rawData)
        {
            try
            {
                objResp.Message = objClasSection.AddNewClass_Section(rawData);
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
        [Route("UpdateClassSection")]
        public Cls_APIResponse UpdateClassSection([FromBody] Cls_ClassSections rawData)
        {
            try
            {
                objResp.Message = objClasSection.UpdateClass_Section(rawData);
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
        [Route("DeleteClassSection")]
        public Cls_APIResponse DeleteClassSection(int sectionID, int userID)
        {
            try
            {
                objResp.Message = objClasSection.DeleteClass_Section(sectionID, userID);
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
        [Route("GetClassSectionsBy_ClassID")]
        public Cls_APIResponse GetClassSectionsBy_ClassID(int classID)
        {
            try
            {
                List<Cls_ClassSections> ClassSecList = objClasSection.GetAllClassSections_ByClassID(classID);

                objResp.Data = ClassSecList;
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
        [Route("GetClassSectionByID")]
        public Cls_APIResponse GetClasessByID(int sectID)
        {
            try
            {
                Cls_ClassSections ClassSecDetail = objClasSection.GetClassSectionByID(sectID);

                objResp.Data = ClassSecDetail;
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
