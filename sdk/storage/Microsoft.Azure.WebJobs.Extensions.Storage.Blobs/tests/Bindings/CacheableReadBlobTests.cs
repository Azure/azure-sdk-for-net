// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings;
using Moq;
using NUnit.Framework;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    public class CacheableReadBlobTests
    {
        /// <summary>
        /// Create a <see cref="CacheableReadBlob"/> with a valid <see cref="SharedMemoryMetadata"/>
        /// which represents the object being present in shared memory.
        /// Validate that this is considered a cache hit.
        /// </summary>
        [Test]
        public void CreateCacheableReadBlob_IsCacheHit()
        {
            // Arrange
            FunctionDataCacheKey key = CreateFunctionDataCacheKey();
            Mock<IFunctionDataCache> cacheMock = CreateMockFunctionDataCache();
            IFunctionDataCache cache = cacheMock.Object;
            Mock<SharedMemoryMetadata> sharedMemMetaMock = CreateMockSharedMemoryMetadata();
            SharedMemoryMetadata sharedMemMeta = sharedMemMetaMock.Object;
            CacheableReadBlob cacheableReadBlob = CreateProductUnderTest(key, sharedMemMeta, cache);

            // Act
            bool isCacheHit = cacheableReadBlob.IsCacheHit;

            // Assert
            Assert.True(isCacheHit);
        }

        /// <summary>
        /// Create a <see cref="CacheableReadBlob"/> with a valid <see cref="Stream"/>
        /// which represents the object being read from storage.
        /// Validate that this is considered a cache miss, since no <see cref="SharedMemoryMetadata"/>
        /// was provided to read the object from shared memory.
        /// </summary>
        [Test]
        public void CreateCacheableReadBlob_IsCacheMiss()
        {
            // Arrange
            FunctionDataCacheKey key = CreateFunctionDataCacheKey();
            Mock<IFunctionDataCache> cacheMock = CreateMockFunctionDataCache();
            IFunctionDataCache cache = cacheMock.Object;
            Mock<Stream> blobStreamMock = CreateMockBlobStream();
            Stream blobStream = blobStreamMock.Object;
            CacheableReadBlob cacheableReadBlob = CreateProductUnderTest(key, blobStream, cache);

            // Act
            bool isCacheHit = cacheableReadBlob.IsCacheHit;

            // Assert
            Assert.False(isCacheHit);
        }

        /// <summary>
        /// Verify that <see cref="CacheableReadBlob.TryPutToCache"/> returns appropriate value
        /// depending on the output of <see cref="IFunctionDataCache.TryPut"/>.
        /// </summary>
        /// <param name="expected">Output of <see cref="IFunctionDataCache.TryPut"/></param>
        [TestCase(false)]
        [TestCase(true)]
        public void TryPutToCache_VerifySuccess(bool expected)
        {
            // Arrange
            FunctionDataCacheKey key = CreateFunctionDataCacheKey();
            bool isIncrementActiveRefs = true;
            Mock<SharedMemoryMetadata> sharedMemMetaMock = CreateMockSharedMemoryMetadata();
            SharedMemoryMetadata sharedMemMeta = sharedMemMetaMock.Object;
            Mock<IFunctionDataCache> cacheMock = CreateMockFunctionDataCache();
            cacheMock
                .Setup(c => c.TryPut(key, sharedMemMeta, isIncrementActiveRefs, false))
                .Returns(expected)
                .Verifiable();
            IFunctionDataCache cache = cacheMock.Object;
            Mock<Stream> blobStreamMock = CreateMockBlobStream();
            Stream blobStream = blobStreamMock.Object;
            CacheableReadBlob cacheableReadBlob = CreateProductUnderTest(key, blobStream, cache);

            // Act
            bool result = cacheableReadBlob.TryPutToCache(sharedMemMeta, isIncrementActiveRefs);

            // Assert
            Assert.AreEqual(expected, result);
            cacheMock.Verify();
        }

        /// <summary>
        /// Try to call <see cref="CacheableReadBlob.TryPutToCache"/> on an already cached object.
        /// Verify this results in a failure.
        /// </summary>
        [Test]
        public void TryPutToCacheAlreadyCached_VerifyFailure()
        {
            // Arrange
            FunctionDataCacheKey key = CreateFunctionDataCacheKey();
            bool isIncrementActiveRefs = true;
            Mock<IFunctionDataCache> cacheMock = CreateMockFunctionDataCache();
            cacheMock
                .Setup(c => c.TryPut(key, It.IsAny<SharedMemoryMetadata>(), isIncrementActiveRefs, false))
                .Throws(new Exception("This should not be called"));
            IFunctionDataCache cache = cacheMock.Object;
            Mock<SharedMemoryMetadata> sharedMemMetaMock = CreateMockSharedMemoryMetadata();
            SharedMemoryMetadata sharedMemMeta = sharedMemMetaMock.Object;
            CacheableReadBlob cacheableReadBlob = CreateProductUnderTest(key, sharedMemMeta, cache);

            // Act
            bool result = cacheableReadBlob.TryPutToCache(sharedMemMeta, isIncrementActiveRefs);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Verify that the reference count of the object is decremented from the <see cref="IFunctionDataCache"/>
        /// when <see cref="CacheableReadBlob"/> is disposed (in the cache the object was a cache hit).
        /// </summary>
        [Test]
        public void CacheHit_Dispose_VerifyCacheRefCountDecremented()
        {
            // Arrange
            FunctionDataCacheKey key = CreateFunctionDataCacheKey();
            Mock<SharedMemoryMetadata> sharedMemMetaMock = CreateMockSharedMemoryMetadata();
            SharedMemoryMetadata sharedMemMeta = sharedMemMetaMock.Object;
            Mock<IFunctionDataCache> cacheMock = CreateMockFunctionDataCache();
            cacheMock
                .Setup(c => c.DecrementActiveReference(key))
                .Verifiable();
            IFunctionDataCache cache = cacheMock.Object;
            CacheableReadBlob cacheableReadBlob = CreateProductUnderTest(key, sharedMemMeta, cache);

            // Act
            cacheableReadBlob.Dispose();

            // Assert
            // This will ensure that the appropriate method was called on the cache
            cacheMock.Verify();
        }

        /// <summary>
        /// Verify that the <see cref="Stream"/> referring to the blob in storage is closed and disposed
        /// when <see cref="CacheableReadBlob"/> is disposed (in the cache the object was a cache miss).
        /// </summary>
        [Test]
        public void CacheMiss_Dispose_VerifyBlobStreamDisposed()
        {
            // Arrange
            FunctionDataCacheKey key = CreateFunctionDataCacheKey();
            Mock<IFunctionDataCache> cacheMock = CreateMockFunctionDataCache();
            IFunctionDataCache cache = cacheMock.Object;
            Mock<SharedMemoryMetadata> sharedMemMetaMock = CreateMockSharedMemoryMetadata();
            SharedMemoryMetadata sharedMemMeta = sharedMemMetaMock.Object;
            Mock<Stream> blobStreamMock = CreateMockBlobStream();
            blobStreamMock
                .Setup(s => s.Close()) // Close is called internally when Stream is Disposed
                .Verifiable();
            Stream blobStream = blobStreamMock.Object;
            CacheableReadBlob cacheableReadBlob = CreateProductUnderTest(key, blobStream, cache);

            // Act
            cacheableReadBlob.Dispose();

            // Assert
            // This will ensure that the appropriate method was called on the stream
            blobStreamMock.Verify();
        }

        /// <summary>
        /// Verify that the reference count of the object is NOT decremented from the <see cref="IFunctionDataCache"/>
        /// when <see cref="CacheableReadBlob"/> is disposed (in the cache the object was a cache miss).
        /// </summary>
        [Test]
        public void CacheMiss_Dispose_VerifyCacheRefCountNotDecremented()
        {
            // Arrange
            FunctionDataCacheKey key = CreateFunctionDataCacheKey();
            Mock<IFunctionDataCache> cacheMock = CreateMockFunctionDataCache();
            cacheMock
                .Setup(c => c.DecrementActiveReference(key))
                .Throws(new Exception("This should not be called"));
            IFunctionDataCache cache = cacheMock.Object;
            Mock<Stream> blobStreamMock = CreateMockBlobStream();
            blobStreamMock
                .Setup(s => s.Close())
                .Verifiable();
            Stream blobStream = blobStreamMock.Object;
            CacheableReadBlob cacheableReadBlob = CreateProductUnderTest(key, blobStream, cache);

            // Act
            cacheableReadBlob.Dispose();

            // Assert
            // If the wrong method was called, an exception would have been thrown
        }

        /// <summary>
        /// Create a mock <see cref="IFunctionDataCache"/>.
        /// </summary>
        /// <returns>Mock <see cref="IFunctionDataCache"/>.</returns>
        private static Mock<IFunctionDataCache> CreateMockFunctionDataCache()
        {
            return new Mock<IFunctionDataCache>(MockBehavior.Strict);
        }

        /// <summary>
        /// Create a <see cref="FunctionDataCacheKey"/> to use in a test.
        /// </summary>
        /// <returns>A <see cref="FunctionDataCacheKey"/> to use in a test.</returns>
        private static FunctionDataCacheKey CreateFunctionDataCacheKey()
        {
            return new FunctionDataCacheKey("foo", "0x1");
        }

        /// <summary>
        /// Create a mock <see cref="Stream"/>.
        /// </summary>
        /// <returns>Mock <see cref="Stream"/>.</returns>
        private static Mock<Stream> CreateMockBlobStream()
        {
            return new Mock<Stream>(MockBehavior.Strict);
        }

        /// <summary>
        /// Create a mock <see cref="SharedMemoryMetadata"/> describing a fake shared memory region.
        /// </summary>
        /// <returns>Mock <see cref="SharedMemoryMetadata"/>.</returns>
        private static Mock<SharedMemoryMetadata> CreateMockSharedMemoryMetadata()
        {
            return new Mock<SharedMemoryMetadata>(MockBehavior.Strict, "mockname", 10);
        }

        /// <summary>
        /// Create a <see cref="CacheableReadBlob"/> to use for a test.
        /// </summary>
        /// <param name="cacheKey">Key associated to this object to address it in the <see cref="IFunctionDataCache"/>.</param>
        /// <param name="blobStream">Stream to use for writing this object to storage.</param>
        /// <param name="functionDataCache">Cache in which to put this object when required.</param>
        /// <returns>A <see cref="CacheableReadBlob"/> object to use for a test.</returns>
        private static CacheableReadBlob CreateProductUnderTest(FunctionDataCacheKey cacheKey, Stream blobStream, IFunctionDataCache functionDataCache)
        {
            return new CacheableReadBlob(cacheKey, blobStream, functionDataCache);
        }

        /// <summary>
        /// Create a <see cref="CacheableReadBlob"/> to use for a test.
        /// </summary>
        /// <param name="cacheKey">Key associated to this object to address it in the <see cref="IFunctionDataCache"/>.</param>
        /// <param name="blobStream">Stream to use for writing this object to storage.</param>
        /// <param name="functionDataCache">Cache in which to put this object when required.</param>
        /// <returns>A <see cref="CacheableReadBlob"/> object to use for a test.</returns>
        private static CacheableReadBlob CreateProductUnderTest(FunctionDataCacheKey cacheKey, SharedMemoryMetadata sharedMemMeta, IFunctionDataCache functionDataCache)
        {
            return new CacheableReadBlob(cacheKey, sharedMemMeta, functionDataCache);
        }
    }
}
