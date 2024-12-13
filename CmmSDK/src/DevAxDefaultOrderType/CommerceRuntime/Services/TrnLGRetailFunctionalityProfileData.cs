using DevAxDefaultOrderType.CommerceRuntime.Entities;
using Microsoft.Dynamics.Commerce.Runtime;
using Microsoft.Dynamics.Commerce.Runtime.Data;
using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using System.Linq;
using System.Threading.Tasks;

namespace DevAxDefaultOrderType.CommerceRuntime.Services
{
    #region Data

    public static class TrnLGRetailFunctionalityProfileData
    {
        #region Constantes

        private const string ext = "ext";
        private const string TrnLGRetailFunctionalityProfile = "TRNLGRETAILFUNCTIONALITYPROFILE";
        private const string profileIdarg = "profileId";
        private const string profileIdParam = "@profileId";

        #endregion Constantes

        public static async Task<TrnLGRetailFunctionalityProfile> GetProfileAsync(RequestContext request, string profileId)
        {
            using (DatabaseContext databaseContext = new DatabaseContext(request))
            {
                SqlPagedQuery queryToDB = new SqlPagedQuery(new QueryResultSettings(PagingInfo.AllRecords))
                {
                    DatabaseSchema = ext,
                    From = TrnLGRetailFunctionalityProfile,
                    Where = $"{profileIdarg} = {profileIdParam}",
                };

                queryToDB.Parameters[profileIdParam] = profileId;

                PagedResult<TrnLGRetailFunctionalityProfile> getDataFromDB =
                    await databaseContext.ReadEntityAsync<TrnLGRetailFunctionalityProfile>(queryToDB).ConfigureAwait(false);

                return getDataFromDB.Results.FirstOrDefault();
            }
        }
    }

    #endregion Data
}