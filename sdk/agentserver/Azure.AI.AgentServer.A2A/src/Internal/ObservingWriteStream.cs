// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.A2A.Internal;

internal sealed class ObservingWriteStream(Stream inner, A2AResponseObserver observer) : Stream
{
    public override bool CanRead => false;
    public override bool CanSeek => false;
    public override bool CanWrite => true;
    public override long Length => throw new NotSupportedException();
    public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
    public override void Flush()
    {
        try
        {
            inner.Flush();
        }
        catch (Exception exception)
        {
            observer.RecordTransmissionFailure(exception);
            throw;
        }
    }

    public override async Task FlushAsync(CancellationToken cancellationToken)
    {
        try
        {
            await inner.FlushAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            observer.RecordTransmissionFailure(exception, cancellationToken);
            throw;
        }
    }
    public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
    public override void SetLength(long value) => throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count)
    {
        observer.Observe(buffer.AsSpan(offset, count));
        try
        {
            inner.Write(buffer, offset, count);
        }
        catch (Exception exception)
        {
            observer.RecordTransmissionFailure(exception);
            throw;
        }
    }

    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
        WriteAsync(buffer.AsMemory(offset, count), cancellationToken).AsTask();

    public override async ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
    {
        observer.Observe(buffer.Span);
        try
        {
            await inner.WriteAsync(buffer, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            observer.RecordTransmissionFailure(exception, cancellationToken);
            throw;
        }
    }
}
