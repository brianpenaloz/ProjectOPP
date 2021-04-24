using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ProjectOPP.Models
{
    public class TipoDocumento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        readonly Conexion con = new Conexion();

        public List<TipoDocumento> Read()
        {
            List<TipoDocumento> lstBean = new List<TipoDocumento>();
            string query = "SELECT ID, Nombre FROM TB_TipoDocumento";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoDocumento objBean = new TipoDocumento
                        {
                            ID = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        };
                        lstBean.Add(objBean);
                    }

                    reader.Close();
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: " + e.Message);
                }
            }

            return lstBean;
        }
    }
}