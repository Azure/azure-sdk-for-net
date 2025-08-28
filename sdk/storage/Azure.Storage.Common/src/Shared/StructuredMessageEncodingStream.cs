// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage.Shared;

internal class StructuredMessageEncodingStream : Stream
{
    private readonly Stream _innerStream;

    private readonly int _streamHeaderLength;
    private readonly int _streamFooterLength;
    private readonly int _segmentHeaderLength;
    private readonly int _segmentFooterLength;
    private readonly int _segmentContentLength;

    private readonly StructuredMessage.Flags _flags;
    private bool _disposed;

    private bool UseCrcSegment => _flags.HasFlag(StructuredMessage.Flags.StorageCrc64);
    private readonly StorageCrc64HashAlgorithm _totalCrc;
    private StorageCrc64HashAlgorithm _segmentCrc;
    private readonly byte[] _segmentCrcs;
    private int _latestSegmentCrcd = 0;

    #region Segments
    /// <summary>
    /// Gets the 1-indexed segment number the underlying stream is currently positioned in.
    /// 1-indexed to match segment labelling as specified by SM spec.
    /// </summary>
    private int CurrentInnerSegment => (int)Math.Floor(_innerStream.Position / (float)_segmentContentLength) + 1;

    /// <summary>
    /// Gets the 1-indexed segment number the encoded data stream is currently positioned in.
    /// 1-indexed to match segment labelling as specified by SM spec.
    /// </summary>
    private int CurrentEncodingSegment
    {
        get
        {
            // edge case: always on final segment when at end of inner stream
            if (_innerStream.Position == _innerStream.Length)
            {
                return TotalSegments;
            }
            // when writing footer, inner stream is positioned at next segment,
            // but this stream is still writing the previous one
            if (_currentRegion == SMRegion.SegmentFooter)
            {
                return CurrentInnerSegment - 1;
            }
            return CurrentInnerSegment;
        }
    }

    /// <summary>
    /// Segment length including header and footer.
    /// </summary>
    private int SegmentTotalLength => _segmentHeaderLength + _segmentContentLength + _segmentFooterLength;

    private int TotalSegments => GetTotalSegments(_innerStream, _segmentContentLength);
    private static int GetTotalSegments(Stream innerStream, long segmentContentLength)
    {
        return (int)Math.Ceiling(innerStream.Length / (float)segmentContentLength);
    }
    #endregion

    public override bool CanRead => true;

    public override bool CanWrite => false;

    public override bool CanSeek => _innerStream.CanSeek;

    public override bool CanTimeout => _innerStream.CanTimeout;

    public override int ReadTimeout => _innerStream.ReadTimeout;

    public override int WriteTimeout => _innerStream.WriteTimeout;

    public override long Length =>
        _streamHeaderLength + _streamFooterLength +
        (_segmentHeaderLength + _segmentFooterLength) * TotalSegments +
        _innerStream.Length;

    #region Position
    private enum SMRegion
    {
        StreamHeader,
        StreamFooter,
        SegmentHeader,
        SegmentFooter,
        SegmentContent,
    }

    private SMRegion _currentRegion = SMRegion.StreamHeader;
    private int _currentRegionPosition = 0;

    private long _maxSeekPosition = 0;

