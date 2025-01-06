using Microsoft.Dynamics.Commerce.Runtime.ComponentModel.DataAnnotations;
using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using System.Runtime.Serialization;

namespace DevAx.CommerceRuntime.DocumentBranding.Entities
{
    public class SysDocuBrandDetails : CommerceEntity
    {
        /*		[ADDRESS] [nvarchar](250) NOT NULL,
		[ADDRESSCOLLAPSE] [int] NOT NULL,
		[ADDRESSDELIMITER] [nvarchar](5) NOT NULL,
		[BRANDID] [nvarchar](30) NOT NULL,
		[BRANDNAME] [nvarchar](60) NOT NULL,
		[EMAIL] [nvarchar](80) NOT NULL,
		[IMAGE1] [varbinary](max) NULL,
		[IMAGE1NAME] [nvarchar](60) NOT NULL,
		[IMAGE2] [varbinary](max) NULL,
		[IMAGE2NAME] [nvarchar](60) NOT NULL,
		[IMAGE3] [varbinary](max) NULL,
		[IMAGE3NAME] [nvarchar](60) NOT NULL,
		[LOGISTICSLOCATIONRECID] [bigint] NOT NULL,
		[NOTESLINE1] [nvarchar](254) NOT NULL,
		[NOTESLINE2] [nvarchar](254) NOT NULL,
		[NOTESLINE3] [nvarchar](254) NOT NULL,
		[PHONE] [nvarchar](20) NOT NULL,
		[PHONELOCAL] [nvarchar](10) NOT NULL,
		[PRIMARYCOLOR] [nvarchar](30) NOT NULL,
		[SECONDARYCOLOR] [nvarchar](30) NOT NULL,
		[REPORTNAME] [nvarchar](40) NOT NULL,
		[DESIGNNAME] [nvarchar](40) NOT NULL,
		[TELEFAX] [nvarchar](20) NOT NULL,
		[URL] [nvarchar](255) NOT NULL,
		[RECID] [bigint] NOT NULL,
		[DATAAREAID] [nvarchar](4) NOT NULL DEFAULT '',*/

        private const string BrandIdColumn = "BRANDID";
        private const string BrandNameColumn = "BRANDNAME";
        private const string Image1NameColumn = "IMAGE1NAME";
        private const string Image2NameColumn = "IMAGE2NAME";
        private const string Image3NameColumn = "IMAGE3NAME";
        private const string RecIdColumn = "RECID";

        public SysDocuBrandDetails() : base("SysDocuBrandDetails")
        {
        }

        [DataMember]
        [Column(BrandIdColumn)]
        public string BrandId
        {
            get { return (string)this[BrandIdColumn]; }
            set { this[BrandIdColumn] = value; }
        }

        [DataMember]
        [Column(BrandNameColumn)]
        public string BrandName
        {
            get { return (string)this[BrandNameColumn]; }
            set { this[BrandNameColumn] = value; }
        }

        [DataMember]
        [Column(Image1NameColumn)]
        public string Image1Name
        {
            get { return (string)this[Image1NameColumn]; }
            set { this[Image1NameColumn] = value; }
        }

        [DataMember]
        [Column(Image2NameColumn)]
        public string Image2Name
        {
            get { return (string)this[Image2NameColumn]; }
            set { this[Image2NameColumn] = value; }
        }

        [DataMember]
        [Column(Image3NameColumn)]
        public string Image3Name
        {
            get { return (string)this[Image3NameColumn]; }
            set { this[Image3NameColumn] = value; }
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