using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_Employee
    {
        #region Objects
        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        Cls_EmpPositions objEmployeePositions = new Cls_EmpPositions();
        Cls_Department objDepartment = new Cls_Department();
        Cls_Qualification objQualification = new Cls_Qualification();
        Cls_EmployeeType objEmpType = new Cls_EmployeeType();
        Cls_SchoolBranch objSclBranch = new Cls_SchoolBranch();
        #endregion

        #region Private Variables
        private int _EmployeeID;
        private int _SchoolBranchID;
        private int _EmployeeTypeID;
        private string _EmployeeNo;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private string _CNIC;
        private string _Gender;
        private DateTime? _DOB;
        private DateTime? _JoiningDate;
        private string _Title;
        private string _MobileNo;
        private string _MobileNo2;
        private string _MobileNo3;
        private string _Email;
        private string _Fax;
        private string _Address;
        private string _Address2;
        private int _CountryID;
        private int _AreaID;
        private int _CityID;
        private int _DepartmentID;
        private int _PositionID;
        private int _QualificationId;
        private string _Experience;
        private string _ExperienceInfo;
        private decimal _Salary;
        private string _MaritalStatus;
        private string _FatherName;
        private string _MotherName;
        private string _BloodGroup;
        private string _LastEmployeer;
        private string _ReasonOfLeaving;
        private string _BiometricNo;
        private string _UserName;
        private string _Password;
        private string _Picture;
        private byte[] _BinaryPicture;
        private bool _IsActive;
        private DateTime? _EnteredDate;
        private string _EnteredBy;
        private DateTime? _UpdatedDate;
        private string _UpdatedBy;
        private DateTime? _DeletedDate;
        private string _DeletedBy;
        private bool _IsDeleted;
        #endregion

        #region Public Properties

        
        public int EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } }
        
        public int SchoolBranchID { get { return _SchoolBranchID; } set { _SchoolBranchID = value; } }
        
        public int EmployeeTypeID { get { return _EmployeeTypeID; } set { _EmployeeTypeID = value; } }
        
        public string EmployeeNo { get { return _EmployeeNo; } set { _EmployeeNo = value; } }
        
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        
        public string MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }
        
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        
        public string CNIC { get { return _CNIC; } set { _CNIC = value; } }
        
        public string Gender { get { return _Gender; } set { _Gender = value; } }
        
        public DateTime? DOB { get { return _DOB; } set { _DOB = value; } }
        
        public DateTime? JoiningDate { get { return _JoiningDate; } set { _JoiningDate = value; } }
        
        public string Title { get { return _Title; } set { _Title = value; } }
        
        public string MobileNo { get { return _MobileNo; } set { _MobileNo = value; } }
        
        public string MobileNo2 { get { return _MobileNo2; } set { _MobileNo2 = value; } }
        
        public string MobileNo3 { get { return _MobileNo3; } set { _MobileNo3 = value; } }
        
        public string Email { get { return _Email; } set { _Email = value; } }
        
        public string Fax { get { return _Fax; } set { _Fax = value; } }
        
        public string Address { get { return _Address; } set { _Address = value; } }
        
        public string Address2 { get { return _Address2; } set { _Address2 = value; } }
        
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }
        
        public int AreaID { get { return _AreaID; } set { _AreaID = value; } }
        
        public int CityID { get { return _CityID; } set { _CityID = value; } }
        
        public int DepartmentID { get { return _DepartmentID; } set { _DepartmentID = value; } }
        
        public int PositionID { get { return _PositionID; } set { _PositionID = value; } }
        
        public int QualificationId { get { return _QualificationId; } set { _QualificationId = value; } }
        
        public string Experience { get { return _Experience; } set { _Experience = value; } }
        
        public string ExperienceInfo { get { return _ExperienceInfo; } set { _ExperienceInfo = value; } }
        
        public decimal Salary { get { return _Salary; } set { _Salary = value; } }
        
        public string MaritalStatus { get { return _MaritalStatus; } set { _MaritalStatus = value; } }
        
        public string FatherName { get { return _FatherName; } set { _FatherName = value; } }
        
        public string MotherName { get { return _MotherName; } set { _MotherName = value; } }
        
        public string BloodGroup { get { return _BloodGroup; } set { _BloodGroup = value; } }
        
        public string LastEmployeer { get { return _LastEmployeer; } set { _LastEmployeer = value; } }
        
        public string ReasonOfLeaving { get { return _ReasonOfLeaving; } set { _ReasonOfLeaving = value; } }
        
        public string BiometricNo { get { return _BiometricNo; } set { _BiometricNo = value; } }
        
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        
        public string Password { get { return _Password; } set { _Password = value; } }
        
        public string Picture { get { return _Picture; } set { _Picture = value; } }
        
        public byte[] BinaryPicture { get { return _BinaryPicture; } set { _BinaryPicture = value; } }
        
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        
        public DateTime? EnteredDate { get { return _EnteredDate; } set { _EnteredDate = value; } }
        
        public string EnteredBy { get { return _EnteredBy; } set { _EnteredBy = value; } }
        
        public DateTime? UpdatedDate { get { return _UpdatedDate; } set { _UpdatedDate = value; } }
        
        public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
        
        public DateTime? DeletedDate { get { return _DeletedDate; } set { _DeletedDate = value; } }
        
        public string DeletedBy { get { return _DeletedBy; } set { _DeletedBy = value; } }
        
        public bool IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }
        
        public Cls_EmpPositions EmpPositionDetail { get; set; }
        
        public Cls_Department DepartmentDetail { get; set; }
        
        public Cls_Qualification QualificationDetail { get; set; }
        
        public Cls_EmployeeType EmployeeTypeDetail { get; set; }
        
        public Cls_SchoolBranch BranchDetail { get; set; }
        #endregion

        #region DML Methods

        public string AddNew_Employee(Cls_Employee Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolBranchID",Data.SchoolBranchID),
                new SqlParameter("@EmployeeTypeID",Data.EmployeeTypeID),
                new SqlParameter("@EmployeeNo",Data.EmployeeNo),
                new SqlParameter("@FirstName",Data.FirstName),
                new SqlParameter("@MiddleName",Data.MiddleName),
                new SqlParameter("@LastName",Data.LastName),
                new SqlParameter("@CNIC",Data.CNIC),
                new SqlParameter("@Gender",Data.Gender),
                new SqlParameter("@DOB",Convert.ToDateTime(Data.DOB)),
                new SqlParameter("@JoiningDate",Convert.ToDateTime(Data.JoiningDate)),
                new SqlParameter("@BloodGroup",Data.BloodGroup),
                new SqlParameter("@CityID",Data.CityID),
                new SqlParameter("@CountryID",Data.CountryID),
                new SqlParameter("@Email",Data.Email),
                new SqlParameter("@Title",Data.Title),
                new SqlParameter("@MobileNo",Data.MobileNo),
                new SqlParameter("@MobileNo2",Data.MobileNo2),
                new SqlParameter("@MobileNo3",Data.MobileNo3),
                new SqlParameter("@Address",Data.Address),
                new SqlParameter("@Address2",Data.Address2),
                new SqlParameter("@DepartmentID",Data.DepartmentID),
                new SqlParameter("@PositionID",Data.PositionID),
                new SqlParameter("@QualificationId",Data.QualificationId),
                new SqlParameter("@Experience",Data.Experience),
                new SqlParameter("@ExperienceInfo",Data.ExperienceInfo),
                new SqlParameter("@Salary",Data.Salary),
                new SqlParameter("@MaritalStatus",Data.MaritalStatus),
                new SqlParameter("@FatherName",Data.FatherName),
                new SqlParameter("@MotherName",Data.MotherName),
                new SqlParameter("@LastEmployeer",Data.LastEmployeer),
                new SqlParameter("@ReasonOfLeaving",Data.ReasonOfLeaving),
                new SqlParameter("@Picture",Data.Picture),
                new SqlParameter("@UserName",Data.UserName),
                new SqlParameter("@Password",Data.Password),
                new SqlParameter("@EnteredBy",Data.EnteredBy),
                new SqlParameter("@ModeType", "INSERT"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_Employee");
        }

        public string UpdateEmployee(Cls_Employee Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID",Data.EmployeeID),
                new SqlParameter("@SchoolBranchID",Data.SchoolBranchID),
                new SqlParameter("@EmployeeTypeID",Data.EmployeeTypeID),
                new SqlParameter("@EmployeeNo",Data.EmployeeNo),
                new SqlParameter("@FirstName",Data.FirstName),
                new SqlParameter("@MiddleName",Data.MiddleName),
                new SqlParameter("@LastName",Data.LastName),
                new SqlParameter("@CNIC",Data.CNIC),
                new SqlParameter("@Gender",Data.Gender),
                new SqlParameter("@DOB",Convert.ToDateTime(Data.DOB)),
                new SqlParameter("@JoiningDate",Convert.ToDateTime(Data.JoiningDate)),
                new SqlParameter("@BloodGroup",Data.BloodGroup),
                new SqlParameter("@CityID",Data.CityID),
                new SqlParameter("@CountryID",Data.CountryID),
                new SqlParameter("@Email",Data.Email),
                new SqlParameter("@Title",Data.Title),
                new SqlParameter("@MobileNo",Data.MobileNo),
                new SqlParameter("@MobileNo2",Data.MobileNo2),
                new SqlParameter("@MobileNo3",Data.MobileNo3),
                new SqlParameter("@Address",Data.Address),
                new SqlParameter("@Address2",Data.Address2),
                new SqlParameter("@DepartmentID",Data.DepartmentID),
                new SqlParameter("@PositionID",Data.PositionID),
                new SqlParameter("@QualificationId",Data.QualificationId),
                new SqlParameter("@Experience",Data.Experience),
                new SqlParameter("@ExperienceInfo",Data.ExperienceInfo),
                new SqlParameter("@Salary",Data.Salary),
                new SqlParameter("@MaritalStatus",Data.MaritalStatus),
                new SqlParameter("@FatherName",Data.FatherName),
                new SqlParameter("@MotherName",Data.MotherName),
                new SqlParameter("@LastEmployeer",Data.LastEmployeer),
                new SqlParameter("@ReasonOfLeaving",Data.ReasonOfLeaving),
                new SqlParameter("@Picture",Data.Picture),
                new SqlParameter("@UserName",Data.UserName),
                new SqlParameter("@Password",Data.Password),
                new SqlParameter("@UpdatedBy",Data.UpdatedBy),
                new SqlParameter("@ModeType", "UPDATE"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_Employee");
        }

        public string DeleteEmployee(int employeeID, int UserID)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID",employeeID),
                new SqlParameter("@DeletedBy",UserID),
                new SqlParameter("@ModeType", "DELETE"),

            };
            return objCommMethods.UpdateSQLMethod(sqlParams, "SP_Employee");
        }
        #endregion

        #region DDL Methods
        public Cls_Employee GetEmployeeRegistrationNumber()
        {
            DataTable dt = new DataTable();
            Cls_Employee objEmployee = new Cls_Employee();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ModeType", "GetEmployee_RegNo"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Employee");
            if (dt.Rows.Count > 0)
            {
                objEmployee = FillRegistrationNumber(objEmployee, dt, 0);
            }
            return objEmployee;
        }

        public List<Cls_Employee> GetAllEmployees()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Employee");
            List<Cls_Employee> list = new List<Cls_Employee>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_Employee obj = new Cls_Employee();
                obj.FillListValuesForAllEmployees(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_Employee GetEmployeeDetail_ByID(int empID)
        {
            DataTable dt = new DataTable();
            Cls_Employee objEmployee = new Cls_Employee();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID", empID),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Employee");
            if (dt.Rows.Count > 0)
            {
                objEmployee = FillListValuesForAllEmployees(objEmployee, dt, 0);
            }
            return objEmployee;
        }


        #endregion

        #region Private Methods
        private Cls_Employee FillRegistrationNumber(Cls_Employee obj, DataTable dt, int row)
        {
            obj.EmployeeNo = Convert.ToString(dt.Rows[row]["EmployeeNo"]);
            return obj;
        }

        private Cls_Employee FillListValuesForAllEmployees(Cls_Employee obj, DataTable dt, int row)
        {
            obj.EmployeeID = Convert.ToInt32(dt.Rows[row]["EmployeeID"]);
            obj.EmployeeTypeID = Convert.ToInt32(dt.Rows[row]["EmployeeTypeID"]);
            obj.SchoolBranchID = Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]);
            obj.DepartmentID = Convert.ToInt32(dt.Rows[row]["DepartmentID"]);
            obj.PositionID = Convert.ToInt32(dt.Rows[row]["PositionID"]);
            obj.QualificationId = Convert.ToInt32(dt.Rows[row]["QualificationId"]);
            obj.CountryID = Convert.ToInt32(dt.Rows[row]["CountryID"]);
            obj.CityID = Convert.ToInt32(dt.Rows[row]["CityID"]);
            obj.EmployeeNo = Convert.ToString(dt.Rows[row]["EmployeeNo"]);
            obj.FirstName = Convert.ToString(dt.Rows[row]["FirstName"]);
            obj.MiddleName = Convert.ToString(dt.Rows[row]["MiddleName"]);
            obj.LastName = Convert.ToString(dt.Rows[row]["LastName"]);
            obj.CNIC = Convert.ToString(dt.Rows[row]["CNIC"]);
            obj.DOB = Convert.ToDateTime(dt.Rows[row]["DOB"]);
            obj.JoiningDate = Convert.ToDateTime(dt.Rows[row]["JoiningDate"]);
            obj.Gender = Convert.ToString(dt.Rows[row]["Gender"]);
            obj.Email = Convert.ToString(dt.Rows[row]["Email"]);
            obj.BloodGroup = Convert.ToString(dt.Rows[row]["BloodGroup"]);
            obj.MaritalStatus = Convert.ToString(dt.Rows[row]["MaritalStatus"]);
            obj.FatherName = Convert.ToString(dt.Rows[row]["FatherName"]);
            obj.MotherName = Convert.ToString(dt.Rows[row]["MotherName"]);
            obj.Address = Convert.ToString(dt.Rows[row]["Address"]);
            obj.Address2 = Convert.ToString(dt.Rows[row]["Address2"]);
            obj.MobileNo = Convert.ToString(dt.Rows[row]["MobileNo"]);
            obj.MobileNo2 = Convert.ToString(dt.Rows[row]["MobileNo2"]);
            obj.MobileNo3 = Convert.ToString(dt.Rows[row]["MobileNo3"]);
            obj.Title = Convert.ToString(dt.Rows[row]["Title"]);
            obj.Experience = Convert.ToString(dt.Rows[row]["Experience"]);
            obj.ExperienceInfo = Convert.ToString(dt.Rows[row]["ExperienceInfo"]);
            obj.Salary = Convert.ToDecimal(dt.Rows[row]["Salary"]);
            obj.LastEmployeer = Convert.ToString(dt.Rows[row]["LastEmployeer"]);
            obj.ReasonOfLeaving = Convert.ToString(dt.Rows[row]["ReasonOfLeaving"]);
            obj.UserName = Convert.ToString(dt.Rows[row]["UserName"]);
            obj.Password = Convert.ToString(dt.Rows[row]["Password"]);
            obj.Picture = Convert.ToString(dt.Rows[row]["Picture"]);
            obj.BranchDetail = objSclBranch.GetSchoolBranchBy_BranchID(Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]));
            obj.DepartmentDetail = objDepartment.GetDepartmentDetail_ByID(Convert.ToInt32(dt.Rows[row]["DepartmentID"]));
            obj.EmployeeTypeDetail = objEmpType.GetEmpTypeDetail_ByID(Convert.ToInt32(dt.Rows[row]["EmployeeTypeID"]));
            obj.QualificationDetail = objQualification.GetQualificationDetail_ByID(Convert.ToInt32(dt.Rows[row]["QualificationId"]));
            obj.EmpPositionDetail = objEmployeePositions.GetPositionDetail_ByID(Convert.ToInt32(dt.Rows[row]["PositionID"]));
            
            return obj;
        }
        #endregion
    }
}