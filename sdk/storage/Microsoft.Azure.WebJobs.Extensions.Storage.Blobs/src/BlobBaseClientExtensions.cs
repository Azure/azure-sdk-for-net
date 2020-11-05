// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal static class BlobBaseClientExtensions
    {
        public static async Task<BlobProperties> FetchPropertiesOrNullIfNotExistAsync(this BlobBaseClient blob,
            CancellationToken cancellationToken = default)
        {
            if (blob == null)
            {
                throw new ArgumentNullException(nameof(blob));
            }

            try
            {
                BlobProperties blobProperties = await blob.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                return blobProperties;
            }
            catch (RequestFailedException exception)
            {
                // Remember specific error codes are not available for Fetch (HEAD request).

                if (exception.IsNotFound())
                {
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

        public static string GetBlobPath(this BlobBaseClient blob)
        {
            return ToBlobPath(blob).ToString();
        }

        public static BlobPath ToBlobPath(this BlobBaseClient blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException(nameof(blob));
            }

            return new BlobPath(blob.BlobContainerName, blob.Name);
        }
    }
}
