// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.ScenarioTests
{
    public class  CacheableBlobsEndToEndTests : LiveTestBase<WebJobsTestEnvironment>
    {
        private const string TestArtifactPrefix = "e2etestcache";
        private const string ContainerName = TestArtifactPrefix + "-%rnd%";
        private const string OutputContainerName = TestArtifactPrefix + "-out%rnd%";
        private const string TestData = "TestData";
        private static TestFixture _fixture;
        private static int _numCacheHits;
        private static int _numCacheMisses;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            string connectionString = TestEnvironment.PrimaryStorageAccountConnectionString;
            Assert.IsNotEmpty(connectionString);
            _fixture = new TestFixture();
            await _fixture.InitializeAsync(TestEnvironment);
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _fixture.DisposeAsync();
        }

        [SetUp]
        public void SetUp()
        {
            _numCacheHits = 0;
            _numCacheMisses = 0;
            _fixture.CacheMock.Reset();
        }

        [Test]
        public async Task BindToCacheableReadBlob_VerifyCacheMiss()
        {
            bool isIncrementActiveReference = true;
            SharedMemoryMetadata outVal = null;

            // Enable the cache
            _fixture.CacheMock
                .Setup(c => c.IsEnabled)
                .Returns(true);

            // Mock a cache miss
            _fixture.CacheMock
                .Setup(c => c.TryGet(It.IsAny<FunctionDataCacheKey>(), isIncrementActiveReference, out outVal))
                .Returns(false)
                .Verifiable();

            // Invoke the function which will verify that it was a cache miss
            await _fixture.JobHost.CallAsync(typeof(CacheableBlobsEndToEndTests).GetMethod("ByteArrayBindingCacheMissAsync"));

            // Verify that it was a cache miss
            Assert.AreEqual(1, _numCacheMisses);
            Assert.AreEqual(0, _numCacheHits);
            // Verify that TryGet was called on the cache
            _fixture.CacheMock.Verify();
        }

        [Test]
        public async Task BindToCacheableReadBlob_VerifyCacheHit()
        {
            bool isIncrementActiveReference = true;

            // Enable the cache
            _fixture.CacheMock
                .Setup(c => c.IsEnabled)
                .Returns(true);

            // Mock the cache hit scenario
            Mock<SharedMemoryMetadata> cacheObjMock = CreateMockSharedMemoryMetadata();
            SharedMemoryMetadata cacheObj = cacheObjMock.Object;

            // This access to the cache should be a cache hit (mocking the case where the first access would
            // have inserted the object into the cache)
            _fixture.CacheMock
                .Setup(c => c.TryGet(It.IsAny<FunctionDataCacheKey>(), isIncrementActiveReference, out cacheObj))
                .Returns(true)
                .Verifiable();
            _fixture.CacheMock
                .Setup(c => c.DecrementActiveReference(It.IsAny<FunctionDataCacheKey>()))
                .Verifiable();

            // Invoke the function which will verify that it was a cache hit
            await _fixture.JobHost.CallAsync(typeof(CacheableBlobsEndToEndTests).GetMethod("ByteArrayBindingCacheHit"));

            // Verify that it was a cache hit
            Assert.AreEqual(1, _numCacheHits);
            Assert.AreEqual(0, _numCacheMisses);
            // Verify that TryGet was called on the cache
            _fixture.CacheMock.Verify();
        }

        [Test]
        public void BindCacheableWriteBlob_VerifyPutToCache()
        {
            // TODO
        }

        [Test]
        public void BindCacheableReadBlob_VerifyFunctionDataCacheKey()
        {
            // TODO
        }

        /// <summary>
        /// This is mocking the case where there was a cache miss.
        /// This function will read the input from remote storage.
        /// </summary>
        [NoAutomaticTrigger]
        public static async Task ByteArrayBindingCacheMissAsync(
            [Blob(ContainerName + "/blob1", FileAccess.Read)] ICacheAwareReadObject blob)
        {
            Assert.IsFalse(blob.IsCacheHit);

            using (Stream blobStream = blob.BlobStream)
            using (StreamReader reader = new StreamReader(blobStream))
            {
                string result = await reader.ReadToEndAsync();
                Assert.AreEqual(TestData, result);
                _numCacheMisses = 1;
            }
        }

        /// <summary>
        /// This is mocking the case where there was a cache hit.
        /// Note: Here the actual input is not read from the shared memory region
        /// as no implementation of that is available in this package.
        /// We just verify if the object was a cache hit and that the input
        /// <see cref="ICacheAwareReadObject"/> has the proper fields populated.
        /// </summary>
        [NoAutomaticTrigger]
        public static void ByteArrayBindingCacheHit(
            [Blob(ContainerName + "/blob1", FileAccess.Read)] ICacheAwareReadObject blob)
        {
            Assert.IsTrue(blob.IsCacheHit);

            SharedMemoryMetadata cacheObj = blob.CacheObject;
            Assert.NotNull(cacheObj);

            _numCacheHits = 1;
        }

        public class TestFixture
        {
            public async Task InitializeAsync(WebJobsTestEnvironment testEnvironment)
            {
                RandomNameResolver nameResolver = new RandomNameResolver();

                CacheMock = CreateMockFunctionDataCache();
                CacheMock
                    .Setup(c => c.IsEnabled)
                    .Returns(true);
                IFunctionDataCache cache = CacheMock.Object;

                Host = new HostBuilder()
                    .ConfigureDefaultTestHost<CacheableBlobsEndToEndTests>(b =>
                    {
                        b.AddAzureStorageBlobs().AddAzureStorageQueues();
                        b.AddAzureStorageCoreServices();
                    })
                    .ConfigureServices(services =>
                    {
                        services.AddSingleton<INameResolver>(nameResolver)
                                .AddSingleton(cache);
                    })
                    .Build();

                JobHost = Host.GetJobHost();

                BlobServiceClient = new BlobServiceClient(testEnvironment.PrimaryStorageAccountConnectionString);

                BlobContainer = BlobServiceClient.GetBlobContainerClient(nameResolver.ResolveInString(ContainerName));
                Assert.False(await BlobContainer.ExistsAsync());
                await BlobContainer.CreateAsync();

                OutputBlobContainer = BlobServiceClient.GetBlobContainerClient(nameResolver.ResolveInString(OutputContainerName));

                await Host.StartAsync();

                // upload some test blobs
                BlockBlobClient blob = BlobContainer.GetBlockBlobClient("blob1");
                await blob.UploadTextAsync(TestData);
            }

            public IHost Host
            {
                get;
                private set;
            }

            public JobHost JobHost
            {
                get;
                private set;
            }

            public INameResolver NameResolver => Host.Services.GetService<INameResolver>();

            public string HostId => Host.Services.GetService<IHostIdProvider>().GetHostIdAsync(CancellationToken.None).Result;

            public BlobServiceClient BlobServiceClient
            {
                get;
                private set;
            }

            public BlobContainerClient BlobContainer
            {
                get;
                private set;
            }

            public BlobContainerClient OutputBlobContainer
            {
                get;
                private set;
            }

            public Mock<IFunctionDataCache> CacheMock
            {
                get;
                private set;
            }

            public async Task VerifyLockState(string lockId, LeaseState state, LeaseStatus status)
            {
                var container = BlobServiceClient.GetBlobContainerClient("azure-webjobs-hosts");
                string blobName = string.Format("locks/{0}/{1}", HostId, lockId);
                var lockBlob = container.GetBlockBlobClient(blobName);

                Assert.True(await lockBlob.ExistsAsync());
                BlobProperties blobProperties = await lockBlob.GetPropertiesAsync();

                Assert.AreEqual(state, blobProperties.LeaseState);
                Assert.AreEqual(status, blobProperties.LeaseStatus);
            }

            public async Task DisposeAsync()
            {
                if (Host != null)
                {
                    await Host.StopAsync();

                    VerifyLockState("WebJobs.Internal.Blobs.Listener", LeaseState.Available, LeaseStatus.Unlocked).Wait();

                    await foreach (var testContainer in BlobServiceClient.GetBlobContainersAsync(prefix: TestArtifactPrefix))
                    {
                        await BlobServiceClient.GetBlobContainerClient(testContainer.Name).DeleteAsync();
                    }
                }
            }
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
        /// Create a mock <see cref="SharedMemoryMetadata"/> describing a fake shared memory region.
        /// </summary>
        /// <returns>Mock <see cref="SharedMemoryMetadata"/>.</returns>
        private static Mock<SharedMemoryMetadata> CreateMockSharedMemoryMetadata()
        {
            return new Mock<SharedMemoryMetadata>(MockBehavior.Strict, "mockname", 10);
        }
    }
}