    public override long Position
    {
        get
        {
            return _currentRegion switch
            {
                SMRegion.StreamHeader => _currentRegionPosition,
                SMRegion.StreamFooter => _streamHeaderLength +
                    TotalSegments * (_segmentHeaderLength + _segmentFooterLength) +
                    _innerStream.Length +
                    _currentRegionPosition,
                SMRegion.SegmentHeader => _innerStream.Position +
                    _streamHeaderLength +
                    (CurrentEncodingSegment - 1) * (_segmentHeaderLength + _segmentFooterLength) +
                    _currentRegionPosition,
                SMRegion.SegmentFooter => _innerStream.Position +
                    _streamHeaderLength +
                    // Inner stream has moved to next segment but we're still writing the previous segment footer
                    CurrentEncodingSegment * (_segmentHeaderLength + _segmentFooterLength) -
                    _segmentFooterLength + _currentRegionPosition,
                SMRegion.SegmentContent => _innerStream.Position +
                    _streamHeaderLength +
                    CurrentEncodingSegment * (_segmentHeaderLength + _segmentFooterLength) -
                    _segmentFooterLength,
                _ => throw new InvalidDataException($"{nameof(StructuredMessageEncodingStream)} invalid state."),
            };
        }
        set
        {
            Argument.AssertInRange(value, 0, _maxSeekPosition, nameof(value));
            if (value < _streamHeaderLength)
            {
                _currentRegion = SMRegion.StreamHeader;
                _currentRegionPosition = (int)value;
                _innerStream.Position = 0;
                return;
            }
            if (value >= Length - _streamFooterLength)
            {
                _currentRegion = SMRegion.StreamFooter;
                _currentRegionPosition = (int)(value - (Length - _streamFooterLength));
                _innerStream.Position = _innerStream.Length;
                return;
            }
            int newSegmentNum = 1 + (int)Math.Floor((value - _streamHeaderLength) / (double)(_segmentHeaderLength + _segmentFooterLength + _segmentContentLength));
            int segmentPosition = (int)(value - _streamHeaderLength -
                ((newSegmentNum - 1) * (_segmentHeaderLength + _segmentFooterLength + _segmentContentLength)));

            if (segmentPosition < _segmentHeaderLength)
            {
                _currentRegion = SMRegion.SegmentHeader;
                _currentRegionPosition = (int)((value - _streamHeaderLength) % SegmentTotalLength);
                _innerStream.Position = (newSegmentNum - 1) * _segmentContentLength;
                return;
            }
            if (segmentPosition < _segmentHeaderLength + _segmentContentLength)
            {
                _currentRegion = SMRegion.SegmentContent;
                _currentRegionPosition = (int)((value - _streamHeaderLength) % SegmentTotalLength) -
                    _segmentHeaderLength;
                _innerStream.Position = (newSegmentNum - 1) * _segmentContentLength + _currentRegionPosition;
                return;
            }

            _currentRegion = SMRegion.SegmentFooter;
            _currentRegionPosition = (int)((value - _streamHeaderLength) % SegmentTotalLength) -
                    _segmentHeaderLength - _segmentContentLength;
            _innerStream.Position = newSegmentNum * _segmentContentLength;
        }
    }
    #endregion

    public StructuredMessageEncodingStream(
        Stream innerStream,
        int segmentContentLength,
        StructuredMessage.Flags flags)
    {
        Argument.AssertNotNull(innerStream, nameof(innerStream));
        if (innerStream.GetLengthOrDefault() == default)
        {
            throw new ArgumentException("Stream must have known length.", nameof(innerStream));
        }
        if (innerStream.Position != 0)
        {
            throw new ArgumentException("Stream must be at starting position.", nameof(innerStream));
        }
        // stream logic likely breaks down with segment length of 1; enforce >=2 rather than just positive number
        // real world scenarios will probably use a minimum of tens of KB
        Argument.AssertInRange(segmentContentLength, 2, int.MaxValue, nameof(segmentContentLength));

        _flags = flags;
        _segmentContentLength = segmentContentLength;

        _streamHeaderLength = StructuredMessage.V1_0.StreamHeaderLength;
        _streamFooterLength = UseCrcSegment ? StructuredMessage.Crc64Length : 0;
        _segmentHeaderLength = StructuredMessage.V1_0.SegmentHeaderLength;
        _segmentFooterLength = UseCrcSegment ? StructuredMessage.Crc64Length : 0;

        if (UseCrcSegment)
        {
            _totalCrc = StorageCrc64HashAlgorithm.Create();
            _segmentCrc = StorageCrc64HashAlgorithm.Create();
            _segmentCrcs = ArrayPool<byte>.Shared.Rent(
                GetTotalSegments(innerStream, segmentContentLength) * StructuredMessage.Crc64Length);
            innerStream = ChecksumCalculatingStream.GetReadStream(innerStream, span =>
            {
                _totalCrc.Append(span);
                _segmentCrc.Append(span);
            });
        }

        _innerStream = innerStream;
    }

    #region Write
    public override void Flush() => throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

    public override void SetLength(long value) => throw new NotSupportedException();
    #endregion

    #region Read
    public override int Read(byte[] buffer, int offset, int count)
        => ReadInternal(buffer, offset, count, async: false, cancellationToken: default).EnsureCompleted();

    public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        => await ReadInternal(buffer, offset, count, async: true, cancellationToken).ConfigureAwait(false);

