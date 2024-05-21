// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers.Binary;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading;
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
    public class StructuredMessageDecodingStreamTests
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

        public StructuredMessageDecodingStreamTests(ReadMethod method)
        {
            Method = method;
        }

        private class CopyStreamException : Exception
        {
            public long TotalCopied { get; }

            public CopyStreamException(Exception inner, long totalCopied)
                : base($"Failed read after {totalCopied}-many bytes.", inner)
            {
                TotalCopied = totalCopied;
            }
        }
        private async ValueTask<long> CopyStream(Stream source, Stream destination, int bufferSize = 81920) // number default for CopyTo impl
        {
            byte[] buf = new byte[bufferSize];
            int read;
            long totalRead = 0;
            try
            {
                switch (Method)
                {
                    case ReadMethod.SyncArray:
                        while ((read = source.Read(buf, 0, bufferSize)) > 0)
                        {
                            totalRead += read;
                            destination.Write(buf, 0, read);
                        }
                        break;
                    case ReadMethod.AsyncArray:
                        while ((read = await source.ReadAsync(buf, 0, bufferSize)) > 0)
                        {
                            totalRead += read;
                            await destination.WriteAsync(buf, 0, read);
                        }
                        break;
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
                    case ReadMethod.SyncSpan:
                        while ((read = source.Read(new Span<byte>(buf))) > 0)
                        {
                            totalRead += read;
                            destination.Write(new Span<byte>(buf, 0, read));
                        }
                        break;
                    case ReadMethod.AsyncMemory:
                        while ((read = await source.ReadAsync(new Memory<byte>(buf))) > 0)
                        {
                            totalRead += read;
                            await destination.WriteAsync(new Memory<byte>(buf, 0, read));
                        }
                        break;
#endif
                }
                destination.Flush();
            }
            catch (Exception ex)
            {
                throw new CopyStreamException(ex, totalRead);
            }
            return totalRead;
        }

        [Test]
        [Pairwise]
        public async Task DecodesData(
            [Values(2048, 2005)] int dataLength,
            [Values(default, 512)] int? seglen,
            [Values(8*Constants.KB, 512, 530, 3)] int readLen,
            [Values(true, false)] bool useCrc)
        {
            int segmentContentLength = seglen ?? int.MaxValue;
            Flags flags = useCrc ? Flags.StorageCrc64 : Flags.None;

            byte[] originalData = new byte[dataLength];
            new Random().NextBytes(originalData);
            byte[] encodedData = StructuredMessageHelper.MakeEncodedData(originalData, segmentContentLength, flags);

            (Stream decodingStream, _) = StructuredMessageDecodingStream.WrapStream(new MemoryStream(encodedData));
            byte[] decodedData;
            using (MemoryStream dest = new())
            {
                await CopyStream(decodingStream, dest, readLen);
                decodedData = dest.ToArray();
            }

            Assert.That(new Span<byte>(decodedData).SequenceEqual(originalData));
        }

        [Test]
        public void BadStreamBadVersion()
        {
            byte[] originalData = new byte[1024];
            new Random().NextBytes(originalData);
            byte[] encodedData = StructuredMessageHelper.MakeEncodedData(originalData, 256, Flags.StorageCrc64);

            encodedData[0] = byte.MaxValue;

            (Stream decodingStream, _) = StructuredMessageDecodingStream.WrapStream(new MemoryStream(encodedData));
            Assert.That(async () => await CopyStream(decodingStream, Stream.Null), Throws.InnerException.TypeOf<InvalidDataException>());
        }

        [Test]
        public async Task BadSegmentCrcThrows()
        {
            const int segmentLength = 256;
            Random r = new();

            byte[] originalData = new byte[2048];
            r.NextBytes(originalData);
            byte[] encodedData = StructuredMessageHelper.MakeEncodedData(originalData, segmentLength, Flags.StorageCrc64);

            const int badBytePos = 1024;
            encodedData[badBytePos] = (byte)~encodedData[badBytePos];

            MemoryStream encodedDataStream = new(encodedData);
            (Stream decodingStream, _) = StructuredMessageDecodingStream.WrapStream(encodedDataStream);

            // manual try/catch to validate the proccess failed mid-stream rather than the end
            const int copyBufferSize = 4;
            bool caught = false;
            try
            {
                await CopyStream(decodingStream, Stream.Null, copyBufferSize);
            }
            catch (CopyStreamException ex)
            {
                caught = true;
                Assert.That(ex.TotalCopied, Is.LessThanOrEqualTo(badBytePos));
            }
            Assert.That(caught);
        }

        [Test]
        public void BadStreamCrcThrows()
        {
            const int segmentLength = 256;
            Random r = new();

            byte[] originalData = new byte[2048];
            r.NextBytes(originalData);
            byte[] encodedData = StructuredMessageHelper.MakeEncodedData(originalData, segmentLength, Flags.StorageCrc64);

            encodedData[originalData.Length - 1] = (byte)~encodedData[originalData.Length - 1];

            (Stream decodingStream, _) = StructuredMessageDecodingStream.WrapStream(new MemoryStream(encodedData));
            Assert.That(async () => await CopyStream(decodingStream, Stream.Null), Throws.InnerException.TypeOf<InvalidDataException>());
        }

        [Test]
        public void BadStreamWrongContentLength()
        {
            byte[] originalData = new byte[1024];
            new Random().NextBytes(originalData);
            byte[] encodedData = StructuredMessageHelper.MakeEncodedData(originalData, 256, Flags.StorageCrc64);

            BinaryPrimitives.WriteInt64LittleEndian(new Span<byte>(encodedData, V1_0.StreamHeaderMessageLengthOffset, 8), 123456789L);

            (Stream decodingStream, _) = StructuredMessageDecodingStream.WrapStream(new MemoryStream(encodedData));
            Assert.That(async () => await CopyStream(decodingStream, Stream.Null), Throws.InnerException.TypeOf<InvalidDataException>());
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void BadStreamWrongSegmentCount(int difference)
        {
            const int dataSize = 1024;
            const int segmentSize = 256;
            const int numSegments = 4;

            byte[] originalData = new byte[dataSize];
            new Random().NextBytes(originalData);
            byte[] encodedData = StructuredMessageHelper.MakeEncodedData(originalData, segmentSize, Flags.StorageCrc64);

            // rewrite the segment count to be different than the actual number of segments
            BinaryPrimitives.WriteInt16LittleEndian(
                new Span<byte>(encodedData, V1_0.StreamHeaderSegmentCountOffset, 2), (short)(numSegments + difference));

            (Stream decodingStream, _) = StructuredMessageDecodingStream.WrapStream(new MemoryStream(encodedData));
            Assert.That(async () => await CopyStream(decodingStream, Stream.Null), Throws.InnerException.TypeOf<InvalidDataException>());
        }

        [Test]
        public void BadStreamWrongSegmentNum()
        {
            byte[] originalData = new byte[1024];
            new Random().NextBytes(originalData);
            byte[] encodedData = StructuredMessageHelper.MakeEncodedData(originalData, 256, Flags.StorageCrc64);

            BinaryPrimitives.WriteInt16LittleEndian(
                new Span<byte>(encodedData, V1_0.StreamHeaderLength + V1_0.SegmentHeaderNumOffset, 2), 123);

            (Stream decodingStream, _) = StructuredMessageDecodingStream.WrapStream(new MemoryStream(encodedData));
            Assert.That(async () => await CopyStream(decodingStream, Stream.Null), Throws.InnerException.TypeOf<InvalidDataException>());
        }

        [Test]
        [Combinatorial]
        public async Task BadStreamWrongContentLength(
            [Values(-1, 1)] int difference,
            [Values(true, false)] bool lengthProvided)
        {
            byte[] originalData = new byte[1024];
            new Random().NextBytes(originalData);
            byte[] encodedData = StructuredMessageHelper.MakeEncodedData(originalData, 256, Flags.StorageCrc64);

            BinaryPrimitives.WriteInt64LittleEndian(
                new Span<byte>(encodedData, V1_0.StreamHeaderMessageLengthOffset, 8),
                encodedData.Length + difference);

            (Stream decodingStream, _) = StructuredMessageDecodingStream.WrapStream(
                new MemoryStream(encodedData),
                lengthProvided ? (long?)encodedData.Length : default);

            // manual try/catch with tiny buffer to validate the proccess failed mid-stream rather than the end
            const int copyBufferSize = 4;
            bool caught = false;
            try
            {
                await CopyStream(decodingStream, Stream.Null, copyBufferSize);
            }
            catch (CopyStreamException ex)
            {
                caught = true;
                if (lengthProvided)
                {
                    Assert.That(ex.TotalCopied, Is.EqualTo(0));
                }
                else
                {
                    Assert.That(ex.TotalCopied, Is.EqualTo(originalData.Length));
                }
            }
            Assert.That(caught);
        }

        [Test]
        public void BadStreamMissingExpectedStreamFooter()
        {
            byte[] originalData = new byte[1024];
            new Random().NextBytes(originalData);
            byte[] encodedData = StructuredMessageHelper.MakeEncodedData(originalData, 256, Flags.StorageCrc64);

            byte[] brokenData = new byte[encodedData.Length - Crc64Length];
            new Span<byte>(encodedData, 0, encodedData.Length - Crc64Length).CopyTo(brokenData);

            (Stream decodingStream, _) = StructuredMessageDecodingStream.WrapStream(new MemoryStream(brokenData));
            Assert.That(async () => await CopyStream(decodingStream, Stream.Null), Throws.InnerException.TypeOf<InvalidDataException>());
        }

        [Test]
        public void NoSeek()
        {
            (Stream stream, _) = StructuredMessageDecodingStream.WrapStream(new MemoryStream());

            Assert.That(stream.CanSeek, Is.False);
            Assert.That(() => stream.Length, Throws.TypeOf<NotSupportedException>());
            Assert.That(() => stream.Position, Throws.TypeOf<NotSupportedException>());
            Assert.That(() => stream.Position = 0, Throws.TypeOf<NotSupportedException>());
            Assert.That(() => stream.Seek(0, SeekOrigin.Begin), Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public void NoWrite()
        {
            (Stream stream, _) = StructuredMessageDecodingStream.WrapStream(new MemoryStream());
            byte[] data = new byte[1024];
            new Random().NextBytes(data);

            Assert.That(stream.CanWrite, Is.False);
            Assert.That(() => stream.Write(data, 0, data.Length),
                Throws.TypeOf<NotSupportedException>());
            Assert.That(async () => await stream.WriteAsync(data, 0, data.Length, CancellationToken.None),
                Throws.TypeOf<NotSupportedException>());
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
            Assert.That(() => stream.Write(new Span<byte>(data)),
                Throws.TypeOf<NotSupportedException>());
            Assert.That(async () => await stream.WriteAsync(new Memory<byte>(data), CancellationToken.None),
                Throws.TypeOf<NotSupportedException>());
#endif
        }
    }
}
