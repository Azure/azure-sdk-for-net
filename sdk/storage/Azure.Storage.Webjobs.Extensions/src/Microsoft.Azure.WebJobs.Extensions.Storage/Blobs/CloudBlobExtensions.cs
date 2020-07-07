// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
    internal static class CloudBlobExtensions
    {
        public static async Task<bool> TryFetchAttributesAsync(this ICloudBlob blob,
            CancellationToken cancellationToken)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob");
            }

            try
            {
                await blob.FetchAttributesAsync();
                return true;
            }
            catch (StorageException exception)
            {
                // Remember specific error codes are not available for Fetch (HEAD request).

                if (exception.IsNotFound())
                {
                    return false;
                }
                else if (exception.IsOk())
                {
                    // If the blob type is incorrect (block vs. page) a 200 OK is returned but the SDK throws an
                    // exception.
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
