// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.Shared;

/// <summary>
/// Decodes a structured message stream as the data is read.
/// </summary>
/// <remarks>
/// Wraps the inner stream in a <see cref="BufferedStream"/>, which avoids using its internal
/// buffer if individual Read() calls are larger than it. This ensures one of the three scenarios
/// <list type="number">
/// <item>
/// Read buffer &gt;= stream buffer:
/// There is enough space in the read buffer for inline metadata to be safely
/// extracted in only one read to the true inner stream.
/// </item>
/// <item>
/// Read buffer &lt; next inline metadata:
/// The stream buffer has been activated, and we can read multiple small times from the inner stream
/// without multi-reading the real stream, even when partway through an existing stream buffer.
/// </item>
/// <item>
/// Else:
/// Same as #1, but also the already-allocated stream buffer has been used to slightly improve
/// resource churn when reading inner stream.
/// </item>
/// </list>
/// </remarks>
internal class StructuredMessageDecodingStream : Stream
{
    private enum SMRegion
    {
        StreamHeader,
        StreamFooter,
        SegmentHeader,
        SegmentFooter,
        SegmentContent,
    }

    private readonly Stream _innerBufferedStream;

    private byte[] _metadataBuffer = ArrayPool<byte>.Shared.Rent(Constants.KB);
    private int _metadataBufferOffset = 0;
    private int _metadataBufferLength = 0;

    private int _streamHeaderLength;
    private int _streamFooterLength;
    private int _segmentHeaderLength;
    private int _segmentFooterLength;

    private int _totalSegments;
    private long _innerStreamLength;

    private StructuredMessage.Flags _flags;
    private bool _processedFooter = false;
    private bool _disposed;

    private StorageCrc64HashAlgorithm _totalContentCrc;
    private StorageCrc64HashAlgorithm _segmentCrc;

    public override bool CanRead => true;

    public override bool CanWrite => false;

    public override bool CanSeek => false;

    public override bool CanTimeout => _innerBufferedStream.CanTimeout;

    public override int ReadTimeout => _innerBufferedStream.ReadTimeout;

    public override int WriteTimeout => _innerBufferedStream.WriteTimeout;

    public override long Length => throw new NotSupportedException();

    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public StructuredMessageDecodingStream(
        Stream innerStream)
    {
        Argument.AssertNotNull(innerStream, nameof(innerStream));
        _innerBufferedStream = new BufferedStream(innerStream);

        // Assumes stream will be structured message 1.0. Will validate this when consuming stream.
        _streamHeaderLength = StructuredMessage.V1_0.StreamHeaderLength;
        _segmentHeaderLength = StructuredMessage.V1_0.SegmentHeaderLength;
    }

    #region Write
    public override void Flush() => throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

    public override void SetLength(long value) => throw new NotSupportedException();
    #endregion

    #region Read
    public override int Read(byte[] buf, int offset, int count)
    {
        int decodedRead;
        int read;
        do
        {
            read = _innerBufferedStream.Read(buf, offset, count);
            _innerStreamConsumed += read;
            decodedRead = Decode(new Span<byte>(buf, offset, read));
        } while (decodedRead <= 0 && read > 0);

        if (read <= 0)
        {
            AssertDecodeFinished();
        }

        return decodedRead;
    }

    public override async Task<int> ReadAsync(byte[] buf, int offset, int count, CancellationToken cancellationToken)
    {
        int decodedRead;
        int read;
        do
        {
            read = await _innerBufferedStream.ReadAsync(buf, offset, count, cancellationToken).ConfigureAwait(false);
            _innerStreamConsumed += read;
            decodedRead = Decode(new Span<byte>(buf, offset, read));
        } while (decodedRead <= 0 && read > 0);

        if (read <= 0)
        {
            AssertDecodeFinished();
        }

        return decodedRead;
    }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    public override int Read(Span<byte> buf)
    {
        int decodedRead;
        int read;
        do
        {
            read = _innerBufferedStream.Read(buf);
            _innerStreamConsumed += read;
            decodedRead = Decode(buf.Slice(0, read));
        } while (decodedRead <= 0 && read > 0);

        if (read <= 0)
        {
            AssertDecodeFinished();
        }

        return decodedRead;
    }

    public override async ValueTask<int> ReadAsync(Memory<byte> buf, CancellationToken cancellationToken = default)
    {
        int decodedRead;
        int read;
        do
        {
            read = await _innerBufferedStream.ReadAsync(buf).ConfigureAwait(false);
            _innerStreamConsumed += read;
            decodedRead = Decode(buf.Slice(0, read).Span);
        } while (decodedRead <= 0 && read > 0);

        if (read <= 0)
        {
            AssertDecodeFinished();
        }

        return decodedRead;
    }
#endif

    private void AssertDecodeFinished()
    {
        if (_streamFooterLength > 0 && !_processedFooter)
        {
            throw Errors.InvalidStructuredMessage("Missing or incomplete trailer.");
        }
        _processedFooter = true;
    }

