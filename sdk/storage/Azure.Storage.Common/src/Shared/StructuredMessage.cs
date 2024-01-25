// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Security.Cryptography;
using Azure.Core;

namespace Azure.Storage.Shared;

internal static class StructuredMessage
{
    public const int Crc64Length = 8;

    [Flags]
    public enum Flags
    {
        None = 0,
        CrcSegment = 1,
    }

    public static class V1_0
    {
        public const byte MessageVersionByte = 1;

        public const int StreamHeaderLength = 13;
        public const int SegmentHeaderLength = 10;

        #region Stream Header
        public static int WriteStreamHeader(Span<byte> buffer, long messageLength, Flags flags, int totalSegments)
        {
            const int versionOffset = 0;
            const int messageLengthOffset = 1;
            const int flagsOffset = 9;
            const int numSegmentsOffset = 11;

            Errors.AssertBufferMinimumSize(buffer, StreamHeaderLength, nameof(buffer));

            buffer[versionOffset] = MessageVersionByte;
            BinaryPrimitives.WriteUInt64LittleEndian(buffer.Slice(messageLengthOffset, 8), (ulong)messageLength);
            BinaryPrimitives.WriteUInt16LittleEndian(buffer.Slice(flagsOffset, 2), (ushort)flags);
            BinaryPrimitives.WriteUInt16LittleEndian(buffer.Slice(numSegmentsOffset, 2), (ushort)totalSegments);

            return StreamHeaderLength;
        }

        /// <summary>
        /// Gets stream header in a buffer rented from the provided ArrayPool.
        /// </summary>
        /// <returns>
        /// Disposable to return the buffer to the pool.
        /// </returns>
        public static IDisposable GetStreamHeaderBytes(
            ArrayPool<byte> pool,
            out Memory<byte> bytes,
            long messageLength,
            Flags flags,
            int totalSegments)
        {
            Argument.AssertNotNull(pool, nameof(pool));
            IDisposable disposable = pool.RentAsMemoryDisposable(StreamHeaderLength, out bytes);
            WriteStreamHeader(bytes.Span, messageLength, flags, totalSegments);
            return disposable;
        }
        #endregion

        // no stream footer content in 1.0

        #region SegmentHeader
        public static int WriteSegmentHeader(Span<byte> buffer, int segmentNum, long segmentLength)
        {
            const int segmentNumOffset = 0;
            const int segmentLengthOffset = 2;

            Errors.AssertBufferMinimumSize(buffer, SegmentHeaderLength, nameof(buffer));

            BinaryPrimitives.WriteUInt16LittleEndian(buffer.Slice(segmentNumOffset, 2), (ushort)segmentNum);
            BinaryPrimitives.WriteUInt64LittleEndian(buffer.Slice(segmentLengthOffset, 8), (ulong)segmentLength);

            return SegmentHeaderLength;
        }

        /// <summary>
        /// Gets segment header in a buffer rented from the provided ArrayPool.
        /// </summary>
        /// <returns>
        /// Disposable to return the buffer to the pool.
        /// </returns>
        public static IDisposable GetSegmentHeaderBytes(
            ArrayPool<byte> pool,
            out Memory<byte> bytes,
            int segmentNum,
            long segmentLength)
        {
            Argument.AssertNotNull(pool, nameof(pool));
            IDisposable disposable = pool.RentAsMemoryDisposable(SegmentHeaderLength, out bytes);
            WriteSegmentHeader(bytes.Span, segmentNum, segmentLength);
            return disposable;
        }
        #endregion

        #region SegmentFooter
        public static int WriteSegmentFooter(Span<byte> buffer, Span<byte> crc64 = default)
        {
            int requiredSpace = 0;
            if (!crc64.IsEmpty)
            {
                Errors.AssertBufferExactSize(crc64, Crc64Length, nameof(crc64));
                requiredSpace += Crc64Length;
            }

            Errors.AssertBufferMinimumSize(buffer, requiredSpace, nameof(buffer));
            int offset = 0;
            if (!crc64.IsEmpty)
            {
                crc64.CopyTo(buffer.Slice(offset, Crc64Length));
                offset += Crc64Length;
            }

            return offset;
        }

        /// <summary>
        /// Gets stream header in a buffer rented from the provided ArrayPool.
        /// </summary>
        /// <returns>
        /// Disposable to return the buffer to the pool.
        /// </returns>
        public static IDisposable GetSegmentFooterBytes(
            ArrayPool<byte> pool,
            out Memory<byte> bytes,
            Span<byte> crc64 = default)
        {
            Argument.AssertNotNull(pool, nameof(pool));
            IDisposable disposable = pool.RentAsMemoryDisposable(StreamHeaderLength, out bytes);
            WriteSegmentFooter(bytes.Span, crc64);
            return disposable;
        }
        #endregion
    }
}
