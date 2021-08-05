// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests.ManagedDisk
{
    public class ManagedDiskTests : BlobTestBase
    {
        private Uri snapshot1SASUri;
        private Uri snapshot2SASUri;

        public ManagedDiskTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [SetUp]
        public void Setup()
        {
            snapshot1SASUri = new Uri(Recording.GetVariable(nameof(snapshot1SASUri), ManagedDiskFixture.Instance.Snapshot1SASUri?.AbsoluteUri, v => Sanitizer.SanitizeUri(v)));
            snapshot2SASUri = new Uri(Recording.GetVariable(nameof(snapshot2SASUri), ManagedDiskFixture.Instance.Snapshot2SASUri?.AbsoluteUri, v => Sanitizer.SanitizeUri(v)));
        }

        [Test]
        public async Task CanDiffPagesBetweenSnapshots()
        {
            // Arrange
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

        private async Task<byte[]> DownloadRange(PageBlobClient client, HttpRange range)
        {
            var memoryStream = new MemoryStream();
            using BlobDownloadStreamingResult result1 = await client.DownloadStreamingAsync(range: range);
            await result1.Content.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
