using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ProjectOPP.Models
{
    public class Provincia
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public Departamento departamento;

        readonly Conexion con = new Conexion();

        public List<Provincia> Read(int fk)
        {
            List<Provincia> lstBean = new List<Provincia>();
            string query = "SELECT ID, Nombre FROM TB_Provincia WHERE ID_Departamento = @fk";

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
                        Provincia objBean = new Provincia
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