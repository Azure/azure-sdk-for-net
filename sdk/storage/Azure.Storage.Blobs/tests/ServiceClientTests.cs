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
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class ServiceClientTests : BlobTestBase
    {
        public ServiceClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
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

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

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
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobServiceClient(httpUri, GetOAuthCredential()),
                 new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
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

        [Test]
        [Ignore("#10044: Re-enable failing Storage tests")]
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
            Assert.IsNotNull(properties);
        }

        [Test]
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

            Assert.IsNotNull(containers[0].Name);
            Assert.IsNotNull(containers[0].Properties);
            Assert.IsNotNull(containers[0].Properties.ETag);
            Assert.IsNotNull(containers[0].Properties.HasImmutabilityPolicy);
            Assert.IsNotNull(containers[0].Properties.HasLegalHold);
            Assert.IsNotNull(containers[0].Properties.LastModified);
            Assert.IsNotNull(containers[0].Properties.LeaseState);
            Assert.IsNotNull(containers[0].Properties.LeaseStatus);

            if (_serviceVersion >= BlobClientOptions.ServiceVersion.V2019_07_07)
            {
                Assert.IsNotNull(containers[0].Properties.DefaultEncryptionScope);
                Assert.IsNotNull(containers[0].Properties.PreventEncryptionScopeOverride);
            }
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
            AssertDictionaryEquality(
                metadata,
                containers.Where(c => c.Name == test.Container.Name).FirstOrDefault().Properties.Metadata);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task ListContainersSegmentAsync_Deleted()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SoftDelete();
            string containerName = GetNewContainerName();
            BlobContainerClient containerClient = InstrumentClient(service.GetBlobContainerClient(containerName));
            await containerClient.CreateAsync();
            await containerClient.DeleteAsync();

            // Act
            IList<BlobContainerItem> containers = await service.GetBlobContainersAsync(states: BlobContainerStates.Deleted).ToListAsync();
            BlobContainerItem containerItem = containers.Where(c => c.Name == containerName).FirstOrDefault();

            // Assert
            Assert.IsTrue(containerItem.IsDeleted);
            Assert.IsNotNull(containerItem.VersionId);
            Assert.IsNotNull(containerItem.Properties.DeletedOn);
            Assert.IsNotNull(containerItem.Properties.RemainingRetentionDays);
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
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetAccountInfoAsync_HnsFalse()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<AccountInfo> response = await service.GetAccountInfoAsync();

            // Assert
            Assert.IsFalse(response.Value.IsHierarchicalNamespaceEnabled);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetAccountInfoAsync_HnsTrue()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_Hns();

            // Act
            Response<AccountInfo> response = await service.GetAccountInfoAsync();

            // Assert
            Assert.IsTrue(response.Value.IsHierarchicalNamespaceEnabled);
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
                e => { });
        }

        [Test]
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
            Assert.AreEqual(1, properties.Cors.Count());
            Assert.IsTrue(properties.Cors[0].MaxAgeInSeconds == 1000);

            // Cleanup
            properties.Cors = originalCors;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.AreEqual(originalCors.Count(), properties.Cors.Count());
        }

        [Test]
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
            Assert.IsTrue(properties.StaticWebsite.Enabled);
            Assert.AreEqual(errorDocument404Path, properties.StaticWebsite.ErrorDocument404Path);
            Assert.AreEqual(defaultIndexDocumentPath, properties.StaticWebsite.DefaultIndexDocumentPath);

            // Cleanup
            properties.StaticWebsite = originalBlobStaticWebsite;
            await service.SetPropertiesAsync(properties);
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
                e => { });
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
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [Test]
        public async Task GetUserDelegationKey_ArgumentException()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_OauthAccount();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                service.GetUserDelegationKeyAsync(
                    startsOn: null,
                    // ensure the time used is not UTC, as DateTimeOffset.Now could actually be UTC based on OS settings
                    // Use a custom time zone so we aren't dependent on OS having specific standard time zone.
                    expiresOn: TimeZoneInfo.ConvertTime(
                        Recording.Now.AddHours(1),
                        TimeZoneInfo.CreateCustomTimeZone("Storage Test Custom Time Zone", TimeSpan.FromHours(-3), "CTZ", "CTZ"))),
                e => Assert.AreEqual("expiresOn must be UTC", e.Message)); ;
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

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
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
                Assert.AreEqual(1, filterBlob.Tags.Count);
                Assert.AreEqual("myTagValue", filterBlob.Tags["myTagKey"]);
            }
            else
            {
                Assert.IsNotNull(filterBlob);
            }
        }

        [Test]
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
            SasQueryParameters sasQueryParameters = GetNewAccountSas(permissions: accountSasPermissions);
            BlobServiceClient sasServiceClient = new BlobServiceClient(new Uri($"{service.Uri}?{sasQueryParameters}"), GetOptions());
            List<TaggedBlobItem> blobs = new List<TaggedBlobItem>();
            await foreach (Page<TaggedBlobItem> page in sasServiceClient.FindBlobsByTagsAsync(expression).AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            TaggedBlobItem filterBlob = blobs.Where(r => r.BlobName == blobName).FirstOrDefault();
            Assert.IsNotNull(filterBlob);
        }

        [Test]
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
                e => Assert.AreEqual(BlobErrorCode.NoAuthenticationInformation.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UndeleteBlobContainerAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SoftDelete();
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
                containerItem.VersionId,
                GetNewContainerName());

            // Assert
            await response.Value.GetPropertiesAsync();

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UndeleteBlobContainerAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SoftDelete();
            string containerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.UndeleteBlobContainerAsync(GetNewBlobName(), "01D60F8BB59A4652"),
                e => Assert.AreEqual(BlobErrorCode.ContainerNotFound.ToString(), e.ErrorCode));
        }

        #region GenerateSasTests
        [Test]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - BlobServiceClient(string connectionString)
            BlobServiceClient container = InstrumentClient(new BlobServiceClient(
                connectionString));
            Assert.IsTrue(container.CanGenerateAccountSasUri);

            // Act - BlobServiceClient(string connectionString, string blobContainerName, BlobClientOptions options)
            BlobServiceClient container2 = InstrumentClient(new BlobServiceClient(
                connectionString,
                GetOptions()));
            Assert.IsTrue(container2.CanGenerateAccountSasUri);

            // Act - BlobServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            BlobServiceClient container3 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(container3.CanGenerateAccountSasUri);

            // Act - BlobServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            BlobServiceClient container4 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(container4.CanGenerateAccountSasUri);

            // Act - BlobServiceClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            BlobServiceClient container5 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.IsFalse(container5.CanGenerateAccountSasUri);
        }

        [Test]
        public void CanGenerateSas_GetContainerClient()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Check if we're passing the SharedKeyCredential correctly to the containerClient
            // Act - BlobServiceClient(string connectionString)
            BlobServiceClient serviceClient = InstrumentClient(new BlobServiceClient(
                connectionString));
            BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(GetNewContainerName());
            Assert.IsTrue(containerClient.CanGenerateSasUri);

            // Act - BlobServiceClient(string connectionString, string blobContainerName, BlobClientOptions options)
            BlobServiceClient serviceClient2 = InstrumentClient(new BlobServiceClient(
                connectionString,
                GetOptions()));
            BlobContainerClient containerClient2 = serviceClient2.GetBlobContainerClient(GetNewContainerName());
            Assert.IsTrue(containerClient2.CanGenerateSasUri);

            // Act - BlobServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            BlobServiceClient serviceClient3 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                GetOptions()));
            BlobContainerClient containerClient3 = serviceClient3.GetBlobContainerClient(GetNewContainerName());
            Assert.IsFalse(containerClient3.CanGenerateSasUri);

            // Act - BlobServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            BlobServiceClient serviceClient4 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            BlobContainerClient containerClient4 = serviceClient4.GetBlobContainerClient(GetNewContainerName());
            Assert.IsTrue(containerClient4.CanGenerateSasUri);

            // Act - BlobServiceClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            BlobServiceClient serviceClient5 = InstrumentClient(new BlobServiceClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            BlobContainerClient containerClient5 = serviceClient5.GetBlobContainerClient(GetNewContainerName());
            Assert.IsFalse(containerClient5.CanGenerateSasUri);
        }

        [Test]
        public void GenerateAccountSas_RequiredParameters()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            BlobServiceClient serviceClient = InstrumentClient(new BlobServiceClient(connectionString, GetOptions()));

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(
                permissions: permissions,
                expiresOn: expiresOn,
                resourceTypes: resourceTypes);

            // Assert
            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, AccountSasServices.Blobs, resourceTypes);
            UriBuilder expectedUri = new UriBuilder(blobEndpoint);
            expectedUri.Query += sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateAccountSas_Builder()
        {
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Blobs;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            BlobServiceClient serviceClient = InstrumentClient(new BlobServiceClient(connectionString, GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None),
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(sasBuilder);

            // Assert
            UriBuilder expectedUri = new UriBuilder(blobEndpoint);
            expectedUri.Query += sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateAccountSas_WrongService_Service()
        {
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Files; // Wrong Service
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            BlobServiceClient serviceClient = InstrumentClient(new BlobServiceClient(connectionString, GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None),
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            // Act
            try
            {
                Uri sasUri = serviceClient.GenerateAccountSasUri(sasBuilder);

                Assert.Fail("BlobContainerClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                // the correct exception came back
            }
        }
        #endregion
    }
}
