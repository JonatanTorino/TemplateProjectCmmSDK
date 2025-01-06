using Microsoft.Dynamics.Commerce.Runtime;
using Microsoft.Dynamics.Commerce.Runtime.Messages;
using System.Runtime.Serialization;

namespace Axx.CommerceRuntime.DocumentBranding.Messages
{
    [DataContract]
    public class GetBrandImageDataResponse : Response
    {
        //public GetSysDocuBrandDetailsDataResponse(PagedResult<Entities.SysDocuBrandDetails> doc)
        public GetBrandImageDataResponse(byte[] image)
        {
            this.Image = image;
        }

        [DataMember]
        public byte[] Image;

        //public PagedResult<Entities.SysDocuBrandDetails> SysDocuBrandDetails { get; private set; }
    }
}