using Microsoft.Dynamics.Commerce.Runtime;
using Microsoft.Dynamics.Commerce.Runtime.Messages;
using System.Runtime.Serialization;

namespace DevAx.CommerceRuntime.DocumentBranding.Messages
{
    [DataContract]
    public class GetRetailStoreTableDataResponse : Response
    {
        public GetRetailStoreTableDataResponse(PagedResult<DocumentBranding.Entities.RetailStoreTable> doc)
        {
            this.RetailStoreTable = doc;
        }

        [DataMember]
        public PagedResult<DocumentBranding.Entities.RetailStoreTable> RetailStoreTable { get; private set; }
    }
}