    private long _innerStreamConsumed = 0;
    private SMRegion _currentRegion = SMRegion.StreamHeader;
    private int _currentSegmentNum = 0;
    private long _currentSegmentContentLength;
    private long _currentSegmentContentRemaining;
    private long CurrentRegionLength => _currentRegion switch
    {
        SMRegion.StreamHeader => _streamHeaderLength,
        SMRegion.StreamFooter => _streamFooterLength,
        SMRegion.SegmentHeader => _segmentHeaderLength,
        SMRegion.SegmentFooter => _segmentFooterLength,
        SMRegion.SegmentContent => _currentSegmentContentLength,
        _ => 0,
    };

    /// <summary>
    /// Decodes given bytes in place. Decoding based on internal stream position info.
    /// Decoded data size will be less than or equal to encoded data length.
    /// </summary>
    /// <returns>
    /// Length of the decoded data in <paramref name="buffer"/>.
    /// </returns>
    private int Decode(Span<byte> buffer)
    {
        if (buffer.IsEmpty)
        {
            return 0;
        }
        List<(int Offset, int Count)> gaps = new();

        int bufferConsumed = ProcessMetadataBuffer(buffer);

        if (bufferConsumed > 0)
        {
            gaps.Add((0, bufferConsumed));
        }

        while (bufferConsumed < buffer.Length)
        {
            if (_currentRegion == SMRegion.SegmentContent)
            {
                int read = (int)Math.Min(buffer.Length - bufferConsumed, _currentSegmentContentRemaining);
                _totalContentCrc?.Append(buffer.Slice(bufferConsumed, read));
                _segmentCrc?.Append(buffer.Slice(bufferConsumed, read));
                bufferConsumed += read;
                _currentSegmentContentRemaining -= read;
                if (_currentSegmentContentRemaining == 0)
                {
                    _currentRegion = SMRegion.SegmentFooter;
                }
            }
            else if (buffer.Length - bufferConsumed < CurrentRegionLength)
            {
                SavePartialMetadata(buffer.Slice(bufferConsumed));
                gaps.Add((bufferConsumed, buffer.Length - bufferConsumed));
                bufferConsumed = buffer.Length;
            }
            else
            {
                int processed = _currentRegion switch
                {
                    SMRegion.StreamHeader => ProcessStreamHeader(buffer.Slice(bufferConsumed)),
                    SMRegion.StreamFooter => ProcessStreamFooter(buffer.Slice(bufferConsumed)),
                    SMRegion.SegmentHeader => ProcessSegmentHeader(buffer.Slice(bufferConsumed)),
                    SMRegion.SegmentFooter => ProcessSegmentFooter(buffer.Slice(bufferConsumed)),
                    _ => 0,
                };
                // TODO surface error if processed is 0
                gaps.Add((bufferConsumed, processed));
                bufferConsumed += processed;
            }
        }

        if (gaps.Count == 0)
        {
            return buffer.Length;
        }

        // gaps is already sorted by offset due to how it was assembled
        int gap = 0;
        for (int i = gaps.First().Offset; i < buffer.Length; i++)
        {
            if (gaps.Count > 0 && gaps.First().Offset == i)
            {
                int count = gaps.First().Count;
                gap += count;
                i += count - 1;
                gaps.RemoveAt(0);
            }
            else
            {
                buffer[i - gap] = buffer[i];
            }
        }
        return buffer.Length - gap;
    }

    /// <summary>
    /// Processes metadata in the internal buffer, if any. Appends any necessary data
    /// from the append buffer to complete metadata.
    /// </summary>
    /// <returns>
    /// Bytes consumed from <paramref name="append"/>.
    /// </returns>
    private int ProcessMetadataBuffer(ReadOnlySpan<byte> append)
    {
        if (_metadataBufferLength == 0)
        {
            return 0;
        }
        if (_currentRegion == SMRegion.SegmentContent)
        {
            return 0;
        }
        int appended = 0;
        if (_metadataBufferLength < CurrentRegionLength && append.Length > 0)
        {
            appended = Math.Min((int)CurrentRegionLength - _metadataBufferLength, append.Length);
            SavePartialMetadata(append.Slice(0, appended));
        }
        if (_metadataBufferLength == CurrentRegionLength)
        {
            Span<byte> metadata = new(_metadataBuffer, _metadataBufferOffset, (int)CurrentRegionLength);
            switch (_currentRegion)
            {
                case SMRegion.StreamHeader:
                    ProcessStreamHeader(metadata);
                    break;
                case SMRegion.StreamFooter:
                    ProcessStreamFooter(metadata);
                    break;
                case SMRegion.SegmentHeader:
                    ProcessSegmentHeader(metadata);
                    break;
                case SMRegion.SegmentFooter:
                    ProcessSegmentFooter(metadata);
                    break;
            }
            _metadataBufferOffset = 0;
            _metadataBufferLength = 0;
        }
        return appended;
    }

