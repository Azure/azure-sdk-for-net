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
using Azure.Storage.Internal.Avro;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// Tests for <see cref="ChunkBase{TEvent}"/> and <see cref="ChunkFactoryBase{TEvent}"/>
    /// using a mocked <see cref="AvroReader"/> and the <see cref="ChangeFeedCommonTestBase.TestEvent"/> type.
    /// </summary>
    public class ChunkBaseTests : ChangeFeedCommonTestBase
    {
        public ChunkBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies HasNext() returns true when the underlying AvroReader has more data.
        /// </summary>
        [Test]
        public async Task HasNext_True()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<AvroReaderFactory> avroReaderFactory = new Mock<AvroReaderFactory>(MockBehavior.Strict);
            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStreamFactory> streamFactory = new Mock<LazyLoadingBlobStreamFactory>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStream> stream = new Mock<LazyLoadingBlobStream>(MockBehavior.Strict);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
            streamFactory.Setup(r => r.BuildLazyLoadingBlobStream(It.IsAny<BlobClient>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(stream.Object);
            avroReaderFactory.Setup(r => r.BuildAvroReader(It.IsAny<Stream>())).Returns(avroReader.Object);
            avroReader.Setup(r => r.HasNext()).Returns(true);
            avroReader.Setup(r => r.Initalize(It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            ChunkFactoryBase<TestEvent> chunkFactory = new ChunkFactoryBase<TestEvent>(
                containerClient.Object, streamFactory.Object, avroReaderFactory.Object, 4 * Constants.MB, CreateTestConfig());
            ChunkBase<TestEvent> chunk = await chunkFactory.BuildChunk(IsAsync, "chunkPath");

            Assert.IsTrue(chunk.HasNext());
            avroReader.Verify(r => r.HasNext());
        }

        /// <summary>
        /// Verifies HasNext() returns false when the underlying AvroReader is exhausted.
        /// </summary>
        [Test]
        public async Task HasNext_False()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<AvroReaderFactory> avroReaderFactory = new Mock<AvroReaderFactory>(MockBehavior.Strict);
            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStreamFactory> streamFactory = new Mock<LazyLoadingBlobStreamFactory>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStream> stream = new Mock<LazyLoadingBlobStream>(MockBehavior.Strict);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
            streamFactory.Setup(r => r.BuildLazyLoadingBlobStream(It.IsAny<BlobClient>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(stream.Object);
            avroReaderFactory.Setup(r => r.BuildAvroReader(It.IsAny<Stream>())).Returns(avroReader.Object);
            avroReader.Setup(r => r.HasNext()).Returns(false);
            avroReader.Setup(r => r.Initalize(It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            ChunkFactoryBase<TestEvent> chunkFactory = new ChunkFactoryBase<TestEvent>(
                containerClient.Object, streamFactory.Object, avroReaderFactory.Object, 4 * Constants.MB, CreateTestConfig());
            ChunkBase<TestEvent> chunk = await chunkFactory.BuildChunk(IsAsync, "chunkPath");

            Assert.IsFalse(chunk.HasNext());
        }

        /// <summary>
        /// Verifies Next() deserializes an Avro record through the EventParser delegate
        /// and tracks block offset and event index from the AvroReader.
        /// </summary>
        [Test]
        public async Task Next_DeserializesEventAndTracksPosition()
        {
            long blockOffset = 5;
            long eventIndex = 10;

            Dictionary<string, object> record = new Dictionary<string, object>
            {
                { "Reason", "SmbCreate" },
                { "Id", "test-event-id" },
                { "Cvnt", 42L },
            };

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<AvroReaderFactory> avroReaderFactory = new Mock<AvroReaderFactory>(MockBehavior.Strict);
            Mock<AvroReader> avroReader = new Mock<AvroReader>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStreamFactory> streamFactory = new Mock<LazyLoadingBlobStreamFactory>(MockBehavior.Strict);
            // Two streams: data stream for reading events, head stream for reading schema on resume
            Mock<LazyLoadingBlobStream> dataStream = new Mock<LazyLoadingBlobStream>(MockBehavior.Strict);
            Mock<LazyLoadingBlobStream> headStream = new Mock<LazyLoadingBlobStream>(MockBehavior.Strict);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
            streamFactory.SetupSequence(r => r.BuildLazyLoadingBlobStream(It.IsAny<BlobClient>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(dataStream.Object)
                .Returns(headStream.Object);
            avroReaderFactory.Setup(r => r.BuildAvroReader(It.IsAny<Stream>(), It.IsAny<Stream>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(avroReader.Object);
            avroReader.Setup(r => r.HasNext()).Returns(true);
            avroReader.Setup(r => r.Initalize(It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            avroReader.Setup(r => r.Next(It.IsAny<bool>(), It.IsAny<CancellationToken>())).ReturnsAsync(record);
            avroReader.Setup(r => r.BlockOffset).Returns(blockOffset);
            avroReader.Setup(r => r.ObjectIndex).Returns(eventIndex);

            ChunkFactoryBase<TestEvent> chunkFactory = new ChunkFactoryBase<TestEvent>(
                containerClient.Object, streamFactory.Object, avroReaderFactory.Object, 4 * Constants.MB, CreateTestConfig());
            ChunkBase<TestEvent> chunk = await chunkFactory.BuildChunk(IsAsync, "chunkPath", blockOffset, eventIndex);

            TestEvent evt = await chunk.Next(IsAsync);

            Assert.AreEqual("SmbCreate", evt.Reason);
            Assert.AreEqual("test-event-id", evt.Id);
            Assert.AreEqual(42L, evt.Cvnt);
            Assert.AreEqual(blockOffset, chunk.BlockOffset);
            Assert.AreEqual(eventIndex, chunk.EventIndex);
        }
    }
}
