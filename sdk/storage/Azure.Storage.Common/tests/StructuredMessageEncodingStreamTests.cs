// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers.Binary;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        [Combinatorial]
        public async Task EncodesDataSingleSegment(
            [Values(Flags.None, Flags.CrcSegment)] int flagsInt,
            [Values(1024, 1001)] int dataLength)
        {
            Flags flags = (Flags)flagsInt;
            const int expectedHeaderLen = V1_0.StreamHeaderLength + V1_0.SegmentHeaderLength;
            int expectedFooterLen = flags.HasFlag(Flags.CrcSegment) ? Crc64Length : 0;

            byte[] data = new byte[dataLength];
            new Random().NextBytes(data);
            byte[] expectedHeader = new byte[expectedHeaderLen];
            byte[] expectedFooter = new byte[expectedFooterLen];
            V1_0.WriteStreamHeader(
                new Span<byte>(expectedHeader, 0, V1_0.StreamHeaderLength),
                messageLength: data.Length + expectedHeaderLen + expectedFooterLen,
                flags,
                totalSegments: 1);
            V1_0.WriteSegmentHeader(
                new Span<byte>(expectedHeader, V1_0.StreamHeaderLength, V1_0.SegmentHeaderLength),
                segmentNum: 1,
                segmentLength: dataLength);
            if (flags.HasFlag(Flags.CrcSegment))
            {
                V1_0.WriteSegmentFooter(expectedFooter, new byte[Crc64Length]); // TODO actual crc
            }

            Stream encodingStream = new StructuredMessageEncodingStream(new MemoryStream(data), 1024, flags);
            MemoryStream dest = new();
            await CopyStream(encodingStream, dest);
            byte[] encodedData = dest.ToArray();

            Assert.That(encodedData.Length, Is.EqualTo(data.Length + expectedHeaderLen + expectedFooterLen));
            Assert.That(new Span<byte>(encodedData, 0, expectedHeaderLen).SequenceEqual(expectedHeader), Is.True);
            if (flags.HasFlag(Flags.CrcSegment))
            {
                Assert.That(new Span<byte>(encodedData, expectedHeaderLen + data.Length, expectedFooterLen)
                    .SequenceEqual(expectedFooter), Is.True);
            }
        }

        [Test]
        [Combinatorial]
        public async Task EncodesDataMultiSegment(
            [Values(Flags.None, Flags.CrcSegment)] int flagsInt,
            [Values(2048, 2005)] int dataLength)
        {
            const int segmentLength = 512;
            const int expectedNumSegments = 4;
            Flags flags = (Flags)flagsInt;
            int expectedSegFooterLen = flags.HasFlag(Flags.CrcSegment) ? Crc64Length : 0;
            int expectedEncodedDataLen = V1_0.StreamHeaderLength +
                (expectedNumSegments * (V1_0.SegmentHeaderLength + expectedSegFooterLen))
                + dataLength;

            byte[] data = new byte[dataLength];
            new Random().NextBytes(data);

            Stream encodingStream = new StructuredMessageEncodingStream(new MemoryStream(data), segmentLength, flags);
            MemoryStream dest = new();
            await CopyStream(encodingStream, dest);
            byte[] encodedData = dest.ToArray();

            Assert.That(encodedData.Length, Is.EqualTo(expectedEncodedDataLen));
            AssertExpectedStreamHeader(new Span<byte>(encodedData, 0, V1_0.StreamHeaderLength),
                dataLength, flags, expectedNumSegments);
            foreach (int segNum in Enumerable.Range(1, expectedNumSegments))
            {
                int segOffset = V1_0.StreamHeaderLength + ((segNum - 1) * (V1_0.SegmentHeaderLength + segmentLength + expectedSegFooterLen));
                int segContentLength = Math.Min(segmentLength, dataLength - ((segNum-1) * segmentLength));
                AssertExpectedSegmentHeader(new Span<byte>(encodedData, segOffset, V1_0.SegmentHeaderLength), segNum, segContentLength);
                Assert.That(new Span<byte>(encodedData, segOffset + V1_0.SegmentHeaderLength, segContentLength)
                    .SequenceEqual(new Span<byte>(data, (segNum - 1) * segmentLength, segContentLength)), Is.True);
                if (flags.HasFlag(Flags.CrcSegment))
                {
                    Assert.That(new Span<byte>(encodedData, segOffset + V1_0.SegmentHeaderLength + segContentLength, Crc64Length)
                        .SequenceEqual(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }), Is.True); // TODO
                }
            }
        }

        private static void AssertExpectedStreamHeader(ReadOnlySpan<byte> actual, int originalDataLength, Flags flags, int expectedSegments)
        {
            int expectedFooterLen = flags.HasFlag(Flags.CrcSegment) ? Crc64Length : 0;

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
    }
}
