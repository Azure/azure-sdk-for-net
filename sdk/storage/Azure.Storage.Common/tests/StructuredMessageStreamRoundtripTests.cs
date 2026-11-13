// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    public class StructuredMessageStreamRoundtripTests
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

        public StructuredMessageStreamRoundtripTests(ReadMethod method)
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
        public async Task RoundTrip(
            [Values(2048, 2005)] int dataLength,
            [Values(default, 512)] int? seglen,
            [Values(8 * Constants.KB, 512, 530, 3)] int readLen,
            [Values(true, false)] bool useCrc)
        {
            int segmentLength = seglen ?? int.MaxValue;
            Flags flags = useCrc ? Flags.StorageCrc64 : Flags.None;

            byte[] originalData = new byte[dataLength];
            new Random().NextBytes(originalData);

            byte[] roundtripData;
            using (MemoryStream source = new(originalData))
            using (Stream encode = new StructuredMessageEncodingStream(source, segmentLength, flags))
            using (Stream decode = StructuredMessageDecodingStream.WrapStream(encode).DecodedStream)
            using (MemoryStream dest = new())
            {
                await CopyStream(source, dest, readLen);
                roundtripData = dest.ToArray();
            }

            Assert.That(originalData.SequenceEqual(roundtripData));
        }
    }
}
