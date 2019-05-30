using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Integration.Tests.Extensions
{
    public static class BlobStorageExtensions
    {
        /// <summary>
        /// Gets a list of all the blobs in a blobcontainer
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<IListBlobItem>> ListBlobs(this CloudBlobContainer container, bool useFlatBlobListing = false)
        {
            BlobContinuationToken blobContinuationToken = null;
            var blobs = new List<IListBlobItem>();
            do
            {
                var blobsSegment = await container.ListBlobsSegmentedAsync(null, useFlatBlobListing, BlobListingDetails.All, null, blobContinuationToken, new BlobRequestOptions(), new WindowsAzure.Storage.OperationContext());
                blobContinuationToken = blobsSegment.ContinuationToken;
                foreach (IListBlobItem blobItem in blobsSegment.Results)
                {
                    blobs.Add(blobItem);
                }
            }
            while (blobContinuationToken != null);
            return blobs;
        }
    }
}
