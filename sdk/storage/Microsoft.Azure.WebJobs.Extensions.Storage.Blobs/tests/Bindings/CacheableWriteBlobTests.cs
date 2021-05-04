// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
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

        /// <summary>
        /// Verify that <see cref="CacheableWriteBlob.TryPutToCacheAsync"/> returns appropriate value
        /// depending on the output of <see cref="IFunctionDataCache.TryPut"/>.
        /// </summary>
        /// <param name="expected">Output of <see cref="IFunctionDataCache.TryPut"/></param>
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

        /// <summary>
        /// Verify that <see cref="CacheableWriteBlob.TryPutToCacheAsync"/> returns <see cref="false"/> if
        /// a valid cache object is not passed to it upon creation.
        /// </summary>
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
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Verify that <see cref="CacheableWriteBlob.TryPutToCacheAsync"/> returns <see cref="false"/> if
        /// the appropriate blob's properties are not found (e.g. if the blob does not exist).
        /// </summary>
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
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Get a reference to a blob to be used for the test.
        /// </summary>
        /// <param name="containerName">Name of blob container.</param>
        /// <param name="blobName">Name of blob.</param>
        /// <param name="createBlob">If <see cref="true"/>, the blob will be created if it does not already exist.</param>
        /// <returns>Reference to the blob.</returns>
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

        /// <summary>
        /// Create a mock <see cref="IFunctionDataCache"/>.
        /// </summary>
        /// <returns>Mock <see cref="IFunctionDataCache"/>.</returns>
        private static Mock<IFunctionDataCache> CreateMockFunctionDataCache()
        {
            return new Mock<IFunctionDataCache>(MockBehavior.Strict);
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
        /// Create a <see cref="CacheableWriteBlob"/> to use for a test.
        /// </summary>
        /// <param name="blob">Blob for this object in storage.</param>
        /// <param name="cacheObject">Desribes the shared memory region containing this object.</param>
        /// <param name="blobStream">Stream to use for writing this object to storage.</param>
        /// <param name="functionDataCache">Cache in which to put this object when required.</param>
        /// <returns>A <see cref="CacheableWriteBlob"/> object to use for a test.</returns>
        private static CacheableWriteBlob CreateProductUnderTest(BlobWithContainer<BlobBaseClient> blob, SharedMemoryMetadata cacheObject, Stream blobStream, IFunctionDataCache functionDataCache)
        {
            return new CacheableWriteBlob(blob, cacheObject, blobStream, functionDataCache);
        }
    }
}
