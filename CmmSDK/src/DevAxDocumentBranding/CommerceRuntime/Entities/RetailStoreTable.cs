using Microsoft.Dynamics.Commerce.Runtime.ComponentModel.DataAnnotations;
using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using System.Runtime.Serialization;

namespace DevAx.CommerceRuntime.DocumentBranding.Entities
{
    public class RetailStoreTable : CommerceEntity
    {
        private const string InvoiceImagesColumn = "DevAxInvoiceImages";
        private const string QuoteImagesColumn = "DevAxQuoteImages";
        private const string RecIdColumn = "RECID";
        private const string DataAreaIdColumn = "DATAAREAID";

        public RetailStoreTable() : base("RetailStoreTable")
        {
        }

        [DataMember]
        [Column(InvoiceImagesColumn)]
        public string InvoiceImages
        {
            get { return (string)this[InvoiceImagesColumn]; }
            set { this[InvoiceImagesColumn] = value; }
        }

        [DataMember]
        [Column(QuoteImagesColumn)]
        public string QuoteImages
        {
            get { return (string)this[QuoteImagesColumn]; }
            set { this[QuoteImagesColumn] = value; }
        }

        [DataMember]
        [Column(DataAreaIdColumn)]
        public string DataAreaId
        {
            get { return (string)this[DataAreaIdColumn]; }
            set { this[DataAreaIdColumn] = value; }
        }

        [DataMember]
        [Column(RecIdColumn)]
        public long RecId
        {
            get { return (long)this[RecIdColumn]; }
            set { this[RecIdColumn] = value; }
        }
    }
}