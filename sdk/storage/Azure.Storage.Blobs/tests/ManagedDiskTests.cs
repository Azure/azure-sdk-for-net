// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Test;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests.ManagedDisk
{
    [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
    public class ManagedDiskTests : BlobTestBase
    {
        private Uri snapshot1SASUri;
        private Uri snapshot2SASUri;
        private long snapshot1Size;

        public ManagedDiskTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [SetUp]
        public void Setup()
        {
            snapshot1SASUri = new Uri(Recording.GetVariable(nameof(snapshot1SASUri), ManagedDiskFixture.Instance.Snapshot1SASUri?.AbsoluteUri, v => SanitizeUri(v)));
            snapshot2SASUri = new Uri(Recording.GetVariable(nameof(snapshot2SASUri), ManagedDiskFixture.Instance.Snapshot2SASUri?.AbsoluteUri, v => SanitizeUri(v)));
            snapshot1Size = long.Parse(Recording.GetVariable(nameof(snapshot1Size), ManagedDiskFixture.Instance.Snapshot1?.Data.DiskSizeBytes.ToString()));
        }

        [Test]
        [RetryOnException(5, typeof(RequestFailedException))]
        public async Task CanDiffPagesBetweenSnapshots()
        {
            // Arrange
            Setup();
            var snapshot1Client = InstrumentClient(new PageBlobClient(snapshot1SASUri, GetOptions()));
            var snapshot2Client = InstrumentClient(new PageBlobClient(snapshot2SASUri, GetOptions()));

            // Act
            PageRangesInfo pageRangesInfo = await snapshot2Client.GetManagedDiskPageRangesDiffAsync(previousSnapshotUri: snapshot1SASUri);

            // Assert
            Assert.IsNotNull(pageRangesInfo.LastModified);
            Assert.IsNotNull(pageRangesInfo.ETag);
            CollectionAssert.IsNotEmpty(pageRangesInfo.ClearRanges);
            CollectionAssert.IsNotEmpty(pageRangesInfo.PageRanges);

            // Assert page diff
            var pageRange = pageRangesInfo.PageRanges.First();
            var range1 = await DownloadRange(snapshot1Client, pageRange);
            var range2 = await DownloadRange(snapshot2Client, pageRange);

            Assert.AreNotEqual(range1, range2);

            // Assert page clean
            var cleanRange = pageRangesInfo.ClearRanges.First();
            range2 = await DownloadRange(snapshot2Client, cleanRange);
            foreach (byte b in range2)
            {
                Assert.AreEqual(0, b);
            }
        }

        [Test]
        public async Task GetManagedDiskPageRangesDiffAsync_Error()
        {
            // Arrange
            Setup();
            var snapshot1Client = InstrumentClient(new PageBlobClient(snapshot1SASUri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                snapshot1Client.GetManagedDiskPageRangesDiffAsync(range: new HttpRange(snapshot1Size + Constants.MB, 4 * Constants.KB)),
                e =>
                {
                    Assert.AreEqual("InvalidRange", e.ErrorCode);
                    Assert.AreEqual("The range specified is invalid for the current size of the resource.",
                        e.Message.Split('\n')[0]);
                });
        }

        [Test]
        public async Task GetManagedDiskPageRangesDiffAsync_AccessConditions()
        {
            Setup();
            var snapshot2Client = InstrumentClient(new PageBlobClient(snapshot2SASUri, GetOptions()));

            foreach (var parameters in Reduced_AccessConditions_Data)
            {
                parameters.Match = await SetupBlobMatchCondition(snapshot2Client, parameters.Match);

                PageBlobRequestConditions accessConditions = PageBlobClientTests.BuildAccessConditions(
                    parameters: parameters,
                    lease: false);

                // Act
                Response<PageRangesInfo> response = await snapshot2Client.GetManagedDiskPageRangesDiffAsync(
                    range: new HttpRange(0, Constants.KB),
                    previousSnapshotUri: snapshot1SASUri,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Value.PageRanges);
            }
        }

        [Test]
        public async Task GetManagedDiskPageRangesDiffAsync_AccessConditionsFail()
        {
            Setup();
            var snapshot2Client = InstrumentClient(new PageBlobClient(snapshot2SASUri, GetOptions()));
            foreach (var parameters in Reduced_AccessConditions_Fail_Data)
            {
                parameters.NoneMatch = await SetupBlobMatchCondition(snapshot2Client, parameters.NoneMatch);

                PageBlobRequestConditions accessConditions = PageBlobClientTests.BuildAccessConditions(
                    parameters: parameters,
                    lease: false);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await snapshot2Client.GetManagedDiskPageRangesDiffAsync(
                            range: new HttpRange(0, Constants.KB),
                            previousSnapshotUri: snapshot1SASUri,
                            conditions: accessConditions)).Value;
                    });
            }
        }

        public IEnumerable<PageBlobClientTests.AccessConditionParameters> Reduced_AccessConditions_Data
            => new[]
            {
                new PageBlobClientTests.AccessConditionParameters(),
                new PageBlobClientTests.AccessConditionParameters { IfModifiedSince = OldDate },
                new PageBlobClientTests.AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new PageBlobClientTests.AccessConditionParameters { Match = ReceivedETag },
                new PageBlobClientTests.AccessConditionParameters { NoneMatch = GarbageETag }
            };

        public IEnumerable<PageBlobClientTests.AccessConditionParameters> Reduced_AccessConditions_Fail_Data
            => new[]
            {
                        new PageBlobClientTests.AccessConditionParameters { IfModifiedSince = NewDate },
                        new PageBlobClientTests.AccessConditionParameters { IfUnmodifiedSince = OldDate },
                        new PageBlobClientTests.AccessConditionParameters { Match = GarbageETag },
                        new PageBlobClientTests.AccessConditionParameters { NoneMatch = ReceivedETag }
            };

        private async Task<byte[]> DownloadRange(PageBlobClient client, HttpRange range)
        {
            var memoryStream = new MemoryStream();
            using BlobDownloadStreamingResult result1 = await client.DownloadStreamingAsync(new BlobDownloadOptions
            {
                Range = range
            });
            await result1.Content.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
