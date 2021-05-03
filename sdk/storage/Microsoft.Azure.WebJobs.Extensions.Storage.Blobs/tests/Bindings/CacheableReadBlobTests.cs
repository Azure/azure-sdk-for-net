// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings;
using Moq;
using NUnit.Framework;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests.Bindings
{
    public class CacheableReadBlobTests
    {
        [Test]
        public void CreateCacheableReadBlob_IsCacheHit()
        {
            // Arrange
            FunctionDataCacheKey key = new FunctionDataCacheKey("foo", "0x1");
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

        [Test]
        public void CreateCacheableReadBlob_IsCacheMiss()
        {
            // Arrange
            FunctionDataCacheKey key = new FunctionDataCacheKey("foo", "0x1");
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

        [TestCase(false)]
        [TestCase(true)]
        public void TryPutToCache_VerifySuccess(bool expected)
        {
            // Arrange
            FunctionDataCacheKey key = new FunctionDataCacheKey("foo", "0x1");
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

        [Test]
        public void TryPutToCacheAlreadyCached_VerifyFailure()
        {
            // Arrange
            FunctionDataCacheKey key = new FunctionDataCacheKey("foo", "0x1");
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
            Assert.AreEqual(false, result);
        }

        [Test]
        public void CacheHit_Dispose_VerifyCacheRefCountDecremented()
        {
            // Arrange
            FunctionDataCacheKey key = new FunctionDataCacheKey("foo", "0x1");
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
            cacheMock.Verify();
        }

        [Test]
        public void CacheMiss_Dispose_VerifyBlobStreamDisposed()
        {
            // Arrange
            FunctionDataCacheKey key = new FunctionDataCacheKey("foo", "0x1");
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
            blobStreamMock.Verify();
        }

        [Test]
        public void CacheMiss_Dispose_VerifyCacheRefCountNotDecremented()
        {
            // Arrange
            FunctionDataCacheKey key = new FunctionDataCacheKey("foo", "0x1");
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

        private static Mock<IFunctionDataCache> CreateMockFunctionDataCache()
        {
            return new Mock<IFunctionDataCache>(MockBehavior.Strict);
        }

        private static Mock<Stream> CreateMockBlobStream()
        {
            return new Mock<Stream>(MockBehavior.Strict);
        }

        private static Mock<SharedMemoryMetadata> CreateMockSharedMemoryMetadata()
        {
            return new Mock<SharedMemoryMetadata>(MockBehavior.Strict, "mockname", 10);
        }

        private static CacheableReadBlob CreateProductUnderTest(FunctionDataCacheKey key, Stream stream, IFunctionDataCache cache)
        {
            return new CacheableReadBlob(key, stream, cache);
        }

        private static CacheableReadBlob CreateProductUnderTest(FunctionDataCacheKey key, SharedMemoryMetadata sharedMemMeta, IFunctionDataCache cache)
        {
            return new CacheableReadBlob(key, sharedMemMeta, cache);
        }
    }
}
