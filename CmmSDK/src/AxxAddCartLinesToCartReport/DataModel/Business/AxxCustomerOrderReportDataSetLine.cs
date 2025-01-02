using System;

namespace DataModelReport.Business
{
    public class AxxCustomerOrderReportDataSetLine //: IRptDataSet
    {
        public decimal InvoiceAmount { get; set; }
        public string AmountTxt { get; set; }
        public string InvoiceId { get; set; }
        public DateTime CustInvoiceJourDueDate { get; set; }
        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public decimal Qty { get; set; }
        public string SalesUnitTxt { get; set; }
        public decimal DiscPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal LineAmount { get; set; }
        public string PrintTaxes { get; set; }
        public decimal SalesPriceInclTax { get; set; } //RdpTaxIncluded
        public decimal LineAmountInclTax { get; set; } //RdpTaxIncluded
        public string ItemId { get; set; }            //RpdDiscTax
        public decimal SalesPrice { get; set; }        //RpdDiscTax
    }
}