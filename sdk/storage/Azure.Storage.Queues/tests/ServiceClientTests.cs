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
            Assert.That(builder1.QueueName, Is.Empty);
            Assert.That(builder1.AccountName, Is.EqualTo(accountName));
            Assert.That(builder2.QueueName, Is.Empty);
            Assert.That(builder2.AccountName, Is.EqualTo(accountName));
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

            Assert.That(service.AccountName, Is.EqualTo(accountName));
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

            Assert.That(builder.QueueName, Is.Empty);
            Assert.That(builder.AccountName, Is.EqualTo(accountName));
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

            Assert.That(service.AccountName, Is.EqualTo(accountName));
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
            Assert.That(properties, Is.Not.Null);
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
            Assert.That(properties, Is.Not.Null);
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
            Assert.That(properties, Is.Not.Null);
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
            Assert.That(properties, Is.Not.Null);
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
                e => Assert.That(e.ErrorCode, Is.EqualTo("InvalidAuthenticationInfo")));
        }

        [RecordedTest]
        public async Task GetQueuesAsync()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            IList<QueueItem> queues = await service.GetQueuesAsync().ToListAsync();
            Assert.That(queues.Count >= 1, Is.True);

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

            Assert.That(queues.Count, Is.Not.EqualTo(0));
            Assert.That(queues.Select(c => c.Name).Distinct().Count(), Is.EqualTo(queues.Count));
            Assert.That(queues.Any(c => test.Queue.Uri == InstrumentClient(service.GetQueueClient(c.Name)).Uri), Is.True);
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
            Assert.That(page.Values.Count, Is.EqualTo(1));
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

                Assert.That(items.Count(), Is.Not.EqualTo(0));
                Assert.That(items.All(c => c.Name.StartsWith(prefix)), Is.True);
                Assert.That(items.Single(c => c.Name == queueName), Is.Not.Null);
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
            Assert.That(first.Metadata, Is.Not.Null);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetQueuesAsync_Error()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetQueuesAsync().AsPages(continuationToken: "garbage").FirstAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("OutOfRangeInput")));
        }

        [RecordedTest]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetUserDelegatioKey()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_OAuth();

            // Act
            QueueGetUserDelegationKeyOptions options = new QueueGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(
                options: options);

            // Assert
            Assert.That(response.Value, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_SharedKey();

            // Act
            QueueGetUserDelegationKeyOptions options = new QueueGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetUserDelegationKeyAsync(options: options),
                e => Assert.That(e.ErrorCode, Is.EqualTo("AuthenticationFailed")));
        }

        [RecordedTest]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetUserDelegationKey_ArgumentException()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_OAuth();

            // Act
            QueueGetUserDelegationKeyOptions options = new QueueGetUserDelegationKeyOptions(
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
            Assert.That(response.Value.Logging.RetentionPolicy, Is.Not.Null);
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
            Assert.That(responseProperties.Cors.Count, Is.EqualTo(properties.Cors.Count));
            Assert.That(responseProperties.Cors[0].AllowedHeaders, Is.EqualTo(properties.Cors[0].AllowedHeaders));
            Assert.That(responseProperties.Cors[0].AllowedMethods, Is.EqualTo(properties.Cors[0].AllowedMethods));
            Assert.That(responseProperties.Cors[0].AllowedOrigins, Is.EqualTo(properties.Cors[0].AllowedOrigins));
            Assert.That(responseProperties.Cors[0].ExposedHeaders, Is.EqualTo(properties.Cors[0].ExposedHeaders));
            Assert.That(responseProperties.Cors[0].MaxAgeInSeconds, Is.EqualTo(properties.Cors[0].MaxAgeInSeconds));
            Assert.That(responseProperties.Logging.Read, Is.EqualTo(properties.Logging.Read));
            Assert.That(responseProperties.Logging.Write, Is.EqualTo(properties.Logging.Write));
            Assert.That(responseProperties.Logging.Delete, Is.EqualTo(properties.Logging.Delete));
            Assert.That(responseProperties.Logging.Version, Is.EqualTo(properties.Logging.Version));
            Assert.That(responseProperties.Logging.RetentionPolicy.Days, Is.EqualTo(properties.Logging.RetentionPolicy.Days));
            Assert.That(responseProperties.Logging.RetentionPolicy.Enabled, Is.EqualTo(properties.Logging.RetentionPolicy.Enabled));
            Assert.That(responseProperties.HourMetrics.Enabled, Is.EqualTo(properties.HourMetrics.Enabled));
            Assert.That(responseProperties.HourMetrics.IncludeApis, Is.EqualTo(properties.HourMetrics.IncludeApis));
            Assert.That(responseProperties.HourMetrics.Version, Is.EqualTo(properties.HourMetrics.Version));
            Assert.That(responseProperties.HourMetrics.RetentionPolicy.Days, Is.EqualTo(properties.HourMetrics.RetentionPolicy.Days));
            Assert.That(responseProperties.HourMetrics.RetentionPolicy.Enabled, Is.EqualTo(properties.HourMetrics.RetentionPolicy.Enabled));
            Assert.That(responseProperties.MinuteMetrics.Enabled, Is.EqualTo(properties.MinuteMetrics.Enabled));
            Assert.That(responseProperties.MinuteMetrics.IncludeApis, Is.EqualTo(properties.MinuteMetrics.IncludeApis));
            Assert.That(responseProperties.MinuteMetrics.Version, Is.EqualTo(properties.MinuteMetrics.Version));
            Assert.That(responseProperties.MinuteMetrics.RetentionPolicy.Days, Is.EqualTo(properties.MinuteMetrics.RetentionPolicy.Days));
            Assert.That(responseProperties.MinuteMetrics.RetentionPolicy.Enabled, Is.EqualTo(properties.MinuteMetrics.RetentionPolicy.Enabled));

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
            Assert.That(properties.Cors.Count(), Is.EqualTo(1));
            Assert.That(properties.Cors[0].MaxAgeInSeconds, Is.EqualTo(1000));

            // Cleanup
            properties.Cors = originalCors;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.Cors.Count(), Is.EqualTo(originalCors.Count()));
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
            Assert.That(serviceClient.CanGenerateAccountSasUri, Is.True);

            // Act - QueueServiceClient(string connectionString, string blobContainerName, BlobClientOptions options)
            QueueServiceClient serviceClient2 = InstrumentClient(new QueueServiceClient(
                connectionString,
                GetOptions()));
            Assert.That(serviceClient2.CanGenerateAccountSasUri, Is.True);

            // Act - QueueServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            QueueServiceClient serviceClient3 = InstrumentClient(new QueueServiceClient(
                blobEndpoint,
                GetOptions()));
            Assert.That(serviceClient3.CanGenerateAccountSasUri, Is.False);

            // Act - QueueServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            QueueServiceClient serviceClient4 = InstrumentClient(new QueueServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.That(serviceClient4.CanGenerateAccountSasUri, Is.True);
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
            Assert.That(queueClient.CanGenerateSasUri, Is.True);

            // Act - QueueServiceClient(string connectionString, string blobContainerName, BlobClientOptions options)
            QueueServiceClient serviceClient2 = InstrumentClient(new QueueServiceClient(
                connectionString,
                GetOptions()));
            QueueClient queueClient2 = serviceClient2.GetQueueClient(GetNewQueueName());
            Assert.That(queueClient2.CanGenerateSasUri, Is.True);

            // Act - QueueServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            QueueServiceClient serviceClient3 = InstrumentClient(new QueueServiceClient(
                blobEndpoint,
                GetOptions()));
            QueueClient queueClient3 = serviceClient3.GetQueueClient(GetNewQueueName());
            Assert.That(queueClient3.CanGenerateSasUri, Is.False);

            // Act - QueueServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            QueueServiceClient serviceClient4 = InstrumentClient(new QueueServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            QueueClient queueClient4 = serviceClient4.GetQueueClient(GetNewQueueName());
            Assert.That(queueClient4.CanGenerateSasUri, Is.True);
        }

        [RecordedTest]
        public void CanGenerateAccountSas_Mockable()
        {
            // Act
            var directory = new Mock<QueueServiceClient>();
            directory.Setup(x => x.CanGenerateAccountSasUri).Returns(false);

            // Assert
            Assert.That(directory.Object.CanGenerateAccountSasUri, Is.False);

            // Act
            directory.Setup(x => x.CanGenerateAccountSasUri).Returns(true);

            // Assert
            Assert.That(directory.Object.CanGenerateAccountSasUri, Is.True);
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
            Assert.That(sasUri, Is.EqualTo(expectedUri.Uri));
            Assert.That(stringToSign, Is.Not.Null);
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
            Assert.That(sasUri, Is.EqualTo(expectedUri.Uri));
            Assert.That(stringToSign, Is.Not.Null);
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
