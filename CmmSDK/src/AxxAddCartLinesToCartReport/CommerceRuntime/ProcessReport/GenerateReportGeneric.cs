using Microsoft.Reporting.NETCore;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Reflection;

namespace DevAxAxxQuotationReport.CommerceRuntime.ProcessReport
{
    public class GenerateReportGeneric<T>
    {
        #region Properties

        public string FileName { get; }

        public string RelativePath
        {
            /* K:\BranchsLG\TemplateProjectCmmSDK\CmmSDK\src\AxxQuotationReport\CommerceRuntime\ProcessReport\ReportModel\*/
            get { return @$"K:\BranchsLG\TemplateProjectCmmSDK\CmmSDK\src\AxxQuotationReport\CommerceRuntime\ProcessReport"; }
        }

        private string PathFile
        {
            get { return @$"{RelativePath}\ReportModel\{FileName}.rdlc"; }
        }

        private string PathFileRelative
        {
            get { return @$"K:\BranchsLG\TemplateProjectCmmSDK\CmmSDK\src\AxxQuotationReport\CommerceRuntime\ProcessReport"; }
            set { value = RelativePath; }
        }

        private string OutPutPathFileReport
        {
            get { return @$"{RelativePath}\PrintReports\{Helpers.MethodsHelpers.BuildFileReportName}"; }
        }

        public T DataModel { get; private set; } // Propiedad para acceder al modelo de datos

        #endregion Properties

        #region Constructores

        private bool validateString(string fileName)
        {
            return (string.IsNullOrEmpty(fileName) || fileName?.Length > 3) ? false : true;
        }

        public GenerateReportGeneric(string fileName)
        {
            this.FileName = validateString(fileName) ? "QuotationReport" : fileName;
        }

        public GenerateReportGeneric(string fileName, T dataModel)
        {
            this.FileName = validateString(fileName) ? "QuotationReport" : fileName;
            this.DataModel = dataModel; // Asigna el modelo de datos
        }

        public GenerateReportGeneric(string fileName, T dataModel, string relativePath)
        {
            this.PathFileRelative = relativePath;
            this.FileName = validateString(fileName) ? "QuotationReport" : fileName;
            this.DataModel = dataModel; // Asigna el modelo de datos
        }

        public GenerateReportGeneric(T dataModel)
        {
            this.DataModel = dataModel; // Asigna el modelo de datos
        }

        #endregion Constructores

        public void GenerateReportMethod(T dataModel)
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
                byte[] renderedBytes = report.Render("PDF");

                #endregion Renderiza el informe en formato PDF

                #region Guarda el informe en un archivo

                System.IO.File.WriteAllBytes(OutPutPathFileReport, renderedBytes);

                #endregion Guarda el informe en un archivo
            }
        }

        #region Private Methods

        private static void AddDataSourcesToReport(T dataModel, LocalReport report)
        {
            // Obtener todas las propiedades de DataModel
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                // Obtener el valor de la propiedad
                var value = property.GetValue(dataModel);

                // Verificar si el valor es una lista o un array y no es nulo y tiene elementos
                if (value != null &&
                (typeof(IList).IsAssignableFrom(property.PropertyType) && ((IList)value).Count > 0))
                {
                    // Agregar la fuente de datos al informe
                    report.DataSources.Add(new ReportDataSource(property.Name, value));
                }
            }
        }

        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new ConcurrentDictionary<Type, PropertyInfo[]>();

        private static void AddDataSourcesToReportCache(T dataModel, LocalReport report)
        {
            // Obtener las propiedades de DataModel desde la caché o almacenarlas si no existen
            PropertyInfo[] properties = PropertyCache.GetOrAdd(typeof(T), type => type.GetProperties());

            // Filtrar y agregar las fuentes de datos al informe
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(dataModel);
                if (value != null && typeof(IList).IsAssignableFrom(property.PropertyType) && ((IList)value).Count > 0)
                    report.DataSources.Add(new ReportDataSource(property.Name, value));
            }
        }

        #endregion Private Methods
    }
}