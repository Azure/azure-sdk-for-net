// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal static class ReadBlobArgumentBinding
    {
        public static Task<Stream> TryBindStreamAsync(BlobBaseClient blob, ValueBindingContext context)
        {
            return TryBindStreamAsync(blob, context.CancellationToken);
        }

        public static async Task<Stream> TryBindStreamAsync(BlobWithContainer<BlobBaseClient> blob, ValueBindingContext context, IFunctionDataCache functionDataCache)
        {
            try
            {
                // Generate the cache key for this blob
                FunctionDataCacheKey cacheKey = await GetFunctionDataCacheKey(blob, context.CancellationToken).ConfigureAwait(false);

                // Check if it exists in the cache
                FunctionDataCacheStream cacheStream = TryGetFromFunctionDataCache(cacheKey, functionDataCache);
                if (cacheStream != null)
                {
                    // Cache hit
                    return cacheStream;
                }

                // Cache miss
                // Wrap the blob's stream along with the cache key so it can be inserted in the cache later using the above
                // generated key for this blob.
                Stream innerStream = await TryBindStreamAsync(blob.BlobClient, context.CancellationToken).ConfigureAwait(false);
                CacheableObjectStream cachableObjStream = new CacheableObjectStream(cacheKey, innerStream, functionDataCache);
                return cachableObjStream;
            }
            catch (RequestFailedException exception)
            {
                // Testing generic error case since specific error codes are not available for FetchAttributes
                // (HEAD request), including OpenRead.
                if (!exception.IsNotFound())
                {
                    throw;
                }

                return null;
            }
        }

        public static async Task<Stream> TryBindStreamAsync(BlobBaseClient blob, CancellationToken cancellationToken)
        {
            Stream rawStream;
            try
            {
                rawStream = await blob.OpenReadAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException exception)
            {
                // Testing generic error case since specific error codes are not available for FetchAttributes
                // (HEAD request), including OpenRead.
                if (!exception.IsNotFound())
                {
                    throw;
                }

                return null;
            }

            return rawStream;
        }

        private static async Task<FunctionDataCacheKey> GetFunctionDataCacheKey(BlobWithContainer<BlobBaseClient> blob, CancellationToken cancellationToken)
        {
            // To be strongly consistent, first check the latest version present in blob storage;
            // query for that particular version in the cache.
            BlobProperties properties = await blob.BlobClient.FetchPropertiesOrNullIfNotExistAsync(cancellationToken).ConfigureAwait(false);
            string eTag = properties.ETag.ToString();
            string id = blob.BlobClient.Uri.ToString();
            FunctionDataCacheKey cacheKey = new FunctionDataCacheKey(id, eTag);
            return cacheKey;
        }

        private static FunctionDataCacheStream TryGetFromFunctionDataCache(
            FunctionDataCacheKey cacheKey,
            IFunctionDataCache functionDataCache)
        {
            if (!functionDataCache.TryGet(cacheKey, isIncrementActiveReference: true, out SharedMemoryMetadata sharedMemoryMeta))
            {
                return null;
            }

            return new FunctionDataCacheStream(cacheKey, sharedMemoryMeta, functionDataCache);
        }
    }
}