    private async ValueTask<int> ReadInternal(byte[] buffer, int offset, int count, bool async, CancellationToken cancellationToken)
    {
        int totalRead = 0;
        bool readInner = false;
        while (totalRead < count && Position < Length)
        {
            int subreadOffset = offset + totalRead;
            int subreadCount = count - totalRead;
            switch (_currentRegion)
            {
                case SMRegion.StreamHeader:
                    totalRead += ReadFromStreamHeader(new Span<byte>(buffer, subreadOffset, subreadCount));
                    break;
                case SMRegion.StreamFooter:
                    totalRead += ReadFromStreamFooter(new Span<byte>(buffer, subreadOffset, subreadCount));
                    break;
                case SMRegion.SegmentHeader:
                    totalRead += ReadFromSegmentHeader(new Span<byte>(buffer, subreadOffset, subreadCount));
                    break;
                case SMRegion.SegmentFooter:
                    totalRead += ReadFromSegmentFooter(new Span<byte>(buffer, subreadOffset, subreadCount));
                    break;
                case SMRegion.SegmentContent:
                    // don't double read from stream. Allow caller to multi-read when desired.
                    if (readInner)
                    {
                        UpdateLatestPosition();
                        return totalRead;
                    }
                    totalRead += await ReadFromInnerStreamInternal(
                        buffer, subreadOffset, subreadCount, async, cancellationToken).ConfigureAwait(false);
                    readInner = true;
                    break;
                default:
                    break;
            }
        }
        UpdateLatestPosition();
        return totalRead;
    }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    public override int Read(Span<byte> buffer)
    {
        int totalRead = 0;
        bool readInner = false;
        while (totalRead < buffer.Length && Position < Length)
        {
            switch (_currentRegion)
            {
                case SMRegion.StreamHeader:
                    totalRead += ReadFromStreamHeader(buffer.Slice(totalRead));
                    break;
                case SMRegion.StreamFooter:
                    totalRead += ReadFromStreamFooter(buffer.Slice(totalRead));
                    break;
                case SMRegion.SegmentHeader:
                    totalRead += ReadFromSegmentHeader(buffer.Slice(totalRead));
                    break;
                case SMRegion.SegmentFooter:
                    totalRead += ReadFromSegmentFooter(buffer.Slice(totalRead));
                    break;
                case SMRegion.SegmentContent:
                    // don't double read from stream. Allow caller to multi-read when desired.
                    if (readInner)
                    {
                        UpdateLatestPosition();
                        return totalRead;
                    }
                    totalRead += ReadFromInnerStream(buffer.Slice(totalRead));
                    readInner = true;
                    break;
                default:
                    break;
            }
        }
        UpdateLatestPosition();
        return totalRead;
    }

    public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        int totalRead = 0;
        bool readInner = false;
        while (totalRead < buffer.Length && Position < Length)
        {
            switch (_currentRegion)
            {
                case SMRegion.StreamHeader:
                    totalRead += ReadFromStreamHeader(buffer.Slice(totalRead).Span);
                    break;
                case SMRegion.StreamFooter:
                    totalRead += ReadFromStreamFooter(buffer.Slice(totalRead).Span);
                    break;
                case SMRegion.SegmentHeader:
                    totalRead += ReadFromSegmentHeader(buffer.Slice(totalRead).Span);
                    break;
                case SMRegion.SegmentFooter:
                    totalRead += ReadFromSegmentFooter(buffer.Slice(totalRead).Span);
                    break;
                case SMRegion.SegmentContent:
                    // don't double read from stream. Allow caller to multi-read when desired.
                    if (readInner)
                    {
                        UpdateLatestPosition();
                        return totalRead;
                    }
                    totalRead += await ReadFromInnerStreamAsync(buffer.Slice(totalRead), cancellationToken).ConfigureAwait(false);
                    readInner = true;
                    break;
                default:
                    break;
            }
        }
        UpdateLatestPosition();
        return totalRead;
    }
