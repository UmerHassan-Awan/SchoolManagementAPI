using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_StudentClass
    {
        #region Objects
        Cls_CommonMethods objComMethod = new Cls_CommonMethods();
        #endregion

        #region Private Variables
        private int _StudentRecordID;
        private int _StudentID;
        private int _ClassID;
        private int _SectionID;
        private int _BatchID;
        private string _RollNumber;
        #endregion

        #region Public Properties

        
        public int StudentRecordID { get { return _StudentRecordID; } set { _StudentRecordID = value; } }

        
        public int StudentID { get { return _StudentID; } set { _StudentID = value; } }

        
        public int ClassID { get { return _ClassID; } set { _ClassID = value; } }

        
        public int SectionID { get { return _SectionID; } set { _SectionID = value; } }

        
        public int BatchID { get { return _BatchID; } set { _BatchID = value; } }

        
        public string RollNumber { get { return _RollNumber; } set { _RollNumber = value; } }

        #endregion

        #region DML Methods
        public string AssignClass(Cls_StudentClass rawData)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@StudentID",rawData.StudentID),
                new SqlParameter("@ClassID",rawData.ClassID),
                new SqlParameter("@SectionID",rawData.SectionID),
                new SqlParameter("@ModeType", "Insert")
            };

            return objComMethod.InsertSQLMethod(sqlParams, "SP_StudentClassAssign");
        }
        #endregion

        #region DDL Methods
        #endregion

        #region Private Methods
        #endregion
    }
}