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
        [DisplayName("Usuario")]
        public string User { get; set; }
        public string Clave { get; set; }
        public int Persona { get; set; }
        public int Rol { get; set; }

        readonly Conexion con = new Conexion();

        public void Create(Usuario usuario)
        {
            string query = "insert into tb_usuario (usuario, clave, id_persona, id_rol) values (@usuario, @clave, @persona, @rol)";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@usuario", usuario.User);
                command.Parameters.AddWithValue("@clave", usuario.Clave);
                command.Parameters.AddWithValue("@persona", usuario.Persona);
                command.Parameters.AddWithValue("@rol", usuario.Rol);

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

        public Usuario Login(string Usuario, string Clavex, int Rolex)
        {
            string query = "select id, usuario, clave, id_persona, id_rol from tb_usuario where usuario = @usuario and clave = @clave and id_rol = @rol";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@usuario", Usuario.Trim());
                command.Parameters.AddWithValue("@clave", Clavex.Trim());
                command.Parameters.AddWithValue("@rol", Rolex);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    Usuario usuario = new Usuario
                    {
                        ID = reader.GetInt32(0),
                        User = reader.GetString(1),
                        Clave = reader.GetString(2),
                        Persona = reader.GetInt32(3),
                        Rol = reader.GetInt32(4)
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