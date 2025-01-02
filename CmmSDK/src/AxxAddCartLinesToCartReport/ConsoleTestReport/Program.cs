// See https://aka.ms/new-console-template for more information
using AxxAddCartLinesToCartReport.CommerceRuntime.ProcessReport;
using DevAxxAddCartLinesToCart.CommerceRuntime.Helpers;
using DevAxxAddCartLinesToCart.CommerceRuntime.Model;
using System.Text.Json;

List<string> reportsModels = new List<string> { "AxxCustomerOrder", "QuotationReport" };

try
{
    Console.WriteLine("Hello, World!");
    var mockedModel = ConstantHelpers.jsonResponse;
    Console.WriteLine(mockedModel);
    //AxxCustomerOrderReportDataModel dataModel = mockedModel.DeserializeJsonTo<AxxCustomerOrderReportDataModel>();
    var dataModel = JsonSerializer.Deserialize<AxxCustomerOrderReportDataModel>(mockedModel);
    //Console.WriteLine("Printing Json Deserialized!");
    //foreach (var item in dataModel.AxxReportDataSetHeader)
    //{
    //    Console.WriteLine(item.CompanyAddress);
    //    Console.WriteLine(item.DocCAIE);
    //    Console.WriteLine(item.DocumentCode);
    //}
    //Console.WriteLine("Json Printed Deserialized!");
    Console.WriteLine("Starting Process Report!");
    string reportModels = reportsModels[0];
    Console.WriteLine($"Models {reportModels}");
    GenerateReport generateReports = new GenerateReport($"{reportModels}", dataModel);
    generateReports.GenerateReportMethod(dataModel);
    Console.WriteLine("Finishing Process Report!");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
finally
{
    Console.WriteLine("Process Finished!");
}