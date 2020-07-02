// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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
    public class ContainerClientTests : BlobTestBase
    {
        public ContainerClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_02_02)]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

            var containerName = "containername";

            BlobContainerClient container = InstrumentClient(new BlobContainerClient(connectionString.ToString(true), containerName));

            var builder = new BlobUriBuilder(container.Uri);

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual("", builder.BlobName);
            Assert.AreEqual(accountName, builder.AccountName);
        }

        [Test]
        [TestCase(true)] // https://github.com/Azure/azure-sdk-for-net/issues/9110
        [TestCase(false)]
        public async Task Perform_Ctor_ConnectionString_Sas(bool includeTable)
        {
            // Arrange
            SharedAccessSignatureCredentials sasCred = GetAccountSasCredentials(
                AccountSasServices.All,
                AccountSasResourceTypes.All,
                AccountSasPermissions.All);

            StorageConnectionString conn1 = GetConnectionString(
                credentials: sasCred,
                includeEndpoint: true,
                includeTable: includeTable);

            BlobContainerClient containerClient1 = GetBlobContainerClient(conn1.ToString(exportSecrets: true));

            // Also test with a connection string not containing the blob endpoint.
            // This should still work provided account name and Sas credential are present.
            StorageConnectionString conn2 = GetConnectionString(
                credentials: sasCred,
                includeEndpoint: false);

            BlobContainerClient containerClient2 = GetBlobContainerClient(conn2.ToString(exportSecrets: true));

            try
            {
                // Act
                await containerClient1.CreateAsync();
                BlobClient blob1 = InstrumentClient(containerClient1.GetBlobClient(GetNewBlobName()));

                await containerClient2.CreateAsync();
                BlobClient blob2 = InstrumentClient(containerClient2.GetBlobClient(GetNewBlobName()));

                var data = GetRandomBuffer(Constants.KB);

                Response<BlobContentInfo> info1 = await blob1.UploadAsync(
                    new MemoryStream(data),
                    true,
                    new CancellationToken());
                Response<BlobContentInfo> info2 = await blob2.UploadAsync(
                    new MemoryStream(data),
                    true,
                    new CancellationToken());

                // Assert
                Assert.IsNotNull(info1.Value.ETag);
                Assert.IsNotNull(info2.Value.ETag);
            }
            finally
            {
                // Clean up
                await containerClient1.DeleteAsync();
                await containerClient2.DeleteAsync();
            }
        }

        [Test]
        public async Task Ctor_ConnectionString_Sas_Resource_Types_Container()
        {
            // Arrange
            SharedAccessSignatureCredentials sasCred = GetAccountSasCredentials(
                AccountSasServices.All,
                AccountSasResourceTypes.Container,
                AccountSasPermissions.All);

            StorageConnectionString conn = GetConnectionString(credentials: sasCred);

            BlobContainerClient containerClient = GetBlobContainerClient(conn.ToString(exportSecrets: true));

            try
            {
                // Act
                // This should succeed as we have Container resourceType permission
                await containerClient.CreateAsync();

                BlobClient blob = InstrumentClient(containerClient.GetBlobClient(GetNewBlobName()));

                var data = GetRandomBuffer(Constants.KB);

                // This should throw as we do not have Object permission
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.UploadAsync(new MemoryStream(data)),
                    e => Assert.AreEqual("AuthorizationResourceTypeMismatch", e.ErrorCode));
            }
            finally
            {
                // Clean up
                await containerClient.DeleteAsync();
            }
        }

        [Test]
        public async Task Ctor_ConnectionString_Sas_Resource_Types_Service()
        {
            // Arrange
            SharedAccessSignatureCredentials sasCred = GetAccountSasCredentials(
                AccountSasServices.All,
                AccountSasResourceTypes.Service,
                AccountSasPermissions.All);

            StorageConnectionString conn = GetConnectionString(credentials: sasCred);

            BlobContainerClient containerClient = GetBlobContainerClient(conn.ToString(exportSecrets: true));

            // This should throw as we do not have Container permission
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                containerClient.CreateAsync(),
                e => Assert.AreEqual("AuthorizationResourceTypeMismatch", e.ErrorCode));
        }

        [Test]
        public async Task Ctor_ConnectionString_Sas_Permissions_ReadOnly()
        {
            // Arrange
            SharedAccessSignatureCredentials sasCred = GetAccountSasCredentials(
                AccountSasServices.All,
                AccountSasResourceTypes.All,
                AccountSasPermissions.Read);

            StorageConnectionString conn = GetConnectionString(credentials: sasCred);

            BlobContainerClient containerClient = GetBlobContainerClient(conn.ToString(exportSecrets: true));

            // Act

            var data = GetRandomBuffer(Constants.KB);

            // This should throw as we only have read permission
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                containerClient.CreateAsync(),
                e => Assert.AreEqual("AuthorizationPermissionMismatch", e.ErrorCode));
        }

        [Test]
        public async Task Ctor_ConnectionString_Sas_Permissions_WriteOnly()
        {
            // Arrange
            SharedAccessSignatureCredentials sasCred = GetAccountSasCredentials(
                AccountSasServices.All,
                AccountSasResourceTypes.All,
                // include Delete so we can clean up the test
                AccountSasPermissions.Write | AccountSasPermissions.Delete);

            StorageConnectionString conn = GetConnectionString(credentials: sasCred);

            BlobContainerClient containerClient = GetBlobContainerClient(conn.ToString(exportSecrets: true));

            try
            {
                // Act
                await containerClient.CreateAsync();

                BlobClient blob = InstrumentClient(containerClient.GetBlobClient(GetNewBlobName()));

                var data = GetRandomBuffer(Constants.KB);

                // This should throw as we do not have read permission
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.GetPropertiesAsync(),
                    e => Assert.AreEqual("AuthorizationPermissionMismatch", e.ErrorCode));
            }
            finally
            {
                // Clean up
                await containerClient.DeleteAsync();
            }
        }
        private BlobContainerClient GetBlobContainerClient(string connectionString) =>
            InstrumentClient(
                new BlobContainerClient(
                    connectionString,
                    GetNewContainerName(),
                    GetOptions()));

        [Test]
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var blobEndpoint = new Uri("https://127.0.0.1/" + accountName);
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var tokenCredentials = new DefaultAzureCredential();

            BlobContainerClient client1 = InstrumentClient(new BlobContainerClient(blobEndpoint, credentials));
            BlobContainerClient client2 = InstrumentClient(new BlobContainerClient(blobEndpoint));
            BlobContainerClient client3 = InstrumentClient(new BlobContainerClient(blobEndpoint, tokenCredentials));


            Assert.AreEqual(accountName, client1.AccountName);
            Assert.AreEqual(accountName, client2.AccountName);
            Assert.AreEqual(accountName, client3.AccountName);
        }

        [Test]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobContainerClient(httpUri, GetOAuthCredential()),
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
                () => new BlobContainerClient(httpUri, blobClientOptions),
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
                () => new BlobContainerClient(new Uri(TestConfigDefault.BlobServiceEndpoint), blobClientOptions),
                new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set"));
        }

        [Test]
        public async Task CreateAsync_WithSharedKey()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            var containerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            try
            {
                // Act
                Response<BlobContainerInfo> response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                var accountName = new BlobUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => container.AccountName);
                TestHelper.AssertCacheableProperty(containerName, () => container.Name);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithSharedKey_Retry_RequestDateShouldUpdate()
        {
            // Arrange
            BlobClientOptions options = GetOptions();
            var testExceptionPolicy = new TestExceptionPolicy(
                numberOfFailuresToSimulate: 2,
                trackedRequestMethods: new List<RequestMethod>(new RequestMethod[] { RequestMethod.Put }),
                delayBetweenAttempts: 1000);

            options.AddPolicy(testExceptionPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient service = GetServiceClient_SharedKey(options);
            var containerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            try
            {
                // Act
                Response<BlobContainerInfo> response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                Assert.AreEqual(3, testExceptionPolicy.DatesSetInRequests.Count);
                Assert.IsTrue(testExceptionPolicy.DatesSetInRequests[1] > testExceptionPolicy.DatesSetInRequests[0]);
                Assert.IsTrue(testExceptionPolicy.DatesSetInRequests[2] > testExceptionPolicy.DatesSetInRequests[1]);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithOauth()
        {
            // Arrange
            var containerName = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_OauthAccount();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            try
            {
                // Act
                Response<BlobContainerInfo> response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithAccountSas()
        {
            // Arrange
            var containerName = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_AccountSas();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            try
            {
                // Act
                Response<BlobContainerInfo> response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithBlobServiceSas()
        {
            // Arrange
            var containerName = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_BlobServiceSas_Container(containerName);
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));
            var pass = false;

            try
            {
                // Act
                Response<BlobContainerInfo> response = await container.CreateAsync();

                Assert.Fail("CreateAsync unexpected success: blob service SAS should not be usable to create container");
            }
            catch (RequestFailedException se) when (se.ErrorCode == "AuthorizationFailure") // TODO verify if this is a missing error code
            {
                pass = true;
            }
            finally
            {
                if (!pass)
                {
                    await container.DeleteAsync();
                }
            }
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await container.CreateAsync(metadata: metadata);

            // Assert
            Response<BlobContainerProperties> response = await container.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        [Ignore("#10044: Re-enable failing Storage tests")]
        public async Task CreateAsync_EncryptionScopeOptions()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlobContainerEncryptionScopeOptions encryptionScopeOptions = new BlobContainerEncryptionScopeOptions
            {
                DefaultEncryptionScope = TestConfigDefault.EncryptionScope,
                PreventEncryptionScopeOverride  = true
            };

            // Act
            await container.CreateAsync(encryptionScopeOptions: encryptionScopeOptions);

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateAsync_PublicAccess()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await container.CreateAsync(publicAccessType: PublicAccessType.Blob);

            // Assert
            Response<BlobContainerProperties> response = await container.GetPropertiesAsync();
            Assert.AreEqual(PublicAccessType.Blob, response.Value.PublicAccess);

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            // ContainerUri is intentually created twice
            await container.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.CreateAsync(),
                e => Assert.AreEqual("ContainerAlreadyExists", e.ErrorCode));

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateIfNotExistsAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await container.CreateIfNotExistsAsync();

            // Assert
            Response<BlobContainerProperties> response = await container.GetPropertiesAsync();
            Assert.IsNotNull(response.Value.ETag);

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            // Act
            await container.CreateIfNotExistsAsync();

            // Assert
            Response<BlobContainerProperties> response = await container.GetPropertiesAsync();
            Assert.IsNotNull(response.Value.ETag);

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlobContainerClient unauthorizedContainer = InstrumentClient(new BlobContainerClient(container.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedContainer.CreateIfNotExistsAsync(),
                e => { });
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            // Act
            Response response = await container.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.DeleteAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                parameters.LeaseId = await SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                Response response = await container.DeleteAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        public async Task DeleteAsync_AccessConditions_Conditions_IfMatch_Should_Throw()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();
            var conditions = new BlobRequestConditions()
            {
                IfMatch = new ETag("etag")
            };

            // Act
            await TestHelper.CatchAsync<ArgumentOutOfRangeException>(
                () => container.DeleteAsync(conditions: conditions));
        }

        [Test]
        public async Task DeleteAsync_AccessConditions_Conditions_IfNoneMatch_Should_Throw()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();
            var conditions = new BlobRequestConditions()
            {
                IfNoneMatch = new ETag("etag")
            };

            // Act
            await TestHelper.CatchAsync<ArgumentOutOfRangeException>(
                () => container.DeleteAsync(conditions: conditions));
        }

        [Test]
        public async Task DeleteAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                parameters.LeaseId = await SetupContainerLeaseCondition(test.Container, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.Container.DeleteAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        public async Task DeleteIfExistsAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            // Act
            Response<bool> response = await container.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);

            // Act
            response = await container.DeleteIfExistsAsync();
        }

        [Test]
        public async Task DeleteIfExistsAsync_Exists()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            Response<bool> response = await container.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            // Act
            Response<bool> response = await container.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);

            await container.DeleteAsync();
        }

        [Test]
        public async Task ExistsAsync_NotExists()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            Response<bool> response = await container.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlobContainerClient unauthorizedContainerClient = InstrumentClient(new BlobContainerClient(test.Container.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedContainerClient.ExistsAsync(),
                e => { });
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Act
            Response<BlobContainerProperties> response = await test.Container.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.LastModified);
            Assert.IsNotNull(response.Value.LeaseStatus);
            Assert.IsNotNull(response.Value.LeaseState);
            Assert.IsNotNull(response.Value.LeaseDuration);
            Assert.IsNotNull(response.Value.PublicAccess);
            Assert.IsNotNull(response.Value.HasImmutabilityPolicy);
            Assert.IsNotNull(response.Value.HasLegalHold);
            Assert.IsNotNull(response.Value.ETag);
            Assert.IsNotNull(response.Value.Metadata);

            if (_serviceVersion >= BlobClientOptions.ServiceVersion.V2019_07_07)
            {
                Assert.IsNotNull(response.Value.DefaultEncryptionScope);
                Assert.IsNotNull(response.Value.PreventEncryptionScopeOverride);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.GetPropertiesAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await test.Container.SetMetadataAsync(metadata);

            // Assert
            Response<BlobContainerProperties> response = await test.Container.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] data =
                new[]
                {
                    new AccessConditionParameters(),
                    new AccessConditionParameters { IfModifiedSince = OldDate },
                    new AccessConditionParameters { LeaseId = ReceivedLeaseId }
                };

            // Arrange
            foreach (AccessConditionParameters parameters in data)
            {
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                parameters.LeaseId = await SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                IDictionary<string, string> metadata = BuildMetadata();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: false,
                    lease: true);

                // Act
                Response<BlobContainerInfo> response = await container.SetMetadataAsync(
                    metadata: metadata,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(new BlobRequestConditions { LeaseId = parameters.LeaseId });
            }
        }

        [Test]
        public async Task SetMetadataAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] data = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };
            foreach (AccessConditionParameters parameters in data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: false,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.Container.SetMetadataAsync(
                        metadata: metadata,
                        conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        public async Task GetAccessPolicyAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Act
            Response<BlobContainerAccessPolicy> response = await test.Container.GetAccessPolicyAsync();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetAccessPolicyAsync_Lease()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();
            var garbageLeaseId = GetGarbageLeaseId();
            var leaseId = await SetupContainerLeaseCondition(container, ReceivedLeaseId, garbageLeaseId);
            var leaseAccessConditions = new BlobRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            Response<BlobContainerAccessPolicy> response = await container.GetAccessPolicyAsync(conditions: leaseAccessConditions);

            // Assert
            Assert.IsNotNull(response);

            // Cleanup
            await container.DeleteAsync(conditions: leaseAccessConditions);
        }

        [Test]
        public async Task GetAccessPolicyAsync_LeaseFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var leaseAccessConditions = new BlobRequestConditions
            {
                LeaseId = garbageLeaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                test.Container.GetAccessPolicyAsync(conditions: leaseAccessConditions),
                e => Assert.AreEqual("LeaseNotPresentWithContainerOperation", e.ErrorCode));
        }

        [Test]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.GetAccessPolicyAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetAccessPolicyAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PublicAccessType publicAccessType = PublicAccessType.BlobContainer;
            BlobSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await test.Container.SetAccessPolicyAsync(
                accessType: publicAccessType,
                permissions: signedIdentifiers
            );

            // Assert
            Response<BlobContainerProperties> propertiesResponse = await test.Container.GetPropertiesAsync();
            Assert.AreEqual(publicAccessType, propertiesResponse.Value.PublicAccess);

            Response<BlobContainerAccessPolicy> response = await test.Container.GetAccessPolicyAsync();
            Assert.AreEqual(1, response.Value.SignedIdentifiers.Count());

            BlobSignedIdentifier acl = response.Value.SignedIdentifiers.First();
            Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.StartsOn, acl.AccessPolicy.StartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.ExpiresOn, acl.AccessPolicy.ExpiresOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Permissions, acl.AccessPolicy.Permissions);
        }

        [Test]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlobSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.SetAccessPolicyAsync(permissions: signedIdentifiers),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetAccessPolicyAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                PublicAccessType publicAccessType = PublicAccessType.BlobContainer;
                BlobSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                parameters.LeaseId = await SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                Response<BlobContainerInfo> response = await container.SetAccessPolicyAsync(
                    accessType: publicAccessType,
                    permissions: signedIdentifiers,
                    conditions: accessConditions
                );

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = parameters.LeaseId });
            }
        }

        [Test]
        public async Task SetAccessPolicyAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PublicAccessType publicAccessType = PublicAccessType.BlobContainer;
                BlobSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.Container.SetAccessPolicyAsync(
                        accessType: publicAccessType,
                        permissions: signedIdentifiers,
                        conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        public async Task AcquireLeaseAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            Response<BlobLease> response = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration);

            // Assert
            Assert.AreEqual(id, response.Value.LeaseId);

            // Cleanup
            await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
        }

        [Test]
        public async Task AcquireLeaseAsync_ErrorDurationTooLarge()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.MaxValue;

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration),
                e => StringAssert.Contains("InvalidHeaderValue", e.ErrorCode));
        }

        [Test]
        public async Task AcquireLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task AcquireLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                Response<BlobLease> response = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(
                    duration: duration,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
            }
        }

        [Test]
        public async Task AcquireLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(test.Container.GetBlobLeaseClient(id)).AcquireAsync(
                        duration: duration,
                        conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        public async Task RenewLeaseAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            Response<BlobLease> leaseResponse = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(
                duration: duration);

            // Act
            Response<BlobLease> renewResponse = await InstrumentClient(container.GetBlobLeaseClient(leaseResponse.Value.LeaseId)).RenewAsync();

            // Assert
            Assert.IsNotNull(renewResponse.GetRawResponse().Headers.RequestId);

            // Cleanup
            await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = renewResponse.Value.LeaseId });
        }

        [Test]
        public async Task RenewLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient(id)).ReleaseAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task RenewLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                BlobLeaseClient lease = InstrumentClient(container.GetBlobLeaseClient(id));
                _ = await lease.AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await lease.RenewAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
            }
        }

        [Test]
        public async Task RenewLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                BlobLeaseClient lease = InstrumentClient(container.GetBlobLeaseClient(id));
                Response<BlobLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.RenewAsync(conditions: accessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            Response<BlobLease> leaseResponse = await InstrumentClient(test.Container.GetBlobLeaseClient(id)).AcquireAsync(duration);

            // Act
            Response<ReleasedObjectInfo> releaseResponse = await InstrumentClient(test.Container.GetBlobLeaseClient(leaseResponse.Value.LeaseId)).ReleaseAsync();

            // Assert
            Response<BlobContainerProperties> response = await test.Container.GetPropertiesAsync();

            Assert.AreEqual(LeaseStatus.Unlocked, response.Value.LeaseStatus);
            Assert.AreEqual(LeaseState.Available, response.Value.LeaseState);
        }

        [Test]
        public async Task ReleaseLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient(id)).ReleaseAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                BlobLeaseClient lease = InstrumentClient(test.Container.GetBlobLeaseClient(id));
                Response<BlobLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                BlobLeaseClient lease = InstrumentClient(container.GetBlobLeaseClient(id));
                Response<BlobLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.ReleaseAsync(conditions: accessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [Test]
        public async Task BreakLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            await InstrumentClient(test.Container.GetBlobLeaseClient(id)).AcquireAsync(duration);
            TimeSpan breakPeriod = TimeSpan.FromSeconds(0);

            // Act
            Response<BlobLease> breakResponse = await InstrumentClient(test.Container.GetBlobLeaseClient()).BreakAsync(breakPeriod);

            // Assert
            Response<BlobContainerProperties> response = await test.Container.GetPropertiesAsync();
            Assert.AreEqual(LeaseStatus.Unlocked, response.Value.LeaseStatus);
            Assert.AreEqual(LeaseState.Broken, response.Value.LeaseState);
        }

        [Test]
        public async Task BreakLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient()).BreakAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task BreakLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();

                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<BlobLease> aquireLeaseResponse = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await InstrumentClient(container.GetBlobLeaseClient()).BreakAsync(
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [Test]
        public async Task BreakLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<BlobLease> aquireLeaseResponse = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(container.GetBlobLeaseClient()).BreakAsync(
                        conditions: accessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [Test]
        public async Task ChangeLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            Response<BlobLease> leaseResponse = await InstrumentClient(test.Container.GetBlobLeaseClient(id)).AcquireAsync(duration);
            var newId = Recording.Random.NewGuid().ToString();

            // Act
            Response<BlobLease> changeResponse = await InstrumentClient(test.Container.GetBlobLeaseClient(id)).ChangeAsync(newId);

            // Assert
            Assert.AreEqual(newId, changeResponse.Value.LeaseId);

            // Cleanup
            await InstrumentClient(test.Container.GetBlobLeaseClient(changeResponse.Value.LeaseId)).ReleaseAsync();
        }

        [Test]
        public async Task ChangeLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient(id)).ChangeAsync(id),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ChangeLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();

                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var newId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<BlobLease> aquireLeaseResponse = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await InstrumentClient(container.GetBlobLeaseClient(aquireLeaseResponse.Value.LeaseId)).ChangeAsync(
                    proposedId: newId,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
            }
        }

        [Test]
        public async Task ChangeLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var newId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<BlobLease> aquireLeaseResponse = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(container.GetBlobLeaseClient(aquireLeaseResponse.Value.LeaseId)).ChangeAsync(
                        proposedId: newId,
                        conditions: accessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            // Act
            var blobs = new List<BlobItem>();
            await foreach (Page<BlobItem> page in test.Container.GetBlobsAsync().AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            Assert.AreEqual(BlobNames.Length, blobs.Count);

            var foundBlobNames = blobs.Select(blob => blob.Name).ToArray();

            Assert.IsTrue(BlobNames.All(blobName => foundBlobNames.Contains(blobName)));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsFlatSegmentAsync_Tags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            IDictionary<string, string> tags = BuildTags();
            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Tags = tags
            };
            await appendBlob.CreateAsync(options);

            // Act
            IList<BlobItem> blobItems = await test.Container.GetBlobsAsync(BlobTraits.Tags).ToListAsync();

            // Assert
            AssertDictionaryEquality(tags, blobItems[0].Tags);
            Assert.AreEqual(tags.Count, blobItems[0].Properties.TagCount);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(null)]
        [TestCase(RehydratePriority.Standard)]
        [TestCase(RehydratePriority.High)]
        public async Task ListBlobsFlatSegmentAsync_RehydratePriority(RehydratePriority? rehydratePriority)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlockBlobClient blockBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await blockBlob.UploadAsync(stream);

            if (rehydratePriority.HasValue)
            {
                await blockBlob.SetAccessTierAsync(
                    AccessTier.Archive);

                await blockBlob.SetAccessTierAsync(
                    AccessTier.Hot,
                    rehydratePriority: rehydratePriority.Value);
            }

            // Act
            IList<BlobItem> blobItems = await test.Container.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(rehydratePriority, blobItems[0].Properties.RehydratePriority);
        }

        [Test]
        [AsyncOnly]
        public async Task ListBlobsFlatSegmentAsync_MaxResults()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            // Act
            Page<BlobItem> page = await test.Container.GetBlobsAsync().AsPages(pageSizeHint: 2).FirstAsync();

            // Assert
            Assert.AreEqual(2, page.Values.Count);
            Assert.IsTrue(page.Values.All(b => b.Metadata == null));
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateAsync(metadata: metadata);

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(traits: BlobTraits.Metadata).ToListAsync();

            // Assert
            AssertDictionaryEquality(metadata, blobs.First().Metadata);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ListBlobsFlatSegmentAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));

            await blob.CreateAsync();

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, blobs.First().Properties.EncryptionScope);
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Deleted()
        {
            // Arrange
            BlobServiceClient blobServiceClient = GetServiceClient_SoftDelete();
            await using DisposingContainer test = await GetTestContainerAsync(blobServiceClient);
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            await blob.DeleteAsync();

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(states: BlobStates.Deleted).ToListAsync();

            // Assert
            Assert.AreEqual(blobName, blobs[0].Name);
            Assert.IsTrue(blobs[0].Deleted);
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Uncommited()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);
            var blockId = ToBase64(GetNewBlockName());

            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(
                    base64BlockId: blockId,
                    content: stream);
            }

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(states: BlobStates.Uncommitted).ToListAsync();

            // Assert
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Snapshot()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(states: BlobStates.Snapshots).ToListAsync();

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Snapshot);
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Prefix()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(prefix: "foo").ToListAsync();

            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.GetBlobsAsync().ToListAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_PreservesWhitespace()
        {
            await VerifyBlobNameWhitespaceRoundtrips("    prefix");
            await VerifyBlobNameWhitespaceRoundtrips("suffix    ");
            await VerifyBlobNameWhitespaceRoundtrips("    ");

            async Task VerifyBlobNameWhitespaceRoundtrips(string blobName)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
                await blob.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes("data")));
                BlobItem blobItem = await test.Container.GetBlobsAsync().FirstAsync();
                Assert.AreEqual(blobName, blobItem.Name);
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsFlatSegmentAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);

            // Act
            var blobs = new List<BlobItem>();
            await foreach (Page<BlobItem> page in test.Container.GetBlobsAsync(states: BlobStates.Version).AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.IsNull(blobs[0].IsLatestVersion);
            Assert.AreEqual(createResponse.Value.VersionId, blobs[0].VersionId);
            Assert.IsTrue(blobs[1].IsLatestVersion);
            Assert.AreEqual(setMetadataResponse.Value.VersionId, blobs[1].VersionId);
        }

        [PlaybackOnly("Object Replication policies is only enabled on certain storage accounts")]
        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsFlatSegmentAsync_ObjectReplication()
        {
            // TODO: The tests will temporarily use designated account, containers and blobs to check the
            // existence of OR Metadata
            BlobServiceClient sourceServiceClient = GetServiceClient_SharedKey();

            // This is a recorded ONLY test with a special container we previously setup, as we can't auto setup policies yet
            BlobContainerClient sourceContainer = InstrumentClient(sourceServiceClient.GetBlobContainerClient("test1"));

            // Act
            IList<BlobItem> blobs = await sourceContainer.GetBlobsAsync().ToListAsync();

            // Assert
            // Since this is a PLAYBACK ONLY test. We expect all the blobs in this source container/account
            // to have OrMetadata
            Assert.IsNotNull(blobs.First().ObjectReplicationSourceProperties);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            var blobs = new List<BlobItem>();
            var prefixes = new List<string>();
            var delimiter = "/";

            await foreach (Page<BlobHierarchyItem> page in test.Container.GetBlobsByHierarchyAsync(delimiter: delimiter).AsPages())
            {
                blobs.AddRange(page.Values.Where(item => item.IsBlob).Select(item => item.Blob));
                prefixes.AddRange(page.Values.Where(item => item.IsPrefix).Select(item => item.Prefix));
            }

            Assert.AreEqual(3, blobs.Count);
            Assert.AreEqual(2, prefixes.Count);

            var foundBlobNames = blobs.Select(blob => blob.Name).ToArray();
            var foundBlobPrefixes = prefixes.ToArray();
            IEnumerable<string> expectedPrefixes =
                BlobNames
                .Where(blobName => blobName.Contains(delimiter))
                .Select(blobName => blobName.Split(new[] { delimiter[0] })[0] + delimiter)
                .Distinct()
                ;

            Assert.IsTrue(
                BlobNames
                .Where(blobName => !blobName.Contains(delimiter))
                .All(blobName => foundBlobNames.Contains(blobName))
                );

            Assert.IsTrue(
                expectedPrefixes
                .All(prefix => foundBlobPrefixes.Contains(prefix))
                );
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsHierarchySegmentAsync_Tags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            IDictionary<string, string> tags = BuildTags();
            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Tags = tags
            };
            await appendBlob.CreateAsync(options);

            // Act
            IList<BlobHierarchyItem> blobHierachyItems = await test.Container.GetBlobsByHierarchyAsync(BlobTraits.Tags).ToListAsync();

            // Assert
            AssertDictionaryEquality(tags, blobHierachyItems[0].Blob.Tags);
            Assert.AreEqual(tags.Count, blobHierachyItems[0].Blob.Properties.TagCount);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(null)]
        [TestCase(RehydratePriority.Standard)]
        [TestCase(RehydratePriority.High)]
        public async Task ListBlobsHierarchySegmentAsync_RehydratePriority(RehydratePriority? rehydratePriority)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlockBlobClient blockBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await blockBlob.UploadAsync(stream);

            if (rehydratePriority.HasValue)
            {
                await blockBlob.SetAccessTierAsync(
                    AccessTier.Archive);

                await blockBlob.SetAccessTierAsync(
                    AccessTier.Hot,
                    rehydratePriority: rehydratePriority.Value);
            }

            // Act
            IList<BlobHierarchyItem> blobItems = await test.Container.GetBlobsByHierarchyAsync().ToListAsync();

            // Assert
            Assert.AreEqual(rehydratePriority, blobItems[0].Blob.Properties.RehydratePriority);
        }

        [Test]
        [AsyncOnly]
        public async Task ListBlobsHierarchySegmentAsync_MaxResults()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);
            var delimiter = "/";

            // Act
            Page<BlobHierarchyItem> page = await test.Container.GetBlobsByHierarchyAsync(delimiter: delimiter)
                .AsPages(pageSizeHint: 2)
                .FirstAsync();

            // Assert
            Assert.AreEqual(2, page.Values.Count);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateAsync(metadata: metadata);

            // Act
            BlobHierarchyItem item = await test.Container.GetBlobsByHierarchyAsync(traits: BlobTraits.Metadata).FirstAsync();

            // Assert
            AssertDictionaryEquality(metadata, item.Blob.Metadata);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ListBlobsHierarchySegmentAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateAsync();

            // Act
            BlobHierarchyItem item = await test.Container.GetBlobsByHierarchyAsync().FirstAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, item.Blob.Properties.EncryptionScope);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Deleted()
        {
            // Arrange
            BlobServiceClient blobServiceClient = GetServiceClient_SoftDelete();
            await using DisposingContainer test = await GetTestContainerAsync(blobServiceClient);
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            await blob.DeleteAsync();

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(states: BlobStates.Deleted).ToListAsync();

            // Assert
            Assert.AreEqual(blobName, blobs[0].Blob.Name);
            Assert.IsTrue(blobs[0].Blob.Deleted);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Uncommited()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);
            var blockId = ToBase64(GetNewBlockName());

            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(
                    base64BlockId: blockId,
                    content: stream);
            }

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(states: BlobStates.Uncommitted).ToListAsync();

            // Assert
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Blob.Name);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Snapshot()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(states: BlobStates.Snapshots).ToListAsync();

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Blob.Snapshot);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsHierarchySegmentAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);

            // Act
            var blobs = new List<BlobHierarchyItem>();
            await foreach (Page<BlobHierarchyItem> page in test.Container.GetBlobsByHierarchyAsync(states: BlobStates.Version).AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.IsNull(blobs[0].Blob.IsLatestVersion);
            Assert.AreEqual(createResponse.Value.VersionId, blobs[0].Blob.VersionId);
            Assert.IsTrue(blobs[1].Blob.IsLatestVersion);
            Assert.AreEqual(setMetadataResponse.Value.VersionId, blobs[1].Blob.VersionId);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Prefix()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(prefix: "foo").ToListAsync();


            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.GetBlobsByHierarchyAsync().ToListAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [PlaybackOnly("Object Replication policies is only enabled on certain storage accounts")]
        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsHierarchySegmentAsync_ObjectReplication()
        {
            // TODO: The tests will temporarily use designated account, containers and blobs to check the
            // existence of OR Metadata
            BlobServiceClient sourceServiceClient = GetServiceClient_SharedKey();

            // This is a recorded ONLY test with a special container we previously setup, as we can't auto setup policies yet
            BlobContainerClient sourceContainer = InstrumentClient(sourceServiceClient.GetBlobContainerClient("test1"));

            // Act
            BlobHierarchyItem item = await sourceContainer.GetBlobsByHierarchyAsync().FirstAsync();

            // Assert
            // Since this is a PLAYBACK ONLY test. We expect all the blobs in this source container/account
            // to have OrMetadata
            Assert.IsNotNull(item.Blob.ObjectReplicationSourceProperties);
        }

        [Test]
        public async Task UploadBlobAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            using var stream = new MemoryStream(GetRandomBuffer(100));
            await test.Container.UploadBlobAsync(name, stream);
            Response<BlobProperties> properties = await InstrumentClient(test.Container.GetBlobClient(name)).GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [Test]
        public async Task DeleteBlobAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(name));
            using (var stream = new MemoryStream(GetRandomBuffer(100)))
            {
                await blob.UploadAsync(stream);
            }

            await test.Container.DeleteBlobAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [Test]
        public async Task DeleteBlobIfExistsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var name = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(name));
            using (var stream = new MemoryStream(GetRandomBuffer(100)))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<bool> response = await test.Container.DeleteBlobIfExistsAsync(name);

            // Assert
            Assert.IsTrue(response.Value);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [Test]
        public async Task DeleteBlobIfExistsAsync_Exists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var name = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(name));
            using (var stream = new MemoryStream(GetRandomBuffer(100)))
            {
                await blob.UploadAsync(stream);
            }
            await test.Container.DeleteBlobAsync(name);

            //Act
            Response<bool> response = await test.Container.DeleteBlobIfExistsAsync(name);

            // Assert
            Assert.IsFalse(response.Value);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [Test]
        public async Task DeleteBlobIfExistsAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.DeleteBlobIfExistsAsync(GetNewBlobName()),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        [TestCase("!*'();[]:@&%=+$,/?#äÄöÖüÜß")]
        [TestCase("%21%2A%27%28%29%3B%5B%5D%3A%40%26%25%3D%2B%24%2C%2F%3F%23äÄöÖüÜß")]
        [TestCase("my cool blob")]
        [TestCase("blob")]
        public async Task GetBlobClient_SpecialCharacters(string blobName)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            Uri expectedUri = new Uri($"https://{TestConfigDefault.AccountName}.blob.core.windows.net/{test.Container.Name}/{Uri.EscapeDataString(blobName)}");

            BlobClient initalBlob = new BlobClient(
                TestConfigDefault.ConnectionString,
                test.Container.Name,
                blobName,
                GetOptions());

            var data = GetRandomBuffer(Constants.KB);

            using var stream = new MemoryStream(data);
            Response<BlobContentInfo> uploadResponse = await initalBlob.UploadAsync(stream);

            BlobClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Blob(
                    containerName: test.Container.Name,
                    blobName: blobName)
                .GetBlobContainerClient(test.Container.Name)
                .GetBlobClient(blobName));

            // Act
            Response<BlobProperties> propertiesResponse = await sasBlob.GetPropertiesAsync();

            List<BlobItem> blobItems = new List<BlobItem>();
            await foreach (BlobItem blobItem in test.Container.GetBlobsAsync())
            {
                blobItems.Add(blobItem);
            }

            Assert.AreEqual(blobName, blobItems[0].Name);

            // Assert
            Assert.AreEqual(uploadResponse.Value.ETag, propertiesResponse.Value.ETag);
            Assert.AreEqual(blobName, initalBlob.Name);
            Assert.AreEqual(expectedUri, initalBlob.Uri);

            Assert.AreEqual(blobName, sasBlob.Name);
            Assert.AreEqual(expectedUri, initalBlob.Uri);
        }

        [Test]
        [TestCase("!*'();[]:@&%=+$,/?#äÄöÖüÜß")]
        [TestCase("%21%2A%27%28%29%3B%5B%5D%3A%40%26%25%3D%2B%24%2C%2F%3F%23äÄöÖüÜß")]
        [TestCase("my cool blob")]
        [TestCase("blob")]
        public async Task GetBlobClients_SpecialCharacters(string blobName)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            Uri expectedUri = new Uri($"https://{TestConfigDefault.AccountName}.blob.core.windows.net/{test.Container.Name}/{Uri.EscapeDataString(blobName)}");

            BlobClient blobClientFromContainer = InstrumentClient(test.Container.GetBlobClient(blobName));
            BlobClient blobClientFromConnectionString = new BlobClient(
                TestConfigDefault.ConnectionString,
                test.Container.Name,
                blobName,
                GetOptions());

            BlockBlobClient blockBlobClientFromContainer = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            BlockBlobClient blockBlobClientFromConnectionString = new BlockBlobClient(
                TestConfigDefault.ConnectionString,
                test.Container.Name,
                blobName,
                GetOptions());

            AppendBlobClient appendBlobClientFromContainer = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            AppendBlobClient appendBlobClientFromConnectionString = new AppendBlobClient(
                TestConfigDefault.ConnectionString,
                test.Container.Name,
                blobName,
                GetOptions());

            PageBlobClient pageBlobClientFromContainer = InstrumentClient(test.Container.GetPageBlobClient(blobName));
            PageBlobClient pageBlobClientFromConnectionString = new PageBlobClient(
                TestConfigDefault.ConnectionString,
                test.Container.Name,
                blobName,
                GetOptions());

            // Assert
            Assert.AreEqual(blobName, blobClientFromContainer.Name);
            Assert.AreEqual(expectedUri, blobClientFromContainer.Uri);
            Assert.AreEqual(blobName, blobClientFromConnectionString.Name);
            Assert.AreEqual(expectedUri, blobClientFromConnectionString.Uri);

            Assert.AreEqual(expectedUri, blockBlobClientFromContainer.Uri);
            Assert.AreEqual(blobName, blockBlobClientFromContainer.Name);
            Assert.AreEqual(expectedUri, blockBlobClientFromConnectionString.Uri);
            Assert.AreEqual(blobName, blockBlobClientFromConnectionString.Name);

            Assert.AreEqual(expectedUri, appendBlobClientFromContainer.Uri);
            Assert.AreEqual(blobName, appendBlobClientFromContainer.Name);
            Assert.AreEqual(expectedUri, appendBlobClientFromConnectionString.Uri);
            Assert.AreEqual(blobName, appendBlobClientFromConnectionString.Name);

            Assert.AreEqual(expectedUri, pageBlobClientFromContainer.Uri);
            Assert.AreEqual(blobName, pageBlobClientFromContainer.Name);
            Assert.AreEqual(expectedUri, pageBlobClientFromConnectionString.Uri);
            Assert.AreEqual(blobName, pageBlobClientFromConnectionString.Name);
        }

        #region Secondary Storage
        [Test]
        public async Task ListContainersSegmentAsync_SecondaryStorageFirstRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(1); // one GET failure means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageFirstRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }


        private async Task<TestExceptionPolicy> PerformSecondaryStorageTest(int numberOfReadFailuresToSimulate, bool retryOn404 = false)
        {
            BlobContainerClient containerClient = GetBlobContainerClient_SecondaryAccount_ReadEnabledOnRetry(numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, retryOn404);
            await containerClient.CreateAsync();

            Response<BlobContainerProperties> properties = await EnsurePropagatedAsync(
                async () => await containerClient.GetPropertiesAsync(),
                properties => properties.GetRawResponse().Status != 404);

            Assert.IsNotNull(properties);
            Assert.AreEqual(200, properties.GetRawResponse().Status);

            await containerClient.DeleteAsync();
            return testExceptionPolicy;
        }
        #endregion

        private string[] BlobNames
            => new[]
            {
                    "foo",
                    "bar",
                    "baz",
                    "foo/foo",
                    "foo/bar",
                    "baz/foo",
                    "baz/foo/bar",
                    "baz/bar/foo"
            };

        private async Task SetUpContainerForListing(BlobContainerClient container)
        {
            var blobNames = BlobNames;

            var data = GetRandomBuffer(Constants.KB);

            var blobs = new BlockBlobClient[blobNames.Length];

            // Upload Blobs
            for (var i = 0; i < blobNames.Length; i++)
            {
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobNames[i]));
                blobs[i] = blob;

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Set metadata on Blob index 3
            IDictionary<string, string> metadata = BuildMetadata();
            await blobs[3].SetMetadataAsync(metadata);
        }

        public IEnumerable<AccessConditionParameters> AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId }
            };

        public IEnumerable<AccessConditionParameters> AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { LeaseId = GarbageETag },
             };

        public IEnumerable<AccessConditionParameters> NoLease_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate }
            };

        public IEnumerable<AccessConditionParameters> NoLease_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate }
            };

        private BlobRequestConditions BuildContainerAccessConditions(
            AccessConditionParameters parameters,
            bool ifUnmodifiedSince,
            bool lease)
        {

            var accessConditions = new BlobRequestConditions { IfModifiedSince = parameters.IfModifiedSince };
            if (ifUnmodifiedSince)
            {
                accessConditions.IfUnmodifiedSince = parameters.IfUnmodifiedSince;
            }
            if (lease)
            {
                accessConditions.LeaseId = parameters.LeaseId;
            }
            return accessConditions;
        }

        public class AccessConditionParameters
        {
            public DateTimeOffset? IfModifiedSince { get; set; }
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
            public string LeaseId { get; set; }
        }
    }
}
