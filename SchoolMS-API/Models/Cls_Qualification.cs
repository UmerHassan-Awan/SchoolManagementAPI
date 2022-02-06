using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_Qualification
    {
        #region Objects
        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        #endregion

        #region Private Variables
        private int _QualificationId;
        private int _SchoolBranchID;
        private string _Qualification;
        private DateTime? _EnteredDate;
        private string _EnteredBy;
        private DateTime? _UpdatedDate;
        private string _UpdatedBy;
        private DateTime? _DeletedDate;
        private string _DeletedBy;
        private bool _IsDeleted;
        #endregion

        #region Public Properties

        
        public int QualificationId { get { return _QualificationId; } set { _QualificationId = value; } }
        
        public int SchoolBranchID { get { return _SchoolBranchID; } set { _SchoolBranchID = value; } }
        
        public string Qualification { get { return _Qualification; } set { _Qualification = value; } }
        
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

        public List<Cls_Qualification> GetAllQualifications()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Result", "GET"),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Qualifications");
            List<Cls_Qualification> list = new List<Cls_Qualification>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_Qualification obj = new Cls_Qualification();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_Qualification GetQualificationDetail_ByID(int qualificationID)
        {
            DataTable dt = new DataTable();
            Cls_Qualification objQualification = new Cls_Qualification();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@QualificationID", qualificationID),
                new SqlParameter("@Result", ""),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Qualifications");
            if (dt.Rows.Count > 0)
            {
                objQualification = FillListValues(objQualification, dt, 0);
            }
            return objQualification;
        }

        #endregion

        #region Private Methods

        private Cls_Qualification FillListValues(Cls_Qualification obj, DataTable dt, int row)
        {
            obj.QualificationId = Convert.ToInt32(dt.Rows[row]["QualificationId"]);
            obj.Qualification = Convert.ToString(dt.Rows[row]["Qualification"]);
            return obj;
        }
        #endregion
    }
}