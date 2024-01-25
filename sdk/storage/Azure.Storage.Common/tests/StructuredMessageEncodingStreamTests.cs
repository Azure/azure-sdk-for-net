// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Storage.Shared;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class StructuredMessageEncodingStreamTests
    {
        [Test]
        public void EncodesDataSingleSegment()
        {
            const int ExpectedHeaderExpansion = StructuredMessage.V1_0.StreamHeaderLength + StructuredMessage.V1_0.SegmentHeaderLength;
            byte[] data = new byte[1024];
            new Random().NextBytes(data);
            byte[] expectedOpening = new byte[ExpectedHeaderExpansion];
            StructuredMessage.V1_0.WriteStreamHeader(
                new Span<byte>(expectedOpening, 0, StructuredMessage.V1_0.StreamHeaderLength),
                messageLength: data.Length + ExpectedHeaderExpansion,
                StructuredMessage.Flags.None,
                totalSegments: 1);
            StructuredMessage.V1_0.WriteSegmentHeader(
                new Span<byte>(expectedOpening, StructuredMessage.V1_0.StreamHeaderLength, StructuredMessage.V1_0.SegmentHeaderLength),
                segmentNum: 1,
                segmentLength: 1024);

            Stream encodingStream = new StructuredMessageEncodingStream(new MemoryStream(data), 1024, StructuredMessage.Flags.None);
            MemoryStream dest = new();
            encodingStream.CopyTo(dest);
            byte[] encodedData = dest.ToArray();

            Assert.That(encodedData.Length, Is.EqualTo(data.Length + ExpectedHeaderExpansion));
            Assert.That(new Span<byte>(encodedData, 0, ExpectedHeaderExpansion).SequenceEqual(expectedOpening), Is.True);
        }
    }
}
