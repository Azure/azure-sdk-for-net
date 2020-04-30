// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.ChangeFeed.Models;
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

        [Test]
        public void HasNext_True()
        {
            // Arrange
            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);
            avroReader.Setup(r => r.HasNext()).Returns(true);
            Chunk chunk = new Chunk(avroReader.Object);

            // Act
            bool hasNext = chunk.HasNext();

            // Assert
            Assert.IsTrue(hasNext);
            avroReader.Verify(r => r.HasNext());
        }

        [Test]
        public void HasNext_False()
        {
            // Arrange
            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);
            avroReader.Setup(r => r.HasNext()).Returns(false);
            Chunk chunk = new Chunk(avroReader.Object);

            // Act
            bool hasNext = chunk.HasNext();

            // Assert
            Assert.IsFalse(hasNext);
            avroReader.Verify(r => r.HasNext());
        }

        [Test]
        public async Task Next()
        {
            // Arrange
            long blockOffset = 5;
            long objectIndex = 10;

            string topic = "topic";
            string subject = "subject";
            string eventType = "BlobCreated";
            DateTimeOffset eventTime = new DateTimeOffset(2020, 4, 30, 8, 26, 30, TimeSpan.Zero);
            Guid eventId = Guid.NewGuid();
            long dataVersion = 1;
            string metadataVersion = "1";

            string api = "CreateBlob";
            Guid clientRequestId = Guid.NewGuid();
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
                { Constants.ChangeFeed.Event.DataVersion, dataVersion },
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

            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);

            avroReader.Setup(r => r.HasNext()).Returns(true);

            avroReader.Setup(r => r.Next(
                It.IsAny<bool>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(record);

            avroReader.Setup(r => r.BlockOffset).Returns(blockOffset);
            avroReader.Setup(r => r.ObjectIndex).Returns(objectIndex);

            Chunk chunk = new Chunk(avroReader.Object);

            // Act
            BlobChangeFeedEvent changeFeedEvent = await chunk.Next(IsAsync);

            // Assert
            Assert.AreEqual(topic, changeFeedEvent.Topic);
            Assert.AreEqual(subject, changeFeedEvent.Subject);
            Assert.AreEqual(BlobChangeFeedEventType.BlobCreated, changeFeedEvent.EventType);
            Assert.AreEqual(eventTime, changeFeedEvent.EventTime);
            Assert.AreEqual(eventId, changeFeedEvent.Id);
            Assert.AreEqual(dataVersion, changeFeedEvent.DataVersion);
            Assert.AreEqual(metadataVersion, changeFeedEvent.MetadataVersion);

            Assert.AreEqual(api, changeFeedEvent.EventData.Api);
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

            avroReader.Verify(r => r.HasNext());
            avroReader.Verify(r => r.Next(
                IsAsync,
                default));
            avroReader.Verify(r => r.BlockOffset);
            avroReader.Verify(r => r.ObjectIndex);
        }
    }
}
