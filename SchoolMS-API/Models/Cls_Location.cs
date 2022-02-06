using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_Location
    {
        #region Objects

        Country objCountry = new Country();
        Province objProvince = new Province();
        City objCity = new City();

        #endregion

        
        public List<Country> CountryList { get; set; }

        
        public List<Province> ProvinceList { get; set; }

        
        public List<City> CityList { get; set; }

        public Cls_Location GetAllLocations_Data()
        {
            Cls_Location objLocation = new Cls_Location();

            objLocation.CountryList = objCountry.GetAllCountries();
            objLocation.ProvinceList = objProvince.GetAllProvinces();
            objLocation.CityList = objCity.GetAllCities();
            return objLocation;
        }


        
        public class Country
        {
            #region Objects

            Cls_CommonMethods objCommMethod = new Cls_CommonMethods();

            #endregion

            #region Private Variables

            private int _CountryID;
            private string _CountryName;

            #endregion

            #region Public Properties

            
            public int CountryID { get { return _CountryID; } set { _CountryID = value; } }

            
            public string CountryName { get { return _CountryName; } set { _CountryName = value; } }

            #endregion

            #region DML Methods

            #endregion

            #region DDL Methods

            public List<Cls_Location.Country> GetAllCountries()
            {
                DataTable dt = new DataTable();
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                new SqlParameter("@ModeType", "GET"),
                };
                dt = objCommMethod.SQL_FillData(sqlParams, "SP_Country");
                List<Cls_Location.Country> list = new List<Cls_Location.Country>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Cls_Location.Country obj = new Cls_Location.Country();
                    obj.FillListValues(obj, dt, i);
                    list.Add(obj);
                }
                return list;
            }

            #endregion

            #region Private Methods
            private Cls_Location.Country FillListValues(Cls_Location.Country obj, DataTable dt, int row)
            {
                obj.CountryID = Convert.ToInt32(dt.Rows[row]["CountryID"]);
                obj.CountryName = Convert.ToString(dt.Rows[row]["CountryName"]);
                return obj;
            }
            #endregion
        }

        
        public class Province
        {
            #region Objects

            Cls_CommonMethods objCommMethod = new Cls_CommonMethods();

            #endregion

            #region Private Variables

            private int _ProvinceID;
            private int _CountryID;
            private string _ProvinceName;

            #endregion

            #region Public Properties

            
            public int ProvinceID { get { return _ProvinceID; } set { _ProvinceID = value; } }

            
            public int CountryID { get { return _CountryID; } set { _CountryID = value; } }

            
            public string ProvinceName { get { return _ProvinceName; } set { _ProvinceName = value; } }

            #endregion

            #region DML Methods
            #endregion

            #region DDL Methods
            public List<Cls_Location.Province> GetAllProvinces()
            {
                DataTable dt = new DataTable();
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                new SqlParameter("@ModeType", "GET"),
                };
                dt = objCommMethod.SQL_FillData(sqlParams, "SP_Province");
                List<Cls_Location.Province> list = new List<Cls_Location.Province>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Cls_Location.Province obj = new Cls_Location.Province();
                    obj.FillListValues(obj, dt, i);
                    list.Add(obj);
                }
                return list;
            }

            public Cls_Location.Province GetProvinceByID(int provinceID)
            {
                DataTable dt = new DataTable();
                Cls_Location.Province objProvince = new Cls_Location.Province();
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                new SqlParameter("@ProvinceID", provinceID),
                new SqlParameter("@ModeType", "GET"),
                };
                dt = objCommMethod.SQL_FillData(sqlParams, "SP_Province");
                if (dt.Rows.Count > 0)
                {
                    objProvince = FillListValues(objProvince, dt, 0);
                }
                return objProvince;
            }
            #endregion

            #region Private Methods

            private Cls_Location.Province FillListValues(Cls_Location.Province obj, DataTable dt, int row)
            {
                obj.ProvinceID = Convert.ToInt32(dt.Rows[row]["ProvinceID"]);
                obj.CountryID = Convert.ToInt32(dt.Rows[row]["CountryID"]);
                obj.ProvinceName = Convert.ToString(dt.Rows[row]["ProvinceName"]);

                return obj;
            }
            #endregion
        }

        
        public class City
        {
            #region Objects

            Cls_CommonMethods objCommMethod = new Cls_CommonMethods();

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

            #region DML Methods
            #endregion

            #region DDL Methods

            public List<Cls_Location.City> GetAllCities()
            {
                DataTable dt = new DataTable();
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                new SqlParameter("@ModeType", "GET"),
                };
                dt = objCommMethod.SQL_FillData(sqlParams, "SP_City");
                List<Cls_Location.City> list = new List<Cls_Location.City>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Cls_Location.City obj = new Cls_Location.City();
                    obj.FillListValues(obj, dt, i);
                    list.Add(obj);
                }
                return list;
            }

            public Cls_Location.City GetCityByID(int cityID)
            {
                DataTable dt = new DataTable();
                Cls_Location.City objCity = new Cls_Location.City();
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                new SqlParameter("@CityID", cityID),
                new SqlParameter("@ModeType", "GET"),
                };
                dt = objCommMethod.SQL_FillData(sqlParams, "SP_City");
                if (dt.Rows.Count > 0)
                {
                    objCity = FillListValues(objCity, dt, 0);
                }
                return objCity;
            }

            #endregion

            #region Private Methods

            private Cls_Location.City FillListValues(Cls_Location.City obj, DataTable dt, int row)
            {
                obj.CityId = Convert.ToInt32(dt.Rows[row]["CityId"]);
                obj.CountryID = Convert.ToInt32(dt.Rows[row]["CountryID"]);
                obj.CityName = Convert.ToString(dt.Rows[row]["CityName"]);

                return obj;
            }

            #endregion
        }
    }
}