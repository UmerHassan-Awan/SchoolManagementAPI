using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_CommonMethods
    {
        string Connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        public string InsertSQLMethod(SqlParameter[] param, string SpName)
        {
            try
            {
                SqlConnection objSqlConnection = new SqlConnection(Connection);
                SqlCommand objSqlCommand = new SqlCommand();
                SqlParameter objSqlParameter = new SqlParameter();
                objSqlCommand = new SqlCommand(SpName, objSqlConnection);
                objSqlCommand.CommandTimeout = 900;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlConnection.Open();
                foreach (object parametersName in param)
                {
                    objSqlCommand.Parameters.Add(parametersName);
                }
                objSqlCommand.Parameters.Add("@Result",SqlDbType.VarChar,600);
                objSqlCommand.Parameters["@Result"].Direction = ParameterDirection.Output;
                objSqlCommand.ExecuteNonQuery();
                return Convert.ToString(objSqlCommand.Parameters["@Result"].Value);
            }
            catch (Exception ex)
            {
                return Convert.ToString(ex.Message);
            }
        }

        public string UpdateSQLMethod(SqlParameter[] param, string SpName)
        {
            try
            {
                SqlConnection objSqlConnection = new SqlConnection(Connection);
                SqlCommand objSqlCommand = new SqlCommand();
                SqlParameter objSqlParameter = new SqlParameter();
                objSqlCommand = new SqlCommand(SpName, objSqlConnection);
                objSqlCommand.CommandTimeout = 900;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlConnection.Open();
                foreach (object parametersName in param)
                {
                    objSqlCommand.Parameters.Add(parametersName);
                }
                objSqlCommand.Parameters.Add("@Result", SqlDbType.VarChar, 600);
                objSqlCommand.Parameters["@Result"].Direction = ParameterDirection.Output;
                objSqlCommand.ExecuteNonQuery();
                return Convert.ToString(objSqlCommand.Parameters["@Result"].Value);
            }
            catch (Exception ex)
            {
                return Convert.ToString(ex.Message);
            }
        }

        public DataTable SQL_FillData(SqlParameter[] param, string SPName)
        {
            SqlConnection objSqlConnection = new SqlConnection(Connection);
            SqlCommand objSqlCommand = new SqlCommand();
            SqlParameter objSqlParameter = new SqlParameter();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter();
            DataTable objDataTable = new DataTable();

            try
            {
                objSqlCommand = new SqlCommand(SPName, objSqlConnection);
                objSqlCommand.CommandTimeout = 900;
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (object x in param)
                {
                    objSqlCommand.Parameters.Add(x);
                }
                objDataAdapter.SelectCommand = objSqlCommand;
                objDataAdapter.Fill(objDataTable);
                objSqlConnection.Close();
                objSqlCommand.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return objDataTable;
        }
    }
}