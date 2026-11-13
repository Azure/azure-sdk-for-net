// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

internal class AsyncValidatingStream : Stream
{
    private readonly bool _isAsync;

    private readonly Stream _innerStream;

    public AsyncValidatingStream(bool isAsync, Stream innerStream)
    {
        _isAsync = isAsync;
        _innerStream = innerStream;
    }

    public override void Flush()
    {
        Validate(false);
        _innerStream.Flush();
    }

    public override Task FlushAsync(CancellationToken cancellationToken)
    {
        Validate(true);
        return _innerStream.FlushAsync(cancellationToken);
    }

    private void Validate(bool isAsync)
    {
        if (isAsync != _isAsync)
        {
            throw new InvalidOperationException("All stream calls were expected to be " + (_isAsync ? "async" : "sync") + " but were " + (isAsync ? "async" : "sync"));
        }
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        Validate(false);
        return _innerStream.Read(buffer, offset, count);
    }

    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken = new CancellationToken())
    {
        Validate(true);
        return _innerStream.ReadAsync(buffer, offset, count, cancellationToken);
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return _innerStream.Seek(offset, origin);
    }

    public override void SetLength(long value)
    {
        _innerStream.SetLength(value);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        Validate(false);
        _innerStream.Write(buffer, offset, count);
    }

    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken = new CancellationToken())
    {
        Validate(true);
        return _innerStream.WriteAsync(buffer, offset, count, cancellationToken);
    }

    public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
    {
        Validate(true);
        return _innerStream.CopyToAsync(destination, bufferSize, cancellationToken);
    }

    public override void Close()
    {
        _innerStream.Close();
    }

    public override bool CanRead => _innerStream.CanRead;
    public override bool CanSeek => _innerStream.CanSeek;
    public override bool CanWrite => _innerStream.CanWrite;
    public override long Length => _innerStream.Length;
    public override long Position
    {
        get => _innerStream.Position;
        set => _innerStream.Position = value;
    }
}