using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjectOPP.Models
{
    public class CicloAlumno
    {
        public int ID { get; set; }
        [DisplayName("Ciclo que actualmente esta cursando")]
        public string Nombre { get; set; }

        readonly Conexion con = new Conexion();

        public List<CicloAlumno> Read()
        {
            List<CicloAlumno> lstBean = new List<CicloAlumno>();
            string query = "SELECT ID, Nombre FROM TB_CicloAlumno";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CicloAlumno objBean = new CicloAlumno
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