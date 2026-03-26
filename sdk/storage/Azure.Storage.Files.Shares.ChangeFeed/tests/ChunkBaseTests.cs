// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.ChangeFeed.Common;
using Azure.Storage.Internal.Avro;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    public class ChunkBaseTests : ShareChangeFeedTestBase
    {
        public ChunkBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        private static ChangeFeedConfiguration<ShareChangeFeedEvent> GetConfig()
            => new ChangeFeedConfiguration<ShareChangeFeedEvent>
            {
                TimeWindowInterval = TimeSpan.FromMinutes(15),
                ContainerPrefix = "$fileschangefeed-testguid/",
                EventParser = dict => new ShareChangeFeedEvent(dict),
                DefaultPageSize = 5000,
                ChunkBlockDownloadSize = Constants.MB,
            };

        [Test]
        public async Task HasNext_True()
        {
            string chunkPath = "chunkPath";
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<AvroReaderFactory> avroReaderFactory = new Mock<AvroReaderFactory>(MockBehavior.Strict);
            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStreamFactory> lazyLoadingBlobStreamFactory = new Mock<LazyLoadingBlobStreamFactory>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStream> lazyLoadingBlobStream = new Mock<LazyLoadingBlobStream>(MockBehavior.Strict);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
            lazyLoadingBlobStreamFactory.Setup(r => r.BuildLazyLoadingBlobStream(
                It.IsAny<BlobClient>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(lazyLoadingBlobStream.Object);
            avroReaderFactory.Setup(r => r.BuildAvroReader(It.IsAny<Stream>())).Returns(avroReader.Object);
            avroReader.Setup(r => r.HasNext()).Returns(true);
            avroReader.Setup(r => r.Initalize(It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            long? maxTransferSize = 256 * Constants.MB;

            ChunkFactoryBase<ShareChangeFeedEvent> chunkFactory = new ChunkFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object, lazyLoadingBlobStreamFactory.Object, avroReaderFactory.Object, maxTransferSize, GetConfig());
            ChunkBase<ShareChangeFeedEvent> chunk = await chunkFactory.BuildChunk(IsAsync, chunkPath);

            bool hasNext = chunk.HasNext();

            Assert.IsTrue(hasNext);
            containerClient.Verify(r => r.GetBlobClient(chunkPath));
            avroReader.Verify(r => r.HasNext());
        }

        [Test]
        public async Task HasNext_False()
        {
            string chunkPath = "chunkPath";
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<AvroReaderFactory> avroReaderFactory = new Mock<AvroReaderFactory>(MockBehavior.Strict);
            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStreamFactory> lazyLoadingBlobStreamFactory = new Mock<LazyLoadingBlobStreamFactory>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStream> lazyLoadingBlobStream = new Mock<LazyLoadingBlobStream>(MockBehavior.Strict);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
            lazyLoadingBlobStreamFactory.Setup(r => r.BuildLazyLoadingBlobStream(
                It.IsAny<BlobClient>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(lazyLoadingBlobStream.Object);
            avroReaderFactory.Setup(r => r.BuildAvroReader(It.IsAny<Stream>())).Returns(avroReader.Object);
            avroReader.Setup(r => r.HasNext()).Returns(false);
            avroReader.Setup(r => r.Initalize(It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            long? maxTransferSize = 256 * Constants.MB;

            ChunkFactoryBase<ShareChangeFeedEvent> chunkFactory = new ChunkFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object, lazyLoadingBlobStreamFactory.Object, avroReaderFactory.Object, maxTransferSize, GetConfig());
            ChunkBase<ShareChangeFeedEvent> chunk = await chunkFactory.BuildChunk(IsAsync, chunkPath);

            bool hasNext = chunk.HasNext();

            Assert.IsFalse(hasNext);
        }

        [Test]
        public async Task Next()
        {
            string chunkPath = "chunkPath";
            long blockOffset = 5;
            long eventIndex = 10;

            Dictionary<string, object> record = new Dictionary<string, object>
            {
                { "SchemaVersion", 1L },
                { "Reason", "SmbCreate" },
                { "Protocol", "SMB" },
                { "EventTime", "2024-01-15T08:12:11.5746587Z" },
                { "Id", "62616073-8020-0000-00ff-233467060cc0" },
                { "Cvnt", 100L },
                { "Data", new Dictionary<string, object>
                    {
                        { "FileId", "9223442405598953472" },
                        { "ParentFileId", "9223442405598958712" },
                        { "Etag", "0x8D9F2171BE32588" },
                        { "FileName", "sample.txt" },
                        { "FullFilePath", "dir/sample.txt" },
                        { "IsDirectory", "false" },
                    }
                }
            };

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<AvroReaderFactory> avroReaderFactory = new Mock<AvroReaderFactory>(MockBehavior.Strict);
            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStreamFactory> lazyLoadingBlobStreamFactory = new Mock<LazyLoadingBlobStreamFactory>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStream> dataStream = new Mock<LazyLoadingBlobStream>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStream> headStream = new Mock<LazyLoadingBlobStream>(MockBehavior.Strict);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
            lazyLoadingBlobStreamFactory.SetupSequence(r => r.BuildLazyLoadingBlobStream(
                It.IsAny<BlobClient>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(dataStream.Object)
                .Returns(headStream.Object);
            avroReaderFactory.Setup(r => r.BuildAvroReader(
                It.IsAny<Stream>(), It.IsAny<Stream>(), It.IsAny<long>(), It.IsAny<long>())).Returns(avroReader.Object);
            avroReader.Setup(r => r.HasNext()).Returns(true);
            avroReader.Setup(r => r.Initalize(It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            avroReader.Setup(r => r.Next(It.IsAny<bool>(), It.IsAny<CancellationToken>())).ReturnsAsync(record);
            avroReader.Setup(r => r.BlockOffset).Returns(blockOffset);
            avroReader.Setup(r => r.ObjectIndex).Returns(eventIndex);
            long? maxTransferSize = 256 * Constants.MB;

            ChunkFactoryBase<ShareChangeFeedEvent> chunkFactory = new ChunkFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object, lazyLoadingBlobStreamFactory.Object, avroReaderFactory.Object, maxTransferSize, GetConfig());
            ChunkBase<ShareChangeFeedEvent> chunk = await chunkFactory.BuildChunk(IsAsync, chunkPath, blockOffset, eventIndex);

            ShareChangeFeedEvent changeFeedEvent = await chunk.Next(IsAsync);

            Assert.AreEqual(ShareChangeFeedReasonType.SmbCreate, changeFeedEvent.Reason);
            Assert.AreEqual(ShareChangeFeedProtocol.Smb, changeFeedEvent.Protocol);
            Assert.AreEqual(1L, changeFeedEvent.SchemaVersion);
            Assert.AreEqual(100L, changeFeedEvent.ContainerVersionNumber);
            Assert.AreEqual("62616073-8020-0000-00ff-233467060cc0", changeFeedEvent.Id);
            Assert.AreEqual("9223442405598953472", changeFeedEvent.EventData.FileId);
            Assert.AreEqual("sample.txt", changeFeedEvent.EventData.FileName);
            Assert.AreEqual("dir/sample.txt", changeFeedEvent.EventData.FullFilePath);
            Assert.IsFalse(changeFeedEvent.EventData.IsDirectory);
        }
    }
}
