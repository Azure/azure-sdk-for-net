// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Queues.Test
{
    [NonParallelizable]
    public class ServiceClientTests : QueueTestBase
    {
        public ServiceClientTests(bool async, QueueClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }
        [RecordedTest]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var queueEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var queueSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, queueStorageUri: (queueEndpoint, queueSecondaryEndpoint));

            QueueServiceClient client1 = InstrumentClient(new QueueServiceClient(connectionString.ToString(true), GetOptions()));

            QueueServiceClient client2 = InstrumentClient(new QueueServiceClient(connectionString.ToString(true)));

            var builder1 = new QueueUriBuilder(client1.Uri);
            var builder2 = new QueueUriBuilder(client2.Uri);
            Assert.IsEmpty(builder1.QueueName);
            Assert.AreEqual(accountName, builder1.AccountName);
            Assert.IsEmpty(builder2.QueueName);
            Assert.AreEqual(accountName, builder2.AccountName);
        }

        [Test]
        public void Ctor_ConnectionString_CustomUri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var fileEndpoint = new Uri("http://customdomain/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://customdomain/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            QueueServiceClient service = new QueueServiceClient(connectionString.ToString(true));

            Assert.AreEqual(accountName, service.AccountName);
        }

        [RecordedTest]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri(Tenants.TestConfigPremiumBlob.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new QueueServiceClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [RecordedTest]
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var queueEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);

            QueueServiceClient service = InstrumentClient(new QueueServiceClient(queueEndpoint, credentials));
            var builder = new QueueUriBuilder(service.Uri);

            Assert.IsEmpty(builder.QueueName);
            Assert.AreEqual(accountName, builder.AccountName);
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var queueEndpoint = new Uri($"https://customdomain/");

            QueueServiceClient service = new QueueServiceClient(queueEndpoint, credentials);

            Assert.AreEqual(accountName, service.AccountName);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials(resourceTypes: AccountSasResourceTypes.Service).ToString();
            await using DisposingQueue test = await GetTestQueueAsync();
            Uri uri = GetServiceClient_SharedKey().Uri;

            // Act
            var sasClient = InstrumentClient(new QueueServiceClient(uri, new AzureSasCredential(sas), GetOptions()));
            QueueServiceProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
        }

        [RecordedTest]
        public void Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            Uri uri = GetServiceClient_SharedKey().Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new QueueClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Act - Create new Queue client with the OAuth Credential and Audience
            QueueClientOptions options = GetOptionsWithAudience(QueueAudience.PublicAudience);

            QueueServiceClient aadService = InstrumentClient(new QueueServiceClient(
                new Uri(Tenants.TestConfigOAuth.QueueServiceEndpoint),
                TestEnvironment.Credential,
                options));

            // Assert
            Response<QueueServiceProperties> properties = await aadService.GetPropertiesAsync();
            Assert.IsNotNull(properties);
        }

        [RecordedTest]
        public async Task Ctor_CustomAudience()
        {
            // Arrange
            QueueUriBuilder uriBuilder = new QueueUriBuilder(new Uri(Tenants.TestConfigOAuth.QueueServiceEndpoint));

            // Act - Create new Queue client with the OAuth Credential and Audience
            QueueClientOptions options = GetOptionsWithAudience(new QueueAudience($"https://{uriBuilder.AccountName}.queue.core.windows.net/"));

            QueueServiceClient aadService = InstrumentClient(new QueueServiceClient(
                new Uri(Tenants.TestConfigOAuth.QueueServiceEndpoint),
                TestEnvironment.Credential,
                options));

            // Assert
            Response<QueueServiceProperties> properties = await aadService.GetPropertiesAsync();
            Assert.IsNotNull(properties);
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            QueueUriBuilder uriBuilder = new QueueUriBuilder(new Uri(Tenants.TestConfigOAuth.QueueServiceEndpoint));

            // Act - Create new Queue client with the OAuth Credential and Audience
            QueueClientOptions options = GetOptionsWithAudience(QueueAudience.CreateQueueServiceAccountAudience(uriBuilder.AccountName));

            QueueServiceClient aadService = InstrumentClient(new QueueServiceClient(
                new Uri(Tenants.TestConfigOAuth.QueueServiceEndpoint),
                TestEnvironment.Credential,
                options));

            // Assert
            Response<QueueServiceProperties> properties = await aadService.GetPropertiesAsync();
            Assert.IsNotNull(properties);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Act - Create new Queue client with the OAuth Credential and Audience
            QueueClientOptions options = GetOptionsWithAudience(new QueueAudience("https://badaudience.queue.core.windows.net"));

            QueueServiceClient aadContainer = InstrumentClient(new QueueServiceClient(
                new Uri(Tenants.TestConfigOAuth.QueueServiceEndpoint),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadContainer.GetPropertiesAsync(),
                e => Assert.AreEqual("InvalidAuthenticationInfo", e.ErrorCode));
        }

        [RecordedTest]
        public async Task GetQueuesAsync()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            IList<QueueItem> queues = await service.GetQueuesAsync().ToListAsync();
            Assert.IsTrue(queues.Count >= 1);

            var accountName = new QueueUriBuilder(service.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
        }

        [RecordedTest]
        public async Task GetQueuesAsync_Marker()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            var continuationToken = default(string);
            var queues = new List<QueueItem>();
            await foreach (Page<QueueItem> page in service.GetQueuesAsync().AsPages(continuationToken))
            {
                queues.AddRange(page.Values);
                continuationToken = page.ContinuationToken;
            }

            Assert.AreNotEqual(0, queues.Count);
            Assert.AreEqual(queues.Count, queues.Select(c => c.Name).Distinct().Count());
            Assert.IsTrue(queues.Any(c => test.Queue.Uri == InstrumentClient(service.GetQueueClient(c.Name)).Uri));
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetQueuesAsync_MaxResults()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await using DisposingQueue test1 = await GetTestQueueAsync(service);
            await using DisposingQueue test2 = await GetTestQueueAsync(service);

            Page<QueueItem> page = await
                service.GetQueuesAsync()
                .AsPages(pageSizeHint: 1)
                .FirstAsync();
            Assert.AreEqual(1, page.Values.Count);
        }

        [RecordedTest]
        public async Task GetQueuesAsync_Prefix()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            var prefix = "aaa";
            var queueName = prefix + GetNewQueueName();
            QueueClient queue = (await service.CreateQueueAsync(queueName)).Value; // Ensure at least one queue
            try
            {
                AsyncPageable<QueueItem> queues = service.GetQueuesAsync(prefix: prefix);
                IList<QueueItem> items = await queues.ToListAsync();

                Assert.AreNotEqual(0, items.Count());
                Assert.IsTrue(items.All(c => c.Name.StartsWith(prefix)));
                Assert.IsNotNull(items.Single(c => c.Name == queueName));
            }
            finally
            {
                await service.DeleteQueueAsync(queueName);
            }
        }

        [RecordedTest]
        public async Task GetQueuesAsync_Metadata()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            IDictionary<string, string> metadata = BuildMetadata();
            await test.Queue.SetMetadataAsync(metadata);
            QueueItem first = await service.GetQueuesAsync(QueueTraits.Metadata).FirstAsync();
            Assert.IsNotNull(first.Metadata);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetQueuesAsync_Error()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetQueuesAsync().AsPages(continuationToken: "garbage").FirstAsync(),
                e => Assert.AreEqual("OutOfRangeInput", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetUserDelegatioKey()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_OAuth();

            // Act
            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(expiresOn: Recording.UtcNow.AddHours(1));

            // Assert
            Assert.IsNotNull(response.Value);
        }

        [RecordedTest]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetUserDelegationKeyAsync(expiresOn: Recording.UtcNow.AddHours(1)),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetUserDelegationKey_ArgumentException()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_OAuth();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                service.GetUserDelegationKeyAsync(
                    // ensure the time used is not UTC, as DateTimeOffset.Now could actually be UTC based on OS settings
                    // Use a custom time zone so we aren't dependent on OS having specific standard time zone.
                    expiresOn: TimeZoneInfo.ConvertTime(
                        Recording.Now.AddHours(1),
                        TimeZoneInfo.CreateCustomTimeZone("Storage Test Custom Time Zone", TimeSpan.FromHours(-3), "CTZ", "CTZ"))),
                e => Assert.AreEqual("expiresOn must be UTC", e.Message));
            ;
        }

        #region Secondary Storage
        [RecordedTest]
        public async Task GetQueuesAsync_SecondaryStorageFirstRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(1); // one GET failure means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageFirstRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [RecordedTest]
        public async Task GetQueuesAsync_SecondaryStorageSecondRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(2); // two GET failures means the GET request should end up using the PRIMARY host
            AssertSecondaryStorageSecondRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [RecordedTest]
        public async Task GetQueuesAsync_SecondaryStorageThirdRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(3); // three GET failures means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageThirdRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [RecordedTest]
        public async Task GetQueuesAsync_SecondaryStorage404OnSecondary()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(3, true);  // three GET failures + 404 on SECONDARY host means the GET request should end up using the PRIMARY host
            AssertSecondaryStorage404OnSecondary(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        private async Task<TestExceptionPolicy> PerformSecondaryStorageTest(int numberOfReadFailuresToSimulate, bool retryOn404 = false)
        {
            QueueServiceClient service = GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, retryOn404);
            await using DisposingQueue test = await GetTestQueueAsync(service);

            IList<QueueItem> queues = await EnsurePropagatedAsync(
                async () => await service.GetQueuesAsync().ToListAsync(),
                queues => queues.Count > 0);

            return testExceptionPolicy;
        }
        #endregion

        #region GetProperties
        [RecordedTest]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<QueueServiceProperties> response = await service.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.Logging.RetentionPolicy);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            QueueServiceClient service = InstrumentClient(
                new QueueServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetPropertiesAsync(),
                e => { });
        }
        #endregion

        #region SetProperties
        [RecordedTest]
        public async Task SetPropertiesAsync()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueServiceProperties originalProperties = await service.GetPropertiesAsync();
            QueueServiceProperties properties = GetQueueServiceProperties();

            // Act
            await service.SetPropertiesAsync(properties);

            // Assert
            QueueServiceProperties responseProperties = await service.GetPropertiesAsync();
            Assert.AreEqual(properties.Cors.Count, responseProperties.Cors.Count);
            Assert.AreEqual(properties.Cors[0].AllowedHeaders, responseProperties.Cors[0].AllowedHeaders);
            Assert.AreEqual(properties.Cors[0].AllowedMethods, responseProperties.Cors[0].AllowedMethods);
            Assert.AreEqual(properties.Cors[0].AllowedOrigins, responseProperties.Cors[0].AllowedOrigins);
            Assert.AreEqual(properties.Cors[0].ExposedHeaders, responseProperties.Cors[0].ExposedHeaders);
            Assert.AreEqual(properties.Cors[0].MaxAgeInSeconds, responseProperties.Cors[0].MaxAgeInSeconds);
            Assert.AreEqual(properties.Logging.Read, responseProperties.Logging.Read);
            Assert.AreEqual(properties.Logging.Write, responseProperties.Logging.Write);
            Assert.AreEqual(properties.Logging.Delete, responseProperties.Logging.Delete);
            Assert.AreEqual(properties.Logging.Version, responseProperties.Logging.Version);
            Assert.AreEqual(properties.Logging.RetentionPolicy.Days, responseProperties.Logging.RetentionPolicy.Days);
            Assert.AreEqual(properties.Logging.RetentionPolicy.Enabled, responseProperties.Logging.RetentionPolicy.Enabled);
            Assert.AreEqual(properties.HourMetrics.Enabled, responseProperties.HourMetrics.Enabled);
            Assert.AreEqual(properties.HourMetrics.IncludeApis, responseProperties.HourMetrics.IncludeApis);
            Assert.AreEqual(properties.HourMetrics.Version, responseProperties.HourMetrics.Version);
            Assert.AreEqual(properties.HourMetrics.RetentionPolicy.Days, responseProperties.HourMetrics.RetentionPolicy.Days);
            Assert.AreEqual(properties.HourMetrics.RetentionPolicy.Enabled, responseProperties.HourMetrics.RetentionPolicy.Enabled);
            Assert.AreEqual(properties.MinuteMetrics.Enabled, responseProperties.MinuteMetrics.Enabled);
            Assert.AreEqual(properties.MinuteMetrics.IncludeApis, responseProperties.MinuteMetrics.IncludeApis);
            Assert.AreEqual(properties.MinuteMetrics.Version, responseProperties.MinuteMetrics.Version);
            Assert.AreEqual(properties.MinuteMetrics.RetentionPolicy.Days, responseProperties.MinuteMetrics.RetentionPolicy.Days);
            Assert.AreEqual(properties.MinuteMetrics.RetentionPolicy.Enabled, responseProperties.MinuteMetrics.RetentionPolicy.Enabled);

            // Clean Up
            await service.SetPropertiesAsync(originalProperties);
        }

        [RecordedTest]
        public async Task SetPropertiesAsync_ExistingProperties()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueServiceProperties properties = await service.GetPropertiesAsync();
            QueueCorsRule[] originalCors = properties.Cors.ToArray();
            properties.Cors =
                new[]
                {
                    new QueueCorsRule
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

        [RecordedTest]
        public async Task SetPropertiesAsync_Error()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueServiceProperties properties = (await service.GetPropertiesAsync()).Value;
            QueueServiceClient invalidService = InstrumentClient(
                new QueueServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                invalidService.SetPropertiesAsync(properties),
                e => { });
        }
        #endregion

        #region GenerateSasTests
        [RecordedTest]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, queueStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - QueueServiceClient(string connectionString)
            QueueServiceClient serviceClient = InstrumentClient(new QueueServiceClient(
                connectionString));
            Assert.IsTrue(serviceClient.CanGenerateAccountSasUri);

            // Act - QueueServiceClient(string connectionString, string blobContainerName, BlobClientOptions options)
            QueueServiceClient serviceClient2 = InstrumentClient(new QueueServiceClient(
                connectionString,
                GetOptions()));
            Assert.IsTrue(serviceClient2.CanGenerateAccountSasUri);

            // Act - QueueServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            QueueServiceClient serviceClient3 = InstrumentClient(new QueueServiceClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(serviceClient3.CanGenerateAccountSasUri);

            // Act - QueueServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            QueueServiceClient serviceClient4 = InstrumentClient(new QueueServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(serviceClient4.CanGenerateAccountSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_GetQueueClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, queueStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - QueueServiceClient(string connectionString)
            QueueServiceClient serviceClient = InstrumentClient(new QueueServiceClient(
                connectionString));
            QueueClient queueClient = serviceClient.GetQueueClient(GetNewQueueName());
            Assert.IsTrue(queueClient.CanGenerateSasUri);

            // Act - QueueServiceClient(string connectionString, string blobContainerName, BlobClientOptions options)
            QueueServiceClient serviceClient2 = InstrumentClient(new QueueServiceClient(
                connectionString,
                GetOptions()));
            QueueClient queueClient2 = serviceClient2.GetQueueClient(GetNewQueueName());
            Assert.IsTrue(queueClient2.CanGenerateSasUri);

            // Act - QueueServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            QueueServiceClient serviceClient3 = InstrumentClient(new QueueServiceClient(
                blobEndpoint,
                GetOptions()));
            QueueClient queueClient3 = serviceClient3.GetQueueClient(GetNewQueueName());
            Assert.IsFalse(queueClient3.CanGenerateSasUri);

            // Act - QueueServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            QueueServiceClient serviceClient4 = InstrumentClient(new QueueServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            QueueClient queueClient4 = serviceClient4.GetQueueClient(GetNewQueueName());
            Assert.IsTrue(queueClient4.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateAccountSas_Mockable()
        {
            // Act
            var directory = new Mock<QueueServiceClient>();
            directory.Setup(x => x.CanGenerateAccountSasUri).Returns(false);

            // Assert
            Assert.IsFalse(directory.Object.CanGenerateAccountSasUri);

            // Act
            directory.Setup(x => x.CanGenerateAccountSasUri).Returns(true);

            // Assert
            Assert.IsTrue(directory.Object.CanGenerateAccountSasUri);
        }

        [RecordedTest]
        public void GenerateAccountSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.queue.core.windows.net");
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            QueueServiceClient serviceClient = InstrumentClient(
                new QueueServiceClient(
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
            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, AccountSasServices.Queues, resourceTypes);
            UriBuilder expectedUri = new UriBuilder(serviceUri)
            {
                Query = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString()
            };
            Assert.AreEqual(expectedUri.Uri, sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateAccountSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.queue.core.windows.net");
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Queues;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            QueueServiceClient serviceClient = InstrumentClient(
                new QueueServiceClient(
                    serviceUri,
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes);

            // Add more properties on the builder
            sasBuilder.SetPermissions(permissions);

            string stringToSign = null;

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(sasBuilder, out stringToSign);

            // Assert
            AccountSasBuilder sasBuilder2 = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes);
            UriBuilder expectedUri = new UriBuilder(serviceUri);
            expectedUri.Query += sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.AreEqual(expectedUri.Uri, sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateAccountSas_WrongService_Service()
        {
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.queue.core.windows.net");
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Blobs; // Wrong Service
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            QueueServiceClient serviceClient = InstrumentClient(
                new QueueServiceClient(
                    serviceUri,
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes);

            // Act
            TestHelper.AssertExpectedException(
                () => serviceClient.GenerateAccountSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. builder.Services does specify Queues. builder.Services must either specify Queues or specify all Services are accessible in the value."));
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            TokenCredential mockTokenCredential = new Mock<TokenCredential>().Object;
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<QueueServiceClient>(TestConfigDefault.ConnectionString, new QueueClientOptions()).Object;
            mock = new Mock<QueueServiceClient>(TestConfigDefault.ConnectionString).Object;
            mock = new Mock<QueueServiceClient>(new Uri("https://test/test"), new QueueClientOptions()).Object;
            mock = new Mock<QueueServiceClient>(new Uri("https://test/test"), GetNewSharedKeyCredentials(), new QueueClientOptions()).Object;
            mock = new Mock<QueueServiceClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new QueueClientOptions()).Object;
            mock = new Mock<QueueServiceClient>(new Uri("https://test/test"), mockTokenCredential, new QueueClientOptions()).Object;
        }
    }
}
