using Microsoft.Dynamics.Commerce.Runtime;
using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using Microsoft.Dynamics.Commerce.Runtime.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DevAx.CommerceRuntime.DocumentBranding.Messages;
using Microsoft.Dynamics.Commerce.Runtime.DataAccess.SqlServer;

namespace DevAx.CommerceRuntime.DocumentBranding.DataService
{
    public class BrandImageDataService : SingleAsyncRequestHandler<GetBrandImageDataRequest>
    {
        protected override async Task<Response> Process(GetBrandImageDataRequest request)
        {
            return await this.GetBrandImageAsync((GetBrandImageDataRequest)request).ConfigureAwait(false);
        }

        private async Task<Response> GetBrandImageAsync(GetBrandImageDataRequest request)
        {
            ThrowIf.Null(request, "request");
            byte[] image;

            using (var databaseContext = new SqlServerDatabaseContext(request.RequestContext))
            {
                QueryResultSettings queryResultSettings = new QueryResultSettings(PagingInfo.AllRecords);

                ParameterSet parameters = new ParameterSet();
                parameters["@brandId"] = request.BrandId;
                parameters["@imageNumber"] = request.ImageNumber;

                var result = await databaseContext.ExecuteStoredProcedureAsync<DocumentBranding.Entities.SysDocuBrandImages>(
                    "ext.DEVAXGETDOCUBRANDIMAGES", parameters, queryResultSettings).ConfigureAwait(false);

                image = result.Item2.Results[0].Image;

                return new GetBrandImageDataResponse(image);
            }
        }
    }
}