// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    /// <summary>
    /// Class representing an object that could be either read from the <see cref="IFunctionDataCache"/>
    /// if it exists in it or from storage.
    /// If the object was found in the cache, then the <see cref="IsCacheHit"/> property will be set to
    /// true and the object can be read from shared memory using the <see cref="CacheObject"/> property.
    /// Otherwise, the object can be read from storage using the <see cref="BlobStream"/> property.
    /// </summary>
    internal class CacheableReadBlob : ICacheAwareReadObject
    {
#pragma warning disable CA2213 // Disposable fields should be disposed
        /// <summary>
        /// Cache in which to put this object when required.
        /// </summary>
        private readonly IFunctionDataCache _functionDataCache;
#pragma warning restore CA2213 // Disposable fields should be disposed

        /// <summary>
        /// Indicates if this object has been disposed
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        /// Indicates if the reference count of this object was incremented when it was written into the cache and that it should be
        /// decremented upon disposing this object.
        /// </summary>
        private bool _decrementRefCountInCacheOnDispose;

        /// <summary>
        /// Used when the object was found in the cache.
        /// </summary>
        /// <param name="cacheKey">Key associated to this object to address it in the <see cref="IFunctionDataCache"/>.</param>
        /// <param name="cacheObject">Desribes the shared memory region containing this object.</param>
        /// <param name="functionDataCache">Cache in which to put this object when required.</param>
        public CacheableReadBlob(FunctionDataCacheKey cacheKey, SharedMemoryMetadata cacheObject, IFunctionDataCache functionDataCache)
        {
            IsCacheHit = true;
            CacheKey = cacheKey;
            CacheObject = cacheObject;
            _functionDataCache = functionDataCache;
            _isDisposed = false;
            _decrementRefCountInCacheOnDispose = true;
        }

        /// <summary>
        /// Used when the object was not found in the cache and will be retrieved from storage.
        /// </summary>
        /// <param name="cacheKey">Key associated to this object to address it in the <see cref="IFunctionDataCache"/>.</param>
        /// <param name="blobStream">Stream to use for writing this object to storage.</param>
        /// <param name="functionDataCache">Cache in which to put this object when required.</param>
        public CacheableReadBlob(FunctionDataCacheKey cacheKey, Stream blobStream, IFunctionDataCache functionDataCache)
        {
            IsCacheHit = false;
            CacheKey = cacheKey;
            BlobStream = blobStream;
            _functionDataCache = functionDataCache;
            _isDisposed = false;
            _decrementRefCountInCacheOnDispose = false;
        }

        /// <summary>
        /// Gets or sets a value indicating if the object was found from the <see cref="IFunctionDataCache"/> or not.
        /// </summary>
        public bool IsCacheHit { get; private set; }

        /// <summary>
        /// Gets or sets the unique key for this object used to address it in the <see cref="IFunctionDataCache"/>.
        /// </summary>
        public FunctionDataCacheKey CacheKey { get; private set; }

        /// <summary>
        /// Gets or sets the details about where this object can be read from in shared memory if it was present in <see cref="IFunctionDataCache"/>.
        /// </summary>
        public SharedMemoryMetadata CacheObject { get; private set; }

        /// <summary>
        /// Gets or sets the Stream using which this object can be read from storage if it was not present in <see cref="IFunctionDataCache"/>.
        /// </summary>
        public Stream BlobStream { get; private set; }

        /// <summary>
        /// Put this object in the <see cref="IFunctionDataCache"/>.
        /// </summary>
        /// <param name="cacheObject">Details about the shared memory region where this object exists.</param>
        /// <param name="isIncrementActiveReference">If true, increases the reference counter for this object in the
        /// <see cref="IFunctionDataCache"/>.</param>
        /// <returns>True if the object was successfully put into the cache, false otherwise.</returns>
        public bool TryPutToCache(SharedMemoryMetadata cacheObject, bool isIncrementActiveReference)
        {
            if (IsCacheHit)
            {
                // The object is already cached
                return false;
            }

            if (!_functionDataCache.TryPut(CacheKey, cacheObject, isIncrementActiveReference: isIncrementActiveReference, isDeleteOnFailure: false))
            {
                return false;
            }

            // If the ref-count was increased in the cache when adding, it needs to be decremented when this object is disposed
            _decrementRefCountInCacheOnDispose = isIncrementActiveReference;

            return true;
        }

        /// <summary>
        /// Disposes the resources associated with this object as appropriate.
        /// If the object was read from the cache, it will decrement the reference counter if appropriate.
        /// If the object was read from storage, it will dispose the associated Stream.
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