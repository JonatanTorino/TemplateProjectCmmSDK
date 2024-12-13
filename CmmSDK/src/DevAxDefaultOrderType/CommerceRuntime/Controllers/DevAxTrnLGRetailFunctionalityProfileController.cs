using DevAxDefaultOrderType.CommerceRuntime.Entities;
using DevAxDefaultOrderType.CommerceRuntime.Exceptions;
using DevAxDefaultOrderType.CommerceRuntime.Messages;
using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using Microsoft.Dynamics.Commerce.Runtime.Hosting.Contracts;
using System;
using System.Threading.Tasks;

namespace DevAxDefaultOrderType.CommerceRuntime.Controllers
{
    // New extended controller.
    [RoutePrefix("DevAxTrnLGRetailFunctionalityProfile")]
    [BindEntity(typeof(TrnLGRetailFunctionalityProfile))]
    public class DevAxTrnLGRetailFunctionalityProfileController : IController
    {
        [HttpGet]
        [Authorization(CommerceRoles.Customer, CommerceRoles.Employee)]
        public async Task<TrnLGRetailFunctionalityProfile> GetProfileAsync(IEndpointContext context)
        {
            try
            {
                DevAxTrnLGRetailFunctionalityProfileRequest request = new DevAxTrnLGRetailFunctionalityProfileRequest();
                DevAxTrnLGRetailFunctionalityProfileResponse response =
                    await context.ExecuteAsync<DevAxTrnLGRetailFunctionalityProfileResponse>(request).ConfigureAwait(false);
                return response.ProfileEntity;
            }
            catch (Exception ex)
            {
                throw new DevAxTrnLGRetailFunctionalityProfileException($"{ex.Message}", ex);
            }
        }
    }
}