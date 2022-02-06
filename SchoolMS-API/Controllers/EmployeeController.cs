using SchoolMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolMS_API.Controllers
{
    [RoutePrefix("api/EmployeeManag")]
    public class EmployeeController : ApiController
    {
        #region Objects
        Cls_EmpPositions objEmp_Positions = new Cls_EmpPositions();
        Cls_Employee objEmployee = new Cls_Employee();
        Cls_EmployeeType objEmployeeType = new Cls_EmployeeType();
        Cls_APIResponse objResp = new Cls_APIResponse();
        #endregion

        [HttpGet]
        [Route("GetAllEmployee_Positions")]
        public Cls_APIResponse GetAllEmployee_Positions()
        {
            try
            {
                List<Cls_EmpPositions> EmpPositionList = objEmp_Positions.GetAllEmployee_Positions();

                objResp.Data = EmpPositionList;
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
        [Route("GetEmployeeRegNo")]
        public Cls_APIResponse GetEmployeeRegNo()
        {
            try
            {
                Cls_Employee EmpData = objEmployee.GetEmployeeRegistrationNumber();

                objResp.Data = EmpData;
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
        [Route("GetAllEmployeeTypes")]
        public Cls_APIResponse GetAllEmployeeTypes()
        {
            try
            {
                List<Cls_EmployeeType> List = objEmployeeType.GetAllEmployee_Types();

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
        [Route("RegisterEmployee")]
        public Cls_APIResponse RegisterEmployee([FromBody] Cls_Employee rawData)
        {
            try
            {
                objResp.Message = objEmployee.AddNew_Employee(rawData);
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
        [Route("GetAllEmployees")]
        public Cls_APIResponse GetAllEmployees()
        {
            try
            {
                List<Cls_Employee> List = objEmployee.GetAllEmployees();

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
        [Route("GetEmployeeDetail_ByID")]
        public Cls_APIResponse GetEmployeeDetail_ByID(int employeeID)
        {
            try
            {
                Cls_Employee EmpData = objEmployee.GetEmployeeDetail_ByID(employeeID);

                objResp.Data = EmpData;
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
        [Route("UpdateEmployee")]
        public Cls_APIResponse UpdateEmployee([FromBody] Cls_Employee rawData)
        {
            try
            {
                objResp.Message = objEmployee.UpdateEmployee(rawData);
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
        [Route("DeleteEmployee")]
        public Cls_APIResponse DeleteEmployee(int employeeID, int userID)
        {
            try
            {
                objResp.Message = objEmployee.DeleteEmployee(employeeID, userID);
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
