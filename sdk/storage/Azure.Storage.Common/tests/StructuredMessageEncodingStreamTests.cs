// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers.Binary;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Shared;
using NUnit.Framework;
using static Azure.Storage.Shared.StructuredMessage;

namespace Azure.Storage.Tests
{
    [TestFixture(ReadMethod.SyncArray)]
    [TestFixture(ReadMethod.AsyncArray)]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    [TestFixture(ReadMethod.SyncSpan)]
    [TestFixture(ReadMethod.AsyncMemory)]
#endif
    public class StructuredMessageEncodingStreamTests
    {
        // Cannot just implement as passthru in the stream
        // Must test each one
        public enum ReadMethod
        {
            SyncArray,
            AsyncArray,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
            SyncSpan,
            AsyncMemory
#endif
        }

        public ReadMethod Method { get; }

        public StructuredMessageEncodingStreamTests(ReadMethod method)
        {
            Method = method;
        }

        private async ValueTask CopyStream(Stream source, Stream destination, int bufferSize = 81920) // number default for CopyTo impl
        {
            byte[] buf = new byte[bufferSize];
            int read;
            switch (Method)
            {
                case ReadMethod.SyncArray:
                    while ((read = source.Read(buf, 0, bufferSize)) > 0)
                    {
                        destination.Write(buf, 0, read);
                    }
                    break;
                case ReadMethod.AsyncArray:
                    while ((read = await source.ReadAsync(buf, 0, bufferSize)) > 0)
                    {
                        await destination.WriteAsync(buf, 0, read);
                    }
                    break;
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
                case ReadMethod.SyncSpan:
                    while ((read = source.Read(new Span<byte>(buf))) > 0)
                    {
                        destination.Write(new Span<byte>(buf, 0, read));
                    }
                    break;
                case ReadMethod.AsyncMemory:
                    while ((read = await source.ReadAsync(new Memory<byte>(buf))) > 0)
                    {
                        await destination.WriteAsync(new Memory<byte>(buf, 0, read));
                    }
                    break;
#endif
            }
            destination.Flush();
        }

        [Test]
        [Pairwise]
        public async Task EncodesData(
            [Values(2048, 2005)] int dataLength,
            [Values(default, 512)] int? seglen,
            [Values(8 * Constants.KB, 512, 530, 3)] int readLen,
            [Values(true, false)] bool useCrc)
        {
            int segmentContentLength = seglen ?? int.MaxValue;
            Flags flags = useCrc ? Flags.StorageCrc64 : Flags.None;

            byte[] originalData = new byte[dataLength];
            new Random().NextBytes(originalData);
            byte[] expectedEncodedData = StructuredMessageHelper.MakeEncodedData(originalData, segmentContentLength, flags);

            Stream encodingStream = new StructuredMessageEncodingStream(new MemoryStream(originalData), segmentContentLength, flags);
            byte[] encodedData;
            using (MemoryStream dest = new())
            {
                await CopyStream(encodingStream, dest, readLen);
                encodedData = dest.ToArray();
            }

            Assert.That(new Span<byte>(encodedData).SequenceEqual(expectedEncodedData));
        }

        [TestCase(0, 0)] // start
        [TestCase(5, 0)] // partway through stream header
        [TestCase(V1_0.StreamHeaderLength, 0)] // start of segment
        [TestCase(V1_0.StreamHeaderLength + 3, 0)] // partway through segment header
        [TestCase(V1_0.StreamHeaderLength + V1_0.SegmentHeaderLength, 0)] // start of segment content
        [TestCase(V1_0.StreamHeaderLength + V1_0.SegmentHeaderLength + 123, 123)] // partway through segment content
        [TestCase(V1_0.StreamHeaderLength + V1_0.SegmentHeaderLength + 512, 512)] // start of segment footer
        [TestCase(V1_0.StreamHeaderLength + V1_0.SegmentHeaderLength + 515, 512)] // partway through segment footer
        [TestCase(V1_0.StreamHeaderLength + 3*V1_0.SegmentHeaderLength + 2*Crc64Length + 1500, 1500)] // partway through not first segment content
        public async Task Seek(int targetRewindOffset, int expectedInnerStreamPosition)
        {
            const int segmentLength = 512;
            const int dataLength = 2055;
            byte[] data = new byte[dataLength];
            new Random().NextBytes(data);

            MemoryStream dataStream = new(data);
            StructuredMessageEncodingStream encodingStream = new(dataStream, segmentLength, Flags.StorageCrc64);

            // no support for seeking past existing read, need to consume whole stream before seeking
            await CopyStream(encodingStream, Stream.Null);

            encodingStream.Position = targetRewindOffset;
            Assert.That(encodingStream.Position, Is.EqualTo(targetRewindOffset));
            Assert.That(dataStream.Position, Is.EqualTo(expectedInnerStreamPosition));
        }

