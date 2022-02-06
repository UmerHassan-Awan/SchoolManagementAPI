using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_Class
    {
        #region Objects
        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        Cls_SchoolBranch objSchoolBranch = new Cls_SchoolBranch();
        #endregion

        #region Private Variables

        private int _ClassID;
        private int _SchoolID;
        private int _SchoolBranchID;
        private string _ClassName;
        private DateTime? _EnteredDate;
        private string _EnteredBy;
        private DateTime? _UpdatedDate;
        private string _UpdatedBy;
        private DateTime? _DeletedDate;
        private string _DeletedBy;
        private bool _IsDeleted;

        #endregion

        #region Public Properties
        
        public int ClassID { get { return _ClassID; } set { _ClassID = value; } }
        public int SchoolID { get { return _SchoolID; } set { _SchoolID = value; } }
        public int SchoolBranchID { get { return _SchoolBranchID; } set { _SchoolBranchID = value; } }
        public string ClassName { get { return _ClassName; } set { _ClassName = value; } }
        public DateTime? EnteredDate { get { return _EnteredDate; } set { _EnteredDate = value; } }
        public string EnteredBy { get { return _EnteredBy; } set { _EnteredBy = value; } }
        public DateTime? UpdatedDate { get { return _UpdatedDate; } set { _UpdatedDate = value; } }
        public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
        public DateTime? DeletedDate { get { return _DeletedDate; } set { _DeletedDate = value; } }
        public string DeletedBy { get { return _DeletedBy; } set { _DeletedBy = value; } }
        public bool IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }
        public Cls_SchoolBranch BranchDetail { get; set; }

        #endregion

        #region DML Methods

        public string AddNewClass(Cls_Class Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolBranchID",Data.SchoolBranchID),
                new SqlParameter("@ClassName",Data.ClassName),
                new SqlParameter("@EnteredBy",Data.EnteredBy),
                new SqlParameter("@ModeType", "INSERT"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_Class");
        }

        public string UpdateClass(Cls_Class Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ClassID",Data.ClassID),
                new SqlParameter("@SchoolBranchID",Data.SchoolBranchID),
                new SqlParameter("@ClassName",Data.ClassName),
                new SqlParameter("@UpdatedBy",Data.UpdatedBy),
                new SqlParameter("@ModeType", "UPDATE"),

            };
            return objCommMethods.UpdateSQLMethod(sqlParams, "SP_Class");
        }

        public string DeleteClass(int classID, int userID)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ClassID",classID),
                new SqlParameter("@DeletedBy",userID),
                new SqlParameter("@ModeType", "DELETE"),

            };
            return objCommMethods.UpdateSQLMethod(sqlParams, "SP_Class");
        }

        #endregion

        #region DDL Methods
        public List<Cls_Class> GetAllClasses()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Class");
            List<Cls_Class> list = new List<Cls_Class>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_Class obj = new Cls_Class();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public List<Cls_Class> GetAllClassesBy_BranchID(int branchID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolBranchID", branchID),
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ModeType", "GetClassesByBranchID"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Class");
            List<Cls_Class> list = new List<Cls_Class>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_Class obj = new Cls_Class();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_Class GetClassBy_ClassID(int classID)
        {
            DataTable dt = new DataTable();
            Cls_Class objClass = new Cls_Class();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ClassID", classID),
                new SqlParameter("@Result", ""),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Class");
            if (dt.Rows.Count > 0)
            {
                objClass = FillListValues(objClass, dt, 0);
            }
            return objClass;
        }
        #endregion

        #region Private Methods

        private Cls_Class FillListValues(Cls_Class obj, DataTable dt, int row)
        {
            obj.ClassID = Convert.ToInt32(dt.Rows[row]["ClassID"]);
            obj.SchoolBranchID = Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]);
            obj.BranchDetail = objSchoolBranch.GetSchoolBranchBy_BranchID(Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]));
            obj.ClassName = Convert.ToString(dt.Rows[row]["ClassName"]);
            return obj;
        }
        #endregion
    }
}