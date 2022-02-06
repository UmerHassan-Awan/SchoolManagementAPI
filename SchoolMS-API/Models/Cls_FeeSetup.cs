using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_FeeSetup
    {
        #region Objects

        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        Cls_SchoolBranch objSclBranch = new Cls_SchoolBranch();

        #endregion

        #region Private Variables

        private int _FeeID;
        private int _SchoolBranchID;
        private string _FeesName;
        private decimal _Amount;
        private decimal _LateCharges;
        private bool _isActive;
        private DateTime? _EnteredDate;
        private string _EnteredBy;
        private DateTime? _UpdatedDate;
        private string _UpdatedBy;
        private DateTime? _DeletedDate;
        private string _DeletedBy;
        private bool _IsDeleted;

        #endregion

        #region Public Properties

        
        public int FeeID { get { return _FeeID; } set { _FeeID = value; } }
        
        public int SchoolBranchID { get { return _SchoolBranchID; } set { _SchoolBranchID = value; } }
        
        public string FeesName { get { return _FeesName; } set { _FeesName = value; } }
        
        public decimal Amount { get { return _Amount; } set { _Amount = value; } }
        
        public decimal LateCharges { get { return _LateCharges; } set { _LateCharges = value; } }
        
        public bool isActive { get { return _isActive; } set { _isActive = value; } }
        
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

        public string AddNewFees(Cls_FeeSetup Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@SchoolBranchID",Data.SchoolBranchID),
                new SqlParameter("@FeesName",Data.FeesName),
                new SqlParameter("@Amount",Data.Amount),
                new SqlParameter("@LateCharges",Data.LateCharges),
                new SqlParameter("@EnteredBy",Data.EnteredBy),
                new SqlParameter("@ModeType", "INSERT"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_FeeSetup");
        }

        public string UpdateFees(Cls_FeeSetup Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@FeeID",Data.FeeID),
                new SqlParameter("@SchoolBranchID",Data.SchoolBranchID),
                new SqlParameter("@FeesName",Data.FeesName),
                new SqlParameter("@Amount",Data.Amount),
                new SqlParameter("@LateCharges",Data.LateCharges),
                new SqlParameter("@UpdatedBy",Data.UpdatedBy),
                new SqlParameter("@ModeType", "UPDATE"),

            };
            return objCommMethods.UpdateSQLMethod(sqlParams, "SP_FeeSetup");
        }

        public string DeleteFees(int feesID, int userID)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@FeeID",feesID),
                new SqlParameter("@DeletedBy",userID),
                new SqlParameter("@ModeType", "DELETE")
            };
            return objCommMethods.UpdateSQLMethod(sqlParams, "SP_FeeSetup");
        }

        #endregion

        #region DDL Methods
        public List<Cls_FeeSetup> GetAllFeeses()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_FeeSetup");
            List<Cls_FeeSetup> list = new List<Cls_FeeSetup>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_FeeSetup obj = new Cls_FeeSetup();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_FeeSetup GetFees_ByID(int feesID)
        {
            DataTable dt = new DataTable();
            Cls_FeeSetup objFees = new Cls_FeeSetup();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@FeeID", feesID),
                new SqlParameter("@Result", ""),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_FeeSetup");
            if (dt.Rows.Count > 0)
            {
                objFees = FillDataByID(objFees, dt, 0);
            }
            return objFees;
        }
        #endregion

        #region Private Methods

        private Cls_FeeSetup FillListValues(Cls_FeeSetup obj, DataTable dt, int row)
        {
            obj.FeeID = Convert.ToInt32(dt.Rows[row]["FeeID"]);
            obj.SchoolBranchID = Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]);
            obj.BranchDetail = objSclBranch.GetSchoolBranchBy_BranchID(Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]));
            obj.FeesName = Convert.ToString(dt.Rows[row]["FeesName"]);
            obj.Amount = Convert.ToDecimal(dt.Rows[row]["Amount"]);
            obj.LateCharges = Convert.ToDecimal(dt.Rows[row]["LateCharges"]);
            return obj;
        }

        private Cls_FeeSetup FillDataByID(Cls_FeeSetup obj, DataTable dt, int row)
        {
            obj.FeeID = Convert.ToInt32(dt.Rows[row]["FeeID"]);
            obj.SchoolBranchID = Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]);
            obj.BranchDetail = objSclBranch.GetSchoolBranchBy_BranchID(Convert.ToInt32(dt.Rows[row]["SchoolBranchID"]));
            obj.FeesName = Convert.ToString(dt.Rows[row]["FeesName"]);
            obj.Amount = Convert.ToDecimal(dt.Rows[row]["Amount"]);
            obj.LateCharges = Convert.ToDecimal(dt.Rows[row]["LateCharges"]);
            return obj;
        }

        #endregion
    }
}