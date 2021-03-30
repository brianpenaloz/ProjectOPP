using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ProjectOPP.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        [DisplayName("Nombre")]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FecNacimiento { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public int ID_Rol { get; set; }

        readonly Conexion con = new Conexion();

        public void Logup(Usuario usuario)
        {
            string query = "INSERT INTO TB_Usuario (Nombres, Apellidos, FecNacimiento, Correo, Clave, ID_Rol) VALUES (@nombres, @apellidos, @fecnacimiento, @correo, @clave, @id_rol)";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@nombres", usuario.Nombres);
                command.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
                command.Parameters.AddWithValue("@fecnacimiento", usuario.FecNacimiento);
                command.Parameters.AddWithValue("@correo", usuario.Correo);
                command.Parameters.AddWithValue("@clave", usuario.Clave);
                command.Parameters.AddWithValue("@id_rol", usuario.ID_Rol);

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

        public Usuario Login(string correo, string clave, int rol)
        {
            string query = "SELECT ID, Nombres, Apellidos, FecNacimiento, Correo, Clave, ID_Rol FROM TB_Usuario WHERE Correo = @correo and Clave = @clave and ID_Rol = @id_rol";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@correo", correo.Trim());
                command.Parameters.AddWithValue("@clave", clave.Trim());
                command.Parameters.AddWithValue("@id_rol", rol);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    Usuario usuario = new Usuario
                    {
                        ID = reader.GetInt32(0),
                        Nombres = reader.GetString(1),
                        Apellidos = reader.GetString(2),
                        FecNacimiento = reader.GetDateTime(3),
                        Correo = reader.GetString(4),
                        Clave = reader.GetString(5),
                        ID_Rol = reader.GetInt32(6)
                    };

                    reader.Close();
                    conn.Close();

                    return usuario;
                }
                catch(Exception e)
                {
                    throw new Exception("Error: " + e.Message);
                }
            }
        }
    }
}