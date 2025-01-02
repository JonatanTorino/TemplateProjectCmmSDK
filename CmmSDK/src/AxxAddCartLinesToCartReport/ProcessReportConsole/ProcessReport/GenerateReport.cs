using DevAxxAddCartLinesToCart.CommerceRuntime.Model;
using Microsoft.Reporting.NETCore;
using ProcessReportConsole.Helpers;
using System.Collections;
using System.Net;
using System.Reflection;

namespace ProcessReportConsole.ProcessReport
{
    public class GenerateReport
    {
        #region Properties

        /// <summary>
        /// Nombre del Archivo que genera el Reporte
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Ruta Relativa donde se buscará el archivo que genera el reporte
        /// </summary>
        //local project
        //private string relativePath = @$"K:\BranchsLG\TemplateProjectCmmSDK\CmmSDK\src\AxxAddCartLinesToCartReport\CommerceRuntime\ProcessReport";
        //install extension
        //private string relativePath = @$"C:\Program Files\Microsoft Dynamics 365\10.0\Commerce Scale Unit\Extensions\ProcessReport";
        //resource
        private string relativePath = @$"K:\BranchsLG\TemplateProjectCmmSDK\CmmSDK\src\AxxAddCartLinesToCartReport\ProcessReportConsole\ProcessReport";

        /// <summary>
        /// Ruta del
        /// </summary>
        private string PathFile
        {
            //get { return @$"{relativePath}\{FileName}.rdlc"; }
            get { return @$"{relativePath}\ReportModel\{FileName}.rdlc"; }
        }

        private string OutPutPathFileReport
        {
            get
            {
                return @$"{relativePath}\PrintReports\{MethodsHelpers.BuildFileReportName()}";
            }
        }

        #endregion Properties

        public GenerateReport(string fileName)
        {
            this.FileName = string.IsNullOrEmpty(fileName) ? "QuotationReport" : fileName;
        }

        public GenerateReport(string fileName, AxxAddCartLinesToCartReportDataModel dataModel)
        {
            this.FileName = string.IsNullOrEmpty(fileName) ? "QuotationReport" : fileName;
        }

        public GenerateReport(string fileName, AxxCustomerOrderReportDataModel dataModel)
        {
            this.FileName = string.IsNullOrEmpty(fileName) ? "QuotationReport" : fileName;
        }

        public void GenerateReportMethod()
        {
            #region Construye objeto LocalReport

            // Crea un nuevo informe
            using (LocalReport report = new LocalReport())
            {
                using var openRead = System.IO.File.OpenRead(PathFile);
                // Carga el archivo RDLC
                report.LoadReportDefinition(openRead);

                #endregion Construye objeto LocalReport

                //Toma el modelo de datos
                AxxAddCartLinesToCartReportDataModel dataModel = new AxxAddCartLinesToCartReportDataModel();

                // Agrega la fuente de datos al informe
                AddDataSourcesToReport(dataModel, report);

                #region Renderiza el informe en formato PDF

                // Renderiza el informe en formato PDF

                byte[] renderedBytes = report.Render("PDF");

                #endregion Renderiza el informe en formato PDF

                #region Guarda el informe en un archivo

                System.IO.File.WriteAllBytes(OutPutPathFileReport, renderedBytes);

                #endregion Guarda el informe en un archivo
            }
        }

        public void GenerateReportMethod(AxxCustomerOrderReportDataModel dataModel)
        {
            #region Construye objeto LocalReport

            // Crea un nuevo informe
            using (LocalReport report = new LocalReport())
            {
                using var openRead = System.IO.File.OpenRead(PathFile);
                // Carga el archivo RDLC
                report.LoadReportDefinition(openRead);

                #endregion Construye objeto LocalReport

                // Agrega la fuente de datos al informe
                AddDataSourcesToReport(dataModel, report);

                #region Renderiza el informe en formato PDF

                // Renderiza el informe en formato PDF
                byte[] renderedBytes = null;
                if (false)
                {
                    renderedBytes = report.Render("PDF");
                }
                else
                {
                    // Configurar los parámetros de renderización
                    string mimeType;
                    string encoding;
                    string fileNameExtension;
                    string[] streams;
                    Warning[] warnings;

                    // Renderizar el informe en formato PDF
                    renderedBytes = report.Render(
                        "PDF", null, out mimeType, out encoding, out fileNameExtension,
                        out streams, out warnings);
                }

                #endregion Renderiza el informe en formato PDF

                #region Guarda el informe en un archivo

                /* @$"{relativePath}\PrintReports\{MethodsHelpers.BuildFileReportName}" */
                //var nameReport = MethodsHelpers.BuildFileReportName();
                //var pathToGenerateReport = @$"{relativePath}\PrintReports\{nameReport}";
                //System.IO.File.WriteAllBytes(pathToGenerateReport, renderedBytes);
                System.IO.File.WriteAllBytes(OutPutPathFileReport, renderedBytes);

                #endregion Guarda el informe en un archivo
            }
        }