    private void SavePartialMetadata(ReadOnlySpan<byte> span)
    {
        // safety array resize w/ArrayPool
        if (_metadataBufferLength + span.Length > _metadataBuffer.Length)
        {
            ResizeMetadataBuffer(2 * (_metadataBufferLength + span.Length));
        }

        // realign any existing content if necessary
        if (_metadataBufferLength != 0 && _metadataBufferOffset != 0)
        {
            // don't use Array.Copy() to move elements in the same array
            for (int i = 0; i < _metadataBufferLength; i++)
            {
                _metadataBuffer[i] = _metadataBuffer[i + _metadataBufferOffset];
            }
            _metadataBufferOffset = 0;
        }

        span.CopyTo(new Span<byte>(_metadataBuffer, _metadataBufferOffset + _metadataBufferLength, span.Length));
        _metadataBufferLength += span.Length;
    }

    private int ProcessStreamHeader(ReadOnlySpan<byte> span)
    {
        StructuredMessage.V1_0.ReadStreamHeader(
            span.Slice(0, _streamHeaderLength),
            out _innerStreamLength,
            out _flags,
            out _totalSegments);
        if (_flags.HasFlag(StructuredMessage.Flags.StorageCrc64))
        {
            _segmentFooterLength = _flags.HasFlag(StructuredMessage.Flags.StorageCrc64) ? StructuredMessage.Crc64Length : 0;
            _streamFooterLength = _flags.HasFlag(StructuredMessage.Flags.StorageCrc64) ? StructuredMessage.Crc64Length : 0;
            _segmentCrc = StorageCrc64HashAlgorithm.Create();
            _totalContentCrc = StorageCrc64HashAlgorithm.Create();
        }
        _currentRegion = SMRegion.SegmentHeader;
        return _streamHeaderLength;
    }

    private int ProcessStreamFooter(ReadOnlySpan<byte> span)
    {
        int totalProcessed = 0;
        if (_flags.HasFlag(StructuredMessage.Flags.StorageCrc64))
        {
            totalProcessed += StructuredMessage.Crc64Length;
            using (ArrayPool<byte>.Shared.RentAsSpanDisposable(StructuredMessage.Crc64Length, out Span<byte> calculated))
            {
                _totalContentCrc.GetCurrentHash(calculated);
                ReadOnlySpan<byte> expected = span.Slice(0, StructuredMessage.Crc64Length);
                if (!calculated.SequenceEqual(expected))
                {
                    throw Errors.ChecksumMismatch(calculated, expected);
                }
            }
        }

        if (_innerStreamConsumed != _innerStreamLength)
        {
            throw Errors.InvalidStructuredMessage("Unexpected message size.");
        }
        if (_currentSegmentNum != _totalSegments)
        {
            throw Errors.InvalidStructuredMessage("Missing expected message segments.");
        }

        _processedFooter = true;
        return totalProcessed;
    }

    private int ProcessSegmentHeader(ReadOnlySpan<byte> span)
    {
        StructuredMessage.V1_0.ReadSegmentHeader(
            span.Slice(0, _segmentHeaderLength),
            out int newSegNum,
            out _currentSegmentContentLength);
        _currentSegmentContentRemaining = _currentSegmentContentLength;
        if (newSegNum != _currentSegmentNum + 1)
        {
            throw Errors.InvalidStructuredMessage("Unexpected segment number in structured message.");
        }
        _currentSegmentNum = newSegNum;
        _currentRegion = SMRegion.SegmentContent;
        return _segmentHeaderLength;
    }

    private int ProcessSegmentFooter(ReadOnlySpan<byte> span)
    {
        int totalProcessed = 0;
        if (_flags.HasFlag(StructuredMessage.Flags.StorageCrc64))
        {
            totalProcessed += StructuredMessage.Crc64Length;
            using (ArrayPool<byte>.Shared.RentAsSpanDisposable(StructuredMessage.Crc64Length, out Span<byte> calculated))
            {
                _segmentCrc.GetCurrentHash(calculated);
                _segmentCrc = StorageCrc64HashAlgorithm.Create();
                ReadOnlySpan<byte> expected = span.Slice(0, StructuredMessage.Crc64Length);
                if (!calculated.SequenceEqual(expected))
                {
                    throw Errors.ChecksumMismatch(calculated, expected);
                }
            }
        }
        _currentRegion = _currentSegmentNum == _totalSegments ? SMRegion.StreamFooter : SMRegion.SegmentHeader;
        return totalProcessed;
    }
    #endregion

    public override long Seek(long offset, SeekOrigin origin)
        => throw new NotSupportedException();

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _innerBufferedStream.Dispose();
            _disposed = true;
        }
    }

    private void ResizeMetadataBuffer(int newSize)
    {
        byte[] newBuf = ArrayPool<byte>.Shared.Rent(newSize);
        Array.Copy(_metadataBuffer, _metadataBufferOffset, newBuf, 0, _metadataBufferLength);
        ArrayPool<byte>.Shared.Return(_metadataBuffer);
        _metadataBuffer = newBuf;
    }

    private void AlignMetadataBuffer()
    {
        if (_metadataBufferOffset != 0 && _metadataBufferLength != 0)
        {
            for (int i = 0; i < _metadataBufferLength; i++)
            {
                _metadataBuffer[i] = _metadataBuffer[_metadataBufferOffset + i];
            }
            _metadataBufferOffset = 0;
        }
    }
}
