// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    /// <summary>
    /// This type should ideally be not part of extension.
    /// </summary>
    internal class CacheObjectAndBlobStream : ICacheAwareWriteObject
    {
        private readonly IFunctionDataCache _functionDataCache;

        private readonly BlobWithContainer<BlobBaseClient> _blob;

        private readonly SharedMemoryMetadata _cacheObject;

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="blob"></param>
        /// <param name="cacheObject"></param>
        /// <param name="blobStream"></param>
        /// <param name="functionDataCache"></param>
        public CacheObjectAndBlobStream(BlobWithContainer<BlobBaseClient> blob, SharedMemoryMetadata cacheObject, Stream blobStream, IFunctionDataCache functionDataCache)
        {
            _cacheObject = cacheObject;
            _functionDataCache = functionDataCache;
            _blob = blob;
            BlobStream = blobStream;
        }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public Stream BlobStream { get; private set; }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="isDeleteOnFailure"></param>
        /// <returns></returns>
        public async Task<bool> TryPutToCacheAsync(bool isDeleteOnFailure)
        {
            if (_cacheObject == null)
            {
                return false;
            }

            // TODO this could have a race condition - we may have called Dispose on BlobStream earlier which may have
            // generated an eTag but another operation on the blob may have modified that eTag between the Dispose call
            // and this call. How do we ensure we have the final eTag when the BlobStream was disposed/closed?
            BlobProperties properties = await _blob.BlobClient.FetchPropertiesOrNullIfNotExistAsync().ConfigureAwait(false);
            return TryPutToFunctionDataCacheCore(properties, isDeleteOnFailure);
        }

        /// <summary>
        /// Put the object into the cache by generating a key for the object based on the blob's properties.
        /// </summary>
        /// <param name="properties">Properties of the blob corresponding to the object being written.</param>
        /// <param name="isDeleteOnFailure">If True, in the case where the cache is unable to insert this object, the local resources pointed to by the Stream (which were to be cached) will be deleted.</param>
        /// <returns>True if the object was written to the <see cref="IFunctionDataCache"/>, false otherwise.</returns>
        private bool TryPutToFunctionDataCacheCore(BlobProperties properties, bool isDeleteOnFailure)
        {
            string eTag = properties.ETag.ToString();
            string id = _blob.BlobClient.Uri.ToString();
            FunctionDataCacheKey cacheKey = new FunctionDataCacheKey(id, eTag);
            return _functionDataCache.TryPut(cacheKey, _cacheObject, isIncrementActiveReference: false, isDeleteOnFailure);
        }
    }
}
