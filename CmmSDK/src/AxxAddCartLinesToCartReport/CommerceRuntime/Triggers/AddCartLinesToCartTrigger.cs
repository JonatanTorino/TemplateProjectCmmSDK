using AxxAddCartLinesToCartReport.CommerceRuntime.ProcessReport;
using DevAxxAddCartLinesToCart.CommerceRuntime.Helpers;
using DevAxxAddCartLinesToCart.CommerceRuntime.Model;
using Microsoft.Dynamics.Commerce.Runtime;
using Microsoft.Dynamics.Commerce.Runtime.Messages;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevAxxAddCartLinesToCart.CommerceRuntime.Triggers
{
    public class AddCartLinesToCartTrigger : IRequestTriggerAsync
    {
        //public IEnumerableType SupportedRequestTypes
        //{
        //    get
        //    {
        //        return new[]
        //        {
        //            //typeof(SaveCustomerOrderRequest),
        //            typeof(AddCartLinesRequest),
        //        };
        //    }
        //}
        IEnumerable<Type> IRequestTriggerAsync.SupportedRequestTypes
        {
            get
            {
                return new[]
                {
                    //typeof(SaveCustomerOrderRequest),
                    typeof(AddCartLinesRequest),
                };
            }
        }

        public Task OnExecuting(Request request)
        {
#if false

            if (request is SaveCustomerOrderRequest saveCustomerOrderRequest)
            {
                obtener la transaccion
                SalesTransaction salesTransaction = new SalesTransaction();
                var roo = await AxxTransactionHelper.LoadSalesTransaction(request.RequestContext, saveCustomerOrderRequest.CartId).ConfigureAwait(false);
                AxxGenerateReportModelRequest generateReportModelRequest = new(salesTransaction);
                AxxGenerateReportModelResponse generateReportModelResponse = await request.RequestContext.ExecuteAsyncAxxGenerateReportModelResponse(generateReportModelRequest).ConfigureAwait(false);
                var json = generateReportModelResponse.JsonDataModel;
                request.SetProperty(JsonReport, json);
                 GENERAR REPORTE
                GenerateReportGenericAxxQuotationReportModelDataModel generateReportGeneric
                            = new(new AxxQuotationReportModelDataModel());

                if (salesTransaction.CustomerOrderType == CustomerOrderType.Quote)
                {
                    DevAxSQRPDFRequest reportRequest = new(salesTransaction);
                    DevAxSQRPDFResponse reportResponse = await request.RequestContext.ExecuteAsyncDevAxSQRPDFResponse(reportRequest).ConfigureAwait(false);
                    request.SetProperty(DevAxSQRConstants.DEVAX_QUOTE_REPORT_MODEL, reportResponse.ReportModel);
                    DevAxSQRDataModel dataModel = reportResponse.ReportModel.DeserializeJsonToDevAxSQRDataModel();
                    TODOGS Remover linea de abajo despues de hacer las pruebas
                    string reportEncoded = ReportGenerator.GetQuotePdfString(dataModel);
                }
            }
#endif
            return Task.CompletedTask;
        }

        public Task OnExecuted(Request request, Response response)
        {
#if false
            if (response is SaveCustomerOrderResponse saveCustomerOrderResponse)
            {
                SalesOrder salesOrder = saveCustomerOrderResponse.Order;
                if (salesOrder.CustomerOrderType == CustomerOrderType.Quote)
                {
                    string datamodelJson = request.GetProperty(DevAxSQRConstants.DEVAX_QUOTE_REPORT_MODEL) as string;
                    DevAxSQRDataModel dataModel = datamodelJson.DeserializeJsonToDevAxSQRDataModel();
                    dataModel.HeaderDataSetList[0].QuotationId = saveCustomerOrderResponse.Order.SalesId;
                    string reportEncoded = ReportGenerator.GetQuotePdfString(dataModel);
                    saveCustomerOrderResponse.Order.SetProperty(DevAxSQRConstants.DEVAX_QUOTE_REPORT_ENCODED, reportEncoded);
                }
            }
#endif
            try
            {
                string mockedModel = ConstantHelpers.jsonResponse;
                AxxCustomerOrderReportDataModel dataModel = null;
#if true
                dataModel = JsonSerializer.Deserialize<AxxCustomerOrderReportDataModel>(mockedModel);
                //AxxCustomerOrderReportDataModel dataModel = mockedModel.DeserializeJsonToAxxCustomerOrderReportDataModel();
#else
                AxxCustomerOrderReportDataModel dataModel = mockedModel.DeserializeJsonToAxxCustomerOrderReportDataModel();
#endif
                //GenerateReport gnrtReport = new GenerateReport();
                //gnrtReport.GenerateReportMethod();
                List<string> reportsModels = new List<string> { "AxxCustomerOrder", "QuotationReport" };
                if (true)
                {
                    ProcessReportConsole.ProcessReport.GenerateReport generateReports
                        = new ProcessReportConsole.ProcessReport.GenerateReport($"{reportsModels[0]}", dataModel);
                    generateReports.GenerateReportMethod(dataModel);
                }
                else
                {
                    GenerateReport generateReports = new GenerateReport($"{reportsModels[0]}", dataModel);
                    generateReports.GenerateReportMethod(dataModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.CompletedTask;
        }
    }
}