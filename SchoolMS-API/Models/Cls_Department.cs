using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_Department
    {
        #region Objects
        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        #endregion

        #region Private Variables

        private int _DepartmentID;
        private int _SchoolBranchID;
        private string _Department;
        private DateTime? _EnteredDate;
        private string _EnteredBy;
        private DateTime? _UpdatedDate;
        private string _UpdatedBy;
        private DateTime? _DeletedDate;
        private string _DeletedBy;
        private bool _IsDeleted;

        #endregion

        #region Public Properties

        
        public int DepartmentID { get { return _DepartmentID; } set { _DepartmentID = value; } }
        
        public int SchoolBranchID { get { return _SchoolBranchID; } set { _SchoolBranchID = value; } }
        
        public string Department { get { return _Department; } set { _Department = value; } }
        
        public DateTime? EnteredDate { get { return _EnteredDate; } set { _EnteredDate = value; } }
        
        public string EnteredBy { get { return _EnteredBy; } set { _EnteredBy = value; } }
        
        public DateTime? UpdatedDate { get { return _UpdatedDate; } set { _UpdatedDate = value; } }
        
        public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
        
        public DateTime? DeletedDate { get { return _DeletedDate; } set { _DeletedDate = value; } }
        
        public string DeletedBy { get { return _DeletedBy; } set { _DeletedBy = value; } }
        
        public bool IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }

        #endregion

        #region DML Methods
        #endregion

        #region DDL Methods

        public List<Cls_Department> GetAllDepartments()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Department");
            List<Cls_Department> list = new List<Cls_Department>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_Department obj = new Cls_Department();
                obj.FillDepartment_ListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_Department GetDepartmentDetail_ByID(int deptID)
        {
            DataTable dt = new DataTable();
            Cls_Department objDepartment = new Cls_Department();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@DepartmentId", deptID),
                new SqlParameter("@Result", ""),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Department");
            if (dt.Rows.Count > 0)
            {
                objDepartment = FillDepartment_ListValues(objDepartment, dt, 0);
            }
            return objDepartment;
        }

        #endregion

        #region Private Methods

        private Cls_Department FillDepartment_ListValues(Cls_Department obj, DataTable dt, int row)
        {
            obj.DepartmentID = Convert.ToInt32(dt.Rows[row]["DepartmentID"]);
            obj.Department = Convert.ToString(dt.Rows[row]["Department"]);
            return obj;
        }
        #endregion
    }
}