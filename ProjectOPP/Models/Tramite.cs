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
        //[Required]
        //[DisplayName("Mi archivo")]
        //public HttpPostedFileBase Archivo1 { get; set; }
        //[Required]
        //[DisplayName("Mi archivo2")]
        //public HttpPostedFileBase Archivo2 { get; set; }
        //[Required]
        //[DisplayName("Mi cadena")]
        //public string Cadena { get; set; }

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
        public string EmpresaNombre { get; set; }
        public string EmpresaRuc { get; set; }
        public string EmpresaDireccion { get; set; }
        public string EmpresaJefe { get; set; }
        public string EmpresaCargo { get; set; }
        public string AlumnoCiclo { get; set; }
        public string AdjuntoUno { get; set; }
        public string AdjuntoDos { get; set; }
        public int Usuario { get; set; }

        readonly Conexion con = new Conexion();

        public void Create(Tramite tramite)
        {
            string query = "INSERT INTO TB_Tramite (Tramite, DependenciaReferencia, NumeroTramite, FecCreacion, FundamentoSolicitud, EmpresaNombre, EmpresaRuc, EmpresaDireccion, EmpresaJefe, EmpresaCargo, AlumnoCiclo, AdjuntoUno, AdjuntoDos, ID_Usuario) " +
                "VALUES (@tramite, @dependencia, @numero, @fecha, @fundamento, @empresanombre, @empresaruc, @empresadireccion, @empresajefe, @empresacargo, @alumnociclo, @adjuntouno, @adjuntodos, @usuario)";
            //string query = "insert into tb_tramite (Numero, ID_Usuario) values (@numero, @usuario)";

            using (SqlConnection conn = new SqlConnection(con.connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@tramite", tramite.Tramit);
                command.Parameters.AddWithValue("@dependencia", tramite.DependenciaReferencia);
                command.Parameters.AddWithValue("@numero", tramite.NumeroTramite);
                command.Parameters.AddWithValue("@fecha", tramite.FecCreacion);
                command.Parameters.AddWithValue("@fundamento", tramite.FundamentoSolicitud);
                command.Parameters.AddWithValue("@empresanombre", tramite.EmpresaNombre);
                command.Parameters.AddWithValue("@empresaruc", tramite.EmpresaRuc);
                command.Parameters.AddWithValue("@empresadireccion", tramite.EmpresaDireccion);
                command.Parameters.AddWithValue("@empresajefe", tramite.EmpresaJefe);
                command.Parameters.AddWithValue("@empresacargo", tramite.EmpresaCargo);
                command.Parameters.AddWithValue("@alumnociclo", tramite.AlumnoCiclo);
                command.Parameters.AddWithValue("@adjuntouno", tramite.AdjuntoUno);
                command.Parameters.AddWithValue("@adjuntodos", tramite.AdjuntoDos);
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
            string query = "SELECT ID, Tramite, DependenciaReferencia, NumeroTramite, FecCreacion, FundamentoSolicitud, EmpresaNombre, EmpresaRuc, EmpresaDireccion, EmpresaJefe, EmpresaCargo, AlumnoCiclo, AdjuntoUno, AdjuntoDos, ID_Usuario FROM TB_Tramite";

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
                            EmpresaNombre = reader.GetString(6),
                            EmpresaRuc = reader.GetString(7),
                            EmpresaDireccion = reader.GetString(8),
                            EmpresaJefe = reader.GetString(9),
                            EmpresaCargo = reader.GetString(10),
                            AlumnoCiclo = reader.GetString(11),
                            AdjuntoUno = reader.GetString(12),
                            AdjuntoDos = reader.GetString(13),
                            Usuario = reader.GetInt32(14)
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
            string query = "SELECT ID, Tramite, DependenciaReferencia, NumeroTramite, FecCreacion, FundamentoSolicitud, EmpresaNombre, EmpresaRuc, EmpresaDireccion, EmpresaJefe, EmpresaCargo, AlumnoCiclo, AdjuntoUno, AdjuntoDos, ID_Usuario FROM TB_Tramite WHERE ID = @id";

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
                        EmpresaNombre = reader.GetString(6),
                        EmpresaRuc = reader.GetString(7),
                        EmpresaDireccion = reader.GetString(8),
                        EmpresaJefe = reader.GetString(9),
                        EmpresaCargo = reader.GetString(10),
                        AlumnoCiclo = reader.GetString(11),
                        AdjuntoUno = reader.GetString(12),
                        AdjuntoDos = reader.GetString(13),
                        Usuario = reader.GetInt32(14)
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
            ///Parametros
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int xMinimo = 80;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Recursos
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Estela de Raimondi
            Image imgEstelaDeRaimondi = new Image(ImageDataFactory.Create("C:/Users/brian/source/repos/ArchivosOPPP/esteladeraimondi.png")).SetWidth(20);

            // Logo de la FIIS
            Image imgLogoFIIS = new Image(ImageDataFactory.Create("C:/Users/brian/source/repos/ArchivosOPPP/unfvfiislogo.png")).SetWidth(40);


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
            document.ShowTextAligned(pimgLogoFIIS, 500, y, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

            document.ShowTextAligned(universidad, 180, y, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(federico, 180, y - 12, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(FIIS, 280, y - 30, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(OPPP, 280, y - 45, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(anho, 280, y - 70, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(lugarFecha, 400, y - 90, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Membrete
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Paragraph carta = new Paragraph("CARTA N° 148-2020-OPPP-FIIS-UNFV");
            carta.SetTextAlignment(TextAlignment.LEFT);
            carta.SetFontSize(12);

            Paragraph senhores = new Paragraph("Señores:");
            senhores.SetTextAlignment(TextAlignment.LEFT);
            senhores.SetFontSize(12);

            Paragraph empresa = new Paragraph("MFDR CONSULTING & GENERAL SERVICES SAC");
            empresa.SetTextAlignment(TextAlignment.LEFT);
            empresa.SetFontSize(12);

            Paragraph ruc = new Paragraph("RUC: 20554079831");
            ruc.SetTextAlignment(TextAlignment.LEFT);
            ruc.SetFontSize(12);

            Paragraph direccionEmpresa = new Paragraph("Av, Colonial 3046 - n 1001 Lima");
            direccionEmpresa.SetTextAlignment(TextAlignment.LEFT);
            direccionEmpresa.SetFontSize(12);

            Paragraph presente = new Paragraph("Presente. -");
            presente.SetTextAlignment(TextAlignment.LEFT);
            presente.SetFontSize(12);

            document.ShowTextAligned(carta, xMinimo, y - 105, 1, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(senhores, xMinimo, y - 125, 1, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(empresa, xMinimo, y - 140, 1, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(ruc, xMinimo, y - 155, 1, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(direccionEmpresa, xMinimo, y - 170, 1, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(presente, xMinimo, y - 185, 1, TextAlignment.LEFT, VerticalAlignment.TOP, 0);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Contenido
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Paragraph representante = new Paragraph("Atencion: Sr. Guiovanny Edward Delgado Garayar");
            representante.SetTextAlignment(TextAlignment.CENTER);
            representante.SetFontSize(12);

            Paragraph cargo = new Paragraph("Gerente General");
            cargo.SetTextAlignment(TextAlignment.CENTER);
            cargo.SetFontSize(12);

            Paragraph primerParrafo = new Paragraph("Es grato dirigirnos a su Despacho, para expresarle nuestro saludo cordial, en nombre \nde la Facultad de Ingeniería Industrial y de Sistemas, de la Universidad Nacional \nFederico Villarreal, y a la vez, presentarles a:");
            primerParrafo.SetTextAlignment(TextAlignment.JUSTIFIED);
            primerParrafo.SetFontSize(11);

            Paragraph estudiante = new Paragraph("PEÑALOZA ORTEGA, BRIAN");
            estudiante.SetTextAlignment(TextAlignment.CENTER);
            estudiante.SetFontSize(12);

            Paragraph segundoParrafo = new Paragraph("Estudiante del 9no. Ciclo de Estudios, con Código de Matricula N.º 2014002507 de la \nCarrera Profesional de Ingeniería de Sistemas, y de conformidad con lo establecido en \nla Ley Nº 28518 “Ley de Modalidades Formativas Laborales”, solicitarle le permita \nrealizar sus Prácticas Pre Profesionales en su prestigiosa empresa; para lo cual utilizará \ntodos los conocimientos adquiridos en esta Facultad.");
            segundoParrafo.SetTextAlignment(TextAlignment.JUSTIFIED);
            segundoParrafo.SetFontSize(11);

            Paragraph tercerParrafo = new Paragraph("Vuestra aceptación permitirá que el (la) mencionado (a) estudiante, complete su \ndesarrollo profesional aplicando sus conocimientos a la realidad empresarial, y cumpla \ncon su Plan de Estudios de acuerdo a normas académicas vigentes, en esta Casa \nSuperior de Estudios.");
            tercerParrafo.SetTextAlignment(TextAlignment.JUSTIFIED);
            tercerParrafo.SetFontSize(11);

            document.ShowTextAligned(representante, 400, y - 200, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(cargo, 400, y - 215, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(primerParrafo, xMinimo, y - 240, 1, TextAlignment.JUSTIFIED, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(estudiante, 300, y - 290, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(segundoParrafo, xMinimo, y - 310, 1, TextAlignment.JUSTIFIED, VerticalAlignment.TOP, 0);
            document.ShowTextAligned(tercerParrafo, xMinimo, y - 390, 1, TextAlignment.JUSTIFIED, VerticalAlignment.TOP, 0);


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