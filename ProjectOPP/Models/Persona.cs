using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ProjectOPP.Models
{
    public class Persona
    {
        public int ID { get; set; }
        [DisplayName("Nombre")]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public DateTime FecNacimiento { get; set; }
        private int Estado { get; set; }


        //public string connectionString = "data source=DESKTOP-NVGBAVV;initial catalog=DB_PracticasPre;user id=sa; password=sql;";
        readonly Conexion con = new Conexion();

        public void Create(Persona persona)
        {
            string query = "insert into tb_persona (ID, Nombres, Apellidos, Correo, FecNacimiento) values (@id, @nombres, @apellidos, @correo, @fecha)";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", persona.ID);
                command.Parameters.AddWithValue("@nombres", persona.Nombres);
                command.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@correo", persona.Correo);
                command.Parameters.AddWithValue("@fecha", persona.FecNacimiento);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: " + e.Message);
                }
            }
        }

        public List<Persona> Read()
        {
            List<Persona> pers = new List<Persona>();
            string query = "select id, nombres, apellidos, correo, fecnacimiento from tb_persona";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Persona objPer = new Persona
                        {
                            ID = reader.GetInt32(0),
                            Nombres = reader.GetString(1),
                            Apellidos = reader.GetString(2),
                            Correo = reader.GetString(3),
                            FecNacimiento = reader.GetDateTime(4)
                        };
                        pers.Add(objPer);
                    }

                    reader.Close();
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: " + e.Message);
                }
            }

            return pers;
        }

        public Persona Read(int Id)
        {
            string query = "select id, nombres, apellidos, correo, fecnacimiento from tb_persona where id = @id";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    Persona objPer = new Persona
                    {
                        ID = reader.GetInt32(0),
                        Nombres = reader.GetString(1),
                        Apellidos = reader.GetString(2),
                        Correo = reader.GetString(3),
                        FecNacimiento = reader.GetDateTime(4)
                    };

                    reader.Close();
                    conn.Close();

                    return objPer;
                }
                catch (Exception e)
                {
                    throw new Exception("Error: " + e.Message);
                }
            }            
        }

        public void Update(Persona persona)
        {
            string query = "update tb_persona set Nombres = @nombres, Apellidos = @apellidos, Correo = @correo, FecNacimiento = @fecha where ID = @id";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", persona.ID);
                command.Parameters.AddWithValue("@nombres", persona.Nombres);
                command.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@correo", persona.Correo);
                command.Parameters.AddWithValue("@fecha", persona.FecNacimiento);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: " + e.Message);
                }
            }
        }

        public void Delete(int Id)
        {
            string query = "delete from tb_persona where id = @id";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: " + e.Message);
                }
            }
        }
    }
}