namespace ProcessReportConsole.Helpers
{
    public static class MethodsHelpers
    {
        public static string BuildFileReportName()
        {
            string dateFile = DateTime.Now.ToShortDateString().Replace("/", "");
            string datehourFile = $"{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";
            return $"Informe{dateFile}{datehourFile}.pdf";
        }

        public static string BuildNameOutPutPathFileReport()
            => @$"K:\BranchsLG\TemplateProjectCmmSDK\CmmSDK\src\AxxQuotationReport\CommerceRuntime\ProcessReport\PrintReports\{BuildFileReportName}";
    }
}