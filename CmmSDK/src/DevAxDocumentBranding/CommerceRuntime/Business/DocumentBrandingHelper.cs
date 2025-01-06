using DevAx.CommerceRuntime.DocumentBranding.Messages;
using Microsoft.Dynamics.Commerce.Runtime;
using System.Threading.Tasks;

namespace DevAx.CommerceRuntime.DocumentBranding.Business
{
    public class DocumentBrandingHelper
    {
        public static async Task<byte[]> GetInvoiceImageLogoAsync(RequestContext context)
        {
            string brandId = await GetBrandIdFromStore(context, true).ConfigureAwait(false);
            byte[] image = await GetImageFromBrand(context, brandId, 1).ConfigureAwait(false);
            return image;
        }

        public static async Task<byte[]> GetInvoiceImageFooterAsync(RequestContext context)
        {
            string brandId = await GetBrandIdFromStore(context, true).ConfigureAwait(false);
            byte[] image = await GetImageFromBrand(context, brandId, 2).ConfigureAwait(false);
            return image;
        }

        public static async Task<byte[]> GetQuoteImageLogoAsync(RequestContext context)
        {
            string brandId = await GetBrandIdFromStore(context, false).ConfigureAwait(false);
            byte[] image = await GetImageFromBrand(context, brandId, 1).ConfigureAwait(false);
            return image;
        }

        public static async Task<byte[]> GetQuoteImageFooterAsync(RequestContext context)
        {
            string brandId = await GetBrandIdFromStore(context, false).ConfigureAwait(false);
            byte[] image = await GetImageFromBrand(context, brandId, 2).ConfigureAwait(false);
            return image;
        }

        private static async Task<string> GetBrandIdFromStore(RequestContext context, bool isInvoice)
        {
            string brandId = "";
            long channelRecId = context.GetChannel().RecordId;

            GetRetailStoreTableDataRequest requestStore = new GetRetailStoreTableDataRequest(channelRecId);
            GetRetailStoreTableDataResponse responseStore = await context.ExecuteAsync<GetRetailStoreTableDataResponse>(requestStore).ConfigureAwait(false);
            if (isInvoice)
            {
                brandId = responseStore.RetailStoreTable.Results[0].InvoiceImages;
            }
            else
            {
                brandId = responseStore.RetailStoreTable.Results[0].QuoteImages;
            }

            //return await Task.FromResult(brandId).ConfigureAwait(false);
            return brandId;
        }

        private static async Task<byte[]> GetImageFromBrand(RequestContext context, string brandId, int imageNumber)
        {
            byte[] image = System.Array.Empty<byte>();

            if (!brandId.IsNullOrEmpty())
            {
                GetBrandImageDataRequest request = new GetBrandImageDataRequest(brandId, imageNumber);
                GetBrandImageDataResponse response = await context.ExecuteAsync<GetBrandImageDataResponse>(request).ConfigureAwait(false);
                image = response.Image;
            }

            return image;
        }
    }
}