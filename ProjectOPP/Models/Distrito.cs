using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ProjectOPP.Models
{
    public class Distrito
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public Provincia provincia;

        readonly Conexion con = new Conexion();

        public List<Distrito> Read(int fk)
        {
            List<Distrito> lstBean = new List<Distrito>();
            string query = "SELECT ID, Nombre FROM TB_Distrito WHERE ID_Provincia = @fk";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", fk);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Distrito objBean = new Distrito
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