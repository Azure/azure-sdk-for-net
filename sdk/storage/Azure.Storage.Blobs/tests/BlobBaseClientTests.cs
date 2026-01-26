// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Identity;
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
using Moq.Protected;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.TestConstants;

namespace Azure.Storage.Blobs.Test
{
    public class BlobBaseClientTests : BlobTestBase
    {
        public BlobAccessConditionConfigs BlobConditions { get; }

        public BlobBaseClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            BlobConditions = new BlobAccessConditionConfigs(this);
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

            BlobBaseClient blob1 = InstrumentClient(new BlobBaseClient(connectionString.ToString(true), containerName, blobName, GetOptions()));
            BlobBaseClient blob2 = InstrumentClient(new BlobBaseClient(connectionString.ToString(true), containerName, blobName));

            var builder1 = new BlobUriBuilder(blob1.Uri);
            var builder2 = new BlobUriBuilder(blob2.Uri);

            Assert.That(builder1.BlobContainerName, Is.EqualTo(containerName));
            Assert.That(builder1.BlobName, Is.EqualTo(blobName));
            Assert.That(builder1.AccountName, Is.EqualTo("accountName"));

            Assert.That(builder2.BlobContainerName, Is.EqualTo(containerName));
            Assert.That(builder2.BlobName, Is.EqualTo(blobName));
            Assert.That(builder2.AccountName, Is.EqualTo("accountName"));
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
            var blobName = "blobname";

            BlobBaseClient blobClient = new BlobBaseClient(connectionString.ToString(true), containerName, blobName);

            Assert.That(blobClient.BlobContainerName, Is.EqualTo(containerName));
            Assert.That(blobClient.Name, Is.EqualTo(blobName));
            Assert.That(blobClient.AccountName, Is.EqualTo(accountName));
        }

        [RecordedTest]
        public async Task Ctor_ConnectionStringEscapeBlobName()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = "!*'();[]:@&%=+$,/?#äÄöÖüÜß";

