// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests.Bindings
{
    public class CacheableWriteBlobTests
    {
        private const string ContainerName = "container-cacheablewriteblobtests";

        private BlobServiceClient _blobServiceClient;

        [SetUp]
        public void SetUp()
        {
            _blobServiceClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient();
            _blobServiceClient.GetBlobContainerClient(ContainerName).DeleteIfExists();
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task TryPutToCache_VerifyResultMatchesResultOfCacheOperation(bool expected)
        {
            // Arrange
            Mock<SharedMemoryMetadata> sharedMemMetaMock = CreateMockSharedMemoryMetadata();
            SharedMemoryMetadata sharedMemMeta = sharedMemMetaMock.Object;
            bool isIncrementActiveRefs = false;
            bool isDeleteOnFailure = false;
            Mock<IFunctionDataCache> cacheMock = CreateMockFunctionDataCache();
            cacheMock
                .Setup(c => c.TryPut(It.IsAny<FunctionDataCacheKey>(), sharedMemMeta, isIncrementActiveRefs, isDeleteOnFailure))
                .Returns(expected)
                .Verifiable();
            IFunctionDataCache cache = cacheMock.Object;
            BlobWithContainer<BlobBaseClient> blob = CreateBlobReference(ContainerName, "blob");
            Mock<Stream> mockBlobStream = CreateMockBlobStream();
            Stream blobStream = mockBlobStream.Object;
            CacheableWriteBlob cacheableWriteBlob = CreateProductUnderTest(blob, sharedMemMeta, blobStream, cache);

            // Act
            bool result = await cacheableWriteBlob.TryPutToCacheAsync(isDeleteOnFailure);

            // Assert
            Assert.AreEqual(expected, result);
            cacheMock.Verify();
        }

        [Test]
        public async Task TryPutToCache_CacheObjectNull_VerifyFailure()
        {
            // Arrange
            bool isIncrementActiveRefs = false;
            bool isDeleteOnFailure = false;
            Mock<IFunctionDataCache> cacheMock = CreateMockFunctionDataCache();
            cacheMock
                .Setup(c => c.TryPut(It.IsAny<FunctionDataCacheKey>(), It.IsAny<SharedMemoryMetadata>(), isIncrementActiveRefs, isDeleteOnFailure))
                .Throws(new Exception("This should not be called"));
            IFunctionDataCache cache = cacheMock.Object;
            BlobWithContainer<BlobBaseClient> blob = CreateBlobReference(ContainerName, "blob");
            Mock<Stream> mockBlobStream = CreateMockBlobStream();
            Stream blobStream = mockBlobStream.Object;
            CacheableWriteBlob cacheableWriteBlob = CreateProductUnderTest(blob, null, blobStream, cache);

            // Act
            bool result = await cacheableWriteBlob.TryPutToCacheAsync(isDeleteOnFailure);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task TryPutToCache_BlobPropertiesNotFound_VerifyFailure()
        {
            // Arrange
            Mock<SharedMemoryMetadata> sharedMemMetaMock = CreateMockSharedMemoryMetadata();
            SharedMemoryMetadata sharedMemMeta = sharedMemMetaMock.Object;
            bool isIncrementActiveRefs = false;
            bool isDeleteOnFailure = false;
            Mock<IFunctionDataCache> cacheMock = CreateMockFunctionDataCache();
            cacheMock
                .Setup(c => c.TryPut(It.IsAny<FunctionDataCacheKey>(), sharedMemMeta, isIncrementActiveRefs, isDeleteOnFailure))
                .Throws(new Exception("This should not be called"));
            IFunctionDataCache cache = cacheMock.Object;
            BlobWithContainer<BlobBaseClient> blob = CreateBlobReference(ContainerName, "blobNotExists", createBlob: false);
            Mock<Stream> mockBlobStream = CreateMockBlobStream();
            Stream blobStream = mockBlobStream.Object;
            CacheableWriteBlob cacheableWriteBlob = CreateProductUnderTest(blob, sharedMemMeta, blobStream, cache);

            // Act
            bool result = await cacheableWriteBlob.TryPutToCacheAsync(isDeleteOnFailure);

            // Assert
            Assert.AreEqual(false, result);
        }

        private BlobWithContainer<BlobBaseClient> CreateBlobReference(string containerName, string blobName, bool createBlob = true)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            container.CreateIfNotExists();
            var blobClient = container.GetBlockBlobClient(blobName);
            if (createBlob)
            {
                byte[] sample = { 0, 100, 200 };
                blobClient.Upload(new MemoryStream(sample));
            }
            return new BlobWithContainer<BlobBaseClient>(container, blobClient);
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

        private static CacheableWriteBlob CreateProductUnderTest(BlobWithContainer<BlobBaseClient> blob, SharedMemoryMetadata cacheObject, Stream blobStream, IFunctionDataCache functionDataCache)
        {
            return new CacheableWriteBlob(blob, cacheObject, blobStream, functionDataCache);
        }
    }
}