#endif

    #region Read Headers/Footers
    private int ReadFromStreamHeader(Span<byte> buffer)
    {
        int read = Math.Min(buffer.Length, _streamHeaderLength - _currentRegionPosition);
        using IDisposable _ = StructuredMessage.V1_0.GetStreamHeaderBytes(
            ArrayPool<byte>.Shared, out Memory<byte> headerBytes, Length, _flags, TotalSegments);
        headerBytes.Slice(_currentRegionPosition, read).Span.CopyTo(buffer);
        _currentRegionPosition += read;

        if (_currentRegionPosition == _streamHeaderLength)
        {
            _currentRegion = SMRegion.SegmentHeader;
            _currentRegionPosition = 0;
        }

        return read;
    }

    private int ReadFromStreamFooter(Span<byte> buffer)
    {
        int read = Math.Min(buffer.Length, _segmentFooterLength - _currentRegionPosition);
        if (read <= 0)
        {
            return 0;
        }

        using IDisposable _ = StructuredMessage.V1_0.GetStreamFooterBytes(
            ArrayPool<byte>.Shared,
            out Memory<byte> footerBytes,
            crc64: UseCrcSegment
                ? _totalCrc.GetCurrentHash() // TODO array pooling
                : default);
        footerBytes.Slice(_currentRegionPosition, read).Span.CopyTo(buffer);
        _currentRegionPosition += read;

        return read;
    }

    private int ReadFromSegmentHeader(Span<byte> buffer)
    {
        int read = Math.Min(buffer.Length, _segmentHeaderLength - _currentRegionPosition);
        using IDisposable _ = StructuredMessage.V1_0.GetSegmentHeaderBytes(
            ArrayPool<byte>.Shared,
            out Memory<byte> headerBytes,
            CurrentInnerSegment,
            Math.Min(_segmentContentLength, _innerStream.Length - _innerStream.Position));
        headerBytes.Slice(_currentRegionPosition, read).Span.CopyTo(buffer);
        _currentRegionPosition += read;

        if (_currentRegionPosition == _segmentHeaderLength)
        {
            _currentRegion = SMRegion.SegmentContent;
            _currentRegionPosition = 0;
        }

        return read;
    }

    private int ReadFromSegmentFooter(Span<byte> buffer)
    {
        int read = Math.Min(buffer.Length, _segmentFooterLength - _currentRegionPosition);
        if (read < 0)
        {
            return 0;
        }

        using IDisposable _ = StructuredMessage.V1_0.GetSegmentFooterBytes(
            ArrayPool<byte>.Shared,
            out Memory<byte> headerBytes,
            crc64: UseCrcSegment
                ? new Span<byte>(
                    _segmentCrcs,
                    (CurrentEncodingSegment-1) * _totalCrc.HashLengthInBytes,
                    _totalCrc.HashLengthInBytes)
                : default);
        headerBytes.Slice(_currentRegionPosition, read).Span.CopyTo(buffer);
        _currentRegionPosition += read;

        if (_currentRegionPosition == _segmentFooterLength)
        {
            _currentRegion = _innerStream.Position == _innerStream.Length
                ? SMRegion.StreamFooter : SMRegion.SegmentHeader;
            _currentRegionPosition = 0;
        }

        return read;
    }
    #endregion

    #region ReadUnderlyingStream
    private int MaxInnerStreamRead => _segmentContentLength - _currentRegionPosition;

    private void CleanupContentSegment()
    {
        if (_currentRegionPosition == _segmentContentLength || _innerStream.Position >= _innerStream.Length)
        {
            _currentRegion = SMRegion.SegmentFooter;
            _currentRegionPosition = 0;
            if (UseCrcSegment && CurrentEncodingSegment - 1 == _latestSegmentCrcd)
            {
                _segmentCrc.GetCurrentHash(new Span<byte>(
                    _segmentCrcs,
                    _latestSegmentCrcd * _segmentCrc.HashLengthInBytes,
                    _segmentCrc.HashLengthInBytes));
                _latestSegmentCrcd++;
                _segmentCrc = StorageCrc64HashAlgorithm.Create();
            }
        }
    }

    private async ValueTask<int> ReadFromInnerStreamInternal(
        byte[] buffer, int offset, int count, bool async, CancellationToken cancellationToken)
    {
        int read = async
            ? await _innerStream.ReadAsync(buffer, offset, Math.Min(count, MaxInnerStreamRead)).ConfigureAwait(false)
            : _innerStream.Read(buffer, offset, Math.Min(count, MaxInnerStreamRead));
        _currentRegionPosition += read;
        CleanupContentSegment();
        return read;
    }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    private int ReadFromInnerStream(Span<byte> buffer)
    {
        if (MaxInnerStreamRead < buffer.Length)
        {
            buffer = buffer.Slice(0, MaxInnerStreamRead);
        }
        int read = _innerStream.Read(buffer);
        _currentRegionPosition += read;
        CleanupContentSegment();
        return read;
    }

    private async ValueTask<int> ReadFromInnerStreamAsync(Memory<byte> buffer, CancellationToken cancellationToken)
    {
        if (MaxInnerStreamRead < buffer.Length)
        {
            buffer = buffer.Slice(0, MaxInnerStreamRead);
        }
        int read = await _innerStream.ReadAsync(buffer, cancellationToken).ConfigureAwait(false);
        _currentRegionPosition += read;
        CleanupContentSegment();
        return read;
    }
#endif
    #endregion

    // don't allow stream to seek too far forward. track how far the stream has been naturally read.
    private void UpdateLatestPosition()
    {
        if (_maxSeekPosition < Position)
        {
            _maxSeekPosition = Position;
        }
    }
    #endregion

    public override long Seek(long offset, SeekOrigin origin)
    {
        switch (origin)
        {
            case SeekOrigin.Begin:
                Position = offset;
                break;
            case SeekOrigin.Current:
                Position += offset;
                break;
            case SeekOrigin.End:
                Position  = Length + offset;
                break;
        }
        return Position;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _innerStream.Dispose();
            _disposed = true;
        }
    }
}
