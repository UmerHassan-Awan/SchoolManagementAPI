using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_EmpPositions
    {
        #region Objects
        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        #endregion

        #region Private Variables

        private int _PositionID;
        private int _SchoolBranchID;
        private string _Position;
        private DateTime? _EnteredDate;
        private string _EnteredBy;
        private DateTime? _UpdatedDate;
        private string _UpdatedBy;
        private DateTime? _DeletedDate;
        private string _DeletedBy;
        private bool _IsDeleted;

        #endregion

        #region Public Properties

        
        public int PositionID { get { return _PositionID; } set { _PositionID = value; } }
        
        public int SchoolBranchID { get { return _SchoolBranchID; } set { _SchoolBranchID = value; } }
        
        public string Position { get { return _Position; } set { _Position = value; } }
        
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

        public List<Cls_EmpPositions> GetAllEmployee_Positions()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Position");
            List<Cls_EmpPositions> list = new List<Cls_EmpPositions>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_EmpPositions obj = new Cls_EmpPositions();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_EmpPositions GetPositionDetail_ByID(int positionID)
        {
            DataTable dt = new DataTable();
            Cls_EmpPositions objEmpPositions = new Cls_EmpPositions();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@PositionID", positionID),
                new SqlParameter("@Result", ""),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Position");
            if (dt.Rows.Count > 0)
            {
                objEmpPositions = FillListValues(objEmpPositions, dt, 0);
            }
            return objEmpPositions;
        }

        #endregion

        #region Private Methods

        private Cls_EmpPositions FillListValues(Cls_EmpPositions obj, DataTable dt, int row)
        {
            obj.PositionID = Convert.ToInt32(dt.Rows[row]["PositionID"]);
            obj.Position = Convert.ToString(dt.Rows[row]["Position"]);
            return obj;
        }
        #endregion
    }
}