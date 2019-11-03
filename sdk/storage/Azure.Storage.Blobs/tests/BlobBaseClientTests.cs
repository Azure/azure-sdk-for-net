// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Blobs.Test
{
    public class BlobBaseClientTests : BlobTestBase
    {
        public BlobBaseClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
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

            var connectionString = new StorageConnectionString(credentials, (blobEndpoint, blobSecondaryEndpoint), (default, default), (default, default), (default, default));

            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();

            BlobBaseClient blob1 = InstrumentClient(new BlobBaseClient(connectionString.ToString(true), containerName, blobName, GetOptions()));
            BlobBaseClient blob2 = InstrumentClient(new BlobBaseClient(connectionString.ToString(true), containerName, blobName));

            var builder1 = new BlobUriBuilder(blob1.Uri);
            var builder2 = new BlobUriBuilder(blob2.Uri);

            Assert.AreEqual(containerName, builder1.BlobContainerName);
            Assert.AreEqual(blobName, builder1.BlobName);
            Assert.AreEqual("accountName", builder1.AccountName);

            Assert.AreEqual(containerName, builder2.BlobContainerName);
            Assert.AreEqual(blobName, builder2.BlobName);
            Assert.AreEqual("accountName", builder2.AccountName);
        }

        [Test]
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            BlobBaseClient blob = InstrumentClient(new BlobBaseClient(blobEndpoint));
            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(accountName, builder.AccountName);
        }

        #region Sequential Download

        [Test]
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
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        #region Secondary Storage
        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/8356")]
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
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreEqual(SecondaryStorageTenantPrimaryHost(), testExceptionPolicy.HostsSetInRequests[0]);
            Assert.AreEqual(SecondaryStorageTenantSecondaryHost(), testExceptionPolicy.HostsSetInRequests[1]);
        }

        [Test]
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
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreEqual(SecondaryStorageTenantPrimaryHost(), testExceptionPolicy.HostsSetInRequests[0]);
            // should not toggle to secondary host on put request failure
            Assert.AreEqual(SecondaryStorageTenantPrimaryHost(), testExceptionPolicy.HostsSetInRequests[1]);
        }
        #endregion

        [Test]
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
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.Details.EncryptionKeySha256);
        }

        [Test]
        public async Task DownloadAsync_CpkHttpError()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient httpBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            httpBlob = InstrumentClient(new BlockBlobClient(
                httpBlob.Uri,
                httpBlob.Pipeline,
                httpBlob.ClientDiagnostics,
                customerProvidedKey));
            Assert.AreEqual(Constants.Blob.Http, httpBlob.Uri.Scheme);
            BlockBlobClient httpsblob = InstrumentClient(httpBlob.WithCustomerProvidedKey(customerProvidedKey));
            using (var stream = new MemoryStream(data))
            {
                await httpsblob.UploadAsync(stream);
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                httpBlob.DownloadAsync(),
                actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
        }

        [Test]
        public async Task DownloadAsync_WithUnreliableConnection()
        {
            // Arrange
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey),
                    GetFaultyBlobConnectionOptions(
                        raiseAt: 256 * Constants.KB,
                        raise: new Exception("Unexpected"))));

            await using DisposingContainer test = await GetTestContainerAsync(service: service);

            var data = GetRandomBuffer(Constants.KB);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
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
            Assert.AreEqual(count, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            Assert.AreEqual(count, actual.Length);
            TestHelper.AssertSequenceEqual(data.Skip(offset).Take(count), actual.ToArray());
        }

        [Test]
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
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
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
                Assert.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await blob.DownloadAsync(
                            conditions: accessConditions)).Value;
                    });
            }
        }

        [Test]
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

        [Test]
        public async Task DownloadAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DownloadAsync(),
                e => Assert.AreEqual("The specified blob does not exist.", e.Message.Split('\n')[0]));
        }

        [Test]
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
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                using var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
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
                        initialTransferLength: singleBlockThreshold,
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

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/8356")]
        [Test]
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

        [Test]
        public async Task DownloadTo_Initial304()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload a blob
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Add conditions to cause a failure and ensure we don't explode
            Response result = await blob.DownloadToAsync(
                Stream.Null,
                new BlobRequestConditions
                {
                    IfModifiedSince = Recording.UtcNow
                });
            Assert.AreEqual(304, result.Status);
        }

        [Test]
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
                        initialTransferLength: Constants.KB,
                        transferOptions:
                            new StorageTransferOptions
                            {
                                MaximumConcurrency = 1,
                                MaximumTransferLength = Constants.KB
                            });
                });
            Assert.IsTrue(ex.ErrorCode == BlobErrorCode.ConditionNotMet);
        }
        #endregion Parallel Download

        [Test]
        public async Task StartCopyFromUriAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

            // Assert
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
        }

        [Test]
        public async Task StartCopyFromUriAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = BuildMetadata();

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await destBlob.StartCopyFromUriAsync(
                source: srcBlob.Uri,
                metadata: metadata);

            // Assert
            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
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

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                Operation<long> response = await destBlob.StartCopyFromUriAsync(
                    source: srcBlob.Uri,
                    sourceConditions: sourceAccessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        sourceConditions: sourceAccessConditions),
                    e => { });

            }
        }

        [Test]
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

                // Act
                Operation<long> response = await destBlob.StartCopyFromUriAsync(
                    source: srcBlob.Uri,
                    destinationConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            }
        }

        [Test]
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

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        destinationConditions: accessConditions),
                    e => { });

            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_AccessTier()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                accessTier: AccessTier.Cool);

            // Assert
            // data copied within an account, so copy should be instantaneous
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

        }

        [Test]
        public async Task StartCopyFromUriAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StartCopyFromUriAsync(srcBlob.Uri),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));

        }

        [Test]
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

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                accessTier: AccessTier.Archive,
                rehydratePriority: RehydratePriority.High);

            // Assert
            // data copied within an account, so copy should be instantaneous
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

            // Act
            await destBlob.SetAccessTierAsync(AccessTier.Cool);
            Response<BlobProperties> propertiesResponse = await destBlob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual("rehydrate-pending-to-cool", propertiesResponse.Value.ArchiveStatus);

        }

        [Test]
        public async Task StartCopyFromUriAsync_AccessTierFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                accessTier: AccessTier.P20),
                e => Assert.AreEqual(BlobErrorCode.InvalidHeaderValue.ToString(), e.ErrorCode));

        }

        [Test]
        public async Task AbortCopyFromUriAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var data = GetRandomBuffer(8 * Constants.MB);

            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }

            BlobServiceClient secondaryService = GetServiceClient_SecondaryAccount_SharedKey();
            await using DisposingContainer destTest = await GetTestContainerAsync(service: secondaryService);


            {
                BlockBlobClient destBlob = InstrumentClient(destTest.Container.GetBlockBlobClient(GetNewBlobName()));

                Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

                // Act
                try
                {
                    Response response = await destBlob.AbortCopyFromUriAsync(operation.Id);

                    // Assert
                    Assert.IsNotNull(response.Headers.RequestId);
                }
                catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                {
                    WarnCopyCompletedTooQuickly();
                }

            }
        }

        [Test]
        public async Task AbortCopyFromUriAsync_Lease()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var data = GetRandomBuffer(8 * Constants.MB);

            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }
            BlobServiceClient secondaryService = GetServiceClient_SecondaryAccount_SharedKey();
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
                source: srcBlob.Uri,
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
                Assert.IsNotNull(response.Headers.RequestId);
            }
            catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
            {
                WarnCopyCompletedTooQuickly();
            }

        }

        [Test]
        public async Task AbortCopyFromUriAsync_LeaseFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();


            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var data = GetRandomBuffer(8 * Constants.MB);

            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }
            BlobServiceClient secondaryService = GetServiceClient_SecondaryAccount_SharedKey();
            await using DisposingContainer destTest = await GetTestContainerAsync(service: secondaryService);

            BlockBlobClient destBlob = InstrumentClient(destTest.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await destBlob.UploadAsync(stream);
            }

            Operation<long> operation = await destBlob.StartCopyFromUriAsync(source: srcBlob.Uri);

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
                                Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode);
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

        [Test]
        public async Task AbortCopyFromUriAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var copyId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.AbortCopyFromUriAsync(copyId),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();


            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response response = await blob.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);

        }

        [Test]
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
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
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

        [Test]
        public async Task DeleteAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DeleteAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteIfExistsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<bool> response = await blob.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [Test]
        public async Task DeleteIfExistsAsync_Exists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Response<bool> response = await blob.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
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

        [Test]
        [NonParallelizable]
        public async Task UndeleteAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await EnableSoftDelete();
            try
            {
                BlobBaseClient blob = await GetNewBlobClient(test.Container);
                await blob.DeleteAsync();

                // Act
                Response response = await blob.UndeleteAsync();

                // Assert
                response.Headers.TryGetValue("x-ms-version", out var version);
                Assert.IsNotNull(version);
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

        [Test]
        public async Task UndeleteAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.UndeleteAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));

        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

        }

        [Test]
        public async Task GetPropertiesAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateAsync();

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }


        [Test]
        public async Task GetPropertiesAsync_CpkError()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient httpBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            httpBlob = InstrumentClient(new AppendBlobClient(
                httpBlob.Uri,
                httpBlob.Pipeline,
                httpBlob.ClientDiagnostics,
                customerProvidedKey));
            Assert.AreEqual(Constants.Blob.Http, httpBlob.Uri.Scheme);
            AppendBlobClient httpsBlob = InstrumentClient(httpBlob.WithCustomerProvidedKey(customerProvidedKey));
            await httpsBlob.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                httpBlob.GetPropertiesAsync(),
                actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));

        }

        [Test]
        public async Task GetPropertiesAsync_ContainerSAS()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlockBlobClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Container(
                    containerName: containerName)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            var accountName = new BlobUriBuilder(test.Container.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => blob.AccountName);
            TestHelper.AssertCacheableProperty(containerName, () => blob.BlobContainerName);
            TestHelper.AssertCacheableProperty(blobName, () => blob.Name);

        }

        [Test]
        public async Task GetPropertiesAsync_ContainerIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            BlockBlobClient identitySasBlob = InstrumentClient(
                GetServiceClient_BlobServiceIdentitySas_Container(
                    containerName: containerName,
                    userDelegationKey: userDelegationKey)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName));

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

        }

        [Test]
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
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

        }

        [Test]
        public async Task GetPropertiesAsync_BlobIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();

            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            BlockBlobClient identitySasBlob = InstrumentClient(
                GetServiceClient_BlobServiceIdentitySas_Blob(
                    containerName: containerName,
                    blobName: blobName,
                    userDelegationKey: userDelegationKey)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName));

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

        }

        [Test]
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
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_SnapshotIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            BlockBlobClient identitySasBlob = InstrumentClient(
                GetServiceClient_BlobServiceIdentitySas_Container(
                    containerName: containerName,
                    userDelegationKey: userDelegationKey)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName)
                .WithSnapshot(snapshotResponse.Value.Snapshot));

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            }
        }

        [Test]
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
                Assert.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await blob.GetPropertiesAsync(
                            conditions: accessConditions)).Value;
                    });

            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPropertiesAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetHttpHeadersAsync()
        {
            var constants = new TestConstants(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            await blob.SetHttpHeadersAsync(new BlobHttpHeaders
            {
                CacheControl = constants.CacheControl,
                ContentDisposition = constants.ContentDisposition,
                ContentEncoding = constants.ContentEncoding,
                ContentLanguage = constants.ContentLanguage,
                ContentHash = constants.ContentMD5,
                ContentType = constants.ContentType
            });

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
            TestHelper.AssertSequenceEqual(constants.ContentMD5, response.Value.ContentHash);
            Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
        }

        [Test]
        public async Task SetHttpHeadersAsync_MultipleHeaders()
        {
            var constants = new TestConstants(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            await blob.SetHttpHeadersAsync(new BlobHttpHeaders
            {
                ContentEncoding = "deflate, gzip",
                ContentLanguage = "de-DE, en-CA",
            });

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.AreEqual("deflate,gzip", response.Value.ContentEncoding);
            Assert.AreEqual("de-DE,en-CA", response.Value.ContentLanguage);
        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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

        [Test]
        public async Task SetHttpHeadersAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetHttpHeadersAsync(new BlobHttpHeaders()),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await blob.SetMetadataAsync(metadata);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task SetMetadataAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateAsync();

            // Act
            await blob.SetMetadataAsync(metadata);
        }

        [Test]
        public async Task SetMetadataAsync_CpkError()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            AppendBlobClient httpBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            httpBlob = InstrumentClient(new AppendBlobClient(
                httpBlob.Uri,
                httpBlob.Pipeline,
                httpBlob.ClientDiagnostics,
                customerProvidedKey));
            Assert.AreEqual(Constants.Blob.Http, httpBlob.Uri.Scheme);
            AppendBlobClient httpsBlob = InstrumentClient(httpBlob.WithCustomerProvidedKey(customerProvidedKey));
            IDictionary<string, string> metadata = BuildMetadata();
            await httpsBlob.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                httpBlob.SetMetadataAsync(metadata),
                actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetMetadataAsync(metadata),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task CreateSnapshotAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

        }

        [Test]
        public async Task CreateSnapshotAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateAsync();

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

        }

        [Test]
        public async Task CreateSnapshotAsync_CpkHttpError()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            AppendBlobClient httpBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            httpBlob = InstrumentClient(new AppendBlobClient(
                httpBlob.Uri,
                httpBlob.Pipeline,
                httpBlob.ClientDiagnostics,
                customerProvidedKey));
            Assert.AreEqual(Constants.Blob.Http, httpBlob.Uri.Scheme);
            AppendBlobClient httpsBlob = InstrumentClient(httpBlob.WithCustomerProvidedKey(customerProvidedKey));
            await httpsBlob.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                httpBlob.CreateSnapshotAsync(),
                actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));

        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            }
        }

        [Test]
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

        [Test]
        public async Task CreateSnapshotAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateSnapshotAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task AcquireLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            Response<BlobLease> response = await InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(duration);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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

        [Test]
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
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
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
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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

        [Test]
        public async Task RenewLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).ReleaseAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
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
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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

        [Test]
        public async Task ReleaseLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).RenewAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
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
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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

        [Test]
        public async Task BreakLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient()).BreakAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
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
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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

        [Test]
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
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetTierAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response response = await blob.SetAccessTierAsync(AccessTier.Cool);

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
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
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
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
                e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
        }

        [Test]
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
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
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
            Assert.AreEqual("rehydrate-pending-to-cool", propertiesResponse.Value.ArchiveStatus);
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

        [Test]
        public void WithSnapshot()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();

            BlobServiceClient service = GetServiceClient_SharedKey();

            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobName));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);

            blob = InstrumentClient(blob.WithSnapshot("foo"));

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            blob = InstrumentClient(blob.WithSnapshot(null));

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        private async Task<BlobBaseClient> GetNewBlobClient(BlobContainerClient container, string blobName = default)
        {
            blobName ??= GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            return blob;
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
            => new RequestConditions
            {
                IfModifiedSince = parameters.IfModifiedSince,
                IfUnmodifiedSince = parameters.IfUnmodifiedSince,
                IfMatch = parameters.Match != null ? new ETag(parameters.Match) : default(ETag?),
                IfNoneMatch = parameters.NoneMatch != null ? new ETag(parameters.NoneMatch) : default(ETag?)
            };

        private BlobRequestConditions BuildAccessConditions(
            AccessConditionParameters parameters,
            bool lease = true)
        {
            var accessConditions = BuildRequestConditions(parameters).ToBlobRequestConditions();
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
            public string Match { get; set; }
            public string NoneMatch { get; set; }
            public string LeaseId { get; set; }
        }
    }
}
