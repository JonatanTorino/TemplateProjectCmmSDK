namespace ProcessReportConsole.Helpers
{
    public static class ConstantHelpers
    {
        public const string jsonResponse = @"{
  ""AxxReportDataSetHeader"": [
    {
      ""CompanyAddress"": ""Buenos Aires"",
      ""CompanyGrossIncNum"": ""CompanyGrossIncNum"",
      ""CompanyName"": ""Axxon"",
      ""CompanyPhone"": ""+54911249865"",
      ""CompanyVATInitialDate"": ""0001-01-01T00:00:00Z"",
      ""DocCAIE"": ""DocCAIE"",
      ""DocCAIEDueDate"": ""DocCAIEDueDate"",
      ""DocCAIEDueDateLabel"": ""DocCAIEDueDateLabel"",
      ""DocCAIELabel"": ""DocCAIELabel"",
      ""DocLetterId"": ""DocLetterId"",
      ""DocumentCode"": ""DocumentCode"",
      ""EndDiscAmount"": 0.0,
      ""InvoiceDate"": ""2024-12-23T19:37:59Z"",
      ""InvoiceTxt"": ""123456"",
      ""RptExchRate"": 0.0,
      ""VatConditionDesc"": ""VatConditionDesc"",
      ""VatNum"": ""23052012""
    }
  ],
  ""AxxReportDataSetLine"": [
    {
      ""AmountTxt"": ""Dos mil"",
      ""CustInvoiceJourDueDate"": ""0001-01-01T00:00:00Z"",
      ""DiscountAmount"": 0.0,
      ""DiscPercent"": 0.0,
      ""InvoiceAmount"": 0.0,
      ""InvoiceId"": ""16035880"",
      ""ItemId"": ""Aire 2"",
      ""LineAmount"": 0.0,
      ""LineAmountInclTax"": 0.0,
      ""Qty"": 2.0,
      ""SalesPrice"": 2000.0,
      ""SalesPriceInclTax"": 0.0
    },
    {
      ""AmountTxt"": ""Mil"",
      ""CustInvoiceJourDueDate"": ""0001-01-01T00:00:00Z"",
      ""DiscountAmount"": 0.0,
      ""DiscPercent"": 0.0,
      ""InvoiceAmount"": 0.0,
      ""InvoiceId"": ""16035880"",
      ""ItemId"": ""Aire"",
      ""LineAmount"": 0.0,
      ""LineAmountInclTax"": 0.0,
      ""Qty"": 2.0,
      ""SalesPrice"": 1000.0,
      ""SalesPriceInclTax"": 0.0
    }
  ],
  ""AxxReportDataSetTax"": [
    {
      ""CustInvoiceJourDueDate"": ""0001-01-01T00:00:00Z"",
      ""DiscAmount"": 0.0,
      ""IsExempt"": 0,
      ""IsPC"": 0,
      ""PrintTaxes"": 0,
      ""TaxAmount"": 10.0,
      ""TaxCode"": ""IVA21"",
      ""TaxValue"": 21.0
    },
    {
      ""CustInvoiceJourDueDate"": ""0001-01-01T00:00:00Z"",
      ""DiscAmount"": 0.0,
      ""IsExempt"": 0,
      ""IsPC"": 0,
      ""PrintTaxes"": 0,
      ""TaxAmount"": 8.0,
      ""TaxCode"": ""IVA10.5"",
      ""TaxValue"": 10.5
    }
  ]
}";

        #region Properties

        /// <summary>
        /// Nombre del Archivo que genera el Reporte
        /// </summary>
        public static string FileName { get; private set; }

        /// <summary>
        /// Ruta Relativa donde se buscará el archivo que genera el reporte
        /// </summary>
        //local project
        //private string relativePath = @$"K:\BranchsLG\TemplateProjectCmmSDK\CmmSDK\src\AxxAddCartLinesToCartReport\CommerceRuntime\ProcessReport";
        //install extension
        //private string relativePath = @$"C:\Program Files\Microsoft Dynamics 365\10.0\Commerce Scale Unit\Extensions\ProcessReport";
        //resource
        private static string relativePath = @$"K:\BranchsLG\TemplateProjectCmmSDK\CmmSDK\src\AxxAddCartLinesToCartReport\ProcessReportConsole\ProcessReport";

        /// <summary>
        /// Ruta del
        /// </summary>
        private static string PathFile
        {
            //get { return @$"{relativePath}\{FileName}.rdlc"; }
            get { return @$"{relativePath}\ReportModel\{FileName}.rdlc"; }
        }

        private static string OutPutPathFileReport
        {
            get
            {
                return @$"{relativePath}\PrintReports\{MethodsHelpers.BuildFileReportName()}";
            }
        }

        #endregion Properties
    }
}