        public void GenerateReportServerMethod(AxxCustomerOrderReportDataModel dataModel)
        {
            #region Construye objeto LocalReport

            ServerReport reportServer = new ServerReport();
            reportServer.ReportServerCredentials.NetworkCredentials
                = new NetworkCredential("login", "password", "DOMAIN");
            reportServer.ReportServerUrl = new Uri("http://localhost/ReportServer");
            reportServer.ReportPath = "/Invoice";
            reportServer.SetParameters(new[] { new ReportParameter("Date", DateTime.Now.Date.ToString()) });
            byte[] pdf = reportServer.Render("PDF");
            // Crea un nuevo informe
            using (LocalReport report = new LocalReport())
            {
                using var openRead = System.IO.File.OpenRead(PathFile);
                // Carga el archivo RDLC
                report.LoadReportDefinition(openRead);

                #endregion Construye objeto LocalReport

                // Agrega la fuente de datos al informe
                AddDataSourcesToReport(dataModel, report);

                #region Renderiza el informe en formato PDF

                // Renderiza el informe en formato PDF

                byte[] renderedBytes = report.Render("PDF");

                #endregion Renderiza el informe en formato PDF

                #region Guarda el informe en un archivo

                /* @$"{relativePath}\PrintReports\{MethodsHelpers.BuildFileReportName}" */
                //var nameReport = MethodsHelpers.BuildFileReportName();
                //var pathToGenerateReport = @$"{relativePath}\PrintReports\{nameReport}";
                //System.IO.File.WriteAllBytes(pathToGenerateReport, renderedBytes);
                System.IO.File.WriteAllBytes(OutPutPathFileReport, renderedBytes);

                #endregion Guarda el informe en un archivo
            }
        }

        #region Private Methods

        private static void AddDataSourcesToReport(AxxAddCartLinesToCartReportDataModel dataModel, LocalReport report)
        {
            // Obtener todas las propiedades de DataModel
            PropertyInfo[] properties = typeof(AxxAddCartLinesToCartReportDataModel).GetProperties();

            foreach (var property in properties)
            {
                // Obtener el valor de la propiedad
                var value = property.GetValue(dataModel);

                // Verificar si el valor es una lista o un array y no es nulo y tiene elementos
                if (value != null &&
                (typeof(IList).IsAssignableFrom(property.PropertyType) && ((IList)value).Count > 0))
                {
                    // Agregar la fuente de datos al informe
                    /* tener en cuenta que property.Name tiene que tener el mismo nombre
                       que el DataSet al que se va a mapear */
                    report.DataSources.Add(new ReportDataSource(property.Name, value));
                }
            }
        }

        private static void AddDataSourcesToReport(AxxCustomerOrderReportDataModel dataModel, LocalReport report)
        {
            // Obtener todas las propiedades de DataModel
            PropertyInfo[] properties = typeof(AxxCustomerOrderReportDataModel).GetProperties();

            foreach (var property in properties)
            {
                // Obtener el valor de la propiedad
                var value = property.GetValue(dataModel);

                // Verificar si el valor es una lista o un array y no es nulo y tiene elementos
                if (value != null &&
                (typeof(IList).IsAssignableFrom(property.PropertyType) && ((IList)value).Count > 0))
                {
                    // Agregar la fuente de datos al informe
                    /* tener en cuenta que property.Name tiene que tener el mismo nombre
                       que el DataSet al que se va a mapear */
                    report.DataSources.Add(new ReportDataSource(property.Name, value));
                }
            }
        }

        private string BuildFileReportName()
        {
            string dateFile = DateTime.Now.ToShortDateString().Replace("/", "");
            string datehourFile = $"{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";
            return $"Informe{dateFile}{datehourFile}.pdf";
        }

        #endregion Private Methods

        /*
         // Define el path relativo
        string pathRelativo = "archivos/miArchivo.txt";

        // Obtiene el directorio del path relativo
        string directorio = Path.GetDirectoryName(pathRelativo);

        // Verifica si el directorio existe, si no, lo crea
        if (!Directory.Exists(directorio))
        {
            Directory.CreateDirectory(directorio);
            Console.WriteLine("Directorio creado: " + directorio);
        }

        // Guarda el archivo
        File.WriteAllText(pathRelativo, contenido);
        Console.WriteLine("Archivo guardado en: " + Path.GetFullPath(pathRelativo));
         */
    }
}