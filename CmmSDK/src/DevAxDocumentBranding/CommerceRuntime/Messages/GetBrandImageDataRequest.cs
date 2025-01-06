using Microsoft.Dynamics.Commerce.Runtime.Messages;
using System.Runtime.Serialization;

namespace DevAx.CommerceRuntime.DocumentBranding.Messages
{
    [DataContract]
    public class GetBrandImageDataRequest : Request
    {
        public GetBrandImageDataRequest(string brandId, int imageNumber)
        {
            this.BrandId = brandId;
            this.ImageNumber = imageNumber;
        }

        [DataMember]
        public string BrandId { get; private set; }

        [DataMember]
        public int ImageNumber { get; private set; }
    }
}