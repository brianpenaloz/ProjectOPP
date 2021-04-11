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
        public string Codigo { get; set; }
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
            string query = "INSERT INTO TB_Usuario (Codigo, Nombres, Apellidos, FecNacimiento, Correo, Clave, ID_Rol) VALUES (@codigo, @nombres, @apellidos, @fecnacimiento, @correo, @clave, @id_rol)";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@codigo", usuario.Codigo);
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
            string query = "SELECT ID, Codigo, Nombres, Apellidos, FecNacimiento, Correo, Clave, ID_Rol FROM TB_Usuario WHERE Correo = @correo and Clave = @clave and ID_Rol = @id_rol";

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
                        Codigo = reader.GetString(1),
                        Nombres = reader.GetString(2),
                        Apellidos = reader.GetString(3),
                        FecNacimiento = reader.GetDateTime(4),
                        Correo = reader.GetString(5),
                        Clave = reader.GetString(6),
                        ID_Rol = reader.GetInt32(7)
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