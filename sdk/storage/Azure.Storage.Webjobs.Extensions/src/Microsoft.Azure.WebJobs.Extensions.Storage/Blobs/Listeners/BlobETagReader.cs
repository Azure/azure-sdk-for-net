// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class BlobETagReader : IBlobETagReader
    {
        private static readonly BlobETagReader Singleton = new BlobETagReader();

        private BlobETagReader()
        {
        }

        public static BlobETagReader Instance
        {
            get { return Singleton; }
        }

        public async Task<string> GetETagAsync(BlobBaseClient blob, CancellationToken cancellationToken)
        {
            try
            {
                BlobProperties blobProperties = await blob.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                return blobProperties.ETag.ToString();
            }
            catch (RequestFailedException exception)
            {
                // Note that specific exception codes are not available for FetchAttributes, which makes a HEAD request.

                if (exception.IsNotFound())
                {
                    // Blob does not exist.
                    return null;
                }
                else if (exception.IsOk())
                {
                    // If the blob type is incorrect (block vs. page) a 200 OK is returned but the SDK throws an
                    // exception.
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
