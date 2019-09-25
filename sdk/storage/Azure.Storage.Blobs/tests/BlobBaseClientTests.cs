// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Common.Test;
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

            Assert.AreEqual(containerName, builder1.ContainerName);
            Assert.AreEqual(blobName, builder1.BlobName);
            Assert.AreEqual("accountName", builder1.AccountName);

            Assert.AreEqual(containerName, builder2.ContainerName);
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
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }

        #region Secondary Storage
        [Test]
        public async Task DownloadAsync_ReadFromSecondaryStorage()
        {
            using (GetNewContainer(out BlobContainerClient container, GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(1, out TestExceptionPolicy testExceptionPolicy)))
            {
                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blockBlobClient = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }

        [Test]
        public async Task DownloadAsync_ReadFromSecondaryStorageShouldNotPut()
        {
            BlobServiceClient serviceClient = GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(
                1,
                out TestExceptionPolicy testExceptionPolicy,
                false,
                new List<Core.Pipeline.RequestMethod>(new Core.Pipeline.RequestMethod[] { RequestMethod.Put }));

            using (GetNewContainer(out BlobContainerClient container, serviceClient))
            {
                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }
        #endregion

        [Test]
        public async Task DownloadAsync_CPK()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Act
                Response<BlobDownloadInfo> response = await blob.DownloadAsync();

                // Assert
                Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.Properties.EncryptionKeySha256);
            }
        }

        [Test]
        public async Task DownloadAsync_CpkHttpError()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient httpBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                httpBlob = InstrumentClient(new BlockBlobClient(
                    httpBlob.Uri,
                    httpBlob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));
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

            using (GetNewContainer(out BlobContainerClient container, service: service))
            {
                var data = GetRandomBuffer(Constants.KB);

                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }

        [Test]
        public async Task DownloadAsync_Range()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var data = GetRandomBuffer(10 * Constants.KB);
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }

        [Test]
        public async Task DownloadAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    var data = GetRandomBuffer(Constants.KB);
                    BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                    BlobAccessConditions accessConditions = BuildAccessConditions(parameters);

                    // Act
                    Response<BlobDownloadInfo> response = await blob.DownloadAsync(accessConditions: accessConditions);

                    // Assert
                    Assert.AreEqual(data.Length, response.Value.ContentLength);
                    var actual = new MemoryStream();
                    await response.Value.Content.CopyToAsync(actual);
                    TestHelper.AssertSequenceEqual(data, actual.ToArray());
                }
            }
        }

        [Test]
        public async Task DownloadAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    var data = GetRandomBuffer(Constants.KB);
                    BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    BlobAccessConditions accessConditions = BuildAccessConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.DownloadAsync(accessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task DownloadAsync_MD5()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var data = GetRandomBuffer(10 * Constants.KB);
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }

        [Test]
        public async Task DownloadAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.DownloadAsync(),
                    e => Assert.AreEqual("The specified blob does not exist.", e.Message.Split('\n')[0]));
            }
        }

        [Test]
        public async Task DownloadAsync_Overloads()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }
        #endregion Sequential Download

        #region Parallel Download

        private async Task ParallelDownloadFileAndVerify(
            long size,
            long singleBlockThreshold,
            ParallelTransferOptions parallelTransferOptions)
        {
            var data = GetRandomBuffer(size);
            var path = Path.GetTempFileName();

            try
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    var name = GetNewBlobName();
                    BlobClient blob = InstrumentClient(container.GetBlobClient(name));

                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }

                    var destination = new FileInfo(path);

                    // Create a special blob client for downloading that will
                    // assign client request IDs based on the range so that out
                    // of order operations still get predictable IDs and the
                    // recordings work correctly
                    var credential = new StorageSharedKeyCredential(this.TestConfigDefault.AccountName, this.TestConfigDefault.AccountKey);
                    var downloadingBlob = this.InstrumentClient(new BlobClient(blob.Uri, credential, GetOptions(true)));

                    await downloadingBlob.StagedDownloadAsync(
                        destination,
                        singleBlockThreshold: singleBlockThreshold,
                        parallelTransferOptions: parallelTransferOptions
                        );

                    using (FileStream resultStream = destination.OpenRead())
                    {
                        TestHelper.AssertSequenceEqual(data, resultStream.AsBytes());
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
            await ParallelDownloadFileAndVerify(size, Constants.KB, new ParallelTransferOptions { MaximumTransferLength = Constants.KB });

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
                await ParallelDownloadFileAndVerify(size, 16 * Constants.MB, new ParallelTransferOptions { MaximumThreadCount = maximumThreadCount });
            }
        }

        #endregion Parallel Download

        [Test]
        public async Task StartCopyFromUriAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(container);
                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

                // Assert
                // data copied within an account, so copy should be instantaneous
                if (Mode == RecordedTestMode.Playback)
                {
                    operation.PollingInterval = TimeSpan.FromMilliseconds(10);
                }
                await operation.WaitCompletionAsync();
                Assert.IsTrue(operation.HasCompleted);
                Assert.IsTrue(operation.HasValue);
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_Metadata()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(container);
                IDictionary<string, string> metadata = BuildMetadata();

                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await destBlob.StartCopyFromUriAsync(
                    source: srcBlob.Uri,
                    metadata: metadata);

                // Assert
                Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
                AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_Source_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient srcBlob = await GetNewBlobClient(container);

                    parameters.Match = await SetupBlobMatchCondition(srcBlob, parameters.Match);
                    parameters.LeaseId = await SetupBlobLeaseCondition(srcBlob, parameters.LeaseId, garbageLeaseId);
                    BlobAccessConditions sourceAccessConditions = BuildAccessConditions(
                        parameters: parameters);

                    BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                    // Act
                    Operation<long> response = await destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        sourceAccessConditions: sourceAccessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_Source_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient srcBlob = await GetNewBlobClient(container);

                    parameters.NoneMatch = await SetupBlobMatchCondition(srcBlob, parameters.NoneMatch);

                    BlobAccessConditions sourceAccessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: false);

                    BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        destBlob.StartCopyFromUriAsync(
                            source: srcBlob.Uri,
                            sourceAccessConditions: sourceAccessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_Destination_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    var data = GetRandomBuffer(Constants.KB);
                    BlockBlobClient srcBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await srcBlob.UploadAsync(stream);
                    }
                    BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                    // destBlob needs to exist so we can get its lease and etag
                    using (var stream = new MemoryStream(data))
                    {
                        await destBlob.UploadAsync(stream);
                    }

                    parameters.Match = await SetupBlobMatchCondition(destBlob, parameters.Match);
                    parameters.LeaseId = await SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                    BlobAccessConditions accessConditions = BuildAccessConditions(parameters: parameters);

                    // Act
                    Operation<long> response = await destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        destinationAccessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_Destination_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    var data = GetRandomBuffer(Constants.KB);
                    BlockBlobClient srcBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await srcBlob.UploadAsync(stream);
                    }

                    // destBlob needs to exist so we can get its etag
                    BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await destBlob.UploadAsync(stream);
                    }

                    parameters.NoneMatch = await SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                    BlobAccessConditions accessConditions = BuildAccessConditions(parameters: parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        destBlob.StartCopyFromUriAsync(
                            source: srcBlob.Uri,
                            destinationAccessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_AccessTier()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(container);
                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                    srcBlob.Uri,
                    accessTier: AccessTier.Cool);

                // Assert
                // data copied within an account, so copy should be instantaneous
                if (Mode == RecordedTestMode.Playback)
                {
                    operation.PollingInterval = TimeSpan.FromMilliseconds(10);
                }
                await operation.WaitCompletionAsync();
                Assert.IsTrue(operation.HasCompleted);
                Assert.IsTrue(operation.HasValue);
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient srcBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StartCopyFromUriAsync(srcBlob.Uri),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_RehydratePriority()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                var data2 = GetRandomBuffer(Constants.KB);
                BlockBlobClient srcBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
                    operation.PollingInterval = TimeSpan.FromMilliseconds(10);
                }
                await operation.WaitCompletionAsync();
                Assert.IsTrue(operation.HasCompleted);
                Assert.IsTrue(operation.HasValue);

                // Act
                await destBlob.SetTierAsync(AccessTier.Cool);
                Response<BlobProperties> propertiesResponse = await destBlob.GetPropertiesAsync();

                // Assert
                Assert.AreEqual("rehydrate-pending-to-cool", propertiesResponse.Value.ArchiveStatus);
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_RehydratePriorityFail()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(container);
                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StartCopyFromUriAsync(
                        srcBlob.Uri,
                        accessTier: AccessTier.Archive,
                        rehydratePriority: "None"),
                    e => Assert.AreEqual("InvalidHeaderValue", e.ErrorCode));
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_AccessTierFail()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(container);
                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StartCopyFromUriAsync(
                    srcBlob.Uri,
                    accessTier: AccessTier.P20),
                    e => Assert.AreEqual(BlobErrorCode.InvalidHeaderValue.ToString(), e.ErrorCode));
            }
        }

        [Test]
        public async Task AbortCopyFromUriAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
                var data = GetRandomBuffer(8 * Constants.MB);

                BlockBlobClient srcBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }

                BlobServiceClient secondaryService = GetServiceClient_SecondaryAccount_SharedKey();
                using (GetNewContainer(out BlobContainerClient destContainer, service: secondaryService))
                {
                    BlockBlobClient destBlob = InstrumentClient(destContainer.GetBlockBlobClient(GetNewBlobName()));

                    Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

                    // Act
                    try
                    {
                        Response response = await destBlob.AbortCopyFromUriAsync(operation.Id);

                        // Assert
                        Assert.IsNotNull(response.Headers.RequestId);
                    }
                    catch (StorageRequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                    {
                        WarnCopyCompletedTooQuickly();
                    }
                }
            }
        }

        [Test]
        public async Task AbortCopyFromUriAsync_Lease()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
                var data = GetRandomBuffer(8 * Constants.MB);

                BlockBlobClient srcBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }
                BlobServiceClient secondaryService = GetServiceClient_SecondaryAccount_SharedKey();
                using (GetNewContainer(out BlobContainerClient destContainer, service: secondaryService))
                {
                    BlockBlobClient destBlob = InstrumentClient(destContainer.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await destBlob.UploadAsync(stream);
                    }

                    TimeSpan duration = LeaseClient.InfiniteLeaseDuration;
                    LeaseClient lease = InstrumentClient(destBlob.GetLeaseClient(Recording.Random.NewGuid().ToString()));
                    Response<Lease> leaseResponse = await lease.AcquireAsync(duration);

                    Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        destinationAccessConditions: new BlobAccessConditions
                        {
                            LeaseAccessConditions = new LeaseAccessConditions
                            {
                                LeaseId = leaseResponse.Value.LeaseId
                            }
                        });


                    // Act
                    try
                    {
                        Response response = await destBlob.AbortCopyFromUriAsync(
                            copyId: operation.Id,
                            leaseAccessConditions: new LeaseAccessConditions
                            {
                                LeaseId = leaseResponse.Value.LeaseId
                            });

                        // Assert
                        Assert.IsNotNull(response.Headers.RequestId);
                    }
                    catch (StorageRequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                    {
                        WarnCopyCompletedTooQuickly();
                    }
                }
            }
        }

        [Test]
        public async Task AbortCopyFromUriAsync_LeaseFail()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
                var data = GetRandomBuffer(8 * Constants.MB);

                BlockBlobClient srcBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }
                BlobServiceClient secondaryService = GetServiceClient_SecondaryAccount_SharedKey();
                using (GetNewContainer(out BlobContainerClient destContainer, service: secondaryService))
                {
                    BlockBlobClient destBlob = InstrumentClient(destContainer.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await destBlob.UploadAsync(stream);
                    }

                    Operation<long> operation = await destBlob.StartCopyFromUriAsync(source: srcBlob.Uri);

                    var leaseId = Recording.Random.NewGuid().ToString();

                    // Act
                    try
                    {
                        await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                            destBlob.AbortCopyFromUriAsync(
                                copyId: operation.Id,
                                leaseAccessConditions: new LeaseAccessConditions
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
                    catch (StorageRequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                    {
                        WarnCopyCompletedTooQuickly();
                    }
                }
            }
        }

        [Test]
        public async Task AbortCopyFromUriAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var copyId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.AbortCopyFromUriAsync(copyId),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task DeleteAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                // Act
                Response response = await blob.DeleteAsync();

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        public async Task DeleteAsync_Options()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);
                await blob.CreateSnapshotAsync();

                // Act
                await blob.DeleteAsync(deleteOptions: DeleteSnapshotsOption.Only);

                // Assert
                Response<BlobProperties> response = await blob.GetPropertiesAsync();
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task DeleteAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                    BlobAccessConditions accessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response response = await blob.DeleteAsync(accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task DeleteAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    BlobAccessConditions accessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.DeleteAsync(accessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.DeleteAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
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
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await EnableSoftDelete();
                try
                {
                    BlobBaseClient blob = await GetNewBlobClient(container);
                    await blob.DeleteAsync();

                    // Act
                    Response response = await blob.UndeleteAsync();

                    // Assert
                    response.Headers.TryGetValue("x-ms-version", out var version);
                    Assert.IsNotNull(version);
                }
                catch (StorageRequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
                {
                    Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
                }
                finally
                {
                    // Cleanup
                    await DisableSoftDelete();
                }
            }
        }

        [Test]
        public async Task UndeleteAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.UndeleteAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                // Act
                Response<BlobProperties> response = await blob.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_CPK()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
                await blob.CreateAsync();

                // Act
                Response<BlobProperties> response = await blob.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_CpkError()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                AppendBlobClient httpBlob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                httpBlob = InstrumentClient(new AppendBlobClient(
                    httpBlob.Uri,
                    httpBlob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));
                Assert.AreEqual(Constants.Blob.Http, httpBlob.Uri.Scheme);
                AppendBlobClient httpsBlob = InstrumentClient(new AppendBlobClient(
                    GetHttpsUri(httpBlob.Uri),
                    httpBlob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));
                await httpsBlob.CreateAsync();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    httpBlob.GetPropertiesAsync(),
                    actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
            }
        }

        [Test]
        public async Task GetPropertiesAsync_ContainerSAS()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            using (GetNewContainer(out BlobContainerClient container, containerName: containerName))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container, blobName);

                BlockBlobClient sasBlob = InstrumentClient(
                    GetServiceClient_BlobServiceSas_Container(
                        containerName: containerName)
                    .GetBlobContainerClient(containerName)
                    .GetBlockBlobClient(blobName));

                // Act
                Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_ContainerIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            using (GetNewContainer(out BlobContainerClient container, containerName: containerName, service: oauthService))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container, blobName);

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
        }

        [Test]
        public async Task GetPropertiesAsync_BlobSAS()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            using (GetNewContainer(out BlobContainerClient container, containerName: containerName))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container, blobName);

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
        }

        [Test]
        public async Task GetPropertiesAsync_BlobIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            using (GetNewContainer(out BlobContainerClient container, containerName: containerName, service: oauthService))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container, blobName);

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
        }

        [Test]
        public async Task GetPropertiesAsync_SnapshotSAS()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            using (GetNewContainer(out BlobContainerClient container, containerName: containerName))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container, blobName);
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
        }

        [Test]
        public async Task GetPropertiesAsync_SnapshotIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            using (GetNewContainer(out BlobContainerClient container, containerName: containerName, service: oauthService))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container, blobName);
                Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
        }

        [Test]
        public async Task GetPropertiesAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                    BlobAccessConditions accessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<BlobProperties> response = await blob.GetPropertiesAsync(accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task GetPropertiesAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    BlobAccessConditions accessConditions = BuildAccessConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.GetPropertiesAsync(accessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.GetPropertiesAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task SetHttpHeadersAsync()
        {
            var constants = new TestConstants(this);
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                // Act
                await blob.SetHttpHeadersAsync(new BlobHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                });

                // Assert
                Response<BlobProperties> response = await blob.GetPropertiesAsync();
                Assert.AreEqual(constants.ContentType, response.Value.ContentType);
                TestHelper.AssertSequenceEqual(constants.ContentMD5, response.Value.ContentHash);
                Assert.AreEqual(1, response.Value.ContentEncoding.Count());
                Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding.First());
                Assert.AreEqual(1, response.Value.ContentLanguage.Count());
                Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage.First());
                Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
            }
        }

        [Test]
        public async Task SetHttpHeadersAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                    BlobAccessConditions accessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<BlobInfo> response = await blob.SetHttpHeadersAsync(
                        httpHeaders: new BlobHttpHeaders(),
                        accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task SetHttpHeadersAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    BlobAccessConditions accessConditions = BuildAccessConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.SetHttpHeadersAsync(
                            httpHeaders: new BlobHttpHeaders(),
                            accessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task SetHttpHeadersAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.SetHttpHeadersAsync(new BlobHttpHeaders()),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                await blob.SetMetadataAsync(metadata);

                // Assert
                Response<BlobProperties> response = await blob.GetPropertiesAsync();
                AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task SetMetadataAsync_CPK()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
                IDictionary<string, string> metadata = BuildMetadata();
                await blob.CreateAsync();

                // Act
                await blob.SetMetadataAsync(metadata);
            }
        }

        [Test]
        public async Task SetMetadataAsync_CpkError()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                AppendBlobClient httpBlob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                httpBlob = InstrumentClient(new AppendBlobClient(
                    httpBlob.Uri,
                    httpBlob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));
                Assert.AreEqual(Constants.Blob.Http, httpBlob.Uri.Scheme);
                AppendBlobClient httpsBlob = InstrumentClient(httpBlob.WithCustomerProvidedKey(customerProvidedKey));
                IDictionary<string, string> metadata = BuildMetadata();
                await httpsBlob.CreateAsync();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    httpBlob.SetMetadataAsync(metadata),
                    actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
            }
        }

        [Test]
        public async Task SetMetadataAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);
                    IDictionary<string, string> metadata = BuildMetadata();

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                    BlobAccessConditions accessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<BlobInfo> response = await blob.SetMetadataAsync(
                        metadata: metadata,
                        accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task SetMetadataAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);
                    IDictionary<string, string> metadata = BuildMetadata();

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    BlobAccessConditions accessConditions = BuildAccessConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.SetMetadataAsync(
                            metadata: metadata,
                            accessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.SetMetadataAsync(metadata),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task CreateSnapshotAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                // Act
                Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task CreateSnapshotAsync_CPK()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
                await blob.CreateAsync();

                // Act
                Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task CreateSnapshotAsync_CpkHttpError()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                AppendBlobClient httpBlob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                httpBlob = InstrumentClient(new AppendBlobClient(
                    httpBlob.Uri,
                    httpBlob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));
                Assert.AreEqual(Constants.Blob.Http, httpBlob.Uri.Scheme);
                AppendBlobClient httpsBlob = InstrumentClient(httpBlob.WithCustomerProvidedKey(customerProvidedKey));
                await httpsBlob.CreateAsync();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    httpBlob.CreateSnapshotAsync(),
                    actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
            }
        }

        [Test]
        public async Task CreateSnapshotAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                    BlobAccessConditions accessConditions = BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync(accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task CreateSnapshotAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    BlobAccessConditions accessConditions = BuildAccessConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.CreateSnapshotAsync(accessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task CreateSnapshotAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CreateSnapshotAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task AcquireLeaseAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                Response<Lease> response = await InstrumentClient(blob.GetLeaseClient(leaseId)).AcquireAsync(duration);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task AcquireLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    var leaseId = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(
                        parameters: parameters);

                    // Act
                    Response<Lease> response = await InstrumentClient(blob.GetLeaseClient(leaseId)).AcquireAsync(
                        duration: duration,
                        httpAccessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task AcquireLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    var leaseId = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        InstrumentClient(blob.GetLeaseClient(leaseId)).AcquireAsync(
                            duration: duration,
                            httpAccessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task AcquireLeaseAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    InstrumentClient(blob.GetLeaseClient(leaseId)).AcquireAsync(duration),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task RenewLeaseAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                await lease.AcquireAsync(duration);

                // Act
                Response<Lease> response = await lease.RenewAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task RenewLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    var leaseId = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(
                        parameters: parameters);

                    LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                    await lease.AcquireAsync(duration: duration);

                    // Act
                    Response<Lease> response = await lease.RenewAsync(httpAccessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task RenewLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    var leaseId = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(parameters);

                    LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                    await lease.AcquireAsync(duration: duration);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        lease.RenewAsync(httpAccessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task RenewLeaseAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var leaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    InstrumentClient(blob.GetLeaseClient(leaseId)).ReleaseAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                await lease.AcquireAsync(duration);

                // Act
                Response<ReleasedObjectInfo> response = await lease.ReleaseAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    var leaseId = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(
                        parameters: parameters);

                    LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                    await lease.AcquireAsync(duration: duration);

                    // Act
                    Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(httpAccessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    var leaseId = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(parameters);

                    LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                    await lease.AcquireAsync(duration: duration);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        lease.ReleaseAsync(httpAccessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var leaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    InstrumentClient(blob.GetLeaseClient(leaseId)).RenewAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task BreakLeaseAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                await lease.AcquireAsync(duration);

                // Act
                Response<Lease> response = await lease.BreakAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task BreakLeaseAsync_BreakPeriod()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                var breakPeriod = 5;

                LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                await lease.AcquireAsync(duration);

                // Act
                Response<Lease> response = await lease.BreakAsync(breakPeriodInSeconds: breakPeriod);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task BreakLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    var leaseId = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(
                        parameters: parameters);

                    LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                    await lease.AcquireAsync(duration: duration);

                    // Act
                    Response<Lease> response = await lease.BreakAsync(httpAccessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task BreakLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    var leaseId = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(parameters);

                    LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                    await lease.AcquireAsync(duration: duration);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        lease.BreakAsync(httpAccessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task BreakLeaseAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    InstrumentClient(blob.GetLeaseClient()).BreakAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task ChangeLeaseAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                await lease.AcquireAsync(duration);

                // Act
                Response<Lease> response = await lease.ChangeAsync(newLeaseId);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task ChangeLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    var leaseId = Recording.Random.NewGuid().ToString();
                    var newLeaseId = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(
                        parameters: parameters);

                    LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                    await lease.AcquireAsync(duration: duration);

                    // Act
                    Response<Lease> response = await lease.ChangeAsync(
                        proposedId: newLeaseId,
                        httpAccessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task ChangeLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlobBaseClient blob = await GetNewBlobClient(container);

                    var leaseId = Recording.Random.NewGuid().ToString();
                    var newLeaseId = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(parameters);

                    LeaseClient lease = InstrumentClient(blob.GetLeaseClient(leaseId));
                    await lease.AcquireAsync(duration: duration);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        lease.ChangeAsync(
                            proposedId: newLeaseId,
                            httpAccessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task ChangeLeaseAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    InstrumentClient(blob.GetLeaseClient(leaseId)).ChangeAsync(proposedId: newLeaseId),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task SetTierAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                // Act
                Response response = await blob.SetTierAsync(AccessTier.Cool);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        public async Task SetTierAsync_Lease()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                await InstrumentClient(blob.GetLeaseClient(leaseId)).AcquireAsync(duration);

                // Act
                Response response = await blob.SetTierAsync(
                    accessTier: AccessTier.Cool,
                    leaseAccessConditions: new LeaseAccessConditions
                    {
                        LeaseId = leaseId
                    });

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        public async Task SetTierAsync_LeaseFail()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var data = GetRandomBuffer(Constants.KB);

                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var leaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.SetTierAsync(
                        accessTier: AccessTier.Cool,
                        leaseAccessConditions: new LeaseAccessConditions
                        {
                            LeaseId = leaseId
                        }),
                    e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
            }
        }

        [Test]
        public async Task SetTierAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.SetTierAsync(AccessTier.Cool),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task SetTierAsync_Rehydrate()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // arrange
                BlobBaseClient blob = await GetNewBlobClient(container);
                await blob.SetTierAsync(AccessTier.Archive);

                // Act
                Response setTierResponse = await blob.SetTierAsync(
                    accessTier: AccessTier.Cool,
                    rehydratePriority: RehydratePriority.High);
                Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();

                // Assert
                Assert.AreEqual("rehydrate-pending-to-cool", propertiesResponse.Value.ArchiveStatus);
            }
        }

        [Test]
        public async Task SetTierAsync_RehydrateFail()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {

                // arrange
                BlobBaseClient blob = await GetNewBlobClient(container);
                await blob.SetTierAsync(AccessTier.Archive);

                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.SetTierAsync(accessTier: AccessTier.Cool, rehydratePriority: "None"),
                    e => Assert.AreEqual("InvalidHeaderValue", e.ErrorCode));
            }
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
            blobName = blobName ?? GetNewBlobName();
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

        private HttpAccessConditions BuildHttpAccessConditions(
            AccessConditionParameters parameters)
            => new HttpAccessConditions
            {
                IfModifiedSince = parameters.IfModifiedSince,
                IfUnmodifiedSince = parameters.IfUnmodifiedSince,
                IfMatch = parameters.Match != null ? new ETag(parameters.Match) : default(ETag?),
                IfNoneMatch = parameters.NoneMatch != null ? new ETag(parameters.NoneMatch) : default(ETag?)
            };

        private BlobAccessConditions BuildAccessConditions(
            AccessConditionParameters parameters,
            bool lease = true)
        {
            var accessConditions = new BlobAccessConditions
            {
                HttpAccessConditions = BuildHttpAccessConditions(parameters)
            };
            if (lease)
            {
                accessConditions.LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = parameters.LeaseId
                };
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
