// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Sas;
using Azure.Storage.Shared;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests;
using Azure.Storage.Tests.Shared;
using Microsoft.CodeAnalysis.CSharp;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class PageBlobClientTests : BlobTestBase
    {
        private const string CacheControl = "control";
        private const string ContentDisposition = "disposition";
        private const string ContentEncoding = "encoding";
        private const string ContentLanguage = "language";
        private const string ContentType = "type";

        public PageBlobClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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

            PageBlobClient blob = InstrumentClient(new PageBlobClient(connectionString.ToString(true), containerName, blobName, GetOptions()));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.That(builder.BlobContainerName, Is.EqualTo(containerName));
            Assert.That(builder.BlobName, Is.EqualTo(blobName));
            Assert.That(builder.AccountName, Is.EqualTo("accountName"));
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
            PageBlobClient pageBlobClient = new PageBlobClient(uri);

            // Assert
            BlobUriBuilder builder = new BlobUriBuilder(pageBlobClient.Uri);

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
                () => new PageBlobClient(httpUri, TestEnvironment.Credential),
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
                () => new PageBlobClient(httpUri, blobClientOptions),
                new ArgumentException("Cannot use client-provided key without HTTPS."));
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            var client = test.Container.GetPageBlobClient(GetNewBlobName());
            await client.CreateAsync(1024);
            Uri blobUri = client.Uri;

            // Act
            var sasClient = InstrumentClient(new PageBlobClient(blobUri, new AzureSasCredential(sas), GetOptions()));
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
            Uri blobUri = test.Container.GetPageBlobClient("foo").Uri;
            blobUri = new Uri(blobUri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new PageBlobClient(blobUri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync(Constants.KB);

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.DefaultAudience);

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            PageBlobClient aadBlob = InstrumentClient(new PageBlobClient(
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

            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync(Constants.KB);

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(new BlobAudience($"https://{test.Container.AccountName}.blob.core.windows.net/"));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            PageBlobClient aadBlob = InstrumentClient(new PageBlobClient(
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

            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync(Constants.KB);

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(BlobAudience.CreateBlobServiceAccountAudience(test.Container.AccountName));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            PageBlobClient aadBlob = InstrumentClient(new PageBlobClient(
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

            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync(Constants.KB);

            // Act - Create new blob client with the OAuth Credential and Audience
            BlobClientOptions options = GetOptionsWithAudience(new BlobAudience("https://badaudience.blob.core.windows.net"));

            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };

            PageBlobClient aadBlob = InstrumentClient(new PageBlobClient(
                uriBuilder.ToUri(),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadBlob.ExistsAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.InvalidAuthenticationInfo.ToString())));
        }

        [RecordedTest]
        public async Task CreateAsync_Min()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync(Constants.KB);

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThan))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberEqual))]
        public async Task CreateAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            PageBlobClient pageBlobClient = new PageBlobClient(uri, GetOptions());

            PageBlobRequestConditions conditions = new PageBlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual):
                    conditions.IfSequenceNumberLessThanOrEqual = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThan):
                    conditions.IfSequenceNumberLessThan = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberEqual):
                    conditions.IfSequenceNumberEqual = 0;
                    break;
            }

            PageBlobCreateOptions options = new PageBlobCreateOptions
            {
                Conditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlobClient.CreateAsync(
                    size: 0,
                    options),
                e =>
                {
                    Assert.That(e.Message.Contains($"Create does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_Tags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            PageBlobCreateOptions options = new PageBlobCreateOptions
            {
                Tags = BuildTags()
            };

            // Act
            await blob.CreateAsync(Constants.KB, options);
            Response<GetBlobTagResult> response = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(options.Tags, response.Value.Tags);
        }

        [RecordedTest]
        public async Task CreateAsync_SequenceNumber()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            await blob.CreateAsync(
                size: Constants.KB,
                sequenceNumber: 2);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.That(response.Value.BlobSequenceNumber, Is.EqualTo(2));
        }

        [RecordedTest]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            await blob.CreateAsync(Constants.KB, metadata: metadata);

            // Assert
            Response<BlobProperties> getPropertiesResponse = await blob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, getPropertiesResponse.Value.Metadata);
            Assert.That(getPropertiesResponse.Value.BlobType, Is.EqualTo(BlobType.Page));
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task CreateAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync(Constants.KB);

            // Assert
            Assert.That(response.Value.EncryptionKeySha256, Is.EqualTo(customerProvidedKey.EncryptionKeyHash));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CreateAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync(Constants.KB);

            // Assert
            Assert.That(response.Value.EncryptionScope, Is.EqualTo(TestConfigDefault.EncryptionScope));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync(Constants.KB);

            // Assert
            Assert.That(response.Value.VersionId, Is.Not.Null);
        }

        /// <summary>
        /// Data for CreateAsync, GetPageRangesAsync, GetPageRangesDiffAsync, ResizeAsync, and
        /// UpdateSequenceNumber AccessConditions tests.
        /// </summary>
        public IEnumerable<AccessConditionParameters> Reduced_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId }
            };

        [RecordedTest]
        public async Task CreateAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Reduced_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                // This PageBlob is intentionally created twice to test the PageBlobAccessConditions
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobContentInfo> response = await blob.CreateAsync(
                    size: Constants.KB,
                    conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task CreateAsync_PremiumPageBlobAccessTier()
        {
            BlobServiceClient premiumService = BlobsClientBuilder.GetServiceClient_PremiumBlobAccount_SharedKey();
            await using DisposingContainer test = await GetTestContainerAsync(service: premiumService, premium: true);

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

            PremiumPageBlobAccessTier accessTier = PremiumPageBlobAccessTier.P60;
            PageBlobCreateOptions optionsAccessTier = new()
            {
                PremiumPageBlobAccessTier = accessTier
            };

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync(
                size: Constants.KB,
                options: optionsAccessTier);

            // Assert
            BlobProperties properties = await blob.GetPropertiesAsync();
            Assert.That(properties.AccessTier, Is.EqualTo(accessTier.ToString()));
        }

        /// <summary>
        /// Data for CreateAsync, GetPageRangesAsync, and GetPageRangesDiffAsync AccessConditions Fail tests.
        /// </summary>
        public IEnumerable<AccessConditionParameters> GetReduced_AccessConditionsFail_Data(string garbageLeaseId)
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };

        [RecordedTest]
        public async Task CreateAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                // This PageBlob is intentionally created twice to test the PageBlobAccessConditions
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.CreateAsync(
                        size: Constants.KB,
                        conditions: accessConditions),
                    actualException => Assert.That(true, Is.True));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_IfTag()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(Constants.KB);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await blob.CreateAsync(
                Constants.KB,
                conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_IfTagFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(Constants.KB);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateAsync(
                    Constants.KB,
                    conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task CreateAsync_Headers()
        {
            var contentMD5 = MD5.Create().ComputeHash(GetRandomBuffer(16));
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var headers = new BlobHttpHeaders
            {
                ContentType = ContentType,
                ContentHash = contentMD5,
                ContentEncoding = ContentEncoding,
                ContentLanguage = ContentLanguage,
                ContentDisposition = ContentDisposition,
                CacheControl = CacheControl
            };
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            await blob.CreateAsync(
                size: Constants.KB,
                httpHeaders: headers);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.That(response.Value.ContentType, Is.EqualTo(ContentType));
            TestHelper.AssertSequenceEqual(contentMD5, response.Value.ContentHash);
            Assert.That(response.Value.ContentEncoding, Is.EqualTo(ContentEncoding));
            Assert.That(response.Value.ContentLanguage, Is.EqualTo(ContentLanguage));
            Assert.That(response.Value.ContentDisposition, Is.EqualTo(ContentDisposition));
            Assert.That(response.Value.CacheControl, Is.EqualTo(CacheControl));
        }

        [RecordedTest]
        public async Task CreateAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var invalidPageSize = 511;
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateAsync(invalidPageSize),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("InvalidHeaderValue"));
                    Assert.That(e.Message.Split('\n')[0],
                        Is.EqualTo("The value for one of the HTTP headers is not in the correct format."));
                });
        }

        [RecordedTest]
        public async Task UploadPagesAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            var data = GetRandomBuffer(Constants.KB);

            Response<PageInfo> response;
            using (var stream = new MemoryStream(data))
            {
                // Act
                response = await blob.UploadPagesAsync(
                    content: stream,
                    offset: Constants.KB);
            }

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));

            // Ensure we uploaded the pages correctly by downloading and checking the content against the upload content
            var expectedData = new byte[4 * Constants.KB];
            data.CopyTo(expectedData, Constants.KB);
            Response<BlobDownloadInfo> downloadRepsonse = await blob.DownloadAsync(range: new HttpRange(0, 4 * Constants.KB));

            var actualData = new byte[4 * Constants.KB];
            using var actualStream = new MemoryStream(actualData);
            await downloadRepsonse.Value.Content.CopyToAsync(actualStream);
            TestHelper.AssertSequenceEqual(expectedData, actualData);
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task UploadPagesAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(blobName));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            var data = GetRandomBuffer(Constants.KB);
            await blob.CreateIfNotExistsAsync(Constants.KB);

            using var stream = new MemoryStream(data);

            // Act
            Response<PageInfo> response = await blob.UploadPagesAsync(
                content: stream,
                offset: 0);

            // Assert
            Assert.That(response.Value.EncryptionKeySha256, Is.EqualTo(customerProvidedKey.EncryptionKeyHash));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadPagesAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(blobName));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            var data = GetRandomBuffer(Constants.KB);
            await blob.CreateIfNotExistsAsync(Constants.KB);

            using var stream = new MemoryStream(data);

            // Act
            Response<PageInfo> response = await blob.UploadPagesAsync(
                content: stream,
                offset: 0);

            // Assert
            Assert.That(response.Value.EncryptionScope, Is.EqualTo(TestConfigDefault.EncryptionScope));
        }

        [RecordedTest]
        public async Task UploadPagesAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Act
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.UploadPagesAsync(stream, 5 * Constants.KB),
                    e => Assert.That(e.ErrorCode, Is.EqualTo("InvalidPageRange")));
            }
        }

        [RecordedTest]
        public async Task UploadPagesAsync_NullStream_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            using (var stream = (MemoryStream)null)
            {
                // Check if the correct param name that is causing the error is being returned
                await TestHelper.AssertExpectedExceptionAsync<ArgumentNullException>(
                    blob.UploadPagesAsync(
                        content: stream,
                        offset: 0),
                    e => Assert.That(e.ParamName, Is.EqualTo("body")));
            }
        }

        public IEnumerable<AccessConditionParameters> UploadClearAsync_AccessConditions_Data(bool noSequenceNumberConditions)
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId },
                new AccessConditionParameters { SequenceNumberLT = noSequenceNumberConditions ? null : 5 },
                new AccessConditionParameters { SequenceNumberLTE = noSequenceNumberConditions? null : 3 },
                new AccessConditionParameters { SequenceNumberEqual = noSequenceNumberConditions ? null : 0 }
           };

        [RecordedTest]
        public async Task UploadAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in UploadClearAsync_AccessConditions_Data(noSequenceNumberConditions: false))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true,
                    sequenceNumbers: true);

                var data = GetRandomBuffer(Constants.KB);
                using (var stream = new MemoryStream(data))
                {
                    // Act
                    Response<PageInfo> response = await blob.UploadPagesAsync(
                        content: stream,
                        offset: 0,
                        options: new PageBlobUploadPagesOptions
                        {
                            Conditions = accessConditions
                        });

                    // Assert
                    Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
                }
            }
        }

        public IEnumerable<AccessConditionParameters> GetUploadClearAsync_AccessConditionsFail_Data(string garbageLeaseId)
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { SequenceNumberLT = -1 },
                new AccessConditionParameters { SequenceNumberLTE = -1 },
                new AccessConditionParameters { SequenceNumberEqual = 100 }
            };

        [RecordedTest]
        public async Task UploadAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetUploadClearAsync_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true,
                    sequenceNumbers: true);

                var data = GetRandomBuffer(Constants.KB);
                using (var stream = new MemoryStream(data))
                {
                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        blob.UploadPagesAsync(
                            content: stream,
                            offset: 0,
                            options: new PageBlobUploadPagesOptions
                            {
                                Conditions = accessConditions
                            }),
                        e => Assert.That(true, Is.True));
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadPagesAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            var data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await blob.UploadPagesAsync(
                content: stream,
                offset: Constants.KB,
                options: new PageBlobUploadPagesOptions
                {
                    Conditions = conditions
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadPagesAsync_IfTagsFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            var data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.UploadPagesAsync(
                    content: stream,
                    offset: Constants.KB,
                    options: new PageBlobUploadPagesOptions
                    {
                        Conditions = conditions
                    }),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task UploadPagesAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;
            await using DisposingContainer test = await GetTestContainerAsync();

            var credentials = new StorageSharedKeyCredential(
                TestConfigDefault.AccountName,
                TestConfigDefault.AccountKey);
            BlobContainerClient containerClientFaulty = InstrumentClient(
                new BlobContainerClient(
                    test.Container.Uri,
                    credentials,
                    GetFaultyBlobConnectionOptions()));

            // Arrange
            var pageBlobName = GetNewBlobName();
            PageBlobClient blobFaulty = InstrumentClient(containerClientFaulty.GetPageBlobClient(pageBlobName));
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(pageBlobName));

            await blob.CreateIfNotExistsAsync(blobSize)
                .ConfigureAwait(false);

            var offset = 0 * Constants.KB;
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
                await blobFaulty.UploadPagesAsync(stream, offset, new PageBlobUploadPagesOptions
                {
                    ProgressHandler = progressHandler
                });

                await WaitForProgressAsync(progressBag, data.LongLength);
                Assert.That(progressBag.Count > 1, Is.True, "Too few progress received");
                // Changing from Assert.AreEqual because these don't always update fast enough
                Assert.That(data.LongLength, Is.GreaterThanOrEqualTo(progressBag.Max()), "Final progress has unexpected value");
            }

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync(
                new HttpRange(offset, data.LongLength));
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.That(timesFaulted, Is.Not.EqualTo(0));
        }

        [LiveOnly]
        [Test]
        public async Task UploadPagesAsync_ProgressReporting()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            long blobSize = 4 * Constants.MB;
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, blobSize);
            var data = GetRandomBuffer(blobSize);
            TestProgress progress = new TestProgress();

            using (var stream = new MemoryStream(data))
            {
                // Act
                await blob.UploadPagesAsync(
                    content: stream,
                    offset: 0,
                    new PageBlobUploadPagesOptions
                    {
                        ProgressHandler = progress
                    });
            }

            // Assert
            Assert.That(progress.List.Count == 0, Is.False);

            Assert.That(progress.List[progress.List.Count - 1], Is.EqualTo(blobSize));
        }

        [RecordedTest]
        public async Task UploadPagesAsync_InvalidStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            long size = Constants.KB;
            byte[] data = GetRandomBuffer(size);

            using Stream stream = new MemoryStream(data)
            {
                Position = size
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.UploadPagesAsync(
                    content: stream,
                    offset: 0),
                e => Assert.That(e.Message, Is.EqualTo("content.Position must be less than content.Length. Please set content.Position to the start of the data to upload.")));
        }

        [RecordedTest]
        public async Task UploadPagesAsync_NonZeroStreamPosition()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            long size = Constants.KB;
            long position = 512;
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, size - position);
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);

            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };

            // Act
            await blob.UploadPagesAsync(
                content: stream,
                offset: 0);

            // Assert
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            var actualData = new byte[512];
            using var actualStream = new MemoryStream(actualData);
            await response.Value.Content.CopyToAsync(actualStream);
            TestHelper.AssertSequenceEqual(expectedData, actualData);
        }

        [RecordedTest]
        public async Task ClearPagesAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            var data = GetRandomBuffer(4 * Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);
            }

            // Act
            Response<PageInfo> response = await blob.ClearPagesAsync(range: new HttpRange(Constants.KB, Constants.KB));

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));

            // Ensure the correct pages are cleared by downloading the blob
            var expectedData = new byte[4 * Constants.KB];
            Array.Copy(data, expectedData, 4 * Constants.KB);
            Array.Clear(expectedData, Constants.KB, Constants.KB);
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(expectedData, actual.ToArray());
        }

        [Ignore("Backend bug")]
        [RecordedTest]
        public async Task ClearPagesAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateIfNotExistsAsync(4 * Constants.KB);
            var data = GetRandomBuffer(4 * Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);
            }

            // Act
            Response<PageInfo> response = await blob.ClearPagesAsync(
                range: new HttpRange(Constants.KB, Constants.KB));

            // Assert
            Assert.That(response.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ClearPagesAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateIfNotExistsAsync(4 * Constants.KB);
            var data = GetRandomBuffer(4 * Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);
            }

            // Act
            Response<PageInfo> response = await blob.ClearPagesAsync(
                range: new HttpRange(Constants.KB, Constants.KB));
        }

        [RecordedTest]
        public async Task ClearPagesAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.ClearPagesAsync(range: new HttpRange(5 * Constants.KB, Constants.KB)),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("InvalidPageRange"));
                    Assert.That(e.Message.Split('\n')[0], Is.EqualTo("The page range specified is invalid."));
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ClearPagesAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            Response<PageInfo> response = await blob.ClearPagesAsync(
                range: new HttpRange(0, Constants.KB),
                conditions: conditions);

            // Assert
            Assert.That(response.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ClearPagesAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.ClearPagesAsync(
                    range: new HttpRange(0, Constants.KB),
                    conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.ConditionNotMet.ToString())));
        }

        [RecordedTest]
        public async Task ClearPagesAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in UploadClearAsync_AccessConditions_Data(noSequenceNumberConditions: false))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true,
                    sequenceNumbers: true);

                Response<PageInfo> response = await blob.ClearPagesAsync(
                    range: new HttpRange(0, Constants.KB),
                    conditions: accessConditions);

                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task ClearAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetUploadClearAsync_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true,
                    sequenceNumbers: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.ClearPagesAsync(
                        range: new HttpRange(0, Constants.KB),
                        conditions: accessConditions),
                    e => Assert.That(true, Is.True));
            }
        }

        [RecordedTest]
        public async Task GetPageRangesAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobWithRangesAsync(test.Container);

            // Act
            Response<PageRangesInfo> result = await blob.GetPageRangesAsync(
                range: new HttpRange(0, 4 * Constants.KB),
                snapshot: null,
                conditions: null,
                cancellationToken: CancellationToken.None);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{result.GetRawResponse().Headers.ETag.ToString()}\"", Is.EqualTo(result.Value.ETag.ToString()));

            Assert.That(result.Value.PageRanges.Count(), Is.EqualTo(2));
            HttpRange range1 = result.Value.PageRanges.First();
            Assert.That(range1.Offset, Is.EqualTo(0));
            Assert.That(range1.Offset + range1.Length, Is.EqualTo(Constants.KB));

            HttpRange range2 = result.Value.PageRanges.ElementAt(1);
            Assert.That(range2.Offset, Is.EqualTo(2 * Constants.KB));
            Assert.That(range2.Offset + range2.Length, Is.EqualTo(3 * Constants.KB));
        }

        [RecordedTest]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThan))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberEqual))]
        public async Task GetPageRangesAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            PageBlobClient pageBlobClient = new PageBlobClient(uri, GetOptions());

            PageBlobRequestConditions conditions = new PageBlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual):
                    conditions.IfSequenceNumberLessThanOrEqual = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThan):
                    conditions.IfSequenceNumberLessThan = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberEqual):
                    conditions.IfSequenceNumberEqual = 0;
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlobClient.GetPageRangesAsync(
                    range: null,
                    snapshot: null,
                    conditions: conditions,
                    cancellationToken: CancellationToken.None),
                e =>
                {
                    Assert.That(e.Message.Contains($"GetPageRanges does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task GetPageRangesAsync_Clear()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 6 * Constants.KB);
            var data = GetRandomBuffer(2 * Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);
            }
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 4 * Constants.KB);
            }

            Response<BlobSnapshotInfo> snapshot = await blob.CreateSnapshotAsync();

            using (var stream = new MemoryStream(data))
            {
                await blob.ClearPagesAsync(new HttpRange(4 * Constants.KB, Constants.KB));
            }

            // Act
            Response<PageRangesInfo> result = await blob.GetPageRangesAsync(
                range: new HttpRange(0, 6 * Constants.KB),
                snapshot: null,
                conditions: null,
                cancellationToken: CancellationToken.None);

            Response<PageRangesInfo> diff = await blob.GetPageRangesDiffAsync(
                range: new HttpRange(0, 6 * Constants.KB),
                snapshot: null,
                previousSnapshot: snapshot.Value.Snapshot,
                conditions: null,
                cancellationToken: CancellationToken.None);

            // Assert
            Assert.That(result.Value.PageRanges.Count(), Is.EqualTo(2));
            HttpRange pageRange1 = result.Value.PageRanges.First();
            Assert.That(pageRange1.Offset, Is.EqualTo(0));
            Assert.That(pageRange1.Offset + pageRange1.Length, Is.EqualTo(2 * Constants.KB));

            HttpRange pageRange2 = result.Value.PageRanges.ElementAt(1);
            Assert.That(pageRange2.Offset, Is.EqualTo(5 * Constants.KB)); // since the first part of the page was cleared, it should start at 5 rather than 4 KB
            Assert.That(pageRange2.Offset + pageRange2.Length, Is.EqualTo(6 * Constants.KB));

            Assert.That(diff.Value.ClearRanges.Count(), Is.EqualTo(1));
            HttpRange clearRange = diff.Value.ClearRanges.First(); // ClearRange is only populated by GetPageRangesDiff API, and only if passing previous snapshot parameter
            Assert.That(clearRange.Offset, Is.EqualTo(4 * Constants.KB));
        }

        [RecordedTest]
        public async Task GetPageRangesAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPageRangesAsync(
                    range: new HttpRange(5 * Constants.KB, 4 * Constants.KB),
                    snapshot: null,
                    conditions: null,
                    cancellationToken: CancellationToken.None),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("InvalidRange"));
                    Assert.That(e.Message.Split('\n')[0],
                        Is.EqualTo("The range specified is invalid for the current size of the resource."));
                });
        }

        [RecordedTest]
        public async Task GetPageRangesAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Reduced_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PageRangesInfo> response = await blob.GetPageRangesAsync(
                    range: new HttpRange(0, Constants.KB),
                    snapshot: null,
                    conditions: accessConditions,
                    cancellationToken: CancellationToken.None);

                // Assert
                Assert.That(response.Value.PageRanges, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task GetPageRangesAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await blob.GetPageRangesAsync(
                            range: new HttpRange(0, Constants.KB),
                            snapshot: null,
                            conditions: accessConditions,
                            cancellationToken: CancellationToken.None)).Value;
                    });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPageRangesAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = await CreatePageBlobWithRangesAsync(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await blob.GetPageRangesAsync(
                range: new HttpRange(0, 4 * Constants.KB),
                snapshot: null,
                conditions: conditions,
                cancellationToken: CancellationToken.None);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPageRangesAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPageRangesAsync(
                    range: new HttpRange(0, 4 * Constants.KB),
                    snapshot: null,
                    conditions: conditions,
                    cancellationToken: CancellationToken.None),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesPageableAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient pageBlob = await CreatePageBlobWithRangesAsync(test.Container);

            // Act
            List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();
            await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesAsync())
            {
                pageBlobRanges.Add(pageBlobRange);
            }

            // Assert
            Assert.That(pageBlobRanges.Count, Is.EqualTo(2));

            Assert.That(pageBlobRanges[0].IsClear, Is.False);
            Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
            Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[1].IsClear, Is.False);
            Assert.That(pageBlobRanges[1].Range.Offset, Is.EqualTo(2048));
            Assert.That(pageBlobRanges[1].Range.Length, Is.EqualTo(1024));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThan))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberEqual))]
        public async Task GetPageRangesPageableAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            PageBlobClient pageBlobClient = new PageBlobClient(uri, GetOptions());

            PageBlobRequestConditions conditions = new PageBlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual):
                    conditions.IfSequenceNumberLessThanOrEqual = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThan):
                    conditions.IfSequenceNumberLessThan = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberEqual):
                    conditions.IfSequenceNumberEqual = 0;
                    break;
            }

            GetPageRangesOptions options = new GetPageRangesOptions
            {
                Conditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlobClient.GetAllPageRangesAsync(options).ToListAsync(),
                e =>
                {
                    Assert.That(e.Message.Contains($"GetPageRanges does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesPageableAsync_ByPage()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient pageBlob = await CreatePageBlobWithRangesAsync(test.Container);

            // Act
            List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();
            await foreach (Page<PageRangeItem> page in pageBlob.GetAllPageRangesAsync().AsPages(pageSizeHint: 1))
            {
                pageBlobRanges.AddRange(page.Values);
            }

            // Assert
            Assert.That(pageBlobRanges.Count, Is.EqualTo(2));

            Assert.That(pageBlobRanges[0].IsClear, Is.False);
            Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
            Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[1].IsClear, Is.False);
            Assert.That(pageBlobRanges[1].Range.Offset, Is.EqualTo(2048));
            Assert.That(pageBlobRanges[1].Range.Length, Is.EqualTo(1024));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesPageableAsync_Range()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient pageBlob = await CreatePageBlobWithRangesAsync(test.Container);
            GetPageRangesOptions options = new GetPageRangesOptions
            {
                Range = new HttpRange(0, 2 * Constants.KB)
            };

            // Act
            List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();
            await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesAsync(options))
            {
                pageBlobRanges.Add(pageBlobRange);
            }

            // Assert
            Assert.That(pageBlobRanges.Count, Is.EqualTo(1));

            Assert.That(pageBlobRanges[0].IsClear, Is.False);
            Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
            Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesPageableAsync_Snapshot()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient pageBlob = await CreatePageBlobWithRangesAsync(test.Container);
            Response<BlobSnapshotInfo> snapshotResponse = await pageBlob.CreateSnapshotAsync();
            GetPageRangesOptions options = new GetPageRangesOptions
            {
                Snapshot = snapshotResponse.Value.Snapshot
            };

            // Act
            List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();
            await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesAsync(options))
            {
                pageBlobRanges.Add(pageBlobRange);
            }

            // Assert
            Assert.That(pageBlobRanges.Count, Is.EqualTo(2));

            Assert.That(pageBlobRanges[0].IsClear, Is.False);
            Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
            Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[1].IsClear, Is.False);
            Assert.That(pageBlobRanges[1].Range.Offset, Is.EqualTo(2048));
            Assert.That(pageBlobRanges[1].Range.Length, Is.EqualTo(1024));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesPageableAsync_AccessConditions()
        {
            // Arrange
            string garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Reduced_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                PageBlobClient pageBlob = await CreatePageBlobWithRangesAsync(test.Container);

                // Act
                List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();

                parameters.Match = await SetupBlobMatchCondition(pageBlob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(pageBlob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                GetPageRangesOptions options = new GetPageRangesOptions
                {
                    Conditions = accessConditions,
                };

                await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesAsync(options))
                {
                    pageBlobRanges.Add(pageBlobRange);
                }

                // Assert
                Assert.That(pageBlobRanges.Count, Is.EqualTo(2));

                Assert.That(pageBlobRanges[0].IsClear, Is.False);
                Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
                Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));

                Assert.That(pageBlobRanges[1].IsClear, Is.False);
                Assert.That(pageBlobRanges[1].Range.Offset, Is.EqualTo(2048));
                Assert.That(pageBlobRanges[1].Range.Length, Is.EqualTo(1024));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesPageableAsync_AccessConditionsFail()
        {
            // Arrange
            string garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                PageBlobClient pageBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

                parameters.NoneMatch = await SetupBlobMatchCondition(pageBlob, parameters.NoneMatch);
                await SetupBlobLeaseCondition(pageBlob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                GetPageRangesOptions options = new GetPageRangesOptions
                {
                    Conditions = accessConditions,
                };

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesAsync(options))
                        {
                        }
                    });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesPageableAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient pageBlob = await CreatePageBlobWithRangesAsync(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await pageBlob.SetTagsAsync(tags);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();
            GetPageRangesOptions options = new GetPageRangesOptions
            {
                Conditions = conditions,
            };
            await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesAsync(options))
            {
                pageBlobRanges.Add(pageBlobRange);
            }

            // Assert
            Assert.That(pageBlobRanges.Count, Is.EqualTo(2));

            Assert.That(pageBlobRanges[0].IsClear, Is.False);
            Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
            Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[1].IsClear, Is.False);
            Assert.That(pageBlobRanges[1].Range.Offset, Is.EqualTo(2048));
            Assert.That(pageBlobRanges[1].Range.Length, Is.EqualTo(1024));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesPageableAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient pageBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            GetPageRangesOptions options = new GetPageRangesOptions
            {
                Range = new HttpRange(0, 4 * Constants.KB),
                Conditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                pageBlob.GetAllPageRangesAsync(options).ToListAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesPageableAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient pageBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            GetPageRangesOptions options = new GetPageRangesOptions
            {
                Range = new HttpRange(5 * Constants.KB, 4 * Constants.KB)
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
               pageBlob.GetAllPageRangesAsync(options).ToListAsync(),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("InvalidRange"));
                    Assert.That(e.Message.Split('\n')[0],
                        Is.EqualTo("The range specified is invalid for the current size of the resource."));
                });
        }

        [RecordedTest]
        public async Task GetPageRangesDiffAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Upload some Pages
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);
            }

            // Create prevSnapshot
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();
            var prevSnapshot = response.Value.Snapshot;

            // Upload additional Pages
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 2 * Constants.KB);
            }

            // create snapshot
            response = await blob.CreateSnapshotAsync();
            var snapshot = response.Value.Snapshot;

            // Act
            Response<PageRangesInfo> result = await blob.GetPageRangesDiffAsync(
                range: new HttpRange(0, 4 * Constants.KB),
                snapshot,
                prevSnapshot,
                conditions: null,
                cancellationToken: CancellationToken.None);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{result.GetRawResponse().Headers.ETag.ToString()}\"", Is.EqualTo(result.Value.ETag.ToString()));

            Assert.That(result.Value.PageRanges.Count(), Is.EqualTo(1));
            HttpRange range = result.Value.PageRanges.First();

            Assert.That(range.Offset, Is.EqualTo(2 * Constants.KB));
            Assert.That(range.Offset + range.Length, Is.EqualTo(3 * Constants.KB));
        }

        [RecordedTest]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThan))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberEqual))]
        public async Task GetPageRangesDiffAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            PageBlobClient pageBlobClient = new PageBlobClient(uri, GetOptions());

            PageBlobRequestConditions conditions = new PageBlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual):
                    conditions.IfSequenceNumberLessThanOrEqual = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThan):
                    conditions.IfSequenceNumberLessThan = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberEqual):
                    conditions.IfSequenceNumberEqual = 0;
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlobClient.GetPageRangesDiffAsync(
                    range: null,
                    snapshot: null,
                    previousSnapshot: null,
                    conditions: conditions,
                    cancellationToken: CancellationToken.None),
                e =>
                {
                    Assert.That(e.Message.Contains($"GetPageRangesDiff does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task GetPageRangesDiffAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPageRangesDiffAsync(
                    range: new HttpRange(5 * Constants.KB, 4 * Constants.KB),
                    snapshot: null,
                    previousSnapshot: null,
                    conditions: null,
                    cancellationToken: CancellationToken.None),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("InvalidRange"));
                    Assert.That(e.Message.Split('\n')[0],
                        Is.EqualTo("The range specified is invalid for the current size of the resource."));
                });
        }

        [RecordedTest]
        public async Task GetPageRangesDiffAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Reduced_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

                // Upload some Pages
                var data = GetRandomBuffer(Constants.KB);
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadPagesAsync(stream, 0);
                }

                // Create prevSnapshot
                Response<BlobSnapshotInfo> snapshotCreateResult = await blob.CreateSnapshotAsync();
                var prevSnapshot = snapshotCreateResult.Value.Snapshot;

                // Upload additional Pages
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadPagesAsync(stream, 2 * Constants.KB);
                }

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PageRangesInfo> response = await blob.GetPageRangesDiffAsync(
                    range: new HttpRange(0, Constants.KB),
                    snapshot: null,
                    previousSnapshot: prevSnapshot,
                    conditions: accessConditions,
                    cancellationToken: CancellationToken.None);

                // Assert
                Assert.That(response.Value.PageRanges, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task GetPageRangesDiffAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

                // Upload some Pages
                var data = GetRandomBuffer(Constants.KB);
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadPagesAsync(stream, 0);
                }

                // Create prevSnapshot
                Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();
                var prevSnapshot = response.Value.Snapshot;

                // Upload additional Pages
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadPagesAsync(stream, 2 * Constants.KB);
                }

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await blob.GetPageRangesDiffAsync(
                            range: new HttpRange(0, Constants.KB),
                            snapshot: null,
                            previousSnapshot: prevSnapshot,
                            conditions: accessConditions,
                            cancellationToken: CancellationToken.None)).Value;
                    });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPageRangesDiffAsyncIfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Upload some Pages
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);
            }

            // Create prevSnapshot
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();
            var prevSnapshot = response.Value.Snapshot;

            // Upload additional Pages
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 2 * Constants.KB);
            }

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            // create snapshot
            response = await blob.CreateSnapshotAsync();
            var snapshot = response.Value.Snapshot;

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await blob.GetPageRangesDiffAsync(
                range: new HttpRange(0, 4 * Constants.KB),
                snapshot,
                prevSnapshot,
                conditions: conditions,
                cancellationToken: CancellationToken.None);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPageRangesDiffAsyncIfTags_Failed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Upload some Pages
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);
            }

            // Create prevSnapshot
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();
            var prevSnapshot = response.Value.Snapshot;

            // Upload additional Pages
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 2 * Constants.KB);
            }

            // create snapshot
            response = await blob.CreateSnapshotAsync();
            var snapshot = response.Value.Snapshot;

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPageRangesDiffAsync(
                    range: new HttpRange(0, 4 * Constants.KB),
                    snapshot,
                    prevSnapshot,
                    conditions: conditions,
                    cancellationToken: CancellationToken.None),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesDiffPageableAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            Tuple<PageBlobClient, string, string> setup = await CreatePageBlobForPageRangeDiff(test.Container);
            PageBlobClient pageBlob = setup.Item1;
            string prevSnapshot = setup.Item2;
            string snapshot = setup.Item3;

            GetPageRangesDiffOptions options = new GetPageRangesDiffOptions
            {
                PreviousSnapshot = prevSnapshot,
                Snapshot = snapshot
            };

            // Act
            List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();
            await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesDiffAsync(options))
            {
                pageBlobRanges.Add(pageBlobRange);
            }

            // Assert
            Assert.That(pageBlobRanges.Count, Is.EqualTo(4));

            Assert.That(pageBlobRanges[0].IsClear, Is.False);
            Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
            Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[1].IsClear, Is.True);
            Assert.That(pageBlobRanges[1].Range.Offset, Is.EqualTo(1024));
            Assert.That(pageBlobRanges[1].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[2].IsClear, Is.False);
            Assert.That(pageBlobRanges[2].Range.Offset, Is.EqualTo(2048));
            Assert.That(pageBlobRanges[2].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[3].IsClear, Is.True);
            Assert.That(pageBlobRanges[3].Range.Offset, Is.EqualTo(3072));
            Assert.That(pageBlobRanges[3].Range.Length, Is.EqualTo(1024));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThan))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberEqual))]
        public async Task GetPageRangesDiffPageableAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            PageBlobClient pageBlobClient = new PageBlobClient(uri, GetOptions());

            PageBlobRequestConditions conditions = new PageBlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual):
                    conditions.IfSequenceNumberLessThanOrEqual = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThan):
                    conditions.IfSequenceNumberLessThan = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberEqual):
                    conditions.IfSequenceNumberEqual = 0;
                    break;
            }

            GetPageRangesDiffOptions options = new GetPageRangesDiffOptions
            {
                Conditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlobClient.GetAllPageRangesDiffAsync(options).ToListAsync(),
                e =>
                {
                    Assert.That(e.Message.Contains($"GetPageRanges does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesDiffPageableAsync_ByPage()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            Tuple<PageBlobClient, string, string> setup = await CreatePageBlobForPageRangeDiff(test.Container);
            PageBlobClient pageBlob = setup.Item1;
            string prevSnapshot = setup.Item2;
            string snapshot = setup.Item3;

            GetPageRangesDiffOptions options = new GetPageRangesDiffOptions
            {
                PreviousSnapshot = prevSnapshot,
                Snapshot = snapshot
            };

            // Act
            List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();
            await foreach (Page<PageRangeItem> page in pageBlob.GetAllPageRangesDiffAsync(options)
                .AsPages(pageSizeHint: 1))
            {
                pageBlobRanges.AddRange(page.Values);
            }

            // Assert
            Assert.That(pageBlobRanges.Count, Is.EqualTo(4));

            Assert.That(pageBlobRanges[0].IsClear, Is.False);
            Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
            Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[1].IsClear, Is.True);
            Assert.That(pageBlobRanges[1].Range.Offset, Is.EqualTo(1024));
            Assert.That(pageBlobRanges[1].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[2].IsClear, Is.False);
            Assert.That(pageBlobRanges[2].Range.Offset, Is.EqualTo(2048));
            Assert.That(pageBlobRanges[2].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[3].IsClear, Is.True);
            Assert.That(pageBlobRanges[3].Range.Offset, Is.EqualTo(3072));
            Assert.That(pageBlobRanges[3].Range.Length, Is.EqualTo(1024));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesDiffPageableAsync_Range()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            Tuple<PageBlobClient, string, string> setup = await CreatePageBlobForPageRangeDiff(test.Container);
            PageBlobClient pageBlob = setup.Item1;
            string prevSnapshot = setup.Item2;
            string snapshot = setup.Item3;

            GetPageRangesDiffOptions options = new GetPageRangesDiffOptions
            {
                PreviousSnapshot = prevSnapshot,
                Snapshot = snapshot,
                Range = new HttpRange(0, 2 * Constants.KB)
            };

            // Act
            List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();
            await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesDiffAsync(options))
            {
                pageBlobRanges.Add(pageBlobRange);
            }

            // Assert
            Assert.That(pageBlobRanges.Count, Is.EqualTo(2));

            Assert.That(pageBlobRanges[0].IsClear, Is.False);
            Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
            Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[1].IsClear, Is.True);
            Assert.That(pageBlobRanges[1].Range.Offset, Is.EqualTo(1024));
            Assert.That(pageBlobRanges[1].Range.Length, Is.EqualTo(1024));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesDiffPageableAsync_AccessConditions()
        {
            // Arrange
            string garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Reduced_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                Tuple<PageBlobClient, string, string> setup = await CreatePageBlobForPageRangeDiff(test.Container);
                PageBlobClient pageBlob = setup.Item1;
                string prevSnapshot = setup.Item2;
                string snapshot = setup.Item3;

                parameters.Match = await SetupBlobMatchCondition(pageBlob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(pageBlob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                GetPageRangesDiffOptions options = new GetPageRangesDiffOptions
                {
                    PreviousSnapshot = prevSnapshot,
                    Conditions = accessConditions
                };

                // Act
                List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();
                await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesDiffAsync(options))
                {
                    pageBlobRanges.Add(pageBlobRange);
                }

                // Assert
                Assert.That(pageBlobRanges.Count, Is.EqualTo(4));

                Assert.That(pageBlobRanges[0].IsClear, Is.False);
                Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
                Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));

                Assert.That(pageBlobRanges[1].IsClear, Is.True);
                Assert.That(pageBlobRanges[1].Range.Offset, Is.EqualTo(1024));
                Assert.That(pageBlobRanges[1].Range.Length, Is.EqualTo(1024));

                Assert.That(pageBlobRanges[2].IsClear, Is.False);
                Assert.That(pageBlobRanges[2].Range.Offset, Is.EqualTo(2048));
                Assert.That(pageBlobRanges[2].Range.Length, Is.EqualTo(1024));

                Assert.That(pageBlobRanges[3].IsClear, Is.True);
                Assert.That(pageBlobRanges[3].Range.Offset, Is.EqualTo(3072));
                Assert.That(pageBlobRanges[3].Range.Length, Is.EqualTo(1024));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesDiffPageableAsync_AccessConditionsFail()
        {
            // Arrange
            string garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                PageBlobClient pageBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

                parameters.NoneMatch = await SetupBlobMatchCondition(pageBlob, parameters.NoneMatch);
                await SetupBlobLeaseCondition(pageBlob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                GetPageRangesDiffOptions options = new GetPageRangesDiffOptions
                {
                    Conditions = accessConditions,
                };

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesDiffAsync(options))
                        {
                        }
                    });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesDiffPageableAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            Tuple<PageBlobClient, string, string> setup = await CreatePageBlobForPageRangeDiff(test.Container);
            PageBlobClient pageBlob = setup.Item1;
            string prevSnapshot = setup.Item2;
            string snapshot = setup.Item3;

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await pageBlob.SetTagsAsync(tags);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            GetPageRangesDiffOptions options = new GetPageRangesDiffOptions
            {
                PreviousSnapshot = prevSnapshot,
                Conditions = conditions
            };

            // Act
            List<PageRangeItem> pageBlobRanges = new List<PageRangeItem>();
            await foreach (PageRangeItem pageBlobRange in pageBlob.GetAllPageRangesDiffAsync(options))
            {
                pageBlobRanges.Add(pageBlobRange);
            }

            // Assert
            Assert.That(pageBlobRanges.Count, Is.EqualTo(4));

            Assert.That(pageBlobRanges[0].IsClear, Is.False);
            Assert.That(pageBlobRanges[0].Range.Offset, Is.EqualTo(0));
            Assert.That(pageBlobRanges[0].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[1].IsClear, Is.True);
            Assert.That(pageBlobRanges[1].Range.Offset, Is.EqualTo(1024));
            Assert.That(pageBlobRanges[1].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[2].IsClear, Is.False);
            Assert.That(pageBlobRanges[2].Range.Offset, Is.EqualTo(2048));
            Assert.That(pageBlobRanges[2].Range.Length, Is.EqualTo(1024));

            Assert.That(pageBlobRanges[3].IsClear, Is.True);
            Assert.That(pageBlobRanges[3].Range.Offset, Is.EqualTo(3072));
            Assert.That(pageBlobRanges[3].Range.Length, Is.EqualTo(1024));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesDiffPageableAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            Tuple<PageBlobClient, string, string> setup = await CreatePageBlobForPageRangeDiff(test.Container);
            PageBlobClient pageBlob = setup.Item1;
            string prevSnapshot = setup.Item2;
            string snapshot = setup.Item3;

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            GetPageRangesDiffOptions options = new GetPageRangesDiffOptions
            {
                Conditions = conditions,
                Range = new HttpRange(0, 4 * Constants.KB),
                Snapshot = snapshot,
                PreviousSnapshot = prevSnapshot
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                pageBlob.GetAllPageRangesDiffAsync(options).ToListAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPageRangesDiffPageableAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient pageBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            GetPageRangesDiffOptions options = new GetPageRangesDiffOptions
            {
                Range = new HttpRange(5 * Constants.KB, 4 * Constants.KB)
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
               pageBlob.GetAllPageRangesDiffAsync(options).ToListAsync(),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("InvalidRange"));
                    Assert.That(e.Message.Split('\n')[0],
                        Is.EqualTo("The range specified is invalid for the current size of the resource."));
                });
        }

        [RecordedTest]
        public async Task ResizeAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            var newSize = 8 * Constants.KB;

            // Act
            Response<PageBlobInfo> result = await blob.ResizeAsync(size: newSize);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{result.GetRawResponse().Headers.ETag.ToString()}\"", Is.EqualTo(result.Value.ETag.ToString()));

            // Ensure we correctly resized properly by doing a GetProperties call
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.That(response.Value.ContentLength, Is.EqualTo(newSize));
        }

        [RecordedTest]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThan))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberEqual))]
        public async Task ResizeAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            PageBlobClient pageBlobClient = new PageBlobClient(uri, GetOptions());

            PageBlobRequestConditions conditions = new PageBlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual):
                    conditions.IfSequenceNumberLessThanOrEqual = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThan):
                    conditions.IfSequenceNumberLessThan = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberEqual):
                    conditions.IfSequenceNumberEqual = 0;
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlobClient.ResizeAsync(
                    size: 0,
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"Resize does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task ResizeAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateIfNotExistsAsync(Constants.KB);
            var newSize = 8 * Constants.KB;

            // Act
            Response<PageBlobInfo> response = await blob.ResizeAsync(size: newSize);

            // Assert
            Assert.That(response.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ResizeAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateIfNotExistsAsync(Constants.KB);
            var newSize = 8 * Constants.KB;

            // Act
            Response<PageBlobInfo> response = await blob.ResizeAsync(size: newSize);

            // Assert
            Assert.That(response.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        public async Task ResizeAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            var invalidSize = 511;

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.ResizeAsync(size: invalidSize),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("InvalidHeaderValue"));
                    Assert.That(e.Message.Split('\n')[0],
                        Is.EqualTo("The value for one of the HTTP headers is not in the correct format."));
                });
        }

        [RecordedTest]
        public async Task ResizeAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Reduced_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
                var newSize = 8 * Constants.KB;

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PageBlobInfo> response = await blob.ResizeAsync(
                    size: newSize,
                    conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task ResizeAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
                var newSize = 8 * Constants.KB;

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.ResizeAsync(
                        size: newSize,
                        conditions: accessConditions),
                    e => Assert.That(true, Is.True));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ResizeAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            long newSize = 8 * Constants.KB;
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            Response<PageBlobInfo> response = await blob.ResizeAsync(
                size: newSize,
                conditions: conditions);

            // Assert
            Assert.That(response.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ResizeAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            long newSize = 8 * Constants.KB;

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.ResizeAsync(
                    size: newSize,
                    conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        public async Task UpdateSequenceNumberAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            long sequenceAccessNumber = 5;

            // Act
            Response<PageBlobInfo> response = await blob.UpdateSequenceNumberAsync(
                action: SequenceNumberAction.Update,
                sequenceNumber: sequenceAccessNumber);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));

            // Ensure that the correct BlobSequence was set by doing a GetProperties
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();
            Assert.That(propertiesResponse.Value.BlobSequenceNumber, Is.EqualTo(sequenceAccessNumber));
        }

        [RecordedTest]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThan))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberEqual))]
        public async Task UpdateSequenceNumberAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            PageBlobClient pageBlobClient = new PageBlobClient(uri, GetOptions());

            PageBlobRequestConditions conditions = new PageBlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual):
                    conditions.IfSequenceNumberLessThanOrEqual = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThan):
                    conditions.IfSequenceNumberLessThan = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberEqual):
                    conditions.IfSequenceNumberEqual = 0;
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlobClient.UpdateSequenceNumberAsync(
                    SequenceNumberAction.Increment,
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"UpdateSequenceNumber does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task UpdateSequenceNumberAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Reduced_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
                long sequenceAccessNumber = 5;

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PageBlobInfo> response = await blob.UpdateSequenceNumberAsync(
                    action: SequenceNumberAction.Update,
                    sequenceNumber: sequenceAccessNumber,
                    conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task UpdateSequenceNumberAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
                long sequenceAccessNumber = 5;

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.UpdateSequenceNumberAsync(
                        action: SequenceNumberAction.Update,
                        sequenceNumber: sequenceAccessNumber,
                        conditions: accessConditions),
                    e => Assert.That(true, Is.True));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateSequenceNumberAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            long sequenceNumber = 5;

            // Act
            Response<PageBlobInfo> response = await blob.UpdateSequenceNumberAsync(
                action: SequenceNumberAction.Update,
                sequenceNumber: sequenceNumber,
                conditions: conditions);

            // Assert
            Assert.That(response.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateSequenceNumberAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            long sequenceNumber = 5;

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.UpdateSequenceNumberAsync(
                    action: SequenceNumberAction.Update,
                    sequenceNumber: sequenceNumber,
                    conditions: conditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.ConditionNotMet.ToString())));
        }

        [RecordedTest]
        public async Task UpdateSequenceNumberAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.UpdateSequenceNumberAsync(
                    action: SequenceNumberAction.Update,
                    sequenceNumber: -1),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("InvalidHeaderValue"));
                    Assert.That(e.Message.Split('\n')[0],
                        Is.EqualTo("The value for one of the HTTP headers is not in the correct format."));
                });
        }

        [Test]
        [Ignore("#10715 - Disabled failing StartCopyIncrementalAsync live tests")]
        public async Task StartCopyIncrementalAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            var data = GetRandomBuffer(Constants.KB);
            var expectedData = new byte[4 * Constants.KB];
            data.CopyTo(expectedData, 0);

            // Create Page Blob
            PageBlobClient sourceBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Update data to firstPageBlob
            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadPagesAsync(stream, Constants.KB);
            }

            // Create Snapshot
            Response<BlobSnapshotInfo> snapshotResponse = await sourceBlob.CreateSnapshotAsync();

            var snapshot = snapshotResponse.Value.Snapshot;

            PageBlobClient destinationBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            Operation<long> operation = await destinationBlob.StartCopyIncrementalAsync(
                sourceUri: sourceBlob.Uri,
                snapshot: snapshot);

            await operation.WaitForCompletionAsync();

            // Assert
            Response<BlobProperties> properties = await destinationBlob.GetPropertiesAsync();
            Assert.That(properties.Value.CopyStatus, Is.EqualTo(CopyStatus.Success));
        }

        [RecordedTest]
        [TestCase(nameof(PageBlobRequestConditions.LeaseId))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThan))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberEqual))]
        public async Task StartCopyIncrementalAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            PageBlobClient pageBlobClient = new PageBlobClient(uri, GetOptions());

            PageBlobRequestConditions conditions = new PageBlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(PageBlobRequestConditions.LeaseId):
                    conditions.LeaseId = "LeaseId";
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual):
                    conditions.IfSequenceNumberLessThanOrEqual = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThan):
                    conditions.IfSequenceNumberLessThan = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberEqual):
                    conditions.IfSequenceNumberEqual = 0;
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlobClient.StartCopyIncrementalAsync(
                    uri,
                    "snapshot",
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"StartCopyIncremental does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task StartCopyIncrementalAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    // dummy snapshot value.
                    snapshot: "2019-03-29T18:12:15.6608647Z"),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("CannotVerifyCopySource"));
                    Assert.That(e.Message.Split('\n')[0], Is.EqualTo("The specified blob does not exist."));
                });
        }

        [Test]
        [Ignore("#10715 - Disabled failing StartCopyIncrementalAsync live tests")]
        public async Task StartCopyIncrementalAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in Reduced_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
                var data = GetRandomBuffer(Constants.KB);
                var expectedData = new byte[4 * Constants.KB];
                data.CopyTo(expectedData, 0);

                // Create sourceBlob
                PageBlobClient sourceBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

                // Update data to sourceBlob
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadPagesAsync(stream, Constants.KB);
                }

                // Create Snapshot
                Response<BlobSnapshotInfo> snapshotResponse = await sourceBlob.CreateSnapshotAsync();

                var snapshot = snapshotResponse.Value.Snapshot;

                PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

                Operation<long> operation = await blob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.Uri,
                    snapshot: snapshot);
                await operation.WaitForCompletionAsync();
                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(parameters: parameters);

                snapshotResponse = await sourceBlob.CreateSnapshotAsync();
                snapshot = snapshotResponse.Value.Snapshot;

                // Act
                Operation<long> response = await blob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.Uri,
                    snapshot: snapshot,
                    conditions: accessConditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task StartCopyIncrementalAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                var expectedData = new byte[4 * Constants.KB];
                data.CopyTo(expectedData, 0);

                // Create sourceBlob
                PageBlobClient sourceBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

                // Update data to sourceBlob
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadPagesAsync(stream, Constants.KB);
                }

                // Create Snapshot
                Response<BlobSnapshotInfo> snapshotResponse = await sourceBlob.CreateSnapshotAsync();

                var snapshot = snapshotResponse.Value.Snapshot;

                PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

                Operation<long> operation = await blob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    snapshot: snapshot);
                await operation.WaitForCompletionAsync();
                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                PageBlobRequestConditions accessConditions = BuildAccessConditions(parameters: parameters);

                snapshotResponse = await sourceBlob.CreateSnapshotAsync();
                snapshot = snapshotResponse.Value.Snapshot;

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.StartCopyIncrementalAsync(
                        sourceUri: sourceBlob.Uri,
                        snapshot: snapshot,
                        conditions: accessConditions),
                    e => Assert.That(true, Is.True));
            }
        }

        [Test]
        [PlaybackOnly("#10715 - Disabled failing StartCopyIncrementalAsync live tests")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyIncrementalAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            var data = GetRandomBuffer(Constants.KB);

            // Create Page Blob
            PageBlobClient sourceBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Update data to firstPageBlob
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadPagesAsync(stream, 0);
            stream.Position = 0;

            // Create Snapshot
            Response<BlobSnapshotInfo> snapshotResponse = await sourceBlob.CreateSnapshotAsync();

            string snapshot0 = snapshotResponse.Value.Snapshot;

            PageBlobClient destinationBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Associate the blobs via incremental copy
            await destinationBlob.StartCopyIncrementalAsync(
                sourceUri: sourceBlob.Uri,
                snapshot: snapshot0);

            // Need to wait for 1st copy to complete.
            await Delay(5000);

            // Update destination tags
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await destinationBlob.SetTagsAsync(tags);

            // Update source blob
            await sourceBlob.UploadPagesAsync(stream, Constants.KB);

            // Create new snapshot
            snapshotResponse = await sourceBlob.CreateSnapshotAsync();

            string snapshot1 = snapshotResponse.Value.Snapshot;

            // Act
            await destinationBlob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.Uri,
                    snapshot: snapshot1,
                    conditions: conditions);
        }

        [Test]
        [PlaybackOnly("#10715 - Disabled failing StartCopyIncrementalAsync live tests")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyIncrementalAsync_IfTags_Failed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            var data = GetRandomBuffer(Constants.KB);

            // Create Page Blob
            PageBlobClient sourceBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Update data to firstPageBlob
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadPagesAsync(stream, 0);
            stream.Position = 0;

            // Create Snapshot
            Response<BlobSnapshotInfo> snapshotResponse = await sourceBlob.CreateSnapshotAsync();

            string snapshot0 = snapshotResponse.Value.Snapshot;

            PageBlobClient destinationBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Associate the blobs via incremental copy
            await destinationBlob.StartCopyIncrementalAsync(
                sourceUri: sourceBlob.Uri,
                snapshot: snapshot0);

            // Update source blob
            await sourceBlob.UploadPagesAsync(stream, Constants.KB);

            // Create new snapshot
            snapshotResponse = await sourceBlob.CreateSnapshotAsync();

            string snapshot1 = snapshotResponse.Value.Snapshot;

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationBlob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.Uri,
                    snapshot: snapshot1,
                    conditions: conditions),
                    e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.ConditionNotMet.ToString())));
        }

        [RecordedTest]
        [Category("NonVirtualized")]
        public async Task StartCopyIncrementalAsync_AccessTier()
        {
            BlobServiceClient premiumService = BlobsClientBuilder.GetServiceClient_PremiumBlobAccount_SharedKey();
            await using DisposingContainer test = await GetTestContainerAsync(service: premiumService, premium: true);
            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            var expectedData = new byte[4 * Constants.KB];
            data.CopyTo(expectedData, 0);

            // Create Page Blob
            PageBlobClient sourceBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Update data to firstPageBlob
            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadPagesAsync(stream, Constants.KB);
            }

            // Create Snapshot
            Response<BlobSnapshotInfo> snapshotResponse = await sourceBlob.CreateSnapshotAsync();

            var snapshot = snapshotResponse.Value.Snapshot;

            PageBlobClient destinationBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            Operation<long> operation = await destinationBlob.StartCopyFromUriAsync(
                sourceBlob.Uri,
                accessTier: AccessTier.P20);

            await operation.WaitForCompletionAsync();

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);

            Response<BlobProperties> response = await destinationBlob.GetPropertiesAsync();
            Assert.That(response.Value.AccessTier, Is.EqualTo(AccessTier.P20.ToString()));
        }

        [RecordedTest]
        [Category("NonVirtualized")]
        public async Task StartCopyIncrementalAsync_AccessTierFail()
        {
            BlobServiceClient premiumService = BlobsClientBuilder.GetServiceClient_PremiumBlobAccount_SharedKey();
            await using DisposingContainer test = await GetTestContainerAsync(service: premiumService, premium: true);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            var expectedData = new byte[4 * Constants.KB];
            data.CopyTo(expectedData, 0);

            // Create Page Blob
            PageBlobClient sourceBlob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Update data to firstPageBlob
            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadPagesAsync(stream, Constants.KB);
            }

            // Create Snapshot
            Response<BlobSnapshotInfo> snapshotResponse = await sourceBlob.CreateSnapshotAsync();

            var snapshot = snapshotResponse.Value.Snapshot;

            PageBlobClient destinationBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destinationBlob.StartCopyFromUriAsync(
                sourceBlob.Uri,
                accessTier: AccessTier.Cool),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.InvalidBlobTier.ToString())));
        }

        [RecordedTest]
        [Category("NonVirtualized")]
        public async Task SetTierAsync_AccessTier()
        {
            BlobServiceClient premiumService = BlobsClientBuilder.GetServiceClient_PremiumBlobAccount_SharedKey();
            await using DisposingContainer test = await GetTestContainerAsync(service: premiumService, premium: true);

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

            // Act
            Response response = await blob.SetAccessTierAsync(AccessTier.P20);

            // Assert
            Response<BlobProperties> responseProperties = await blob.GetPropertiesAsync();
            Assert.That(responseProperties.Value.AccessTier, Is.EqualTo(AccessTier.P20.ToString()));
        }

        [RecordedTest]
        [Category("NonVirtualized")]
        public async Task SetTierAsync_AccessTierFail()
        {
            BlobServiceClient premiumService = BlobsClientBuilder.GetServiceClient_PremiumBlobAccount_SharedKey();
            await using DisposingContainer test = await GetTestContainerAsync(service: premiumService, premium: true);
            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetAccessTierAsync(AccessTier.Cool),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.InvalidBlobTier.ToString())));
        }

        [RecordedTest]
        public async Task UploadPagesFromUriAsync_Min()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
                await sourceBlob.UploadPagesAsync(stream, 0);

                PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync(Constants.KB);
                var range = new HttpRange(0, Constants.KB);

                // Act
                Response<PageInfo> response = await destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    sourceRange: range,
                    range: range);

                // Ensure that we grab the whole ETag value from the service without removing the quotes
                Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2024_08_04)]
        public async Task UploadPagesFromUriAsync_SourceErrorAndStatusCode()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);

            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await destBlob.CreateIfNotExistsAsync(Constants.KB);

            HttpRange range = new HttpRange(0, Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.UploadPagesFromUriAsync(sourceBlob.Uri, range, range),
                e =>
                {
                    Assert.That(e.Message.Contains("CopySourceStatusCode: 401"), Is.True);
                    Assert.That(e.Message.Contains("CopySourceErrorCode: NoAuthenticationInformation"), Is.True);
                    Assert.That(e.Message.Contains("CopySourceErrorMessage: Server failed to authenticate the request. Please refer to the information in the www-authenticate header."), Is.True);
                });
        }

        [RecordedTest]
        [TestCase(nameof(PageBlobRequestConditions.LeaseId))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberLessThan))]
        [TestCase(nameof(PageBlobRequestConditions.IfSequenceNumberEqual))]
        [TestCase(nameof(PageBlobRequestConditions.TagConditions))]
        public async Task UploadPagesFromUriAsync_InvalidSourceRequestConditions(string invalidSourceCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            PageBlobClient pageBlobClient = new PageBlobClient(uri, GetOptions());

            PageBlobRequestConditions sourceConditions = new PageBlobRequestConditions();

            switch (invalidSourceCondition)
            {
                case nameof(PageBlobRequestConditions.LeaseId):
                    sourceConditions.LeaseId = "LeaseId";
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual):
                    sourceConditions.IfSequenceNumberLessThanOrEqual = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberLessThan):
                    sourceConditions.IfSequenceNumberLessThan = 0;
                    break;
                case nameof(PageBlobRequestConditions.IfSequenceNumberEqual):
                    sourceConditions.IfSequenceNumberEqual = 0;
                    break;
                case nameof(PageBlobRequestConditions.TagConditions):
                    sourceConditions.TagConditions = "TagConditions";
                    break;
            }

            HttpRange httpRange = new HttpRange(0, 1);

            PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
            {
                SourceConditions = sourceConditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlobClient.UploadPagesFromUriAsync(
                    uri,
                    httpRange,
                    httpRange,
                    options),
                e =>
                {
                    Assert.That(e.Message.Contains($"UploadPagesFromUri does not support the {invalidSourceCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("sourceConditions"), Is.True);
                });
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task UploadPagesFromUriAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using var stream = new MemoryStream(data);
            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
            await sourceBlob.UploadPagesAsync(stream, 0);

            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            destBlob = InstrumentClient(destBlob.WithCustomerProvidedKey(customerProvidedKey));
            await destBlob.CreateIfNotExistsAsync(Constants.KB);
            var range = new HttpRange(0, Constants.KB);

            Uri sourceUri = sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddDays(1));

            // Act
            Response<PageInfo> response = await destBlob.UploadPagesFromUriAsync(
                sourceUri: sourceUri,
                sourceRange: range,
                range: range);

            // Assert
            Assert.That(response.Value.EncryptionKeySha256, Is.EqualTo(customerProvidedKey.EncryptionKeyHash));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_04_06)]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task UploadPagesFromUriAsync_SourceCPK()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            CustomerProvidedKey destCustomerProvidedKey = GetCustomerProvidedKey();
            destBlob = destBlob.WithCustomerProvidedKey(destCustomerProvidedKey);
            await destBlob.CreateIfNotExistsAsync(Constants.KB);

            CustomerProvidedKey sourceCustomerProvidedKey = GetCustomerProvidedKey();
            sourceBlob = sourceBlob.WithCustomerProvidedKey(sourceCustomerProvidedKey);
            await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadPagesAsync(stream, 0);

            // Act
            PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
            {
                SourceCustomerProvidedKey = sourceCustomerProvidedKey
            };
            Response<PageInfo> response = await destBlob.UploadPagesFromUriAsync(
                sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddDays(1)),
                sourceRange: new HttpRange(0, Constants.KB),
                range: new HttpRange(0, Constants.KB),
                options: options);

            // Assert
            Assert.That(response.Value.EncryptionKeySha256, Is.EqualTo(destCustomerProvidedKey.EncryptionKeyHash));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_04_06)]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task UploadPagesFromUriAsync_SourceCPK_Fail()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            CustomerProvidedKey destCustomerProvidedKey = GetCustomerProvidedKey();
            destBlob = destBlob.WithCustomerProvidedKey(destCustomerProvidedKey);
            await destBlob.CreateIfNotExistsAsync(Constants.KB);

            CustomerProvidedKey sourceCustomerProvidedKey = GetCustomerProvidedKey();
            sourceBlob = sourceBlob.WithCustomerProvidedKey(sourceCustomerProvidedKey);
            await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadPagesAsync(stream, 0);

            // Act
            PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
            {
                // incorrectly use the dest CPK here
                SourceCustomerProvidedKey = destCustomerProvidedKey
            };
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddDays(1)),
                    sourceRange: new HttpRange(0, Constants.KB),
                    range: new HttpRange(0, Constants.KB),
                    options: options),
                e =>
                {
                    Assert.That(e.Status, Is.EqualTo(409));
                    Assert.That(e.ErrorCode, Is.EqualTo("CannotVerifyCopySource"));
                    Assert.That(e.Message, Does.Contain("The given customer specified encryption does not match the encryption used to encrypt the blob."));
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadPagesFromUriAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using var stream = new MemoryStream(data);
            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
            await sourceBlob.UploadPagesAsync(stream, 0);

            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            destBlob = InstrumentClient(destBlob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await destBlob.CreateIfNotExistsAsync(Constants.KB);
            var range = new HttpRange(0, Constants.KB);

            // Act
            Response<PageInfo> response = await destBlob.UploadPagesFromUriAsync(
                sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                sourceRange: range,
                range: range);

            // Assert
            Assert.That(response.Value.EncryptionScope, Is.EqualTo(TestConfigDefault.EncryptionScope));
        }

        [RecordedTest]
        public async Task UploadPagesFromUriAsync_Range()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(4 * Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync(4 * Constants.KB);
                await sourceBlob.UploadPagesAsync(stream, 0);

                PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync(2 * Constants.KB);
                var range = new HttpRange(0, 2 * Constants.KB);

                // Act
                await destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    sourceRange: new HttpRange(2 * Constants.KB, 2 * Constants.KB),
                    range: range);

                // Assert
                Response<BlobDownloadInfo> response = await destBlob.DownloadAsync(new HttpRange(0, 2 * Constants.KB));
                var dataResult = new MemoryStream();
                await response.Value.Content.CopyToAsync(dataResult);
                Assert.That(dataResult.Length, Is.EqualTo(2 * Constants.KB));
                TestHelper.AssertSequenceEqual(data.Skip(2 * Constants.KB).Take(2 * Constants.KB), dataResult.ToArray());
            }
        }

        [RecordedTest]
        public async Task UploadPagesFromUriAsync_MD5()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
                await sourceBlob.UploadPagesAsync(stream, 0);

                PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync(Constants.KB);
                HttpRange range = new HttpRange(0, Constants.KB);

                PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
                {
                    SourceContentHash = MD5.Create().ComputeHash(data)
                };

                // Act
                await destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    sourceRange: range,
                    range: range,
                    options: options);
            }
        }

        [RecordedTest]
        public async Task UploadPagesFromUriAsync_MD5_Fail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
                await sourceBlob.UploadPagesAsync(stream, 0);

                PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync(Constants.KB);
                HttpRange range = new HttpRange(0, Constants.KB);

                PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
                {
                    SourceContentHash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garabage"))
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.UploadPagesFromUriAsync(
                        sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                        sourceRange: range,
                        range: range,
                        options: options),
                    actualException => Assert.That(actualException.ErrorCode, Is.EqualTo("Md5Mismatch"))
                );
            }
        }

        public IEnumerable<AccessConditionParameters> UploadPagesFromUriAsync_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId },
                new AccessConditionParameters { SequenceNumberLT = 5 },
                new AccessConditionParameters { SequenceNumberLTE = 3 },
                new AccessConditionParameters { SequenceNumberEqual = 0 },
                new AccessConditionParameters { SourceIfModifiedSince = OldDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = NewDate },
                new AccessConditionParameters { SourceIfMatch = ReceivedETag },
                new AccessConditionParameters { SourceIfNoneMatch = GarbageETag }
            };

        [RecordedTest]
        public async Task UploadPagesFromUriAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in UploadPagesFromUriAsync_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                    await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                    await destBlob.CreateIfNotExistsAsync(Constants.KB);

                    parameters.Match = await SetupBlobMatchCondition(destBlob, parameters.Match);
                    parameters.SourceIfMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                    parameters.LeaseId = await SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                    PageBlobRequestConditions accessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: true,
                        sequenceNumbers: true);
                    PageBlobRequestConditions sourceAccessConditions = BuildSourceAccessConditions(parameters);

                    HttpRange range = new HttpRange(0, Constants.KB);

                    PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
                    {
                        DestinationConditions = accessConditions,
                        SourceConditions = sourceAccessConditions
                    };

                    // Act
                    await destBlob.UploadPagesFromUriAsync(
                        sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                        sourceRange: range,
                        range: range,
                        options: options);
                }
            }
        }

        [RecordedTest]
        // Net462 is sending the source SAS expiry unencoded to the service, while net6 and net7 sending it encoded.
        // Both are valid, but make this test non-recordable.
        [LiveOnly]
        public async Task UploadPagesFromUriAsync_NonAsciiSourceUri()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewNonAsciiBlobName()));
                await sourceBlob.CreateAsync(Constants.KB);
                await sourceBlob.UploadPagesAsync(stream, 0);

                PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync(Constants.KB);
                var range = new HttpRange(0, Constants.KB);

                // Act
                await destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    sourceRange: range,
                    range: range);
            }
        }

        public IEnumerable<AccessConditionParameters> GetUploadPagesFromUriAsync_AccessConditionsFail_Data(string garbageLeaseId)
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { SequenceNumberLT = -1 },
                new AccessConditionParameters { SequenceNumberLTE = -1 },
                new AccessConditionParameters { SequenceNumberEqual = 100 },
                new AccessConditionParameters { SourceIfModifiedSince = NewDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = OldDate },
                new AccessConditionParameters { SourceIfMatch = GarbageETag },
                new AccessConditionParameters { SourceIfNoneMatch = ReceivedETag }
            };

        [RecordedTest]
        public async Task UploadPagesFromUriAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetUploadPagesFromUriAsync_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                    await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                    await destBlob.CreateIfNotExistsAsync(Constants.KB);

                    parameters.NoneMatch = await SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                    parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);

                    PageBlobRequestConditions accessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: true,
                        sequenceNumbers: true);
                    PageBlobRequestConditions sourceAccessConditions = BuildSourceAccessConditions(parameters);

                    HttpRange range = new HttpRange(0, Constants.KB);

                    PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
                    {
                        DestinationConditions = accessConditions,
                        SourceConditions = sourceAccessConditions
                    };

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        destBlob.UploadPagesFromUriAsync(
                            sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                            sourceRange: range,
                            range: range,
                            options: options),
                        actualException => Assert.That(true, Is.True)
                    );
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadPagesFromUriAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await sourceBlob.CreateAsync(Constants.KB);
            await sourceBlob.UploadPagesAsync(stream, 0);

            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await destBlob.CreateAsync(Constants.KB);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await destBlob.SetTagsAsync(tags);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            HttpRange range = new HttpRange(0, Constants.KB);

            PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
            {
                DestinationConditions = conditions
            };

            // Act
            await destBlob.UploadPagesFromUriAsync(
                sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                sourceRange: range,
                range: range,
                options: options);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadPagesFromUriAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await sourceBlob.CreateAsync(Constants.KB);
            await sourceBlob.UploadPagesAsync(stream, 0);

            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await destBlob.CreateAsync(Constants.KB);

            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            HttpRange range = new HttpRange(0, Constants.KB);

            PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
            {
                DestinationConditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                    sourceRange: range,
                    range: range,
                    options: options),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ConditionNotMet")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task UploadPagesFromUriAsync_SourceBearerToken()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            byte[] data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);
            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
            await sourceBlob.UploadPagesAsync(stream, 0);

            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await destBlob.CreateIfNotExistsAsync(Constants.KB);
            HttpRange range = new HttpRange(0, Constants.KB);

            string sourceBearerToken = await GetAuthToken();

            HttpAuthorization sourceAuth = new HttpAuthorization(
                "Bearer",
                sourceBearerToken);

            PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
            {
                SourceAuthentication = sourceAuth
            };

            // Act
            await destBlob.UploadPagesFromUriAsync(
                sourceUri: sourceBlob.Uri,
                sourceRange: range,
                range: range,
                options: options);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task UploadPagesFromUriAsync_SourceBearerTokenFail()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            byte[] data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);
            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await sourceBlob.CreateIfNotExistsAsync(Constants.KB);
            await sourceBlob.UploadPagesAsync(stream, 0);

            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await destBlob.CreateIfNotExistsAsync(Constants.KB);
            HttpRange range = new HttpRange(0, Constants.KB);

            HttpAuthorization sourceAuth = new HttpAuthorization(
                "Bearer",
                "auth token");

            PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
            {
                SourceAuthentication = sourceAuth
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    sourceRange: range,
                    range: range,
                    options: options),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.CannotVerifyCopySource.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2025_07_05)]
        [RetryOnException(5, typeof(RequestFailedException))]
        public async Task UploadPagesFromUriAsync_SourceBearerToken_FilesSource()
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

                PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync(size: Constants.MB);

                string sourceBearerToken = await GetAuthToken();

                HttpAuthorization sourceAuth = new HttpAuthorization(
                    "Bearer",
                    sourceBearerToken);

                PageBlobUploadPagesFromUriOptions options = new PageBlobUploadPagesFromUriOptions
                {
                    SourceAuthentication = sourceAuth,
                    SourceShareTokenIntent = FileShareTokenIntent.Backup
                };

                HttpRange range = new HttpRange(0, Constants.KB);

                // Act
                await destBlob.UploadPagesFromUriAsync(fileClient.Uri, range, range, options);
            }
            finally
            {
                await shareClient.DeleteAsync();
            }
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
            PageBlobClient pageBlobClient = new PageBlobClient(uri);
            PageBlobClient snapshotPageBlobClient = pageBlobClient.WithSnapshot(snapshot);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(snapshotPageBlobClient.Uri);

            // Assert
            Assert.That(snapshotPageBlobClient.AccountName, Is.EqualTo(accountName));
            Assert.That(snapshotPageBlobClient.BlobContainerName, Is.EqualTo(containerName));
            Assert.That(snapshotPageBlobClient.Name, Is.EqualTo(blobName));
            Assert.That(snapshotPageBlobClient.Uri, Is.EqualTo(snapshotUri));

            Assert.That(blobUriBuilder.AccountName, Is.EqualTo(accountName));
            Assert.That(blobUriBuilder.BlobContainerName, Is.EqualTo(containerName));
            Assert.That(blobUriBuilder.BlobName, Is.EqualTo(blobName));
            Assert.That(blobUriBuilder.Snapshot, Is.EqualTo(snapshot));
            Assert.That(blobUriBuilder.ToUri(), Is.EqualTo(snapshotUri));
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
            PageBlobClient pageBlobClient = new PageBlobClient(uri);
            PageBlobClient versionPageBlobClient = pageBlobClient.WithVersion(versionId);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(versionPageBlobClient.Uri);

            // Assert
            Assert.That(versionPageBlobClient.AccountName, Is.EqualTo(accountName));
            Assert.That(versionPageBlobClient.BlobContainerName, Is.EqualTo(containerName));
            Assert.That(versionPageBlobClient.Name, Is.EqualTo(blobName));
            Assert.That(versionPageBlobClient.Uri, Is.EqualTo(versionUri));

            Assert.That(blobUriBuilder.AccountName, Is.EqualTo(accountName));
            Assert.That(blobUriBuilder.BlobContainerName, Is.EqualTo(containerName));
            Assert.That(blobUriBuilder.BlobName, Is.EqualTo(blobName));
            Assert.That(blobUriBuilder.VersionId, Is.EqualTo(versionId));
            Assert.That(blobUriBuilder.ToUri(), Is.EqualTo(versionUri));
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            Response<BlobContentInfo> response = await blob.CreateIfNotExistsAsync(Constants.KB);

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> response = await blob.CreateAsync(Constants.KB);

            // Act
            Response<BlobContentInfo> responseExists = await blob.CreateIfNotExistsAsync(Constants.KB);

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var invalidPageSize = 511;
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateIfNotExistsAsync(invalidPageSize),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("InvalidHeaderValue"));
                    Assert.That(e.Message.Split('\n')[0],
                        Is.EqualTo("The value for one of the HTTP headers is not in the correct format."));
                });
        }

        [RecordedTest]
        public async Task GetPageBlobClient_AsciiName()
        {
            //Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();

            //Act
            PageBlobClient blob = test.Container.GetPageBlobClient(blobName);
            await blob.CreateAsync(Constants.KB);

            //Assert
            List<string> names = new List<string>();
            await foreach (BlobItem pathItem in test.Container.GetBlobsAsync())
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.That(names.Count, Is.EqualTo(1));
            Assert.That(names, Does.Contain(blobName));
        }

        [RecordedTest]
        public async Task GetPageBlobClient_NonAsciiName()
        {
            //Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewNonAsciiBlobName();

            //Act
            PageBlobClient blob = test.Container.GetPageBlobClient(blobName);
            await blob.CreateAsync(Constants.KB);

            //Assert
            List<string> names = new List<string>();
            await foreach (BlobItem pathItem in test.Container.GetBlobsAsync())
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.That(names.Count, Is.EqualTo(1));
            Assert.That(names, Does.Contain(blobName));
        }

        [RecordedTest]
        public async Task WithCustomerProvidedKey()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            PageBlobClient cpkBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()).WithCustomerProvidedKey(customerProvidedKey));
            await cpkBlob.CreateAsync(Constants.KB);
            PageBlobClient noCpkBlob = InstrumentClient(cpkBlob.WithCustomerProvidedKey(null));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                noCpkBlob.GetPropertiesAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.BlobUsesCustomerSpecifiedEncryption.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task WithEncryptionScope()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string encryptionScope = TestConfigDefault.EncryptionScope;
            PageBlobClient encryptionScopeBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()).WithEncryptionScope(encryptionScope));
            await encryptionScopeBlob.CreateAsync(Constants.KB);
            PageBlobClient noEncryptionScopeBlob = InstrumentClient(encryptionScopeBlob.WithEncryptionScope(null));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                noEncryptionScopeBlob.SetMetadataAsync(BuildMetadata()),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.BlobUsesCustomerSpecifiedEncryption.ToString())));
        }

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<PageBlobClient>(TestConfigDefault.ConnectionString, "name", "name", new BlobClientOptions()).Object;
            mock = new Mock<PageBlobClient>(TestConfigDefault.ConnectionString, "name", "name").Object;
            mock = new Mock<PageBlobClient>(new Uri("https://test/test"), new BlobClientOptions()).Object;
            mock = new Mock<PageBlobClient>(new Uri("https://test/test"), Tenants.GetNewSharedKeyCredentials(), new BlobClientOptions()).Object;
            mock = new Mock<PageBlobClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new BlobClientOptions()).Object;
            mock = new Mock<PageBlobClient>(new Uri("https://test/test"), TestEnvironment.Credential, new BlobClientOptions()).Object;
        }

        [RecordedTest]
        public async Task DownloadAsync_UnevenPageRanges()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            // Create Page Blob with different page ranges
            int pageBlobSize = 10 * Constants.KB;
            StorageTransferOptions transferOptions = new()
            {
                InitialTransferLength = 4 * Constants.KB,
                MaximumTransferSize = 4 * Constants.KB,
            };
            PageBlobClient pageBlobClient = test.Container.GetPageBlobClient(GetNewBlobName());
            await pageBlobClient.CreateIfNotExistsAsync(pageBlobSize);
            int offset = 2 * Constants.KB + 512;
            int length = Constants.KB;
            var data = GetRandomBuffer(length);

            using (var stream = new MemoryStream(data))
            {
                await pageBlobClient.UploadPagesAsync(
                    content: stream,
                    offset: offset);
            }
            // Act
            Response<BlobDownloadStreamingResult> result = await pageBlobClient.DownloadStreamingAsync();

            // Assert
            var actual = new MemoryStream();
            await result.Value.Content.CopyToAsync(actual);
            actual.Seek(offset, SeekOrigin.Begin);
            byte[] resultArray = new byte[length];
            await actual.ReadAsync(resultArray, 0, length, CancellationToken.None);
            Assert.That(actual.Length, Is.EqualTo(pageBlobSize));
            Assert.That(data, Is.EqualTo(resultArray));
        }

        public static PageBlobRequestConditions BuildAccessConditions(
            AccessConditionParameters parameters,
            bool lease = false,
            bool sequenceNumbers = false)
        {
            var accessConditions = new PageBlobRequestConditions
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

            if (sequenceNumbers)
            {
                accessConditions.IfSequenceNumberLessThan = parameters.SequenceNumberLT;
                accessConditions.IfSequenceNumberEqual = parameters.SequenceNumberEqual;
                accessConditions.IfSequenceNumberLessThanOrEqual = parameters.SequenceNumberLTE;
            }

            return accessConditions;
        }

        private PageBlobRequestConditions BuildSourceAccessConditions(AccessConditionParameters parameters) =>
            new PageBlobRequestConditions
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
            public long? SequenceNumberLT { get; set; }
            public long? SequenceNumberLTE { get; set; }
            public long? SequenceNumberEqual { get; set; }
            public DateTimeOffset? SourceIfModifiedSince { get; set; }
            public DateTimeOffset? SourceIfUnmodifiedSince { get; set; }
            public string SourceIfMatch { get; set; }
            public string SourceIfNoneMatch { get; set; }
        }

        /// <summary>
        /// Creates a 4 KB Page Blob, and populates bytes 0-1023 and 2048-3071.
        /// </summary>
        private async Task<PageBlobClient> CreatePageBlobWithRangesAsync(BlobContainerClient containerClient)
        {
            PageBlobClient pageBlob = await CreatePageBlobClientAsync(containerClient, 4 * Constants.KB);
            byte[] data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await pageBlob.UploadPagesAsync(stream, 0);
            }
            using (var stream = new MemoryStream(data))
            {
                await pageBlob.UploadPagesAsync(stream, 2 * Constants.KB);
            }

            return pageBlob;
        }

        /// <summary>
        /// Creates a 4 KB Page Blob, populates it with data.
        /// Creates prevSnapshot.
        /// Writes over bytes 0-1023 and 2048-3071.
        /// Clears bytes 1024-2047 and 3072-4095.
        /// Creates snapshot.
        /// </summary>
        /// <returns>PageBlobClient, prevSnapshot, snapshot</returns>
        private async Task<Tuple<PageBlobClient, string, string>> CreatePageBlobForPageRangeDiff(BlobContainerClient containerClient)
        {
            // Create Page Blob
            PageBlobClient pageBlob = await CreatePageBlobClientAsync(containerClient, 4 * Constants.KB);

            // Populate entire Page Blob with data.
            byte[] initalData = GetRandomBuffer(4 * Constants.KB);
            using (Stream stream = new MemoryStream(initalData))
            {
                await pageBlob.UploadPagesAsync(stream, 0);
            }

            // Take previous snapshot
            Response<BlobSnapshotInfo> prevSnapshotResponse = await pageBlob.CreateSnapshotAsync();
            string prevSnapshot = prevSnapshotResponse.Value.Snapshot;

            // Write over bytes 0-1023 and 2048-3071
            byte[] newData = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(newData))
            {
                await pageBlob.UploadPagesAsync(stream, 0);
            }
            using (var stream = new MemoryStream(newData))
            {
                await pageBlob.UploadPagesAsync(stream, 2 * Constants.KB);
            }

            // Clear bytes 1024-2047 and 3072-4095
            await pageBlob.ClearPagesAsync(new HttpRange(Constants.KB, Constants.KB));
            await pageBlob.ClearPagesAsync(new HttpRange(3 * Constants.KB, Constants.KB));

            // Take snapshot
            Response<BlobSnapshotInfo> snapshotResponse = await pageBlob.CreateSnapshotAsync();
            string snapshot = snapshotResponse.Value.Snapshot;

            return Tuple.Create(pageBlob, prevSnapshot, snapshot);
        }
    }
}
