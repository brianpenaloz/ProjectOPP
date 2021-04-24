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
        [DisplayName("Numero de Documento")]
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        [DisplayName("Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [DisplayName("Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [DisplayName("Fecha de Nacimiento")]
        public DateTime FecNacimiento { get; set; }
        public string Direccion { get; set; }
        [DisplayName("Numero de Direccion")]
        public string NumeroDireccion { get; set; }
        [DisplayName("Telefono Fijo")]
        public string TelefonoFijo { get; set; }
        public string Celular { get; set; }
        [DisplayName("Codigo de alumno")]
        public string Codigo { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public int ID_TipoDocumento { get; set; }
        public int ID_Distrito { get; set; }
        public int ID_Rol { get; set; }
        public int ID_Escuela { get; set; }


        public TipoDocumento tipoDocumento;
        public Distrito distrito;
        public Rol rol;
        public Escuela escuela;










        readonly Conexion con = new Conexion();

        public void Logup(Usuario usuario)
        {
            string query = "INSERT INTO TB_Usuario (NumeroDocumento, Nombres, ApellidoPaterno, ApellidoMaterno, FecNacimiento, Direccion, NumeroDireccion, TelefonoFijo, Celular, Codigo, Correo, Clave, ID_TipoDocumento, ID_Distrito, ID_Rol, ID_Escuela) " +
                "VALUES (@documento, @nombres, @paterno, @materno, @fecnacimiento, @direccion, @numerodireccion, @fijo, @celular, @codigo, @correo, @clave, @tipodocumento, @distrito, @rol, @escuela)";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@documento", usuario.NumeroDocumento);
                command.Parameters.AddWithValue("@nombres", usuario.Nombres);
                command.Parameters.AddWithValue("@paterno", usuario.ApellidoPaterno);
                command.Parameters.AddWithValue("@materno", usuario.ApellidoMaterno);
                command.Parameters.AddWithValue("@fecnacimiento", usuario.FecNacimiento);
                command.Parameters.AddWithValue("@direccion", usuario.Direccion);
                command.Parameters.AddWithValue("@numerodireccion", usuario.NumeroDireccion);
                command.Parameters.AddWithValue("@fijo", usuario.TelefonoFijo);
                command.Parameters.AddWithValue("@celular", usuario.Celular);
                command.Parameters.AddWithValue("@codigo", usuario.Codigo);
                command.Parameters.AddWithValue("@correo", usuario.Correo);
                command.Parameters.AddWithValue("@clave", usuario.Clave);
                command.Parameters.AddWithValue("@distrito", usuario.ID_Distrito);
                command.Parameters.AddWithValue("@tipodocumento", usuario.ID_TipoDocumento);
                command.Parameters.AddWithValue("@rol", usuario.ID_Rol);
                command.Parameters.AddWithValue("@escuela", usuario.ID_Escuela);                

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
            string query = "SELECT ID, NumeroDocumento, Nombres, ApellidoPaterno, ApellidoMaterno, FecNacimiento, Direccion, NumeroDireccion, TelefonoFijo, Celular, Codigo, Correo, Clave, ID_TipoDocumento, ID_Distrito, ID_Rol, ID_Escuela " +
                "FROM TB_Usuario WHERE Correo = @correo and Clave = @clave and ID_Rol = @rol";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@correo", correo.Trim());
                command.Parameters.AddWithValue("@clave", clave.Trim());
                command.Parameters.AddWithValue("@rol", rol);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    Usuario usuario = new Usuario
                    {
                        ID = reader.GetInt32(0),
                        NumeroDocumento = reader.GetString(1),
                        Nombres = reader.GetString(2),
                        ApellidoPaterno = reader.GetString(3),
                        ApellidoMaterno = reader.GetString(4),
                        FecNacimiento = reader.GetDateTime(5),
                        Direccion = reader.GetString(6),
                        NumeroDireccion = reader.GetString(7),
                        TelefonoFijo = reader.GetString(8),
                        Celular = reader.GetString(9),
                        Codigo = reader.GetString(10),
                        Correo = reader.GetString(11),
                        Clave = reader.GetString(12),
                        ID_TipoDocumento = reader.GetInt32(13),
                        ID_Distrito = reader.GetInt32(14),
                        ID_Rol = reader.GetInt32(15),
                        ID_Escuela = reader.GetInt32(16)                        
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