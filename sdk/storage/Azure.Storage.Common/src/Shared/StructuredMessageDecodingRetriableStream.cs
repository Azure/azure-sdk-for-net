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
using Azure.Core.Pipeline;

namespace Azure.Storage.Shared;

internal class StructuredMessageDecodingRetriableStream : Stream
{
    private readonly Stream _innerRetriable;
    private long _decodedBytesRead;

    private readonly List<StructuredMessageDecodingStream.DecodedData> _decodedDatas;
    private readonly Action<StructuredMessageDecodingStream.DecodedData> _onComplete;

    private readonly Func<long, (Stream DecodingStream, StructuredMessageDecodingStream.DecodedData DecodedData)> _decodingStreamFactory;
    private readonly Func<long, ValueTask<(Stream DecodingStream, StructuredMessageDecodingStream.DecodedData DecodedData)>> _decodingAsyncStreamFactory;

    public StructuredMessageDecodingRetriableStream(
        Stream initialDecodingStream,
        StructuredMessageDecodingStream.DecodedData initialDecodedData,
        Func<long, (Stream DecodingStream, StructuredMessageDecodingStream.DecodedData DecodedData)> decodingStreamFactory,
        Func<long, ValueTask<(Stream DecodingStream, StructuredMessageDecodingStream.DecodedData DecodedData)>> decodingAsyncStreamFactory,
        Action<StructuredMessageDecodingStream.DecodedData> onComplete,
        ResponseClassifier responseClassifier,
        int maxRetries)
    {
        _decodingStreamFactory = decodingStreamFactory;
        _decodingAsyncStreamFactory = decodingAsyncStreamFactory;
        _innerRetriable = RetriableStream.Create(initialDecodingStream, StreamFactory, StreamFactoryAsync, responseClassifier, maxRetries);
        _decodedDatas = new() { initialDecodedData };
        _onComplete = onComplete;
    }

    private Stream StreamFactory(long _)
    {
        long offset = _decodedDatas.Select(d => d.SegmentCrcs?.LastOrDefault().SegmentEnd ?? 0).Sum();
        (Stream decodingStream, StructuredMessageDecodingStream.DecodedData decodedData) = _decodingStreamFactory(offset);
        _decodedDatas.Add(decodedData);
        FastForwardInternal(decodingStream, _decodedBytesRead - offset, false).EnsureCompleted();
        return decodingStream;
    }

    private async ValueTask<Stream> StreamFactoryAsync(long _)
    {
        long offset = _decodedDatas.Select(d => d.SegmentCrcs?.LastOrDefault().SegmentEnd ?? 0).Sum();
        (Stream decodingStream, StructuredMessageDecodingStream.DecodedData decodedData) = await _decodingAsyncStreamFactory(offset).ConfigureAwait(false);
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
        foreach (IDisposable data in _decodedDatas)
        {
            data.Dispose();
        }
        _decodedDatas.Clear();
        _innerRetriable.Dispose();
    }

    private void OnCompleted()
    {
        StructuredMessageDecodingStream.DecodedData final = new();
        // TODO
        _onComplete?.Invoke(final);
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
