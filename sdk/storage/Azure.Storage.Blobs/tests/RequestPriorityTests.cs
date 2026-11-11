// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class RequestPriorityTests : BlobTestBase
    {
        /// <summary>
        /// Priority the service applies when no priority, or an out-of-range priority, is sent.
        /// </summary>
        private const int DefaultEffectivePriority = 3;

        /// <summary>
        /// Priority used by tests that only verify RequestPriority is plumbed through and EffectiveRequestPriority is read back.
        /// Any value other than <see cref="DefaultEffectivePriority"/> fails if the header is dropped.
        /// </summary>
        private const int Priority = 5;

        public RequestPriorityTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Effective priority the service is expected to return for the given requested priority.
        /// Unset or out-of-range (outside 0-7) values fall back to the service default.
        /// </summary>
        private static int ExpectedEffectivePriority(int? requested)
            => requested is >= 0 and <= 7 ? requested.Value : DefaultEffectivePriority;

        /// <summary>
        /// Asserts the effective priority on a raw response, for APIs without a result model.
        /// </summary>
        private static void AssertRawPriority(Response response, int? requested)
        {
            Assert.IsTrue(response.Headers.TryGetValue("x-ms-request-priority", out string effectivePriority));
            Assert.AreEqual(ExpectedEffectivePriority(requested).ToString(), effectivePriority);
        }

        private string NewBlockId()
            => Convert.ToBase64String(Recording.Random.NewGuid().ToByteArray());

        private async Task<BlobClient> CreateBlobAsync(BlobContainerClient container)
        {
            BlobClient blob = InstrumentClient(container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));
            return blob;
        }

        #region Block blob
        [RecordedTest]
        public async Task GetBlockList_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(GetRandomBuffer(Constants.KB)));

            Response<BlockList> response = await blob.GetBlockListAsync(
                new BlockBlobGetBlockListOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task SyncUploadFromUri_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient source = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            await source.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));
            Uri sourceUri = source.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1));
            BlockBlobClient destination = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            Response<BlobContentInfo> response = await destination.SyncUploadFromUriAsync(
                sourceUri,
                new BlobSyncUploadFromUriOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task StageBlock_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            Response<BlockInfo> response = await blob.StageBlockAsync(
                NewBlockId(),
                new MemoryStream(GetRandomBuffer(Constants.KB)),
                new BlockBlobStageBlockOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task StageBlockFromUri_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient source = await CreateBlobAsync(test.Container);
            Uri sourceUri = source.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1));
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            Response<BlockInfo> response = await blob.StageBlockFromUriAsync(
                sourceUri,
                NewBlockId(),
                new StageBlockFromUriOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task CommitBlockList_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            string blockId = NewBlockId();
            await blob.StageBlockAsync(blockId, new MemoryStream(GetRandomBuffer(Constants.KB)));

            Response<BlobContentInfo> response = await blob.CommitBlockListAsync(
                new[] { blockId },
                new CommitBlockListOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task Query_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(System.Text.Encoding.UTF8.GetBytes("a,b\n1,2\n")));

            Response<BlobDownloadInfo> response = await blob.QueryAsync(
                "SELECT * from BlobStorage",
                new BlobQueryOptions { RequestPriority = priority });
            response.Value.Dispose();

            AssertRawPriority(response.GetRawResponse(), priority);
        }
        #endregion

        #region Append blob
        [RecordedTest]
        public async Task AppendBlobCreate_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));

            Response<BlobContentInfo> response = await blob.CreateAsync(
                new AppendBlobCreateOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task AppendBlock_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();

            Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                new MemoryStream(GetRandomBuffer(Constants.KB)),
                new AppendBlobAppendBlockOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task AppendBlockFromUri_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient source = await CreateBlobAsync(test.Container);
            Uri sourceUri = source.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1));
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();

            Response<BlobAppendInfo> response = await blob.AppendBlockFromUriAsync(
                sourceUri,
                new AppendBlobAppendBlockFromUriOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task Seal_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();

            Response<BlobInfo> response = await blob.SealAsync(
                new AppendBlobSealOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }
        #endregion

        #region Page blob
        [RecordedTest]
        public async Task GetAllPageRanges_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(4 * Constants.KB);
            await blob.UploadPagesAsync(new MemoryStream(GetRandomBuffer(512)), 0);
            await blob.UploadPagesAsync(new MemoryStream(GetRandomBuffer(512)), 2 * Constants.KB);

            int pages = 0;
            await foreach (Page<PageRangeItem> page in blob
                .GetAllPageRangesAsync(new GetPageRangesOptions { RequestPriority = priority })
                .AsPages(pageSizeHint: 1))
            {
                Assert.IsTrue(page.GetRawResponse().Headers.TryGetValue("x-ms-request-priority", out string effectivePriority));
                Assert.AreEqual(ExpectedEffectivePriority(priority).ToString(), effectivePriority);
                pages++;
            }

            Assert.GreaterOrEqual(pages, 2);
        }

        [RecordedTest]
        public async Task GetAllPageRangesDiff_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(4 * Constants.KB);
            Response<BlobSnapshotInfo> snapshot = await blob.CreateSnapshotAsync();
            await blob.UploadPagesAsync(new MemoryStream(GetRandomBuffer(512)), 0);
            await blob.UploadPagesAsync(new MemoryStream(GetRandomBuffer(512)), 2 * Constants.KB);

            int pages = 0;
            await foreach (Page<PageRangeItem> page in blob
                .GetAllPageRangesDiffAsync(new GetPageRangesDiffOptions { PreviousSnapshot = snapshot.Value.Snapshot, RequestPriority = priority })
                .AsPages(pageSizeHint: 1))
            {
                Assert.IsTrue(page.GetRawResponse().Headers.TryGetValue("x-ms-request-priority", out string effectivePriority));
                Assert.AreEqual(ExpectedEffectivePriority(priority).ToString(), effectivePriority);
                pages++;
            }

            Assert.GreaterOrEqual(pages, 2);
        }

        [RecordedTest]
        public async Task PageBlobCreate_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

            Response<BlobContentInfo> response = await blob.CreateAsync(
                Constants.KB,
                new PageBlobCreateOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task UploadPages_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(Constants.KB);

            Response<PageInfo> response = await blob.UploadPagesAsync(
                new MemoryStream(GetRandomBuffer(512)),
                0,
                new PageBlobUploadPagesOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task UploadPagesFromUri_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient source = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await source.CreateAsync(Constants.KB);
            await source.UploadPagesAsync(new MemoryStream(GetRandomBuffer(512)), 0);
            Uri sourceUri = source.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1));
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(Constants.KB);

            Response<PageInfo> response = await blob.UploadPagesFromUriAsync(
                sourceUri,
                new HttpRange(0, 512),
                new HttpRange(0, 512),
                new PageBlobUploadPagesFromUriOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task ClearPages_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(Constants.KB);

            Response<PageInfo> response = await blob.ClearPagesAsync(
                new HttpRange(0, 512),
                new PageBlobClearPagesOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task Resize_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(Constants.KB);

            Response<PageBlobInfo> response = await blob.ResizeAsync(
                2 * Constants.KB,
                new PageBlobResizeOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task UpdateSequenceNumber_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(Constants.KB);

            Response<PageBlobInfo> response = await blob.UpdateSequenceNumberAsync(
                SequenceNumberAction.Update,
                new PageBlobUpdateSequenceNumberOptions { SequenceNumber = 5, RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }
        #endregion

        #region Blob
        [RecordedTest]
        public async Task Upload_SingleShot_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));

            Response<BlobContentInfo> response = await blob.UploadAsync(
                BinaryData.FromBytes(GetRandomBuffer(Constants.KB)),
                new BlobUploadOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task Upload_Staged_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));

            Response<BlobContentInfo> response = await blob.UploadAsync(
                BinaryData.FromBytes(GetRandomBuffer(4 * Constants.KB)),
                new BlobUploadOptions
                {
                    RequestPriority = priority,
                    TransferOptions = new StorageTransferOptions
                    {
                        InitialTransferSize = Constants.KB,
                        MaximumTransferSize = Constants.KB,
                    },
                });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task GetProperties_RequestPriority([Values(null, 0, 5, 7, -1, 8)] int? priority)
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));

            Response<BlobProperties> response = await blob.GetPropertiesAsync(
                new BlobGetPropertiesOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task DownloadStreaming_RequestPriority([Values(null, 0, 5, 7, -1, 8)] int? priority)
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));

            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(
                new BlobDownloadOptions { RequestPriority = priority });
            using BlobDownloadStreamingResult result = response.Value;

            Assert.AreEqual(ExpectedEffectivePriority(priority), result.Details.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task DownloadContent_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));

            Response<BlobDownloadResult> response = await blob.DownloadContentAsync(
                new BlobDownloadOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.Details.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task DownloadTo_Partitioned_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(4 * Constants.KB)));

            // Partitioned download: one ranged request per 1 KB partition.
            Response response = await blob.DownloadToAsync(Stream.Null, new BlobDownloadToOptions
            {
                RequestPriority = priority,
                TransferOptions = new StorageTransferOptions
                {
                    InitialTransferSize = Constants.KB,
                    MaximumTransferSize = Constants.KB,
                },
            });

            // DownloadTo returns a raw Response, so the effective priority is read from its header.
            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task SetMetadata_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));

            Response<BlobInfo> response = await blob.SetMetadataAsync(
                new Dictionary<string, string> { { "foo", "bar" } },
                new BlobSetMetadataOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task GetTags_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));

            Response<GetBlobTagResult> response = await blob.GetTagsAsync(
                new BlobGetTagsOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task CreateSnapshot_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            await blob.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));

            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync(
                new BlobCreateSnapshotOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task SyncCopyFromUri_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient source = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            await source.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));
            Uri sourceUri = source.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1));
            BlobClient destination = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));

            Response<BlobCopyInfo> response = await destination.SyncCopyFromUriAsync(
                sourceUri,
                new BlobCopyFromUriOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task StartCopyFromUri_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient source = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            await source.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));
            BlobClient destination = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));

            CopyFromUriOperation operation = await destination.StartCopyFromUriAsync(
                source.Uri,
                new BlobCopyFromUriOptions { RequestPriority = priority });
            await operation.WaitForCompletionAsync();

            // The copy operation exposes the most recent response (start or status poll).
            AssertRawPriority(operation.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task SetHttpHeaders_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);

            Response<BlobInfo> response = await blob.SetHttpHeadersAsync(
                new BlobSetHttpHeadersOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = "text/plain" },
                    RequestPriority = priority,
                });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task SetTags_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);

            Response response = await blob.SetTagsAsync(
                new Dictionary<string, string> { { "foo", "bar" } },
                new BlobSetTagsOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task SetAccessTier_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);

            Response response = await blob.SetAccessTierAsync(
                AccessTier.Cool,
                new BlobSetAccessTierOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task Delete_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);

            Response response = await blob.DeleteAsync(
                new BlobDeleteOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task DeleteIfExists_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);

            Response<bool> response = await blob.DeleteIfExistsAsync(
                new BlobDeleteIfExistsOptions { RequestPriority = priority });

            Assert.IsTrue(response.Value);
            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task Exists_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);

            Response<bool> response = await blob.ExistsAsync(
                new BlobExistsOptions { RequestPriority = priority });

            Assert.IsTrue(response.Value);
            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task Undelete_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);

            Response response = await blob.UndeleteAsync(
                new BlobUndeleteOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task BlobGetAccountInfo_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);

            Response<AccountInfo> response = await blob.GetAccountInfoAsync(
                new BlobGetAccountInfoOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }
        #endregion

        #region Lease
        [RecordedTest]
        public async Task LeaseAcquire_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);
            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(Recording.Random.NewGuid().ToString()));

            Response<BlobLease> response = await lease.AcquireAsync(
                TimeSpan.FromSeconds(15),
                new BlobLeaseAcquireOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
            await lease.ReleaseAsync();
        }

        [RecordedTest]
        public async Task LeaseRenew_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);
            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(Recording.Random.NewGuid().ToString()));
            await lease.AcquireAsync(TimeSpan.FromSeconds(15));

            Response<BlobLease> response = await lease.RenewAsync(
                new BlobLeaseRenewOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
            await lease.ReleaseAsync();
        }

        [RecordedTest]
        public async Task LeaseChange_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);
            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(Recording.Random.NewGuid().ToString()));
            await lease.AcquireAsync(TimeSpan.FromSeconds(15));

            Response<BlobLease> response = await lease.ChangeAsync(
                Recording.Random.NewGuid().ToString(),
                new BlobLeaseChangeOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
            await lease.ReleaseAsync();
        }

        [RecordedTest]
        public async Task LeaseRelease_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);
            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(Recording.Random.NewGuid().ToString()));
            await lease.AcquireAsync(TimeSpan.FromSeconds(15));

            Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(
                new BlobLeaseReleaseOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task LeaseBreak_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);
            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(Recording.Random.NewGuid().ToString()));
            await lease.AcquireAsync(TimeSpan.FromSeconds(15));

            Response<BlobLease> response = await lease.BreakAsync(
                new BlobLeaseBreakOptions { BreakPeriod = TimeSpan.Zero, RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }
        #endregion

        #region Container
        [RecordedTest]
        public async Task ContainerCreate_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            try
            {
                Response<BlobContainerInfo> response = await container.CreateAsync(
                    new BlobContainerCreateOptions { RequestPriority = priority });

                Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task ContainerCreateIfNotExists_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            try
            {
                Response<BlobContainerInfo> response = await container.CreateIfNotExistsAsync(
                    new BlobContainerCreateIfNotExistsOptions { RequestPriority = priority });

                Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task ContainerUploadBlob_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();

            Response<BlobContentInfo> response = await test.Container.UploadBlobAsync(
                GetNewBlobName(),
                new MemoryStream(GetRandomBuffer(Constants.KB)),
                new BlobContainerUploadBlobOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task GetBlobs_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            for (int i = 0; i < 2; i++)
            {
                await test.Container.GetBlobClient(GetNewBlobName()).UploadAsync(BinaryData.FromString("data"));
            }

            List<BlobItem> items = new List<BlobItem>();
            await foreach (Page<BlobItem> page in test.Container
                .GetBlobsAsync(new GetBlobsOptions { RequestPriority = priority })
                .AsPages(pageSizeHint: 1))
            {
                AssertRawPriority(page.GetRawResponse(), priority);
                items.AddRange(page.Values);
            }

            Assert.AreEqual(2, items.Count);
        }

        [RecordedTest]
        public async Task GetBlobsByHierarchy_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            await test.Container.GetBlobClient($"dir/{GetNewBlobName()}").UploadAsync(BinaryData.FromString("data"));
            await test.Container.GetBlobClient(GetNewBlobName()).UploadAsync(BinaryData.FromString("data"));

            int pages = 0;
            await foreach (Page<BlobHierarchyItem> page in test.Container
                .GetBlobsByHierarchyAsync(new GetBlobsByHierarchyOptions { Delimiter = "/", RequestPriority = priority })
                .AsPages(pageSizeHint: 1))
            {
                AssertRawPriority(page.GetRawResponse(), priority);
                pages++;
            }

            Assert.GreaterOrEqual(pages, 2);
        }

        [RecordedTest]
        public async Task ContainerFindBlobsByTags_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            string tagValue = GetNewBlobName();
            await test.Container.GetBlobClient(GetNewBlobName()).UploadAsync(
                BinaryData.FromString("data"),
                new BlobUploadOptions { Tags = new Dictionary<string, string> { { "priorityTag", tagValue } } });

            // It takes a few seconds for Find Blobs by Tags to pick up new changes.
            await Delay(2000);

            int pages = 0;
            await foreach (Page<TaggedBlobItem> page in test.Container
                .FindBlobsByTagsAsync($"\"priorityTag\"='{tagValue}'", new BlobContainerFindBlobsByTagsOptions { RequestPriority = priority })
                .AsPages())
            {
                AssertRawPriority(page.GetRawResponse(), priority);
                pages++;
            }

            Assert.GreaterOrEqual(pages, 1);
        }

        [RecordedTest]
        public async Task ContainerGetProperties_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();

            Response<BlobContainerProperties> response = await test.Container.GetPropertiesAsync(
                new BlobContainerGetPropertiesOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task ContainerSetMetadata_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();

            Response<BlobContainerInfo> response = await test.Container.SetMetadataAsync(
                new Dictionary<string, string> { { "foo", "bar" } },
                new BlobContainerSetMetadataOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task ContainerGetAccessPolicy_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();

            Response<BlobContainerAccessPolicy> response = await test.Container.GetAccessPolicyAsync(
                new BlobContainerGetAccessPolicyOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task ContainerSetAccessPolicy_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();

            Response<BlobContainerInfo> response = await test.Container.SetAccessPolicyAsync(
                new BlobContainerSetAccessPolicyOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task ContainerExists_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();

            Response<bool> response = await test.Container.ExistsAsync(
                new BlobContainerExistsOptions { RequestPriority = priority });

            Assert.IsTrue(response.Value);
            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task ContainerGetAccountInfo_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();

            Response<AccountInfo> response = await test.Container.GetAccountInfoAsync(
                new BlobContainerGetAccountInfoOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task ContainerDelete_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            Response response = await container.DeleteAsync(
                new BlobContainerDeleteOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task ContainerDeleteIfExists_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            Response<bool> response = await container.DeleteIfExistsAsync(
                new BlobContainerDeleteIfExistsOptions { RequestPriority = priority });

            Assert.IsTrue(response.Value);
            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task ContainerDeleteBlob_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = await CreateBlobAsync(test.Container);

            Response response = await test.Container.DeleteBlobAsync(
                blob.Name,
                new BlobContainerDeleteBlobOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }
        #endregion

        #region Service
        [RecordedTest]
        public async Task GetUserDelegationKey_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = GetServiceClient_OAuth();

            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(
                new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1)) { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task ServiceGetProperties_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();

            Response<BlobServiceProperties> response = await service.GetPropertiesAsync(
                new BlobServiceGetPropertiesOptions { RequestPriority = priority });

            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task GetBlobContainers_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            await using DisposingContainer test1 = await GetTestContainerAsync(service);
            await using DisposingContainer test2 = await GetTestContainerAsync(service);

            int pages = 0;
            await foreach (Page<BlobContainerItem> page in service
                .GetBlobContainersAsync(new BlobServiceGetBlobContainersOptions { RequestPriority = priority })
                .AsPages(pageSizeHint: 1))
            {
                AssertRawPriority(page.GetRawResponse(), priority);
                if (++pages >= 2)
                {
                    break;
                }
            }

            Assert.AreEqual(2, pages);
        }

        [RecordedTest]
        public async Task ServiceSetProperties_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobServiceProperties properties = await service.GetPropertiesAsync();

            Response response = await service.SetPropertiesAsync(
                properties,
                new BlobServiceSetPropertiesOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task ServiceGetAccountInfo_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();

            Response<AccountInfo> response = await service.GetAccountInfoAsync(
                new BlobServiceGetAccountInfoOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task ServiceCreateBlobContainer_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            string containerName = GetNewContainerName();

            try
            {
                Response<BlobContainerClient> response = await service.CreateBlobContainerAsync(
                    containerName,
                    new BlobServiceCreateBlobContainerOptions { RequestPriority = priority });

                AssertRawPriority(response.GetRawResponse(), priority);
            }
            finally
            {
                await service.GetBlobContainerClient(containerName).DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task ServiceDeleteBlobContainer_RequestPriority()
        {
            int? priority = Priority;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            string containerName = GetNewContainerName();
            await service.CreateBlobContainerAsync(containerName);

            Response response = await service.DeleteBlobContainerAsync(
                containerName,
                new BlobServiceDeleteBlobContainerOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }
        #endregion
    }
}
