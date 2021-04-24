using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ProjectOPP.Models
{
    public class Escuela
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public Facultad facultad;

        readonly Conexion con = new Conexion();

        public List<Escuela> Read(int fk)
        {
            List<Escuela> lstBean = new List<Escuela>();
            string query = "SELECT ID, Nombre FROM TB_Escuela WHERE ID_Facultad = @fk";

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
                        Escuela objBean = new Escuela
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