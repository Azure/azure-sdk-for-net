// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Storage.Shared;
using NUnit.Framework;
using static Azure.Storage.Shared.StructuredMessage;

namespace Azure.Storage.Tests
{
    public class StructuredMessageEncodingStreamTests
    {
        [Test]
        public void EncodesDataSingleSegment([Values(Flags.None, Flags.CrcSegment)] int flags)
        {
            const int expectedHeaderLen = V1_0.StreamHeaderLength + V1_0.SegmentHeaderLength;
            int expectedFooterLen = ((Flags)flags).HasFlag(Flags.CrcSegment) ? Crc64Length : 0;

            byte[] data = new byte[1024];
            new Random().NextBytes(data);
            byte[] expectedHeader = new byte[expectedHeaderLen];
            byte[] expectedFooter = new byte[expectedFooterLen];
            V1_0.WriteStreamHeader(
                new Span<byte>(expectedHeader, 0, V1_0.StreamHeaderLength),
                messageLength: data.Length + expectedHeaderLen + expectedFooterLen,
                (Flags)flags,
                totalSegments: 1);
            V1_0.WriteSegmentHeader(
                new Span<byte>(expectedHeader, V1_0.StreamHeaderLength, V1_0.SegmentHeaderLength),
                segmentNum: 1,
                segmentLength: 1024);
            if (((Flags)flags).HasFlag(Flags.CrcSegment))
            {
                V1_0.WriteSegmentFooter(expectedFooter, new byte[Crc64Length]); // TODO actual crc
            }

            Stream encodingStream = new StructuredMessageEncodingStream(new MemoryStream(data), 1024, (Flags)flags);
            MemoryStream dest = new();
            encodingStream.CopyTo(dest);
            byte[] encodedData = dest.ToArray();

            Assert.That(encodedData.Length, Is.EqualTo(data.Length + expectedHeaderLen + expectedFooterLen));
            Assert.That(new Span<byte>(encodedData, 0, expectedHeaderLen).SequenceEqual(expectedHeader), Is.True);
            if (((Flags)flags).HasFlag(Flags.CrcSegment))
            {
                Assert.That(new Span<byte>(encodedData, expectedHeaderLen + data.Length, expectedFooterLen)
                    .SequenceEqual(expectedFooter), Is.True);
            }
        }
    }
}
