// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task DecodesData(
            [Values(2048, 2005)] int dataLength,
            [Values(default, 512)] int? seglen,
            [Values(8*Constants.KB, 512, 530, 3)] int readLen,
            [Values(true, false)] bool useCrc)
        {
            int segmentContentLength = seglen ?? int.MaxValue;
            Flags flags = useCrc ? Flags.CrcSegment : Flags.None;

            byte[] originalData = new byte[dataLength];
            new Random().NextBytes(originalData);
            byte[] encodedData = StructuredMessageHelper.MakeEncodedData(originalData, segmentContentLength, flags);

            Stream encodingStream = new StructuredMessageDecodingStream(new MemoryStream(encodedData));
            byte[] decodedData;
            using (MemoryStream dest = new())
            {
                await CopyStream(encodingStream, dest, readLen);
                decodedData = dest.ToArray();
            }

            Assert.That(new Span<byte>(decodedData).SequenceEqual(originalData));
        }

        [Test]
        public void NoSeek()
        {
            StructuredMessageDecodingStream stream = new(new MemoryStream());

            Assert.That(stream.CanSeek, Is.False);
            Assert.That(() => stream.Length, Throws.TypeOf<NotSupportedException>());
            Assert.That(() => stream.Position, Throws.TypeOf<NotSupportedException>());
            Assert.That(() => stream.Position = 0, Throws.TypeOf<NotSupportedException>());
            Assert.That(() => stream.Seek(0, SeekOrigin.Begin), Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public void NoWrite()
        {
            StructuredMessageDecodingStream stream = new(new MemoryStream());
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
