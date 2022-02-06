using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_ClassSections
    {
        #region Objects

        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        Cls_Class objClass = new Cls_Class();
        Cls_SchoolBranch objSchoolBranch = new Cls_SchoolBranch();

        #endregion

        #region Private Variables

        private int _ClassSectionID;
        private int _SchoolBranchID;
        private int _ClassID;
        private string _SectionName;
        private DateTime? _EnteredDate;
        private string _EnteredBy;
        private DateTime? _UpdatedDate;
        private string _UpdatedBy;
        private DateTime? _DeletedDate;
        private string _DeletedBy;
        private bool _IsDeleted;

        #endregion

        #region Public Properties


        
        public int ClassSectionID { get { return _ClassSectionID; } set { _ClassSectionID = value; } }

        
        public int SchoolBranchID { get { return _SchoolBranchID; } set { _SchoolBranchID = value; } }

        
        public int ClassID { get { return _ClassID; } set { _ClassID = value; } }

        
        public string SectionName { get { return _SectionName; } set { _SectionName = value; } }

        
        public DateTime? EnteredDate { get { return _EnteredDate; } set { _EnteredDate = value; } }

        
        public string EnteredBy { get { return _EnteredBy; } set { _EnteredBy = value; } }

        
        public DateTime? UpdatedDate { get { return _UpdatedDate; } set { _UpdatedDate = value; } }

        
        public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

        
        public DateTime? DeletedDate { get { return _DeletedDate; } set { _DeletedDate = value; } }

        
        public string DeletedBy { get { return _DeletedBy; } set { _DeletedBy = value; } }

        
        public bool IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }

        
        public Cls_Class ClassDetail { get; set; }

        
        public Cls_SchoolBranch BranchDetail { get; set; }
        #endregion

        #region DML Methods

        public string AddNewClass_Section(Cls_ClassSections Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolBranchID",Data.SchoolBranchID),
                new SqlParameter("@ClassID",Data.ClassID),
                new SqlParameter("@SectionName",Data.SectionName),
                new SqlParameter("@EnteredBy",Data.EnteredBy),
                new SqlParameter("@ModeType", "INSERT"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_ClassSection");
        }

        public string UpdateClass_Section(Cls_ClassSections Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ClassSectionID",Data.ClassSectionID),
                new SqlParameter("@SchoolBranchID",Data.SchoolBranchID),
                new SqlParameter("@ClassID",Data.ClassID),
                new SqlParameter("@SectionName",Data.SectionName),
                new SqlParameter("@UpdatedBy",Data.UpdatedBy),
                new SqlParameter("@ModeType", "UPDATE"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_ClassSection");
        }

        public string DeleteClass_Section(int sectionID, int userID)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ClassSectionID",sectionID),
                new SqlParameter("@DeletedBy",userID),
                new SqlParameter("@ModeType", "DELETE"),

            };
            return objCommMethods.UpdateSQLMethod(sqlParams, "SP_ClassSection");
        }
        #endregion

        #region DDL Methods

        public List<Cls_ClassSections> GetAllClassSections()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_ClassSection");
            List<Cls_ClassSections> list = new List<Cls_ClassSections>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_ClassSections obj = new Cls_ClassSections();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public List<Cls_ClassSections> GetAllClassSections_ByClassID(int classID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ClassID", classID),
                new SqlParameter("@ModeType", "GETSECTIONSBYCLASS"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_ClassSection");
            List<Cls_ClassSections> list = new List<Cls_ClassSections>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_ClassSections obj = new Cls_ClassSections();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_ClassSections GetClassSectionByID(int sectionID)
        {
            DataTable dt = new DataTable();
            Cls_ClassSections objClassSection = new Cls_ClassSections();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ClassSectionID", sectionID),
                new SqlParameter("@Result", ""),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_ClassSection");
            if (dt.Rows.Count > 0)
            {
                objClassSection = FillDataForSectionByID(objClassSection, dt, 0);
            }
            return objClassSection;
        }

        #endregion

        #region Private Methods
        private Cls_ClassSections FillListValues(Cls_ClassSections obj, DataTable dt, int row)
        {
            obj.ClassSectionID = Convert.ToInt32(dt.Rows[row]["ClassSectionID"]);
            obj.ClassID = Convert.ToInt32(dt.Rows[row]["ClassID"]);
            obj.SchoolBranchID = Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]);
            obj.ClassDetail = objClass.GetClassBy_ClassID(Convert.ToInt32(dt.Rows[row]["ClassID"]));
            obj.BranchDetail = objSchoolBranch.GetSchoolBranchBy_BranchID(Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]));
            obj.SectionName = Convert.ToString(dt.Rows[row]["SectionName"]);
            return obj;
        }

        private Cls_ClassSections FillDataForSectionByID(Cls_ClassSections obj, DataTable dt, int row)
        {
            obj.ClassSectionID = Convert.ToInt32(dt.Rows[row]["ClassSectionID"]);
            obj.ClassID = Convert.ToInt32(dt.Rows[row]["ClassID"]);
            obj.SchoolBranchID = Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]);
            obj.ClassDetail = objClass.GetClassBy_ClassID(Convert.ToInt32(dt.Rows[row]["ClassID"]));
            obj.BranchDetail = objSchoolBranch.GetSchoolBranchBy_BranchID(Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]));
            obj.SectionName = Convert.ToString(dt.Rows[row]["SectionName"]);
            return obj;
        }
        #endregion
    }
}