using DataModelReport.Business;
using DevAxxAddCartLinesToCart.CommerceRuntime.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DevAxxAddCartLinesToCart.CommerceRuntime.Business
{
    public class AxxCustomerOrderReportDataProvider
    {
        public AxxCustomerOrderReportDataModel DataModel { get; }
        private readonly AxxCustomerOrderReportDataContract DataContract;

        public AxxCustomerOrderReportDataProvider(AxxCustomerOrderReportDataContract dataContract)
        {
            DataModel = new AxxCustomerOrderReportDataModel();
            DataContract = dataContract;
        }

        public AxxCustomerOrderReportDataProvider()
        {
        }

        public virtual void Process()
        {
            DataModel.AxxReportDataSetHeader = CreateInvoiceHeader();
            DataModel.AxxReportDataSetLine = CreateInvoiceLine();
            DataModel.AxxReportDataSetTax = CreateInvoiceTax();
        }

        public Dictionary<string, DataTable> GetDataSetCollection()
        {
            var rptHeaderDS = new RptDataSource<AxxCustomerOrderReportDataSetHeader>(DataModel.AxxReportDataSetHeader.ToList());
            var rptLinesDS = new RptDataSource<AxxCustomerOrderReportDataSetLine>(DataModel.AxxReportDataSetLine.ToList());
            var rptTaxDS = new RptDataSource<AxxCustomerOrderReportDataSetTax>(DataModel.AxxReportDataSetTax.ToList());

            Dictionary<string, DataTable> dataSetCollection = new Dictionary<string, DataTable>
            {
                { nameof(DataModel.AxxReportDataSetHeader), rptHeaderDS.DataSet },
                { nameof(DataModel.AxxReportDataSetLine), rptLinesDS.DataSet },
                { nameof(DataModel.AxxReportDataSetTax), rptTaxDS.DataSet },
            };
            return dataSetCollection;
        }

        public virtual List<AxxCustomerOrderReportDataSetHeader> CreateInvoiceHeader()
        {
            //Armado de la lista con la información del DataContract
            return new List<AxxCustomerOrderReportDataSetHeader>() { new AxxCustomerOrderReportDataSetHeader {
                CompanyName = "Axxon",
                CompanyAddress = "Buenos Aires",
                CompanyPhone = "+54911249865",
                InvoiceDate = System.DateTime.Now,
                InvoiceTxt = "123456",
                VatNum = "23052012",
                VatConditionDesc = "VatConditionDesc",
                CompanyGrossIncNum = "CompanyGrossIVatConditionDescncNum",
                DocLetterId = "DocLetterId",
                DocumentCode = "DocumentCode",
                DocCAIE = "DocCAIE",
                DocCAIEDueDate = "DocCAIEDueDate",
                DocCAIELabel = "DocCAIELabel",
                DocCAIEDueDateLabel = "DocCAIEDueDateLabel",
                CompanyCoRegNum = "CompanyCoRegNum",
                CompanyVATInitialDate = System.DateTime.Now,
                }
            };
        }

        public virtual List<AxxCustomerOrderReportDataSetLine> CreateInvoiceLine()
        {
            //Armado de la lista con la información del DataContract
            return new List<AxxCustomerOrderReportDataSetLine>() { new AxxCustomerOrderReportDataSetLine { SalesPrice = 2000, Qty = 2, AmountTxt = "Dos mil", ItemId = "Aire 2", InvoiceId = "16035880", CustInvoiceJourDueDate = System.DateTime.Now },
                new AxxCustomerOrderReportDataSetLine { SalesPrice = 1000, Qty = 2, AmountTxt = "Mil", ItemId = "Aire", InvoiceId = "16035880" , CustInvoiceJourDueDate = System.DateTime.Now } };
        }

        public virtual List<AxxCustomerOrderReportDataSetTax> CreateInvoiceTax()
        {
            //Armado de la lista con la información del DataContract
            return new List<AxxCustomerOrderReportDataSetTax>() { new AxxCustomerOrderReportDataSetTax { TaxAmount = 10, TaxCode = "IVA21", TaxValue = 21, CustInvoiceJourDueDate = System.DateTime.Now }, new AxxCustomerOrderReportDataSetTax { TaxAmount = 8, TaxCode = "IVA10.5", TaxValue = 10.5M, CustInvoiceJourDueDate = System.DateTime.Now } };
        }
    }

    public class RptDataSource<T>
    {
        //Esta clase sirve para devolver un DataTable para usar como DataSet en los reportes RDLC
        //El tipo TDataSet debe implementar IRptDataSet solo para asegurar la convención de nombre y que sea una clase.

        public DataTable DataSet { get; set; }

        /// <summary>
        /// Asegura que la construcción de esta clase cree un DataTable con una única definición de columnas.
        /// </summary>
        /// <param name="recordList">Colección de objetos que representan registros, donde sus propiedades oficiaran como columnas</param>
        public RptDataSource(List<T> recordList)
        {
            Type type = typeof(T);
            DataSet = InitColumns(type);
            InsertRows(recordList);
        }

        private DataTable InitColumns(Type type)
        {
            DataTable details = new DataTable();

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Type propertyType = property.PropertyType;
                if (propertyType == typeof(decimal)) //Reemplazo propiedad del tipo decimal por double dado que en RDLC usan double
                    propertyType = typeof(double);

                DataColumn dataColumn = new DataColumn()
                {
                    DataType = propertyType,
                    ColumnName = property.Name,
                };

                details.Columns.Add(dataColumn);
            }
            return details;
        }

        private void InsertRows(List<T> recordList)
        {
            foreach (var item in recordList)
            {
                DataRow row = DataSet.NewRow();
                PropertyInfo[] properties = item.GetType().GetProperties();
                foreach (var property in properties)
                    row[property.Name] = property.GetValue(item);

                DataSet.Rows.Add(row);
            }
        }
    }
}