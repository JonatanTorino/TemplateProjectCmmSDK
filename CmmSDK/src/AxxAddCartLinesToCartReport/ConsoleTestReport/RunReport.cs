using AxxAddCartLinesToCartReport.CommerceRuntime.ProcessReport;
using DevAxxAddCartLinesToCart.CommerceRuntime.Helpers;
using DevAxxAddCartLinesToCart.CommerceRuntime.Model;
using System.Text.Json;

namespace ConsoleTestReport
{
    public class RunReport
    {
        private List<string> reportsModels = new List<string> { "AxxCustomerOrder", "QuotationReport" };

        public void ProccesReport()
        {
            var mockedModel = ConstantHelpers.jsonResponse;
            //Console.WriteLine(mockedModel);
            var dataModel = JsonSerializer.Deserialize<AxxCustomerOrderReportDataModel>(mockedModel);

            Console.WriteLine("Starting Process Report!");
            string reportModels = reportsModels[0];
            Console.WriteLine($"Models {reportModels}");
            GenerateReport generateReports = new GenerateReport($"{reportModels}", dataModel);
            generateReports.GenerateReportMethod(dataModel);
        }
    }
}