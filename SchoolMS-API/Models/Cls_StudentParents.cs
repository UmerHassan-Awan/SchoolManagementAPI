using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_StudentParents
    {
        #region Objects

        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        Cls_SchoolBranch objSclBranch = new Cls_SchoolBranch();

        #endregion

        #region Public Properties
        public int ParentID { get; set; }
        public string Relation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CNIC { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string MobileNumber2 { get; set; }
        public string Occupation { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsSMS { get; set; }
        public bool IsEmail { get; set; }
        public DateTime EnteredDate { get; set; }
        public int EnteredBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public int DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        #region DML Methods

        public string AddNew_Parent(Cls_StudentParents Data)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@FirstName",Data.FirstName),
                new SqlParameter("@LastName",Data.LastName),
                new SqlParameter("@Relation",Data.Relation),
                new SqlParameter("@Gender",Data.Gender),
                new SqlParameter("@CNIC",Data.CNIC),
                new SqlParameter("@Email",Data.Email),
                new SqlParameter("@MobileNumber",Data.MobileNumber),
                new SqlParameter("@MobileNumber2",Data.MobileNumber2),
                new SqlParameter("@Occupation",Data.Occupation),
                new SqlParameter("@IsEmail",Data.IsEmail),
                new SqlParameter("@IsSMS",Data.IsSMS),
                new SqlParameter("@EnteredBy",Data.EnteredBy),
                new SqlParameter("@ModeType", "InsertParent"),

            };
            return objCommMethods.InsertSQLMethod(sqlParams, "SP_StudentParent");
        }

        #endregion
    }
}