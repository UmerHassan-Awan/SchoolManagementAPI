using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_School_Information
    {
        #region Objects

        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        Cls_City objCity = new Cls_City();
        #endregion

        #region Private Variables

        private int _SchoolID;
        private string _SchoolName;
        private string _OwnerName;
        private string _LandLineNo;
        private string _MobileNo;
        private string _MobileNo2;
        private string _MobileNo3;
        private string _Address;
        private string _Address2;
        private int _CityID;
        private int _CountryID;
        private string _Email;
        private bool _IsActive;
        private DateTime? _SessionStartDate;
        private DateTime? _SessionEndDate;

        #endregion

        #region Public Properties

        
        public int SchoolID { get { return _SchoolID; } set { _SchoolID = value; } }

        
        public string SchoolName { get { return _SchoolName; } set { _SchoolName = value; } }

        
        public string OwnerName { get { return _OwnerName; } set { _OwnerName = value; } }

        
        public string LandLineNo { get { return _LandLineNo; } set { _LandLineNo = value; } }

        
        public string MobileNo { get { return _MobileNo; } set { _MobileNo = value; } }

        
        public string MobileNo2 { get { return _MobileNo2; } set { _MobileNo2 = value; } }

        
        public string MobileNo3 { get { return _MobileNo3; } set { _MobileNo3 = value; } }

        
        public string Address { get { return _Address; } set { _Address = value; } }

        
        public string Address2 { get { return _Address2; } set { _Address2 = value; } }

        
        public int CityID { get { return _CityID; } set { _CityID = value; } }

        
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }

        
        public string Email { get { return _Email; } set { _Email = value; } }

        
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

        
        public DateTime? SessionStartDate { get { return _SessionStartDate; } set { _SessionStartDate = value; } }

        
        public DateTime? SessionEndDate { get { return _SessionEndDate; } set { _SessionEndDate = value; } }

        
        public List<Cls_SchoolBranch> SchoolBranches { get; set; }

        
        public Cls_City City { get; set; }

        #endregion

        #region DML Methods

        public string AddNewSchool(Cls_School_Information Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolName",Data.SchoolName),
                new SqlParameter("@OwnerName",Data.OwnerName),
                new SqlParameter("@LandLineNo",Data.LandLineNo),
                new SqlParameter("@MobileNo",Data.MobileNo),
                new SqlParameter("@MobileNo2",Data.MobileNo2),
                new SqlParameter("@MobileNo3",Data.MobileNo3),
                new SqlParameter("@Address",Data.Address),
                new SqlParameter("@Address2",Data.Address2),
                new SqlParameter("@CityID",Data.CityID),
                new SqlParameter("@Email",Data.Email),
                new SqlParameter("@IsActive",Data.IsActive),
                new SqlParameter("@ModeType", "INSERT"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_SchoolInformation");
        }

        public string UpdateSchool(Cls_School_Information Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolID",Data.SchoolID),
                new SqlParameter("@SchoolName",Data.SchoolName),
                new SqlParameter("@OwnerName",Data.OwnerName),
                new SqlParameter("@LandLineNo",Data.LandLineNo),
                new SqlParameter("@MobileNo",Data.MobileNo),
                new SqlParameter("@MobileNo2",Data.MobileNo2),
                new SqlParameter("@MobileNo3",Data.MobileNo3),
                new SqlParameter("@Address",Data.Address),
                new SqlParameter("@Address2",Data.Address2),
                new SqlParameter("@CityID",Data.CityID),
                new SqlParameter("@Email",Data.Email),
                new SqlParameter("@IsActive",Data.IsActive),
                new SqlParameter("@ModeType", "UPDATE"),

            };
            return objCommMethods.UpdateSQLMethod(sqlParams, "SP_SchoolInformation");
        }

        public string DeleteSchool(int id)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolID",id),
                new SqlParameter("@ModeType", "DELETE")

            };
            return objCommMethods.UpdateSQLMethod(sqlParams, "SP_SchoolInformation");
        }
        #endregion

        #region DDL Methods
        public List<Cls_School_Information> GetAllSchools()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_SchoolInformation");
            List<Cls_School_Information> list = new List<Cls_School_Information>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_School_Information obj = new Cls_School_Information();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_School_Information GetSchoolByID(int schoolID)
        {
            DataTable dt = new DataTable();
            Cls_School_Information objSclInfo = new Cls_School_Information();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolID", schoolID),
                new SqlParameter("@Result", "Get"),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_SchoolInformation");
            if (dt.Rows.Count > 0)
            {
                objSclInfo = FillListValues(objSclInfo, dt, 0);
            }
            return objSclInfo;
        }
        #endregion

        #region Private Methods

        private Cls_School_Information FillListValues(Cls_School_Information obj, DataTable dt, int row)
        {
            obj.SchoolID = Convert.ToInt32(dt.Rows[row]["SchoolID"]);
            obj.SchoolName = Convert.ToString(dt.Rows[row]["SchoolName"]);
            obj.OwnerName = Convert.ToString(dt.Rows[row]["OwnerName"]);
            obj.LandLineNo = Convert.ToString(dt.Rows[row]["LandLineNo"]);
            obj.MobileNo = Convert.ToString(dt.Rows[row]["MobileNo"]);
            obj.MobileNo2 = Convert.ToString(dt.Rows[row]["MobileNo2"]);
            obj.MobileNo3 = Convert.ToString(dt.Rows[row]["MobileNo3"]);
            obj.Address = Convert.ToString(dt.Rows[row]["Address"]);
            obj.Address2 = Convert.ToString(dt.Rows[row]["Address2"]);
            obj.City = objCity.GetCityByID(Convert.ToInt32(dt.Rows[row]["CityID"]));
            obj.CountryID = Convert.ToInt32(dt.Rows[row]["CountryID"]);
            obj.Email = Convert.ToString(dt.Rows[row]["Email"]);
            obj.IsActive = Convert.ToBoolean(dt.Rows[row]["IsActive"]);
            return obj;
        }

        #endregion
    }
}