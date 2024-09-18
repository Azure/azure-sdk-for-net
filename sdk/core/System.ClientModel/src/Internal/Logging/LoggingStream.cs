// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal.Logging;

internal class LoggingStream : Stream
{
    private readonly string _requestId;
    private int _maxLoggedBytes;
    private readonly int _originalMaxLength;
    private readonly Stream _originalStream;
    private readonly bool _error;
    private readonly Encoding? _textEncoding;
    private int _blockNumber;
    private readonly LoggingHandler _handler;

    public LoggingStream(LoggingHandler handler, string requestId, int maxLoggedBytes, Stream originalStream, bool error, Encoding? textEncoding)
    {
        // Should only wrap non-seekable streams
        Debug.Assert(!originalStream.CanSeek);
        _requestId = requestId;
        _maxLoggedBytes = maxLoggedBytes;
        _originalMaxLength = maxLoggedBytes;
        _originalStream = originalStream;
        _error = error;
        _textEncoding = textEncoding;
        _handler = handler;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return _originalStream.Seek(offset, origin);
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        var result = _originalStream.Read(buffer, offset, count);

        var countToLog = result;
        DecrementLength(ref countToLog);
        LogBuffer(buffer, offset, countToLog, false);

        return result;
    }

    private void LogBuffer(byte[] buffer, int offset, int length, bool async)
    {
        if (length == 0 || buffer == null)
        {
            return;
        }

        var logLength = Math.Min(length, _originalMaxLength);

        byte[] bytes;
        if (length == logLength && offset == 0)
        {
            bytes = buffer;
        }
        else
        {
            bytes = new byte[logLength];
            Buffer.BlockCopy(buffer, offset, bytes, 0, logLength);
        }

        if (_error)
        {
            _handler.LogErrorResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
        }
        else
        {
            _handler.LogResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
        }

        _blockNumber++;
    }

    public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
#pragma warning disable CA1835 // ReadAsync(Memory<>) overload is not available in netstandard2.0
        var result = await _originalStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
#pragma warning restore // ReadAsync(Memory<>) overload is not available in netstandard2.0

        var countToLog = result;
        DecrementLength(ref countToLog);
        LogBuffer(buffer, offset, countToLog, true);

        return result;
    }

    public override bool CanRead => _originalStream.CanRead;
    public override bool CanSeek => _originalStream.CanSeek;
    public override long Length => _originalStream.Length;
    public override long Position
    {
        get => _originalStream.Position;
        set => _originalStream.Position = value;
    }

    // Make this stream readonly
    public override bool CanWrite => false;

    // Make this stream readonly
    public override void Write(byte[] buffer, int offset, int count)
    {
        throw new NotSupportedException("This stream is read-only.");
    }

    // Make this stream readonly
    public override void SetLength(long value)
    {
        throw new NotSupportedException("This stream is read-only.");
    }

    public override void Flush()
    {
    }

    public override void Close()
    {
        _originalStream.Close();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        _originalStream.Dispose();
    }

    private void DecrementLength(ref int count)
    {
        var left = Math.Min(count, _maxLoggedBytes);
        count = left;
        _maxLoggedBytes -= count;
    }
}
