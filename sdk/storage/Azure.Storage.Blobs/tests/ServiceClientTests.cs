// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests.Shared;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class ServiceClientTests : BlobTestBase
    {
        public ServiceClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        public BlobServiceClient GetServiceClient_SharedKey(BlobClientOptions options = default)
            => BlobsClientBuilder.GetServiceClient_SharedKey(options);

        [RecordedTest]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

            BlobServiceClient service1 = InstrumentClient(new BlobServiceClient(connectionString.ToString(true)));
            BlobServiceClient service2 = InstrumentClient(new BlobServiceClient(connectionString.ToString(true), GetOptions()));

            var builder1 = new BlobUriBuilder(service1.Uri);
            var builder2 = new BlobUriBuilder(service2.Uri);

            Assert.That(builder1.BlobContainerName, Is.Empty);
            Assert.That(builder1.BlobName, Is.Empty);
            Assert.That(builder1.AccountName, Is.EqualTo(accountName));

            Assert.That(builder2.BlobContainerName, Is.Empty);
            Assert.That(builder2.BlobName, Is.Empty);
            Assert.That(builder2.AccountName, Is.EqualTo(accountName));
        }

        [Test]
        public void Ctor_ConnectionString_CustomUri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://customdomain/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://customdomain/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

            BlobServiceClient service = new BlobServiceClient(connectionString.ToString(true));

            Assert.That(service.AccountName, Is.EqualTo(accountName));
        }

        [RecordedTest]
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

            Assert.That(builder1.BlobContainerName, Is.Empty);
            Assert.That(builder1.BlobName, Is.Empty);
            Assert.That(builder1.AccountName, Is.EqualTo(accountName));

            Assert.That(builder2.BlobContainerName, Is.Empty);
            Assert.That(builder2.BlobName, Is.Empty);
            Assert.That(builder2.AccountName, Is.EqualTo(accountName));
        }

        [RecordedTest]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobServiceClient(httpUri, TestEnvironment.Credential),
                 new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [RecordedTest]
        public void Ctor_CPK_Http()
        {
            // Arrange
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlobClientOptions blobClientOptions = new BlobClientOptions()
            {
                CustomerProvidedKey = customerProvidedKey
            };
            Uri httpUri = new Uri(TestConfigDefault.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobServiceClient(httpUri, blobClientOptions),
                new ArgumentException("Cannot use client-provided key without HTTPS."));
        }

        [RecordedTest]
        public void Ctor_CPK_EncryptionScope()
        {
            // Arrange
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlobClientOptions blobClientOptions = new BlobClientOptions
            {
                CustomerProvidedKey = customerProvidedKey,
                EncryptionScope = TestConfigDefault.EncryptionScope
            };

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobServiceClient(new Uri(TestConfigDefault.BlobServiceEndpoint), blobClientOptions),
                new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set"));
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri($"https://customdomain/");

            BlobServiceClient blobClient = new BlobServiceClient(blobEndpoint, credentials);

            Assert.That(blobClient.AccountName, Is.EqualTo(accountName));
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetAccountSasCredentials().SasToken;
            Uri uri = test.Container.GetParentBlobServiceClient().Uri;

            // Act
            var sasClient = InstrumentClient(new BlobServiceClient(uri, new AzureSasCredential(sas), GetOptions()));
            BlobServiceProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.That(properties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetAccountSasCredentials().SasToken;
            Uri uri = test.Container.GetParentBlobServiceClient().Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new BlobServiceClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [Test]
        public void Ctor_With_Sas_Does_Not_Reorder_Services()
        {
            // Arrange
            var uri = new Uri("http://127.0.0.1/accountName?sv=2015-04-05&ss=bqtf&srt=sco&st=2021-03-29T02%3A25%3A53Z&se=2021-06-09T02%3A40%3A53Z&sp=crwdlaup&sig=XXXXX");
            var transport = new MockTransport(r => new MockResponse(404));
            var clientOptions = new BlobClientOptions()
            {
                Transport = transport
            };

            // Act
            var client = new BlobServiceClient(uri, clientOptions);
            Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetPropertiesAsync());

            // Act
            Assert.That(transport.SingleRequest.Uri.ToString(), Does.Contain("ss=bqtf"));
        }

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.DefaultAudience);

            BlobServiceClient aadService = InstrumentClient(new BlobServiceClient(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                TestEnvironment.Credential,
                options));

            // Assert
            Response<BlobServiceProperties> properties = await aadService.GetPropertiesAsync();
            Assert.That(properties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_CustomAudience()
        {
            // Arrange
            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint));

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(new BlobAudience($"https://{uriBuilder.AccountName}.blob.core.windows.net/"));

            BlobServiceClient aadService = InstrumentClient(new BlobServiceClient(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                TestEnvironment.Credential,
                options));

            // Assert
            Response<BlobServiceProperties> properties = await aadService.GetPropertiesAsync();
            Assert.That(properties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint));

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.CreateBlobServiceAccountAudience(uriBuilder.AccountName));

            BlobServiceClient aadService = InstrumentClient(new BlobServiceClient(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                TestEnvironment.Credential,
                options));

            // Assert
            Response<BlobServiceProperties> properties = await aadService.GetPropertiesAsync();
            Assert.That(properties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(new BlobAudience("https://badaudience.blob.core.windows.net"));

            BlobServiceClient aadContainer = InstrumentClient(new BlobServiceClient(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadContainer.GetPropertiesAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.InvalidAuthenticationInfo.ToString())));
        }

        [RecordedTest]
        public async Task ListContainersSegmentAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Ensure at least one container
            await using DisposingContainer test = await GetTestContainerAsync(service: service);

            // Act
            IList<BlobContainerItem> containers = await service.GetBlobContainersAsync().ToListAsync();

            // Assert
            Assert.That(containers.Count() >= 1, Is.True);
            var accountName = new BlobUriBuilder(service.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);

            Assert.That(containers[0].Name, Is.Not.Null);
            Assert.That(containers[0].Properties, Is.Not.Null);
            Assert.That(containers[0].Properties.ETag, Is.Not.Null);
            Assert.That(containers[0].Properties.HasImmutabilityPolicy, Is.Not.Null);
            Assert.That(containers[0].Properties.HasLegalHold, Is.Not.Null);
            Assert.That(containers[0].Properties.LastModified, Is.Not.Null);
            Assert.That(containers[0].Properties.LeaseState, Is.Not.Null);
            Assert.That(containers[0].Properties.LeaseStatus, Is.Not.Null);

            if (_serviceVersion >= BlobClientOptions.ServiceVersion.V2019_07_07)
            {
                Assert.That(containers[0].Properties.DefaultEncryptionScope, Is.Not.Null);
                Assert.That(containers[0].Properties.PreventEncryptionScopeOverride, Is.Not.Null);
            }
        }

        #region Secondary Storage
        [RecordedTest]
        public async Task ListContainersSegmentAsync_SecondaryStorageFirstRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(1); // one GET failure means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageFirstRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [RecordedTest]
        public async Task ListContainersSegmentAsync_SecondaryStorageSecondRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(2); // two GET failures means the GET request should end up using the PRIMARY host
            AssertSecondaryStorageSecondRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [RecordedTest]
        public async Task ListContainersSegmentAsync_SecondaryStorageThirdRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(3); // three GET failures means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageThirdRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [RecordedTest]
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
            Assert.That(containers.Count >= 1, Is.True);
            return testExceptionPolicy;
        }
        #endregion

        [RecordedTest]
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

            Assert.That(containers.Count, Is.Not.EqualTo(0));
            Assert.That(containers.Select(c => c.Name).Distinct().Count(), Is.EqualTo(containers.Count));
            Assert.That(containers.Any(c => test.Container.Uri == InstrumentClient(service.GetBlobContainerClient(c.Name)).Uri), Is.True);
        }

        [RecordedTest]
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
            Assert.That(page.Values.Count(), Is.EqualTo(1));
        }

        [RecordedTest]
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
            Assert.That(items.Count(), Is.Not.EqualTo(0));
            Assert.That(items.All(c => c.Name.StartsWith(prefix)), Is.True);
            Assert.That(items.Single(c => c.Name == containerName), Is.Not.Null);
            Assert.That(items.All(c => c.Properties.Metadata == null), Is.True);
        }

        [RecordedTest]
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
            AssertDictionaryEquality(
                metadata,
                containers.Where(c => c.Name == test.Container.Name).FirstOrDefault().Properties.Metadata);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task ListContainersSegmentAsync_Deleted()
        {
            // Arrange
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SoftDelete();
            string containerName = GetNewContainerName();
            BlobContainerClient containerClient = InstrumentClient(service.GetBlobContainerClient(containerName));
            await containerClient.CreateAsync();
            await containerClient.DeleteAsync();

            // Act
            IList<BlobContainerItem> containers = await service.GetBlobContainersAsync(states: BlobContainerStates.Deleted).ToListAsync();
            BlobContainerItem containerItem = containers.Where(c => c.Name == containerName).FirstOrDefault();

            // Assert
            Assert.That(containerItem.IsDeleted, Is.True);
            Assert.That(containerItem.VersionId, Is.Not.Null);
            Assert.That(containerItem.Properties.DeletedOn, Is.Not.Null);
            Assert.That(containerItem.Properties.RemainingRetentionDays, Is.Not.Null);
        }

        [RecordedTest]
        [PlaybackOnly("Enabling static website is not allowed on Network Security Perimeter enabled accounts.")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        [NonParallelizable]
        public async Task ListContainersSegmentAsync_System()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobServiceProperties properties = await service.GetPropertiesAsync();
            BlobStaticWebsite originalBlobStaticWebsite = properties.StaticWebsite;

            string errorDocument404Path = "error/404.html";
            string defaultIndexDocumentPath = "index.html";

            properties.StaticWebsite = new BlobStaticWebsite
            {
                Enabled = true,
                ErrorDocument404Path = errorDocument404Path,
                DefaultIndexDocumentPath = defaultIndexDocumentPath
            };

            await service.SetPropertiesAsync(properties);

            // Act
            IList<BlobContainerItem> containers = await service.GetBlobContainersAsync(states: BlobContainerStates.System).ToListAsync();
            BlobContainerItem logsBlobContainerItem = containers.Where(r => r.Name == "$web").FirstOrDefault();

            // Assert
            Assert.That(containers.Count > 0, Is.True);
            Assert.That(logsBlobContainerItem, Is.Not.Null);

            // Cleanup
            properties.StaticWebsite = originalBlobStaticWebsite;
            await service.SetPropertiesAsync(properties);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task ListContainersSegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetBlobContainersAsync().AsPages(continuationToken: "garbage").FirstAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("OutOfRangeInput")));
        }

        [RecordedTest]
        public async Task GetAccountInfoAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<AccountInfo> response = await service.GetAccountInfoAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetAccountInfoAsync_HnsFalse()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<AccountInfo> response = await service.GetAccountInfoAsync();

            // Assert
            Assert.That(response.Value.IsHierarchicalNamespaceEnabled, Is.False);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetAccountInfoAsync_HnsTrue()
        {
            // Arrange
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_Hns();

            // Act
            Response<AccountInfo> response = await service.GetAccountInfoAsync();

            // Assert
            Assert.That(response.Value.IsHierarchicalNamespaceEnabled, Is.True);
        }

        [RecordedTest]
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
                e => Assert.That(e.ErrorCode, Is.EqualTo("NoAuthenticationInformation")));
        }

        [RecordedTest]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<BlobServiceProperties> response = await service.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.DeleteRetentionPolicy, Is.Not.Null);
        }

        [RecordedTest]
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
                e => { });
        }

        [RecordedTest]
        [NonParallelizable]
        public async Task SetPropertiesAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobServiceProperties properties = await service.GetPropertiesAsync();
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
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.Cors.Count(), Is.EqualTo(1));
            Assert.That(properties.Cors[0].MaxAgeInSeconds, Is.EqualTo(1000));

            // Cleanup
            properties.Cors = originalCors;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.Cors.Count(), Is.EqualTo(originalCors.Count()));
        }

        [RecordedTest]
        [PlaybackOnly("Enabling static website is not allowed on Network Security Perimeter enabled accounts.")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [NonParallelizable]
        public async Task SetPropertiesAsync_StaticWebsite()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobServiceProperties properties = await service.GetPropertiesAsync();
            BlobStaticWebsite originalBlobStaticWebsite = properties.StaticWebsite;

            string errorDocument404Path = "error/404.html";
            string defaultIndexDocumentPath = "index.html";

            properties.StaticWebsite = new BlobStaticWebsite
            {
                Enabled = true,
                ErrorDocument404Path = errorDocument404Path,
                DefaultIndexDocumentPath = defaultIndexDocumentPath
            };

            // Act
            await service.SetPropertiesAsync(properties);

            // Assert
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.StaticWebsite.Enabled, Is.True);
            Assert.That(properties.StaticWebsite.ErrorDocument404Path, Is.EqualTo(errorDocument404Path));
            Assert.That(properties.StaticWebsite.DefaultIndexDocumentPath, Is.EqualTo(defaultIndexDocumentPath));

            // Cleanup
            properties.StaticWebsite = originalBlobStaticWebsite;
            await service.SetPropertiesAsync(properties);
        }

        [RecordedTest]
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
                e => { });
        }

        // Note: read-access geo-redundant replication must be enabled for test account, or this test will fail.
        [RecordedTest]
        [PlaybackOnly(".NET autorest generator bug - https://github.com/Azure/azure-sdk-for-net/issues/28979")]
        public async Task GetStatisticsAsync()
        {
            // Arrange
            // "-secondary" is required by the server
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceSecondaryEndpoint),
                    Tenants.GetNewSharedKeyCredentials(),
                    GetOptions()));

            // Act
            Response<BlobServiceStatistics> response = await service.GetStatisticsAsync();

            // Assert
            Assert.That(response, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetUserDelegationKey()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_OAuth();

            // Act
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(
                options: options);

            // Assert
            Assert.That(response.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetUserDelegationKeyAsync(options: options),
                e => Assert.That(e.ErrorCode, Is.EqualTo("AuthenticationFailed")));
        }

        [RecordedTest]
        public async Task GetUserDelegationKey_ArgumentException()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_OAuth();

            // Act
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(
                // ensure the time used is not UTC, as DateTimeOffset.Now could actually be UTC based on OS settings
                // Use a custom time zone so we aren't dependent on OS having specific standard time zone.
                expiresOn: TimeZoneInfo.ConvertTime(
                        Recording.Now.AddHours(1),
                        TimeZoneInfo.CreateCustomTimeZone("Storage Test Custom Time Zone", TimeSpan.FromHours(-3), "CTZ", "CTZ")));
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                service.GetUserDelegationKeyAsync(
                    options: options),
                e => Assert.That(e.Message, Is.EqualTo("expiresOn must be UTC")));
            ;
        }

        [RecordedTest]
        public async Task CreateBlobContainerAsync()
        {
            var name = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_SharedKey();
            try
            {
                BlobContainerClient container = InstrumentClient((await service.CreateBlobContainerAsync(name)).Value);
                Response<BlobContainerProperties> properties = await container.GetPropertiesAsync();
                Assert.That(properties.Value, Is.Not.Null);
            }
            finally
            {
                await service.DeleteBlobContainerAsync(name);
            }
        }

        [RecordedTest]
        public async Task DeleteBlobContainerAsync()
        {
            var name = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient((await service.CreateBlobContainerAsync(name)).Value);

            await service.DeleteBlobContainerAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await container.GetPropertiesAsync());
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(5, typeof(NullReferenceException))]
        public async Task FindBlobsByTagAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            string tagKey = "myTagKey";
            string tagValue = "myTagValue";
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { tagKey, tagValue }
            };
            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Tags = tags
            };
            await appendBlob.CreateAsync(options);

            string expression = $"\"{tagKey}\"='{tagValue}'";

            // It takes a few seconds for Filter Blobs to pick up new changes
            await Delay(2000);

            // Act
            List<TaggedBlobItem> blobs = new List<TaggedBlobItem>();
            await foreach (Page<TaggedBlobItem> page in service.FindBlobsByTagsAsync(expression).AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            TaggedBlobItem filterBlob = blobs.Where(r => r.BlobName == blobName).FirstOrDefault();

            if (_serviceVersion >= BlobClientOptions.ServiceVersion.V2020_04_08)
            {
                Assert.That(filterBlob.Tags.Count, Is.EqualTo(1));
                Assert.That(filterBlob.Tags["myTagKey"], Is.EqualTo("myTagValue"));
            }
            else
            {
                Assert.That(filterBlob, Is.Not.Null);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(AccountSasPermissions.Filter)]
        [TestCase(AccountSasPermissions.All)]
        public async Task FindBlobsByTagAsync_AccountSas(AccountSasPermissions accountSasPermissions)
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            string tagKey = "myTagKey";
            string tagValue = "myTagValue";
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { tagKey, tagValue }
            };
            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Tags = tags
            };
            await appendBlob.CreateAsync(options);

            string expression = $"\"{tagKey}\"='{tagValue}'";

            // It takes a few seconds for Filter Blobs to pick up new changes
            await Delay(2000);

            // Act
            SasQueryParameters sasQueryParameters = BlobsClientBuilder.GetNewAccountSas(permissions: accountSasPermissions);
            BlobServiceClient sasServiceClient = new BlobServiceClient(new Uri($"{service.Uri}?{sasQueryParameters}"), GetOptions());
            List<TaggedBlobItem> blobs = new List<TaggedBlobItem>();
            await foreach (Page<TaggedBlobItem> page in sasServiceClient.FindBlobsByTagsAsync(expression).AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            TaggedBlobItem filterBlob = blobs.Where(r => r.BlobName == blobName).FirstOrDefault();
            Assert.That(filterBlob, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task FindBlobsByTagAsync_Error()
        {
            // Arrange
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.FindBlobsByTagsAsync("\"key\" = 'value'").AsPages().FirstAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.NoAuthenticationInformation.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UndeleteBlobContainerAsync()
        {
            // Arrange
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SoftDelete();
            string containerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));
            await container.CreateAsync();
            await container.DeleteAsync();
            IList<BlobContainerItem> containers = await service.GetBlobContainersAsync(states: BlobContainerStates.Deleted).ToListAsync();
            BlobContainerItem containerItem = containers.Where(c => c.Name == containerName).FirstOrDefault();

            // It takes some time for the Container to be deleted.
            await Delay(30000);

            // Act
            Response<BlobContainerClient> response = await service.UndeleteBlobContainerAsync(
                containerItem.Name,
                containerItem.VersionId);

            // Assert
            await response.Value.GetPropertiesAsync();

            // Cleanup
            await container.DeleteAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UndeleteBlobContainerAsync_Error()
        {
            // Arrange
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SoftDelete();
            string containerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.UndeleteBlobContainerAsync(GetNewBlobName(), "01D60F8BB59A4652"),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.ContainerNotFound.ToString())));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task RenameBlobContainerAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            string oldContainerName = GetNewContainerName();
            string newContainerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(oldContainerName));
            await container.CreateAsync();

            // Act
            BlobContainerClient newContainer = await service.RenameBlobContainerAsync(
                sourceContainerName: oldContainerName,
                destinationContainerName: newContainerName);

            // Assert
            await newContainer.GetPropertiesAsync();

            // Cleanup
            await newContainer.DeleteAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(nameof(BlobRequestConditions.IfModifiedSince))]
        [TestCase(nameof(BlobRequestConditions.IfUnmodifiedSince))]
        [TestCase(nameof(BlobRequestConditions.TagConditions))]
        [TestCase(nameof(BlobRequestConditions.IfMatch))]
        [TestCase(nameof(BlobRequestConditions.IfNoneMatch))]
        public async Task RenameBlobContainerAsync_InvalidSourceRequestConditions(string invalidSourceCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobServiceClient serviceClient = new BlobServiceClient(uri, GetOptions());

            BlobRequestConditions sourceConditions = new BlobRequestConditions();

            switch (invalidSourceCondition)
            {
                case nameof(BlobRequestConditions.IfModifiedSince):
                    sourceConditions.IfModifiedSince = new DateTimeOffset();
                    break;
                case nameof(BlobRequestConditions.IfUnmodifiedSince):
                    sourceConditions.IfUnmodifiedSince = new DateTimeOffset();
                    break;
                case nameof(BlobRequestConditions.TagConditions):
                    sourceConditions.TagConditions = string.Empty;
                    break;
                case nameof(BlobRequestConditions.IfMatch):
                    sourceConditions.IfMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfNoneMatch):
                    sourceConditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                serviceClient.RenameBlobContainerAsync(
                    sourceContainerName: "sourceContainerName",
                    destinationContainerName: "destinationContainerName",
                    sourceConditions: sourceConditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"RenameBlobContainer does not support the {invalidSourceCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("sourceConditions"), Is.True);
                });
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task RenameBlobContainerAsync_AccountSas()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            string oldContainerName = GetNewContainerName();
            string newContainerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(oldContainerName));
            await container.CreateAsync();
            SasQueryParameters sasQueryParameters = BlobsClientBuilder.GetNewAccountSas();
            service = InstrumentClient(new BlobServiceClient(new Uri($"{service.Uri}?{sasQueryParameters}"), GetOptions()));

            // Act
            BlobContainerClient newContainer = await service.RenameBlobContainerAsync(
                sourceContainerName: oldContainerName,
                destinationContainerName: newContainerName);

            // Assert
            await newContainer.GetPropertiesAsync();

            // Cleanup
            await newContainer.DeleteAsync();
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task RenameBlobContainerAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.RenameBlobContainerAsync(GetNewContainerName(), GetNewContainerName()),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.ContainerNotFound.ToString())));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task RenameBlobContainerAsync_SourceLease()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            string oldContainerName = GetNewContainerName();
            string newContainerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(oldContainerName));
            await container.CreateAsync();
            string leaseId = Recording.Random.NewGuid().ToString();

            BlobLeaseClient leaseClient = InstrumentClient(container.GetBlobLeaseClient(leaseId));
            await leaseClient.AcquireAsync(duration: TimeSpan.FromSeconds(30));

            BlobRequestConditions sourceConditions = new BlobRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            BlobContainerClient newContainer = await service.RenameBlobContainerAsync(
                sourceContainerName: oldContainerName,
                destinationContainerName: newContainerName,
                sourceConditions: sourceConditions);

            // Assert
            await newContainer.GetPropertiesAsync();

            // Cleanup
            await newContainer.DeleteAsync();
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task RenameBlobContainerAsync_SourceLeaseFailed()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            string oldContainerName = GetNewContainerName();
            string newContainerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(oldContainerName));
            await container.CreateAsync();
            string leaseId = Recording.Random.NewGuid().ToString();

            BlobRequestConditions sourceConditions = new BlobRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.RenameBlobContainerAsync(
                    sourceContainerName: oldContainerName,
                    destinationContainerName: newContainerName,
                    sourceConditions: sourceConditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.LeaseNotPresentWithContainerOperation.ToString())));

            // Cleanup
            await container.DeleteAsync();
        }

        #region GenerateSasTests
        [RecordedTest]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - BlobServiceClient(string connectionString)
            BlobServiceClient container = InstrumentClient(new BlobServiceClient(
                connectionString));
            Assert.That(container.CanGenerateAccountSasUri, Is.True);

            // Act - BlobServiceClient(string connectionString, string blobContainerName, BlobClientOptions options)
            BlobServiceClient container2 = InstrumentClient(new BlobServiceClient(
                connectionString,
                GetOptions()));
            Assert.That(container2.CanGenerateAccountSasUri, Is.True);

            // Act - BlobServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            BlobServiceClient container3 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                GetOptions()));
            Assert.That(container3.CanGenerateAccountSasUri, Is.False);

            // Act - BlobServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            BlobServiceClient container4 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.That(container4.CanGenerateAccountSasUri, Is.True);

            // Act - BlobServiceClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            BlobServiceClient container5 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.That(container5.CanGenerateAccountSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateSas_GetContainerClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Check if we're passing the SharedKeyCredential correctly to the containerClient
            // Act - BlobServiceClient(string connectionString)
            BlobServiceClient serviceClient = InstrumentClient(new BlobServiceClient(
                connectionString));
            BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(GetNewContainerName());
            Assert.That(containerClient.CanGenerateSasUri, Is.True);

            // Act - BlobServiceClient(string connectionString, string blobContainerName, BlobClientOptions options)
            BlobServiceClient serviceClient2 = InstrumentClient(new BlobServiceClient(
                connectionString,
                GetOptions()));
            BlobContainerClient containerClient2 = serviceClient2.GetBlobContainerClient(GetNewContainerName());
            Assert.That(containerClient2.CanGenerateSasUri, Is.True);

            // Act - BlobServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            BlobServiceClient serviceClient3 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                GetOptions()));
            BlobContainerClient containerClient3 = serviceClient3.GetBlobContainerClient(GetNewContainerName());
            Assert.That(containerClient3.CanGenerateSasUri, Is.False);

            // Act - BlobServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            BlobServiceClient serviceClient4 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            BlobContainerClient containerClient4 = serviceClient4.GetBlobContainerClient(GetNewContainerName());
            Assert.That(containerClient4.CanGenerateSasUri, Is.True);

            // Act - BlobServiceClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            BlobServiceClient serviceClient5 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            BlobContainerClient containerClient5 = serviceClient5.GetBlobContainerClient(GetNewContainerName());
            Assert.That(containerClient5.CanGenerateSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateAccountSas_Mockable()
        {
            // Act
            var serviceClient = new Mock<BlobServiceClient>();
            serviceClient.Setup(x => x.CanGenerateAccountSasUri).Returns(false);

            // Assert
            Assert.That(serviceClient.Object.CanGenerateAccountSasUri, Is.False);

            // Act
            serviceClient.Setup(x => x.CanGenerateAccountSasUri).Returns(true);

            // Assert
            Assert.That(serviceClient.Object.CanGenerateAccountSasUri, Is.True);
        }

        [RecordedTest]
        public void GenerateAccountSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            BlobServiceClient serviceClient = InstrumentClient(
                new BlobServiceClient(
                    serviceUri,
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            string stringToSign = null;

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(
                permissions: permissions,
                expiresOn: expiresOn,
                resourceTypes: resourceTypes,
                out stringToSign);

            // Assert
            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, AccountSasServices.Blobs, resourceTypes);
            UriBuilder expectedUri = new UriBuilder(serviceUri);
            expectedUri.Query += sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.That(sasUri, Is.EqualTo(expectedUri.Uri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public void GenerateAccountSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Blobs;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            BlobServiceClient serviceClient = InstrumentClient(
                new BlobServiceClient(
                    serviceUri,
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            string stringToSign = null;

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(sasBuilder, out stringToSign);

            // Assert
            UriBuilder expectedUri = new UriBuilder(serviceUri);
            expectedUri.Query += sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.That(sasUri, Is.EqualTo(expectedUri.Uri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public void GenerateAccountSas_WrongService_Service()
        {
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Files; // Wrong Service
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            BlobServiceClient serviceClient = InstrumentClient(
                new BlobServiceClient(
                    serviceUri,
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            // Act
            TestHelper.AssertExpectedException(
                () => serviceClient.GenerateAccountSasUri(sasBuilder),
                 new InvalidOperationException("SAS Uri cannot be generated. builder.Services does specify Blobs. builder.Services must either specify Blobs or specify all Services are accessible in the value."));
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<BlobServiceClient>(TestConfigDefault.ConnectionString, new BlobClientOptions()).Object;
            mock = new Mock<BlobServiceClient>(TestConfigDefault.ConnectionString).Object;
            mock = new Mock<BlobServiceClient>(new Uri("https://test/test"), new BlobClientOptions()).Object;
            mock = new Mock<BlobServiceClient>(new Uri("https://test/test"), Tenants.GetNewSharedKeyCredentials(), new BlobClientOptions()).Object;
            mock = new Mock<BlobServiceClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new BlobClientOptions()).Object;
            mock = new Mock<BlobServiceClient>(new Uri("https://test/test"), TestEnvironment.Credential, new BlobClientOptions()).Object;
        }
    }
}
