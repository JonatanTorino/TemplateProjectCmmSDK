using System;

namespace DataModelReport.Business
{
    public class AxxCustomerOrderReportDataSetHeader //: IRptDataSet
    {
        public string DocumentText { get; set; }
        public string RelatedDocumentTxt { get; set; }
        public string InvoiceTxtHeader { get; set; }
        public decimal EndDiscAmount { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string VatConditionDesc { get; set; }
        public string CompanyCoRegNum { get; set; }
        public DateTime CompanyVATInitialDate { get; set; }
        public string CompanyGrossIncNum { get; set; }
        public string DocLetterId { get; set; }
        public string DocumentCode { get; set; }
        public string InvoiceTxt { get; set; }
        public byte[] LogoCompany { get; set; }
        public string InvoicingVatConditionDesc { get; set; }
        public string InvoicingAddress { get; set; }
        public string VatNum { get; set; }
        public string InvoicingName { get; set; }
        public string PaymentCondition { get; set; }
        public decimal RptExchRate { get; set; }
        public string DlvTermDescription { get; set; }
        public string DlvMode { get; set; }
        public string IdentificationNumber { get; set; }
        public string DocCAIE { get; set; }
        public string DocCAIEDueDate { get; set; }
        public string DocCAIELabel { get; set; }
        public string DocCAIEDueDateLabel { get; set; }
        public string DocQRCode { get; set; }
        public string VATConditionLegend { get; set; } //RpdDiscTax

        public virtual void init()
        {
            VatNum = "V16035880-3";
            CompanyName = "Margarita";
            CompanyAddress = "la Assuncion";
            CompanyPhone = "04248079739";
            DocLetterId = "V";
            InvoiceTxt = "123456";
            DocumentCode = "2206";
        }
    }

    /*
RelatedDocumentTxt
DocumentText
InvoiceTxtHeader
EndDiscAmount
CompanyName
CompanyAddress
CompanyPhone
InvoiceDate
VatConditionDesc
CompanyCoRegNum
CompanyVATInitialDate
CompanyGrossIncNum
DocLetterId
DocumentCode
InvoiceTxt
LogoCompany
InvoicingVatConditionDesc
InvoicingAddress
VatNum
InvoicingName
PaymentCondition
RptExchRate
DlvTermDescription
DlvMode
IdentificationNumber
DocCAIE
DocCAIEDueDate
DocCAIELabel
DocCAIEDueDateLabel
DocQRCode
    */
}