using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_SchoolBranch
    {
        #region Objects

        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        //Cls_City objCity = new Cls_City();
        Cls_Location.City objCity = new Cls_Location.City();
        Cls_Location.Province objProvince = new Cls_Location.Province();
        Cls_School_Information objSclInformation = new Cls_School_Information();

        #endregion

        #region Private Variables

        private int _BranchID;
        private int _SchoolID;
        private string _BranchName;
        private string _BranchOwnerName;
        private string _Email;
        private string _TelephoneNo;
        private string _MobileNo1;
        private string _MobileNo2;
        private string _Address;
        private int _CityID;
        private int _ProvinceID;
        private int _CountryID;
        private DateTime? _EnteredDate;
        private int _EnteredBy;
        private DateTime? _UpdatedDate;
        private int _UpdatedBy;
        private DateTime? _DeletedDate;
        private int _DeletedBy;
        private int _IsDeleted;

        #endregion

        #region Public Properties
        
        public int BranchID { get { return _BranchID; } set { _BranchID = value; } }
        
        public int SchoolID { get { return _SchoolID; } set { _SchoolID = value; } }
        
        public string BranchName { get { return _BranchName; } set { _BranchName = value; } }
        
        public string BranchOwnerName { get { return _BranchOwnerName; } set { _BranchOwnerName = value; } }
        
        public string Email { get { return _Email; } set { _Email = value; } }
        
        public string TelephoneNo { get { return _TelephoneNo; } set { _TelephoneNo = value; } }
        
        public string MobileNo1 { get { return _MobileNo1; } set { _MobileNo1 = value; } }
        
        public string MobileNo2 { get { return _MobileNo2; } set { _MobileNo2 = value; } }
        
        public string Address { get { return _Address; } set { _Address = value; } }
        
        public int CityID { get { return _CityID; } set { _CityID = value; } }
        
        public int ProvinceID { get { return _ProvinceID; } set { _ProvinceID = value; } }
        
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }
        
        public DateTime? EnteredDate { get { return _EnteredDate; } set { _EnteredDate = value; } }
        
        public int EnteredBy { get { return _EnteredBy; } set { _EnteredBy = value; } }
        
        public DateTime? UpdatedDate { get { return _UpdatedDate; } set { _UpdatedDate = value; } }
        
        public int UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
        
        public DateTime? DeletedDate { get { return _DeletedDate; } set { _DeletedDate = value; } }
        
        public int DeletedBy { get { return _DeletedBy; } set { _DeletedBy = value; } }
        
        public int IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }

        
        public Cls_Location.Province Province { get; set; }
        
        public Cls_Location.City City { get; set; }
        
        public Cls_School_Information SchoolInfo { get; set; }
        #endregion

        #region DML Methods

        public string AddNewSchool_Branch(Cls_SchoolBranch Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolID",Data.SchoolID),
                new SqlParameter("@BranchName",Data.BranchName),
                new SqlParameter("@BranchOwnerName",Data.BranchOwnerName),
                new SqlParameter("@TelephoneNo",Data.TelephoneNo),
                new SqlParameter("@MobileNo1",Data.MobileNo1),
                new SqlParameter("@MobileNo2",Data.MobileNo2),
                new SqlParameter("@Email",Data.Email),
                new SqlParameter("@Address",Data.Address),
                new SqlParameter("@CityID",Data.CityID),
                new SqlParameter("@ProvinceID",Data.ProvinceID),
                new SqlParameter("@CountryID",Data.CountryID),
                new SqlParameter("@EnteredBy",Data.EnteredBy),
                new SqlParameter("@ModeType", "INSERT"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_SchoolBranches");
        }

        public string UpdateSchool_Branch(Cls_SchoolBranch Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@BranchID",Data.BranchID),
                new SqlParameter("@SchoolID",Data.SchoolID),
                new SqlParameter("@BranchName",Data.BranchName),
                new SqlParameter("@BranchOwnerName",Data.BranchOwnerName),
                new SqlParameter("@TelephoneNo",Data.TelephoneNo),
                new SqlParameter("@MobileNo1",Data.MobileNo1),
                new SqlParameter("@MobileNo2",Data.MobileNo2),
                new SqlParameter("@Email",Data.Email),
                new SqlParameter("@Address",Data.Address),
                new SqlParameter("@CityID",Data.CityID),
                new SqlParameter("@ProvinceID",Data.ProvinceID),
                new SqlParameter("@CountryID",Data.CountryID),
                new SqlParameter("@UpdatedBy",Data.UpdatedBy),
                new SqlParameter("@ModeType", "Update"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_SchoolBranches");
        }

        public string DeleteBranch(int branchID)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@BranchID",branchID),
                new SqlParameter("@ModeType", "DeleteBranch"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_SchoolBranches");
        }
        #endregion

        #region DDL Methods
        public List<Cls_SchoolBranch> GetAllSchoolBranches()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_SchoolBranches");
            List<Cls_SchoolBranch> list = new List<Cls_SchoolBranch>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_SchoolBranch obj = new Cls_SchoolBranch();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public List<Cls_SchoolBranch> GetAllSchoolBranches_BySchoolID(int sclID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@SchoolID", sclID),
                new SqlParameter("@ModeType", "GetBranchDetailBy_SchoolID"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_SchoolBranches");
            List<Cls_SchoolBranch> list = new List<Cls_SchoolBranch>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_SchoolBranch obj = new Cls_SchoolBranch();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_SchoolBranch GetSchoolBranchBy_BranchID(int branchID)
        {
            DataTable dt = new DataTable();
            Cls_SchoolBranch objSclBranch = new Cls_SchoolBranch();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@BranchID", branchID),
                new SqlParameter("@Result", ""),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_SchoolBranches");
            if (dt.Rows.Count > 0)
            {
                objSclBranch = FillListValues(objSclBranch, dt, 0);
            }
            return objSclBranch;
        }

        public Cls_SchoolBranch GetSchoolBranchBy_SchoolID(int sclID)
        {
            DataTable dt = new DataTable();
            Cls_SchoolBranch objSclBranch = new Cls_SchoolBranch();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@BranchID", sclID),
                new SqlParameter("@Result", ""),
                new SqlParameter("@ModeType", "GetBranchDetailBy_SchoolID"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_SchoolBranches");
            if (dt.Rows.Count > 0)
            {
                objSclBranch = FillListValues(objSclBranch, dt, 0);
            }
            return objSclBranch;
        }
        #endregion

        #region Private Methods

        private Cls_SchoolBranch FillListValues(Cls_SchoolBranch obj, DataTable dt, int row)
        {
            obj.BranchID = Convert.ToInt32(dt.Rows[row]["BranchID"]);
            obj.SchoolID = Convert.ToInt32(dt.Rows[row]["SchoolID"]);
            obj.SchoolInfo = objSclInformation.GetSchoolByID(Convert.ToInt32(dt.Rows[row]["SchoolID"]));
            obj.BranchName = Convert.ToString(dt.Rows[row]["BranchName"]);
            obj.BranchOwnerName = Convert.ToString(dt.Rows[row]["BranchOwnerName"]);
            obj.TelephoneNo = Convert.ToString(dt.Rows[row]["TelephoneNo"]);
            obj.MobileNo1 = Convert.ToString(dt.Rows[row]["MobileNo1"]);
            obj.MobileNo2 = Convert.ToString(dt.Rows[row]["MobileNo2"]);
            obj.Address = Convert.ToString(dt.Rows[row]["Address"]);
            obj.CityID = Convert.ToInt32(dt.Rows[row]["CityID"]);
            obj.City = objCity.GetCityByID(Convert.ToInt32(dt.Rows[row]["CityID"]));
            obj.CountryID = Convert.ToInt32(dt.Rows[row]["CountryID"]);
            obj.Email = Convert.ToString(dt.Rows[row]["Email"]);
            obj.ProvinceID = Convert.ToInt32(dt.Rows[row]["ProvinceID"]);
            obj.Province = objProvince.GetProvinceByID(Convert.ToInt32(dt.Rows[row]["ProvinceID"]));
            return obj;
        }

        #endregion
    }
}