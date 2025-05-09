// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.IO;
using Azure.Storage.Common;

namespace Azure.Storage.Shared;

internal static class StructuredMessage
{
    public const int Crc64Length = 8;

    [Flags]
    public enum Flags
    {
        None = 0,
        StorageCrc64 = 1,
    }

    public static class V1_0
    {
        public const byte MessageVersionByte = 1;

        public const int StreamHeaderLength = 13;
        public const int StreamHeaderVersionOffset = 0;
        public const int StreamHeaderMessageLengthOffset = 1;
        public const int StreamHeaderFlagsOffset = 9;
        public const int StreamHeaderSegmentCountOffset = 11;

        public const int SegmentHeaderLength = 10;
        public const int SegmentHeaderNumOffset = 0;
        public const int SegmentHeaderContentLengthOffset = 2;

        #region Stream Header
        public static void ReadStreamHeader(
            ReadOnlySpan<byte> buffer,
            out long messageLength,
            out Flags flags,
            out int totalSegments)
        {
            Errors.AssertBufferExactSize(buffer, 13, nameof(buffer));
            if (buffer[StreamHeaderVersionOffset] != 1)
            {
                throw new InvalidDataException("Unrecognized version of structured message.");
            }
            messageLength = (long)BinaryPrimitives.ReadUInt64LittleEndian(buffer.Slice(StreamHeaderMessageLengthOffset, 8));
            flags = (Flags)BinaryPrimitives.ReadUInt16LittleEndian(buffer.Slice(StreamHeaderFlagsOffset, 2));
            totalSegments = BinaryPrimitives.ReadUInt16LittleEndian(buffer.Slice(StreamHeaderSegmentCountOffset, 2));
        }

        public static int WriteStreamHeader(
            Span<byte> buffer,
            long messageLength,
            Flags flags,
            int totalSegments)
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

        #region StreamFooter
        public static int GetStreamFooterSize(Flags flags)
            => flags.HasFlag(Flags.StorageCrc64) ? Crc64Length : 0;

        public static void ReadStreamFooter(
            ReadOnlySpan<byte> buffer,
            Flags flags,
            out ulong crc64)
        {
            int expectedBufferSize = GetSegmentFooterSize(flags);
            Errors.AssertBufferExactSize(buffer, expectedBufferSize, nameof(buffer));

            crc64 = flags.HasFlag(Flags.StorageCrc64) ? buffer.ReadCrc64() : default;
        }

        public static int WriteStreamFooter(Span<byte> buffer, ReadOnlySpan<byte> crc64 = default)
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
        public static IDisposable GetStreamFooterBytes(
            ArrayPool<byte> pool,
            out Memory<byte> bytes,
            ReadOnlySpan<byte> crc64 = default)
        {
            Argument.AssertNotNull(pool, nameof(pool));
            IDisposable disposable = pool.RentAsMemoryDisposable(StreamHeaderLength, out bytes);
            WriteStreamFooter(bytes.Span, crc64);
            return disposable;
        }
        #endregion

        #region SegmentHeader
        public static void ReadSegmentHeader(
            ReadOnlySpan<byte> buffer,
            out int segmentNum,
            out long contentLength)
        {
            Errors.AssertBufferExactSize(buffer, 10, nameof(buffer));
            segmentNum = BinaryPrimitives.ReadUInt16LittleEndian(buffer.Slice(0, 2));
            contentLength = (long)BinaryPrimitives.ReadUInt64LittleEndian(buffer.Slice(2, 8));
        }

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
        public static int GetSegmentFooterSize(Flags flags)
            => flags.HasFlag(Flags.StorageCrc64) ? Crc64Length : 0;

        public static void ReadSegmentFooter(
            ReadOnlySpan<byte> buffer,
            Flags flags,
            out ulong crc64)
        {
            int expectedBufferSize = GetSegmentFooterSize(flags);
            Errors.AssertBufferExactSize(buffer, expectedBufferSize, nameof(buffer));

            crc64 = flags.HasFlag(Flags.StorageCrc64) ? buffer.ReadCrc64() : default;
        }

        public static int WriteSegmentFooter(Span<byte> buffer, ReadOnlySpan<byte> crc64 = default)
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
            ReadOnlySpan<byte> crc64 = default)
        {
            Argument.AssertNotNull(pool, nameof(pool));
            IDisposable disposable = pool.RentAsMemoryDisposable(StreamHeaderLength, out bytes);
            WriteSegmentFooter(bytes.Span, crc64);
            return disposable;
        }
        #endregion
    }
}
