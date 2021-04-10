using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjectOPP.Models
{
    public class Tramite
    {
        [Required]
        [DisplayName("Mi archivo")]
        public HttpPostedFileBase Archivo1 { get; set; }
        [Required]
        [DisplayName("Mi archivo2")]
        public HttpPostedFileBase Archivo2 { get; set; }
        [Required]
        [DisplayName("Mi cadena")]
        public string Cadena { get; set; }

        public int ID { get; set; }
        [DisplayName("Tramite a Realizar")]
        public string Tramit { get; set; }
        [DisplayName("Dependencia de Referencia")]
        public string DependenciaReferencia { get; set; }
        [DisplayName("Numero de Tramite")]
        public string NumeroTramite { get; set; }
        [DisplayName("Fecha de Solicitud")]
        public DateTime FecCreacion { get; set; }
        [DisplayName("Fundamento de Solicitud")]
        public string FundamentoSolicitud { get; set; }
        public int Usuario { get; set; }

        readonly Conexion con = new Conexion();

        public void Create(Tramite tramite)
        {
            string query = "insert into tb_tramite (Tramite, DependenciaReferencia, NumeroTramite, FecCreacion, FundamentoSolicitud, ID_Usuario) values (@tramite, @dependencia, @numero, @fecha, @fundamento, @usuario)";
            //string query = "insert into tb_tramite (Numero, ID_Usuario) values (@numero, @usuario)";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@tramite", tramite.Tramit);
                command.Parameters.AddWithValue("@dependencia", tramite.DependenciaReferencia);
                command.Parameters.AddWithValue("@numero", tramite.NumeroTramite);
                command.Parameters.AddWithValue("@fecha", tramite.FecCreacion);
                command.Parameters.AddWithValue("@fundamento", tramite.FundamentoSolicitud);
                command.Parameters.AddWithValue("@usuario", tramite.Usuario);

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

        public List<Tramite> Read()
        {
            List<Tramite> lstBean = new List<Tramite>();
            string query = "SELECT ID, Tramite, DependenciaReferencia, NumeroTramite, FecCreacion, FundamentoSolicitud, ID_Usuario FROM TB_Tramite";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Tramite objBean = new Tramite
                        {
                            ID = reader.GetInt32(0),
                            Tramit = reader.GetString(1),
                            DependenciaReferencia = reader.GetString(2),
                            NumeroTramite = reader.GetString(3),
                            FecCreacion = reader.GetDateTime(4),
                            FundamentoSolicitud = reader.GetString(5),
                            Usuario = reader.GetInt32(6),
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