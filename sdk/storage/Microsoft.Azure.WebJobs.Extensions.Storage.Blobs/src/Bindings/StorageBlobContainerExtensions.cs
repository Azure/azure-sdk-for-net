// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    internal static class StorageBlobContainerExtensions
    {
        public static Task<BlobBaseClient> GetBlobReferenceForArgumentTypeAsync(this BlobContainerClient container,
            string blobName, Type argumentType, CancellationToken cancellationToken)
        {
            if (argumentType == typeof(BlobClient))
            {
                BlobBaseClient blob = container.GetBlobClient(blobName);
                return Task.FromResult(blob);
            }
            else if (argumentType == typeof(BlockBlobClient))
            {
                BlobBaseClient blob = container.GetBlockBlobClient(blobName);
                return Task.FromResult(blob);
            }
            else if (argumentType == typeof(PageBlobClient))
            {
                BlobBaseClient blob = container.GetPageBlobClient(blobName);
                return Task.FromResult(blob);
            }
            else if (argumentType == typeof(AppendBlobClient))
            {
                BlobBaseClient blob = container.GetAppendBlobClient(blobName);
                return Task.FromResult(blob);
            }
            else
            {
                return GetExistingOrNewBlockBlobReferenceAsync(container, blobName, cancellationToken);
            }
        }

        public static async Task<(BlobBaseClient Client, BlobProperties Properties)> GetBlobReferenceFromServerAsync(this BlobContainerClient container, string blobName, CancellationToken cancellationToken = default)
        {
            BlobProperties blobProperties = await container.GetBlobClient(blobName).GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            switch (blobProperties.BlobType)
            {
                case BlobType.Append:
                    return (container.GetAppendBlobClient(blobName), blobProperties);
                case BlobType.Block:
                    return (container.GetBlockBlobClient(blobName), blobProperties);
                case BlobType.Page:
                    return (container.GetPageBlobClient(blobName), blobProperties);
                default:
                    throw new InvalidOperationException();
            }
        }

        private static async Task<BlobBaseClient> GetExistingOrNewBlockBlobReferenceAsync(BlobContainerClient container,
            string blobName, CancellationToken cancellationToken)
        {
            try
            {
                return (await container.GetBlobReferenceFromServerAsync(blobName, cancellationToken).ConfigureAwait(false)).Client;
            }
            catch (RequestFailedException exception)
            {
                if (exception.Status != 404)
                {
                    throw;
                }
                else
                {
                    return container.GetBlockBlobClient(blobName);
                }
            }
        }
    }
}
