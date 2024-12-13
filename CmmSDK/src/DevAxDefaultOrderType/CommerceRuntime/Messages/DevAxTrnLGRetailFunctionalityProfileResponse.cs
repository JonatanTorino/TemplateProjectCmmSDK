using DevAxDefaultOrderType.CommerceRuntime.Entities;
using Microsoft.Dynamics.Commerce.Runtime.Messages;

namespace DevAxDefaultOrderType.CommerceRuntime.Messages
{
    public class DevAxTrnLGRetailFunctionalityProfileResponse : Response
    {
        public TrnLGRetailFunctionalityProfile ProfileEntity { get; }

        public DevAxTrnLGRetailFunctionalityProfileResponse(TrnLGRetailFunctionalityProfile profileEntity)
        {
            this.ProfileEntity = profileEntity;
        }
    }
}
