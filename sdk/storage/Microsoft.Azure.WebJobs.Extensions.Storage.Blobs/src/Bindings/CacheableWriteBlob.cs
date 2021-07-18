// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    /// <summary>
    /// Class representing an object that exists in shared memory.
    /// This object needs to be persisted to storage using the associated Stream.
    /// Once it is persisted, it needs to be inserted into the <see cref="IFunctionDataCache"/>.
    /// </summary>
    internal class CacheableWriteBlob : ICacheAwareWriteObject
    {
        /// <summary>
        /// Cache in which to put this object when required.
        /// </summary>
        private readonly IFunctionDataCache _functionDataCache;

        /// <summary>
        /// Blob for this object in storage.
        /// </summary>
        private readonly BlobWithContainer<BlobBaseClient> _blob;

        /// <summary>
        /// Desribes the shared memory region containing this object.
        /// </summary>
        private readonly SharedMemoryMetadata _cacheObject;

        /// <summary>
        /// </summary>
        /// <param name="blob">Blob for this object in storage.</param>
        /// <param name="cacheObject">Desribes the shared memory region containing this object.</param>
        /// <param name="blobStream">Stream to use for writing this object to storage.</param>
        /// <param name="functionDataCache">Cache in which to put this object when required.</param>
        public CacheableWriteBlob(BlobWithContainer<BlobBaseClient> blob, SharedMemoryMetadata cacheObject, Stream blobStream, IFunctionDataCache functionDataCache)
        {
            _cacheObject = cacheObject;
            _functionDataCache = functionDataCache;
            _blob = blob;
            BlobStream = blobStream;
        }

        /// <summary>
        /// Gets or sets the Stream associated to this object using which it will be written to storage.
        /// </summary>
        public Stream BlobStream { get; private set; }

        /// <summary>
        /// Put this object in the <see cref="IFunctionDataCache"/>.
        /// </summary>
        /// <param name="isDeleteOnFailure">If true, in the case of failure when adding to the cache, delete the object from shared memory
        /// which is being added. If false, in the case of failure the object is not deleted from shared memory.</param>
        /// <returns>True if the object was successfully put into the cache, false otherwise.</returns>
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
            if (properties == null)
            {
                return false;
            }

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
