using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
namespace ani_inhse.Dll
{
    public static class mysql
    {
        public static int excuteSQLToInt32(string connstring, string sql)
        {
            return excuteSQLToInt32(connstring, sql, null, null);
        }
        public static int excuteSQLToInt32(string connstring, string sql, object[] paraObj, string[] paraStr)
        {
            int result = 0;
            MySqlConnection mySqlConnection = new MySqlConnection(connstring);
            if (paraObj != null && paraStr != null && paraObj.Length != paraStr.Length)
                return -1;

            using (mySqlConnection)
            {
                MySqlCommand mycomm1 = new MySqlCommand(sql, mySqlConnection);
                if (paraObj != null && paraStr != null)
                {
                    for (int i = 0; i < paraStr.Length; i++)
                        mycomm1.Parameters.AddWithValue(paraStr[i], paraObj[i]);
                }

                try
                {
                    mySqlConnection.Open();
                    result = Convert.ToInt32(mycomm1.ExecuteScalar());
                }
                catch (Exception e)
                {
                    int y = 1;
                }
            }
            return result;
        }


        public static void excuteSQL(string connstring, string sql)
        {
            excuteSQL(connstring, sql, null, null);
        }
        public static void excuteSQL(string connstring, string sql, object[] paraObj, string[] paraStr)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connstring);
            if (paraObj != null && paraStr != null && paraObj.Length != paraStr.Length)
                return;

            using (mySqlConnection)
            {
                MySqlCommand mycomm1 = new MySqlCommand(sql, mySqlConnection);
                if (paraObj != null && paraStr != null)
                {
                    for (int i = 0; i < paraStr.Length; i++)
                        mycomm1.Parameters.AddWithValue(paraStr[i], paraObj[i]);
                }

                try
                {
                    mySqlConnection.Open();
                    mycomm1.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    int y = 1;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        public static DataTable excuteSQLToDataTable(string connstring, string sql)
        {
            return excuteSQLToDataTable(connstring, sql, null, null);
        }

        public static DataSet GetDataset(string sql, string connstring)
        {
            DataSet ds = new DataSet();
            MySqlConnection mySqlConnection = new MySqlConnection(connstring);
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            MySqlDataAdapter mysqlda = new MySqlDataAdapter(mySqlCommand);
            mysqlda.Fill(ds);
            mysqlda.Dispose();
            mySqlCommand.Dispose();
            mySqlConnection.Dispose();
            mySqlConnection.Close();
            return ds;
        }
        public static DataTable excuteSQLToDataTable(string connstring, string sql, object[] paraObj, string[] paraStr)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connstring);
            DataTable tmpDt = new DataTable();
            if (paraObj != null && paraStr != null && paraObj.Length != paraStr.Length)
                return null;
            try
            {
                using (mySqlConnection)
                {
                    MySqlCommand mycomm1 = new MySqlCommand(sql, mySqlConnection);
                    mycomm1.CommandTimeout = 0;
                    if (paraObj != null && paraStr != null)
                    {
                        for (int i = 0; i < paraStr.Length; i++)
                            mycomm1.Parameters.AddWithValue(paraStr[i], paraObj[i]);
                    }
                    using (mycomm1)
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(mycomm1))
                        {
                            using (tmpDt)
                            {
                                sda.Fill(tmpDt);
                            }
                        }
                    };
                }
            }
            catch (MySqlException e)
            {
                throw e;
                //MessageBox.Show("Database Cannot be connected", "System Error", MessageBoxButtons.OK);
            }
            return tmpDt;
        }

        public static string Get_mysql_database_MaxID(string conn_string, string database_name, string coloumn_name, string condition = "")
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select max(" + coloumn_name + ")+1 from " + database_name);
            if (condition.Length > 0)
            {
                sql.Append(" where " + condition);
            }
            return Get_mysql_database_MaxID(conn_string, sql.ToString());
        }
        public static string Get_mysql_database_MaxID(string conn_string, string sqlStr)
        {
            DataSet ds = (!string.IsNullOrWhiteSpace(sqlStr)) ? mysql.GetDataset(sqlStr, conn_string) : null;
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (!ds.Tables[0].Rows[0][0].ToString().Equals(""))
                {
                    int id = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                    if (id <= 100000)
                    {
                        return "100001";
                    }
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "100001";
                }
            }
            else
            {
                return "100001";
            }
        }
    }
}
