using Microsoft.Dynamics.Commerce.Runtime.ComponentModel.DataAnnotations;
using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using System.Runtime.Serialization;

namespace DevAx.CommerceRuntime.DocumentBranding.Entities
{
    public class SysDocuBrandImages : CommerceEntity
    {
        private const string DescriptionColumn = "DESCRIPTION";
        private const string FormatColumn = "FORMAT";
        private const string ImageColumn = "IMAGE";
        private const string NameColumn = "NAME";
        private const string RecIdColumn = "RECID";

        public SysDocuBrandImages() : base("SysDocuBrandImages")
        {
        }

        [DataMember]
        [Column(DescriptionColumn)]
        public string Description
        {
            get { return (string)this[DescriptionColumn]; }
            set { this[DescriptionColumn] = value; }
        }

        [DataMember]
        [Column(FormatColumn)]
        public string Format
        {
            get { return (string)this[FormatColumn]; }
            set { this[FormatColumn] = value; }
        }

        [DataMember]
        [Column(ImageColumn)]
        public byte[] Image
        {
            get { return (byte[])this[ImageColumn]; }
            set { this[ImageColumn] = value; }
        }

        [DataMember]
        [Column(NameColumn)]
        public string Name
        {
            get { return (string)this[NameColumn]; }
            set { this[NameColumn] = value; }
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