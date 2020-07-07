// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

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

        public async Task<string> GetETagAsync(ICloudBlob blob, CancellationToken cancellationToken)
        {
            try
            {
                await blob.FetchAttributesAsync(cancellationToken);
            }
            catch (StorageException exception)
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

            return blob.Properties.ETag;
        }
    }
}
