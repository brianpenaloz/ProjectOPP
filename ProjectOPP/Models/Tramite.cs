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

            Paragraph parrafo = new Paragraph("Hola Mundo");
            document.Add(parrafo);
            document.Close();





            var logo = new Image(ImageDataFactory.Create("C:/Users/brian/source/repos/ArchivosOPPP/imagen.jpg")).SetWidth(50);
            Paragraph plogo = new Paragraph("").Add(logo);

            Paragraph titulo = new Paragraph("Carta de Presentacion");
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);

            var dfecha = DateTime.Now.ToString("dd-MM-yyyy");
            var dhora = DateTime.Now.ToString("hh:mm:ss");
            Paragraph fecha = new Paragraph("Fecha: " + dfecha + "\nHora" + dhora);
            fecha.SetFontSize(12);

            PdfDocument pdfDocument1 = new PdfDocument(new PdfReader("C:/Users/brian/source/repos/ArchivosOPPP/Reporte.pdf"), new PdfWriter("C:/Users/brian/source/repos/ArchivosOPPP/ReporteProducto.pdf"));
            Document document1 = new Document(pdfDocument1);

            int numeros = pdfDocument1.GetNumberOfPages();

            for (int i = 1; i <= numeros; i++)
            {
                PdfPage pagina = pdfDocument1.GetPage(i);
                float y = (pdfDocument1.GetPage(i).GetPageSize().GetTop() - 15);

                float h = pdfDocument1.GetPage(i).GetPageSize().GetHeight();
                float w = pdfDocument1.GetPage(i).GetPageSize().GetWidth();
                float t = pdfDocument1.GetPage(i).GetPageSize().GetTop();
                float r = pdfDocument1.GetPage(i).GetPageSize().GetRight();
                float b = pdfDocument1.GetPage(i).GetPageSize().GetBottom();
                float l = pdfDocument1.GetPage(i).GetPageSize().GetLeft();

                int a = 0;

                document1.ShowTextAligned(plogo, 40, y, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                document1.ShowTextAligned(titulo, 150, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                document1.ShowTextAligned(fecha, 520, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                document1.ShowTextAligned(new Paragraph(string.Format("Página {0} de {1}", i, numeros)), pdfDocument1.GetPage(i).GetPageSize().GetWidth() / 2, pdfDocument1.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            }

            document1.Close();
        }

        public void CreatePDFOneDocument()
        {
            /*
             * GetHeight = 842
             * GetWidth = 595
             * GetTop = 842
             * GetRight = 595
             * GetBottom = 0
             * GetLeft = 0
            */


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Recursos
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Estela de Raimondi
            //https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuNJInvF2ej6zssULuLVXk5ORUewbqMuMFD9uDsl6Da3SdzCRIza9xxMPH4xedtP6A3ak&usqp=CAU
            Image imgEstelaDeRaimondi = new Image(ImageDataFactory.Create("C:/Users/brian/source/repos/ArchivosOPPP/esteladeraimondi.png")).SetWidth(20);

            // Logo de la FIIS
            //data:image/jpeg;base64,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
            Image imgLogoFIIS = new Image(ImageDataFactory.Create("C:/Users/brian/source/repos/ArchivosOPPP/unfvfiislogo.png")).SetWidth(50);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Documento
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            string danho = DateTime.Now.ToString("yyyy");
            string dmes = DateTime.Now.ToString("MM");
            string ddia = DateTime.Now.ToString("dd");
            string dhora = DateTime.Now.ToString("hh");
            string dminuto = DateTime.Now.ToString("mm");
            string dsegundo = DateTime.Now.ToString("ss");
            string fechacompleta = danho + dmes + ddia + dhora + dminuto + dsegundo;

            PdfWriter pdfWriter = new PdfWriter("C:/Users/brian/source/repos/ArchivosOPPP/CartaDePresentacion-" + fechacompleta + ".pdf");
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            Document document = new Document(pdfDocument, PageSize.A4);

            document.SetMargins(60, 80, 55, 80);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Encabezado
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Paragraph pimgEstelaDeRaimondi = new Paragraph("").Add(imgEstelaDeRaimondi);

            Paragraph pimgLogoFIIS = new Paragraph("").Add(imgLogoFIIS);         

            Paragraph universidad = new Paragraph("Univerisdad Nacional");
            universidad.SetTextAlignment(TextAlignment.CENTER);
            universidad.SetFontSize(12);

            Paragraph federico = new Paragraph("FEDERICO VILLARREAL");
            federico.SetTextAlignment(TextAlignment.CENTER);
            federico.SetFontSize(12);

            Paragraph FIIS = new Paragraph("FACULTAD DE INGENIERIA INDUSTRIAL Y DE SISTEMAS");
            FIIS.SetTextAlignment(TextAlignment.CENTER);
            FIIS.SetFontSize(12);

            Paragraph OPPP = new Paragraph("OFICINA DE PRACTICAS PRE PROFESIONALES");
            OPPP.SetTextAlignment(TextAlignment.CENTER);
            OPPP.SetFontSize(12);

            Paragraph anho = new Paragraph("\"Año de la Universalizacion de la Salud\"");
            anho.SetTextAlignment(TextAlignment.CENTER);
            anho.SetFontSize(12);

            Paragraph lugarFecha = new Paragraph("Lima, 15 de diciembre del 2020");
            lugarFecha.SetTextAlignment(TextAlignment.CENTER);
            lugarFecha.SetFontSize(12);

            float y = 827; // (pdfDocument.GetPage(1).GetPageSize().GetTop() - 15);

            document.ShowTextAligned(pimgEstelaDeRaimondi, 90, y, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(pimgLogoFIIS, 480, y, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

            document.ShowTextAligned(universidad, 180, y, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(federico, 180, y - 12, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(FIIS, 280, y - 30, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(OPPP, 280, y - 45, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(anho, 280, y - 70, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(lugarFecha, 400, y - 90, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Membrete
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Paragraph primeraParteCarta = new Paragraph("CARTA N° 148-2020-OPPP-FIIS-UNFV");
            primeraParteCarta.SetTextAlignment(TextAlignment.CENTER);
            primeraParteCarta.SetFontSize(12);

            Paragraph senhores = new Paragraph("Señores:");
            senhores.SetTextAlignment(TextAlignment.CENTER);
            senhores.SetFontSize(12);

            Paragraph empresa = new Paragraph("MFDR CONSULTING & GENERAL SERVICES SAC");
            empresa.SetTextAlignment(TextAlignment.CENTER);
            empresa.SetFontSize(12);

            Paragraph ruc = new Paragraph("RUC: 20554079831");
            ruc.SetTextAlignment(TextAlignment.CENTER);
            ruc.SetFontSize(12);

            Paragraph direccionEmpresa = new Paragraph("Av, Colonial 3046 - n 1001 Lima");
            direccionEmpresa.SetTextAlignment(TextAlignment.CENTER);
            direccionEmpresa.SetFontSize(12);

            Paragraph presente = new Paragraph("Presente. -");
            presente.SetTextAlignment(TextAlignment.CENTER);
            presente.SetFontSize(12);

            document.ShowTextAligned(primeraParteCarta, 180, y - 105, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(senhores, 180, y - 120, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(empresa, 280, y - 130, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(ruc, 280, y - 140, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(direccionEmpresa, 280, y - 150, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(presente, 400, y - 160, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Contenido
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Paragraph nombre = new Paragraph("Atencion: Sr. Guiovanny Edward Delgado Garayar");
            //document.Add(nombre);

            //Paragraph cargo = new Paragraph("Gerente General");
            //document.Add(cargo);

            //Paragraph primeraParte = new Paragraph("Es grato dirigirnos a su Despacho, para expresarle nuestro saludo cordial, en nombre de la Facultad de Ingeniería Industrial y de Sistemas, de la Universidad Nacional Federico Villarreal, y a la vez, presentarles a:");
            //document.Add(primeraParte);

            //Paragraph segundaParte = new Paragraph("PEÑALOZA ORTEGA, BRIAN");
            //document.Add(segundaParte);

            //Paragraph terceraParte = new Paragraph("Estudiante del 9no. Ciclo de Estudios, con Código de Matricula N.º 2014002507 de la Carrera Profesional de Ingeniería de Sistemas, y de conformidad con lo establecido en la Ley Nº 28518 “Ley de Modalidades Formativas Laborales”, solicitarle le permita realizar sus Prácticas Pre Profesionales en su prestigiosa empresa; para lo cual utilizará todos los conocimientos adquiridos en esta Facultad.");
            //document.Add(terceraParte);

            //Paragraph cuartaParte = new Paragraph("Vuestra aceptación permitirá que el (la) mencionado (a) estudiante, complete su desarrollo profesional aplicando sus conocimientos a la realidad empresarial, y cumpla con su Plan de Estudios de acuerdo a normas académicas vigentes, en esta Casa Superior de Estudios.");
            //document.Add(cuartaParte);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Pie de pagina
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Paragraph direccionUNFV = new Paragraph("Av Oscar R. Benavides (Ex Colonial N° 450 - 334. Piso) - Lima 01 / 748-08888 anexo 8761");
            Paragraph correo = new Paragraph("Correo: oppp.fiis@unfv.edu.pe");

            document.ShowTextAligned(direccionUNFV, pdfDocument.GetPage(1).GetPageSize().GetWidth() / 2, pdfDocument.GetPage(1).GetPageSize().GetBottom() + 40, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(correo, pdfDocument.GetPage(1).GetPageSize().GetWidth() / 2, pdfDocument.GetPage(1).GetPageSize().GetBottom() + 25, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);



            document.Close();
        }
    }
}