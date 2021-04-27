// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    /// <summary>
    /// TODO.
    /// </summary>
    internal class CacheObjectOrBlobStream : ICacheAwareReadObject
    {
#pragma warning disable CA2213 // Disposable fields should be disposed
        private readonly IFunctionDataCache _functionDataCache;
#pragma warning restore CA2213 // Disposable fields should be disposed

        // Indicates if this object has been disposed
        private bool _isDisposed;

        private bool _decrementRefCountInCacheOnDispose;

        /// <summary>
        /// Used when the object was found in the cache.
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheObject"></param>
        /// <param name="functionDataCache"></param>
        public CacheObjectOrBlobStream(FunctionDataCacheKey cacheKey, SharedMemoryMetadata cacheObject, IFunctionDataCache functionDataCache)
        {
            IsCacheHit = true;
            CacheKey = cacheKey;
            CacheObject = cacheObject;
            _functionDataCache = functionDataCache;
            _isDisposed = false;
            _decrementRefCountInCacheOnDispose = true;
        }

        /// <summary>
        /// Used when the object was not found in the cache and will be fetched from storage.
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="blobStream"></param>
        /// <param name="functionDataCache"></param>
        public CacheObjectOrBlobStream(FunctionDataCacheKey cacheKey, Stream blobStream, IFunctionDataCache functionDataCache)
        {
            IsCacheHit = false;
            CacheKey = cacheKey;
            BlobStream = blobStream;
            _functionDataCache = functionDataCache;
            _isDisposed = false;
            _decrementRefCountInCacheOnDispose = false;
        }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public bool IsCacheHit { get; private set; }

        // TODO make below three private variables?
        /// <summary>
        /// Gets or sets.
        /// </summary>
        public FunctionDataCacheKey CacheKey { get; private set; }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public SharedMemoryMetadata CacheObject { get; private set; }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public Stream BlobStream { get; private set; }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="cacheObject"></param>
        /// <param name="isIncrementActiveReference"></param>
        /// <returns></returns>
        public bool TryPutToCache(SharedMemoryMetadata cacheObject, bool isIncrementActiveReference)
        {
            if (!_functionDataCache.TryPut(CacheKey, cacheObject, isIncrementActiveReference: isIncrementActiveReference, isDeleteOnFailure: false))
            {
                return false;
            }

            // If the ref-count was increased in the cache when adding, it needs to be decremented when this object is disposed
            _decrementRefCountInCacheOnDispose = isIncrementActiveReference;

            return true;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            // If the object was not retrieved from the cache, then we have a BlobStream open pointing to storage which needs to be disposed
            if (!IsCacheHit)
            {
                BlobStream.Dispose();
            }

            if (_decrementRefCountInCacheOnDispose)
            {
                _functionDataCache.DecrementActiveReference(CacheKey);
            }

            _isDisposed = true;
        }
    }
}