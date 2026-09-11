// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Internal.Avro;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// End-to-end resume tests that drive the production cursor plumbing
    /// (<see cref="ChunkFactoryBase{TEvent}"/> building a real <see cref="AvroReader"/> from a mocked
    /// blob <c>OpenRead</c>) instead of a mocked reader. This is the shared code path used by both the
    /// Blob and Files change feeds, so it locks in exactly-once resumption for both.
    /// </summary>
    public class ChunkFactoryResumeTests : ChangeFeedCommonTestBase
    {
        private const string ChunkPath = "log/00/2024/01/15/0800/00000.avro";

        private const string RecordSchema =
            "{\"type\":\"record\",\"name\":\"TestEvent\",\"fields\":[{\"name\":\"Id\",\"type\":\"string\"}]}";

        private static readonly byte[] s_syncMarker =
            new byte[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        public ChunkFactoryResumeTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Reproduces the reviewer's scenario at the chunk level: enumerate a multi-block chunk one
        /// event at a time, round-tripping through a brand-new resumed chunk after every event, and
        /// assert the full event sequence is produced exactly once with no duplicates and no gaps.
        /// A resumed reader crossing an Avro block boundary previously corrupted the next cursor.
        /// </summary>
        [Test]
        public async Task ResumeEveryEvent_ProducesEachEventExactlyOnce()
        {
            string[][] blocks = new string[][]
            {
                new[] { "e0", "e1", "e2" },
                new[] { "e3", "e4" },
                new[] { "e5", "e6", "e7", "e8" },
                new[] { "e9" },
            };
            byte[] avro = BuildMultiBlockAvro(blocks);

            ChunkFactoryBase<TestEvent> factory = CreateFactory(avro);

            // Expected full sequence, read without any resume.
            List<string> expected = new List<string>();
            ChunkBase<TestEvent> all = await factory.BuildChunk(IsAsync, ChunkPath);
            while (all.HasNext())
            {
                expected.Add((await all.Next(IsAsync)).Id);
            }

            // Chained-token simulation: rebuild the chunk from (blockOffset, eventIndex) after each event.
            List<string> got = new List<string>();
            ChunkBase<TestEvent> chunk = await factory.BuildChunk(IsAsync, ChunkPath);
            while (chunk.HasNext())
            {
                got.Add((await chunk.Next(IsAsync)).Id);
                long blockOffset = chunk.BlockOffset;
                long eventIndex = chunk.EventIndex;

                // Stop once the whole chunk is consumed; a real ShardFactory only resumes a chunk
                // whose length is strictly greater than the cursor's block offset.
                if (blockOffset >= avro.Length)
                {
                    break;
                }

                chunk = await factory.BuildChunk(IsAsync, ChunkPath, blockOffset, eventIndex);
            }

            CollectionAssert.AreEqual(expected, got);
            CollectionAssert.AllItemsAreUnique(got);
        }

        /// <summary>
        /// Wires a <see cref="ChunkFactoryBase{TEvent}"/> whose blob <c>OpenRead</c> returns a seekable
        /// <see cref="MemoryStream"/> over <paramref name="avro"/> positioned at the requested offset,
        /// mirroring the absolute-position behavior of the real blob read stream.
        /// </summary>
        private ChunkFactoryBase<TestEvent> CreateFactory(byte[] avro)
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
            blobClient
                .Setup(r => r.OpenReadAsync(It.IsAny<BlobOpenReadOptions>(), It.IsAny<CancellationToken>()))
                .Returns<BlobOpenReadOptions, CancellationToken>((opts, _) =>
                    System.Threading.Tasks.Task.FromResult<Stream>(new MemoryStream(avro) { Position = opts.Position }));
            blobClient
                .Setup(r => r.OpenRead(It.IsAny<BlobOpenReadOptions>(), It.IsAny<CancellationToken>()))
                .Returns<BlobOpenReadOptions, CancellationToken>((opts, _) =>
                    new MemoryStream(avro) { Position = opts.Position });

            return new ChunkFactoryBase<TestEvent>(
                containerClient.Object,
                new AvroReaderFactory(),
                maxTransferSize: null,
                CreateTestConfig());
        }

        /// <summary>
        /// Builds a valid, uncompressed Avro chunk whose items are records with a single string
        /// <c>Id</c> field. Each element of <paramref name="blocks"/> becomes one Avro block.
        /// </summary>
        private static byte[] BuildMultiBlockAvro(string[][] blocks)
        {
            using MemoryStream stream = new MemoryStream();

            // Magic bytes: "Obj\1".
            stream.Write(new byte[] { 0x4F, 0x62, 0x6A, 0x01 }, 0, 4);

            // Metadata map with a single entry: avro.schema => record schema. Codec omitted (null).
            WriteLong(stream, 1);
            WriteString(stream, "avro.schema");
            WriteString(stream, RecordSchema);
            WriteLong(stream, 0);

            stream.Write(s_syncMarker, 0, s_syncMarker.Length);

            foreach (string[] block in blocks)
            {
                WriteLong(stream, block.Length);   // item count
                WriteLong(stream, 0);              // block byte size (ignored by AvroReader)
                foreach (string id in block)
                {
                    WriteString(stream, id);       // the record's single string field
                }
                stream.Write(s_syncMarker, 0, s_syncMarker.Length);
            }

            return stream.ToArray();
        }

        private static void WriteLong(MemoryStream stream, long value)
        {
            ulong zigzag = (ulong)((value << 1) ^ (value >> 63));
            while (zigzag > 0x7F)
            {
                stream.WriteByte((byte)((zigzag & 0x7F) | 0x80));
                zigzag >>= 7;
            }
            stream.WriteByte((byte)zigzag);
        }

        private static void WriteString(MemoryStream stream, string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            WriteLong(stream, bytes.Length);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
