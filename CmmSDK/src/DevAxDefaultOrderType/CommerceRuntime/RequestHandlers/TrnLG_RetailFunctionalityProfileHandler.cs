using DevAxDefaultOrderType.CommerceRuntime.Entities;
using DevAxDefaultOrderType.CommerceRuntime.Exceptions;
using DevAxDefaultOrderType.CommerceRuntime.Messages;
using DevAxDefaultOrderType.CommerceRuntime.Services;
using Microsoft.Dynamics.Commerce.Runtime;
using Microsoft.Dynamics.Commerce.Runtime.Messages;
using System;
using System.Threading.Tasks;

namespace DevAxDefaultOrderType.CommerceRuntime.RequestHandlers
{
    #region Handler

    public class TrnLG_RetailFunctionalityProfileHandler : SingleAsyncRequestHandler<DevAxTrnLGRetailFunctionalityProfileRequest>
    {
        private string errorMessage = "No se encontró ningún registro en la tabla extendida de RetailFunctionalityProfile con el Profile Id {0}";
        private string El_ProfileId_no_puede_estar_vacío = "El ProfileId no puede estar vacío.";

        protected override async Task<Response> Process(DevAxTrnLGRetailFunctionalityProfileRequest request)
        {
            ValidateModel(request);

            string profId = request.RequestContext.GetDeviceConfiguration().ProfileId;

            TrnLGRetailFunctionalityProfile getEntityFromDB =
                await TrnLGRetailFunctionalityProfileData.GetProfileAsync(request.RequestContext, profId).ConfigureAwait(false);

            DevAxTrnLGRetailFunctionalityProfileResponse serviceResponse =
                new DevAxTrnLGRetailFunctionalityProfileResponse(getEntityFromDB);

            ValidateResponse(serviceResponse, profId);

            return await Task.FromResult<Response>(serviceResponse).ConfigureAwait(false);
        }

        #region Validations

        private void ValidateModel(DevAxTrnLGRetailFunctionalityProfileRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.RequestContext.GetDeviceConfiguration().ProfileId))
                throw new ArgumentNullException(El_ProfileId_no_puede_estar_vacío, "ProfileId");
        }

        private void ValidateResponse(DevAxTrnLGRetailFunctionalityProfileResponse serviceResponse, string profId)
        {
            if (serviceResponse.ProfileEntity is null)
                throw new DevAxTrnLGRetailFunctionalityProfileException(string.Format(errorMessage, profId));
        }

        #endregion Validations
    }

    #endregion Handler
}