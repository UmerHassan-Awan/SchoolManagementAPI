using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace SchoolMS_API.Models
{
    public class Cls_City
    {
        #region Objects 
        Cls_CommonMethods objCommMethods = new Cls_CommonMethods();
        #endregion

        #region Private Variables 

        private int _CityId;
        private int _CountryID;
        private string _CityName;

        #endregion

        #region Public Properties

        
        public int CityId { get { return _CityId; } set { _CityId = value; } }

        
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }

        
        public string CityName { get { return _CityName; } set { _CityName = value; } }
        

        #endregion

        #region DDL Methods
        public List<Cls_City> GetAllCities()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_City");
            List<Cls_City> list = new List<Cls_City>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cls_City obj = new Cls_City();
                obj.FillListValues(obj, dt, i);
                list.Add(obj);
            }
            return list;
        }

        public Cls_City GetCityByID(int cityID)
        {
            DataTable dt = new DataTable();
            Cls_City objCity = new Cls_City();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@CityID", cityID),
                new SqlParameter("@ModeType", "GET"),
            };
            dt = objCommMethods.SQL_FillData(sqlParams, "SP_City");
            if (dt.Rows.Count > 0)
            {
                objCity = FillValuesByID(objCity, dt, 0);
            }
            return objCity;
        }

        #endregion


        #region Private Methods

        private Cls_City FillListValues(Cls_City obj, DataTable dt, int row)
        {
            obj.CityId = Convert.ToInt32(dt.Rows[row]["CityId"]);
            obj.CountryID = Convert.ToInt32(dt.Rows[row]["CountryID"]);
            obj.CityName = Convert.ToString(dt.Rows[row]["CityName"]);
            return obj;
        }
        private Cls_City FillValuesByID(Cls_City obj, DataTable dt, int row)
        {
            obj.CityId = Convert.ToInt32(dt.Rows[row]["CityId"]);
            obj.CountryID = Convert.ToInt32(dt.Rows[row]["CountryID"]);
            obj.CityName = Convert.ToString(dt.Rows[row]["CityName"]);
            return obj;
        }

        #endregion
        
    }
}