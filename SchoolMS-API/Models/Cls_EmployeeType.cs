using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_EmployeeType
    {
        #region Objects
        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        #endregion

        #region Private Variables

        private int _EmployeeTypeID;
        private string _Name;
        private DateTime? _EnteredDate;
        private string _EnteredBy;
        private DateTime? _UpdatedDate;
        private string _UpdatedBy;
        private DateTime? _DeletedDate;
        private string _DeletedBy;
        private bool _IsDeleted;

        #endregion

        #region Public Properties

        
        public int EmployeeTypeID { get { return _EmployeeTypeID; } set { _EmployeeTypeID = value; } }
        
        public string Name { get { return _Name; } set { _Name = value; } }
        
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

        public List<Cls_EmployeeType> GetAllEmployee_Types()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_EmployeeType");
            List<Cls_EmployeeType> list = new List<Cls_EmployeeType>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_EmployeeType obj = new Cls_EmployeeType();
                obj.FillDepartment_ListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_EmployeeType GetEmpTypeDetail_ByID(int empTypeID)
        {
            DataTable dt = new DataTable();
            Cls_EmployeeType objEmpType = new Cls_EmployeeType();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@EmployeeTypeId", empTypeID),
                new SqlParameter("@Result", ""),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_EmployeeType");
            if (dt.Rows.Count > 0)
            {
                objEmpType = FillDepartment_ListValues(objEmpType, dt, 0);
            }
            return objEmpType;
        }

        #endregion

        #region Private Methods

        private Cls_EmployeeType FillDepartment_ListValues(Cls_EmployeeType obj, DataTable dt, int row)
        {
            obj.EmployeeTypeID = Convert.ToInt32(dt.Rows[row]["EmployeeTypeID"]);
            obj.Name = Convert.ToString(dt.Rows[row]["Name"]);
            return obj;
        }
        #endregion
    }
}