using SchoolMS_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace SchoolMS_API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        #region Objects
        Cls_Students objStudent = new Cls_Students();
        Cls_StudentClass objStdClass = new Cls_StudentClass();
        Cls_StudentParents objParent = new Cls_StudentParents();
        Cls_APIResponse objResp = new Cls_APIResponse();
        #endregion

        [HttpGet]
        [Route("GetStudentRegNo")]
        public Cls_APIResponse GetStudentRegNo()
        {
            try
            {
                Cls_Students StdDetail = objStudent.GetStudentRegistrationNumber();

                objResp.Data = StdDetail;
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
        [Route("RegisterStudent")]
        public Cls_APIResponse RegisterStudent([FromBody] Cls_Students rawData)
        {
            try 
            {
                string Result = "";

                if (rawData.ParentID == 0)// If parent not exist then add parent first
                {
                    Result = objParent.AddNew_Parent(rawData.ParentDetail);

                    int n;
                    bool isNumeric = int.TryParse(Result, out n);


                    if (!isNumeric)
                    {
                        objResp.Message = Result;
                        objResp.StatusCode = 0;

                        return objResp;
                    }
                    else { rawData.ParentID = Convert.ToInt32(Result); }
                }

                string dirPath = System.Web.HttpContext.Current.Server.MapPath("~/StudentImages/");

                if (rawData.Picture != "https://i.pinimg.com/originals/ae/8a/c2/ae8ac2fa217d23aadcc913989fcc34a2.png")
                {
                    byte[] StudentimageBytes = Convert.FromBase64String(Regex.Replace(rawData.Picture, @"^data:image\/[a-zA-Z]+;base64,", string.Empty));
                    rawData.Picture = Guid.NewGuid().ToString() + ".jpg";
                    File.WriteAllBytes(dirPath + rawData.Picture, StudentimageBytes);
                }
                else
                {
                    rawData.Picture = null;
                }

                rawData.ParentID = rawData.ParentDetail.ParentID;
                objResp.Message = objStudent.AddNew_Student(rawData);
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
        [Route("GetAllStudents")]
        public Cls_APIResponse GetAllStudents()
        {
            try
            {
                List<Cls_Students> List = objStudent.GetAllStudents();

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
        [Route("GetStudentByID")]
        public Cls_APIResponse GetStudentByID(int stdID)
        {
            try
            {
                List<Cls_Students> AllStudents = objStudent.GetAllStudents();
                Cls_Students SclDetail = AllStudents.Where(s => s.StudentID == stdID).FirstOrDefault();

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

        [HttpPost]
        [Route("UpdateStudent")]
        public Cls_APIResponse UpdateStudent([FromBody] Cls_Students rawData)
        {
            try
            {
                objResp.Message = objStudent.Update_Student(rawData);
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
        [Route("DeleteStudent")]
        public Cls_APIResponse DeleteStudent(int studentID, int userID)
        {
            try
            {
                objResp.Message = objStudent.DeleteStudent(studentID, userID);
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
        [Route("GetStudentsBy_BranchID")]
        public Cls_APIResponse GetStudentsBy_BranchID(int branchID)
        {
            try
            {
                List<Cls_Students> List = objStudent.Get_Students_ByBranchID(branchID);

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
        [Route("AssignStudentClass")]
        public Cls_APIResponse AssignStudentClass([FromBody] Cls_StudentClass rawData)
        {
            try
            {
                objResp.Message = objStdClass.AssignClass(rawData);
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
