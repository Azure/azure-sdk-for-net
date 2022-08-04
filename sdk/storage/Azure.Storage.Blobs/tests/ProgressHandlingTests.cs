// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class ProgressHandlingTests : BlobTestBase
    {
        public ProgressHandlingTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        [TestCase(Constants.KB)] // simple case
        [TestCase(256 * Constants.KB)] // multi-report case
        public async Task DownloadContent(int size)
        {
            await using DisposingContainer test = await BlobsClientBuilder.GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TestProgress progress = new TestProgress();
            var client = test.Container.GetBlobClient(BlobsClientBuilder.GetNewBlobName());
            await client.UploadAsync(BinaryData.FromBytes(data));

            // Act
            var result = await client.DownloadContentAsync(new BlobDownloadOptions
            {
                ProgressHandler = progress
            });

            // Assert
            Assert.AreNotEqual(0, progress.List.Count);
            Assert.AreEqual(size, progress.List.Max());
            Assert.IsTrue(Enumerable.SequenceEqual(data, result.Value.Content.ToArray()));
        }

        [RecordedTest]
        [TestCase(0, Constants.KB)]
        [TestCase(0, 4 * Constants.KB)]
        [TestCase(4 * Constants.KB, Constants.KB)]
        [TestCase(4 * Constants.KB, 4 * Constants.KB)]
        public async Task DownloadContentRange(int offset, int length)
        {
            await using DisposingContainer test = await BlobsClientBuilder.GetTestContainerAsync();

            // Arrange
            const int size = 8 * Constants.KB;
            var data = GetRandomBuffer(size);
            TestProgress progress = new TestProgress();
            var client = test.Container.GetBlobClient(BlobsClientBuilder.GetNewBlobName());
            await client.UploadAsync(BinaryData.FromBytes(data));

            // Act
            var result = await client.DownloadContentAsync(new BlobDownloadOptions
            {
                ProgressHandler = progress,
                Range = new HttpRange(offset, length)
            });

            // Assert
            Assert.AreNotEqual(0, progress.List.Count);
            Assert.AreEqual(length, progress.List.Max());
            Assert.IsTrue(new ReadOnlySpan<byte>(data, offset, length).SequenceEqual(result.Value.Content.ToArray()));
        }

        [RecordedTest]
        [TestCase(Constants.KB)] // simple case
        [TestCase(256 * Constants.KB)] // multi-report case
        public async Task DownloadStreaming(int size)
        {
            await using DisposingContainer test = await BlobsClientBuilder.GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TestProgress progress = new TestProgress();
            var client = test.Container.GetBlobClient(BlobsClientBuilder.GetNewBlobName());
            await client.UploadAsync(BinaryData.FromBytes(data));

            // Act
            var result = await client.DownloadStreamingAsync(new BlobDownloadOptions
            {
                ProgressHandler = progress
            });
            var downloadedData = new byte[result.Value.Details.ContentLength];
            using (Stream ms = new MemoryStream(downloadedData))
            {
                await result.Value.Content.CopyToAsync(ms);
            }

            // Assert
            Assert.AreNotEqual(0, progress.List.Count);
            Assert.AreEqual(size, progress.List.Max());
        }

        [RecordedTest]
        [TestCase(0, Constants.KB)]
        [TestCase(0, 4 * Constants.KB)]
        [TestCase(4 * Constants.KB, Constants.KB)]
        [TestCase(4 * Constants.KB, 4 * Constants.KB)]
        public async Task DownloadStreamingRange(int offset, int length)
        {
            await using DisposingContainer test = await BlobsClientBuilder.GetTestContainerAsync();

            // Arrange
            const int size = 8 * Constants.KB;
            var data = GetRandomBuffer(size);
            TestProgress progress = new TestProgress();
            var client = test.Container.GetBlobClient(BlobsClientBuilder.GetNewBlobName());
            await client.UploadAsync(BinaryData.FromBytes(data));

            // Act
            var result = await client.DownloadStreamingAsync(new BlobDownloadOptions
            {
                ProgressHandler = progress,
                Range = new HttpRange(offset, length)
            });
            var downloadedData = new byte[result.Value.Details.ContentLength];
            using (Stream ms = new MemoryStream(downloadedData))
            {
                await result.Value.Content.CopyToAsync(ms);
            }

            // Assert
            Assert.AreNotEqual(0, progress.List.Count);
            Assert.AreEqual(length, progress.List.Max());
            Assert.IsTrue(new ReadOnlySpan<byte>(data, offset, length).SequenceEqual(downloadedData));
        }

        [RecordedTest]
        [TestCase(Constants.KB, default, default)]
        [TestCase(10 * Constants.KB, Constants.KB, 1)]
        [TestCase(10 * Constants.KB, Constants.KB, 2)]
        [TestCase(10 * Constants.KB, Constants.KB, 10)]
        [TestCase(Constants.MB, 100 * Constants.KB, 10)] // multi-report per-partition case
        public async Task DownloadTo(int dataLength, int? partitionSize, int? parallelism)
        {
            await using DisposingContainer test = await BlobsClientBuilder.GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(dataLength);
            TestProgress progress = new TestProgress();
            var client = test.Container.GetBlobClient(BlobsClientBuilder.GetNewBlobName());
            await client.UploadAsync(BinaryData.FromBytes(data));

            // Act
            var downloadedData = new MemoryStream();
            await client.DownloadToAsync(downloadedData, new BlobDownloadToOptions
            {
                ProgressHandler = progress,
                TransferOptions = new StorageTransferOptions
                {
                    InitialTransferSize = partitionSize,
                    MaximumTransferSize = partitionSize,
                    MaximumConcurrency = parallelism
                }
            });

            // Assert
            Assert.AreNotEqual(0, progress.List.Count);
            Assert.AreEqual(downloadedData.Length, progress.List.Max());
            Assert.AreEqual(data.Length, downloadedData.Length);
            Assert.IsTrue(Enumerable.SequenceEqual(data, downloadedData.ToArray()));
        }
    }
}