        [TestCase(0)] // start
        [TestCase(5)] // partway through stream header
        [TestCase(V1_0.StreamHeaderLength)] // start of segment
        [TestCase(V1_0.StreamHeaderLength + 3)] // partway through segment header
        [TestCase(V1_0.StreamHeaderLength + V1_0.SegmentHeaderLength)] // start of segment content
        [TestCase(V1_0.StreamHeaderLength + V1_0.SegmentHeaderLength + 123)] // partway through segment content
        [TestCase(V1_0.StreamHeaderLength + V1_0.SegmentHeaderLength + 512)] // start of segment footer
        [TestCase(V1_0.StreamHeaderLength + V1_0.SegmentHeaderLength + 515)] // partway through segment footer
        [TestCase(V1_0.StreamHeaderLength + 2 * V1_0.SegmentHeaderLength + Crc64Length + 1500)] // partway through not first segment content
        public async Task SupportsRewind(int targetRewindOffset)
        {
            const int segmentLength = 512;
            const int dataLength = 2055;
            byte[] data = new byte[dataLength];
            new Random().NextBytes(data);

            Stream encodingStream = new StructuredMessageEncodingStream(new MemoryStream(data), segmentLength, Flags.StorageCrc64);
            byte[] encodedData1;
            using (MemoryStream dest = new())
            {
                await CopyStream(encodingStream, dest);
                encodedData1 = dest.ToArray();
            }
            encodingStream.Position = targetRewindOffset;
            byte[] encodedData2;
            using (MemoryStream dest = new())
            {
                await CopyStream(encodingStream, dest);
                encodedData2 = dest.ToArray();
            }

            Assert.That(new Span<byte>(encodedData1).Slice(targetRewindOffset).SequenceEqual(encodedData2));
        }

        [Test]
        public async Task SupportsFastForward()
        {
            const int segmentLength = 512;
            const int dataLength = 2055;
            byte[] data = new byte[dataLength];
            new Random().NextBytes(data);

            // must have read stream to fastforward. so read whole stream upfront & save result to check later
            Stream encodingStream = new StructuredMessageEncodingStream(new MemoryStream(data), segmentLength, Flags.StorageCrc64);
            byte[] encodedData;
            using (MemoryStream dest = new())
            {
                await CopyStream(encodingStream, dest);
                encodedData = dest.ToArray();
            }

            encodingStream.Position = 0;

            bool skip = false;
            const int increment = 499;
            while (encodingStream.Position < encodingStream.Length)
            {
                if (skip)
                {
                    encodingStream.Position = Math.Min(dataLength, encodingStream.Position + increment);
                    skip = !skip;
                    continue;
                }
                ReadOnlyMemory<byte> expected = new(encodedData, (int)encodingStream.Position,
                    (int)Math.Min(increment, encodedData.Length - encodingStream.Position));
                ReadOnlyMemory<byte> actual;
                using (MemoryStream dest = new(increment))
                {
                    await CopyStream(WindowStream.GetWindow(encodingStream, increment), dest);
                    actual = dest.ToArray();
                }
                Assert.That(expected.Span.SequenceEqual(actual.Span));
                skip = !skip;
            }
        }

        [Test]
        public void NotSupportsFastForwardBeyondLatestRead()
        {
            const int segmentLength = 512;
            const int dataLength = 2055;
            byte[] data = new byte[dataLength];
            new Random().NextBytes(data);

            Stream encodingStream = new StructuredMessageEncodingStream(new MemoryStream(data), segmentLength, Flags.StorageCrc64);

            Assert.That(() => encodingStream.Position = 123, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [Pairwise]
        public async Task WrapperStreamCorrectData(
            [Values(2048, 2005)] int dataLength,
            [Values(8 * Constants.KB, 512, 530, 3)] int readLen)
        {
            int segmentContentLength = dataLength;
            Flags flags = Flags.StorageCrc64;

            byte[] originalData = new byte[dataLength];
            new Random().NextBytes(originalData);
            byte[] crc = CrcInline(originalData);
            byte[] expectedEncodedData = StructuredMessageHelper.MakeEncodedData(originalData, segmentContentLength, flags);

            Stream encodingStream = new StructuredMessagePrecalculatedCrcWrapperStream(new MemoryStream(originalData), crc);
            byte[] encodedData;
            using (MemoryStream dest = new())
            {
                await CopyStream(encodingStream, dest, readLen);
                encodedData = dest.ToArray();
            }

            Assert.That(new Span<byte>(encodedData).SequenceEqual(expectedEncodedData));
        }

        private static void AssertExpectedStreamHeader(ReadOnlySpan<byte> actual, int originalDataLength, Flags flags, int expectedSegments)
        {
            int expectedFooterLen = flags.HasFlag(Flags.StorageCrc64) ? Crc64Length : 0;

            Assert.That(actual.Length, Is.EqualTo(V1_0.StreamHeaderLength));
            Assert.That(actual[0], Is.EqualTo(1));
            Assert.That(BinaryPrimitives.ReadInt64LittleEndian(actual.Slice(1, 8)),
                Is.EqualTo(V1_0.StreamHeaderLength + expectedSegments * (V1_0.SegmentHeaderLength + expectedFooterLen) + originalDataLength));
            Assert.That(BinaryPrimitives.ReadInt16LittleEndian(actual.Slice(9, 2)), Is.EqualTo((short)flags));
            Assert.That(BinaryPrimitives.ReadInt16LittleEndian(actual.Slice(11, 2)), Is.EqualTo((short)expectedSegments));
        }

        private static void AssertExpectedSegmentHeader(ReadOnlySpan<byte> actual, int segmentNum, long contentLength)
        {
            Assert.That(BinaryPrimitives.ReadInt16LittleEndian(actual.Slice(0, 2)), Is.EqualTo((short) segmentNum));
            Assert.That(BinaryPrimitives.ReadInt64LittleEndian(actual.Slice(2, 8)), Is.EqualTo(contentLength));
        }

        private static byte[] CrcInline(ReadOnlySpan<byte> data)
        {
            var crc = StorageCrc64HashAlgorithm.Create();
            crc.Append(data);
            return crc.GetCurrentHash();
        }
    }
}
