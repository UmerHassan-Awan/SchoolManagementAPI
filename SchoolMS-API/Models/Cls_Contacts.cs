using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_Contacts
    {
        #region Objects
        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        #endregion

        #region Private Variables

        private int _ContactID;
        private string _ContactType;
        private string _FirstName;
        private string _LastName;
        private string _Address1;
        private string _Address2;
        private int _CityID;
        private int _ProvinceID;
        private int _CountryID;
        private string _PostalZip;
        private string _Phone1;
        private string _Phone2;
        private string _Password;
        private string _Email;
        private string _Status;
        private DateTime? _DateEntered;
        private string _EnteredBy;
        private DateTime? _UpdatedOn;
        private string _UpdatedBy;
        private bool _IsDeleted;
        private string _DeletedBy;
        private DateTime? _DeletionDate;

        #endregion

        #region Public Properties

        
        public int ContactID { get { return _ContactID; } set { _ContactID = value; } }
        public string ContactType { get { return _ContactType; } set { _ContactType = value; } }
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string Address1 { get { return _Address1; } set { _Address1 = value; } }
        public string Address2 { get { return _Address2; } set { _Address2 = value; } }
        public int CityID { get { return _CityID; } set { _CityID = value; } }
        public int ProvinceID { get { return _ProvinceID; } set { _ProvinceID = value; } }
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }
        public string PostalZip { get { return _PostalZip; } set { _PostalZip = value; } }
        public string Phone1 { get { return _Phone1; } set { _Phone1 = value; } }
        public string Phone2 { get { return _Phone2; } set { _Phone2 = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Status { get { return _Status; } set { _Status = value; } }
        public DateTime? DateEntered { get { return _DateEntered; } set { _DateEntered = value; } }
        public string EnteredBy { get { return _EnteredBy; } set { _EnteredBy = value; } }
        public DateTime? UpdatedOn { get { return _UpdatedOn; } set { _UpdatedOn = value; } }
        public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
        public bool IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }
        public string DeletedBy { get { return _DeletedBy; } set { _DeletedBy = value; } }
        public string AccessToken { get; set; }
        public DateTime? DeletionDate { get { return _DeletionDate; } set { _DeletionDate = value; } }

        #endregion

        #region DML Methods
        #endregion

        #region DDL Methods

        public Cls_Contacts GetUserLogin(Cls_Contacts data)
        {
            DataTable dt = new DataTable();
            Cls_Contacts objContacts = new Cls_Contacts();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Email", data.Email),
                new SqlParameter("@Password", data.Password),
                new SqlParameter("@Result", ""),
                new SqlParameter("@ModeType", "GetUserForLogin"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_Contacts");
            if (dt.Rows.Count > 0)
            {
                objContacts = FillValues_ForLogin(objContacts, dt, 0);
            }
            return objContacts;
        }

        #endregion

        #region Private Methods
        private Cls_Contacts FillValues_ForLogin(Cls_Contacts obj, DataTable dt, int row)
        {
            obj.ContactID = Convert.ToInt32(dt.Rows[row]["ContactID"]);
            obj.ContactType = Convert.ToString(dt.Rows[row]["ContactType"]);
            obj.FirstName = Convert.ToString(dt.Rows[row]["FirstName"]);
            obj.LastName = Convert.ToString(dt.Rows[row]["LastName"]);
            return obj;
        }
        #endregion
    }
}