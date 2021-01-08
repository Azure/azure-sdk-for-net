// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Internal.Avro;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class ChunkTests : ChangeFeedTestBase
    {
        public ChunkTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Tests Chunk.HasNext() when the underlying AvroReader.HasNext() returns true.
        /// </summary>
        [Test]
        public async Task HasNext_True()
        {
            // Arrange
            string chunkPath = "chunkPath";
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<AvroReaderFactory> avroReaderFactory = new Mock<AvroReaderFactory>(MockBehavior.Strict);
            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStreamFactory> lazyLoadingBlobStreamFactory = new Mock<LazyLoadingBlobStreamFactory>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStream> lazyLoadingBlobStream = new Mock<LazyLoadingBlobStream>(MockBehavior.Strict);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
            lazyLoadingBlobStreamFactory.Setup(r => r.BuildLazyLoadingBlobStream(
                It.IsAny<BlobClient>(),
                It.IsAny<long>(),
                It.IsAny<long>()))
                .Returns(lazyLoadingBlobStream.Object);
            avroReaderFactory.Setup(r => r.BuildAvroReader(It.IsAny<Stream>())).Returns(avroReader.Object);
            avroReader.Setup(r => r.HasNext()).Returns(true);
            avroReader.Setup(r => r.Initalize(It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            ChunkFactory chunkFactory = new ChunkFactory(
                containerClient.Object,
                lazyLoadingBlobStreamFactory.Object,
                avroReaderFactory.Object);
            Chunk chunk = await chunkFactory.BuildChunk(
                IsAsync,
                chunkPath);

            // Act
            bool hasNext = chunk.HasNext();

            // Assert
            Assert.IsTrue(hasNext);

            containerClient.Verify(r => r.GetBlobClient(chunkPath));
            lazyLoadingBlobStreamFactory.Verify(r => r.BuildLazyLoadingBlobStream(
                blobClient.Object,
                0,
                Constants.ChangeFeed.ChunkBlockDownloadSize));
            avroReaderFactory.Verify(r => r.BuildAvroReader(lazyLoadingBlobStream.Object));
            avroReader.Verify(r => r.HasNext());
        }

        /// <summary>
        /// Tests Chunk.HasNext() when the underlying AvroReader.HasNext() returns false.
        /// </summary>
        [Test]
        public async Task HasNext_False()
        {
            // Arrange
            string chunkPath = "chunkPath";
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<AvroReaderFactory> avroReaderFactory = new Mock<AvroReaderFactory>(MockBehavior.Strict);
            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStreamFactory> lazyLoadingBlobStreamFactory = new Mock<LazyLoadingBlobStreamFactory>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStream> lazyLoadingBlobStream = new Mock<LazyLoadingBlobStream>(MockBehavior.Strict);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
            lazyLoadingBlobStreamFactory.Setup(r => r.BuildLazyLoadingBlobStream(
                It.IsAny<BlobClient>(),
                It.IsAny<long>(),
                It.IsAny<long>()))
                .Returns(lazyLoadingBlobStream.Object);
            avroReaderFactory.Setup(r => r.BuildAvroReader(It.IsAny<Stream>())).Returns(avroReader.Object);
            avroReader.Setup(r => r.HasNext()).Returns(false);
            avroReader.Setup(r => r.Initalize(It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            ChunkFactory chunkFactory = new ChunkFactory(
                containerClient.Object,
                lazyLoadingBlobStreamFactory.Object,
                avroReaderFactory.Object);
            Chunk chunk = await chunkFactory.BuildChunk(
                IsAsync,
                chunkPath);

            // Act
            bool hasNext = chunk.HasNext();

            // Assert
            Assert.IsFalse(hasNext);

            containerClient.Verify(r => r.GetBlobClient(chunkPath));
            lazyLoadingBlobStreamFactory.Verify(r => r.BuildLazyLoadingBlobStream(
                blobClient.Object,
                0,
                Constants.ChangeFeed.ChunkBlockDownloadSize));
            avroReaderFactory.Verify(r => r.BuildAvroReader(lazyLoadingBlobStream.Object));
            avroReader.Verify(r => r.HasNext());
        }

        /// <summary>
        /// Tests Chunk.Next() and the BlobChangeFeedEvent and BlobChangeFeedEventData constructors.
        /// </summary>
        [Test]
        public async Task Next()
        {
            // Arrange
            string chunkPath = "chunkPath";
            long blockOffset = 5;
            long eventIndex = 10;

            string topic = "topic";
            string subject = "subject";
            string eventType = "BlobCreated";
            DateTimeOffset eventTime = new DateTimeOffset(2020, 4, 30, 8, 26, 30, TimeSpan.Zero);
            Guid eventId = Guid.NewGuid();
            long dataVersion = 1;
            string metadataVersion = "1";

            string api = "PutBlob";
            string clientRequestId = $"Azure-Storage-Powershell-{Guid.NewGuid()}";
            Guid requestId = Guid.NewGuid();
            ETag etag = new ETag("0x8D75EF45A3B8617");
            string contentType = "contentType";
            long contentLength = Constants.KB;
            string blobType = "BlockBlob";
            long contentOffset = 5;
            Uri destinationUri = new Uri("https://www.destination.com");
            Uri sourceUri = new Uri("https://www.source.com");
            Uri uri = new Uri("https://www.uri.com");
            bool recursive = true;
            string sequencer = "sequencer";

            Dictionary<string, object> record = new Dictionary<string, object>
            {
                { Constants.ChangeFeed.Event.Topic, topic },
                { Constants.ChangeFeed.Event.Subject, subject },
                { Constants.ChangeFeed.Event.EventType, eventType },
                { Constants.ChangeFeed.Event.EventTime, eventTime.ToString() },
                { Constants.ChangeFeed.Event.EventId, eventId.ToString() },
                { Constants.ChangeFeed.Event.SchemaVersion, dataVersion },
                { Constants.ChangeFeed.Event.MetadataVersion, metadataVersion },
                { Constants.ChangeFeed.Event.Data, new Dictionary<string, object>
                    {
                        { Constants.ChangeFeed.EventData.Api, api },
                        { Constants.ChangeFeed.EventData.ClientRequestId, clientRequestId.ToString() },
                        { Constants.ChangeFeed.EventData.RequestId, requestId.ToString() },
                        { Constants.ChangeFeed.EventData.Etag, etag.ToString() },
                        { Constants.ChangeFeed.EventData.ContentType, contentType },
                        { Constants.ChangeFeed.EventData.ContentLength, contentLength },
                        { Constants.ChangeFeed.EventData.BlobType, blobType },
                        { Constants.ChangeFeed.EventData.ContentOffset, contentOffset },
                        { Constants.ChangeFeed.EventData.DestinationUrl, destinationUri.ToString() },
                        { Constants.ChangeFeed.EventData.SourceUrl, sourceUri.ToString() },
                        { Constants.ChangeFeed.EventData.Url, uri.ToString() },
                        { Constants.ChangeFeed.EventData.Recursive, recursive },
                        { Constants.ChangeFeed.EventData.Sequencer, sequencer }
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
                It.IsAny<BlobClient>(),
                It.IsAny<long>(),
                It.IsAny<long>()))
                .Returns(dataStream.Object)
                .Returns(headStream.Object);
            avroReaderFactory.Setup(r => r.BuildAvroReader(
                It.IsAny<Stream>(),
                It.IsAny<Stream>(),
                It.IsAny<long>(),
                It.IsAny<long>())).Returns(avroReader.Object);
            avroReader.Setup(r => r.HasNext()).Returns(true);
            avroReader.Setup(r => r.Initalize(It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            avroReader.Setup(r => r.Next(
                It.IsAny<bool>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(record);

            avroReader.Setup(r => r.BlockOffset).Returns(blockOffset);
            avroReader.Setup(r => r.ObjectIndex).Returns(eventIndex);

            ChunkFactory chunkFactory = new ChunkFactory(
                containerClient.Object,
                lazyLoadingBlobStreamFactory.Object,
                avroReaderFactory.Object);
            Chunk chunk = await chunkFactory.BuildChunk(
                IsAsync,
                chunkPath,
                blockOffset,
                eventIndex);

            // Act
            BlobChangeFeedEvent changeFeedEvent = await chunk.Next(IsAsync);

            // Assert
            Assert.AreEqual(topic, changeFeedEvent.Topic);
            Assert.AreEqual(subject, changeFeedEvent.Subject);
            Assert.AreEqual(BlobChangeFeedEventType.BlobCreated, changeFeedEvent.EventType);
            Assert.AreEqual(eventTime, changeFeedEvent.EventTime);
            Assert.AreEqual(eventId, changeFeedEvent.Id);
            Assert.AreEqual(dataVersion, changeFeedEvent.SchemaVersion);
            Assert.AreEqual(metadataVersion, changeFeedEvent.MetadataVersion);

            Assert.AreEqual(BlobOperationName.PutBlob, changeFeedEvent.EventData.BlobOperationName);
            Assert.AreEqual(clientRequestId, changeFeedEvent.EventData.ClientRequestId);
            Assert.AreEqual(requestId, changeFeedEvent.EventData.RequestId);
            Assert.AreEqual(etag, changeFeedEvent.EventData.ETag);
            Assert.AreEqual(contentType, changeFeedEvent.EventData.ContentType);
            Assert.AreEqual(contentLength, changeFeedEvent.EventData.ContentLength);
            Assert.AreEqual(BlobType.Block, changeFeedEvent.EventData.BlobType);
            Assert.AreEqual(contentOffset, changeFeedEvent.EventData.ContentOffset);
            Assert.AreEqual(destinationUri, changeFeedEvent.EventData.DestinationUri);
            Assert.AreEqual(sourceUri, changeFeedEvent.EventData.SourceUri);
            Assert.AreEqual(uri, changeFeedEvent.EventData.Uri);
            Assert.AreEqual(recursive, changeFeedEvent.EventData.Recursive);
            Assert.AreEqual(sequencer, changeFeedEvent.EventData.Sequencer);

            containerClient.Verify(r => r.GetBlobClient(chunkPath));
            lazyLoadingBlobStreamFactory.Verify(r => r.BuildLazyLoadingBlobStream(
                blobClient.Object,
                blockOffset,
                Constants.ChangeFeed.ChunkBlockDownloadSize));
            lazyLoadingBlobStreamFactory.Verify(r => r.BuildLazyLoadingBlobStream(
                blobClient.Object,
                0,
                3 * Constants.KB));
            avroReaderFactory.Verify(r => r.BuildAvroReader(
                dataStream.Object,
                headStream.Object,
                blockOffset,
                eventIndex));
            avroReader.Verify(r => r.HasNext());
            avroReader.Verify(r => r.Next(
                IsAsync,
                default));
            avroReader.Verify(r => r.BlockOffset);
            avroReader.Verify(r => r.ObjectIndex);
        }
    }
}
