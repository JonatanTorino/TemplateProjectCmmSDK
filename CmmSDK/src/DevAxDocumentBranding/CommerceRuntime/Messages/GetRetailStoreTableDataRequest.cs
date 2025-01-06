using Microsoft.Dynamics.Commerce.Runtime.Messages;
using System.Runtime.Serialization;

namespace DevAx.CommerceRuntime.DocumentBranding.Messages
{
    [DataContract]
    public class GetRetailStoreTableDataRequest : Request
    {
        public GetRetailStoreTableDataRequest(long channelRecId)
        {
            this.ChannelRecId = channelRecId;
        }

        [DataMember]
        public long ChannelRecId { get; private set; }
    }
}