using Microsoft.Dynamics.Commerce.Runtime;
using Microsoft.Dynamics.Commerce.Runtime.Data;
using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using Microsoft.Dynamics.Commerce.Runtime.Messages;
using System.Threading.Tasks;
using DevAx.CommerceRuntime.DocumentBranding.Messages;

namespace DevAx.CommerceRuntime.DocumentBranding.DataService
{
    public class RetailStoreTableDataService : SingleAsyncRequestHandler<GetRetailStoreTableDataRequest>
    {
        protected override async Task<Response> Process(GetRetailStoreTableDataRequest request)
        {
            return await this.GetRetailStoreTableAsync((GetRetailStoreTableDataRequest)request).ConfigureAwait(false);
        }

        private async Task<Response> GetRetailStoreTableAsync(GetRetailStoreTableDataRequest request)
        {
            ThrowIf.Null(request, "request");

            using (DatabaseContext databaseContext = new DatabaseContext(request.RequestContext))
            {
                var query = new SqlPagedQuery(QueryResultSettings.SingleRecord)
                {
                    DatabaseSchema = "ext",
                    Select = new ColumnSet("DEVAXINVOICEIMAGES", "DEVAXQUOTEIMAGES"),
                    From = "DevAxRetailStoreTableRptImages",
                    Where = "RecId = @channelRecId"
                };

                query.Parameters["@channelRecId"] = request.ChannelRecId;

                return new GetRetailStoreTableDataResponse(await databaseContext.ReadEntityAsync<DocumentBranding.Entities.RetailStoreTable>(query).ConfigureAwait(false));
            }
        }
    }
}