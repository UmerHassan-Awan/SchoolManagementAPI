using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace SchoolMS_API.Models
{
    
    public class Cls_Students
    {
        #region Objects
        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        Cls_SchoolBranch objSclBranch = new Cls_SchoolBranch();
        #endregion

        #region Private Variables

        private int _StudentID;
        private int _SchoolBranchID;
        private int _ParentID;
        private string _StudentRegNo;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private DateTime? _DOB;
        private string _Gender;
        private string _BloodGroup;
        private string _BirthPlace;
        private string _Nationality;
        private DateTime? _AdmissionDate;
        private string _MotherTongue;
        private int _ReligionID;
        private string _Address;
        private string _Address2;
        private int _CountryID;
        private int _CityID;
        private int _AreaID;
        private string _Phone;
        private string _Mobile;
        private string _Email;
        private string _BiometricID;
        private string _LastSchoolName;
        private string _LastClass;
        private string _LastYear;
        private string _LastTotalMarks;
        private string _Picture;
        private string _Status;
        private string _ReasonOfLeaving;
        private bool _EnableEmailFeature;
        private bool _IsSMS;
        private bool _IsEmail;
        private bool _IsTransport;
        private bool _IsStudentCard;
        private bool _IsLibraryCard;
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

        
        public int StudentID { get { return _StudentID; } set { _StudentID = value; } }
        
        public int SchoolBranchID { get { return _SchoolBranchID; } set { _SchoolBranchID = value; } }

        public int ParentID { get { return _ParentID; } set { _ParentID = value; } }

        public string StudentRegNo { get { return _StudentRegNo; } set { _StudentRegNo = value; } }
        
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        
        public string MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }
        
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        
        public DateTime? DOB { get { return _DOB; } set { _DOB = value; } }
        
        public string Gender { get { return _Gender; } set { _Gender = value; } }
        
        public string BloodGroup { get { return _BloodGroup; } set { _BloodGroup = value; } }
        
        public string BirthPlace { get { return _BirthPlace; } set { _BirthPlace = value; } }
        
        public string Nationality { get { return _Nationality; } set { _Nationality = value; } }
        
        public DateTime? AdmissionDate { get { return _AdmissionDate; } set { _AdmissionDate = value; } }
        
        public string MotherTongue { get { return _MotherTongue; } set { _MotherTongue = value; } }
        
        public int ReligionID { get { return _ReligionID; } set { _ReligionID = value; } }
        
        public string Address { get { return _Address; } set { _Address = value; } }
        
        public string Address2 { get { return _Address2; } set { _Address2 = value; } }
        
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }
        
        public int CityID { get { return _CityID; } set { _CityID = value; } }
        
        public int AreaID { get { return _AreaID; } set { _AreaID = value; } }
        
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        
        public string Mobile { get { return _Mobile; } set { _Mobile = value; } }
        
        public string Email { get { return _Email; } set { _Email = value; } }
        
        public string BiometricID { get { return _BiometricID; } set { _BiometricID = value; } }
        
        public string LastSchoolName { get { return _LastSchoolName; } set { _LastSchoolName = value; } }
        
        public string LastClass { get { return _LastClass; } set { _LastClass = value; } }
        
        public string LastYear { get { return _LastYear; } set { _LastYear = value; } }
        
        public string LastTotalMarks { get { return _LastTotalMarks; } set { _LastTotalMarks = value; } }
        
        public string Picture { get { return _Picture; } set { _Picture = value; } }
        
        public string Status { get { return _Status; } set { _Status = value; } }
        
        public string ReasonOfLeaving { get { return _ReasonOfLeaving; } set { _ReasonOfLeaving = value; } }
        
        public bool EnableEmailFeature { get { return _EnableEmailFeature; } set { _EnableEmailFeature = value; } }
        
        public bool IsSMS { get { return _IsSMS; } set { _IsSMS = value; } }
        
        public bool IsEmail { get { return _IsEmail; } set { _IsEmail = value; } }
        
        public bool IsTransport { get { return _IsTransport; } set { _IsTransport = value; } }
        
        public bool IsStudentCard { get { return _IsStudentCard; } set { _IsStudentCard = value; } }
        
        public bool IsLibraryCard { get { return _IsLibraryCard; } set { _IsLibraryCard = value; } }
        
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        
        public DateTime? EnteredDate { get { return _EnteredDate; } set { _EnteredDate = value; } }
        
        public string EnteredBy { get { return _EnteredBy; } set { _EnteredBy = value; } }
        
        public DateTime? UpdatedDate { get { return _UpdatedDate; } set { _UpdatedDate = value; } }
        
        public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
        
        public DateTime? DeletedDate { get { return _DeletedDate; } set { _DeletedDate = value; } }
        
        public string DeletedBy { get { return _DeletedBy; } set { _DeletedBy = value; } }
        
        public bool IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }
        
        public Cls_SchoolBranch BranchDetail { get; set; }

        public Cls_StudentParents ParentDetail { get; set; }

        #endregion

        #region DML Methods
        public string AddNew_Student(Cls_Students Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolBranchID",Data.SchoolBranchID),
                new SqlParameter("@Address",Data.Address),
                new SqlParameter("@Address2",Data.Address2),
                new SqlParameter("@AdmissionDate",Convert.ToDateTime(Data.AdmissionDate)),
                new SqlParameter("@BirthPlace",Data.BirthPlace),
                new SqlParameter("@BloodGroup",Data.BloodGroup),
                new SqlParameter("@CityID",Data.CityID),
                new SqlParameter("@CountryID",Data.CountryID),
                new SqlParameter("@DOB",Convert.ToDateTime(Data.DOB)),
                new SqlParameter("@Email",Data.Email),
                new SqlParameter("@FirstName",Data.FirstName),
                new SqlParameter("@Gender",Data.Gender),
                new SqlParameter("@IsEmail",Data.IsEmail),
                new SqlParameter("@IsLibraryCard",Data.IsLibraryCard),
                new SqlParameter("@IsSMS",Data.IsSMS),
                new SqlParameter("@IsStudentCard",Data.IsStudentCard),
                new SqlParameter("@IsTransport",Data.IsTransport),
                new SqlParameter("@LastClass",Data.LastClass),
                new SqlParameter("@LastName",Data.LastName),
                new SqlParameter("@LastSchoolName",Data.LastSchoolName),
                new SqlParameter("@LastTotalMarks",Data.LastTotalMarks),
                new SqlParameter("@LastYear",Data.LastYear),
                new SqlParameter("@MiddleName",Data.MiddleName),
                new SqlParameter("@Mobile",Data.Mobile),
                new SqlParameter("@MotherTongue",Data.MotherTongue),
                new SqlParameter("@Nationality",Data.Nationality),
                new SqlParameter("@Phone",Data.Phone),
                new SqlParameter("@Picture",Data.Picture),
                new SqlParameter("@StudentRegNo",Data.StudentRegNo),
                new SqlParameter("@EnteredBy",Data.EnteredBy),
                new SqlParameter("@ModeType", "Insert"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_Student");
        }

        public string Update_Student(Cls_Students Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@StudentID",Data.StudentID),
                new SqlParameter("@SchoolBranchID",Data.SchoolBranchID),
                new SqlParameter("@Address",Data.Address),
                new SqlParameter("@Address2",Data.Address2),
                new SqlParameter("@BirthPlace",Data.BirthPlace),
                new SqlParameter("@BloodGroup",Data.BloodGroup),
                new SqlParameter("@CityID",Data.CityID),
                new SqlParameter("@CountryID",Data.CountryID),
                new SqlParameter("@DOB",Convert.ToDateTime(Data.DOB)),
                new SqlParameter("@Email",Data.Email),
                new SqlParameter("@FirstName",Data.FirstName),
                new SqlParameter("@Gender",Data.Gender),
                new SqlParameter("@IsEmail",Data.IsEmail),
                new SqlParameter("@IsLibraryCard",Data.IsLibraryCard),
                new SqlParameter("@IsSMS",Data.IsSMS),
                new SqlParameter("@IsStudentCard",Data.IsStudentCard),
                new SqlParameter("@IsTransport",Data.IsTransport),
                new SqlParameter("@LastClass",Data.LastClass),
                new SqlParameter("@LastName",Data.LastName),
                new SqlParameter("@LastSchoolName",Data.LastSchoolName),
                new SqlParameter("@LastTotalMarks",Data.LastTotalMarks),
                new SqlParameter("@LastYear",Data.LastYear),
                new SqlParameter("@MiddleName",Data.MiddleName),
                new SqlParameter("@Mobile",Data.Mobile),
                new SqlParameter("@MotherTongue",Data.MotherTongue),
                new SqlParameter("@Nationality",Data.Nationality),
                new SqlParameter("@Phone",Data.Phone),
                new SqlParameter("@Picture",Data.Picture),
                new SqlParameter("@UpdatedBy",Data.UpdatedBy),
                new SqlParameter("@ModeType", "Update"),

            };
            return objCommMethods.UpdateSQLMethod(sqlParams, "SP_Student");
        }

        public string DeleteStudent(int studentID, int userID)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@StudentID",studentID),
                new SqlParameter("@UpdatedBy",userID),
                new SqlParameter("@ModeType", "Delete")
            };
            return objCommMethods.UpdateSQLMethod(sqlParams, "SP_Student");
        }

        #endregion

        #region DDL Methods

        public Cls_Students GetStudentRegistrationNumber()
        {
            DataTable dt = new DataTable();
            Cls_Students objStudents = new Cls_Students();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ModeType", "GetStudentReg_Number"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Student");
            if (dt.Rows.Count > 0)
            {
                objStudents = FillRegistrationNumber(objStudents, dt, 0);
            }
            return objStudents;
        }

        public List<Cls_Students> GetAllStudents()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ModeType", "Get"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Student");
            List<Cls_Students> list = new List<Cls_Students>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_Students obj = new Cls_Students();
                obj.FillListValuesForAllStudents(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public List<Cls_Students> Get_Students_ByBranchID(int branchID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolBranchID", branchID),
                new SqlParameter("@ModeType", "Get_Students_ByBranchID"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Student");
            List<Cls_Students> list = new List<Cls_Students>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_Students obj = new Cls_Students();
                obj.FillListValuesForAllStudents(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region Private Methods
        private Cls_Students FillRegistrationNumber(Cls_Students obj, DataTable dt, int row)
        {
            obj.StudentRegNo = Convert.ToString(dt.Rows[row]["RegNo"]);
            return obj;
        }

        private Cls_Students FillListValuesForAllStudents(Cls_Students obj, DataTable dt, int row)
        {
            obj.StudentID = Convert.ToInt32(dt.Rows[row]["StudentID"]);
            obj.SchoolBranchID = Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]);
            obj.BranchDetail = objSclBranch.GetSchoolBranchBy_BranchID(Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]));
            obj.StudentRegNo = Convert.ToString(dt.Rows[row]["StudentRegNo"]);
            obj.AdmissionDate = Convert.ToDateTime(dt.Rows[row]["AdmissionDate"]);
            obj.FirstName = Convert.ToString(dt.Rows[row]["FirstName"]);
            obj.MiddleName = Convert.ToString(dt.Rows[row]["MiddleName"]);
            obj.LastName = Convert.ToString(dt.Rows[row]["LastName"]);
            obj.DOB = Convert.ToDateTime(dt.Rows[row]["DOB"]);
            obj.Gender = Convert.ToString(dt.Rows[row]["Gender"]);
            obj.BloodGroup = Convert.ToString(dt.Rows[row]["BloodGroup"]);
            obj.MotherTongue = Convert.ToString(dt.Rows[row]["MotherTongue"]);
            obj.BirthPlace = Convert.ToString(dt.Rows[row]["BirthPlace"]);
            obj.Nationality = Convert.ToString(dt.Rows[row]["Nationality"]);
            obj.Address = Convert.ToString(dt.Rows[row]["Address"]);
            obj.Address2 = Convert.ToString(dt.Rows[row]["Address2"]);
            obj.Picture = Convert.ToString(dt.Rows[row]["Picture"]);
            obj.CountryID = Convert.ToInt32(dt.Rows[row]["CountryID"]);
            obj.CityID = Convert.ToInt32(dt.Rows[row]["CityID"]);
            obj.Email = Convert.ToString(dt.Rows[row]["Email"]);
            obj.Phone = Convert.ToString(dt.Rows[row]["Phone"]);
            obj.Mobile = Convert.ToString(dt.Rows[row]["Mobile"]);
            obj.LastSchoolName = Convert.ToString(dt.Rows[row]["LastSchoolName"]);
            obj.LastClass = Convert.ToString(dt.Rows[row]["LastClass"]);
            obj.LastYear = Convert.ToString(dt.Rows[row]["LastYear"]);
            obj.LastTotalMarks = Convert.ToString(dt.Rows[row]["LastTotalMarks"]);
            obj.IsSMS = Convert.ToBoolean(dt.Rows[row]["IsSMS"]);
            obj.IsStudentCard = Convert.ToBoolean(dt.Rows[row]["IsStudentCard"]);
            obj.IsEmail = Convert.ToBoolean(dt.Rows[row]["IsEmail"]);
            obj.IsTransport = Convert.ToBoolean(dt.Rows[row]["IsTransport"]);
            obj.IsLibraryCard = Convert.ToBoolean(dt.Rows[row]["IsLibraryCard"]);
            return obj;
        }
        #endregion
    }
}