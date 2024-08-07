// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Shared;

internal class StructuredMessageDecodingRetriableStream : Stream
{
    public class DecodedData
    {
        public ulong Crc { get; set; }
    }

    private readonly Stream _innerRetriable;
    private long _decodedBytesRead;

    private readonly StructuredMessage.Flags _expectedFlags;
    private readonly List<StructuredMessageDecodingStream.RawDecodedData> _decodedDatas;
    private readonly Action<DecodedData> _onComplete;

    private StorageCrc64HashAlgorithm _totalContentCrc;

    private readonly Func<long, (Stream DecodingStream, StructuredMessageDecodingStream.RawDecodedData DecodedData)> _decodingStreamFactory;
    private readonly Func<long, ValueTask<(Stream DecodingStream, StructuredMessageDecodingStream.RawDecodedData DecodedData)>> _decodingAsyncStreamFactory;

    public StructuredMessageDecodingRetriableStream(
        Stream initialDecodingStream,
        StructuredMessageDecodingStream.RawDecodedData initialDecodedData,
        StructuredMessage.Flags expectedFlags,
        Func<long, (Stream DecodingStream, StructuredMessageDecodingStream.RawDecodedData DecodedData)> decodingStreamFactory,
        Func<long, ValueTask<(Stream DecodingStream, StructuredMessageDecodingStream.RawDecodedData DecodedData)>> decodingAsyncStreamFactory,
        Action<DecodedData> onComplete,
        ResponseClassifier responseClassifier,
        int maxRetries)
    {
        _decodingStreamFactory = decodingStreamFactory;
        _decodingAsyncStreamFactory = decodingAsyncStreamFactory;
        _innerRetriable = RetriableStream.Create(initialDecodingStream, StreamFactory, StreamFactoryAsync, responseClassifier, maxRetries);
        _decodedDatas = new() { initialDecodedData };
        _expectedFlags = expectedFlags;
        _onComplete = onComplete;

        if (expectedFlags.HasFlag(StructuredMessage.Flags.StorageCrc64))
        {
            _totalContentCrc = StorageCrc64HashAlgorithm.Create();
        }
    }

    private Stream StreamFactory(long _)
    {
        long offset = _decodedDatas.SelectMany(d => d.SegmentCrcs).Select(s => s.SegmentLen).Sum();
        (Stream decodingStream, StructuredMessageDecodingStream.RawDecodedData decodedData) = _decodingStreamFactory(offset);
        _decodedDatas.Add(decodedData);
        FastForwardInternal(decodingStream, _decodedBytesRead - offset, false).EnsureCompleted();
        return decodingStream;
    }

    private async ValueTask<Stream> StreamFactoryAsync(long _)
    {
        long offset = _decodedDatas.SelectMany(d => d.SegmentCrcs).Select(s => s.SegmentLen).Sum();
        (Stream decodingStream, StructuredMessageDecodingStream.RawDecodedData decodedData) = await _decodingAsyncStreamFactory(offset).ConfigureAwait(false);
        _decodedDatas.Add(decodedData);
        await FastForwardInternal(decodingStream, _decodedBytesRead - offset, true).ConfigureAwait(false);
        return decodingStream;
    }

    private static async ValueTask FastForwardInternal(Stream stream, long bytes, bool async)
    {
        using (ArrayPool<byte>.Shared.RentDisposable(4 * Constants.KB, out byte[] buffer))
        {
            if (async)
            {
                while (bytes > 0)
                {
                    bytes -= await stream.ReadAsync(buffer, 0, (int)Math.Min(bytes, buffer.Length)).ConfigureAwait(false);
                }
            }
            else
            {
                while (bytes > 0)
                {
                    bytes -= stream.Read(buffer, 0, (int)Math.Min(bytes, buffer.Length));
                }
            }
        }
    }

    protected override void Dispose(bool disposing)
    {
        _decodedDatas.Clear();
        _innerRetriable.Dispose();
    }

    private void OnCompleted()
    {
        DecodedData final = new();
        if (_totalContentCrc != null)
        {
            final.Crc = ValidateCrc();
        }
        _onComplete?.Invoke(final);
    }

