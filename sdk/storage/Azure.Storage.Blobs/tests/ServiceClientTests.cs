// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class ServiceClientTests : BlobTestBase
    {
        public ServiceClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (blobEndpoint, blobSecondaryEndpoint), (default, default), (default, default), (default, default));

            BlobServiceClient service1 = InstrumentClient(new BlobServiceClient(connectionString.ToString(true)));
            BlobServiceClient service2 = InstrumentClient(new BlobServiceClient(connectionString.ToString(true), GetOptions()));

            var builder1 = new BlobUriBuilder(service1.Uri);
            var builder2 = new BlobUriBuilder(service2.Uri);

            Assert.IsEmpty(builder1.BlobContainerName);
            Assert.IsEmpty(builder1.BlobName);
            Assert.AreEqual(accountName, builder1.AccountName);

            Assert.IsEmpty(builder2.BlobContainerName);
            Assert.IsEmpty(builder2.BlobName);
            Assert.AreEqual(accountName, builder2.AccountName);
        }

        [Test]
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);

            BlobServiceClient service1 = InstrumentClient(new BlobServiceClient(blobEndpoint, credentials));
            BlobServiceClient service2 = InstrumentClient(new BlobServiceClient(blobEndpoint));

            var builder1 = new BlobUriBuilder(service1.Uri);
            var builder2 = new BlobUriBuilder(service2.Uri);

            Assert.IsEmpty(builder1.BlobContainerName);
            Assert.AreEqual("", builder1.BlobName);
            Assert.AreEqual(accountName, builder1.AccountName);

            Assert.IsEmpty(builder2.BlobContainerName);
            Assert.AreEqual("", builder2.BlobName);
            Assert.AreEqual(accountName, builder2.AccountName);
        }

        [Test]
        public async Task ListContainersSegmentAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Ensure at least one container
            await using DisposingContainer test = await GetTestContainerAsync(service: service);

            // Act
            IList<BlobContainerItem> containers = await service.GetBlobContainersAsync().ToListAsync();

            // Assert
            Assert.IsTrue(containers.Count() >= 1);
            var accountName = new BlobUriBuilder(service.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
        }

        #region Secondary Storage
        [Test]
        public async Task ListContainersSegmentAsync_SecondaryStorageFirstRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(1); // one GET failure means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageFirstRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [Test]
        public async Task ListContainersSegmentAsync_SecondaryStorageSecondRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(2); // two GET failures means the GET request should end up using the PRIMARY host
            AssertSecondaryStorageSecondRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [Test]
        public async Task ListContainersSegmentAsync_SecondaryStorageThirdRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(3); // three GET failures means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageThirdRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [Test]
        public async Task ListContainersSegmentAsync_SecondaryStorage404OnSecondary()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(3, true);  // three GET failures + 404 on SECONDARY host means the GET request should end up using the PRIMARY host
            AssertSecondaryStorage404OnSecondary(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        private async Task<TestExceptionPolicy> PerformSecondaryStorageTest(int numberOfReadFailuresToSimulate, bool retryOn404 = false)
        {
            BlobServiceClient service = GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(
                numberOfReadFailuresToSimulate,
                out TestExceptionPolicy testExceptionPolicy,
                retryOn404);
            await using DisposingContainer test = await GetTestContainerAsync(service: service);
                IList<BlobContainerItem> containers = await EnsurePropagatedAsync(
                    async () => await service.GetBlobContainersAsync().ToListAsync(),
                    containers => containers.Count > 0);
                Assert.IsTrue(containers.Count >= 1);
            return testExceptionPolicy;
        }
        #endregion

        [Test]
        public async Task ListContainersSegmentAsync_Marker()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            await using DisposingContainer test = await GetTestContainerAsync();
            var marker = default(string);
            var containers = new List<BlobContainerItem>();

            await foreach (Page<BlobContainerItem> page in service.GetBlobContainersAsync().AsPages(marker))
            {
                containers.AddRange(page.Values);
            }

            Assert.AreNotEqual(0, containers.Count);
            Assert.AreEqual(containers.Count, containers.Select(c => c.Name).Distinct().Count());
            Assert.IsTrue(containers.Any(c => test.Container.Uri == InstrumentClient(service.GetBlobContainerClient(c.Name)).Uri));
        }

        [Test]
        [AsyncOnly]
        public async Task ListContainersSegmentAsync_MaxResults()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            await using DisposingContainer test = await GetTestContainerAsync(service: service);
            await using DisposingContainer container = await GetTestContainerAsync(service: service);

            // Act
            Page<BlobContainerItem> page = await
                service.GetBlobContainersAsync()
                .AsPages(pageSizeHint: 1)
                .FirstAsync();

            // Assert
            Assert.AreEqual(1, page.Values.Count());

        }

        [Test]
        public async Task ListContainersSegmentAsync_Prefix()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            var prefix = "aaa";
            var containerName = prefix + GetNewContainerName();
            // Ensure at least one container
            await using DisposingContainer test = await GetTestContainerAsync(service: service, containerName: containerName);

            AsyncPageable<BlobContainerItem> containers = service.GetBlobContainersAsync(prefix: prefix);
            IList<BlobContainerItem> items = await containers.ToListAsync();
            // Assert
            Assert.AreNotEqual(0, items.Count());
            Assert.IsTrue(items.All(c => c.Name.StartsWith(prefix)));
            Assert.IsNotNull(items.Single(c => c.Name == containerName));
            Assert.IsTrue(items.All(c => c.Properties.Metadata == null));
        }

        [Test]
        public async Task ListContainersSegmentAsync_Metadata()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            await test.Container.SetMetadataAsync(metadata);

            // Act
            IList<BlobContainerItem> containers = await service.GetBlobContainersAsync(BlobContainerTraits.Metadata).ToListAsync();

            // Assert
            AssertMetadataEquality(
                metadata,
                containers.Where(c => c.Name == test.Container.Name).FirstOrDefault().Properties.Metadata);
        }

        [Test]
        [AsyncOnly]
        public async Task ListContainersSegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetBlobContainersAsync().AsPages(continuationToken: "garbage").FirstAsync(),
                e => Assert.AreEqual("OutOfRangeInput", e.ErrorCode));
        }

        [Test]
        public async Task GetAccountInfoAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<AccountInfo> response = await service.GetAccountInfoAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetAccountInfoAsync_Error()
        {
            // Arrange
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetAccountInfoAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<BlobServiceProperties> response = await service.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.DeleteRetentionPolicy);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetPropertiesAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        [NonParallelizable]
        public async Task SetPropertiesAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobServiceProperties properties = (await service.GetPropertiesAsync()).Value;
            BlobCorsRule[] originalCors = properties.Cors.ToArray();
            properties.Cors =
                new[]
                {
                    new BlobCorsRule
                    {
                        MaxAgeInSeconds = 1000,
                        AllowedHeaders = "x-ms-meta-data*,x-ms-meta-target*,x-ms-meta-abc",
                        AllowedMethods = "PUT,GET",
                        AllowedOrigins = "*",
                        ExposedHeaders = "x-ms-meta-*"
                    }
                };

            // Act
            await service.SetPropertiesAsync(properties);

            // Assert
            properties = (await service.GetPropertiesAsync()).Value;
            Assert.AreEqual(1, properties.Cors.Count());
            Assert.IsTrue(properties.Cors[0].MaxAgeInSeconds == 1000);

            // Cleanup
            properties.Cors = originalCors;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.AreEqual(originalCors.Count(), properties.Cors.Count());
        }

        [Test]
        public async Task SetPropertiesAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobServiceProperties properties = (await service.GetPropertiesAsync()).Value;
            BlobServiceClient invalidService = InstrumentClient(
                new BlobServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                invalidService.SetPropertiesAsync(properties),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        // Note: read-access geo-redundant replication must be enabled for test account, or this test will fail.
        [Test]
        public async Task GetStatisticsAsync()
        {
            // Arrange
            // "-secondary" is required by the server
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceSecondaryEndpoint),
                    GetNewSharedKeyCredentials(),
                    GetOptions()));

            // Act
            Response<BlobServiceStatistics> response = await service.GetStatisticsAsync();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetUserDelegationKey()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_OauthAccount();

            // Act
            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(startsOn: null, expiresOn: Recording.UtcNow.AddHours(1));

            // Assert
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetUserDelegationKeyAsync(startsOn: null, expiresOn: Recording.UtcNow.AddHours(1)),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task GetUserDelegationKey_ArgumentException()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_OauthAccount();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                service.GetUserDelegationKeyAsync(startsOn: null, expiresOn: Recording.Now.AddHours(1)),
                e => Assert.AreEqual("expiresOn must be UTC", e.Message));
        }

        [Test]
        public async Task CreateBlobContainerAsync()
        {
            var name = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_SharedKey();
            try
            {
                BlobContainerClient container = InstrumentClient((await service.CreateBlobContainerAsync(name)).Value);
                Response<BlobContainerProperties> properties = await container.GetPropertiesAsync();
                Assert.IsNotNull(properties.Value);
            }
            finally
            {
                await service.DeleteBlobContainerAsync(name);
            }
        }

        [Test]
        public async Task DeleteBlobContainerAsync()
        {
            var name = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient((await service.CreateBlobContainerAsync(name)).Value);

            await service.DeleteBlobContainerAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await container.GetPropertiesAsync());
        }
    }
}
