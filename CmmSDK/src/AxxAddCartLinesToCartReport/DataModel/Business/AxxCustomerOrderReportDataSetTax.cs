using System;

namespace DataModelReport.Business
{
    public class AxxCustomerOrderReportDataSetTax //: IRptDataSet
    {
        public decimal TaxAmount { get; set; }
        public string TaxTypeName { get; set; } //
        public string TaxCode { get; set; }
        public decimal TaxValue { get; set; }
        public DateTime CustInvoiceJourDueDate { get; set; }
        public string TaxName { get; set; }
        public int PrintTaxes { get; set; }
        public int IsPC { get; set; }            //RdpTaxIncluded
        public string TaxBaseAmount { get; set; }   //RpdDiscTax
        public int IsExempt { get; set; }        //RpdDiscTax
        public decimal DiscAmount { get; set; }      //RpdDiscTax
    }
}