    private ulong ValidateCrc()
    {
        using IDisposable _ = ArrayPool<byte>.Shared.RentDisposable(StructuredMessage.Crc64Length * 2, out byte[] buf);
        Span<byte> calculatedBytes = new(buf, 0, StructuredMessage.Crc64Length);
        _totalContentCrc.GetCurrentHash(calculatedBytes);
        ulong calculated = BinaryPrimitives.ReadUInt64LittleEndian(calculatedBytes);

        ulong reported = _decodedDatas.Count == 1
            ? _decodedDatas.First().TotalCrc.Value
            : StorageCrc64Composer.Compose(_decodedDatas.SelectMany(d => d.SegmentCrcs));

        if (calculated != reported)
        {
            Span<byte> reportedBytes = new(buf, calculatedBytes.Length, StructuredMessage.Crc64Length);
            BinaryPrimitives.WriteUInt64LittleEndian(reportedBytes, reported);
            throw Errors.ChecksumMismatch(calculatedBytes, reportedBytes);
        }

        return calculated;
    }

    #region Read
    public override int Read(byte[] buffer, int offset, int count)
    {
        int read = _innerRetriable.Read(buffer, offset, count);
        _decodedBytesRead += read;
        if (read == 0)
        {
            OnCompleted();
        }
        else
        {
            _totalContentCrc?.Append(new ReadOnlySpan<byte>(buffer, offset, read));
        }
        return read;
    }

    public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        int read = await _innerRetriable.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
        _decodedBytesRead += read;
        if (read == 0)
        {
            OnCompleted();
        }
        else
        {
            _totalContentCrc?.Append(new ReadOnlySpan<byte>(buffer, offset, read));
        }
        return read;
    }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    public override int Read(Span<byte> buffer)
    {
        int read = _innerRetriable.Read(buffer);
        _decodedBytesRead += read;
        if (read == 0)
        {
            OnCompleted();
        }
        else
        {
            _totalContentCrc?.Append(buffer.Slice(0, read));
        }
        return read;
    }

    public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        int read = await _innerRetriable.ReadAsync(buffer, cancellationToken).ConfigureAwait(false);
        _decodedBytesRead += read;
        if (read == 0)
        {
            OnCompleted();
        }
        else
        {
            _totalContentCrc?.Append(buffer.Span.Slice(0, read));
        }
        return read;
    }
#endif

    public override int ReadByte()
    {
        int val = _innerRetriable.ReadByte();
        _decodedBytesRead += 1;
        if (val == -1)
        {
            OnCompleted();
        }
        return val;
    }

    public override int EndRead(IAsyncResult asyncResult)
    {
        int read = _innerRetriable.EndRead(asyncResult);
        _decodedBytesRead += read;
        if (read == 0)
        {
            OnCompleted();
        }
        return read;
    }
    #endregion

    #region Passthru
    public override bool CanRead => _innerRetriable.CanRead;

    public override bool CanSeek => _innerRetriable.CanSeek;

    public override bool CanWrite => _innerRetriable.CanWrite;

    public override bool CanTimeout => _innerRetriable.CanTimeout;

    public override long Length => _innerRetriable.Length;

    public override long Position { get => _innerRetriable.Position; set => _innerRetriable.Position = value; }

    public override void Flush() => _innerRetriable.Flush();

    public override Task FlushAsync(CancellationToken cancellationToken) => _innerRetriable.FlushAsync(cancellationToken);

    public override long Seek(long offset, SeekOrigin origin) => _innerRetriable.Seek(offset, origin);

    public override void SetLength(long value) => _innerRetriable.SetLength(value);

    public override void Write(byte[] buffer, int offset, int count) => _innerRetriable.Write(buffer, offset, count);

    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => _innerRetriable.WriteAsync(buffer, offset, count, cancellationToken);

    public override void WriteByte(byte value) => _innerRetriable.WriteByte(value);

    public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) => _innerRetriable.BeginWrite(buffer, offset, count, callback, state);

    public override void EndWrite(IAsyncResult asyncResult) => _innerRetriable.EndWrite(asyncResult);

    public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) => _innerRetriable.BeginRead(buffer, offset, count, callback, state);

    public override int ReadTimeout { get => _innerRetriable.ReadTimeout; set => _innerRetriable.ReadTimeout = value; }

    public override int WriteTimeout { get => _innerRetriable.WriteTimeout; set => _innerRetriable.WriteTimeout = value; }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    public override void Write(ReadOnlySpan<byte> buffer) => _innerRetriable.Write(buffer);

    public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default) => _innerRetriable.WriteAsync(buffer, cancellationToken);
#endif
    #endregion
}
