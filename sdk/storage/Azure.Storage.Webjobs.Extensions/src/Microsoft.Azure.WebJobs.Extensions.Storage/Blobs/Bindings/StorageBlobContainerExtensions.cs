// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Bindings
{
    internal static class StorageBlobContainerExtensions
    {
        public static Task<ICloudBlob> GetBlobReferenceForArgumentTypeAsync(this CloudBlobContainer container,
            string blobName, Type argumentType, CancellationToken cancellationToken)
        {
            if (argumentType == typeof(CloudBlockBlob))
            {
                ICloudBlob blob = container.GetBlockBlobReference(blobName);
                return Task.FromResult(blob);
            }
            else if (argumentType == typeof(CloudPageBlob))
            {
                ICloudBlob blob = container.GetPageBlobReference(blobName);
                return Task.FromResult(blob);
            }
            else if (argumentType == typeof(CloudAppendBlob))
            {
                ICloudBlob blob = container.GetAppendBlobReference(blobName);
                return Task.FromResult(blob);
            }
            else
            {
                return GetExistingOrNewBlockBlobReferenceAsync(container, blobName, cancellationToken);
            }
        }

        private static async Task<ICloudBlob> GetExistingOrNewBlockBlobReferenceAsync(CloudBlobContainer container,
            string blobName, CancellationToken cancellationToken)
        {
            try
            {
                return await container.GetBlobReferenceFromServerAsync(blobName, cancellationToken).ConfigureAwait(false);
            }
            catch (StorageException exception)
            {
                RequestResult result = exception.RequestInformation;

                if (result == null || result.HttpStatusCode != 404)
                {
                    throw;
                }
                else
                {
                    return container.GetBlockBlobReference(blobName);
                }
            }
        }
    }
}
