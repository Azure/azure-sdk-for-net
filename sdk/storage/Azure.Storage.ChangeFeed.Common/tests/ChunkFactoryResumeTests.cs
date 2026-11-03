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

        [Test]
        public async Task ResumeEveryEvent_ProducesEachEventExactlyOnce()
        {
            string[][] blocks = new string[][]
            {
                new string[] { "e0", "e1", "e2" },
                new string[] { "e3", "e4" },
                new string[] { "e5", "e6", "e7", "e8" },
                new string[] { "e9" },
            };
            byte[] avro = BuildMultiBlockAvro(blocks);
            ChunkFactoryBase<TestEvent> factory = CreateFactory(avro);

            List<string> expected = new List<string>();
            ChunkBase<TestEvent> all = await factory.BuildChunk(IsAsync, ChunkPath);
            while (all.HasNext())
            {
                expected.Add((await all.Next(IsAsync)).Id);
            }

            List<string> actual = new List<string>();
            ChunkBase<TestEvent> chunk = await factory.BuildChunk(IsAsync, ChunkPath);
            while (chunk.HasNext())
            {
                actual.Add((await chunk.Next(IsAsync)).Id);
                long blockOffset = chunk.BlockOffset;
                long eventIndex = chunk.EventIndex;

                if (blockOffset >= avro.Length)
                {
                    break;
                }

                chunk = await factory.BuildChunk(IsAsync, ChunkPath, blockOffset, eventIndex);
            }

            CollectionAssert.AreEqual(expected, actual);
            CollectionAssert.AllItemsAreUnique(actual);
        }

        private ChunkFactoryBase<TestEvent> CreateFactory(byte[] avro)
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
            blobClient
                .Setup(r => r.OpenReadAsync(It.IsAny<BlobOpenReadOptions>(), It.IsAny<CancellationToken>()))
                .Returns<BlobOpenReadOptions, CancellationToken>((options, _) =>
                    Task.FromResult<Stream>(new MemoryStream(avro) { Position = options.Position }));
            blobClient
                .Setup(r => r.OpenRead(It.IsAny<BlobOpenReadOptions>(), It.IsAny<CancellationToken>()))
                .Returns<BlobOpenReadOptions, CancellationToken>((options, _) =>
                    new MemoryStream(avro) { Position = options.Position });

            return new ChunkFactoryBase<TestEvent>(
                containerClient.Object,
                new AvroReaderFactory(),
                maxTransferSize: null,
                CreateTestConfig());
        }

        private static byte[] BuildMultiBlockAvro(string[][] blocks)
        {
            using MemoryStream stream = new MemoryStream();

            stream.Write(new byte[] { 0x4F, 0x62, 0x6A, 0x01 }, 0, 4);
            WriteLong(stream, 1);
            WriteString(stream, "avro.schema");
            WriteString(stream, RecordSchema);
            WriteLong(stream, 0);
            stream.Write(s_syncMarker, 0, s_syncMarker.Length);

            foreach (string[] block in blocks)
            {
                WriteLong(stream, block.Length);
                WriteLong(stream, 0);
                foreach (string id in block)
                {
                    WriteString(stream, id);
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
