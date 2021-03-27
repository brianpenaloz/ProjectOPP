using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjectOPP.Models
{
    public class Conexion
    {
        public string connectionString = "data source=DESKTOP-NVGBAVV;initial catalog=DB_PracticasPre;user id=sa; password=sql;";

        public bool MyConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (Exception)
            {

                //throw;
                return false;
            }
            finally
            {
                //conn.Close();
            }

            return true;
        }
    }
}