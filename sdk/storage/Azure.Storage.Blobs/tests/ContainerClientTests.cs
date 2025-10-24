// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Common;
using Azure.Storage.Sas;
using Azure.Storage.Shared;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests;
using Azure.Storage.Tests.Shared;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class ContainerClientTests : BlobTestBase
    {
        public ContainerClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        public BlobServiceClient GetServiceClient_SharedKey(BlobClientOptions options = default)
            => BlobsClientBuilder.GetServiceClient_SharedKey(options);

        [RecordedTest]
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
        public void Ctor_ConnectionString_CustomUri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://customdomain/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://customdomain/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

            var containerName = "containername";

            BlobContainerClient container = new BlobContainerClient(connectionString.ToString(true), containerName);

            var builder = new BlobUriBuilder(container.Uri);

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual("", builder.BlobName);
            Assert.AreEqual(containerName, container.Name);
            Assert.AreEqual(accountName, container.AccountName);
        }

        [RecordedTest]
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
                await containerClient1.CreateIfNotExistsAsync();
                BlobClient blob1 = InstrumentClient(containerClient1.GetBlobClient(GetNewBlobName()));

                await containerClient2.CreateIfNotExistsAsync();
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
                await containerClient1.DeleteIfExistsAsync();
                await containerClient2.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
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
                await containerClient.CreateIfNotExistsAsync();

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
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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
                await containerClient.CreateIfNotExistsAsync();

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
                await containerClient.DeleteIfExistsAsync();
            }
        }
        private BlobContainerClient GetBlobContainerClient(string connectionString) =>
            InstrumentClient(
                new BlobContainerClient(
                    connectionString,
                    GetNewContainerName(),
                    GetOptions()));

        [RecordedTest]
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

        [RecordedTest]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobContainerClient(httpUri, TestEnvironment.Credential),
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
                () => new BlobContainerClient(httpUri, blobClientOptions),
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
                () => new BlobContainerClient(new Uri(TestConfigDefault.BlobServiceEndpoint), blobClientOptions),
                new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set"));
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var containerName = "containerName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri($"https://customdomain/{containerName}");

            BlobContainerClient blobClient = new BlobContainerClient(blobEndpoint, credentials);

            Assert.AreEqual(accountName, blobClient.AccountName);
            Assert.AreEqual(containerName, blobClient.Name);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetAccountSasCredentials().SasToken;
            Uri uri = test.Container.Uri;

            // Act
            var sasClient = InstrumentClient(new BlobContainerClient(uri, new AzureSasCredential(sas), GetOptions()));
            BlobContainerProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetAccountSasCredentials().SasToken;
            Uri uri = test.Container.Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new BlobContainerClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.DefaultAudience);

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = test.Container.Name,
            };

            BlobContainerClient aadContainer = InstrumentClient(new BlobContainerClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadContainer.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_CustomAudience()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(new BlobAudience($"https://{test.Container.AccountName}.blob.core.windows.net/"));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = test.Container.Name,
            };

            BlobContainerClient aadContainer = InstrumentClient(new BlobContainerClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadContainer.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.CreateBlobServiceAccountAudience(test.Container.AccountName));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = test.Container.Name,
            };

            BlobContainerClient aadContainer = InstrumentClient(new BlobContainerClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadContainer.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(new BlobAudience("https://badaudience.blob.core.windows.net"));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = test.Container.Name,
            };

            BlobContainerClient aadContainer = InstrumentClient(new BlobContainerClient(
                uriBuilder.ToUri(),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadContainer.ExistsAsync(),
                e => Assert.AreEqual(BlobErrorCode.InvalidAuthenticationInfo.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        public void ctor_BlobContainerClient_clientSideEncryptionOptions()
        {
            var client = new BlobContainerClient(
                connectionString: "UseDevelopmentStorage=true",
                blobContainerName: "enc-test",
                options: new SpecializedBlobClientOptions()
                {
                    ClientSideEncryption = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0)
                });
            Assert.NotNull(client.ClientSideEncryption);
        }

        [Test]
        public void Ctor_FromConfig(
            [Values(
            StorageAuthType.None,
            StorageAuthType.StorageSharedKey,
            StorageAuthType.Token,
            StorageAuthType.Sas)] StorageAuthType authType)
        {
            StorageSharedKeyCredential sharedKeyCred =
                authType == StorageAuthType.StorageSharedKey ? new("", "") : null;
            TokenCredential tokenCred =
                authType == StorageAuthType.Token ? new DefaultAzureCredential() : null;
            AzureSasCredential sasCred =
                authType == StorageAuthType.Sas ? new("?foo=bar") : null;

            BlobClientOptions options = new();
            BlobContainerClient container = new(
                new Uri("https://example.blob.core.windows.net"),
                new BlobClientConfiguration(
                    options.Build(authType switch
                    {
                        StorageAuthType.StorageSharedKey => sharedKeyCred,
                        StorageAuthType.Token => tokenCred,
                        StorageAuthType.Sas => sasCred,
                        _ => null,
                    }),
                    sharedKeyCred,
                    tokenCred,
                    sasCred,
                    new ClientDiagnostics(options),
                    _serviceVersion,
                    customerProvidedKey: default,
                    transferValidation: null,
                    encryptionScope: null,
                    trimBlobNameSlashes: default),
                null);

            Assert.That(container.ClientConfiguration.SharedKeyCredential,
                authType == StorageAuthType.StorageSharedKey ? Is.EqualTo(sharedKeyCred) : Is.Null);
            Assert.That(container.ClientConfiguration.TokenCredential,
                authType == StorageAuthType.Token ? Is.EqualTo(tokenCred) : Is.Null);
            Assert.That(container.ClientConfiguration.SasCredential,
                authType == StorageAuthType.Sas ? Is.EqualTo(sasCred) : Is.Null);

            switch (authType)
            {
                case StorageAuthType.None:
                    Assert.That(container.AuthenticationPolicy, Is.Null);
                    break;
                case StorageAuthType.StorageSharedKey:
                    Assert.That(container.AuthenticationPolicy, Is.TypeOf<StorageSharedKeyPipelinePolicy>());
                    break;
                case StorageAuthType.Token:
                    Assert.That(container.AuthenticationPolicy, Is.TypeOf<StorageBearerTokenChallengeAuthorizationPolicy>());
                    break;
                case StorageAuthType.Sas:
                    Assert.That(container.AuthenticationPolicy, Is.TypeOf<AzureSasCredentialSynchronousPolicy>());
                    break;
            }
        }

        [RecordedTest]
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
                // Ensure that we grab the whole ETag value from the service without removing the quotes
                Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                var accountName = new BlobUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => container.AccountName);
                TestHelper.AssertCacheableProperty(containerName, () => container.Name);
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
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
                await container.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task CreateAsync_WithOauth()
        {
            // Arrange
            var containerName = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_OAuth();
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
                await container.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task CreateAsync_WithAccountSas()
        {
            // Arrange
            var containerName = GetNewContainerName();

            AccountSasPermissions permissions = AccountSasPermissions.Read
                | AccountSasPermissions.Write
                | AccountSasPermissions.Delete
                | AccountSasPermissions.List
                | AccountSasPermissions.Add
                | AccountSasPermissions.Create
                | AccountSasPermissions.Update
                | AccountSasPermissions.Process;

            SasQueryParameters sasQueryParameters = BlobsClientBuilder.GetNewAccountSas(
                permissions: permissions);

            BlobServiceClient service = new BlobServiceClient(
                new Uri($"{TestConfigDefault.BlobServiceEndpoint}?{sasQueryParameters}"),
                GetOptions());

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
                await container.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task CreateAsync_WithBlobServiceSas()
        {
            // Arrange
            var containerName = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_BlobServiceSas_Container(containerName);

            BlobContainerSasPermissions permissions = BlobContainerSasPermissions.Read
                | BlobContainerSasPermissions.Add
                | BlobContainerSasPermissions.Create
                | BlobContainerSasPermissions.Write
                | BlobContainerSasPermissions.Delete
                | BlobContainerSasPermissions.List;

            BlobSasQueryParameters sasQueryParameters = GetContainerSas(
                containerName: containerName,
                permissions: permissions);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(service.GetBlobContainerClient(containerName).Uri)
            {
                Sas = sasQueryParameters
            };

            BlobContainerClient container = InstrumentClient(new BlobContainerClient(blobUriBuilder.ToUri(), GetOptions()));
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
                    await container.DeleteIfExistsAsync();
                }
            }
        }

        [RecordedTest]
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
            await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CreateAsync_EncryptionScopeOptions()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlobContainerEncryptionScopeOptions encryptionScopeOptions = new BlobContainerEncryptionScopeOptions
            {
                DefaultEncryptionScope = TestConfigDefault.EncryptionScope,
                PreventEncryptionScopeOverride = true
            };

            // Act
            await container.CreateAsync(encryptionScopeOptions: encryptionScopeOptions);

            // Cleanup
            await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
        [PlaybackOnly("Public access disabled on live tests accounts")]
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
            await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task CreateAsync_PublicAccess_None()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await container.CreateAsync(publicAccessType: PublicAccessType.None);

            // Assert
            Response<BlobContainerProperties> response = await container.GetPropertiesAsync();
            Assert.AreEqual(PublicAccessType.None, response.Value.PublicAccess);

            // Cleanup
            await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task CreateAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            // ContainerUri is intentually created twice
            await container.CreateIfNotExistsAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.CreateAsync(),
                e => Assert.AreEqual("ContainerAlreadyExists", e.ErrorCode));

            // Cleanup
            await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
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
            await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateIfNotExistsAsync();

            // Act
            await container.CreateIfNotExistsAsync();

            // Assert
            Response<BlobContainerProperties> response = await container.GetPropertiesAsync();
            Assert.IsNotNull(response.Value.ETag);

            // Cleanup
            await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task DeleteAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateIfNotExistsAsync();

            // Act
            Response response = await container.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [RecordedTest]
        [TestCase(nameof(BlobRequestConditions.TagConditions))]
        [TestCase(nameof(BlobRequestConditions.IfMatch))]
        [TestCase(nameof(BlobRequestConditions.IfNoneMatch))]
        public async Task DeleteAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());

            BlobRequestConditions conditions = new BlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(BlobRequestConditions.TagConditions):
                    conditions.TagConditions = "TagConditions";
                    break;
                case nameof(BlobRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                containerClient.DeleteAsync(
                    conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"Delete does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task DeleteAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateIfNotExistsAsync();
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

        [RecordedTest]
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

        [RecordedTest]
        public async Task DeleteIfExistsAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await container.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);

            // Act
            response = await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task DeleteIfExistsAsync_NotExists()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            Response<bool> response = await container.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await container.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);

            await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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
            Assert.IsNotNull(response.Value.Metadata);

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            if (_serviceVersion >= BlobClientOptions.ServiceVersion.V2019_07_07)
            {
                Assert.IsNotNull(response.Value.DefaultEncryptionScope);
                Assert.IsNotNull(response.Value.PreventEncryptionScopeOverride);
            }
        }

        [RecordedTest]
        [TestCase(nameof(BlobRequestConditions.TagConditions))]
        [TestCase(nameof(BlobRequestConditions.IfMatch))]
        [TestCase(nameof(BlobRequestConditions.IfNoneMatch))]
        [TestCase(nameof(BlobRequestConditions.IfModifiedSince))]
        [TestCase(nameof(BlobRequestConditions.IfUnmodifiedSince))]
        public async Task GetPropertiesAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());

            BlobRequestConditions conditions = new BlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(BlobRequestConditions.TagConditions):
                    conditions.TagConditions = "TagConditions";
                    break;
                case nameof(BlobRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfModifiedSince):
                    conditions.IfModifiedSince = new DateTimeOffset();
                    break;
                case nameof(BlobRequestConditions.IfUnmodifiedSince):
                    conditions.IfUnmodifiedSince = new DateTimeOffset();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                containerClient.GetPropertiesAsync(
                    conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"GetProperties does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task SetMetadataAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<BlobContainerInfo> response = await test.Container.SetMetadataAsync(metadata);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Check if we correctly set the metadata properly
            Response<BlobContainerProperties> getPropertiesResponse = await test.Container.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, getPropertiesResponse.Value.Metadata);
        }

        [RecordedTest]
        [TestCase(nameof(BlobRequestConditions.TagConditions))]
        [TestCase(nameof(BlobRequestConditions.IfUnmodifiedSince))]
        [TestCase(nameof(BlobRequestConditions.IfMatch))]
        [TestCase(nameof(BlobRequestConditions.IfNoneMatch))]
        public async Task SetMetadataAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());

            IDictionary<string, string> metadata = BuildMetadata();
            BlobRequestConditions conditions = new BlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(BlobRequestConditions.TagConditions):
                    conditions.TagConditions = "TagConditions";
                    break;
                case nameof(BlobRequestConditions.IfUnmodifiedSince):
                    conditions.IfUnmodifiedSince = new DateTimeOffset();
                    break;
                case nameof(BlobRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                containerClient.SetMetadataAsync(
                    metadata: metadata,
                    conditions: conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"SetMetadata does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
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

        [RecordedTest]
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
                await container.CreateIfNotExistsAsync();
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
                await container.DeleteIfExistsAsync(new BlobRequestConditions { LeaseId = parameters.LeaseId });
            }
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task GetAccessPolicyAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Act
            Response<BlobContainerAccessPolicy> response = await test.Container.GetAccessPolicyAsync();

            // Assert
            Assert.IsNotNull(response);
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
        }

        [RecordedTest]
        [TestCase(nameof(BlobRequestConditions.TagConditions))]
        [TestCase(nameof(BlobRequestConditions.IfMatch))]
        [TestCase(nameof(BlobRequestConditions.IfNoneMatch))]
        [TestCase(nameof(BlobRequestConditions.IfModifiedSince))]
        [TestCase(nameof(BlobRequestConditions.IfUnmodifiedSince))]
        public async Task GetAccessPolicyAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());

            BlobRequestConditions conditions = new BlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(BlobRequestConditions.TagConditions):
                    conditions.TagConditions = "TagConditions";
                    break;
                case nameof(BlobRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfModifiedSince):
                    conditions.IfModifiedSince = new DateTimeOffset();
                    break;
                case nameof(BlobRequestConditions.IfUnmodifiedSince):
                    conditions.IfUnmodifiedSince = new DateTimeOffset();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                containerClient.GetAccessPolicyAsync(
                    conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"GetAccessPolicy does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
        public async Task GetAccessPolicyAsync_Lease()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateIfNotExistsAsync();
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
            await container.DeleteIfExistsAsync(conditions: leaseAccessConditions);
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task GetAccessPolicyAsync_EmptyAccessPolicy()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobSignedIdentifier[] signedIdentifiers = new[]
            {
                new BlobSignedIdentifier
                {
                    Id = GetNewString(),
                    // Empty Access Policy
                }
            };

            // Act
            Response<BlobContainerInfo> response = await test.Container.SetAccessPolicyAsync(
                permissions: signedIdentifiers
            );

            // Assert
            Response<BlobContainerAccessPolicy> getPolicyResponse = await test.Container.GetAccessPolicyAsync();
            Assert.AreEqual(1, getPolicyResponse.Value.SignedIdentifiers.Count());

            BlobSignedIdentifier acl = getPolicyResponse.Value.SignedIdentifiers.First();
            Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
            Assert.IsNull(acl.AccessPolicy);
        }

        [RecordedTest]
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

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2025_07_05)]
        public async Task GetSetAccessPolicyAsync_OAuth()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(service);

            // Act
            Response<BlobContainerAccessPolicy> response = await test.Container.GetAccessPolicyAsync();
            await test.Container.SetAccessPolicyAsync(permissions: response.Value.SignedIdentifiers);
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            Response<BlobContainerInfo> response = await test.Container.SetAccessPolicyAsync(
                permissions: signedIdentifiers
            );

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            Response<BlobContainerProperties> propertiesResponse = await test.Container.GetPropertiesAsync();

            Response<BlobContainerAccessPolicy> getPolicyResponse = await test.Container.GetAccessPolicyAsync();
            Assert.AreEqual(1, getPolicyResponse.Value.SignedIdentifiers.Count());

            BlobSignedIdentifier acl = getPolicyResponse.Value.SignedIdentifiers.First();
            Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, acl.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, acl.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Permissions, acl.AccessPolicy.Permissions);
        }

        [RecordedTest]
        [TestCase(nameof(BlobRequestConditions.TagConditions))]
        [TestCase(nameof(BlobRequestConditions.IfMatch))]
        [TestCase(nameof(BlobRequestConditions.IfNoneMatch))]
        public async Task SetAccessPolicyAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());

            BlobRequestConditions conditions = new BlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(BlobRequestConditions.TagConditions):
                    conditions.TagConditions = "TagConditions";
                    break;
                case nameof(BlobRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                containerClient.SetAccessPolicyAsync(
                    conditions: conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"SetAccessPolicy does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
        public void BlobAccessPolicyNullStartsOnExpiresOnTest()
        {
            BlobAccessPolicy accessPolicy = new BlobAccessPolicy()
            {
                Permissions = "rw"
            };

            Assert.AreEqual(new DateTimeOffset(), accessPolicy.StartsOn);
            Assert.AreEqual(new DateTimeOffset(), accessPolicy.ExpiresOn);
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync_OldProperties()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange and Act
            BlobSignedIdentifier[] signedIdentifiers = new[]
            {
                new BlobSignedIdentifier
                {
                    Id = GetNewString(),
                    // Create an AccessPolicy with only StartsOn (old property)
                    AccessPolicy = new BlobAccessPolicy
                    {
                        StartsOn = Recording.UtcNow.AddHours(-1),
                        ExpiresOn = Recording.UtcNow.AddHours(+1)
                    }
                }
            };

            // Assert
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifiers[0].AccessPolicy.StartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, signedIdentifiers[0].AccessPolicy.ExpiresOn);

            // Act
            Response<BlobContainerInfo> response = await test.Container.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            Response<BlobContainerAccessPolicy> responseAfter = await test.Container.GetAccessPolicyAsync();
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            BlobSignedIdentifier signedIdentifierResponse = responseAfter.Value.SignedIdentifiers.First();
            Assert.AreEqual(1, responseAfter.Value.SignedIdentifiers.Count());
            Assert.AreEqual(signedIdentifiers[0].Id, signedIdentifierResponse.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.StartsOn, signedIdentifierResponse.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, signedIdentifierResponse.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.ExpiresOn, signedIdentifierResponse.AccessPolicy.PolicyExpiresOn);
            Assert.IsNull(signedIdentifierResponse.AccessPolicy.Permissions);
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync_StartsPermissionsProperties()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobSignedIdentifier[] signedIdentifiers = new[]
            {
                new BlobSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new BlobAccessPolicy
                    {
                        // Create an AccessPolicy without PolicyExpiresOn
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        Permissions = "rw"
                    }
                }
            };
            // Assert
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifiers[0].AccessPolicy.StartsOn);
            Assert.IsNull(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn);

            // Act
            Response<BlobContainerInfo> response = await test.Container.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            Response<BlobContainerAccessPolicy> responseAfter = await test.Container.GetAccessPolicyAsync();
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            BlobSignedIdentifier signedIdentifierResponse = responseAfter.Value.SignedIdentifiers.First();
            Assert.AreEqual(1, responseAfter.Value.SignedIdentifiers.Count());
            Assert.AreEqual(signedIdentifiers[0].Id, signedIdentifierResponse.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.StartsOn);
            Assert.IsNull(signedIdentifierResponse.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.Permissions, signedIdentifiers[0].AccessPolicy.Permissions);
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync_StartsExpiresProperties()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobSignedIdentifier[] signedIdentifiers = new[]
            {
                new BlobSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new BlobAccessPolicy
                    {
                        // Create an AccessPolicy without PolicyExpiresOn
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        PolicyExpiresOn = Recording.UtcNow.AddHours(+1)
                    }
                }
            };
            // Assert
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifiers[0].AccessPolicy.StartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, signedIdentifiers[0].AccessPolicy.ExpiresOn);

            // Act
            Response<BlobContainerInfo> response = await test.Container.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            Response<BlobContainerAccessPolicy> responseAfter = await test.Container.GetAccessPolicyAsync();
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            BlobSignedIdentifier signedIdentifierResponse = responseAfter.Value.SignedIdentifiers.First();
            Assert.AreEqual(1, responseAfter.Value.SignedIdentifiers.Count());
            Assert.AreEqual(signedIdentifiers[0].Id, signedIdentifierResponse.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.StartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, signedIdentifierResponse.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.PolicyExpiresOn, signedIdentifierResponse.AccessPolicy.ExpiresOn);
            Assert.IsNull(signedIdentifierResponse.AccessPolicy.Permissions);
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task SetAccessPolicyAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateIfNotExistsAsync();
                BlobSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                parameters.LeaseId = await SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                Response<BlobContainerInfo> response = await container.SetAccessPolicyAsync(
                    permissions: signedIdentifiers,
                    conditions: accessConditions
                );

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = parameters.LeaseId });
            }
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task SetAccessPolicyAsync_InvalidPermissionOrder()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobSignedIdentifier[] signedIdentifiers = new[]
            {
                new BlobSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new BlobAccessPolicy()
                    {
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        PolicyExpiresOn = Recording.UtcNow.AddHours(1),
                        Permissions = "wrld"
                    }
                }
            };

            // Act
            await test.Container.SetAccessPolicyAsync(
                permissions: signedIdentifiers
            );

            // Assert
            Response<BlobContainerProperties> propertiesResponse = await test.Container.GetPropertiesAsync();

            Response<BlobContainerAccessPolicy> response = await test.Container.GetAccessPolicyAsync();
            Assert.AreEqual(1, response.Value.SignedIdentifiers.Count());

            BlobSignedIdentifier acl = response.Value.SignedIdentifiers.First();
            Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, acl.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, acl.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Permissions, acl.AccessPolicy.Permissions);
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateIfNotExistsAsync();
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            var leaseClient = InstrumentClient(container.GetBlobLeaseClient(id));

            // Act
            Response<BlobLease> response = await leaseClient.AcquireAsync(duration: duration);

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            Assert.AreEqual(id, response.Value.LeaseId);
            Assert.AreEqual(response.Value.LeaseId, leaseClient.LeaseId);

            // Cleanup
            await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
        }

        [RecordedTest]
        [TestCase(nameof(RequestConditions.IfMatch))]
        [TestCase(nameof(RequestConditions.IfNoneMatch))]
        public async Task AcquireLeaseAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());
            string id = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);
            BlobLeaseClient leaseClient = InstrumentClient(containerClient.GetBlobLeaseClient(id));

            RequestConditions conditions = new RequestConditions();

            switch (invalidCondition)
            {
                case nameof(RequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(RequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                leaseClient.AcquireAsync(
                    duration,
                    conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"Acquire does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
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
                e => StringAssert.Contains(Constants.ErrorCodes.InvalidHeaderValue, e.ErrorCode));
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task AcquireLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateIfNotExistsAsync();
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
                await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
            }
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task RenewLeaseAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateIfNotExistsAsync();

            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            var leaseClient = InstrumentClient(container.GetBlobLeaseClient(id));

            Response<BlobLease> leaseResponse = await leaseClient.AcquireAsync(duration: duration);

            // Act
            Response<BlobLease> renewResponse = await InstrumentClient(container.GetBlobLeaseClient(leaseResponse.Value.LeaseId)).RenewAsync();

            // Assert
            Assert.IsNotNull(renewResponse.GetRawResponse().Headers.RequestId);
            Assert.AreEqual(renewResponse.Value.LeaseId, leaseClient.LeaseId);

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(renewResponse.Value.ETag.ToString(), $"\"{renewResponse.GetRawResponse().Headers.ETag}\"");

            // Cleanup
            await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = renewResponse.Value.LeaseId });
        }

        [RecordedTest]
        [TestCase(nameof(RequestConditions.IfMatch))]
        [TestCase(nameof(RequestConditions.IfNoneMatch))]
        public async Task RenewLeaseAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());
            string id = Recording.Random.NewGuid().ToString();
            BlobLeaseClient leaseClient = InstrumentClient(containerClient.GetBlobLeaseClient(id));

            RequestConditions conditions = new RequestConditions();

            switch (invalidCondition)
            {
                case nameof(RequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(RequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                leaseClient.RenewAsync(
                    conditions: conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"Release does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task RenewLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateIfNotExistsAsync();
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
                await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
            }
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateIfNotExistsAsync();
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
                await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [RecordedTest]
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
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(releaseResponse.Value.ETag.ToString(), $"\"{releaseResponse.GetRawResponse().Headers.ETag}\"");

            // Ensure the correct status by doing a GetProperties call
            Response<BlobContainerProperties> response = await test.Container.GetPropertiesAsync();

            Assert.AreEqual(LeaseStatus.Unlocked, response.Value.LeaseStatus);
            Assert.AreEqual(LeaseState.Available, response.Value.LeaseState);
        }

        [RecordedTest]
        [TestCase(nameof(RequestConditions.IfMatch))]
        [TestCase(nameof(RequestConditions.IfNoneMatch))]
        public async Task ReleaseLeaseAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());
            string id = Recording.Random.NewGuid().ToString();
            BlobLeaseClient leaseClient = InstrumentClient(containerClient.GetBlobLeaseClient(id));

            RequestConditions conditions = new RequestConditions();

            switch (invalidCondition)
            {
                case nameof(RequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(RequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                leaseClient.ReleaseAsync(
                    conditions: conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"Release does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public async Task ReleaseLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateIfNotExistsAsync();
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
                await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [RecordedTest]
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

        [RecordedTest]
        [TestCase(nameof(RequestConditions.IfMatch))]
        [TestCase(nameof(RequestConditions.IfNoneMatch))]
        public async Task BreakLeaseAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());
            string id = Recording.Random.NewGuid().ToString();
            BlobLeaseClient leaseClient = InstrumentClient(containerClient.GetBlobLeaseClient(id));

            RequestConditions conditions = new RequestConditions();

            switch (invalidCondition)
            {
                case nameof(RequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(RequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                leaseClient.BreakAsync(
                    conditions: conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"Break does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task BreakLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateIfNotExistsAsync();

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
                await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateIfNotExistsAsync();
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
                await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            Response<BlobLease> leaseResponse = await InstrumentClient(test.Container.GetBlobLeaseClient(id)).AcquireAsync(duration);
            var newId = Recording.Random.NewGuid().ToString();
            var leaseClient = InstrumentClient(test.Container.GetBlobLeaseClient(id));

            // Act
            Response<BlobLease> changeResponse = await leaseClient.ChangeAsync(newId);

            // Assert
            Assert.AreEqual(newId, changeResponse.Value.LeaseId);
            Assert.AreEqual(changeResponse.Value.LeaseId, leaseClient.LeaseId);

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(changeResponse.Value.ETag.ToString(), $"\"{changeResponse.GetRawResponse().Headers.ETag}\"");

            // Cleanup
            await InstrumentClient(test.Container.GetBlobLeaseClient(changeResponse.Value.LeaseId)).ReleaseAsync();
        }

        [RecordedTest]
        [TestCase(nameof(RequestConditions.IfMatch))]
        [TestCase(nameof(RequestConditions.IfNoneMatch))]
        public async Task ChangeLeaseAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());
            string id = Recording.Random.NewGuid().ToString();
            BlobLeaseClient leaseClient = InstrumentClient(containerClient.GetBlobLeaseClient(id));

            RequestConditions conditions = new RequestConditions();

            switch (invalidCondition)
            {
                case nameof(RequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(RequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                leaseClient.ChangeAsync(
                    id,
                    conditions: conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"Change does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task ChangeLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateIfNotExistsAsync();

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
                await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
            }
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateIfNotExistsAsync();
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
                await container.DeleteIfExistsAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [RecordedTest]
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

        [RecordedTest]
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

            GetBlobsOptions getBlobsOptions = new GetBlobsOptions
            {
                Traits = BlobTraits.Tags
            };

            // Act
            IList<BlobItem> blobItems = await test.Container.GetBlobsAsync(getBlobsOptions).ToListAsync();

            // Assert
            AssertDictionaryEquality(tags, blobItems[0].Tags);
            Assert.AreEqual(tags.Count, blobItems[0].Properties.TagCount);
        }

        [RecordedTest]
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

        [RecordedTest]
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
            Assert.IsTrue(page.Values.All(b => b.Metadata.Count == 0));
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateIfNotExistsAsync(metadata: metadata);

            GetBlobsOptions options = new GetBlobsOptions
            {
                Traits = BlobTraits.Metadata
            };

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(options).ToListAsync();

            // Assert
            AssertDictionaryEquality(metadata, blobs.First().Metadata);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ListBlobsFlatSegmentAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));

            await blob.CreateIfNotExistsAsync();

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, blobs.First().Properties.EncryptionScope);
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Deleted()
        {
            // Arrange
            BlobServiceClient blobServiceClient = BlobsClientBuilder.GetServiceClient_SoftDelete();
            await using DisposingContainer test = await GetTestContainerAsync(blobServiceClient);
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateIfNotExistsAsync();
            await blob.DeleteIfExistsAsync();

            GetBlobsOptions options = new GetBlobsOptions
            {
                States = BlobStates.Deleted
            };

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(options).ToListAsync();

            // Assert
            Assert.AreEqual(blobName, blobs[0].Name);
            Assert.IsTrue(blobs[0].Deleted);
        }

        [RecordedTest]
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

            GetBlobsOptions options = new GetBlobsOptions
            {
                States = BlobStates.Uncommitted
            };

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(options).ToListAsync();

            // Assert
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Snapshot()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            GetBlobsOptions options = new GetBlobsOptions
            {
                States = BlobStates.Snapshots
            };

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(options).ToListAsync();

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Snapshot);
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Prefix()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            GetBlobsOptions options = new GetBlobsOptions
            {
                Prefix = "foo"
            };

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(options).ToListAsync();

            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsFlatSegmentAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);

            GetBlobsOptions options = new GetBlobsOptions
            {
                States = BlobStates.Version
            };

            // Act
            var blobs = new List<BlobItem>();
            await foreach (Page<BlobItem> page in test.Container.GetBlobsAsync(options).AsPages())
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
        [RecordedTest]
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

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task ListBlobsFlatSegmentAsync_LastAccessed()
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
            Assert.AreNotEqual(DateTimeOffset.MinValue, blobs.FirstOrDefault().Properties.LastAccessedOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task ListBlobsFlatSegmentAsync_DeletedWithVersions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);
            await blob.DeleteAsync();

            GetBlobsOptions options = new GetBlobsOptions
            {
                States = BlobStates.DeletedWithVersions
            };

            // Act
            List<BlobItem> blobItems = new List<BlobItem>();
            await foreach (BlobItem blobItem in test.Container.GetBlobsAsync(options))
            {
                blobItems.Add(blobItem);
            }

            // Assert
            Assert.AreEqual(1, blobItems.Count);
            Assert.AreEqual(blob.Name, blobItems[0].Name);
            Assert.IsTrue(blobItems[0].HasVersionsOnly);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2021_02_12)]
        public async Task ListBlobsFlatSegmentAsync_EncodedBlobName()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = "dir1/dir2/file\uFFFF.blob";
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            // Act
            BlobItem blobItem = await test.Container.GetBlobsAsync().FirstAsync();

            // Assert
            Assert.AreEqual(blobName, blobItem.Name);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ListBlobsFlatSegmentAsync_StartFrom()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            GetBlobsOptions options = new GetBlobsOptions
            {
                StartFrom = "foo"
            };

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(options).ToListAsync();

            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [RecordedTest]
        [PlaybackOnly("Service bug - https://github.com/Azure/azure-sdk-for-net/issues/16516")]
        public async Task ListBlobsHierarchySegmentAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            var blobs = new List<BlobItem>();
            var prefixes = new List<string>();
            var delimiter = "/";

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                Delimiter = delimiter,
            };

            await foreach (Page<BlobHierarchyItem> page in test.Container.GetBlobsByHierarchyAsync(options: options).AsPages())
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

        [RecordedTest]
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

            GetBlobsByHierarchyOptions getBlobsByHierarchyOptions = new GetBlobsByHierarchyOptions
            {
                Traits = BlobTraits.Tags
            };

            // Act
            IList<BlobHierarchyItem> blobHierachyItems = await test.Container.GetBlobsByHierarchyAsync(getBlobsByHierarchyOptions).ToListAsync();

            // Assert
            AssertDictionaryEquality(tags, blobHierachyItems[0].Blob.Tags);
            Assert.AreEqual(tags.Count, blobHierachyItems[0].Blob.Properties.TagCount);
        }

        [RecordedTest]
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

        [RecordedTest]
        [PlaybackOnly("Service bug - https://github.com/Azure/azure-sdk-for-net/issues/16516")]
        [AsyncOnly]
        public async Task ListBlobsHierarchySegmentAsync_MaxResults()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                Delimiter = "/"
            };

            // Act
            Page<BlobHierarchyItem> page = await test.Container.GetBlobsByHierarchyAsync(options: options)
                .AsPages(pageSizeHint: 2)
                .FirstAsync();

            // Assert
            Assert.AreEqual(2, page.Values.Count);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateIfNotExistsAsync(metadata: metadata);

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                Traits = BlobTraits.Metadata,
            };

            // Act
            BlobHierarchyItem item = await test.Container.GetBlobsByHierarchyAsync(options: options).FirstAsync();

            // Assert
            AssertDictionaryEquality(metadata, item.Blob.Metadata);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Metadata_NoMetadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                Traits = BlobTraits.Metadata
            };

            // Act
            BlobHierarchyItem item = await test.Container.GetBlobsByHierarchyAsync(options: options).FirstAsync();

            // Assert
            Assert.IsNotNull(item.Blob.Metadata);
            Assert.AreEqual(0, item.Blob.Metadata.Count);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ListBlobsHierarchySegmentAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateIfNotExistsAsync();

            // Act
            BlobHierarchyItem item = await test.Container.GetBlobsByHierarchyAsync().FirstAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, item.Blob.Properties.EncryptionScope);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Deleted()
        {
            // Arrange
            BlobServiceClient blobServiceClient = BlobsClientBuilder.GetServiceClient_SoftDelete();
            await using DisposingContainer test = await GetTestContainerAsync(blobServiceClient);
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            await blob.DeleteAsync();

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                States = BlobStates.Deleted
            };

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(options: options).ToListAsync();

            // Assert
            Assert.AreEqual(blobName, blobs[0].Blob.Name);
            Assert.IsTrue(blobs[0].Blob.Deleted);
        }

        [RecordedTest]
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

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                States = BlobStates.Uncommitted,
            };

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(options: options).ToListAsync();

            // Assert
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Blob.Name);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Snapshot()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                States = BlobStates.Snapshots,
            };

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(options: options).ToListAsync();

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Blob.Snapshot);
        }

        [RecordedTest]
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
            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                States = BlobStates.Version,
            };

            var blobs = new List<BlobHierarchyItem>();
            await foreach (Page<BlobHierarchyItem> page in test.Container.GetBlobsByHierarchyAsync(options: options).AsPages())
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

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Prefix()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                Prefix = "foo",
            };

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(options: options).ToListAsync();

            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [RecordedTest]
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
        [RecordedTest]
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

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task ListBlobsHierarchySegmentAsync_LastAccessed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(content: stream);

            // Act
            BlobHierarchyItem item = await test.Container.GetBlobsByHierarchyAsync().FirstAsync();

            // Assert
            Assert.IsNotNull(item.Blob.Properties.LastAccessedOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task ListBlobsHierarchySegmentAsync_DeletedWithVersions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);
            await blob.DeleteAsync();

            // Act
            List<BlobHierarchyItem> blobHierarchyItems = new List<BlobHierarchyItem>();

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                States = BlobStates.DeletedWithVersions,
            };

            await foreach (BlobHierarchyItem blobItem in test.Container.GetBlobsByHierarchyAsync(options: options))
            {
                blobHierarchyItems.Add(blobItem);
            }

            // Assert
            Assert.AreEqual(1, blobHierarchyItems.Count);
            Assert.AreEqual(blob.Name, blobHierarchyItems[0].Blob.Name);
            Assert.IsTrue(blobHierarchyItems[0].Blob.HasVersionsOnly);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2021_02_12)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task ListBlobsHierarchySegmentAsync_EncodedBlobName(bool delimiter)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = "dir1/dir2/file\uFFFF.blob";
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            // Act
            BlobHierarchyItem item;
            if (delimiter)
            {
                item = await test.Container.GetBlobsByHierarchyAsync().FirstAsync();

                // Assert
                Assert.IsTrue(item.IsBlob);
                Assert.AreEqual(blobName, item.Blob.Name);
            }
            else
            {
                GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
                {
                    Delimiter = ".b",
                };

                item = await test.Container.GetBlobsByHierarchyAsync(
                    options: options).FirstAsync();

                // Assert
                Assert.IsTrue(item.IsPrefix);
                Assert.AreEqual("dir1/dir2/file\uffff.b", item.Prefix);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2021_12_02)]
        public async Task ListBlobsHierarchySegmentAsync_VersionPrefixDelimiter()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            await SetUpContainerForListing(test.Container);

            var blobs = new List<BlobItem>();
            var prefixes = new List<string>();

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                States = BlobStates.Version,
                Delimiter = "/",
                Prefix = "baz"
            };

            await foreach (BlobHierarchyItem blobItem in test.Container.GetBlobsByHierarchyAsync(
                options: options))
            {
                if (blobItem.IsBlob)
                {
                    blobs.Add(blobItem.Blob);
                }
                else
                {
                    prefixes.Add(blobItem.Prefix);
                }
            }

            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(1, prefixes.Count);

            Assert.AreEqual("baz", blobs[0].Name);
            Assert.IsNotNull(blobs[0].VersionId);

            Assert.AreEqual("baz/", prefixes[0]);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ListBlobsHierarchySegmentAsync_StartFrom()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                StartFrom = "foo"
            };

            // Act
            IList<BlobHierarchyItem> blobHierachyItems = await test.Container.GetBlobsByHierarchyAsync(options).ToListAsync();

            // Assert
            Assert.AreEqual(3, blobHierachyItems.Count);
        }

        [RecordedTest]
        public async Task UploadBlobAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            using var stream = new MemoryStream(GetRandomBuffer(100));
            await test.Container.UploadBlobAsync(name, stream);
            Response<BlobProperties> properties = await InstrumentClient(test.Container.GetBlobClient(name)).GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [RecordedTest]
        public async Task UploadBlobAsync_BinaryData()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            await test.Container.UploadBlobAsync(name, BinaryData.FromBytes(GetRandomBuffer(100)));
            Response<BlobProperties> properties = await InstrumentClient(test.Container.GetBlobClient(name)).GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public async Task DeleteBlobIfExistsAsync_ContainerNotExists()
        {
            var name = GetNewBlobName();

            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = service.GetBlobContainerClient(GetNewContainerName());
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(name));

            // Act
            Response<bool> response = await container.DeleteBlobIfExistsAsync(name);

            // Assert
            Assert.IsFalse(response.Value);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [RecordedTest]
        public async Task DeleteBlobIfExistsAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlobContainerClient unauthorizedContainerClient = InstrumentClient(new BlobContainerClient(test.Container.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedContainerClient.DeleteBlobIfExistsAsync(GetNewBlobName()),
                e => { });
        }

        [RecordedTest]
        [TestCase("!*'();[]:@&%=+$,/?#äÄöÖüÜß")]
        [TestCase("%21%2A%27%28%29%3B%5B%5D%3A%40%26%25%3D%2B%24%2C%2F%3F%23äÄöÖüÜß")]
        [TestCase("my cool blob")]
        [TestCase("blob")]
        [TestCase("  ")]
        public async Task GetBlobClient_SpecialCharacters(string blobName)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            Uri expectedUri = new Uri($"{TestConfigDefault.BlobServiceEndpoint}/{test.Container.Name}/{blobName.EscapePath()}");

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

        [RecordedTest]
        [TestCase("!*'();[]:@&%=+$,/?#äÄöÖüÜß")]
        [TestCase("%21%2A%27%28%29%3B%5B%5D%3A%40%26%25%3D%2B%24%2C%2F%3F%23äÄöÖüÜß")]
        [TestCase("my cool blob")]
        [TestCase("blob")]
        [TestCase("  ")]
        public async Task GetBlobClients_SpecialCharacters(string blobName)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            Uri expectedUri = new Uri($"{TestConfigDefault.BlobServiceEndpoint}/{test.Container.Name}/{blobName.EscapePath()}");

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

        [Test]
        [Sequential]
        public void GetBlobClient_PreserveSas(
            [Values("https,http", "http,https", "https")] string protocol)
        {
            string version = _serviceVersion.ToVersionString();
            string service = "b";
            string resourceType = "c";
            string startTime = DateTimeOffset.Now.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
            string expiryTime = DateTimeOffset.Now.AddDays(1).ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
            string identifier = "foo";
            string resource = "bar";
            string permissions = "rw";
            string cacheControl = "no-store";
            string contentDisposition = "inline";
            string contentEncoding = "identity";
            string contentLanguage = "en-US";
            string contentType = "text/html";
            string signature = "a+b=";

            Dictionary<string, string> original = new()
            {
                { "sv", version },
                { "ss", service },
                { "srt", resourceType },
                { "spr", protocol },
                { "st", startTime },
                { "se", expiryTime },
                { "si", identifier },
                { "sr", resource },
                { "sp", permissions },
                { "rscc", cacheControl },
                { "rscd", contentDisposition },
                { "rsce", contentEncoding },
                { "rscl", contentLanguage },
                { "rsct", contentType },
                { "sig", signature },
            };

            string sas = SasQueryParametersInternals.Create(new Dictionary<string, string>(original)).ToString();

            BlobContainerClient containerFromUri = new(new Uri($"https://myaccount.blob.core.windows.net/mycontainer?{sas}"));
            BlobClient blob = containerFromUri.GetBlobClient("myblob");
            Dictionary<string, string> blobQueryParams = blob.Uri.Query.Trim('?').Split('&').ToDictionary(
                s => s.Split('=')[0],
                s => WebUtility.UrlDecode(s.Split('=')[1]));
            Assert.That(original, Is.EquivalentTo(blobQueryParams));
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

            // Act - BlobContainerClient(string connectionString, string blobContainerName)
            BlobContainerClient container = InstrumentClient(new BlobContainerClient(
                connectionString,
                GetNewContainerName()));
            Assert.IsTrue(container.CanGenerateSasUri);

            // Act - BlobContainerClient(string connectionString, string blobContainerName, BlobClientOptions options)
            BlobContainerClient container2 = InstrumentClient(new BlobContainerClient(
                connectionString,
                GetNewContainerName(),
                GetOptions()));
            Assert.IsTrue(container2.CanGenerateSasUri);

            // Act - BlobContainerClient(Uri blobContainerUri, BlobClientOptions options = default)
            BlobContainerClient container3 = InstrumentClient(new BlobContainerClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(container3.CanGenerateSasUri);

            // Act - BlobContainerClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            BlobContainerClient container4 = InstrumentClient(new BlobContainerClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(container4.CanGenerateSasUri);

            // Act - BlobContainerClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            BlobContainerClient container5 = InstrumentClient(new BlobContainerClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.IsFalse(container5.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_Mockable()
        {
            // Act
            var container = new Mock<BlobContainerClient>();
            container.Setup(x => x.CanGenerateSasUri).Returns(false);

            // Assert
            Assert.IsFalse(container.Object.CanGenerateSasUri);

            // Act
            container.Setup(x => x.CanGenerateSasUri).Returns(true);

            // Assert
            Assert.IsTrue(container.Object.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_GetBlobClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - BlobContainerClient(string connectionString, string blobContainerName)
            BlobContainerClient container = InstrumentClient(new BlobContainerClient(
                connectionString,
                GetNewContainerName()));
            BlobBaseClient blob = container.GetBlobBaseClient(GetNewBlobName());
            Assert.IsTrue(blob.CanGenerateSasUri);

            // Act - BlobContainerClient(string connectionString, string blobContainerName, BlobClientOptions options)
            BlobContainerClient container2 = InstrumentClient(new BlobContainerClient(
                connectionString,
                GetNewContainerName(),
                GetOptions()));
            BlobBaseClient blob2 = container2.GetBlobBaseClient(GetNewBlobName());
            Assert.IsTrue(blob2.CanGenerateSasUri);

            // Act - BlobContainerClient(Uri blobContainerUri, BlobClientOptions options = default)
            BlobContainerClient container3 = InstrumentClient(new BlobContainerClient(
                blobEndpoint,
                GetOptions()));
            BlobBaseClient blob3 = container3.GetBlobBaseClient(GetNewBlobName());
            Assert.IsFalse(blob3.CanGenerateSasUri);

            // Act - BlobContainerClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            BlobContainerClient container4 = InstrumentClient(new BlobContainerClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            BlobBaseClient blob4 = container4.GetBlobBaseClient(GetNewBlobName());
            Assert.IsTrue(blob4.CanGenerateSasUri);

            // Act - BlobContainerClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            BlobContainerClient container5 = InstrumentClient(new BlobContainerClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            BlobBaseClient blob5 = container5.GetBlobBaseClient(GetNewBlobName());
            Assert.IsFalse(blob5.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_GetParentServiceClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - BlobContainerClient(string connectionString, string blobContainerName)
            BlobContainerClient container = InstrumentClient(new BlobContainerClient(
                connectionString,
                GetNewContainerName()));
            BlobServiceClient service = container.GetParentBlobServiceClient();
            Assert.IsTrue(service.CanGenerateAccountSasUri);

            // Act - BlobContainerClient(string connectionString, string blobContainerName, BlobClientOptions options)
            BlobContainerClient container2 = InstrumentClient(new BlobContainerClient(
                connectionString,
                GetNewContainerName(),
                GetOptions()));
            BlobServiceClient service2 = container2.GetParentBlobServiceClient();
            Assert.IsTrue(service2.CanGenerateAccountSasUri);

            // Act - BlobContainerClient(Uri blobContainerUri, BlobClientOptions options = default)
            BlobContainerClient container3 = InstrumentClient(new BlobContainerClient(
                blobEndpoint,
                GetOptions()));
            BlobServiceClient service3 = container3.GetParentBlobServiceClient();
            Assert.IsFalse(service3.CanGenerateAccountSasUri);

            // Act - BlobContainerClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            BlobContainerClient container4 = InstrumentClient(new BlobContainerClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            BlobServiceClient service4 = container4.GetParentBlobServiceClient();
            Assert.IsTrue(service4.CanGenerateAccountSasUri);

            // Act - BlobContainerClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            BlobContainerClient container5 = InstrumentClient(new BlobContainerClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            BlobServiceClient service5 = container5.GetParentBlobServiceClient();
            Assert.IsFalse(service5.CanGenerateAccountSasUri);
        }

        [RecordedTest]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName
            };
            BlobContainerSasPermissions permissions = BlobContainerSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobContainerClient containerClient = InstrumentClient(
                new BlobContainerClient(
                    blobUriBuilder.ToUri(),
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            string stringToSign = null;

            //Act
            Uri sasUri = containerClient.GenerateSasUri(permissions, expiresOn, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                Sas = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName
            };
            BlobContainerSasPermissions permissions = BlobContainerSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobContainerClient containerClient =
                InstrumentClient(new BlobContainerClient(
                    blobUriBuilder.ToUri(),
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName
            };

            string stringToSign = null;

            // Act
            Uri sasUri = containerClient.GenerateSasUri(sasBuilder, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullName()
        {
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName
            };
            BlobContainerSasPermissions permissions = BlobContainerSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobContainerClient containerClient =
                InstrumentClient(new BlobContainerClient(
                    blobUriBuilder.ToUri(),
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = null
            };

            // Act
            Uri sasUri = containerClient.GenerateSasUri(sasBuilder);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobContainerClient containerClient = InstrumentClient(new BlobContainerClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = GetNewContainerName(), // set a different containerName
                Resource = "b"
            };

            // Act
            TestHelper.AssertExpectedException(
                () => containerClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. BlobSasBuilder.BlobContainerName does not match Name in the Client. BlobSasBuilder.BlobContainerName must either be left empty or match the Name in the Client"));
        }
        #endregion

        #region GenerateUserDelegationSas
        [RecordedTest]
        public async Task GenerateUserDelegationSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
            };
            BlobContainerSasPermissions permissions = BlobContainerSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobContainerClient containerClient = InstrumentClient(
                new BlobContainerClient(
                    blobUriBuilder.ToUri(),
                    GetOptions()));

            string stringToSign = null;
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            //Act
            Uri sasUri = containerClient.GenerateUserDelegationSasUri(permissions, expiresOn, userDelegationKey, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                Sas = sasBuilder.ToSasQueryParameters(userDelegationKey, containerClient.AccountName)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName
            };
            BlobContainerSasPermissions permissions = BlobContainerSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobContainerClient containerClient =
                InstrumentClient(new BlobContainerClient(
                    blobUriBuilder.ToUri(),
                    GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
            };

            string stringToSign = null;
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = containerClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, containerClient.AccountName)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNull()
        {
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName
            };
            BlobContainerClient containerClient =
                InstrumentClient(new BlobContainerClient(
                    blobUriBuilder.ToUri(),
                    GetOptions()));

            string stringToSign = null;
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => containerClient.GenerateUserDelegationSasUri(null, userDelegationKey, out stringToSign),
                 new ArgumentNullException("builder"));
        }

        [RecordedTest]
        public void GenerateUserDelegationSas_UserDelegationKeyNull()
        {
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName
            };
            BlobContainerSasPermissions permissions = BlobContainerSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobContainerClient containerClient =
                InstrumentClient(new BlobContainerClient(
                    blobUriBuilder.ToUri(),
                    GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName
            };

            string stringToSign = null;

            // Act
            TestHelper.AssertExpectedException(
                () => containerClient.GenerateUserDelegationSasUri(sasBuilder, null, out stringToSign),
                 new ArgumentNullException("userDelegationKey"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullName()
        {
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName
            };
            BlobContainerSasPermissions permissions = BlobContainerSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobContainerClient containerClient =
                InstrumentClient(new BlobContainerClient(
                    blobUriBuilder.ToUri(),
                    GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = null
            };

            string stringToSign = null;
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = containerClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, containerClient.AccountName)
            };

            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobContainerClient containerClient = InstrumentClient(new BlobContainerClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = GetNewContainerName(), // set a different containerName
                Resource = "b"
            };

            string stringToSign = null;
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => containerClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign),
                new InvalidOperationException("SAS Uri cannot be generated. BlobSasBuilder.BlobContainerName does not match Name in the Client. BlobSasBuilder.BlobContainerName must either be left empty or match the Name in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderIncorrectlySettingBlobName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobContainerClient containerClient = InstrumentClient(new BlobContainerClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName
            };

            string stringToSign = null;
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => containerClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign),
                new InvalidOperationException("SAS Uri cannot be generated. builder.BlobName cannot be set to create a Name SAS."));
        }
        #endregion

        [RecordedTest]
        public void CanMockBlobClientsRetrieval()
        {
            // Arrange
            string blobName = "test";
            string leaseId = "leaseId";
            Mock<BlobContainerClient> containerClientMock = new Mock<BlobContainerClient>();
            Mock<BlockBlobClient> blockBlobClientMock = new Mock<BlockBlobClient>();
            Mock<AppendBlobClient> appendBlobClientMock = new Mock<AppendBlobClient>();
            Mock<PageBlobClient> pageBlobClientMock = new Mock<PageBlobClient>();
            Mock<BlobLeaseClient> blobLeaseClientMock = new Mock<BlobLeaseClient>();
            containerClientMock.Protected().Setup<BlockBlobClient>("GetBlockBlobClientCore", blobName).Returns(blockBlobClientMock.Object);
            containerClientMock.Protected().Setup<AppendBlobClient>("GetAppendBlobClientCore", blobName).Returns(appendBlobClientMock.Object);
            containerClientMock.Protected().Setup<PageBlobClient>("GetPageBlobClientCore", blobName).Returns(pageBlobClientMock.Object);
            containerClientMock.Protected().Setup<BlobLeaseClient>("GetBlobLeaseClientCore", leaseId).Returns(blobLeaseClientMock.Object);

            // Act
            var blockBlobClient = containerClientMock.Object.GetBlockBlobClient(blobName);
            var appendBlobClient = containerClientMock.Object.GetAppendBlobClient(blobName);
            var pageBlobClient = containerClientMock.Object.GetPageBlobClient(blobName);
            var blobLeaseClient = containerClientMock.Object.GetBlobLeaseClient(leaseId);

            // Assert
            Assert.IsNotNull(blockBlobClient);
            Assert.AreSame(blockBlobClientMock.Object, blockBlobClient);
            Assert.IsNotNull(appendBlobClient);
            Assert.AreSame(appendBlobClientMock.Object, appendBlobClient);
            Assert.IsNotNull(pageBlobClient);
            Assert.AreSame(pageBlobClientMock.Object, pageBlobClient);
            Assert.IsNotNull(blobLeaseClient);
            Assert.AreSame(blobLeaseClientMock.Object, blobLeaseClient);
        }

        [RecordedTest]
        public void CanMockBlobServiceClientRetrieval()
        {
            // Arrange
            Mock<BlobContainerClient> containerClientMock = new Mock<BlobContainerClient>();
            Mock<BlobServiceClient> blobServiceClientMock = new Mock<BlobServiceClient>();
            containerClientMock.Protected().Setup<BlobServiceClient>("GetParentBlobServiceClientCore").Returns(blobServiceClientMock.Object);

            // Act
            var blobServiceClient = containerClientMock.Object.GetParentBlobServiceClient();

            // Assert
            Assert.IsNotNull(blobServiceClient);
            Assert.AreSame(blobServiceClientMock.Object, blobServiceClient);
        }

        [RecordedTest]
        public async Task CanGetParentBlobServiceClient()
        {
            // Arrange
            BlobContainerClient container = InstrumentClient(GetServiceClient_SharedKey().GetBlobContainerClient(GetNewContainerName()));

            // Act
            BlobServiceClient service = container.GetParentBlobServiceClient();
            //make sure it's functional
            var containers = await service.GetBlobContainersAsync().ToListAsync();

            // Assert
            Assert.AreEqual(container.AccountName, service.AccountName);
            Assert.IsNotNull(container);

            // Cleanup
            await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CanGetParentBlobServiceClient_WithAccountSAS()
        {
            // Arrange
            BlobContainerClient container = InstrumentClient(GetServiceClient_AccountSas().GetBlobContainerClient(GetNewContainerName()));

            // Act
            BlobServiceClient service = container.GetParentBlobServiceClient();
            //make sure it's functional
            var containers = await service.GetBlobContainersAsync().ToListAsync();

            // Assert
            Assert.AreEqual(container.AccountName, service.AccountName);
            Assert.IsNotNull(container);

            // Cleanup
            await container.DeleteIfExistsAsync();
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task RenameAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            string oldContainerName = GetNewContainerName();
            string newContainerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(oldContainerName));
            await container.CreateAsync();

            // Act
            BlobContainerClient newContainer = await container.RenameAsync(
                destinationContainerName: newContainerName);

            // Assert
            await newContainer.GetPropertiesAsync();

            // Cleanup
            await newContainer.DeleteAsync();
        }

        [RecordedTest]
        [TestCase(nameof(BlobRequestConditions.TagConditions))]
        [TestCase(nameof(BlobRequestConditions.IfMatch))]
        [TestCase(nameof(BlobRequestConditions.IfNoneMatch))]
        [TestCase(nameof(BlobRequestConditions.IfModifiedSince))]
        [TestCase(nameof(BlobRequestConditions.IfUnmodifiedSince))]
        public async Task RenameAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobContainerClient containerClient = new BlobContainerClient(uri, GetOptions());

            BlobRequestConditions conditions = new BlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(BlobRequestConditions.TagConditions):
                    conditions.TagConditions = "TagConditions";
                    break;
                case nameof(BlobRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfModifiedSince):
                    conditions.IfModifiedSince = new DateTimeOffset();
                    break;
                case nameof(BlobRequestConditions.IfUnmodifiedSince):
                    conditions.IfUnmodifiedSince = new DateTimeOffset();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                containerClient.RenameAsync(
                    "destination",
                    conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"Rename does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("sourceConditions"));
                });
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task RenameAsync_AccountSas()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            string oldContainerName = GetNewContainerName();
            string newContainerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(oldContainerName));
            await container.CreateAsync();
            SasQueryParameters sasQueryParameters = BlobsClientBuilder.GetNewAccountSas();
            service = InstrumentClient(new BlobServiceClient(new Uri($"{service.Uri}?{sasQueryParameters}"), GetOptions()));
            BlobContainerClient sasContainer = InstrumentClient(service.GetBlobContainerClient(oldContainerName));

            // Act
            BlobContainerClient newContainer = await sasContainer.RenameAsync(
                destinationContainerName: newContainerName);

            // Assert
            await newContainer.GetPropertiesAsync();

            // Cleanup
            await newContainer.DeleteAsync();
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task RenameAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient containerClient = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                containerClient.RenameAsync(GetNewContainerName()),
                e => Assert.AreEqual(BlobErrorCode.ContainerNotFound.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task RenameAsync_SourceLease()
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
            BlobContainerClient newContainer = await container.RenameAsync(
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
        public async Task RenameAsync_SourceLeaseFailed()
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
                container.RenameAsync(
                    destinationContainerName: newContainerName,
                    sourceConditions: sourceConditions),
                e => Assert.AreEqual(BlobErrorCode.LeaseNotPresentWithContainerOperation.ToString(), e.ErrorCode));

            // Cleanup
            await container.DeleteAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2021_04_10)]
        public async Task FilterBlobsByTag()
        {
            // Arrange
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
            await foreach (TaggedBlobItem taggedBlobItem in test.Container.FindBlobsByTagsAsync(expression))
            {
                blobs.Add(taggedBlobItem);
            }

            // Assert
            TaggedBlobItem filterBlob = blobs.Where(r => r.BlobName == blobName).FirstOrDefault();
            Assert.AreEqual(1, filterBlob.Tags.Count);
            Assert.AreEqual("myTagValue", filterBlob.Tags["myTagKey"]);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2021_04_10)]
        [TestCase(BlobContainerSasPermissions.Filter)]
        [TestCase(BlobContainerSasPermissions.All)]
        public async Task FindBlobsByTag_ContainerSAS(BlobContainerSasPermissions containerSasPermissions)
        {
            // Arrange
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

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = test.Container.Name,
                ExpiresOn = Recording.UtcNow.AddDays(1)
            };
            blobSasBuilder.SetPermissions(containerSasPermissions);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                Sas = blobSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials())
            };

            BlobContainerClient sasContainerClient = InstrumentClient(new BlobContainerClient(blobUriBuilder.ToUri(), GetOptions()));

            // Act
            List<TaggedBlobItem> blobs = new List<TaggedBlobItem>();
            await foreach (TaggedBlobItem taggedBlobItem in sasContainerClient.FindBlobsByTagsAsync(expression))
            {
                blobs.Add(taggedBlobItem);
            }

            // Assert
            TaggedBlobItem filterBlob = blobs.Where(r => r.BlobName == blobName).FirstOrDefault();
            Assert.AreEqual(1, filterBlob.Tags.Count);
            Assert.AreEqual("myTagValue", filterBlob.Tags["myTagKey"]);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2021_04_10)]
        public async Task FindBlobsByTagAsync_Error()
        {
            // Arrange
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.FindBlobsByTagsAsync("\"key\" = 'value'").AsPages().FirstAsync(),
                e => Assert.AreEqual(BlobErrorCode.NoAuthenticationInformation.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        public async Task GetAccountInfoAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            // Act
            Response<AccountInfo> response = await test.Container.GetAccountInfoAsync();

            // Assert
            Assert.AreEqual(SkuName.StandardRagrs, response.Value.SkuName);
            Assert.AreEqual(AccountKind.StorageV2, response.Value.AccountKind);
            Assert.IsFalse(response.Value.IsHierarchicalNamespaceEnabled);
        }

        [RecordedTest]
        public async Task GetAccountInfoAsync_Error()
        {
            // Arrange
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    BlobsClientBuilder.GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            BlobContainerClient containerClient = service.GetBlobContainerClient(GetNewContainerName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                containerClient.GetAccountInfoAsync(),
                e => Assert.AreEqual("NoAuthenticationInformation", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2025_07_05)]
        public async Task GetAccountInfoAsync_OAuth()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(service);

            // Act
            await test.Container.GetAccountInfoAsync();
        }

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<BlobContainerClient>(TestConfigDefault.ConnectionString, "name", new BlobClientOptions()).Object;
            mock = new Mock<BlobContainerClient>(TestConfigDefault.ConnectionString, "name").Object;
            mock = new Mock<BlobContainerClient>(new Uri("https://test/test"), new BlobClientOptions()).Object;
            mock = new Mock<BlobContainerClient>(new Uri("https://test/test"), Tenants.GetNewSharedKeyCredentials(), new BlobClientOptions()).Object;
            mock = new Mock<BlobContainerClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new BlobClientOptions()).Object;
            mock = new Mock<BlobContainerClient>(new Uri("https://test/test"), TestEnvironment.Credential, new BlobClientOptions()).Object;
        }

        [RecordedTest]
        public async Task InvalidServiceVersion()
        {
            BlobClientOptions clientOptions = GetOptions();
            clientOptions.AddPolicy(new InvalidServiceVersionPipelinePolicy(), HttpPipelinePosition.PerCall);
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_SharedKey(clientOptions);
            BlobContainerClient containerClient = InstrumentClient(serviceClient.GetBlobContainerClient(GetNewContainerName()));

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                containerClient.CreateAsync(),
                e =>
                {
                    Assert.AreEqual(Constants.ErrorCodes.InvalidHeaderValue, e.ErrorCode);
                    Assert.IsTrue(e.Message.Contains(Constants.Errors.InvalidVersionHeaderMessage));
                });
        }

        #region Secondary Storage
        [RecordedTest]
        public async Task ListContainersSegmentAsync_SecondaryStorageFirstRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(1); // one GET failure means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageFirstRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        private async Task<TestExceptionPolicy> PerformSecondaryStorageTest(int numberOfReadFailuresToSimulate, bool retryOn404 = false)
        {
            BlobContainerClient containerClient = GetBlobContainerClient_SecondaryAccount_ReadEnabledOnRetry(numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, retryOn404);
            await containerClient.CreateIfNotExistsAsync();

            Response<BlobContainerProperties> properties = await EnsurePropagatedAsync(
                async () => await containerClient.GetPropertiesAsync(),
                properties => properties.GetRawResponse().Status != 404);

            Assert.IsNotNull(properties);
            Assert.AreEqual(200, properties.GetRawResponse().Status);

            await containerClient.DeleteIfExistsAsync();
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
