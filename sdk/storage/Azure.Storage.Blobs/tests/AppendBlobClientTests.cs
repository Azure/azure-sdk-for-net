// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Sas;
using Azure.Storage.Shared;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests.Shared;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class AppendBlobClientTests : BlobTestBase
    {
        public AppendBlobClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();

            AppendBlobClient blob = InstrumentClient(new AppendBlobClient(connectionString.ToString(true), containerName, blobName, GetOptions()));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [RecordedTest]
        public void Ctor_Uri()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();

            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName}");

            // Act
            AppendBlobClient appendBlobClient = new AppendBlobClient(uri);

            // Assert
            BlobUriBuilder builder = new BlobUriBuilder(appendBlobClient.Uri);

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual(accountName, builder.AccountName);
        }

        [RecordedTest]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new AppendBlobClient(httpUri, TestEnvironment.Credential),
                 new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [RecordedTest]
        public void Ctor_CPK_Http()
        {
            // Arrange
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlobClientOptions blobClientOptions = new BlobClientOptions
            {
                CustomerProvidedKey = customerProvidedKey
            };
            Uri httpUri = new Uri(TestConfigDefault.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new AppendBlobClient(httpUri, blobClientOptions),
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
                () => new AppendBlobClient(new Uri(TestConfigDefault.BlobServiceEndpoint), blobClientOptions),
                new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set"));
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            var client = test.Container.GetAppendBlobClient(GetNewBlobName());
            await client.CreateAsync();
            Uri blobUri = client.Uri;

            // Act
            var sasClient = InstrumentClient(new AppendBlobClient(blobUri, new AzureSasCredential(sas), GetOptions()));
            BlobProperties blobProperties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(blobProperties);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            Uri blobUri = test.Container.GetAppendBlobClient("foo").Uri;
            blobUri = new Uri(blobUri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new AppendBlobClient(blobUri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.DefaultAudience);

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            AppendBlobClient aadBlob = InstrumentClient(new AppendBlobClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadBlob.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_CustomAudience()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(new BlobAudience($"https://{test.Container.AccountName}.blob.core.windows.net/"));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            AppendBlobClient aadBlob = InstrumentClient(new AppendBlobClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadBlob.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.CreateBlobServiceAccountAudience(test.Container.AccountName));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            AppendBlobClient aadBlob = InstrumentClient(new AppendBlobClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadBlob.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(new BlobAudience("https://badaudience.blob.core.windows.net"));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            AppendBlobClient aadBlob = InstrumentClient(new AppendBlobClient(
                uriBuilder.ToUri(),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadBlob.ExistsAsync(),
                e => Assert.AreEqual(BlobErrorCode.InvalidAuthenticationInfo.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        public void WithSnapshot()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = "my/blob/name";
            string snapshot = "2020-07-03T12:45:46.1234567Z";
            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName.EscapePath()}");
            Uri snapshotUri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName.EscapePath()}?snapshot={snapshot}");

            // Act
            AppendBlobClient appendBlobClient = new AppendBlobClient(uri);
            AppendBlobClient snapshotAppendBlobClient = appendBlobClient.WithSnapshot(snapshot);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(snapshotAppendBlobClient.Uri);

            // Assert
            Assert.AreEqual(accountName, snapshotAppendBlobClient.AccountName);
            Assert.AreEqual(containerName, snapshotAppendBlobClient.BlobContainerName);
            Assert.AreEqual(blobName, snapshotAppendBlobClient.Name);
            Assert.AreEqual(snapshotUri, snapshotAppendBlobClient.Uri);

            Assert.AreEqual(accountName, blobUriBuilder.AccountName);
            Assert.AreEqual(containerName, blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual(snapshot, blobUriBuilder.Snapshot);
            Assert.AreEqual(snapshotUri, blobUriBuilder.ToUri());
        }

        [RecordedTest]
        public void WithVersion()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = "my/blob/name";
            string versionId = "2020-07-03T12:45:46.1234567Z";
            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName.EscapePath()}");
            Uri versionUri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName.EscapePath()}?versionid={versionId}");

            // Act
            AppendBlobClient appendBlobClient = new AppendBlobClient(uri);
            AppendBlobClient versionAppendBlobClient = appendBlobClient.WithVersion(versionId);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(versionAppendBlobClient.Uri);

            // Assert
            Assert.AreEqual(accountName, versionAppendBlobClient.AccountName);
            Assert.AreEqual(containerName, versionAppendBlobClient.BlobContainerName);
            Assert.AreEqual(blobName, versionAppendBlobClient.Name);
            Assert.AreEqual(versionUri, versionAppendBlobClient.Uri);

            Assert.AreEqual(accountName, blobUriBuilder.AccountName);
            Assert.AreEqual(containerName, blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual(versionId, blobUriBuilder.VersionId);
            Assert.AreEqual(versionUri, blobUriBuilder.ToUri());
        }

        [RecordedTest]
        public async Task CreateAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);
        }

        [RecordedTest]
        [TestCase(nameof(AppendBlobRequestConditions.IfAppendPositionEqual))]
        [TestCase(nameof(AppendBlobRequestConditions.IfMaxSizeLessThanOrEqual))]
        public async Task CreateAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            AppendBlobClient appendBlobClient = new AppendBlobClient(uri, GetOptions());

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(AppendBlobRequestConditions.IfAppendPositionEqual):
                    conditions.IfAppendPositionEqual = 0;
                    break;
                case nameof(AppendBlobRequestConditions.IfMaxSizeLessThanOrEqual):
                    conditions.IfMaxSizeLessThanOrEqual = 0;
                    break;
            }

            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Conditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                appendBlobClient.CreateAsync(
                    options),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"Create does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_Tags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Tags = BuildTags()
            };

            // Act
            await blob.CreateAsync(options);
            Response<GetBlobTagResult> response = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(options.Tags, response.Value.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_TagsWithSpecialCharacters()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Tags = new Dictionary<string, string>
                {
                    { " +-.:", "_ =" },
                    { "+-.:= _", "+ // _"}
                }
            };

            // Act
            await blob.CreateAsync(options);
            Response<GetBlobTagResult> response = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(options.Tags, response.Value.Tags);
        }

        [RecordedTest]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await blob.CreateAsync(
                metadata: metadata);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task CreateAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync();

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CreateAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_12_06)]
        public async Task CreateAsync_EncryptionScopeSAS()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                BlobContainerName = test.Container.Name,
                BlobName = blobName,
                EncryptionScope = TestConfigDefault.EncryptionScope,
                ExpiresOn = Recording.UtcNow.AddDays(1)
            };
            blobSasBuilder.SetPermissions(BlobSasPermissions.All);

            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(
                new StorageSharedKeyCredential(
                    TestConfigDefault.AccountName,
                    TestConfigDefault.AccountKey));

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                BlobName = blobName,
                Sas = sasQueryParameters
            };

            AppendBlobClient sasBlob = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));

            byte[] data = GetRandomBuffer(Constants.KB);

            // Act
            Response<BlobContentInfo> response = await sasBlob.CreateIfNotExistsAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_12_06)]
        public async Task CreateAsync_EncryptionScopeSAS_GenerateSasUri()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blobClient = InstrumentClient(
                test.Container.GetAppendBlobClient(GetNewBlobName()).WithEncryptionScope(TestConfigDefault.EncryptionScope));
            Uri sasUri = blobClient.GenerateSasUri(
                BlobSasPermissions.All,
                Recording.UtcNow.AddDays(1));
            AppendBlobClient sasBlob = InstrumentClient(new AppendBlobClient(sasUri, GetOptions()));

            // Act
            Response<BlobContentInfo> response = await sasBlob.CreateIfNotExistsAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_12_06)]
        public async Task CreateAsync_EncryptionScopeAccountSAS()
        {
            // Arrange
            string containerName = GetNewContainerName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);
            BlobServiceClient blobServiceClient = BlobsClientBuilder.GetServiceClient_SharedKey();

            AccountSasBuilder accountSasBuilder = new AccountSasBuilder(
                permissions: AccountSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1),
                services: AccountSasServices.All,
                resourceTypes: AccountSasResourceTypes.All);
            accountSasBuilder.EncryptionScope = TestConfigDefault.EncryptionScope;

            Uri accountSasUri = blobServiceClient.GenerateAccountSasUri(accountSasBuilder);
            blobServiceClient = InstrumentClient(new BlobServiceClient(accountSasUri, GetOptions()));
            BlobContainerClient containerClient = InstrumentClient(blobServiceClient.GetBlobContainerClient(containerName));
            AppendBlobClient blob = InstrumentClient(containerClient.GetAppendBlobClient(GetNewBlobName()));

            // Act
            Response<BlobContentInfo> response = await blob.CreateIfNotExistsAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_12_06)]
        public async Task CreateAsync_EncryptionScopeIdentitySAS()
        {
            // Arrange
            BlobServiceClient oauthService = BlobsClientBuilder.GetServiceClient_OAuth(TestEnvironment.Credential);
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            string blobName = GetNewBlobName();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                BlobContainerName = test.Container.Name,
                BlobName = blobName,
                EncryptionScope = TestConfigDefault.EncryptionScope,
                ExpiresOn = Recording.UtcNow.AddDays(1)
            };
            blobSasBuilder.SetPermissions(BlobSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                BlobName = blobName,
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, Tenants.TestConfigOAuth.AccountName)
            };
            AppendBlobClient sasBlob = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));

            // Act
            Response<BlobContentInfo> response = await sasBlob.CreateIfNotExistsAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        //TODO
        [Ignore("Not yet implemented")]
        [RecordedTest]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task CreateAsync_Headers()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
        }

        [RecordedTest]
        public async Task CreateAsync_Error()
        {
            // Arrange
            BlobServiceClient blobService = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobContainerClient containerClient = InstrumentClient(blobService.GetBlobContainerClient(GetNewContainerName()));
            AppendBlobClient blob = InstrumentClient(containerClient.GetAppendBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateAsync(),
                actualException => Assert.AreEqual(BlobErrorCode.ContainerNotFound.ToString(), actualException.ErrorCode)
                );
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync();

            // Assert
            Assert.IsNotNull(response.Value.VersionId);
        }

        [RecordedTest]
        public async Task CreateAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] data = new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId }
            };
            foreach (AccessConditionParameters parameters in data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateAsync();
                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobContentInfo> response = await blob.CreateAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task CreateAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] data = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };
            foreach (AccessConditionParameters parameters in data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateAsync();
                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.CreateAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await blob.CreateAsync(conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateAsync(
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            // Act
            Response<BlobContentInfo> response = await blob.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            Response<BlobContentInfo> response = await blob.CreateIfNotExistsAsync();

            // Act
            Response<BlobContentInfo> responseExists = await blob.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_Error()
        {
            // Arrange
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobContainerClient containerClient = InstrumentClient(serviceClient.GetBlobContainerClient(GetNewContainerName()));
            AppendBlobClient blob = InstrumentClient(containerClient.GetAppendBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateIfNotExistsAsync(),
                actualException => Assert.AreEqual(BlobErrorCode.ContainerNotFound.ToString(), actualException.ErrorCode)
                );
        }

        [RecordedTest]
        public async Task AppendBlockAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateIfNotExistsAsync();
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            // Act
            Response<BlobAppendInfo> response;
            using (var stream = new MemoryStream(data))
            {
                response = await blob.AppendBlockAsync(stream);
            }

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Check if block was appeneded correctly by Downloading the block
            Response<BlobDownloadInfo> result = await blob.DownloadAsync(new HttpRange(0, data.Length));
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task AppendBlockAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            var data = GetRandomBuffer(Constants.KB);
            await blob.CreateIfNotExistsAsync();

            // Act
            using var stream = new MemoryStream(data);
            Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                content: stream);

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AppendBlockAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            var data = GetRandomBuffer(Constants.KB);
            await blob.CreateIfNotExistsAsync();

            // Act
            using var stream = new MemoryStream(data);
            Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                content: stream);

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [RecordedTest]
        public async Task AppendBlockAsync_MD5()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                    content: stream,
                    transactionalContentHash: MD5.Create().ComputeHash(data),
                    conditions: null,
                    progressHandler: null,
                    cancellationToken: CancellationToken.None);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task AppendBlockAsync_MD5Fail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.AppendBlockAsync(
                        content: stream,
                        transactionalContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garbage")),
                        conditions: null,
                        progressHandler: null,
                        cancellationToken: CancellationToken.None),
                    e => Assert.AreEqual("Md5Mismatch", e.ErrorCode));
            }
        }

        [RecordedTest]
        public async Task AppendBlockAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.AppendBlockAsync(stream),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [RecordedTest]
        public async Task AppendBlockAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId },
                new AccessConditionParameters { AppendPosE = 0 },
                new AccessConditionParameters { MaxSizeLTE = 100 }
            };
            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await blob.CreateIfNotExistsAsync();
                var data = GetRandomBuffer(7);
                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true,
                    appendPosAndMaxSize: true);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                        content: stream,
                        options: new AppendBlobAppendBlockOptions
                        {
                            Conditions = accessConditions
                        });

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [RecordedTest]
        public async Task AppendBlockAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { AppendPosE = 1 },
                new AccessConditionParameters { MaxSizeLTE = 1 }
            };
            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(7);
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateIfNotExistsAsync();
                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true,
                    appendPosAndMaxSize: true);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        blob.AppendBlockAsync(
                            content: stream,
                            options: new AppendBlobAppendBlockOptions
                            {
                                Conditions = accessConditions
                            }),
                        e => { });
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AppendBlockAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = test.Container.GetAppendBlobClient(GetNewBlobName());
            await blob.CreateAsync();
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);
            using Stream stream = new MemoryStream(data);

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                content: stream,
                options: new AppendBlobAppendBlockOptions
                {
                    Conditions = conditions
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AppendBlockAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = test.Container.GetAppendBlobClient(GetNewBlobName());
            await blob.CreateAsync();

            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);
            using Stream stream = new MemoryStream(data);

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.AppendBlockAsync(
                    content: stream,
                    options: new AppendBlobAppendBlockOptions
                    {
                        Conditions = conditions
                    }),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [RecordedTest]
        public async Task AppendBlockAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobContainerClient containerFaulty = InstrumentClient(
                new BlobContainerClient(
                    test.Container.Uri,
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetFaultyBlobConnectionOptions()));

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blobFaulty = InstrumentClient(containerFaulty.GetAppendBlobClient(blobName));
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            await blob.CreateIfNotExistsAsync();

            var data = GetRandomBuffer(blobSize);
            var progressBag = new System.Collections.Concurrent.ConcurrentBag<long>();
            var progressHandler = new Progress<long>(progress => progressBag.Add(progress));
            var timesFaulted = 0;

            // Act
            using (var stream = new FaultyStream(
                new MemoryStream(data),
                256 * Constants.KB,
                1,
                new IOException("Simulated stream fault"),
                () => timesFaulted++))
            {
                await blobFaulty.AppendBlockAsync(
                    content: stream,
                    options: new AppendBlobAppendBlockOptions
                    {
                        ProgressHandler = progressHandler
                    });
                await WaitForProgressAsync(progressBag, data.LongLength);
                Assert.IsTrue(progressBag.Count > 1, "Too few progress received");
                // Changing from Assert.AreEqual because these don't always update fast enough
                if (progressBag.Count > 0)
                {
                    Assert.GreaterOrEqual(data.LongLength, progressBag.Max(), "Final progress has unexpected value");
                }
            }

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            Assert.AreEqual(data.Length, actual.Length);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreNotEqual(0, timesFaulted);
        }

        [LiveOnly]
        [Test]
        public async Task AppendBlockAsync_ProgressReporting()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateIfNotExistsAsync();
            const int blobSize = 4 * Constants.MB;
            var data = GetRandomBuffer(blobSize);
            TestProgress progress = new TestProgress();

            // Act
            using (var stream = new MemoryStream(data))
            {
                await blob.AppendBlockAsync(
                    content: stream,
                    options: new AppendBlobAppendBlockOptions
                    {
                        ProgressHandler = progress
                    });
            }

            // Assert
            Assert.IsFalse(progress.List.Count == 0);

            Assert.AreEqual(blobSize, progress.List[progress.List.Count - 1]);
        }

        [RecordedTest]
        public async Task AppendBlockAsync_InvalidStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            // Act
            using Stream stream = new MemoryStream(data);
            stream.Position = stream.Length;

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.AppendBlockAsync(stream),
                e => Assert.AreEqual("content.Position must be less than content.Length. Please set content.Position to the start of the data to upload.", e.Message));
        }

        [RecordedTest]
        public async Task AppendBlockAsync_NonZeroStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            const int blobSize = Constants.KB;
            long position = 512;
            byte[] data = GetRandomBuffer(blobSize);
            byte[] expectedData = new byte[blobSize - position];
            Array.Copy(data, position, expectedData, 0, blobSize - position);

            // Act
            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };
            await blob.AppendBlockAsync(stream);

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync();
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(blobSize - position, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2022_11_02)]
        public async Task AppendBlockAsync_HighThroughputAppendBlob()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateIfNotExistsAsync();
            const int blobSize = 5 * Constants.MB;
            var data = GetRandomBuffer(blobSize);

            // Act
            Response<BlobAppendInfo> response;
            using (var stream = new MemoryStream(data))
            {
                response = await blob.AppendBlockAsync(stream);
            }

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Check if block was appeneded correctly by Downloading the block
            Response<BlobDownloadInfo> result = await blob.DownloadAsync(new HttpRange(0, data.Length));
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task AppendBlockFromUriAsync_Min()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync();

                AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
                {
                    SourceRange = new HttpRange(0, Constants.KB)
                };

                // Act
                Response<BlobAppendInfo> response = await destBlob.AppendBlockFromUriAsync(
                    sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    options);

                // Ensure that we grab the whole ETag value from the service without removing the quotes
                Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2024_08_04)]
        public async Task AppendBlockFromUriAsync_SourceErrorAndStatusCode()
        {
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);

            AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await destBlob.CreateIfNotExistsAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.AppendBlockFromUriAsync(sourceBlob.Uri),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("CopySourceStatusCode: 401"));
                    Assert.IsTrue(e.Message.Contains("CopySourceErrorCode: NoAuthenticationInformation"));
                    Assert.IsTrue(e.Message.Contains("CopySourceErrorMessage: Server failed to authenticate the request. Please refer to the information in the www-authenticate header."));
                });
        }

        [RecordedTest]
        [TestCase(nameof(AppendBlobRequestConditions.LeaseId))]
        [TestCase(nameof(AppendBlobRequestConditions.TagConditions))]
        [TestCase(nameof(AppendBlobRequestConditions.IfAppendPositionEqual))]
        [TestCase(nameof(AppendBlobRequestConditions.IfMaxSizeLessThanOrEqual))]
        public async Task AppendBlockFromUriAsync_InvalidSourceRequestConditions(string invalidSourceCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            AppendBlobClient appendBlobClient = new AppendBlobClient(uri, GetOptions());

            AppendBlobRequestConditions sourceConditions = new AppendBlobRequestConditions();

            switch (invalidSourceCondition)
            {
                case nameof(AppendBlobRequestConditions.LeaseId):
                    sourceConditions.LeaseId = "LeaseId";
                    break;
                case nameof(AppendBlobRequestConditions.TagConditions):
                    sourceConditions.TagConditions = "TagConditions";
                    break;
                case nameof(AppendBlobRequestConditions.IfAppendPositionEqual):
                    sourceConditions.IfAppendPositionEqual = 0;
                    break;
                case nameof(AppendBlobRequestConditions.IfMaxSizeLessThanOrEqual):
                    sourceConditions.IfMaxSizeLessThanOrEqual = 0;
                    break;
            }

            AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
            {
                SourceConditions = sourceConditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                appendBlobClient.AppendBlockFromUriAsync(
                    uri,
                    options),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"AppendBlockFromUri does not support the {invalidSourceCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("sourceConditions"));
                });
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task AppendBlockFromUriAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                destBlob = InstrumentClient(destBlob.WithCustomerProvidedKey(customerProvidedKey));
                await destBlob.CreateIfNotExistsAsync();

                AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
                {
                    SourceRange = new HttpRange(0, Constants.KB)
                };

                Uri sourceUri = sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddDays(1));

                // Act
                Response<BlobAppendInfo> response = await destBlob.AppendBlockFromUriAsync(
                    sourceUri,
                    options);

                Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AppendBlockFromUriAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                destBlob = InstrumentClient(destBlob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
                await destBlob.CreateIfNotExistsAsync();

                AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
                {
                    SourceRange = new HttpRange(0, Constants.KB)
                };

                // Act
                Response<BlobAppendInfo> response = await destBlob.AppendBlockFromUriAsync(
                    sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    options);

                Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
            }
        }

        [RecordedTest]
        public async Task AppendBlockFromUriAsync_Range()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(4 * Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync();

                AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
                {
                    SourceRange = new HttpRange(2 * Constants.KB, 2 * Constants.KB)
                };

                // Act
                await destBlob.AppendBlockFromUriAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    options: options);

                // Assert
                Response<BlobDownloadInfo> result = await destBlob.DownloadAsync(new HttpRange(0, 2 * Constants.KB));
                var dataResult = new MemoryStream();
                await result.Value.Content.CopyToAsync(dataResult);
                Assert.AreEqual(2 * Constants.KB, dataResult.Length);
                TestHelper.AssertSequenceEqual(data.Skip(2 * Constants.KB).Take(2 * Constants.KB), dataResult.ToArray());
            }
        }

        [RecordedTest]
        public async Task AppendBlockFromUriAsync_MD5()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync();

                AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
                {
                    SourceContentHash = MD5.Create().ComputeHash(data)
                };

                // Act
                await destBlob.AppendBlockFromUriAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    options: options);
            }
        }

        [RecordedTest]
        public async Task AppendBlockFromUriAsync_MD5_Fail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync();

                AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
                {
                    SourceContentHash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garabage"))
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.AppendBlockFromUriAsync(
                        sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                        options: options),
                    actualException => Assert.AreEqual("Md5Mismatch", actualException.ErrorCode)
                );
            }
        }

        [RecordedTest]
        public async Task AppendBlockFromUriAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId },
                new AccessConditionParameters { AppendPosE = 0 },
                new AccessConditionParameters { MaxSizeLTE = 100 },
                new AccessConditionParameters { SourceIfModifiedSince = OldDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = NewDate },
                new AccessConditionParameters { SourceIfMatch = ReceivedETag },
                new AccessConditionParameters { SourceIfNoneMatch = GarbageETag }
            };
            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(7);

                using (var stream = new MemoryStream(data))
                {
                    AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await sourceBlob.CreateIfNotExistsAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await destBlob.CreateIfNotExistsAsync();

                    parameters.Match = await SetupBlobMatchCondition(destBlob, parameters.Match);
                    parameters.SourceIfMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                    parameters.LeaseId = await SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                    AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                        parameters: parameters,
                        lease: true,
                        appendPosAndMaxSize: true);
                    AppendBlobRequestConditions sourceAccessConditions = BuildSourceAccessConditions(parameters);

                    AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
                    {
                        DestinationConditions = accessConditions,
                        SourceConditions = sourceAccessConditions
                    };

                    // Act
                    await destBlob.AppendBlockFromUriAsync(
                        sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                        options: options);
                }
            }
        }

        [RecordedTest]
        public async Task AppendBlockFromUriAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { AppendPosE = 1 },
                new AccessConditionParameters { MaxSizeLTE = 1 },
                new AccessConditionParameters { SourceIfModifiedSince = NewDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = OldDate },
                new AccessConditionParameters { SourceIfMatch = GarbageETag },
                new AccessConditionParameters { SourceIfNoneMatch = ReceivedETag }
            };
            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(7);

                using (var stream = new MemoryStream(data))
                {
                    AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await sourceBlob.CreateIfNotExistsAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await destBlob.CreateIfNotExistsAsync();

                    parameters.NoneMatch = await SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                    parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);

                    AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                        parameters: parameters,
                        lease: true,
                        appendPosAndMaxSize: true);
                    AppendBlobRequestConditions sourceAccessConditions = BuildSourceAccessConditions(parameters);

                    AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
                    {
                        DestinationConditions = accessConditions,
                        SourceConditions = sourceAccessConditions
                    };

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        destBlob.AppendBlockFromUriAsync(
                            sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                            options: options),
                        actualException => Assert.IsTrue(true)
                    );
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AppendBlockFromUriAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await sourceBlob.CreateAsync();
            await sourceBlob.AppendBlockAsync(stream);

            AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await destBlob.CreateAsync();

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await destBlob.SetTagsAsync(tags);

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
            {
                DestinationConditions = conditions,
                SourceRange = new HttpRange(0, Constants.KB)
            };

            // Act
            await destBlob.AppendBlockFromUriAsync(
                sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                options: options);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AppendBlockFromUriAsync_IfTagsFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await sourceBlob.CreateAsync();
            await sourceBlob.AppendBlockAsync(stream);

            AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await destBlob.CreateAsync();

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
            {
                DestinationConditions = conditions,
                SourceRange = new HttpRange(0, Constants.KB)
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.AppendBlockFromUriAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    options: options),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [RecordedTest]
        // Net462 is sending the source SAS expiry unencoded to the service, while net6 and net7 sending it encoded.
        // Both are valid, but make this test non-recordable.
        [LiveOnly]
        public async Task AppendBlockFromUriAsync_NonAsciiSourceUri()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewNonAsciiBlobName()));
                await sourceBlob.CreateAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync();

                AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
                {
                    SourceRange = new HttpRange(0, Constants.KB)
                };

                // Act
                await destBlob.AppendBlockFromUriAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    options: options);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        [RetryOnException(5, typeof(RequestFailedException))]
        public async Task AppendBlockFromUriAsync_SourceBearerToken()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            byte[] data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);
            AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await sourceBlob.CreateIfNotExistsAsync();
            await sourceBlob.AppendBlockAsync(stream);

            AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await destBlob.CreateIfNotExistsAsync();

            string sourceBearerToken = await GetAuthToken();

            HttpAuthorization sourceAuth = new HttpAuthorization(
                "Bearer",
                sourceBearerToken);

            AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
            {
                SourceAuthentication = sourceAuth
            };

            // Act
            await destBlob.AppendBlockFromUriAsync(sourceBlob.Uri, options);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task AppendBlockFromUriAsync_SourceBearerTokenFail()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            byte[] data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);
            AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await sourceBlob.CreateIfNotExistsAsync();
            await sourceBlob.AppendBlockAsync(stream);

            AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await destBlob.CreateIfNotExistsAsync();

            HttpAuthorization sourceAuth = new HttpAuthorization(
                "Bearer",
                "auth token");

            AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
            {
                SourceAuthentication = sourceAuth
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.AppendBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    options: options),
                e => Assert.AreEqual(BlobErrorCode.CannotVerifyCopySource.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2025_07_05)]
        [RetryOnException(5, typeof(RequestFailedException))]
        public async Task AppendBlockFromUriAsync_SourceBearerToken_FilesSource()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            byte[] data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            ShareServiceClient shareServiceClient = GetShareServiceClient_OAuthAccount_SharedKey();
            ShareClient shareClient = await shareServiceClient.CreateShareAsync(GetNewContainerName());
            try
            {
                ShareDirectoryClient directoryClient = await shareClient.CreateDirectoryAsync(GetNewBlobName());
                ShareFileClient fileClient = await directoryClient.CreateFileAsync(GetNewBlobName(), Constants.KB);
                await fileClient.UploadAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync();

                string sourceBearerToken = await GetAuthToken();

                HttpAuthorization sourceAuth = new HttpAuthorization(
                    "Bearer",
                    sourceBearerToken);

                AppendBlobAppendBlockFromUriOptions options = new AppendBlobAppendBlockFromUriOptions
                {
                    SourceAuthentication = sourceAuth,
                    SourceShareTokenIntent = FileShareTokenIntent.Backup
                };

                // Act
                await destBlob.AppendBlockFromUriAsync(fileClient.Uri, options);
            }
            finally
            {
                await shareClient.DeleteAsync();
            }
        }

        [RecordedTest]
        public async Task AppendBlockFromUriAsync_NullOptions()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync();

                // Act
                Response<BlobAppendInfo> response = await destBlob.AppendBlockFromUriAsync(
                    sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)));

                // Ensure that we grab the whole ETag value from the service without removing the quotes
                Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            }
        }

        [RecordedTest]
        public async Task AppendBlockAsync_NullStream_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));

            // Act
            using (var stream = (MemoryStream)null)
            {
                // Check if the correct param name that is causing the error is being returned
                await TestHelper.AssertExpectedExceptionAsync<ArgumentNullException>(
                    blob.AppendBlockAsync(content: stream),
                    e => Assert.AreEqual("content", e.ParamName));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SealAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await appendBlob.CreateAsync();

            // Act
            Response<BlobInfo> response = await appendBlob.SealAsync();
            Response<BlobProperties> propertiesResponse = await appendBlob.GetPropertiesAsync();
            Response<BlobDownloadInfo> downloadResponse = await appendBlob.DownloadAsync();
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Ensure the blob is correctly sealed
            Assert.IsTrue(propertiesResponse.Value.IsSealed);
            Assert.IsTrue(downloadResponse.Value.Details.IsSealed);
            Assert.IsTrue(blobs.First().Properties.IsSealed);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(nameof(AppendBlobRequestConditions.IfMaxSizeLessThanOrEqual))]
        [TestCase(nameof(AppendBlobRequestConditions.TagConditions))]
        public async Task SealAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            AppendBlobClient appendBlobClient = new AppendBlobClient(uri, GetOptions());

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(AppendBlobRequestConditions.IfMaxSizeLessThanOrEqual):
                    conditions.IfMaxSizeLessThanOrEqual = 0;
                    break;
                case nameof(AppendBlobRequestConditions.TagConditions):
                    conditions.TagConditions = "TagConditions";
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                appendBlobClient.SealAsync(
                    conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"Seal does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SealAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                appendBlob.SealAsync(),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SealAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId },
                new AccessConditionParameters { AppendPosE = 0 },
            };

            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await blob.CreateAsync();
                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true,
                    appendPosAndMaxSize: true);

                // Act
                Response<BlobInfo> response = await blob.SealAsync(accessConditions);

                // Assert
                Assert.IsNotNull(response.Value.ETag);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SealAsync_AccessConditionsFailed()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { AppendPosE = 1 },
            };

            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateAsync();
                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true,
                    appendPosAndMaxSize: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.SealAsync(
                        conditions: accessConditions),
                    e => { });
            }
        }

        public async Task GetAppendBlobClient_AsciiName()
        {
            //Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();

            //Act
            AppendBlobClient blob = test.Container.GetAppendBlobClient(blobName);
            await blob.CreateAsync();

            //Assert
            List<string> names = new List<string>();
            await foreach (BlobItem pathItem in test.Container.GetBlobsAsync())
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(blobName, names);
        }

        [RecordedTest]
        public async Task GetAppendBlobClient_NonAsciiName()
        {
            //Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewNonAsciiBlobName();

            //Act
            AppendBlobClient blob = test.Container.GetAppendBlobClient(blobName);
            await blob.CreateAsync();

            //Assert
            List<string> names = new List<string>();
            await foreach (BlobItem pathItem in test.Container.GetBlobsAsync())
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(blobName, names);
        }

        [RecordedTest]
        public async Task WithCustomerProvidedKey()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            AppendBlobClient cpkBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()).WithCustomerProvidedKey(customerProvidedKey));
            await cpkBlob.CreateAsync();
            AppendBlobClient noCpkBlob = InstrumentClient(cpkBlob.WithCustomerProvidedKey(null));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                noCpkBlob.GetPropertiesAsync(),
                e => Assert.AreEqual(BlobErrorCode.BlobUsesCustomerSpecifiedEncryption.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task WithEncryptionScope()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string encryptionScope = TestConfigDefault.EncryptionScope;
            AppendBlobClient encryptionScopeBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()).WithEncryptionScope(encryptionScope));
            await encryptionScopeBlob.CreateAsync();
            AppendBlobClient noEncryptionScopeBlob = InstrumentClient(encryptionScopeBlob.WithEncryptionScope(null));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                noEncryptionScopeBlob.SetMetadataAsync(BuildMetadata()),
                e => Assert.AreEqual(BlobErrorCode.BlobUsesCustomerSpecifiedEncryption.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<AppendBlobClient>(TestConfigDefault.ConnectionString, "name", "name", new BlobClientOptions()).Object;
            mock = new Mock<AppendBlobClient>(TestConfigDefault.ConnectionString, "name", "name").Object;
            mock = new Mock<AppendBlobClient>(new Uri("https://test/test"), new BlobClientOptions()).Object;
            mock = new Mock<AppendBlobClient>(new Uri("https://test/test"), Tenants.GetNewSharedKeyCredentials(), new BlobClientOptions()).Object;
            mock = new Mock<AppendBlobClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new BlobClientOptions()).Object;
            mock = new Mock<AppendBlobClient>(new Uri("https://test/test"), TestEnvironment.Credential, new BlobClientOptions()).Object;
        }

        private AppendBlobRequestConditions BuildDestinationAccessConditions(
            AccessConditionParameters parameters,
            bool lease = false,
            bool appendPosAndMaxSize = false)
        {
            var accessConditions = new AppendBlobRequestConditions
            {
                IfMatch = parameters.Match != null ? new ETag(parameters.Match) : default(ETag?),
                IfNoneMatch = parameters.NoneMatch != null ? new ETag(parameters.NoneMatch) : default(ETag?),
                IfModifiedSince = parameters.IfModifiedSince,
                IfUnmodifiedSince = parameters.IfUnmodifiedSince
            };

            if (lease)
            {
                accessConditions.LeaseId = parameters.LeaseId;
            }

            if (appendPosAndMaxSize)
            {
                accessConditions.IfAppendPositionEqual = parameters.AppendPosE;
                accessConditions.IfMaxSizeLessThanOrEqual = parameters.MaxSizeLTE;
            }

            return accessConditions;
        }

        private AppendBlobRequestConditions BuildSourceAccessConditions(AccessConditionParameters parameters) =>
            new AppendBlobRequestConditions
            {
                IfMatch = parameters.SourceIfMatch != null ? new ETag(parameters.SourceIfMatch) : default(ETag?),
                IfNoneMatch = parameters.SourceIfNoneMatch != null ? new ETag(parameters.SourceIfNoneMatch) : default(ETag?),
                IfModifiedSince = parameters.SourceIfModifiedSince,
                IfUnmodifiedSince = parameters.SourceIfUnmodifiedSince
            };

        public class AccessConditionParameters
        {
            public DateTimeOffset? IfModifiedSince { get; set; }
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
            public string Match { get; set; }
            public string NoneMatch { get; set; }
            public string LeaseId { get; set; }
            public long? AppendPosE { get; set; }
            public long? MaxSizeLTE { get; set; }
            public DateTimeOffset? SourceIfModifiedSince { get; set; }
            public DateTimeOffset? SourceIfUnmodifiedSince { get; set; }
            public string SourceIfMatch { get; set; }
            public string SourceIfNoneMatch { get; set; }
        }
    }
}
