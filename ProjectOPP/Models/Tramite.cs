using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout.Properties;
using iText.IO.Image;

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

        public Tramite Read(int Id)
        {
            string query = "SELECT ID, Tramite, DependenciaReferencia, NumeroTramite, FecCreacion, FundamentoSolicitud, ID_Usuario FROM TB_Tramite WHERE ID = @id";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

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

                    reader.Close();
                    conn.Close();

                    return objBean;
                }
                catch (Exception e)
                {
                    throw new Exception("Error: " + e.Message);
                }
            }
        }

        public void CreatePDFTwoDocumentsOriginal()
        {
            //C:\Users\brian\source\repos
            PdfWriter pdfWriter = new PdfWriter("C:/Users/brian/source/repos/ArchivosOPPP/Reporte.pdf");
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            // 1 pulgada = 72 pt (Puntos Tipograficos) (8 1/2 x 11 pulgadas) (612 x 792)
            PageSize tamanhoH = new PageSize(792, 612);
            Document document = new Document(pdfDocument, PageSize.A4);

            document.SetMargins(60, 20, 55, 20);

            PdfFont pdfFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont pdfFontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            string[] columnas = { "Columna 1", "Columna 2", "Columna 3", "Columna 4", "Columna 5" };

            // Ancho de las columnas
            float[] tamanhos = { 2, 4, 2, 2, 4 };
            Table table = new Table(UnitValue.CreatePercentArray(tamanhos));
            table.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnas)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(pdfFont)));
            }

            table.AddCell(new Cell().Add(new Paragraph("codigo")).SetFont(pdfFontContenido));
            table.AddCell(new Cell().Add(new Paragraph("nombre")).SetFont(pdfFontContenido));
            table.AddCell(new Cell().Add(new Paragraph("precio")).SetFont(pdfFontContenido));
            table.AddCell(new Cell().Add(new Paragraph("codigo")).SetFont(pdfFontContenido));
            table.AddCell(new Cell().Add(new Paragraph("codigo")).SetFont(pdfFontContenido));

            document.Add(table);

            var parrafo = new Paragraph("Hola Mundo");
            document.Add(parrafo);
            document.Close();





            var logo = new Image(ImageDataFactory.Create("C:/Users/brian/source/repos/ArchivosOPPP/imagen.jpg")).SetWidth(50);
            var plogo = new Paragraph("").Add(logo);

            var titulo = new Paragraph("Carta de Presentacion");
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);

            var dfecha = DateTime.Now.ToString("dd-MM-yyyy");
            var dhora = DateTime.Now.ToString("hh:mm:ss");
            var fecha = new Paragraph("Fecha: " + dfecha + "\nHora" + dhora);
            fecha.SetFontSize(12);

            PdfDocument pdfDocument1 = new PdfDocument(new PdfReader("C:/Users/brian/source/repos/ArchivosOPPP/Reporte.pdf"), new PdfWriter("C:/Users/brian/source/repos/ArchivosOPPP/ReporteProducto.pdf"));
            Document document1 = new Document(pdfDocument1);

            int numeros = pdfDocument1.GetNumberOfPages();

            for (int i = 1; i <= numeros; i++)
            {
                PdfPage pagina = pdfDocument1.GetPage(i);
                float y = (pdfDocument1.GetPage(i).GetPageSize().GetTop() - 15);

                document1.ShowTextAligned(plogo, 40, y, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                document1.ShowTextAligned(titulo, 150, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                document1.ShowTextAligned(fecha, 520, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                document1.ShowTextAligned(new Paragraph(string.Format("Página {0} de {1}", i, numeros)), pdfDocument1.GetPage(i).GetPageSize().GetWidth() / 2, pdfDocument1.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            }

            document1.Close();
        }

        public void CreatePDFOneDocument()
        {
            var danho = DateTime.Now.ToString("yyyy");
            var dmes = DateTime.Now.ToString("MM");
            var ddia = DateTime.Now.ToString("dd");
            var dhora = DateTime.Now.ToString("hh");
            var dminuto = DateTime.Now.ToString("mm");
            var dsegundo = DateTime.Now.ToString("ss");
            var fechacompleta = danho + dmes + ddia + dhora + dminuto + dsegundo;


            PdfWriter pdfWriter = new PdfWriter("C:/Users/brian/source/repos/ArchivosOPPP/CartaDePresentacion-" + fechacompleta + ".pdf");
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            Document document = new Document(pdfDocument, PageSize.A4);

            document.SetMargins(60, 20, 55, 20);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Encabezado
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            var logo = new Image(ImageDataFactory.Create("C:/Users/brian/source/repos/ArchivosOPPP/imagen.jpg")).SetWidth(50);
            var plogo = new Paragraph("").Add(logo);

            var titulo = new Paragraph("Carta de Presentacion");
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);

            var dfecha = DateTime.Now.ToString("dd-MM-yyyy");
            var dhorahora = DateTime.Now.ToString("hh:mm:ss");
            var fecha = new Paragraph("Fecha: " + dfecha + "\nHora: " + dhorahora);
            fecha.SetFontSize(12);



            float y = 827; // (pdfDocument.GetPage(1).GetPageSize().GetTop() - 15);

            document.ShowTextAligned(plogo, 40, y, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(titulo, 150, y - 15, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(fecha, 520, y - 15, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Contenido
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            PdfFont pdfFontTitulo = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont pdfFontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            string[] columnas = { "Columna 1", "Columna 2", "Columna 3", "Columna 4", "Columna 5" };

            // Ancho de las columnas
            float[] tamanhos = { 2, 4, 2, 2, 4 };
            Table table = new Table(UnitValue.CreatePercentArray(tamanhos));
            table.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnas)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(pdfFontTitulo)));
            }

            table.AddCell(new Cell().Add(new Paragraph("codigo")).SetFont(pdfFontContenido));
            table.AddCell(new Cell().Add(new Paragraph("nombre")).SetFont(pdfFontContenido));
            table.AddCell(new Cell().Add(new Paragraph("precio")).SetFont(pdfFontContenido));
            table.AddCell(new Cell().Add(new Paragraph("codigo")).SetFont(pdfFontContenido));
            table.AddCell(new Cell().Add(new Paragraph("codigo")).SetFont(pdfFontContenido));

            document.Add(table);

            var parrafo = new Paragraph("Hola Mundo");
            document.Add(parrafo);

            var parrafoOneDocument = new Paragraph("One Document");
            document.Add(parrafoOneDocument);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Pie de pagina
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            document.ShowTextAligned(new Paragraph(string.Format("Página {0} de {1}", 1, 1)), pdfDocument.GetPage(1).GetPageSize().GetWidth() / 2, pdfDocument.GetPage(1).GetPageSize().GetBottom() + 30, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);


            document.Close();




            //PdfDocument pdfDocument1 = new PdfDocument(new PdfReader("C:/Users/brian/source/repos/ArchivosOPPP/Reporte.pdf"), new PdfWriter("C:/Users/brian/source/repos/ArchivosOPPP/ReporteProducto.pdf"));
            //Document document1 = new Document(pdfDocument1);

            //int numeros = pdfDocument1.GetNumberOfPages();



            //for (int i = 1; i <= numeros; i++)
            //{
            //    PdfPage pagina = pdfDocument1.GetPage(i);
            //    float y = (pdfDocument1.GetPage(i).GetPageSize().GetTop() - 15);

            //    document1.ShowTextAligned(plogo, 40, y, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            //    document1.ShowTextAligned(titulo, 150, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            //    document1.ShowTextAligned(fecha, 520, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

            //    document1.ShowTextAligned(new Paragraph(string.Format("Página {0} de {1}", i, numeros)), pdfDocument1.GetPage(i).GetPageSize().GetWidth() / 2, pdfDocument1.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            //}

            //document1.Close();
        }
    }
}