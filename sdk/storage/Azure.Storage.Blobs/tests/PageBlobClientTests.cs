// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests;
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

        [Test]
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

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
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

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual(accountName, builder.AccountName);
        }

        [Test]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new PageBlobClient(httpUri, GetOAuthCredential()),
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
                () => new PageBlobClient(httpUri, blobClientOptions),
                new ArgumentException("Cannot use client-provided key without HTTPS."));
        }

        [Test]
        public async Task CreateAsync_Min()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync(Constants.KB);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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

        [Test]
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
            Assert.AreEqual(2, response.Value.BlobSequenceNumber);
        }

        [Test]
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
            Assert.AreEqual(BlobType.Page, getPropertiesResponse.Value.BlobType);
        }

        [Test]
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
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [Test]
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
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync(Constants.KB);

            // Assert
            Assert.IsNotNull(response.Value.VersionId);
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

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
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

        [Test]
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
                    actualException => Assert.IsTrue(true));
            }
        }

        [Test]
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

        [Test]
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
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
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
            Assert.AreEqual(ContentType, response.Value.ContentType);
            TestHelper.AssertSequenceEqual(contentMD5, response.Value.ContentHash);
            Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(CacheControl, response.Value.CacheControl);
        }

        [Test]
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
                    Assert.AreEqual("InvalidHeaderValue", e.ErrorCode);
                    Assert.AreEqual("The value for one of the HTTP headers is not in the correct format.",
                        e.Message.Split('\n')[0]);
                });
        }

        [Test]
        public async Task UploadPagesAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                // Act
                await blob.UploadPagesAsync(
                    content: stream,
                    offset: Constants.KB);
            }

            // Assert
            var expectedData = new byte[4 * Constants.KB];
            data.CopyTo(expectedData, Constants.KB);
            Response<BlobDownloadInfo> response = await blob.DownloadAsync(range: new HttpRange(0, 4 * Constants.KB));

            var actualData = new byte[4 * Constants.KB];
            using var actualStream = new MemoryStream(actualData);
            await response.Value.Content.CopyToAsync(actualStream);
            TestHelper.AssertSequenceEqual(expectedData, actualData);
        }

        [Test]
        public async Task UploadPagesAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(blobName));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            var data = GetRandomBuffer(Constants.KB);
            await blob.CreateAsync(Constants.KB);

            using var stream = new MemoryStream(data);

            // Act
            Response<PageInfo> response = await blob.UploadPagesAsync(
                content: stream,
                offset: 0);

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadPagesAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(blobName));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            var data = GetRandomBuffer(Constants.KB);
            await blob.CreateAsync(Constants.KB);

            using var stream = new MemoryStream(data);

            // Act
            Response<PageInfo> response = await blob.UploadPagesAsync(
                content: stream,
                offset: 0);

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [Test]
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
                    e => Assert.AreEqual("InvalidPageRange", e.ErrorCode));
            }
        }

        [Test]
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
                    e => Assert.AreEqual("body", e.ParamName));
            }
        }

        public IEnumerable<AccessConditionParameters> UploadClearAsync_AccessConditions_Data
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
                new AccessConditionParameters { SequenceNumberEqual = 0 }
           };

        [Test]
        public async Task UploadAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in UploadClearAsync_AccessConditions_Data)
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
                        conditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
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

        [Test]
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
                            conditions: accessConditions),
                        e => Assert.IsTrue(true));
                }
            }
        }

        [Test]
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
                conditions: conditions);
        }

        [Test]
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
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
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

            await blob.CreateAsync(blobSize)
                .ConfigureAwait(false);

            var offset = 0 * Constants.KB;
            var data = GetRandomBuffer(blobSize);
            var progressList = new List<long>();
            var progressHandler = new Progress<long>(progress => progressList.Add(progress));
            var timesFaulted = 0;

            // Act
            using (var stream = new FaultyStream(
                new MemoryStream(data),
                256 * Constants.KB,
                1,
                new IOException("Simulated stream fault"),
                () => timesFaulted++))
            {
                await blobFaulty.UploadPagesAsync(stream, offset, progressHandler: progressHandler);

                await WaitForProgressAsync(progressList, data.LongLength);
                Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                // Changing from Assert.AreEqual because these don't always update fast enough
                Assert.GreaterOrEqual(data.LongLength, progressList.Last(), "Final progress has unexpected value");
            }

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync(
                new HttpRange(offset, data.LongLength));
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreNotEqual(0, timesFaulted);
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
                    progressHandler: progress);
            }

            // Assert
            Assert.IsFalse(progress.List.Count == 0);

            Assert.AreEqual(blobSize, progress.List[progress.List.Count - 1]);
        }

        [Test]
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
            await blob.ClearPagesAsync(range: new HttpRange(Constants.KB, Constants.KB));

            // Assert
            var expectedData = new byte[4 * Constants.KB];
            Array.Copy(data, expectedData, 4 * Constants.KB);
            Array.Clear(expectedData, Constants.KB, Constants.KB);
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(expectedData, actual.ToArray());
        }

        [Ignore("Backend bug")]
        [Test]
        public async Task ClearPagesAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateAsync(4 * Constants.KB);
            var data = GetRandomBuffer(4 * Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);
            }

            // Act
            Response<PageInfo> response = await blob.ClearPagesAsync(
                range: new HttpRange(Constants.KB, Constants.KB));

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ClearPagesAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateAsync(4 * Constants.KB);
            var data = GetRandomBuffer(4 * Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);
            }

            // Act
            Response<PageInfo> response = await blob.ClearPagesAsync(
                range: new HttpRange(Constants.KB, Constants.KB));
        }

        [Test]
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
                    Assert.AreEqual("InvalidPageRange", e.ErrorCode);
                    Assert.AreEqual("The page range specified is invalid.", e.Message.Split('\n')[0]);
                });
        }

        [Test]
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
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
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
                e => Assert.AreEqual(BlobErrorCode.ConditionNotMet.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task ClearPagesAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in UploadClearAsync_AccessConditions_Data)
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

                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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
                    e => Assert.IsTrue(true));
            }
        }

        [Test]
        public async Task GetPageRangesAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);

            }
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 2 * Constants.KB);
            }

            // Act
            Response<PageRangesInfo> result = await blob.GetPageRangesAsync(range: new HttpRange(0, 4 * Constants.KB));

            // Assert
            Assert.AreEqual(2, result.Value.PageRanges.Count());
            HttpRange range1 = result.Value.PageRanges.First();
            Assert.AreEqual(0, range1.Offset);
            Assert.AreEqual(Constants.KB, range1.Offset + range1.Length);

            HttpRange range2 = result.Value.PageRanges.ElementAt(1);
            Assert.AreEqual(2 * Constants.KB, range2.Offset);
            Assert.AreEqual(3 * Constants.KB, range2.Offset + range2.Length);
        }

        [Test]
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
            Response<PageRangesInfo> result = await blob.GetPageRangesAsync(range: new HttpRange(0, 6 * Constants.KB));

            Response<PageRangesInfo> diff = await blob.GetPageRangesDiffAsync(range: new HttpRange(0, 6 * Constants.KB), previousSnapshot: snapshot.Value.Snapshot);


            // Assert
            Assert.AreEqual(2, result.Value.PageRanges.Count());
            HttpRange pageRange1 = result.Value.PageRanges.First();
            Assert.AreEqual(0, pageRange1.Offset);
            Assert.AreEqual(2 * Constants.KB, pageRange1.Offset + pageRange1.Length);

            HttpRange pageRange2 = result.Value.PageRanges.ElementAt(1);
            Assert.AreEqual(5 * Constants.KB, pageRange2.Offset); // since the first part of the page was cleared, it should start at 5 rather than 4 KB
            Assert.AreEqual(6 * Constants.KB, pageRange2.Offset + pageRange2.Length);

            Assert.AreEqual(1, diff.Value.ClearRanges.Count());
            HttpRange clearRange = diff.Value.ClearRanges.First(); // ClearRange is only populated by GetPageRangesDiff API, and only if passing previous snapshot parameter
            Assert.AreEqual(4 * Constants.KB, clearRange.Offset);
        }

        [Test]
        public async Task GetPageRangesAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPageRangesAsync(range: new HttpRange(5 * Constants.KB, 4 * Constants.KB)),
                e =>
                {
                    Assert.AreEqual("InvalidRange", e.ErrorCode);
                    Assert.AreEqual("The range specified is invalid for the current size of the resource.",
                        e.Message.Split('\n')[0]);
                });
        }

        [Test]
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
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Value.PageRanges);
            }
        }

        [Test]
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
                            conditions: accessConditions)).Value;
                    });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPageRangesAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);

            }
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 2 * Constants.KB);
            }

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
                conditions: conditions);
        }

        [Test]
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
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
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
                prevSnapshot);

            // Assert
            Assert.AreEqual(1, result.Value.PageRanges.Count());
            HttpRange range = result.Value.PageRanges.First();

            Assert.AreEqual(2 * Constants.KB, range.Offset);
            Assert.AreEqual(3 * Constants.KB, range.Offset + range.Length);
        }

        [Test]
        public async Task GetPageRangesDiffAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPageRangesDiffAsync(range: new HttpRange(5 * Constants.KB, 4 * Constants.KB)),
                e =>
                {
                    Assert.AreEqual("InvalidRange", e.ErrorCode);
                    Assert.AreEqual("The range specified is invalid for the current size of the resource.",
                        e.Message.Split('\n')[0]);
                });
        }

        [Test]
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
                    previousSnapshot: prevSnapshot,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Value.PageRanges);
            }
        }

        [Test]
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
                            previousSnapshot: prevSnapshot,
                            conditions: accessConditions)).Value;
                    });
            }
        }

        [Test]
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
                conditions: conditions);
        }

        [Test]
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
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        [PlaybackOnly("Not possible to programmatically create a managed disk storage account")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetManagedDiskPageRangesDiffAsync()
        {
            BlobServiceClient manageDiskService = GetServiceClient_ManagedDisk();
            await using DisposingContainer test = await GetTestContainerAsync(manageDiskService);

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

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Snapshot = prevSnapshot
            };

            // Upload additional Pages
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 2 * Constants.KB);
            }

            // create snapshot
            response = await blob.CreateSnapshotAsync();
            string snapshot = response.Value.Snapshot;

            // Act
            Response<PageRangesInfo> result = await blob.GetManagedDiskPageRangesDiffAsync(
                range: new HttpRange(0, 4 * Constants.KB),
                snapshot,
                previousSnapshotUri: blobUriBuilder.ToUri());

            // Assert
            Assert.AreEqual(1, result.Value.PageRanges.Count());
            HttpRange range = result.Value.PageRanges.First();

            Assert.AreEqual(2 * Constants.KB, range.Offset);
            Assert.AreEqual(3 * Constants.KB, range.Offset + range.Length);
        }

        [Test]
        [PlaybackOnly("Not possible to programmatically create a managed disk storage account")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetManagedDiskPageRangesDiffAsync_Error()
        {
            BlobServiceClient manageDiskService = GetServiceClient_ManagedDisk();
            await using DisposingContainer test = await GetTestContainerAsync(manageDiskService);

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetManagedDiskPageRangesDiffAsync(range: new HttpRange(5 * Constants.KB, 4 * Constants.KB)),
                e =>
                {
                    Assert.AreEqual("InvalidRange", e.ErrorCode);
                    Assert.AreEqual("The range specified is invalid for the current size of the resource.",
                        e.Message.Split('\n')[0]);
                });
        }

        [Test]
        [PlaybackOnly("Not possible to programmatically create a managed disk storage account")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetManagedDiskPageRangesDiffAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Reduced_AccessConditions_Data)
            {
                BlobServiceClient manageDiskService = GetServiceClient_ManagedDisk();
                await using DisposingContainer test = await GetTestContainerAsync(manageDiskService);

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

                BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
                {
                    Snapshot = prevSnapshot
                };

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
                Response<PageRangesInfo> response = await blob.GetManagedDiskPageRangesDiffAsync(
                    range: new HttpRange(0, Constants.KB),
                    previousSnapshotUri: blobUriBuilder.ToUri(),
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Value.PageRanges);
            }
        }

        [Test]
        [PlaybackOnly("Not possible to programmatically create a managed disk storage account")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetManagedDiskPageRangesDiffAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                BlobServiceClient manageDiskService = GetServiceClient_ManagedDisk();
                await using DisposingContainer test = await GetTestContainerAsync(manageDiskService);

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

                BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
                {
                    Snapshot = prevSnapshot
                };

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
                        var _ = (await blob.GetManagedDiskPageRangesDiffAsync(
                            range: new HttpRange(0, Constants.KB),
                            previousSnapshotUri: blobUriBuilder.ToUri(),
                            conditions: accessConditions)).Value;
                    });
            }
        }

        [Test]
        [PlaybackOnly("Not possible to programmatically create a managed disk storage account")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetManagedDiskPageRangesDiffAsync_NonAsciiPrevSnapshotUri()
        {
            BlobServiceClient manageDiskService = GetServiceClient_ManagedDisk();
            await using DisposingContainer test = await GetTestContainerAsync(manageDiskService);

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewNonAsciiBlobName()));
            await blob.CreateAsync(4 * Constants.KB, 0).ConfigureAwait(false);

            // Upload some Pages
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 0);
            }

            // Create prevSnapshot
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();
            var prevSnapshot = response.Value.Snapshot;

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Snapshot = prevSnapshot
            };

            // Upload additional Pages
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadPagesAsync(stream, 2 * Constants.KB);
            }

            // create snapshot
            response = await blob.CreateSnapshotAsync();
            string snapshot = response.Value.Snapshot;

            // Act
            Response<PageRangesInfo> result = await blob.GetManagedDiskPageRangesDiffAsync(
                range: new HttpRange(0, 4 * Constants.KB),
                snapshot,
                previousSnapshotUri: blobUriBuilder.ToUri());

            // Assert
            Assert.AreEqual(1, result.Value.PageRanges.Count());
            HttpRange range = result.Value.PageRanges.First();

            Assert.AreEqual(2 * Constants.KB, range.Offset);
            Assert.AreEqual(3 * Constants.KB, range.Offset + range.Length);
        }

        [Test]
        public async Task ResizeAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            var newSize = 8 * Constants.KB;

            // Act
            Response<PageBlobInfo> result = await blob.ResizeAsync(size: newSize);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.AreEqual(newSize, response.Value.ContentLength);

        }

        [Test]
        public async Task ResizeAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateAsync(Constants.KB);
            var newSize = 8 * Constants.KB;

            // Act
            Response<PageBlobInfo> response = await blob.ResizeAsync(size: newSize);

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ResizeAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateAsync(Constants.KB);
            var newSize = 8 * Constants.KB;

            // Act
            Response<PageBlobInfo> response = await blob.ResizeAsync(size: newSize);

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
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
                    Assert.AreEqual("InvalidHeaderValue", e.ErrorCode);
                    Assert.AreEqual("The value for one of the HTTP headers is not in the correct format.",
                        e.Message.Split('\n')[0]);
                });

        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            }
        }

        [Test]
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
                    e => Assert.IsTrue(true));

            }
        }

        [Test]
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
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
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
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task UpdateSequenceNumberAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            long sequenceAccessNumber = 5;

            // Act
            await blob.UpdateSequenceNumberAsync(
                action: SequenceNumberAction.Update,
                sequenceNumber: sequenceAccessNumber);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.AreEqual(sequenceAccessNumber, response.Value.BlobSequenceNumber);

        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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
                    e => Assert.IsTrue(true));

            }
        }

        [Test]
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
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
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
                e => Assert.AreEqual(BlobErrorCode.ConditionNotMet.ToString(), e.ErrorCode));
        }

        [Test]
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
                    Assert.AreEqual("InvalidHeaderValue", e.ErrorCode);
                    Assert.AreEqual("The value for one of the HTTP headers is not in the correct format.",
                        e.Message.Split('\n')[0]);
                });
        }

        [Test]
        [PlaybackOnly("#10715 - Disabled failing StartCopyIncrementalAsync live tests")]
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
            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }

            // Assert
            Response<BlobProperties> properties = await destinationBlob.GetPropertiesAsync();
            Assert.AreEqual(CopyStatus.Success, properties.Value.CopyStatus);
        }

        [Test]
        public async Task StartCopyIncrementalAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, 4 * Constants.KB);
            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.Uri,
                    // dummy snapshot value.
                    snapshot: "2019-03-29T18:12:15.6608647Z"),
                e =>
                {
                    Assert.AreEqual("CannotVerifyCopySource", e.ErrorCode);
                    Assert.AreEqual("The specified blob does not exist.", e.Message.Split('\n')[0]);
                });
        }

        [Test]
        [PlaybackOnly("#10715 - Disabled failing StartCopyIncrementalAsync live tests")]
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
                if (Mode == RecordedTestMode.Playback)
                {
                    await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
                }
                else
                {
                    await operation.WaitForCompletionAsync();
                }
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            }
        }

        [Test]
        public async Task StartCopyIncrementalAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetReduced_AccessConditionsFail_Data(garbageLeaseId))
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
                if (Mode == RecordedTestMode.Playback)
                {
                    await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
                }
                else
                {
                    await operation.WaitForCompletionAsync();
                }
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
                    e => Assert.IsTrue(true));

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
                    e => Assert.AreEqual(BlobErrorCode.ConditionNotMet.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task StartCopyIncrementalAsync_AccessTier()
        {
            BlobServiceClient premiumService = GetServiceClient_PremiumBlobAccount_SharedKey();
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
            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            Response<BlobProperties> response = await destinationBlob.GetPropertiesAsync();
            Assert.AreEqual(AccessTier.P20.ToString(), response.Value.AccessTier);
        }

        [Test]
        public async Task StartCopyIncrementalAsync_AccessTierFail()
        {
            BlobServiceClient premiumService = GetServiceClient_PremiumBlobAccount_SharedKey();
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
                e => Assert.AreEqual(BlobErrorCode.InvalidBlobTier.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task SetTierAsync_AccessTier()
        {
            BlobServiceClient premiumService = GetServiceClient_PremiumBlobAccount_SharedKey();
            await using DisposingContainer test = await GetTestContainerAsync(service: premiumService, premium: true);

            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

            // Act
            Response response = await blob.SetAccessTierAsync(AccessTier.P20);

            // Assert
            Response<BlobProperties> responseProperties = await blob.GetPropertiesAsync();
            Assert.AreEqual(AccessTier.P20.ToString(), responseProperties.Value.AccessTier);
        }

        [Test]
        public async Task SetTierAsync_AccessTierFail()
        {
            BlobServiceClient premiumService = GetServiceClient_PremiumBlobAccount_SharedKey();
            await using DisposingContainer test = await GetTestContainerAsync(service: premiumService, premium: true);
            // Arrange
            PageBlobClient blob = await CreatePageBlobClientAsync(test.Container, Constants.KB);

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetAccessTierAsync(AccessTier.Cool),
                e => Assert.AreEqual(BlobErrorCode.InvalidBlobTier.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task UploadPagesFromUriAsync_Min()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange

            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await sourceBlob.CreateAsync(Constants.KB);
                await sourceBlob.UploadPagesAsync(stream, 0);

                PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync(Constants.KB);
                var range = new HttpRange(0, Constants.KB);

                // Act
                await destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    sourceRange: range,
                    range: range);
            }
        }

        [Test]
        public async Task UploadPagesFromUriAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using var stream = new MemoryStream(data);
            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await sourceBlob.CreateAsync(Constants.KB);
            await sourceBlob.UploadPagesAsync(stream, 0);

            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            destBlob = InstrumentClient(destBlob.WithCustomerProvidedKey(customerProvidedKey));
            await destBlob.CreateAsync(Constants.KB);
            var range = new HttpRange(0, Constants.KB);

            // Act
            Response<PageInfo> response = await destBlob.UploadPagesFromUriAsync(
                sourceUri: sourceBlob.Uri,
                sourceRange: range,
                range: range);

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadPagesFromUriAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using var stream = new MemoryStream(data);
            PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await sourceBlob.CreateAsync(Constants.KB);
            await sourceBlob.UploadPagesAsync(stream, 0);

            PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            destBlob = InstrumentClient(destBlob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await destBlob.CreateAsync(Constants.KB);
            var range = new HttpRange(0, Constants.KB);

            // Act
            Response<PageInfo> response = await destBlob.UploadPagesFromUriAsync(
                sourceUri: sourceBlob.Uri,
                sourceRange: range,
                range: range);

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [Test]
        public async Task UploadPagesFromUriAsync_Range()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(4 * Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await sourceBlob.CreateAsync(4 * Constants.KB);
                await sourceBlob.UploadPagesAsync(stream, 0);

                PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync(2 * Constants.KB);
                var range = new HttpRange(0, 2 * Constants.KB);

                // Act
                await destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    sourceRange: new HttpRange(2 * Constants.KB, 2 * Constants.KB),
                    range: range);

                // Assert
                Response<BlobDownloadInfo> response = await destBlob.DownloadAsync(new HttpRange(0, 2 * Constants.KB));
                var dataResult = new MemoryStream();
                await response.Value.Content.CopyToAsync(dataResult);
                Assert.AreEqual(2 * Constants.KB, dataResult.Length);
                TestHelper.AssertSequenceEqual(data.Skip(2 * Constants.KB).Take(2 * Constants.KB), dataResult.ToArray());
            }
        }

        [Test]
        public async Task UploadPagesFromUriAsync_MD5()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await sourceBlob.CreateAsync(Constants.KB);
                await sourceBlob.UploadPagesAsync(stream, 0);

                PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync(Constants.KB);
                var range = new HttpRange(0, Constants.KB);

                // Act
                await destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    sourceRange: range,
                    range: range,
                    sourceContentHash: MD5.Create().ComputeHash(data));
            }
        }

        [Test]
        public async Task UploadPagesFromUriAsync_MD5_Fail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await sourceBlob.CreateAsync(Constants.KB);
                await sourceBlob.UploadPagesAsync(stream, 0);

                PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync(Constants.KB);
                var range = new HttpRange(0, Constants.KB);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.UploadPagesFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        sourceRange: range,
                        range: range,
                        sourceContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garabage"))),
                    actualException => Assert.AreEqual("Md5Mismatch", actualException.ErrorCode)
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

        [Test]
        public async Task UploadPagesFromUriAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in UploadPagesFromUriAsync_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

                var data = GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                    await sourceBlob.CreateAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                    await destBlob.CreateAsync(Constants.KB);

                    parameters.Match = await SetupBlobMatchCondition(destBlob, parameters.Match);
                    parameters.SourceIfMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                    parameters.LeaseId = await SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                    PageBlobRequestConditions accessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: true,
                        sequenceNumbers: true);
                    PageBlobRequestConditions sourceAccessConditions = BuildSourceAccessConditions(parameters);

                    var range = new HttpRange(0, Constants.KB);

                    // Act
                    await destBlob.UploadPagesFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        sourceRange: range,
                        range: range,
                        conditions: accessConditions,
                        sourceConditions: sourceAccessConditions);
                }
            }
        }

        [Test]
        public async Task UploadPagesFromUriAsync_NonAsciiSourceUri()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

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
                    sourceUri: sourceBlob.Uri,
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

        [Test]
        public async Task UploadPagesFromUriAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetUploadPagesFromUriAsync_AccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

                var data = GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    PageBlobClient sourceBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                    await sourceBlob.CreateAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    PageBlobClient destBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                    await destBlob.CreateAsync(Constants.KB);

                    parameters.NoneMatch = await SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                    parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);

                    PageBlobRequestConditions accessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: true,
                        sequenceNumbers: true);
                    PageBlobRequestConditions sourceAccessConditions = BuildSourceAccessConditions(parameters);

                    var range = new HttpRange(0, Constants.KB);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        destBlob.UploadPagesFromUriAsync(
                            sourceUri: sourceBlob.Uri,
                            sourceRange: range,
                            range: range,
                            conditions: accessConditions,
                            sourceConditions: sourceAccessConditions),
                        actualException => Assert.IsTrue(true)
                    );
                }
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadPagesFromUriAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange

            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

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

            var range = new HttpRange(0, Constants.KB);

            // Act
            await destBlob.UploadPagesFromUriAsync(
                sourceUri: sourceBlob.Uri,
                sourceRange: range,
                range: range,
                conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadPagesFromUriAsync_IfTagsFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange

            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

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

            var range = new HttpRange(0, Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.UploadPagesFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    sourceRange: range,
                    range: range,
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public void WithSnapshot()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = "my/blob/name";
            string snapshot = "2020-07-03T12:45:46.1234567Z";
            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{Uri.EscapeDataString(blobName)}");
            Uri snapshotUri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{Uri.EscapeDataString(blobName)}?snapshot={snapshot}");

            // Act
            PageBlobClient pageBlobClient = new PageBlobClient(uri);
            PageBlobClient snapshotPageBlobClient = pageBlobClient.WithSnapshot(snapshot);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(snapshotPageBlobClient.Uri);

            // Assert
            Assert.AreEqual(accountName, snapshotPageBlobClient.AccountName);
            Assert.AreEqual(containerName, snapshotPageBlobClient.BlobContainerName);
            Assert.AreEqual(blobName, snapshotPageBlobClient.Name);
            Assert.AreEqual(snapshotUri, snapshotPageBlobClient.Uri);

            Assert.AreEqual(accountName, blobUriBuilder.AccountName);
            Assert.AreEqual(containerName, blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual(snapshot, blobUriBuilder.Snapshot);
            Assert.AreEqual(snapshotUri, blobUriBuilder.ToUri());
        }

        [Test]
        public void WithVersion()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = "my/blob/name";
            string versionId = "2020-07-03T12:45:46.1234567Z";
            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{Uri.EscapeDataString(blobName)}");
            Uri versionUri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{Uri.EscapeDataString(blobName)}?versionid={versionId}");

            // Act
            PageBlobClient pageBlobClient = new PageBlobClient(uri);
            PageBlobClient versionPageBlobClient = pageBlobClient.WithVersion(versionId);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(versionPageBlobClient.Uri);

            // Assert
            Assert.AreEqual(accountName, versionPageBlobClient.AccountName);
            Assert.AreEqual(containerName, versionPageBlobClient.BlobContainerName);
            Assert.AreEqual(blobName, versionPageBlobClient.Name);
            Assert.AreEqual(versionUri, versionPageBlobClient.Uri);

            Assert.AreEqual(accountName, blobUriBuilder.AccountName);
            Assert.AreEqual(containerName, blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual(versionId, blobUriBuilder.VersionId);
            Assert.AreEqual(versionUri, blobUriBuilder.ToUri());
        }

        [Test]
        public async Task CreateIfNotExistsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            // Act
            Response<BlobContentInfo> response = await blob.CreateIfNotExistsAsync(Constants.KB);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> response = await blob.CreateAsync(Constants.KB);

            // Act
            Response<BlobContentInfo> responseExists = await blob.CreateIfNotExistsAsync(Constants.KB);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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
                    Assert.AreEqual("InvalidHeaderValue", e.ErrorCode);
                    Assert.AreEqual("The value for one of the HTTP headers is not in the correct format.",
                        e.Message.Split('\n')[0]);
                });
        }

        [Test]
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
            Assert.AreEqual(1, names.Count);
            Assert.Contains(blobName, names);
        }

        [Test]
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
            Assert.AreEqual(1, names.Count);
            Assert.Contains(blobName, names);
        }

        private PageBlobRequestConditions BuildAccessConditions(
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
    }
}
