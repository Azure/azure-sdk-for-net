// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using NUnit.Framework;
using static Azure.Storage.Shared.StructuredMessage;

namespace Azure.Storage.Tests
{
    public class StructuredMessageTests
    {
        [TestCase(1024, Flags.None, 2)]
        [TestCase(2000, Flags.StorageCrc64, 4)]
        public void EncodeStreamHeader(int messageLength, int flags, int numSegments)
        {
            Span<byte> encoding = new(new byte[V1_0.StreamHeaderLength]);
            V1_0.WriteStreamHeader(encoding, messageLength, (Flags)flags, numSegments);

            Assert.That(encoding[0], Is.EqualTo((byte)1));
            Assert.That(BinaryPrimitives.ReadUInt64LittleEndian(encoding.Slice(1, 8)), Is.EqualTo(messageLength));
            Assert.That(BinaryPrimitives.ReadUInt16LittleEndian(encoding.Slice(9, 2)), Is.EqualTo(flags));
            Assert.That(BinaryPrimitives.ReadUInt16LittleEndian(encoding.Slice(11, 2)), Is.EqualTo(numSegments));
        }

        [TestCase(V1_0.StreamHeaderLength)]
        [TestCase(V1_0.StreamHeaderLength + 1)]
        [TestCase(V1_0.StreamHeaderLength - 1)]
        public void EncodeStreamHeaderRejectBadBufferSize(int bufferSize)
        {
            Random r = new();
            byte[] encoding = new byte[bufferSize];

            void Action() => V1_0.WriteStreamHeader(encoding, r.Next(2, int.MaxValue), Flags.StorageCrc64, r.Next(2, int.MaxValue));
            if (bufferSize < V1_0.StreamHeaderLength)
            {
                Assert.That(Action, Throws.ArgumentException);
            }
            else
            {
                Assert.That(Action, Throws.Nothing);
            }
        }

        [TestCase(1, 1024)]
        [TestCase(5, 39578)]
        public void EncodeSegmentHeader(int segmentNum, int contentLength)
        {
            Span<byte> encoding = new(new byte[V1_0.SegmentHeaderLength]);
            V1_0.WriteSegmentHeader(encoding, segmentNum, contentLength);

            Assert.That(BinaryPrimitives.ReadUInt16LittleEndian(encoding.Slice(0, 2)), Is.EqualTo(segmentNum));
            Assert.That(BinaryPrimitives.ReadUInt64LittleEndian(encoding.Slice(2, 8)), Is.EqualTo(contentLength));
        }

        [TestCase(V1_0.SegmentHeaderLength)]
        [TestCase(V1_0.SegmentHeaderLength + 1)]
        [TestCase(V1_0.SegmentHeaderLength - 1)]
        public void EncodeSegmentHeaderRejectBadBufferSize(int bufferSize)
        {
            Random r = new();
            byte[] encoding = new byte[bufferSize];

            void Action() => V1_0.WriteSegmentHeader(encoding, r.Next(1, int.MaxValue), r.Next(2, int.MaxValue));
            if (bufferSize < V1_0.SegmentHeaderLength)
            {
                Assert.That(Action, Throws.ArgumentException);
            }
            else
            {
                Assert.That(Action, Throws.Nothing);
            }
        }

        [TestCase(true)]
        [TestCase(false)]
        public void EncodeSegmentFooter(bool useCrc)
        {
            Span<byte> encoding = new(new byte[Crc64Length]);
            Span<byte> crc = useCrc ? new Random().NextBytesInline(Crc64Length) : default;
            V1_0.WriteSegmentFooter(encoding, crc);

            if (useCrc)
            {
                Assert.That(encoding.SequenceEqual(crc), Is.True);
            }
            else
            {
                Assert.That(encoding.SequenceEqual(new Span<byte>(new byte[Crc64Length])), Is.True);
            }
        }

        [TestCase(Crc64Length)]
        [TestCase(Crc64Length + 1)]
        [TestCase(Crc64Length - 1)]
        public void EncodeSegmentFooterRejectBadBufferSize(int bufferSize)
        {
            byte[] encoding = new byte[bufferSize];
            byte[] crc = new byte[Crc64Length];
            new Random().NextBytes(crc);

            void Action() => V1_0.WriteSegmentFooter(encoding, crc);
            if (bufferSize < Crc64Length)
            {
                Assert.That(Action, Throws.ArgumentException);
            }
            else
            {
                Assert.That(Action, Throws.Nothing);
            }
        }
    }
}