            BlockBlobClient initalBlob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);

            using var stream = new MemoryStream(data);
            Response<BlobContentInfo> uploadResponse = await initalBlob.UploadAsync(stream);

            // Act
            BlobBaseClient blob = new BlobBaseClient(TestConfigDefault.ConnectionString, test.Container.Name, blobName, GetOptions());
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(propertiesResponse.Value.ETag, Is.EqualTo(uploadResponse.Value.ETag));

            // Act
            BlobBaseClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Blob(
                    containerName: test.Container.Name,
                    blobName: blobName)
                .GetBlobContainerClient(test.Container.Name)
                .GetBlobClient(blobName));

            propertiesResponse = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.That(propertiesResponse.Value.ETag, Is.EqualTo(uploadResponse.Value.ETag));
        }

        [RecordedTest]
        public async Task Ctor_EscapeBlobName()
        {
            // Arrange
            string blobName = "!*'();[]:@&%=+$,/#äÄöÖüÜß";
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(blobName));
            ETag originalEtag;
            using (var stream = new MemoryStream(data))
            {
                BlobContentInfo info = await blob.UploadAsync(stream);
                originalEtag = info.ETag;
            }

            // Act
            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blobName
            };
            BlobBaseClient freshBlobClient = InstrumentClient(new BlobBaseClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                GetOptions()));

            // Assert
            Assert.That(freshBlobClient.Name, Is.EqualTo(blobName));
            BlobProperties propertiesResponse = await freshBlobClient.GetPropertiesAsync();
            Assert.That(propertiesResponse.ETag, Is.EqualTo(originalEtag));
        }

        [RecordedTest]
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            BlobBaseClient blob = InstrumentClient(new BlobBaseClient(blobEndpoint));
            var builder = new BlobUriBuilder(blob.Uri);

            Assert.That(builder.AccountName, Is.EqualTo(accountName));
        }

        [RecordedTest]
        public void Ctor_UriNonIpStyle()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();

            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName}");

            // Act
            BlobBaseClient blobBaseClient = new BlobBaseClient(uri);

            // Assert
            BlobUriBuilder builder = new BlobUriBuilder(blobBaseClient.Uri);

            Assert.That(builder.BlobContainerName, Is.EqualTo(containerName));
            Assert.That(builder.BlobName, Is.EqualTo(blobName));
            Assert.That(builder.AccountName, Is.EqualTo(accountName));
        }

        [RecordedTest]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobBaseClient(httpUri, TestEnvironment.Credential),
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
                () => new BlobBaseClient(httpUri, blobClientOptions),
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
                () => new BlobBaseClient(new Uri(TestConfigDefault.BlobServiceEndpoint), blobClientOptions),
                new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set"));
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var containerName = "containerName";
            var blobName = "blobName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri($"https://customdomain/{containerName}/{blobName}");

            BlobBaseClient blobClient = new BlobBaseClient(blobEndpoint, credentials);

            Assert.That(blobClient.AccountName, Is.EqualTo(accountName));
            Assert.That(blobClient.BlobContainerName, Is.EqualTo(containerName));
            Assert.That(blobClient.Name, Is.EqualTo(blobName));
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            var client = test.Container.GetBlobClient(GetNewBlobName());
            await client.UploadAsync(new MemoryStream());
            Uri blobUri = client.Uri;

            // Act
            var sasClient = InstrumentClient(new BlobBaseClient(blobUri, new AzureSasCredential(sas), GetOptions()));
            BlobProperties blobProperties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.That(blobProperties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_UserDelegationSAS()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);
            var client = test.Container.GetBlobClient(GetNewBlobName());
            await client.UploadAsync(new MemoryStream());
            Uri blobUri = client.Uri;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);
            var sasBuilder = new BlobSasBuilder(BlobSasPermissions.All, Recording.UtcNow.AddHours(1))
            {
                BlobContainerName = client.BlobContainerName,
                BlobName = client.Name,
            };
            var sas = sasBuilder.ToSasQueryParameters(userDelegationKey.Value, client.AccountName).ToString();

            // Act
            var sasClient = InstrumentClient(new BlobBaseClient(blobUri, new AzureSasCredential(sas), GetOptions()));
            BlobProperties blobProperties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.That(blobProperties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            Uri blobUri = test.Container.GetBlobClient("foo").Uri;
            blobUri = new Uri(blobUri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new BlobBaseClient(blobUri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.DefaultAudience);

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            BlobBaseClient aadBlob = InstrumentClient(new BlobBaseClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadBlob.ExistsAsync();
            Assert.That(exists, Is.True);
        }

        [RecordedTest]
        public async Task Ctor_CustomAudience()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(new BlobAudience($"https://{test.Container.AccountName}.blob.core.windows.net/"));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            BlobBaseClient aadBlob = InstrumentClient(new BlobBaseClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadBlob.ExistsAsync();
            Assert.That(exists, Is.True);
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.CreateBlobServiceAccountAudience(test.Container.AccountName));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            BlobBaseClient aadBlob = InstrumentClient(new BlobBaseClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadBlob.ExistsAsync();
            Assert.That(exists, Is.True);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.DefaultAudience);

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            // Hand it a Mock Credential that's supposed to fail
            BlobBaseClient aadBlob = InstrumentClient(new BlobBaseClient(
                uriBuilder.ToUri(),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadBlob.ExistsAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.InvalidAuthenticationInfo.ToString())));
        }

        #region Sequential Download

        [RecordedTest]
        public async Task DownloadAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.That(response.Value.ContentLength, Is.EqualTo(data.Length));
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task DownloadAsync_Disposal()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();
            response.Value.Dispose();
            response.Value.Dispose(); // 2nd disposal shouldn't throw.

            // Assert
            // Not thrown
        }

        [RecordedTest]
        public async Task DownloadAsync_Streaming()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync();

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag.ToString()}\"", Is.EqualTo(response.Value.Details.ETag.ToString()));

            Assert.That(response.Value.Details.ContentLength, Is.EqualTo(data.Length));
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());

            Assert.That(response.Value.Details.LeaseStatus, Is.EqualTo(LeaseStatus.Unlocked));
            Assert.That(response.Value.Details.LeaseState, Is.EqualTo(LeaseState.Available));
            Assert.That(response.Value.Details.LeaseDuration, Is.EqualTo(LeaseDurationType.Infinite));
        }

        [RecordedTest]
        public async Task DownloadAsync_Streaming_Disposal()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync();
            response.Value.Dispose();
            response.Value.Dispose(); // 2nd disposal shouldn't throw

            // Assert
            // not thrown
        }

        [RecordedTest]
        public async Task DownloadAsync_BinaryData()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadResult> response = await blob.DownloadContentAsync();

            // Assert
            Assert.That(response.Value.Details.ContentLength, Is.EqualTo(data.Length));
            TestHelper.AssertSequenceEqual(data, response.Value.Content.ToArray());
        }

        [RecordedTest]
        public async Task DownloadAsync_ZeroSizeBlob()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            byte[] data = new byte[] { };
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.That(response.Value.ContentLength, Is.EqualTo(data.Length));
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task DownloadAsync_ZeroSizeBlob_Streaming()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            byte[] data = new byte[] { };
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync();

            // Assert
            Assert.That(response.Value.Details.ContentLength, Is.EqualTo(data.Length));
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task DownloadAsync_ZeroSizeBlob_BinaryData()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            byte[] data = new byte[] { };
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            // Act
            Response<BlobDownloadResult> response = await blob.DownloadContentAsync();

            // Assert
            Assert.That(response.Value.Details.ContentLength, Is.EqualTo(data.Length));
            TestHelper.AssertSequenceEqual(data, response.Value.Content.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_Tags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            IDictionary<string, string> tags = BuildTags();
            await blob.SetTagsAsync(tags);

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.That(response.Value.Details.TagCount, Is.EqualTo(tags.Count));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_Tags_Streaming()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            IDictionary<string, string> tags = BuildTags();
            await blob.SetTagsAsync(tags);

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync();

            // Assert
            Assert.That(response.Value.Details.TagCount, Is.EqualTo(tags.Count));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_Tags_BinaryData()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            IDictionary<string, string> tags = BuildTags();
            await blob.SetTagsAsync(tags);

            // Act
            Response<BlobDownloadResult> response = await blob.DownloadContentAsync();

            // Assert
            Assert.That(response.Value.Details.TagCount, Is.EqualTo(tags.Count));
        }

        #region Secondary Storage
        [RecordedTest]
        public async Task DownloadAsync_ReadFromSecondaryStorage()
        {
            await using DisposingContainer test = await GetTestContainerAsync(GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(1, out TestExceptionPolicy testExceptionPolicy));

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blockBlobClient.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await EnsurePropagatedAsync(
                async () => await blockBlobClient.DownloadAsync(),
                downloadInfo => downloadInfo.GetRawResponse().Status != 404);

            // Assert
            Assert.That(response.Value.ContentLength, Is.EqualTo(data.Length));
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.That(testExceptionPolicy.HostsSetInRequests[0], Is.EqualTo(SecondaryStorageTenantPrimaryHost()));
            Assert.That(testExceptionPolicy.HostsSetInRequests[1], Is.EqualTo(SecondaryStorageTenantSecondaryHost()));
        }

        [RecordedTest]
        public async Task DownloadAsync_ReadFromSecondaryStorageShouldNotPut()
        {
            BlobServiceClient serviceClient = GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(
                1,
                out TestExceptionPolicy testExceptionPolicy,
                false,
                new List<RequestMethod>(new RequestMethod[] { RequestMethod.Put }));
            await using DisposingContainer test = await GetTestContainerAsync(serviceClient);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.That(response.Value.ContentLength, Is.EqualTo(data.Length));
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.That(testExceptionPolicy.HostsSetInRequests[0], Is.EqualTo(SecondaryStorageTenantPrimaryHost()));
            // should not toggle to secondary host on put request failure
            Assert.That(testExceptionPolicy.HostsSetInRequests[1], Is.EqualTo(SecondaryStorageTenantPrimaryHost()));
        }
        #endregion

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task DownloadAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.That(response.Value.Details.EncryptionKeySha256, Is.EqualTo(customerProvidedKey.EncryptionKeyHash));
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task DownloadAsync_CPK_Streaming()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync();

            // Assert
            Assert.That(response.Value.Details.EncryptionKeySha256, Is.EqualTo(customerProvidedKey.EncryptionKeyHash));
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task DownloadAsync_CPK_BinaryData()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadResult> response = await blob.DownloadContentAsync();

            // Assert
            Assert.That(response.Value.Details.EncryptionKeySha256, Is.EqualTo(customerProvidedKey.EncryptionKeyHash));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DownloadAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.That(response.Value.Details.EncryptionScope, Is.EqualTo(TestConfigDefault.EncryptionScope));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DownloadAsync_EncryptionScope_Streaming()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync();

            // Assert
            Assert.That(response.Value.Details.EncryptionScope, Is.EqualTo(TestConfigDefault.EncryptionScope));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DownloadAsync_EncryptionScope_BinaryData()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadResult> response = await blob.DownloadContentAsync();

            // Assert
            Assert.That(response.Value.Details.EncryptionScope, Is.EqualTo(TestConfigDefault.EncryptionScope));
        }

        [Test]
        [TestCase(10 * Constants.KB, 1 * Constants.KB)]
        [TestCase(256 * Constants.KB, 255 * Constants.KB)]
        [TestCase(257 * Constants.KB, 256 * Constants.KB)]
        [TestCase(1 * Constants.MB, 1 * Constants.KB)]
        [LiveOnly] // Stream copy uses ArrayPool under the hood. Which brings undeterministic behavior for larger content.
        public async Task DownloadAsync_WithUnreliableConnection(int dataSize, int faultPoint)
        {
            // Arrange
            int timesFaulted = 0;
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey),
                    GetFaultyBlobConnectionOptions(
                        raiseAt: faultPoint,
                        raise: new IOException("Manually injected testing fault"),
                        () =>
                        {
                            timesFaulted++;
                        })));

            await using DisposingContainer test = await GetTestContainerAsync(service: service);

            var data = GetRandomBuffer(dataSize);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.That(response.Value.ContentLength, Is.EqualTo(data.Length));
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.That(timesFaulted, Is.Not.EqualTo(0));
        }

        [Test]
        [TestCase(10 * Constants.KB, 1 * Constants.KB)]
        [TestCase(256 * Constants.KB, 255 * Constants.KB)]
        [TestCase(257 * Constants.KB, 256 * Constants.KB)]
        [TestCase(1 * Constants.MB, 1 * Constants.KB)]
        [LiveOnly] // Stream copy uses ArrayPool under the hood. Which brings undeterministic behavior for larger content.
        public async Task DownloadAsync_WithUnreliableConnection_Streaming(int dataSize, int faultPoint)
        {
            // Arrange
            int timesFaulted = 0;
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey),
                    GetFaultyBlobConnectionOptions(
                        raiseAt: faultPoint,
                        raise: new IOException("Manually injected testing fault"),
                        () =>
                        {
                            timesFaulted++;
                        })));

            await using DisposingContainer test = await GetTestContainerAsync(service: service);

            var data = GetRandomBuffer(dataSize);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync();

            // Assert
            Assert.That(response.Value.Details.ContentLength, Is.EqualTo(data.Length));
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.That(timesFaulted, Is.Not.EqualTo(0));
        }

        [Test]
        [TestCase(10 * Constants.KB, 1 * Constants.KB)]
        [TestCase(256 * Constants.KB, 255 * Constants.KB)]
        [TestCase(257 * Constants.KB, 256 * Constants.KB)]
        [TestCase(1 * Constants.MB, 1 * Constants.KB)]
        [LiveOnly] // Stream copy uses ArrayPool under the hood. Which brings undeterministic behavior for larger content.
        public async Task DownloadAsync_WithUnreliableConnection_Streaming_And_ConcurrentChange(int dataSize, int faultPoint)
        {
            // Arrange
            int timesFaulted = 0;
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            BlobServiceClient nonFaultyService = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey)));
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey),
                    GetFaultyBlobConnectionOptions(
                        raiseAt: faultPoint,
                        raise: new IOException("Manually injected testing fault"),
                        () =>
                        {
                            timesFaulted++;
                            var data = GetRandomBuffer(dataSize);
                            using (var stream = new MemoryStream(data))
                            {
                                nonFaultyService.GetBlobContainerClient(containerName).GetBlobClient(blobName)
                                    .UploadAsync(stream, overwrite: true).GetAwaiter().GetResult();
                            }
                        })));

            await using DisposingContainer test = await GetTestContainerAsync(service: service, containerName: containerName);

            var data = GetRandomBuffer(dataSize);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            // Check the error we get when a download fails because the blob
            // was replaced while we're downloading
            RequestFailedException ex = Assert.CatchAsync<RequestFailedException>(async () =>
            {
                BlobDownloadStreamingResult result = await blob.DownloadStreamingAsync();
                await result.Content.CopyToAsync(Stream.Null);
            });

            // Assert
            Assert.That(ex.ErrorCode, Is.EqualTo(BlobErrorCode.ConditionNotMet));
        }

        [Test]
        [TestCase(10 * Constants.KB, 1 * Constants.KB)]
        [TestCase(256 * Constants.KB, 255 * Constants.KB)]
        [TestCase(257 * Constants.KB, 256 * Constants.KB)]
        [TestCase(1 * Constants.MB, 1 * Constants.KB)]
        [LiveOnly] // Stream copy uses ArrayPool under the hood. Which brings undeterministic behavior for larger content.
        public async Task DownloadAsync_WithUnreliableConnection_BinaryData(int dataSize, int faultPoint)
        {
            // Arrange
            int timesFaulted = 0;
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey),
                    GetFaultyBlobConnectionOptions(
                        raiseAt: faultPoint,
                        raise: new IOException("Manually injected testing fault"),
                        () =>
                        {
                            timesFaulted++;
                        })));

            await using DisposingContainer test = await GetTestContainerAsync(service: service);

            var data = GetRandomBuffer(dataSize);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadResult> response = await blob.DownloadContentAsync();

            // Assert
            Assert.That(response.Value.Details.ContentLength, Is.EqualTo(data.Length));
            TestHelper.AssertSequenceEqual(data, response.Value.Content.ToArray());
            Assert.That(timesFaulted, Is.Not.EqualTo(0));
        }

        [RecordedTest]
        public async Task DownloadAsync_Range()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(10 * Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var offset = Constants.KB;
            var count = 2 * Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync(range: new HttpRange(offset, count));

            // Assert
            Assert.That(response.Value.ContentLength, Is.EqualTo(count));
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            Assert.That(actual.Length, Is.EqualTo(count));
            TestHelper.AssertSequenceEqual(data.Skip(offset).Take(count), actual.ToArray());
        }

        [RecordedTest]
        public async Task DownloadAsync_Range_Streaming()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(10 * Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var offset = Constants.KB;
            var count = 2 * Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
            {
                Range = new HttpRange(offset, count)
            });

            // Assert
            Assert.That(response.Value.Details.ContentLength, Is.EqualTo(count));
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            Assert.That(actual.Length, Is.EqualTo(count));
            TestHelper.AssertSequenceEqual(data.Skip(offset).Take(count), actual.ToArray());
        }

        [RecordedTest]
        public async Task DownloadAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                Response<BlobDownloadInfo> response = await blob.DownloadAsync(conditions: accessConditions);

                // Assert
                Assert.That(response.Value.ContentLength, Is.EqualTo(data.Length));
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [RecordedTest]
        public async Task DownloadAsync_AccessConditions_Streaming()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
                {
                    Conditions = accessConditions
                });

                // Assert
                Assert.That(response.Value.Details.ContentLength, Is.EqualTo(data.Length));
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [RecordedTest]
        public async Task DownloadAsync_AccessConditions_BinaryData()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                Response<BlobDownloadResult> response = await blob.DownloadContentAsync(new BlobDownloadOptions
                {
                    Conditions = accessConditions
                });

                // Assert
                Assert.That(response.Value.Details.ContentLength, Is.EqualTo(data.Length));
                TestHelper.AssertSequenceEqual(data, response.Value.Content.ToArray());
            }
        }

        [RecordedTest]
        public async Task DownloadAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await blob.DownloadAsync(
                            conditions: accessConditions)).Value;
                    });
            }
        }

        [RecordedTest]
        public async Task DownloadAsync_AccessConditionsFail_Streaming()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await blob.DownloadStreamingAsync(new BlobDownloadOptions
                        {
                            Conditions = accessConditions
                        })).Value;
                    });
            }
        }

        [RecordedTest]
        public async Task DownloadAsync_AccessConditionsFail_BinaryData()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await blob.DownloadContentAsync(new BlobDownloadOptions
                        {
                            Conditions = accessConditions
                        })).Value;
                    });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            var options = new BlobDownloadOptions
            {
                Conditions = conditions
            };
            await blob.DownloadAsync(conditions: conditions);
            await blob.DownloadStreamingAsync(options);
            await blob.DownloadContentAsync(options);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_IfTagsFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            var options = new BlobDownloadOptions
            {
                Conditions = conditions
            };
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DownloadAsync(
                    conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DownloadStreamingAsync(
                    options),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DownloadContentAsync(
                    options),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task DownloadAsync_MD5()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(10 * Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var offset = Constants.KB;
            var count = 2 * Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync(
                range: new HttpRange(offset, count),
                rangeGetContentHash: true);

            // Assert
            var expectedMD5 = MD5.Create().ComputeHash(data.Skip(offset).Take(count).ToArray());
            TestHelper.AssertSequenceEqual(expectedMD5, response.Value.ContentHash);
        }

        [RecordedTest]
        public async Task DownloadAsync_MD5_Streaming()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(10 * Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var offset = Constants.KB;
            var count = 2 * Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
            {
                Range = new HttpRange(offset, count),
                TransferValidation = new DownloadTransferValidationOptions
                {
                    ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                    AutoValidateChecksum = false
                }
            });

            // Assert
            var expectedMD5 = MD5.Create().ComputeHash(data.Skip(offset).Take(count).ToArray());
            TestHelper.AssertSequenceEqual(expectedMD5, response.Value.Details.ContentHash);
        }

        [RecordedTest]
        public async Task DownloadAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DownloadAsync(),
                e => Assert.That(e.Message.Split('\n')[0], Is.EqualTo("The specified blob does not exist.")));
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DownloadStreamingAsync(),
                e => Assert.That(e.Message.Split('\n')[0], Is.EqualTo("The specified blob does not exist.")));
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DownloadContentAsync(),
                e => Assert.That(e.Message.Split('\n')[0], Is.EqualTo("The specified blob does not exist.")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DownloadAsync_LastAccess()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.That(response.Value.Details.LastAccessed, Is.Not.EqualTo(DateTimeOffset.MinValue));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DownloadAsync_LastAccess_Streaming()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync();

            // Assert
            Assert.That(response.Value.Details.LastAccessed, Is.Not.EqualTo(DateTimeOffset.MinValue));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DownloadAsync_LastAccess_BinaryData()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadResult> response = await blob.DownloadContentAsync();

            // Assert
            Assert.That(response.Value.Details.LastAccessed, Is.Not.EqualTo(DateTimeOffset.MinValue));
        }

        [RecordedTest]
        public async Task DownloadAsync_Overloads()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            await Verify(await blob.DownloadAsync());
            await Verify(await blob.DownloadAsync(CancellationToken.None));
            await Verify(await blob.DownloadAsync(range: default));

            async Task Verify(Response<BlobDownloadInfo> response)
            {
                Assert.That(response.Value.ContentLength, Is.EqualTo(data.Length));
                using var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [RecordedTest]
        public async Task DownloadAsync_Overloads_BinaryData()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            Verify(await blob.DownloadContentAsync());
            Verify(await blob.DownloadContentAsync(CancellationToken.None));
            Verify(await blob.DownloadContentAsync(options: default));

            void Verify(Response<BlobDownloadResult> response)
            {
                Assert.That(response.Value.Details.ContentLength, Is.EqualTo(data.Length));
                TestHelper.AssertSequenceEqual(data, response.Value.Content.ToArray());
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> uploadResponse;
            using (var stream = new MemoryStream(data))
            {
                uploadResponse = await blob.UploadAsync(stream);
            }

            // Act
            BlockBlobClient versionBlob = blob.WithVersion(uploadResponse.Value.VersionId);
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.That(response.Value.Details.VersionId, Is.Not.Null);
        }

        [PlaybackOnly("Object Replication policies is only enabled on certain storage accounts")]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_ObjectReplication()
        {
            // TODO: The tests will temporarily use designated account, containers and blobs to check the
            // existence of OR headers
            BlobServiceClient sourceServiceClient = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobServiceClient destinationServiceClient = BlobsClientBuilder.GetServiceClient_SecondaryAccount_SharedKey();

            // This is a PLAYBACK ONLY test with a special container we previously setup, as we can't auto setup policies yet
            BlobContainerClient sourceContainer = InstrumentClient(sourceServiceClient.GetBlobContainerClient("test1"));
            BlobContainerClient destinationContainer = InstrumentClient(destinationServiceClient.GetBlobContainerClient("test2"));

            // Arrange
            string blob_name = "netgetpropertiesors2blobapitestgetpropertiesors";
            BlobClient sourceBlob = sourceContainer.GetBlobClient(blob_name);
            BlobClient destBlob = destinationContainer.GetBlobClient(blob_name);

            // Act
            Response<BlobDownloadInfo> sourceResponse = await sourceBlob.DownloadAsync();
            Response<BlobDownloadInfo> destResponse = await destBlob.DownloadAsync();

            //Assert
            Assert.That(sourceResponse.Value.Details.ObjectReplicationSourceProperties.Count, Is.EqualTo(1));
            Assert.That(sourceResponse.Value.Details.ObjectReplicationDestinationPolicyId, Is.Null);
            Assert.That(destResponse.Value.Details.ObjectReplicationDestinationPolicyId, Is.Not.Empty);
            Assert.That(destResponse.Value.Details.ObjectReplicationSourceProperties, Is.Null);
        }

        [RecordedTest]
        public async Task DownloadAsync_CreatedOn()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.That(response.Value.Details.CreatedOn, Is.Not.Null);
        }
        #endregion Sequential Download

        #region Parallel Download

        private async Task ParallelDownloadFileAndVerify(
            long size,
            long singleBlockThreshold,
            StorageTransferOptions transferOptions)
        {
            var data = GetRandomBuffer(size);
            var path = Path.GetTempFileName();

            try
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                var name = GetNewBlobName();
                BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Create a special blob client for downloading that will
                // assign client request IDs based on the range so that out
                // of order operations still get predictable IDs and the
                // recordings work correctly
                var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
                BlobClient downloadingBlob = InstrumentClient(new BlobClient(blob.Uri, credential, GetOptions(true)));

                using (FileStream file = File.OpenWrite(path))
                {
                    await downloadingBlob.StagedDownloadAsync(
                        file,
                        transferOptions: transferOptions);
                }

                using (FileStream resultStream = File.OpenRead(path))
                {
                    TestHelper.AssertSequenceEqual(data, resultStream.AsBytes());
                }
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        [RecordedTest]
        [TestCase(512)]
        [TestCase(1 * Constants.KB)]
        [TestCase(2 * Constants.KB)]
        [TestCase(4 * Constants.KB)]
        [TestCase(10 * Constants.KB)]
        [TestCase(20 * Constants.KB)]
        [TestCase(30 * Constants.KB)]
        [TestCase(50 * Constants.KB)]
        [TestCase(501 * Constants.KB)]
        public async Task DownloadFileAsync_Parallel_SmallBlobs(long size) =>
             // Use a 1KB threshold so we get a lot of individual blocks
             await ParallelDownloadFileAndVerify(size, Constants.KB, new StorageTransferOptions { MaximumTransferLength = Constants.KB });

        [Ignore("These tests currently take 40 mins for little additional coverage")]
        [Test]
        [Category("Live")]
        [TestCase(33 * Constants.MB, 1)]
        [TestCase(33 * Constants.MB, 4)]
        [TestCase(33 * Constants.MB, 8)]
        [TestCase(33 * Constants.MB, 16)]
        [TestCase(33 * Constants.MB, null)]
        [TestCase(257 * Constants.MB, 1)]
        [TestCase(257 * Constants.MB, 4)]
        [TestCase(257 * Constants.MB, 8)]
        [TestCase(257 * Constants.MB, 16)]
        [TestCase(257 * Constants.MB, null)]
        [TestCase(1 * Constants.GB, 1)]
        [TestCase(1 * Constants.GB, 4)]
        [TestCase(1 * Constants.GB, 8)]
        [TestCase(1 * Constants.GB, 16)]
        [TestCase(1 * Constants.GB, null)]
        public async Task DownloadFileAsync_Parallel_LargeBlobs(long size, int? maximumThreadCount)
        {
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            if (Mode == RecordedTestMode.Live)
            {
                await ParallelDownloadFileAndVerify(size, 16 * Constants.MB, new StorageTransferOptions { MaximumConcurrency = maximumThreadCount });
            }
        }

        [RecordedTest]
        public async Task DownloadToAsync_ZeroSizeBlob()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using Stream stream = new MemoryStream(new byte[] { });
            await blob.UploadAsync(stream);

            // Act
            using Stream resultStream = new MemoryStream();
            await blob.DownloadToAsync(resultStream);
        }

        [RecordedTest]
        [TestCase(StorageChecksumAlgorithm.StorageCrc64)]
        [TestCase(StorageChecksumAlgorithm.MD5)]
        public async Task DownloadToAsync_ZeroSizeBlob_ContentValidationEnabled(StorageChecksumAlgorithm alg)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using Stream stream = new MemoryStream(new byte[] { });
            await blob.UploadAsync(stream);

            // Act
            using Stream resultStream = new MemoryStream();
            BlobDownloadToOptions options = new();
            options.TransferValidation = new DownloadTransferValidationOptions
            {
                ChecksumAlgorithm = alg,
                AutoValidateChecksum = true
            };
            await blob.DownloadToAsync(resultStream, options);
        }

        [RecordedTest]
        [Ignore("Don't want to record 300 MB of data in the tests")]
        public async Task DownloadToAsync_LargeStream()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(300 * Constants.MB);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            using (var resultStream = new MemoryStream(data))
            {
                await blob.DownloadToAsync(resultStream);
                Assert.That(resultStream.Length, Is.EqualTo(data.Length));
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }
        }

        [RecordedTest]
        [RetryOnException(5, typeof(AssertionException))]
        public async Task DownloadTo_Initial304()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload a blob
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> uploadResponse;
            using (var stream = new MemoryStream(data))
            {
                uploadResponse = await blob.UploadAsync(stream);
            }

            DateTimeOffset modifiedSince = CheckModifiedSinceAndWait(uploadResponse);

            // Add conditions to cause a failure and ensure we don't explode
            Response result = await blob.DownloadToAsync(
                Stream.Null,
                new BlobRequestConditions
                {
                    IfModifiedSince = modifiedSince
                });
            Assert.That(result.Status, Is.EqualTo(304));
        }

        [RecordedTest]
        [RetryOnException(5, typeof(AssertionException))]
        public async Task DownloadContent_Initial304()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload a blob
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> uploadResponse;
            using (var stream = new MemoryStream(data))
            {
                uploadResponse = await blob.UploadAsync(stream);
            }

            DateTimeOffset modifiedSince = CheckModifiedSinceAndWait(uploadResponse);

            // Add conditions to cause a failure and ensure we don't explode
            Response<BlobDownloadResult> result = await blob.DownloadContentAsync(new BlobDownloadOptions
            {
                Conditions = new BlobRequestConditions
                {
                    IfModifiedSince = modifiedSince
                }
            });
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(304));
        }

        [RecordedTest]
        [RetryOnException(5, typeof(AssertionException))]
        public async Task DownloadStreaming_Initial304()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload a blob
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> uploadResponse;
            using (var stream = new MemoryStream(data))
            {
                uploadResponse = await blob.UploadAsync(stream);
            }

            DateTimeOffset modifiedSince = CheckModifiedSinceAndWait(uploadResponse);

            // Add conditions to cause a failure and ensure we don't explode
            Response<BlobDownloadStreamingResult> result = await blob.DownloadStreamingAsync(new BlobDownloadOptions
            {
                Conditions = new BlobRequestConditions
                {
                    IfModifiedSince = modifiedSince
                }
            });
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(304));
        }

        [RecordedTest]
        [RetryOnException(5, typeof(AssertionException))]
        public async Task Download_Initial304()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload a blob
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> uploadResponse;
            using (var stream = new MemoryStream(data))
            {
                uploadResponse = await blob.UploadAsync(stream);
            }

            DateTimeOffset modifiedSince = CheckModifiedSinceAndWait(uploadResponse);

            // Add conditions to cause a failure and ensure we don't explode
            Response<BlobDownloadInfo> result = await blob.DownloadAsync(
                conditions: new BlobRequestConditions
                {
                    IfModifiedSince = modifiedSince
                });
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(304));
        }

        [RecordedTest]
        public async Task DownloadTo_ReplacedDuringDownload()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload a large blob
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(GetRandomBuffer(10 * Constants.KB)))
            {
                await blob.UploadAsync(stream);
            }

            // Check the error we get when a download fails because the blob
            // was replaced while we're downloading
            RequestFailedException ex = Assert.CatchAsync<RequestFailedException>(
                async () =>
                {
                    // Create a stream that replaces the blob as soon as it starts downloading
                    bool replaced = false;
                    await blob.StagedDownloadAsync(
                        new FuncStream(
                            Stream.Null,
                            async () =>
                            {
                                if (!replaced)
                                {
                                    replaced = true;
                                    using var newStream = new MemoryStream(GetRandomBuffer(Constants.KB));
                                    await blob.UploadAsync(newStream, overwrite: true);
                                }
                            }),
                        transferOptions:
                            new StorageTransferOptions
                            {
                                MaximumConcurrency = 1,
                                MaximumTransferLength = Constants.KB,
                                InitialTransferLength = Constants.KB
                            });
                });
            Assert.That(ex.ErrorCode, Is.EqualTo(BlobErrorCode.ConditionNotMet));
        }

        [RecordedTest]
        public async Task DownloadTo_ReplacedDuringDownload_MatchAny()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload a large blob
            BlobClient blob = test.Container.GetBlobClient(GetNewBlobName());
            using (var stream = new MemoryStream(GetRandomBuffer(10 * Constants.KB)))
            {
                await blob.UploadAsync(stream);
            }

            // Check the error we get when a download fails because the blob
            // was replaced while we're downloading
            RequestFailedException ex = Assert.CatchAsync<RequestFailedException>(
                async () =>
                {
                    // Create a stream that replaces the blob as soon as it starts downloading
                    bool replaced = false;
                    await blob.DownloadToAsync(
                        new FuncStream(
                            Stream.Null,
                            async () =>
                            {
                                if (!replaced)
                                {
                                    replaced = true;
                                    using var newStream = new MemoryStream(GetRandomBuffer(10 * Constants.KB));
                                    await blob.UploadAsync(newStream, overwrite: true);
                                }
                            }),
                        conditions: new BlobRequestConditions
                        {
                            IfMatch = new ETag("*")
                        },
                        transferOptions:
                            new StorageTransferOptions
                            {
                                MaximumConcurrency = 1,
                                MaximumTransferLength = Constants.KB,
                                InitialTransferLength = Constants.KB
                            });
                });
            Assert.That(ex.ErrorCode, Is.EqualTo(BlobErrorCode.ConditionNotMet));
        }

        [RecordedTest]
        public async Task DownloadToAsync_PathOverloads()
        {
            var path = Path.GetTempFileName();
            try
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                var data = GetRandomBuffer(Constants.KB);

                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
                await Verify(await blob.DownloadToAsync(path));
                await Verify(await blob.DownloadToAsync(path, CancellationToken.None));
                await Verify(await blob.DownloadToAsync(path,
                    new BlobRequestConditions() { IfModifiedSince = default }));

                async Task Verify(Response response)
                {
                    Assert.That(File.ReadAllBytes(path).Length, Is.EqualTo(data.Length));
                    using var actual = new MemoryStream();
                    using (FileStream resultStream = File.OpenRead(path))
                    {
                        await resultStream.CopyToAsync(actual);
                        TestHelper.AssertSequenceEqual(data, actual.ToArray());
                    }
                }
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        [RecordedTest]
        public async Task DownloadToAsync_StreamOverloads()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            using (var resultStream = new MemoryStream(data))
            {
                await blob.DownloadToAsync(resultStream);
                Verify(resultStream);
            }
            using (var resultStream = new MemoryStream())
            {
                await blob.DownloadToAsync(resultStream, CancellationToken.None);
                Verify(resultStream);
            }
            using (var resultStream = new MemoryStream())
            {
                await blob.DownloadToAsync(resultStream,
                    new BlobRequestConditions() { IfModifiedSince = default });
                Verify(resultStream);
            }

            void Verify(MemoryStream resultStream)
            {
                Assert.That(resultStream.Length, Is.EqualTo(data.Length));
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }
        }
        #endregion Parallel Download

        [RecordedTest]
        public async Task DownloadEmptyBlobTest()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blobClient = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream())
            {
                await blobClient.UploadAsync(stream, overwrite: true);
            }

            // Act
            await blobClient.DownloadAsync();
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

            // Assert
            await operation.WaitForCompletionAsync();

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
        }

        [RecordedTest]
        [TestCase(nameof(BlobRequestConditions.LeaseId))]
        public async Task StartCopyFromUriAsync_InvalidSourceRequestConditions(string invalidSourceCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobBaseClient blobBaseClient = new BlobBaseClient(uri, GetOptions());

            BlobRequestConditions sourceConditions = new BlobRequestConditions();

            switch (invalidSourceCondition)
            {
                case nameof(BlobRequestConditions.LeaseId):
                    sourceConditions.LeaseId = string.Empty;
                    break;
            }

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                SourceConditions = sourceConditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blobBaseClient.StartCopyFromUriAsync(
                    uri,
                    options: options),
                e =>
                {
                    Assert.That(e.Message.Contains($"StartCopyFromUri does not support the {invalidSourceCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("sourceConditions"), Is.True);
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_Tags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            IDictionary<string, string> tags = BuildTags();
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                Tags = tags
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri, options);

            // Assert
            await operation.WaitForCompletionAsync();

            Response<GetBlobTagResult> response = await destBlob.GetTagsAsync();
            AssertDictionaryEquality(tags, response.Value.Tags);
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = BuildMetadata();
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                Metadata = metadata
            };

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await destBlob.StartCopyFromUriAsync(
                source: srcBlob.Uri,
                options);

            // Assert
            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync_Source_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(srcBlob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(srcBlob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions sourceAccessConditions = BuildAccessConditions(
                    parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    SourceConditions = sourceAccessConditions
                };

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                Operation<long> response = await destBlob.StartCopyFromUriAsync(
                    source: srcBlob.Uri,
                    options);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync_Source_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(srcBlob, parameters.NoneMatch);

                BlobRequestConditions sourceAccessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: false);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    SourceConditions = sourceAccessConditions
                };

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        options),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_Source_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await srcBlob.SetTagsAsync(tags);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                SourceConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options: options);

            // Assert
            await operation.WaitForCompletionAsync();

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_Source_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                SourceConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StartCopyFromUriAsync(
                            srcBlob.Uri,
                            options: options),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync_Destination_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // destBlob needs to exist so we can get its lease and etag
                using (var stream = new MemoryStream(data))
                {
                    await destBlob.UploadAsync(stream);
                }

                parameters.Match = await SetupBlobMatchCondition(destBlob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                BlobRequestConditions accessConditions = BuildAccessConditions(parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    DestinationConditions = accessConditions
                };

                // Act
                Operation<long> response = await destBlob.StartCopyFromUriAsync(
                    source: srcBlob.Uri,
                    options);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync_Destination_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }

                // destBlob needs to exist so we can get its etag
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await destBlob.UploadAsync(stream);
                }

                parameters.NoneMatch = await SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    DestinationConditions = accessConditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        options),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await destBlob.SetTagsAsync(tags);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                DestinationConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options: options);

            // Assert
            await operation.WaitForCompletionAsync();

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                DestinationConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StartCopyFromUriAsync(
                            srcBlob.Uri,
                            options: options),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync_AccessTier()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.Cool
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options);

            // Assert
            // data copied within an account, so copy should be instantaneous
            await operation.WaitForCompletionAsync();

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2021_12_02)]
        public async Task StartCopyFromUriAsync_AccessTier_Cold()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.Cold
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options);

            // data copied within an account, so copy should be instantaneous
            await operation.WaitForCompletionAsync();

            // Assert
            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
            Assert.That(response.Value.AccessTier, Is.EqualTo("Cold"));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_Seal()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient srcBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await srcBlob.CreateAsync();
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                ShouldSealDestination = true
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri, options);

            // Assert
            await operation.WaitForCompletionAsync();

            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
            Assert.That(response.Value.IsSealed, Is.True);
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StartCopyFromUriAsync(srcBlob.Uri),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync_RehydratePriority()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            var data2 = GetRandomBuffer(Constants.KB);
            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }

            // destBlob needs to exist so we can get its lease and etag
            using (var stream = new MemoryStream(data2))
            {
                await destBlob.UploadAsync(stream);
            }

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.Archive,
                RehydratePriority = RehydratePriority.High
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options);

            // Assert
            // data copied within an account, so copy should be instantaneous
            await operation.WaitForCompletionAsync();

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);

            // Act
            await destBlob.SetAccessTierAsync(AccessTier.Cool);
            Response<BlobProperties> propertiesResponse = await destBlob.GetPropertiesAsync();

            // Assert
            Assert.That(propertiesResponse.Value.ArchiveStatus, Is.EqualTo("rehydrate-pending-to-cool"));
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync_AccessTierFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.P20
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.InvalidHeaderValue.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

            // Assert
            await operation.WaitForCompletionAsync();

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.VersionId, out var _), Is.True);
        }

        [RecordedTest]
        public async Task StartCopyFromUriAsync_OperationAbort()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(8 * Constants.MB);

            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }

            BlobServiceClient secondaryService = BlobsClientBuilder.GetServiceClient_SecondaryAccount_SharedKey();
            await using DisposingContainer destTest = await GetTestContainerAsync(service: secondaryService);
            {
                BlockBlobClient destBlob = InstrumentClient(destTest.Container.GetBlockBlobClient(GetNewBlobName()));

                CopyFromUriOperation operation = await destBlob.StartCopyFromUriAsync(
                    srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)));

                // Act
                try
                {
                    Response response = await destBlob.AbortCopyFromUriAsync(operation.Id);

                    // Act
                    await operation.WaitForCompletionAsync();

                    // Assert
                    Assert.That(operation.Value, Is.EqualTo(0));
                    Assert.That(operation.HasCompleted, Is.True);
                    Assert.That(operation.GetRawResponse(), Is.Not.Null);
                }
                catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                {
                    WarnCopyCompletedTooQuickly();
                }
            }
        }

        [RecordedTest]
        public async Task AbortCopyFromUriAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(8 * Constants.MB);

            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }

            BlobServiceClient secondaryService = BlobsClientBuilder.GetServiceClient_SecondaryAccount_SharedKey();
            await using DisposingContainer destTest = await GetTestContainerAsync(service: secondaryService);
            {
                BlockBlobClient destBlob = InstrumentClient(destTest.Container.GetBlockBlobClient(GetNewBlobName()));

                Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                    srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)));

                // Act
                try
                {
                    Response response = await destBlob.AbortCopyFromUriAsync(operation.Id);

                    // Assert
                    Assert.That(response.Headers.RequestId, Is.Not.Null);
                }
                catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                {
                    WarnCopyCompletedTooQuickly();
                }
            }
        }

        [RecordedTest]
        [TestCase(nameof(BlobRequestConditions.IfModifiedSince))]
        [TestCase(nameof(BlobRequestConditions.IfUnmodifiedSince))]
        [TestCase(nameof(BlobRequestConditions.IfMatch))]
        [TestCase(nameof(BlobRequestConditions.IfNoneMatch))]
        [TestCase(nameof(BlobRequestConditions.TagConditions))]
        public async Task AbortCopyFromUriAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobBaseClient blobBaseClient = new BlobBaseClient(uri, GetOptions());

            BlobRequestConditions conditions = new BlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(BlobRequestConditions.IfModifiedSince):
                    conditions.IfModifiedSince = new DateTimeOffset();
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
                case nameof(BlobRequestConditions.TagConditions):
                    conditions.TagConditions = string.Empty;
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blobBaseClient.AbortCopyFromUriAsync(
                    copyId: "copyId",
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"AbortCopyFromUri does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task AbortCopyFromUriAsync_Lease()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(8 * Constants.MB);

            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }
            BlobServiceClient secondaryService = BlobsClientBuilder.GetServiceClient_SecondaryAccount_SharedKey();
            await using DisposingContainer destTest = await GetTestContainerAsync(service: secondaryService);

            BlockBlobClient destBlob = InstrumentClient(destTest.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await destBlob.UploadAsync(stream);
            }

            TimeSpan duration = BlobLeaseClient.InfiniteLeaseDuration;
            BlobLeaseClient lease = InstrumentClient(destBlob.GetBlobLeaseClient(Recording.Random.NewGuid().ToString()));
            Response<BlobLease> leaseResponse = await lease.AcquireAsync(duration);

            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                source: srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                destinationConditions: new BlobRequestConditions { LeaseId = leaseResponse.Value.LeaseId });

            // Act
            try
            {
                Response response = await destBlob.AbortCopyFromUriAsync(
                    copyId: operation.Id,
                    conditions: new BlobRequestConditions
                    {
                        LeaseId = leaseResponse.Value.LeaseId
                    });

                // Assert
                Assert.That(response.Headers.RequestId, Is.Not.Null);
            }
            catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
            {
                WarnCopyCompletedTooQuickly();
            }
        }

        [RecordedTest]
        public async Task AbortCopyFromUriAsync_LeaseFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(8 * Constants.MB);

            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }
            BlobServiceClient secondaryService = BlobsClientBuilder.GetServiceClient_SecondaryAccount_SharedKey();
            await using DisposingContainer destTest = await GetTestContainerAsync(service: secondaryService);

            BlockBlobClient destBlob = InstrumentClient(destTest.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await destBlob.UploadAsync(stream);
            }

            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                source: srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)));

            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            try
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.AbortCopyFromUriAsync(
                        copyId: operation.Id,
                        conditions: new BlobRequestConditions
                        {
                            LeaseId = leaseId
                        }),
                    e =>
                    {
                        switch (e.ErrorCode)
                        {
                            case "NoPendingCopyOperation":
                                WarnCopyCompletedTooQuickly();
                                break;
                            default:
                                Assert.That(e.ErrorCode, Is.EqualTo("LeaseNotPresentWithBlobOperation"));
                                break;
                        }
                    }
                    );
            }
            catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
            {
                WarnCopyCompletedTooQuickly();
            }
        }

        [RecordedTest]
        public async Task AbortCopyFromUriAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var copyId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.AbortCopyFromUriAsync(copyId),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task SyncCopyFromUriAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            Uri srcBlobSasUri = srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1));
            srcBlob = InstrumentClient(new BlobBaseClient(srcBlobSasUri, GetOptions()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Response<BlobCopyInfo> copyResponse = await destBlob.SyncCopyFromUriAsync(srcBlob.Uri);

            // Check that destBlob actually exists
            await destBlob.GetPropertiesAsync();

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{copyResponse.GetRawResponse().Headers.ETag.ToString()}\"", Is.EqualTo(copyResponse.Value.ETag.ToString()));
            Assert.That(copyResponse.Value.LastModified, Is.Not.Null);
            Assert.That(copyResponse.Value.CopyId, Is.Not.Null);
            Assert.That(copyResponse.Value.CopyStatus, Is.EqualTo(CopyStatus.Success));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_12_06)]
        public async Task SyncCopyFromUriAsync_EncryptionScope()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            destBlob = InstrumentClient(destBlob.WithEncryptionScope(TestConfigDefault.EncryptionScope));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            await sourceBlob.UploadAsync(stream);

            // Act
            Response<BlobCopyInfo> response = await destBlob.SyncCopyFromUriAsync(
                sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)));

            // Assert
            Assert.That(response.Value.EncryptionScope, Is.EqualTo(TestConfigDefault.EncryptionScope));
        }

        [RecordedTest]
        [TestCase(nameof(BlobRequestConditions.LeaseId))]
        public async Task SyncCopyFromUriAsync_InvalidSourceRequestConditions(string invalidSourceCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobBaseClient blobBaseClient = new BlobBaseClient(uri, GetOptions());

            BlobRequestConditions sourceConditions = new BlobRequestConditions();

            switch (invalidSourceCondition)
            {
                case nameof(BlobRequestConditions.LeaseId):
                    sourceConditions.LeaseId = string.Empty;
                    break;
            }

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                SourceConditions = sourceConditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blobBaseClient.SyncCopyFromUriAsync(
                    uri,
                    options: options),
                e =>
                {
                    Assert.That(e.Message.Contains($"SyncCopyFromUri does not support the {invalidSourceCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("sourceConditions"), Is.True);
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SyncCopyFromUriAsync_Tags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            IDictionary<string, string> tags = BuildTags();
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                Tags = tags
            };

            // Act
            Response<BlobCopyInfo> copyResponse = await destBlob.SyncCopyFromUriAsync(
                srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)), options);

            // Assert
            Response<GetBlobTagResult> response = await destBlob.GetTagsAsync();
            AssertDictionaryEquality(tags, response.Value.Tags);
        }

        [RecordedTest]
        public async Task SyncCopyFromUriAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = BuildMetadata();
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                Metadata = metadata
            };

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await destBlob.SyncCopyFromUriAsync(
                source: srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                options);

            // Assert
            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        public async Task SyncCopyFromUriAsync_Source_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(srcBlob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(srcBlob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions sourceAccessConditions = BuildAccessConditions(
                    parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    SourceConditions = sourceAccessConditions
                };

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                Response<BlobCopyInfo> response = await destBlob.SyncCopyFromUriAsync(
                    source: srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    options);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task SyncCopyFromUriAsync_Source_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(srcBlob, parameters.NoneMatch);

                BlobRequestConditions sourceAccessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: false);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    SourceConditions = sourceAccessConditions
                };

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.SyncCopyFromUriAsync(
                        source: srcBlob.Uri,
                        options),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task SyncCopyFromUriAsync_Destination_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // destBlob needs to exist so we can get its lease and etag
                using (var stream = new MemoryStream(data))
                {
                    await destBlob.UploadAsync(stream);
                }

                parameters.Match = await SetupBlobMatchCondition(destBlob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                BlobRequestConditions accessConditions = BuildAccessConditions(parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    DestinationConditions = accessConditions
                };

                // Act
                Response<BlobCopyInfo> response = await destBlob.SyncCopyFromUriAsync(
                    source: srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    options);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task SyncCopyFromUriAsync_Destination_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }

                // destBlob needs to exist so we can get its etag
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await destBlob.UploadAsync(stream);
                }

                parameters.NoneMatch = await SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    DestinationConditions = accessConditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.SyncCopyFromUriAsync(
                        source: srcBlob.Uri,
                        options),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SyncCopyFromUriAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await destBlob.SetTagsAsync(tags);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                DestinationConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            Response<BlobCopyInfo> copyResponse = await destBlob.SyncCopyFromUriAsync(
                srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                options: options);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SyncCopyFromUriAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                DestinationConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncCopyFromUriAsync(
                    srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    options: options),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        [Ignore("Inducing a 500 in the service")]
        public async Task SyncCopyFromUriAsync_AccessTier()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.Cool
            };

            // Act
            await destBlob.SyncCopyFromUriAsync(
                srcBlob.Uri,
                options);

            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.AccessTier, Is.EqualTo(AccessTier.Cool));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2021_12_02)]
        public async Task SyncCopyFromUriAsync_AccessTier_Cold()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.Cold
            };

            // Act
            await destBlob.SyncCopyFromUriAsync(
                srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                options);

            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.AccessTier, Is.EqualTo("Cold"));
        }

        [RecordedTest]
        public async Task SyncCopyFromUriAsync_AccessTierFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.P20
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncCopyFromUriAsync(
                srcBlob.Uri,
                options),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.InvalidHeaderValue.ToString())));
        }

        [RecordedTest]
        public async Task SyncCopyFromUriAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncCopyFromUriAsync(srcBlob.Uri),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.CannotVerifyCopySource.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SyncCopyFromUriAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Response<BlobCopyInfo> response = await destBlob.SyncCopyFromUriAsync(
                srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)));

            // Assert
            Assert.That(response.Value.VersionId, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task SyncCopyFromUri_SourceBearerToken()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            string sourceBearerToken = await GetAuthToken();

            HttpAuthorization sourceAuth = new HttpAuthorization(
                "Bearer",
                sourceBearerToken);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                SourceAuthentication = sourceAuth
            };

            // Act
            Response<BlobCopyInfo> copyResponse = await destBlob.SyncCopyFromUriAsync(
                source: srcBlob.Uri,
                options: options);

            // Check that destBlob actually exists
            await destBlob.GetPropertiesAsync();

            // Assert
            Assert.That(copyResponse.Value.ETag, Is.Not.Null);
            Assert.That(copyResponse.Value.LastModified, Is.Not.Null);
            Assert.That(copyResponse.Value.CopyId, Is.Not.Null);
            Assert.That(copyResponse.Value.CopyStatus, Is.EqualTo(CopyStatus.Success));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task SyncCopyFromUri_SourceBearerTokenFail()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            string sourceTokenCredential = await GetAuthToken();

            HttpAuthorization sourceAuth = new HttpAuthorization(
                "Bearer",
                "auth token");

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                SourceAuthentication = sourceAuth
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncCopyFromUriAsync(
                    source: srcBlob.Uri,
                    options: options),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.CannotVerifyCopySource.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2025_07_05)]
        public async Task SyncCopyFromUri_SourceBearerToken_FilesSource()
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

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                string sourceBearerToken = await GetAuthToken();

                HttpAuthorization sourceAuth = new HttpAuthorization(
                    "Bearer",
                    sourceBearerToken);

                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    SourceAuthentication = sourceAuth,
                    SourceShareTokenIntent = FileShareTokenIntent.Backup
                };

                // Act
                Response<BlobCopyInfo> copyResponse = await destBlob.SyncCopyFromUriAsync(
                    source: fileClient.Uri,
                    options: options);
            }
            finally
            {
                await shareClient.DeleteAsync();
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2021_04_10)]
        [TestCase(null)]
        [TestCase(BlobCopySourceTagsMode.Replace)]
        [TestCase(BlobCopySourceTagsMode.Copy)]
        public async Task SyncCopyFromUriAsync_CopyTags(BlobCopySourceTagsMode? copySourceTags)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            Dictionary<string, string> sourceTags = new Dictionary<string, string>
            {
                { "source", "tag" }
            };

            await srcBlob.SetTagsAsync(sourceTags);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                CopySourceTagsMode = copySourceTags
            };

            Dictionary<string, string> destTags = new Dictionary<string, string>
            {
                { "dest", "tag" }
            };

            if (copySourceTags != BlobCopySourceTagsMode.Copy)
            {
                options.Tags = destTags;
            }

            Uri sourceUri = srcBlob.GenerateSasUri(BlobSasPermissions.All, Recording.UtcNow.AddDays(1));

            // Act
            await destBlob.SyncCopyFromUriAsync(
                source: sourceUri,
                options: options);

            // Assert
            Response<GetBlobTagResult> getTagsResponse = await destBlob.GetTagsAsync();

            if (copySourceTags == BlobCopySourceTagsMode.Copy)
            {
                AssertDictionaryEquality(sourceTags, getTagsResponse.Value.Tags);
            }
            else
            {
                AssertDictionaryEquality(destTags, getTagsResponse.Value.Tags);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2024_08_04)]
        public async Task SyncCopyFromUriAsync_SourceErrorAndStatusCode()
        {
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);

            // Arrange
            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncCopyFromUriAsync(srcBlob.Uri),
                e =>
                {
                    Assert.That(e.Message.Contains("CopySourceStatusCode: 401"), Is.True);
                    Assert.That(e.Message.Contains("CopySourceErrorCode: NoAuthenticationInformation"), Is.True);
                    Assert.That(e.Message.Contains("CopySourceErrorMessage: Server failed to authenticate the request. Please refer to the information in the www-authenticate header."), Is.True);
                });
        }

        [RecordedTest]
        public async Task DeleteAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response response = await blob.DeleteAsync();

            // Assert
            Assert.That(response.Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task DeleteAsync_Options()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            await blob.CreateSnapshotAsync();

            // Act
            await blob.DeleteAsync(snapshotsOption: DeleteSnapshotsOption.OnlySnapshots);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task DeleteAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response response = await blob.DeleteAsync(conditions: accessConditions);

                // Assert
                Assert.That(response.Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task DeleteAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.DeleteAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            Response response = await blob.DeleteAsync(conditions: conditions);

            // Assert
            bool exists = await blob.ExistsAsync();
            Assert.That(exists, Is.False);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DeleteAsync(conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task DeleteAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DeleteAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_Version()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            BlobBaseClient versionBlob = blob.WithVersion(createResponse.Value.VersionId);

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.That((bool)await blob.ExistsAsync(), Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_VersionSAS()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetBlobVersionSas(
                test.Container.Name,
                blob.Name,
                createResponse.Value.VersionId,
                BlobVersionSasPermissions.Delete,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.That((bool)await blob.ExistsAsync(), Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_InvalidVersionSAS()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetBlobSas(
                test.Container.Name,
                blob.Name,
                BlobSasPermissions.Read);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                versionBlob.DeleteAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.AuthorizationPermissionMismatch.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_VersionIdentitySAS()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);
            SasQueryParameters sasQueryParameters = GetBlobVersionIdentitySas(
                test.Container.Name,
                blob.Name,
                createResponse.Value.VersionId,
                BlobVersionSasPermissions.Delete,
                userDelegationKey,
                oauthService.AccountName,
                Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.That((bool)await blob.ExistsAsync(), Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_VersionInvalidSAS()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);
            SasQueryParameters sasQueryParameters = GetBlobIdentitySas(
                test.Container.Name,
                blob.Name,
                BlobSasPermissions.Read,
                userDelegationKey,
                oauthService.AccountName,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                versionBlob.DeleteAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.AuthorizationPermissionMismatch.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(BlobSasPermissions.DeleteBlobVersion)]
        [TestCase(BlobSasPermissions.All)]
        public async Task DeleteAsync_VersionBlobSAS(BlobSasPermissions blobSasPermissions)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetBlobSas(
                test.Container.Name,
                blob.Name,
                blobSasPermissions,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.That((bool)await blob.ExistsAsync(), Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(BlobSasPermissions.DeleteBlobVersion)]
        [TestCase(BlobSasPermissions.All)]
        public async Task DeleteAsync_VersionBlobIdentitySAS(BlobSasPermissions blobSasPermissions)
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);
            SasQueryParameters sasQueryParameters = GetBlobIdentitySas(
                test.Container.Name,
                blob.Name,
                blobSasPermissions,
                userDelegationKey,
                oauthService.AccountName,
                Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.That((bool)await blob.ExistsAsync(), Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(BlobContainerSasPermissions.DeleteBlobVersion)]
        [TestCase(BlobContainerSasPermissions.All)]
        public async Task DeleteAsync_VersionContainerSAS(BlobContainerSasPermissions blobContainerSasPermissions)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetContainerSas(
                test.Container.Name,
                blobContainerSasPermissions,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.That((bool)await blob.ExistsAsync(), Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(BlobContainerSasPermissions.DeleteBlobVersion)]
        [TestCase(BlobContainerSasPermissions.All)]
        public async Task DeleteAsync_VersionContainerIdentitySAS(BlobContainerSasPermissions blobContainerSasPermissions)
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);
            SasQueryParameters sasQueryParameters = GetContainerIdentitySas(
                test.Container.Name,
                blobContainerSasPermissions,
                userDelegationKey,
                oauthService.AccountName,
                Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.That((bool)await blob.ExistsAsync(), Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(AccountSasPermissions.DeleteVersion)]
        [TestCase(AccountSasPermissions.All)]
        public async Task DeleteAsync_VersionAccountSAS(AccountSasPermissions accountSasPermissions)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = BlobsClientBuilder.GetNewAccountSas(
                resourceTypes: AccountSasResourceTypes.All,
                permissions: AccountSasPermissions.All);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.That((bool)await blob.ExistsAsync(), Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_InvalidSAS()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetBlobSas(test.Container.Name, blob.Name, BlobSasPermissions.Read);
            BlobBaseClient versionBlob = blob.WithVersion(createResponse.Value.VersionId);

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.That((bool)await blob.ExistsAsync(), Is.True);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeleteAsync_BlobAccessTierRequestConditions(bool isAccessTierModifiedSince)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // modify the access tier
            await blob.SetAccessTierAsync(AccessTier.Cool);
            DateTimeOffset changeTime = Recording.UtcNow;

            BlobRequestConditions accessConditions;
            if (isAccessTierModifiedSince)
            {
                accessConditions = new BlobRequestConditions
                {
                    // requires modification since yesterday (which there should be modification in this time window)
                    AccessTierIfModifiedSince = changeTime.AddDays(-1)
                };
            }
            else
            {
                accessConditions = new BlobRequestConditions
                {
                    // requires no modification after 5 minutes from now (which there should be no modification then)
                    AccessTierIfUnmodifiedSince = changeTime.AddMinutes(5)
                };
            }

            // Act
            Response response = await blob.DeleteAsync(conditions: accessConditions);

            // Assert
            Assert.That(response.Headers.RequestId, Is.Not.Null);
            Assert.That((bool)await blob.ExistsAsync(), Is.False);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeleteAsync_BlobAccessTierRequestConditions_Fail(bool isAccessTierModifiedSince)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // modify the access tier
            await blob.SetAccessTierAsync(AccessTier.Cool);
            DateTimeOffset changeTime = Recording.UtcNow;

            BlobRequestConditions accessConditions;
            if (isAccessTierModifiedSince)
            {
                accessConditions = new BlobRequestConditions
                {
                    // requires modification after 5 minutes from now (which there should be no modification then)
                    AccessTierIfModifiedSince = changeTime.AddMinutes(5)
                };
            }
            else
            {
                accessConditions = new BlobRequestConditions
                {
                    // requires no modification since yesterday (which there should be modification in this time window)
                    AccessTierIfUnmodifiedSince = changeTime.AddDays(-1)
                };
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DeleteAsync(conditions: accessConditions),
                e =>
                {
                    Assert.That(e.Status, Is.EqualTo(412));
                    Assert.That(e.ErrorCode, Is.EqualTo("AccessTierChangeTimeConditionNotMet"));
                    Assert.That(e.Message, Does.Contain("The condition specified using access tier change time conditional header(s) is not met."));
                });

            // Assert
            Assert.That((bool)await blob.ExistsAsync(), Is.True);
        }

        [RecordedTest]
        public async Task DeleteIfExistsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<bool> response = await blob.DeleteIfExistsAsync();

            // Assert
            Assert.That(response.Value, Is.True);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [RecordedTest]
        public async Task DeleteIfExistsAsync_NotExists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Response<bool> response = await blob.DeleteIfExistsAsync();

            // Assert
            Assert.That(response.Value, Is.False);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [RecordedTest]
        public async Task DeleteIfExistsAsync_ContainerNotExists()
        {
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobContainerClient container = service.GetBlobContainerClient(GetNewContainerName());

            // Arrange
            BlobBaseClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Response<bool> response = await blob.DeleteIfExistsAsync();

            // Assert
            Assert.That(response.Value, Is.False);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        //[Test]
        //public async Task DeleteAsync_Batch()
        //{
        //    using (this.GetNewContainer(out var container, serviceUri: this.GetServiceUri_PreviewAccount_SharedKey()))
        //    {
        //        const int blobSize = Constants.KB;
        //        var data = this.GetRandomBuffer(blobSize);

        //        var blob1 = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob1.UploadAsync(stream);
        //        }

        //        var blob2 = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob2.UploadAsync(stream);
        //        }

        //        var batch =
        //            blob1.DeleteAsync()
        //            .And(blob2.DeleteAsync())
        //            ;

        //        var result = await batch;

        //        Assert.IsNotNull(result);
        //        Assert.AreEqual(2, result.Length);
        //        Assert.IsNotNull(result[0].RequestId);
        //        Assert.IsNotNull(result[1].RequestId);
        //    }
        //}

        [RecordedTest]
        [NonParallelizable]
        public async Task UndeleteAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await EnableSoftDelete();
            try
            {
                BlobBaseClient blob = await GetNewBlobClient(test.Container);
                await blob.DeleteIfExistsAsync();

                // Act
                Response response = await blob.UndeleteAsync();

                // Assert
                response.Headers.TryGetValue("x-ms-version", out var version);
                Assert.That(version, Is.Not.Null);
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
            }
            finally
            {
                // Cleanup
                await DisableSoftDelete();
            }
        }

        [RecordedTest]
        public async Task UndeleteAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.UndeleteAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task ExistsAsync_Exists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<bool> response = await blob.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.True);
        }

        [RecordedTest]
        public async Task ExistsAsync_NotExists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));

            // Act
            Response<bool> response = await blob.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.False);
        }

        [RecordedTest]
        public async Task ExistsAsync_Exists_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await blob.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.True);
        }

        [RecordedTest]
        public async Task ExistsAsync_Exists_CPK_NoKey()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateIfNotExistsAsync();

            AppendBlobClient blobClientNoKey = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            // Act
            Response<bool> response = await blobClientNoKey.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ExistsAsync_Exists_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await blob.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.True);
        }

        [RecordedTest]
        public async Task ExistsAsync_ContainerNotExists()
        {
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobContainerClient container = service.GetBlobContainerClient(GetNewContainerName());

            // Arrange
            BlobBaseClient blob = InstrumentClient(container.GetBlobClient(GetNewBlobName()));

            // Act
            Response<bool> response = await blob.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.False);
        }

        [RecordedTest]
        public async Task ExistsAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            BlobBaseClient unauthorizedBlobClient = InstrumentClient(new BlobBaseClient(blob.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedBlobClient.ExistsAsync(),
                e => { });
        }

        [RecordedTest]
        public async Task ExistsAsync_NotExists_NoLogWarning()
        {
            // Arrange
            BlobClient nonExistentBlob = BlobsClientBuilder.GetServiceClient_SharedKey()
                .GetBlobContainerClient(BlobsClientBuilder.GetNewContainerName())
                .GetBlobClient(BlobsClientBuilder.GetNewBlobName());

            var events = new List<(EventWrittenEventArgs EventData, string EventMessage)>();

            // Act
            bool exists;
            using (AzureEventSourceListener listener = new AzureEventSourceListener(
                (data, message) => events.Add((data, message)),
                EventLevel.Informational))
            {
                exists = await nonExistentBlob.ExistsAsync();
            }

            // Assert
            Assert.That(exists, Is.False);
            Assert.That(events.Where(e => e.EventData.Level < EventLevel.Informational), Is.Empty);
        }

        [RecordedTest]
        public async Task ExistsAsync_Exists_CPK_NoKey_NoLogWarning()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateIfNotExistsAsync();

            AppendBlobClient blobClientNoKey = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            var events = new List<(EventWrittenEventArgs EventData, string EventMessage)>();

            // Act
            bool exists;
            using (AzureEventSourceListener listener = new AzureEventSourceListener(
                (data, message) => events.Add((data, message)),
                EventLevel.Informational))
            {
                exists = await blobClientNoKey.ExistsAsync();
            }

            // Assert
            Assert.That(exists, Is.True);
            Assert.That(events.Where(e => e.EventData.Level < EventLevel.Informational), Is.Empty);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_CheckDefaults()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.BlobCopyStatus, Is.EqualTo(default(CopyStatus))); // correct behavior
            Assert.That(response.Value.CopyStatus, Is.EqualTo((CopyStatus)0)); // legacy facade doesn't break
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPropertiesAsync_Tags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> tags = BuildTags();
            await blob.SetTagsAsync(tags);

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.TagCount, Is.EqualTo(tags.Count));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(null)]
        [TestCase(RehydratePriority.Standard)]
        [TestCase(RehydratePriority.High)]
        public async Task GetPropertiesAsync_RehydratePriority(RehydratePriority? rehydratePriority)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            if (rehydratePriority.HasValue)
            {
                await blob.SetAccessTierAsync(
                    AccessTier.Archive);

                await blob.SetAccessTierAsync(
                    AccessTier.Hot,
                    rehydratePriority: rehydratePriority.Value);
            }

            // Act
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(propertiesResponse.Value.RehydratePriority, Is.EqualTo(rehydratePriority.HasValue ? rehydratePriority.Value.ToString() : null));
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task GetPropertiesAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateIfNotExistsAsync();

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.EncryptionKeySha256, Is.EqualTo(customerProvidedKey.EncryptionKeyHash));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetPropertiesAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateIfNotExistsAsync();

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.EncryptionScope, Is.EqualTo(TestConfigDefault.EncryptionScope));
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_ContainerSAS()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlobSasQueryParameters blobSasQueryParameters = GetContainerSas(
                containerName: test.Container.Name,
                permissions: BlobContainerSasPermissions.Read);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = blobSasQueryParameters
            };

            BlockBlobClient sasBlob = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), GetOptions()));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            var accountName = new BlobUriBuilder(test.Container.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => blob.AccountName);
            TestHelper.AssertCacheableProperty(containerName, () => blob.BlobContainerName);
            TestHelper.AssertCacheableProperty(blobName, () => blob.Name);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_ContainerIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            BlobSasQueryParameters blobSasQueryParameters = GetContainerIdentitySas(
                containerName: test.Container.Name,
                BlobContainerSasPermissions.Read,
                userDelegationKey: userDelegationKey,
                Tenants.TestConfigOAuth.AccountName);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = blobSasQueryParameters
            };

            BlockBlobClient identitySasBlob = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), GetOptions()));

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();
            AssertSasUserDelegationKey(identitySasBlob.Uri, userDelegationKey.Value);

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_BlobSAS()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlockBlobClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Blob(
                    containerName: containerName,
                    blobName: blobName)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_BlobSasWithIdentifier()
        {
            // Arrange
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            string signedIdentifierId = GetNewString();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlobSignedIdentifier identifier = new BlobSignedIdentifier
            {
                Id = signedIdentifierId,
                AccessPolicy = new BlobAccessPolicy
                {
                    PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                    PolicyExpiresOn = Recording.UtcNow.AddHours(1),
                    Permissions = "rw"
                }
            };
            await test.Container.SetAccessPolicyAsync(permissions: new BlobSignedIdentifier[] { identifier });

            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Identifier = signedIdentifierId
            };
            BlobSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials());

            BlobUriBuilder uriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = sasQueryParameters
            };

            BlockBlobClient sasBlob = InstrumentClient(new BlockBlobClient(
                uriBuilder.ToUri(),
                GetOptions()));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_BlobSasWithContentHeaders()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None),
                CacheControl = "\\cache control?",
                ContentDisposition = "\\content disposition?",
                ContentEncoding = "\\content encoding?",
                ContentLanguage = "\\content language?",
                ContentType = "\\content type?"
            };
            blobSasBuilder.SetPermissions(
                BlobSasPermissions.All);

            BlobSasQueryParameters blobSasQueryParameters = blobSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials());

            // Act
            string queryParametersString = blobSasQueryParameters.ToString();

            // Assert
            Assert.That(queryParametersString.Contains("rscc=%5Ccache+control%3F"), Is.True);
            Assert.That(queryParametersString.Contains("rscd=%5Ccontent+disposition%3F"), Is.True);
            Assert.That(queryParametersString.Contains("rsce=%5Ccontent+encoding%3F"), Is.True);
            Assert.That(queryParametersString.Contains("rscl=%5Ccontent+language%3F"), Is.True);
            Assert.That(queryParametersString.Contains("rsct=%5Ccontent+type%3F"), Is.True);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri(TestConfigDefault.BlobServiceEndpoint));
            blobUriBuilder.BlobName = blobName;
            blobUriBuilder.BlobContainerName = containerName;
            blobUriBuilder.Sas = blobSasQueryParameters;
            BlockBlobClient sasBlob = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);

            Assert.That(sasBlob.Uri.Query.Contains("rscc=%5Ccache+control%3F"), Is.True);
            Assert.That(sasBlob.Uri.Query.Contains("rscd=%5Ccontent+disposition%3F"), Is.True);
            Assert.That(sasBlob.Uri.Query.Contains("rsce=%5Ccontent+encoding%3F"), Is.True);
            Assert.That(sasBlob.Uri.Query.Contains("rscl=%5Ccontent+language%3F"), Is.True);
            Assert.That(sasBlob.Uri.Query.Contains("rsct=%5Ccontent+type%3F"), Is.True);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_BlobIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();

            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            BlockBlobClient identitySasBlob = InstrumentClient(
                GetServiceClient_BlobServiceIdentitySas_Blob(
                    containerName: containerName,
                    blobName: blobName,
                    userDelegationKey: userDelegationKey)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName));

            AssertSasUserDelegationKey(identitySasBlob.Uri, userDelegationKey.Value);

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPropertiesAsync_Version()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            BlobBaseClient versionBlob = blob.WithVersion(createResponse.Value.VersionId);

            // Act
            Response<BlobProperties> oldVersionResponse = await versionBlob.GetPropertiesAsync();
            Response<BlobProperties> latestVersionResponse = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(oldVersionResponse.Value.VersionId, Is.Not.Null);
            Assert.That(oldVersionResponse.Value.IsLatestVersion, Is.False);
            Assert.That(oldVersionResponse.Value.VersionId, Is.Not.Null);
            Assert.That(latestVersionResponse.Value.IsLatestVersion, Is.True);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_SnapshotSAS()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlockBlobClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Snapshot(
                    containerName: containerName,
                    blobName: blobName,
                    snapshot: snapshotResponse.Value.Snapshot)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName)
                .WithSnapshot(snapshotResponse.Value.Snapshot));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_SnapshotSAS_Using_BlobClient()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlobBaseClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Snapshot(
                    containerName: containerName,
                    blobName: blobName,
                    snapshot: snapshotResponse.Value.Snapshot)
                .GetBlobContainerClient(containerName)
                .GetBlobClient(blobName)
                .WithSnapshot(snapshotResponse.Value.Snapshot));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_SnapshotIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            BlobSasQueryParameters blobSasQueryParameters = GetSnapshotIdentitySas(
                containerName: test.Container.Name,
                blobName: blob.Name,
                snapshot: snapshotResponse.Value.Snapshot,
                permissions: SnapshotSasPermissions.Read,
                userDelegationKey: userDelegationKey,
                accountName: Tenants.TestConfigOAuth.AccountName);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = blobSasQueryParameters
            };

            BlockBlobClient identitySasBlob = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), GetOptions())).WithSnapshot(snapshotResponse.Value.Snapshot);

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            AssertSasUserDelegationKey(identitySasBlob.Uri, userDelegationKey.Value);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobProperties> response = await blob.GetPropertiesAsync(conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await blob.GetPropertiesAsync(
                            conditions: accessConditions)).Value;
                    });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPropertiesAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync(conditions: conditions);

            // Assert
            Assert.That(response.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPropertiesAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPropertiesAsync(conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [PlaybackOnly("Object Replication policies is only enabled on certain storage accounts")]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPropertiesAsync_ObjectReplication()
        {
            // TODO: The tests will temporarily use designated account, containers and blobs to check the
            // existence of OR headers
            BlobServiceClient sourceServiceClient = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobServiceClient destinationServiceClient = BlobsClientBuilder.GetServiceClient_SecondaryAccount_SharedKey();

            // This is a PLAYBACK ONLY test with a special container we previously setup, as we can't auto setup policies yet
            BlobContainerClient sourceContainer = InstrumentClient(sourceServiceClient.GetBlobContainerClient("test1"));
            BlobContainerClient destinationContainer = InstrumentClient(destinationServiceClient.GetBlobContainerClient("test2"));

            // Arrange
            string blob_name = "netgetpropertiesors2blobapitestgetpropertiesors";
            BlobClient sourceBlob = sourceContainer.GetBlobClient(blob_name);
            BlobClient destBlob = destinationContainer.GetBlobClient(blob_name);

            // Act
            Response<BlobProperties> source_response = await sourceBlob.GetPropertiesAsync();
            Response<BlobProperties> dest_response = await destBlob.GetPropertiesAsync();

            // Assert
            Assert.That(source_response.Value.ObjectReplicationSourceProperties.Count, Is.EqualTo(1));
            Assert.That(source_response.Value.ObjectReplicationDestinationPolicyId, Is.Null);
            Assert.That(dest_response.Value.ObjectReplicationDestinationPolicyId, Is.Not.Empty);
            Assert.That(dest_response.Value.ObjectReplicationSourceProperties, Is.Null);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPropertiesAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetPropertiesAsync_LastAccessed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.LastAccessed, Is.Not.EqualTo(DateTimeOffset.MinValue));
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync()
        {
            var constants = TestConstants.Create(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobInfo> response = await blob.SetHttpHeadersAsync(new BlobHttpHeaders
            {
                CacheControl = constants.CacheControl,
                ContentDisposition = constants.ContentDisposition,
                ContentEncoding = constants.ContentEncoding,
                ContentLanguage = constants.ContentLanguage,
                ContentHash = constants.ContentMD5,
                ContentType = constants.ContentType
            });

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));

            // Ensure the values has been correctly set by doing a GetProperties call
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();
            Assert.That(propertiesResponse.Value.ContentType, Is.EqualTo(constants.ContentType));
            TestHelper.AssertSequenceEqual(constants.ContentMD5, propertiesResponse.Value.ContentHash);
            Assert.That(propertiesResponse.Value.ContentEncoding, Is.EqualTo(constants.ContentEncoding));
            Assert.That(propertiesResponse.Value.ContentLanguage, Is.EqualTo(constants.ContentLanguage));
            Assert.That(propertiesResponse.Value.ContentDisposition, Is.EqualTo(constants.ContentDisposition));
            Assert.That(propertiesResponse.Value.CacheControl, Is.EqualTo(constants.CacheControl));
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync_MultipleHeaders()
        {
            var constants = TestConstants.Create(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            await blob.SetHttpHeadersAsync(new BlobHttpHeaders
            {
                ContentEncoding = "deflate,gzip",
                ContentLanguage = "de-DE,en-CA",
            });

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.That(response.Value.ContentEncoding, Is.EqualTo("deflate,gzip"));
            Assert.That(response.Value.ContentLanguage, Is.EqualTo("de-DE,en-CA"));
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobInfo> response = await blob.SetHttpHeadersAsync(
                    httpHeaders: new BlobHttpHeaders(),
                    conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.SetHttpHeadersAsync(
                        httpHeaders: new BlobHttpHeaders(),
                        conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetHttpHeadersAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            Response<BlobInfo> response = await blob.SetHttpHeadersAsync(
                new BlobHttpHeaders
                {
                    ContentEncoding = "deflate, gzip",
                    ContentLanguage = "de-DE, en-CA",
                },
                conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetHttpHeadersAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetHttpHeadersAsync(
                    new BlobHttpHeaders
                    {
                        ContentEncoding = "deflate, gzip",
                        ContentLanguage = "de-DE, en-CA",
                    },
                    conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetHttpHeadersAsync(new BlobHttpHeaders()),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task SetMetadataAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<BlobInfo> response = await blob.SetMetadataAsync(metadata);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));

            // Ensure the value has been correctly set by doing a GetProperties call
            Response<BlobProperties> getPropertiesResponse = await blob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, getPropertiesResponse.Value.Metadata);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetMetadataAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<BlobInfo> response = await blob.SetMetadataAsync(metadata);

            // Assert
            Assert.That(response.Value.VersionId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task SetMetadataAsync_CPK()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateIfNotExistsAsync();

            // Act
            await blob.SetMetadataAsync(metadata);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task SetMetadataAsync_EncryptionScope()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateIfNotExistsAsync();

            // Act
            Response<BlobInfo> response = await blob.SetMetadataAsync(metadata);
        }

        [RecordedTest]
        public async Task SetMetadataAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);
                IDictionary<string, string> metadata = BuildMetadata();

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobInfo> response = await blob.SetMetadataAsync(
                    metadata: metadata,
                    conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task SetMetadataAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);
                IDictionary<string, string> metadata = BuildMetadata();

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.SetMetadataAsync(
                        metadata: metadata,
                        conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetMetadataAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<BlobInfo> response = await blob.SetMetadataAsync(
                metadata: metadata,
                conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetMetadataAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetMetadataAsync(
                    metadata: metadata,
                    conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task SetMetadataAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetMetadataAsync(metadata),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task SetMetadataAsync_Sort()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = new Dictionary<string, string>() {
                { "a0", "a" },
                { "a1", "a" },
                { "a2", "a" },
                { "a3", "a" },
                { "a4", "a" },
                { "a5", "a" },
                { "a6", "a" },
                { "a7", "a" },
                { "a8", "a" },
                { "a9", "a" },
                { "_", "a" },
                { "_a", "a" },
                { "a_", "a" },
                { "__", "a" },
                { "_a_", "a" },
                { "b", "a" },
                { "c", "a" },
                { "y", "a" },
                { "z", "z_" },
                { "_z", "a" },
                { "_F", "a" },
                { "F", "a" },
                { "F_", "a" },
                { "_F_", "a" },
                { "__F", "a" },
                { "__a", "a" },
                { "a__", "a" }
             };

            // Act
            Response<BlobInfo> response = await blob.SetMetadataAsync(metadata);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));

            // Ensure the value has been correctly set by doing a GetProperties call
            Response<BlobProperties> getPropertiesResponse = await blob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, getPropertiesResponse.Value.Metadata);
        }

        [RecordedTest]
        public async Task SetMetadataAsync_Sort_InvalidMetadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = new Dictionary<string, string>() {
                { "test", "val" },
                { "test-", "val" },
                { "test--", "val" },
                { "test-_", "val" },
                { "test_-", "val" },
                { "test__", "val" },
                { "test-a", "val" },
                { "test-_A", "val" },
                { "test_a", "val" },
                { "test_Z", "val" },
                { "test_a_", "val" },
                { "test_a-", "val" },
                { "test_a-_", "val" },
             };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetMetadataAsync(metadata),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.InvalidMetadata.ToString())));
        }

        [RecordedTest]
        public async Task CreateSnapshotAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));

            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task CreateSnapshotAsync_CPK()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateIfNotExistsAsync();

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CreateSnapshotAsync_EncryptionScope()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateIfNotExistsAsync();

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task CreateSnapshotAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync(conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task CreateSnapshotAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.CreateSnapshotAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateSnapshotAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync(conditions: conditions);

            // Assert
            bool exists = await blob.WithSnapshot(response.Value.Snapshot).ExistsAsync();
            Assert.That(exists, Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateSnapshotAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateSnapshotAsync(conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task CreateSnapshotAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateSnapshotAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateSnapshotAsync_Version()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

            // Assert
            Assert.That(response.Value.VersionId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            var leaseClient = InstrumentClient(blob.GetBlobLeaseClient(leaseId));

            // Act
            Response<BlobLease> response = await leaseClient.AcquireAsync(duration);

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            Assert.That(leaseClient.LeaseId, Is.EqualTo(response.Value.LeaseId));
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                RequestConditions accessConditions = BuildRequestConditions(
                    parameters: parameters);

                // Act
                Response<BlobLease> response = await InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(
                    duration: duration,
                    conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(
                        duration: duration,
                        conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AcquireLeaseAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            await InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(
                duration,
                conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AcquireLeaseAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(
                    duration,
                    conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(duration),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_ExtendedExceptionMessage()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(10);
            BlobLeaseClient blobLeaseClient = InstrumentClient(blob.GetBlobLeaseClient(leaseId));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blobLeaseClient.AcquireAsync(duration),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.InvalidHeaderValue.ToString()));
                    Assert.That(e.Message.Contains($"Additional Information:{Environment.NewLine}HeaderName: x-ms-lease-duration{Environment.NewLine}HeaderValue: 10"), Is.True);
                });
        }

        [RecordedTest]
        public async Task RenewLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<BlobLease> response = await lease.RenewAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            Assert.That(lease.LeaseId, Is.EqualTo(response.Value.LeaseId));

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                RequestConditions accessConditions = BuildRequestConditions(
                    parameters: parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await lease.RenewAsync(conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.RenewAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RenewLeaseAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await lease.RenewAsync(conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RenewLeaseAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                lease.RenewAsync(conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).ReleaseAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<ReleasedObjectInfo> response = await lease.ReleaseAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That(response.Value.ETag.ToString(), Is.EqualTo($"\"{response.GetRawResponse().Headers.ETag}\""));
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                RequestConditions accessConditions = BuildRequestConditions(
                    parameters: parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.ReleaseAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ReleaseLeaseAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await lease.ReleaseAsync(conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ReleaseLeaseAsync_IfTagsFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                lease.ReleaseAsync(conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).RenewAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task BreakLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<BlobLease> response = await lease.BreakAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_BreakPeriod()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            TimeSpan breakPeriod = TimeSpan.FromSeconds(5);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<BlobLease> response = await lease.BreakAsync(breakPeriod: breakPeriod);

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                RequestConditions accessConditions = BuildRequestConditions(
                    parameters: parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await lease.BreakAsync(conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.BreakAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task BreakLeaseAsync_IfTag()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await lease.BreakAsync(conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task BreakLeaseAsync_IfTagFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                lease.BreakAsync(conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient()).BreakAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<BlobLease> response = await lease.ChangeAsync(newLeaseId);

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            Assert.That(response.Value.LeaseId, Is.EqualTo(newLeaseId));
            Assert.That(lease.LeaseId, Is.EqualTo(response.Value.LeaseId));

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That(response.Value.ETag.ToString(), Is.EqualTo($"\"{response.GetRawResponse().Headers.ETag}\""));
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                RequestConditions accessConditions = BuildRequestConditions(
                    parameters: parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await lease.ChangeAsync(
                    proposedId: newLeaseId,
                    conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.ChangeAsync(
                        proposedId: newLeaseId,
                        conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ChangeLeaseAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await lease.ChangeAsync(
                newLeaseId,
                conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ChangeLeaseAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                lease.ChangeAsync(
                newLeaseId,
                conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).ChangeAsync(proposedId: newLeaseId),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task SetTierAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response response = await blob.SetAccessTierAsync(AccessTier.Cool);

            // Assert
            Assert.That(response.Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2021_12_02)]
        public async Task SetTierAsync_Cold()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            await blob.SetAccessTierAsync(AccessTier.Cold);

            // We are also going to test that get blob properties and list blobs return cold tier correctly.

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.AccessTier, Is.EqualTo("Cold"));

            // Act
            List<BlobItem> blobItems = new List<BlobItem>();
            await foreach (BlobItem blobItem in test.Container.GetBlobsAsync())
            {
                blobItems.Add(blobItem);
            }

            // Assert
            Assert.That(blobItems.Count, Is.EqualTo(1));
            Assert.That(blobItems[0].Properties.AccessTier, Is.EqualTo(AccessTier.Cold));

            // Act
            List<BlobHierarchyItem> blobHierarchyItems = new List<BlobHierarchyItem>();
            await foreach (BlobHierarchyItem blobHierarchyItem in test.Container.GetBlobsByHierarchyAsync())
            {
                blobHierarchyItems.Add(blobHierarchyItem);
            }

            // Assert
            Assert.That(blobHierarchyItems.Count, Is.EqualTo(1));
            Assert.That(blobHierarchyItems[0].Blob.Properties.AccessTier, Is.EqualTo(AccessTier.Cold));
        }

        [RecordedTest]
        [TestCase(nameof(BlobRequestConditions.IfModifiedSince))]
        [TestCase(nameof(BlobRequestConditions.IfUnmodifiedSince))]
        [TestCase(nameof(BlobRequestConditions.IfMatch))]
        [TestCase(nameof(BlobRequestConditions.IfNoneMatch))]
        public async Task SetAccessTierAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            BlobBaseClient blobBaseClient = new BlobBaseClient(uri, GetOptions());

            BlobRequestConditions conditions = new BlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(BlobRequestConditions.IfModifiedSince):
                    conditions.IfModifiedSince = new DateTimeOffset();
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
                blobBaseClient.SetAccessTierAsync(
                    AccessTier.Archive,
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"SetAccessTier does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task SetTierAsync_Lease()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            await InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(duration);

            // Act
            Response response = await blob.SetAccessTierAsync(
                accessTier: AccessTier.Cool,
                conditions: new BlobRequestConditions
                {
                    LeaseId = leaseId
                });

            // Assert
            Assert.That(response.Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task SetTierAsync_LeaseFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetAccessTierAsync(
                    accessTier: AccessTier.Cool,
                    conditions: new BlobRequestConditions
                    {
                        LeaseId = leaseId
                    }),
                e => Assert.That(e.ErrorCode, Is.EqualTo("LeaseNotPresentWithBlobOperation")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTierAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await blob.SetAccessTierAsync(
                accessTier: AccessTier.Cool,
                conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTierAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetAccessTierAsync(
                    accessTier: AccessTier.Cool,
                    conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.ConditionNotMet.ToString())));
        }

        [RecordedTest]
        public async Task SetTierAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetAccessTierAsync(AccessTier.Cool),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        public async Task SetTierAsync_Rehydrate()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            await blob.SetAccessTierAsync(AccessTier.Archive);

            // Act
            Response setTierResponse = await blob.SetAccessTierAsync(
                accessTier: AccessTier.Cool,
                rehydratePriority: RehydratePriority.High);
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();

            // Assert
            Assert.That(propertiesResponse.Value.ArchiveStatus, Is.EqualTo("rehydrate-pending-to-cool"));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTierAsync_Snapshot()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();
            BlobBaseClient snapshotBlob = blob.WithSnapshot(snapshotResponse.Value.Snapshot);

            // Act
            await snapshotBlob.SetAccessTierAsync(AccessTier.Cool);
            Response<BlobProperties> propertiesResponse = await snapshotBlob.GetPropertiesAsync();

            // Assert
            Assert.That(propertiesResponse.Value.AccessTier, Is.EqualTo(AccessTier.Cool.ToString()));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTierAsync_SnapshotError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            string fakeVersion = "2020-04-17T20:37:16.5129130Z";
            BlobBaseClient snapshotBlob = blob.WithSnapshot(fakeVersion);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                snapshotBlob.SetAccessTierAsync(AccessTier.Cool),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.BlobNotFound.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTierAsync_Version()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> uploadResponse;
            using (var stream = new MemoryStream(data))
            {
                uploadResponse = await blob.UploadAsync(stream);
            }

            // Act
            BlobBaseClient versionBlob = blob.WithVersion(uploadResponse.Value.VersionId);

            // Act
            await versionBlob.SetAccessTierAsync(AccessTier.Cool);
            Response<BlobProperties> propertiesResponse = await versionBlob.GetPropertiesAsync();

            // Assert
            Assert.That(propertiesResponse.Value.AccessTier, Is.EqualTo(AccessTier.Cool.ToString()));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTierAsync_VersionError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            string fakeVersion = "2020-04-17T20:37:16.5129130Z";
            BlobBaseClient versionBlob = blob.WithVersion(fakeVersion);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                versionBlob.SetAccessTierAsync(AccessTier.Cool),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.BlobNotFound.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Dictionary<string, string> tags = BuildTags();

            // Act
            await blob.SetTagsAsync(tags);
            Response<GetBlobTagResult> getTagsResponse = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_BlobTagSas()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            SasQueryParameters sasQueryParameters = GetBlobSas(
                test.Container.Name,
                blob.Name,
                BlobSasPermissions.Tag,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient sasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await sasBlob.SetTagsAsync(tags);
            Response<GetBlobTagResult> getTagsResponse = await sasBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_InvalidBlobSas()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            SasQueryParameters sasQueryParameters = GetBlobSas(
                test.Container.Name, blob.Name,
                BlobSasPermissions.Read,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient sasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sasBlob.SetTagsAsync(tags),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.AuthorizationPermissionMismatch.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_BlobIdentityTagSas()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            SasQueryParameters sasQueryParameters = GetBlobIdentitySas(
                test.Container.Name,
                blob.Name,
                BlobSasPermissions.Tag,
                userDelegationKey,
                oauthService.AccountName,
                sasVersion: Constants.DefaultSasVersion);

            BlobBaseClient identitySasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await identitySasBlob.SetTagsAsync(tags);
            Response<GetBlobTagResult> getTagsResponse = await identitySasBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_InvalidBlobIdentitySas()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            SasQueryParameters sasQueryParameters = GetBlobIdentitySas(
                test.Container.Name,
                blob.Name,
                BlobSasPermissions.Read,
                userDelegationKey,
                oauthService.AccountName,
                sasVersion: Constants.DefaultSasVersion);

            BlobBaseClient identitySasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                identitySasBlob.SetTagsAsync(tags),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.AuthorizationPermissionMismatch.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_ContainerTagSas()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            SasQueryParameters sasQueryParameters = GetContainerSas(
                test.Container.Name,
                BlobContainerSasPermissions.Tag,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient sasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await sasBlob.SetTagsAsync(tags);
            Response<GetBlobTagResult> getTagsResponse = await sasBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_InvalidContainerSas()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            SasQueryParameters sasQueryParameters = GetContainerSas(
                test.Container.Name,
                BlobContainerSasPermissions.Read,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient sasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sasBlob.SetTagsAsync(tags),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.AuthorizationPermissionMismatch.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_ContainerIdentityTagSas()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            SasQueryParameters sasQueryParameters = GetContainerIdentitySas(
                test.Container.Name,
                BlobContainerSasPermissions.Tag,
                userDelegationKey,
                oauthService.AccountName,
                sasVersion: Constants.DefaultSasVersion);

            BlobBaseClient identitySasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await identitySasBlob.SetTagsAsync(tags);
            Response<GetBlobTagResult> getTagsResponse = await identitySasBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_InvalidContainerIdentitySas()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            SasQueryParameters sasQueryParameters = GetContainerIdentitySas(
                test.Container.Name,
                BlobContainerSasPermissions.Read,
                userDelegationKey,
                oauthService.AccountName,
                sasVersion: Constants.DefaultSasVersion);

            BlobBaseClient identitySasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                identitySasBlob.SetTagsAsync(tags),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.AuthorizationPermissionMismatch.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(AccountSasPermissions.Tag)]
        [TestCase(AccountSasPermissions.All)]
        public async Task GetSetTagsAsync_AccountSas(AccountSasPermissions accountSasPermissions)
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            SasQueryParameters sasQueryParameters = BlobsClientBuilder.GetNewAccountSas(permissions: accountSasPermissions);
            BlobBaseClient sasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await sasBlob.SetTagsAsync(tags);
            Response<GetBlobTagResult> getTagsResponse = await sasBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            tags.Add("anotherTag", "anotherValue");

            // Act
            await blob.SetTagsAsync(
                tags,
                conditions: conditions);
            Response<GetBlobTagResult> getTagsResponse = await blob.GetTagsAsync(
                conditions: conditions);

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetTagsAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetTagsAsync(
                conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTagsAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetTagsAsync(
                    tags,
                conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_Version()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(BuildMetadata());
            BlobBaseClient versionBlob = blob.WithVersion(metadataResponse.Value.VersionId);
            Dictionary<string, string> tags = BuildTags();

            // Act
            await versionBlob.SetTagsAsync(tags);
            Response<GetBlobTagResult> getVersionTagsResponse = await versionBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getVersionTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_VersionError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            string fakeVersion = "2020-04-17T21:55:48.6692074Z";
            BlobBaseClient versionBlob = blob.WithVersion(fakeVersion);
            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                versionBlob.SetTagsAsync(tags),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.BlobNotFound.ToString())));

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                versionBlob.GetTagsAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.BlobNotFound.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetTags_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                // Arrange
                await using DisposingContainer test = await GetTestContainerAsync();
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.GetTagsAsync(
                        conditions: accessConditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetTagsAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = InstrumentClient(test.Container.GetBlobBaseClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetTagsAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.BlobNotFound.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTagsAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = InstrumentClient(test.Container.GetBlobBaseClient(GetNewBlobName()));
            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetTagsAsync(tags),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.BlobNotFound.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task GetSetTagsAsync_Lease()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);
            await InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(duration);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                LeaseId = leaseId
            };

            Dictionary<string, string> tags = BuildTags();
            await blob.SetTagsAsync(tags, conditions);

            // Act
            Response<GetBlobTagResult> response = await blob.GetTagsAsync(conditions);

            // Assert
            AssertDictionaryEquality(tags, response.Value.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task GetTagsAsync_LeaseFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            string leaseId = Recording.Random.NewGuid().ToString();

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetTagsAsync(conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.LeaseNotPresentWithBlobOperation.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SetTagsAsync_LeaseFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            string leaseId = Recording.Random.NewGuid().ToString();

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                LeaseId = leaseId
            };

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetTagsAsync(tags, conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.LeaseNotPresentWithBlobOperation.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                await using DisposingContainer test = await GetTestContainerAsync();
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                Dictionary<string, string> tags = BuildTags();

                // Act
                await blob.SetTagsAsync(
                   tags: tags,
                   conditions: accessConditions);

                Response<GetBlobTagResult> response = await blob.GetTagsAsync(
                    conditions: accessConditions);

                // Assert
                AssertDictionaryEquality(tags, response.Value.Tags);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task SetTags_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                // Arrange
                await using DisposingContainer test = await GetTestContainerAsync();
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                Dictionary<string, string> tags = BuildTags();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.SetTagsAsync(
                        tags: tags,
                        conditions: accessConditions),
                    e => { });
            }
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

            // Act - BlobBaseClient(string connectionString, string blobContainerName, string blobName)
            BlobBaseClient blob = InstrumentClient(new BlobBaseClient(
                connectionString,
                GetNewContainerName(),
                GetNewBlobName()));
            Assert.That(blob.CanGenerateSasUri, Is.True);

            // Act - BlobBaseClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            BlobBaseClient blob2 = InstrumentClient(new BlobBaseClient(
                connectionString,
                GetNewContainerName(),
                GetNewBlobName(),
                GetOptions()));
            Assert.That(blob2.CanGenerateSasUri, Is.True);

            // Act - BlobBaseClient(Uri blobContainerUri, BlobClientOptions options = default)
            BlobBaseClient blob3 = InstrumentClient(new BlobBaseClient(
                blobEndpoint,
                GetOptions()));
            Assert.That(blob3.CanGenerateSasUri, Is.False);

            // Act - BlobBaseClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            BlobBaseClient blob4 = InstrumentClient(new BlobBaseClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.That(blob4.CanGenerateSasUri, Is.True);

            // Act - BlobBaseClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            BlobBaseClient blob5 = InstrumentClient(new BlobBaseClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.That(blob5.CanGenerateSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateSas_GetParentBlobContainerClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - BlobBaseClient(string connectionString, string blobContainerName, string blobName)
            BlobBaseClient blob = InstrumentClient(new BlobBaseClient(
                connectionString,
                GetNewContainerName(),
                GetNewBlobName()));
            BlobContainerClient container = blob.GetParentBlobContainerClient();
            Assert.That(container.CanGenerateSasUri, Is.True);

            // Act - BlobBaseClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            BlobBaseClient blob2 = InstrumentClient(new BlobBaseClient(
                connectionString,
                GetNewContainerName(),
                GetNewBlobName(),
                GetOptions()));
            BlobContainerClient container2 = blob2.GetParentBlobContainerClient();
            Assert.That(container2.CanGenerateSasUri, Is.True);

            // Act - BlobBaseClient(Uri blobContainerUri, BlobClientOptions options = default)
            BlobBaseClient blob3 = InstrumentClient(new BlobBaseClient(
                blobEndpoint,
                GetOptions()));
            BlobContainerClient container3 = blob3.GetParentBlobContainerClient();
            Assert.That(container3.CanGenerateSasUri, Is.False);

            // Act - BlobBaseClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            BlobBaseClient blob4 = InstrumentClient(new BlobBaseClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            BlobContainerClient container4 = blob4.GetParentBlobContainerClient();
            Assert.That(container4.CanGenerateSasUri, Is.True);

            // Act - BlobBaseClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            BlobBaseClient blob5 = InstrumentClient(new BlobBaseClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            BlobContainerClient container5 = blob5.GetParentBlobContainerClient();
            Assert.That(container5.CanGenerateSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateSas_WithSnapshot_True()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Create blob
            BlobBaseClient blob = InstrumentClient(new BlobBaseClient(
                connectionString,
                GetNewContainerName(),
                GetNewBlobName()));
            Assert.That(blob.CanGenerateSasUri, Is.True);

            // Act
            string snapshot = "2020-04-17T20:37:16.5129130Z";
            BlobBaseClient snapshotBlob = blob.WithSnapshot(snapshot);

            // Assert
            Assert.That(snapshotBlob.CanGenerateSasUri, Is.True);
        }

        [RecordedTest]
        public void CanGenerateSas_WithSnapshot_False()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);

            // Create blob
            BlobBaseClient blob = InstrumentClient(new BlobBaseClient(
                blobEndpoint,
                GetOptions()));
            Assert.That(blob.CanGenerateSasUri, Is.False);

            // Act
            string snapshot = "2020-04-17T20:37:16.5129130Z";
            BlobBaseClient snapshotBlob = blob.WithSnapshot(snapshot);

            // Assert
            Assert.That(snapshotBlob.CanGenerateSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateSas_WithVersion_True()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Create blob
            BlobBaseClient blob = InstrumentClient(new BlobBaseClient(
                connectionString,
                GetNewContainerName(),
                GetNewBlobName()));
            Assert.That(blob.CanGenerateSasUri, Is.True);

            // Act
            string version = "2020-04-17T21:55:48.6692074Z";
            BlobBaseClient versionBlob = blob.WithVersion(version);

            // Assert
            Assert.That(versionBlob.CanGenerateSasUri, Is.True);
        }

        [RecordedTest]
        public void CanGenerateSas_WithVersion_False()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);

            // Create blob
            BlobBaseClient blob = InstrumentClient(new BlobBaseClient(
                blobEndpoint,
                GetOptions()));
            Assert.That(blob.CanGenerateSasUri, Is.False);

            // Act
            string version = "2020-04-17T21:55:48.6692074Z";
            BlobBaseClient versionBlob = blob.WithVersion(version);

            // Assert
            Assert.That(versionBlob.CanGenerateSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateSas_Mockable()
        {
            // Act
            var blob = new Mock<BlobBaseClient>();
            blob.Setup(x => x.CanGenerateSasUri).Returns(false);

            // Assert
            Assert.That(blob.Object.CanGenerateSasUri, Is.False);

            // Act
            blob.Setup(x => x.CanGenerateSasUri).Returns(true);

            // Assert
            Assert.That(blob.Object.CanGenerateSasUri, Is.True);
        }

        [RecordedTest]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            string stringToSign = null;

            // Act
            Uri sasUri = blobClient.GenerateSasUri(permissions, expiresOn, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Sas = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public void GenerateSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                StartsOn = startsOn
            };

            string stringToSign = null;

            // Act
            Uri sasUri = blobClient.GenerateSasUri(sasBuilder, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                StartsOn = startsOn
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullContainerName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobName = GetNewBlobName();
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = null,
                BlobName = blobName,
                Resource = "b"
            };

            // Act
            Uri sasUri = blobClient.GenerateSasUri(sasBuilder);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongContainerName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobName = GetNewBlobName();
            string containerName = GetNewContainerName();
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri($"https://{constants.Sas.Account}.blob.core.windows.net"))
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = GetNewContainerName(), // set a different containerName
                BlobName = blobName,
                Resource = "b"
            };

            // Act
            TestHelper.AssertExpectedException(
                () => blobClient.GenerateSasUri(sasBuilder),
                 new InvalidOperationException("SAS Uri cannot be generated. BlobSasBuilder.BlobContainerName does not match BlobContainerName in the Client. BlobSasBuilder.BlobContainerName must either be left empty or match the BlobContainerName in the Client"));
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullBlobName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobName = GetNewBlobName();
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = null,
                Resource = "b",
                StartsOn = startsOn
            };

            // Act
            Uri sasUri = blobClient.GenerateSasUri(sasBuilder);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                StartsOn = startsOn
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongBlobName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri($"https://{constants.Sas.Account}.blob.core.windows.net"))
            {
                BlobContainerName = containerName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = GetNewBlobName(), // set a different blobName
                Resource = "b"
            };

            // Act
            TestHelper.AssertExpectedException(
                () => blobClient.GenerateSasUri(sasBuilder),
                 new InvalidOperationException("SAS Uri cannot be generated. BlobSasBuilder.BlobName does not match Name in the Client. BlobSasBuilder.BlobName must either be left empty or match the Name in the Client"));
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullSnapshot()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobName = GetNewBlobName();
            string containerName = GetNewContainerName();
            string snapshot = "2020-07-03T12:45:46.1234567Z";
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = null,
                Resource = "b",
                StartsOn = startsOn
            };

            // Act
            Uri sasUri = blobClient.GenerateSasUri(sasBuilder);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                StartsOn = startsOn
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongSnapshot()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string snapshot = "2020-07-03T12:45:46.1234567Z";
            string differentSnapshot = "2019-07-03T12:45:46.1234567Z";
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri($"https://{constants.Sas.Account}.blob.core.windows.net"))
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Resource = "bs",
                Snapshot = differentSnapshot
            };

            // Act
            TestHelper.AssertExpectedException(
                () => blobClient.GenerateSasUri(sasBuilder),
                 new InvalidOperationException("SAS Uri cannot be generated. BlobSasBuilder.Snapshot does not match snapshot value in the URI in the Client. BlobSasBuilder.Snapshot must either be left empty or match the snapshot value in the URI in the Client"));
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullVersion()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobName = GetNewBlobName();
            string containerName = GetNewContainerName();
            string versionId = "2020-07-03T12:45:46.1234567Z";
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                VersionId = versionId
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                BlobVersionId = null,
                Resource = "b",
                StartsOn = startsOn
            };

            // Act
            Uri sasUri = blobClient.GenerateSasUri(sasBuilder);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                BlobVersionId = versionId,
                StartsOn = startsOn
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                VersionId = versionId,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongVersion()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobVersionId = "2020-07-03T12:45:46.1234567Z";
            string diffBlobVersionId = "2019-07-03T12:45:46.1234567Z";
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            Uri blobEndpoint = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blobEndpoint)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                VersionId = blobVersionId
            };

            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Resource = "bs",
                BlobVersionId = diffBlobVersionId,
            };

            // Act
            TestHelper.AssertExpectedException(
                () => blobClient.GenerateSasUri(sasBuilder),
                 new InvalidOperationException("SAS Uri cannot be generated. BlobSasBuilder.BlobVersionId does not match snapshot value in the URI in the Client. BlobSasBuilder.BlobVersionId must either be left empty or match the snapshot value in the URI in the Client"));
        }

        [RecordedTest]
        public async Task GenerateSas_TrimBlobSlashes()
        {
            // Arrange
            StorageSharedKeyCredential sharedKeyCredential = Tenants.GetNewSharedKeyCredentials();
            await using DisposingContainer test = await GetTestContainerAsync();
            string containerName = test.Container.Name;
            string blobName = $"/{GetNewBlobName()}";

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri, false)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };

            // Set up options with TrimBlobNameSlashes set to false
            BlobClientOptions options = GetOptions();
            options.TrimBlobNameSlashes = false;
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AppendBlobClient createClient = InstrumentClient(new AppendBlobClient(
                blobUriBuilder.ToUri(),
                sharedKeyCredential,
                options));

            await createClient.CreateAsync();

            // Act
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                sharedKeyCredential,
                options));

            Uri sasUri = blobClient.GenerateSasUri(permissions, expiresOn);

            // Assert
            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(test.Container.Uri, false)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Sas = sasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));

            BlobBaseClient sasClient = InstrumentClient(new BlobBaseClient(sasUri, options));
            Assert.That((bool)await sasClient.ExistsAsync(), Is.True);
        }
        #endregion

        #region GenerateUserDelegationSasTests
        [RecordedTest]
        public async Task GenerateUserDelegationSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = blobClient.GenerateUserDelegationSasUri(permissions, expiresOn, userDelegationKey, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Sas = sasBuilder.ToSasQueryParameters(userDelegationKey, blobClient.AccountName)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                StartsOn = startsOn
            };

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                StartsOn = startsOn
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, blobClient.AccountName)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNull()
        {
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => blobClient.GenerateUserDelegationSasUri(null, userDelegationKey, out stringToSign),
                 new ArgumentNullException("builder"));
        }

        [RecordedTest]
        public void GenerateUserDelegationSas_UserDelegationKeyNull()
        {
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                StartsOn = startsOn
            };

            string stringToSign = null;

            // Act
            TestHelper.AssertExpectedException(
                () => blobClient.GenerateUserDelegationSasUri(sasBuilder, null, out stringToSign),
                 new ArgumentNullException("userDelegationKey"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullContainerName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobName = GetNewBlobName();
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = null,
                BlobName = blobName,
                Resource = "b"
            };

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, blobClient.AccountName)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongContainerName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobName = GetNewBlobName();
            string containerName = GetNewContainerName();
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri($"https://{constants.Sas.Account}.blob.core.windows.net"))
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = GetNewContainerName(), // set a different containerName
                BlobName = blobName,
                Resource = "b"
            };

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign),
                 new InvalidOperationException("SAS Uri cannot be generated. BlobSasBuilder.BlobContainerName does not match BlobContainerName in the Client. BlobSasBuilder.BlobContainerName must either be left empty or match the BlobContainerName in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullBlobName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobName = GetNewBlobName();
            string containerName = GetNewContainerName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = null,
                Resource = "b",
                StartsOn = startsOn
            };

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                StartsOn = startsOn
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, blobClient.AccountName)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongBlobName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri($"https://{constants.Sas.Account}.blob.core.windows.net"))
            {
                BlobContainerName = containerName,
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = GetNewBlobName(), // set a different blobName
                Resource = "b"
            };

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign),
                 new InvalidOperationException("SAS Uri cannot be generated. BlobSasBuilder.BlobName does not match Name in the Client. BlobSasBuilder.BlobName must either be left empty or match the Name in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullSnapshot()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobName = GetNewBlobName();
            string containerName = GetNewContainerName();
            string snapshot = "2020-07-03T12:45:46.1234567Z";
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = null,
                Resource = "b",
                StartsOn = startsOn
            };

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                StartsOn = startsOn
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, blobClient.AccountName)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongSnapshot()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string snapshot = "2020-07-03T12:45:46.1234567Z";
            string differentSnapshot = "2019-07-03T12:45:46.1234567Z";
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri($"https://{constants.Sas.Account}.blob.core.windows.net"))
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Resource = "bs",
                Snapshot = differentSnapshot
            };

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign),
                 new InvalidOperationException("SAS Uri cannot be generated. BlobSasBuilder.Snapshot does not match snapshot value in the URI in the Client. BlobSasBuilder.Snapshot must either be left empty or match the snapshot value in the URI in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullVersion()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobName = GetNewBlobName();
            string containerName = GetNewContainerName();
            string versionId = "2020-07-03T12:45:46.1234567Z";
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                VersionId = versionId
            };
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                BlobVersionId = null,
                Resource = "b",
                StartsOn = startsOn
            };

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder2 = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                BlobVersionId = versionId,
                StartsOn = startsOn
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(serviceUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                VersionId = versionId,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, blobClient.AccountName)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongVersion()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string blobVersionId = "2020-07-03T12:45:46.1234567Z";
            string diffBlobVersionId = "2019-07-03T12:45:46.1234567Z";
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            Uri blobEndpoint = new Uri($"https://{constants.Sas.Account}.blob.core.windows.net");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blobEndpoint)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                VersionId = blobVersionId
            };

            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                GetOptions()));

            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Resource = "bs",
                BlobVersionId = diffBlobVersionId,
            };

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions options = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: options);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign),
                 new InvalidOperationException("SAS Uri cannot be generated. BlobSasBuilder.BlobVersionId does not match snapshot value in the URI in the Client. BlobSasBuilder.BlobVersionId must either be left empty or match the snapshot value in the URI in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_TrimBlobSlashes()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient);
            string containerName = test.Container.Name;
            string blobName = $"/{GetNewBlobName()}";

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri, false)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            };

            // Set up options with TrimBlobNameSlashes set to false
            BlobClientOptions options = GetOptions();
            options.TrimBlobNameSlashes = false;
            BlobSasPermissions permissions = BlobSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AppendBlobClient createClient = InstrumentClient(new AppendBlobClient(
                blobUriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            await createClient.CreateAsync();

            string stringToSign = null;
            BlobGetUserDelegationKeyOptions getUserDelegationKeyOptions = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await serviceClient.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            BlobBaseClient blobClient = InstrumentClient(new BlobBaseClient(
                blobUriBuilder.ToUri(),
                options));

            Uri sasUri = blobClient.GenerateUserDelegationSasUri(permissions, expiresOn, userDelegationKey, out stringToSign);

            // Assert
            BlobSasBuilder sasBuilder = new BlobSasBuilder(permissions, expiresOn)
            {
                BlobContainerName = containerName,
                BlobName = blobName
            };
            BlobUriBuilder expectedUri = new BlobUriBuilder(test.Container.Uri, false)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Sas = sasBuilder.ToSasQueryParameters(userDelegationKey, blobClient.AccountName)
            };
            Assert.That(expectedUri.ToUri(), Is.EqualTo(sasUri));
            Assert.That(stringToSign, Is.Not.Null);

            BlobBaseClient sasClient = InstrumentClient(new BlobBaseClient(sasUri, options));
            Assert.That((bool)await sasClient.ExistsAsync(), Is.True);
        }
        #endregion

        [Test]
        [TestCase(null, false)]
        [TestCase("ContainerNotFound", true)]
        [TestCase("ContainerDisabled", false)]
        [TestCase("", false)]
        public void BlobErrorCode_EqualityOperatorOverloadTest(string errorCode, bool expected)
        {
            var ex = new RequestFailedException(status: 404, message: "Some error.", errorCode: errorCode, innerException: null);

            bool result1 = BlobErrorCode.ContainerNotFound == ex.ErrorCode;
            bool result2 = ex.ErrorCode == BlobErrorCode.ContainerNotFound;
            Assert.That(expected, Is.EqualTo(result1));
            Assert.That(expected, Is.EqualTo(result2));

            bool result3 = BlobErrorCode.ContainerNotFound != ex.ErrorCode;
            bool result4 = ex.ErrorCode != BlobErrorCode.ContainerNotFound;
            Assert.That(!expected, Is.EqualTo(result3));
            Assert.That(!expected, Is.EqualTo(result4));

            bool result5 = BlobErrorCode.ContainerNotFound.Equals(ex.ErrorCode);
            Assert.That(expected, Is.EqualTo(result5));
        }

        //[Test]
        //public async Task SetTierAsync_Batch()
        //{
        //    using (this.GetNewContainer(out var container, service: this.GetServiceClient_PreviewAccount_SharedKey()))
        //    {
        //        const int blobSize = Constants.KB;
        //        var data = this.GetRandomBuffer(blobSize);

        //        var blob1 = this.InstrumentClient(container.CreateBlockBlobClient(this.GetNewBlobName()));
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob1.UploadAsync(stream);
        //        }

        //        var blob2 = this.InstrumentClient(container.CreateBlockBlobClient(this.GetNewBlobName()));
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob2.UploadAsync(stream);
        //        }

        //        var batch =
        //            blob1.SetTierAsync(AccessTier.Cool)
        //            .And(blob2.SetTierAsync(AccessTier.Cool))
        //            ;

        //        var result = await batch;

        //        Assert.IsNotNull(result);
        //        Assert.AreEqual(2, result.Length);
        //        Assert.IsNotNull(result[0].RequestId);
        //        Assert.IsNotNull(result[1].RequestId);
        //    }
        //}

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
            BlobBaseClient blobBaseClient = new BlobBaseClient(uri);
            BlobBaseClient snapshotBlobBaseClient = blobBaseClient.WithSnapshot(snapshot);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(snapshotBlobBaseClient.Uri);

            // Assert
            Assert.That(accountName, Is.EqualTo(snapshotBlobBaseClient.AccountName));
            Assert.That(containerName, Is.EqualTo(snapshotBlobBaseClient.BlobContainerName));
            Assert.That(blobName, Is.EqualTo(snapshotBlobBaseClient.Name));
            Assert.That(snapshotUri, Is.EqualTo(snapshotBlobBaseClient.Uri));

            Assert.That(accountName, Is.EqualTo(blobUriBuilder.AccountName));
            Assert.That(containerName, Is.EqualTo(blobUriBuilder.BlobContainerName));
            Assert.That(blobName, Is.EqualTo(blobUriBuilder.BlobName));
            Assert.That(snapshot, Is.EqualTo(blobUriBuilder.Snapshot));
            Assert.That(snapshotUri, Is.EqualTo(blobUriBuilder.ToUri()));
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
            BlobBaseClient blobBaseClient = new BlobBaseClient(uri);
            BlobBaseClient versionBlobBaseClient = blobBaseClient.WithVersion(versionId);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(versionBlobBaseClient.Uri);

            // Assert
            Assert.That(accountName, Is.EqualTo(versionBlobBaseClient.AccountName));
            Assert.That(containerName, Is.EqualTo(versionBlobBaseClient.BlobContainerName));
            Assert.That(blobName, Is.EqualTo(versionBlobBaseClient.Name));
            Assert.That(versionUri, Is.EqualTo(versionBlobBaseClient.Uri));

            Assert.That(accountName, Is.EqualTo(blobUriBuilder.AccountName));
            Assert.That(containerName, Is.EqualTo(blobUriBuilder.BlobContainerName));
            Assert.That(blobName, Is.EqualTo(blobUriBuilder.BlobName));
            Assert.That(versionId, Is.EqualTo(blobUriBuilder.VersionId));
            Assert.That(versionUri, Is.EqualTo(blobUriBuilder.ToUri()));
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task WithCustomerProvidedKey()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(blobName).WithCustomerProvidedKey(customerProvidedKey));
            byte[] data = GetRandomBuffer(Constants.KB);
            Stream stream = new MemoryStream(data);
            await blockBlobClient.UploadAsync(stream);
            BlobBaseClient cpkBlobClient = InstrumentClient(test.Container.GetBlobBaseClient(blobName).WithCustomerProvidedKey(customerProvidedKey));

            // Act
            Response<BlobDownloadInfo> downloadResponse = await cpkBlobClient.DownloadAsync();

            // Assert
            Assert.That(customerProvidedKey.EncryptionKeyHash, Is.EqualTo(downloadResponse.Value.Details.EncryptionKeySha256));

            // Arrange
            BlobBaseClient noCpkBlobClient = InstrumentClient(cpkBlobClient.WithCustomerProvidedKey(null));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                noCpkBlobClient.DownloadAsync(),
                e => Assert.That(BlobErrorCode.BlobUsesCustomerSpecifiedEncryption.ToString(), Is.EqualTo(e.ErrorCode)));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task WithEncryptionScope()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string encryptionScope = TestConfigDefault.EncryptionScope;
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(blobName).WithEncryptionScope(encryptionScope));
            byte[] data = GetRandomBuffer(Constants.KB);
            Stream stream = new MemoryStream(data);
            await blockBlobClient.UploadAsync(stream);
            BlobBaseClient encryptionScopeBlob = InstrumentClient(test.Container.GetBlobBaseClient(blobName).WithEncryptionScope(encryptionScope));

            // Act
            Response<BlobDownloadInfo> downloadResponse = await encryptionScopeBlob.DownloadAsync();

            // Assert
            Assert.That(encryptionScope, Is.EqualTo(downloadResponse.Value.Details.EncryptionScope));

            // Arrange
            BlobBaseClient noEncryptionScopeBlobClient = InstrumentClient(encryptionScopeBlob.WithEncryptionScope(null));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                noEncryptionScopeBlobClient.SetMetadataAsync(BuildMetadata()),
                e => Assert.That(BlobErrorCode.BlobUsesCustomerSpecifiedEncryption.ToString(), Is.EqualTo(e.ErrorCode)));
        }

        [RecordedTest]
        public void CanMockBlobLeaseClientRetrieval()
        {
            // Arrange
            string leaseId = "leaseId";
            Mock<BlobBaseClient> blobBaseClientMock = new Mock<BlobBaseClient>();
            Mock<BlobLeaseClient> blobLeaseClientMock = new Mock<BlobLeaseClient>();
            blobBaseClientMock.Protected().Setup<BlobLeaseClient>("GetBlobLeaseClientCore", leaseId).Returns(blobLeaseClientMock.Object);

            // Act
            var blobLeaseClient = blobBaseClientMock.Object.GetBlobLeaseClient(leaseId);

            // Assert
            Assert.That(blobLeaseClient, Is.Not.Null);
            Assert.That(blobLeaseClient, Is.SameAs(blobLeaseClientMock.Object));
        }

        [RecordedTest]
        public async Task CanGetParentContainerClient()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blobClient = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));

            // Act
            var containerClient = blobClient.GetParentBlobContainerClient();
            // make sure that client is functional
            BlobContainerProperties containerProperties = await containerClient.GetPropertiesAsync();

            // Assert
            Assert.That(blobClient.BlobContainerName, Is.EqualTo(containerClient.Name));
            Assert.That(blobClient.AccountName, Is.EqualTo(containerClient.AccountName));
            Assert.That(containerProperties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task CanGetParentContainerClient_FromBlobClientThatHasExtraQueryParameters()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blobClient = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName())).WithVersion(Recording.Random.NewGuid().ToString());

            // Act
            var containerClient = blobClient.GetParentBlobContainerClient();
            // make sure that client is functional
            BlobContainerProperties containerProperties = await containerClient.GetPropertiesAsync();

            // Assert
            Assert.That(blobClient.BlobContainerName, Is.EqualTo(containerClient.Name));
            Assert.That(blobClient.AccountName, Is.EqualTo(containerClient.AccountName));
            Assert.That(containerProperties, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CanGetParentContainerClient_WithAccountSAS()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var blobName = GetNewBlobName();
            BlobBaseClient blobClient = InstrumentClient(
                GetServiceClient_AccountSas()
                .GetBlobContainerClient(test.Container.Name)
                .GetBlobClient(blobName));

            // Act
            var containerClient = blobClient.GetParentBlobContainerClient();
            // make sure that client is functional
            BlobContainerProperties containerProperties = await containerClient.GetPropertiesAsync();

            // Assert
            Assert.That(blobClient.BlobContainerName, Is.EqualTo(containerClient.Name));
            Assert.That(blobClient.AccountName, Is.EqualTo(containerClient.AccountName));
            Assert.That(containerProperties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task CanGetParentContainerClient_WithContainerSAS()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var blobName = GetNewBlobName();
            BlobBaseClient blobClient = InstrumentClient(
                GetServiceClient_BlobServiceSas_Container(test.Container.Name)
                .GetBlobContainerClient(test.Container.Name)
                .GetBlobClient(blobName));

            // Act
            var containerClient = blobClient.GetParentBlobContainerClient();
            // make sure that client is functional
            var blobItems = await containerClient.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.That(blobClient.BlobContainerName, Is.EqualTo(containerClient.Name));
            Assert.That(blobClient.AccountName, Is.EqualTo(containerClient.AccountName));
            Assert.That(blobItems, Is.Not.Null);
        }

        [RecordedTest]
        public void CanMockParentContainerClientRetrieval()
        {
            // Arrange
            Mock<BlobBaseClient> blobBaseClientMock = new Mock<BlobBaseClient>();
            Mock<BlobContainerClient> blobContainerClientMock = new Mock<BlobContainerClient>();
            blobBaseClientMock.Protected().Setup<BlobContainerClient>("GetParentBlobContainerClientCore").Returns(blobContainerClientMock.Object);

            // Act
            var blobContainerClient = blobBaseClientMock.Object.GetParentBlobContainerClient();

            // Assert
            Assert.That(blobContainerClient, Is.Not.Null);
            Assert.That(blobContainerClient, Is.SameAs(blobContainerClientMock.Object));
        }

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<BlobBaseClient>(TestConfigDefault.ConnectionString, "name", "name", new BlobClientOptions()).Object;
            mock = new Mock<BlobBaseClient>(TestConfigDefault.ConnectionString, "name", "name").Object;
            mock = new Mock<BlobBaseClient>(new Uri("https://test/test"), new BlobClientOptions()).Object;
            mock = new Mock<BlobBaseClient>(new Uri("https://test/test"), Tenants.GetNewSharedKeyCredentials(), new BlobClientOptions()).Object;
            mock = new Mock<BlobBaseClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new BlobClientOptions()).Object;
            mock = new Mock<BlobBaseClient>(new Uri("https://test/test"), TestEnvironment.Credential, new BlobClientOptions()).Object;
        }

        [RecordedTest]
        public async Task GetAccountInfoAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<AccountInfo> response = await blob.GetAccountInfoAsync();

            // Assert
            Assert.That(SkuName.StandardRagrs, Is.EqualTo(response.Value.SkuName));
            Assert.That(AccountKind.StorageV2, Is.EqualTo(response.Value.AccountKind));
            Assert.That(response.Value.IsHierarchicalNamespaceEnabled, Is.False);
        }

        [RecordedTest]
        public async Task GetAccountInfoAsync_Error()
        {
            // Arrange
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    BlobsClientBuilder.GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            BlobClient blobClient = service.GetBlobContainerClient(GetNewContainerName()).GetBlobClient(GetNewBlobName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blobClient.GetAccountInfoAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("NoAuthenticationInformation")));
        }

        public IEnumerable<AccessConditionParameters> AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId }
            };

        public IEnumerable<AccessConditionParameters> GetAccessConditionsFail_Data(string garbageLeaseId)
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
             };

        public IEnumerable<AccessConditionParameters> NoLease_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
            };

        public IEnumerable<AccessConditionParameters> NoLease_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
            };

        private RequestConditions BuildRequestConditions(
            AccessConditionParameters parameters)
            => BlobConditions.BuildRequestConditions(parameters);

        private BlobRequestConditions BuildAccessConditions(
            AccessConditionParameters parameters,
            bool lease = true)
            => BlobConditions.BuildAccessConditions(parameters, lease);
    }
}
