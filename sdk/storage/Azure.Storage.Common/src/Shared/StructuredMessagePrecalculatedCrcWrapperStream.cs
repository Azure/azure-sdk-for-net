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

internal class StructuredMessagePrecalculatedCrcWrapperStream : Stream
{
    private readonly Stream _innerStream;

    private readonly int _streamHeaderLength;
    private readonly int _streamFooterLength;
    private readonly int _segmentHeaderLength;
    private readonly int _segmentFooterLength;

    private bool _disposed;

    private readonly byte[] _crc;

    public override bool CanRead => true;

    public override bool CanWrite => false;

    public override bool CanSeek => _innerStream.CanSeek;

    public override bool CanTimeout => _innerStream.CanTimeout;

    public override int ReadTimeout => _innerStream.ReadTimeout;

    public override int WriteTimeout => _innerStream.WriteTimeout;

    public override long Length =>
        _streamHeaderLength + _streamFooterLength +
        _segmentHeaderLength + _segmentFooterLength +
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
                SMRegion.SegmentHeader => _innerStream.Position +
                    _streamHeaderLength +
                    _currentRegionPosition,
                SMRegion.SegmentContent => _streamHeaderLength +
                    _segmentHeaderLength +
                    _innerStream.Position,
                SMRegion.SegmentFooter => _streamHeaderLength +
                    _segmentHeaderLength +
                    _innerStream.Length +
                    _currentRegionPosition,
                SMRegion.StreamFooter => _streamHeaderLength +
                    _segmentHeaderLength +
                    _innerStream.Length +
                    _segmentFooterLength +
                    _currentRegionPosition,
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
            if (value < _streamHeaderLength + _segmentHeaderLength)
            {
                _currentRegion = SMRegion.SegmentHeader;
                _currentRegionPosition = (int)(value - _streamHeaderLength);
                _innerStream.Position = 0;
                return;
            }
            if (value < _streamHeaderLength + _segmentHeaderLength + _innerStream.Length)
            {
                _currentRegion = SMRegion.SegmentContent;
                _currentRegionPosition = (int)(value - _streamHeaderLength - _segmentHeaderLength);
                _innerStream.Position = value - _streamHeaderLength - _segmentHeaderLength;
                return;
            }
            if (value < _streamHeaderLength + _segmentHeaderLength + _innerStream.Length + _segmentFooterLength)
            {
                _currentRegion = SMRegion.SegmentFooter;
                _currentRegionPosition = (int)(value - _streamHeaderLength - _segmentHeaderLength - _innerStream.Length);
                _innerStream.Position = _innerStream.Length;
                return;
            }

            _currentRegion = SMRegion.StreamFooter;
            _currentRegionPosition = (int)(value - _streamHeaderLength - _segmentHeaderLength - _innerStream.Length - _segmentFooterLength);
            _innerStream.Position = _innerStream.Length;
        }
    }
    #endregion

    public StructuredMessagePrecalculatedCrcWrapperStream(
        Stream innerStream,
        ReadOnlySpan<byte> precalculatedCrc)
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

        _streamHeaderLength = StructuredMessage.V1_0.StreamHeaderLength;
        _streamFooterLength = StructuredMessage.Crc64Length;
        _segmentHeaderLength = StructuredMessage.V1_0.SegmentHeaderLength;
        _segmentFooterLength = StructuredMessage.Crc64Length;

        _crc = ArrayPool<byte>.Shared.Rent(StructuredMessage.Crc64Length);
        precalculatedCrc.CopyTo(_crc);

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
            ArrayPool<byte>.Shared,
            out Memory<byte> headerBytes,
            Length,
            StructuredMessage.Flags.StorageCrc64,
            totalSegments: 1);
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
            new ReadOnlySpan<byte>(_crc, 0, StructuredMessage.Crc64Length));
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
            segmentNum: 1,
            _innerStream.Length);
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
            new ReadOnlySpan<byte>(_crc, 0, StructuredMessage.Crc64Length));
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
    private void CleanupContentSegment()
    {
        if (_innerStream.Position >= _innerStream.Length)
        {
            _currentRegion = SMRegion.SegmentFooter;
            _currentRegionPosition = 0;
        }
    }

    private async ValueTask<int> ReadFromInnerStreamInternal(
        byte[] buffer, int offset, int count, bool async, CancellationToken cancellationToken)
    {
        int read = async
            ? await _innerStream.ReadAsync(buffer, offset, count).ConfigureAwait(false)
            : _innerStream.Read(buffer, offset, count);
        _currentRegionPosition += read;
        CleanupContentSegment();
        return read;
    }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    private int ReadFromInnerStream(Span<byte> buffer)
    {
        int read = _innerStream.Read(buffer);
        _currentRegionPosition += read;
        CleanupContentSegment();
        return read;
    }

    private async ValueTask<int> ReadFromInnerStreamAsync(Memory<byte> buffer, CancellationToken cancellationToken)
    {
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
            ArrayPool<byte>.Shared.Return(_crc);
            _innerStream.Dispose();
            _disposed = true;
        }
    }
}
