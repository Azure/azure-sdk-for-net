// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Queues.Test
{
    [NonParallelizable]
    public class ServiceClientTests : QueueTestBase
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
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri(TestConfigPremiumBlob.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new QueueServiceClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
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

        [Test]
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

        [Test]
        public async Task GetQueuesAsync()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            IList<QueueItem> queues = await service.GetQueuesAsync().ToListAsync();
            Assert.IsTrue(queues.Count >= 1);

            var accountName = new QueueUriBuilder(service.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
        }

        [Test]
        public async Task GetQueuesAsync_Marker()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            var marker = default(string);
            var queues = new List<QueueItem>();
            await foreach (Page<QueueItem> page in service.GetQueuesAsync().AsPages(marker))
            {
                queues.AddRange(page.Values);
            }

            Assert.AreNotEqual(0, queues.Count);
            Assert.AreEqual(queues.Count, queues.Select(c => c.Name).Distinct().Count());
            Assert.IsTrue(queues.Any(c => test.Queue.Uri == InstrumentClient(service.GetQueueClient(c.Name)).Uri));
        }

        [Test]
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

        [Test]
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

        [Test]
        public async Task GetQueuesAsync_Metadata()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            IDictionary<string, string> metadata = BuildMetadata();
            await test.Queue.SetMetadataAsync(metadata);
            QueueItem first = await service.GetQueuesAsync(QueueTraits.Metadata).FirstAsync();
            Assert.IsNotNull(first.Metadata);
        }

        [Test]
        [AsyncOnly]
        public async Task GetQueuesAsync_Error()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetQueuesAsync().AsPages(continuationToken: "garbage").FirstAsync(),
                e => Assert.AreEqual("OutOfRangeInput", e.ErrorCode));
        }

        #region Secondary Storage
        [Test]
        public async Task GetQueuesAsync_SecondaryStorageFirstRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(1); // one GET failure means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageFirstRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [Test]
        public async Task GetQueuesAsync_SecondaryStorageSecondRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(2); // two GET failures means the GET request should end up using the PRIMARY host
            AssertSecondaryStorageSecondRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [Test]
        public async Task GetQueuesAsync_SecondaryStorageThirdRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(3); // three GET failures means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageThirdRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [Test]
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
        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<QueueServiceProperties> response = await service.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.Logging.RetentionPolicy);
        }

        [Test]
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
        [Test]
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

        [Test]
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

        [Test]
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
        [Test]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = new TestConstants(this);
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

        [Test]
        public void CanGenerateSas_GetQueueClient()
        {
            // Arrange
            var constants = new TestConstants(this);
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

        [Test]
        public void GenerateAccountSas_RequiredParameters()
        {
            // Arrange
            var constants = new TestConstants(this);
            var queueEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var queueSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, queueStorageUri: (queueEndpoint, queueSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            QueueServiceClient serviceClient = InstrumentClient(new QueueServiceClient(connectionString, GetOptions()));

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(
                permissions: permissions,
                expiresOn: expiresOn,
                resourceTypes: resourceTypes);

            // Assert
            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, AccountSasServices.Queues, resourceTypes);
            UriBuilder expectedUri = new UriBuilder(queueEndpoint)
            {
                Query = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString()
            };
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateAccountSas_Builder()
        {
            var constants = new TestConstants(this);
            var queueEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var queueSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, queueStorageUri: (queueEndpoint, queueSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            AccountSasServices services = AccountSasServices.Queues;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            QueueServiceClient serviceClient = InstrumentClient(new QueueServiceClient(connectionString, GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                StartsOn = startsOn
            };
            // Add more properties on the builder
            sasBuilder.SetPermissions(permissions);

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(sasBuilder);

            // Assert
            AccountSasBuilder sasBuilder2 = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                StartsOn = startsOn
            };
            UriBuilder expectedUri = new UriBuilder(queueEndpoint);
            expectedUri.Query += sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateAccountSas_WrongService_Service()
        {
            var constants = new TestConstants(this);
            var queueEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var queueSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, queueStorageUri: (queueEndpoint, queueSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Blobs; // Wrong Service
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            QueueServiceClient serviceClient = InstrumentClient(new QueueServiceClient(connectionString, GetOptions()));

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
