using DataModelReport.Business;
using System.Collections.Generic;

namespace DevAxxAddCartLinesToCart.CommerceRuntime.Model
{
    public class AxxCustomerOrderReportDataModel
    {
        public List<AxxCustomerOrderReportDataSetHeader> AxxReportDataSetHeader { get; set; }
        public List<AxxCustomerOrderReportDataSetLine> AxxReportDataSetLine { get; set; }
        public List<AxxCustomerOrderReportDataSetTax> AxxReportDataSetTax { get; set; }
    }

    public class AxxAddCartLinesToCartReportDataModel
    {
        public List<AxxCustomerOrderReportDataSetHeader> AxxReportDataSetHeader { get; set; }
        public List<AxxCustomerOrderReportDataSetLine> AxxReportDataSetLine { get; set; }
        public List<AxxCustomerOrderReportDataSetTax> AxxReportDataSetTax { get; set; }
    }
}