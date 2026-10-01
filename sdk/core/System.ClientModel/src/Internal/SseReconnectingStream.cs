// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal sealed class SseReconnectResult : IDisposable
{
    private readonly IDisposable? _owner;

    internal SseReconnectResult(Stream stream, IDisposable? owner = null)
    {
        Stream = stream;
        _owner = owner;
    }

    internal Stream Stream { get; }

    public void Dispose()
    {
        if (_owner is not null)
        {
            _owner.Dispose();
        }
        else
        {
            Stream.Dispose();
        }
    }
}

internal sealed class SseReconnectingStream : Stream
{
    private const int ReadBufferSize = 8192;
    private const long MaximumRetryMilliseconds = int.MaxValue;
    private static readonly TimeSpan s_defaultReconnectionInterval =
        TimeSpan.FromSeconds(3);

    private readonly Func<string?, CancellationToken, ValueTask<SseReconnectResult?>> _reconnectAsync;
    private readonly Func<string?, CancellationToken, SseReconnectResult?> _reconnect;
    private readonly CancellationToken _operationCancellationToken;
    private readonly IDisposable? _reconnectOwner;
    private readonly bool _requireLastEventId;
    private readonly CancellationTokenSource _disposeCancellation = new();
    private readonly object _currentSync = new();
    private readonly byte[] _readBuffer = new byte[ReadBufferSize];
    private readonly MemoryStream _pendingEvent = new();
    private readonly MemoryStream _readyEvents = new();
    private readonly MemoryStream _lineBuffer = new();
    private SseReconnectResult _current;
    private TimeSpan _reconnectionInterval = s_defaultReconnectionInterval;
    private string? _lastEventId;
    private string? _eventIdBuffer;
    private int _readyOffset;
    private bool _pendingCarriageReturn;
    private bool _pendingCarriageReturnWasBlank;
    private bool _reconnectImmediately;
    private bool _endOfStream;
    private bool _currentFaulted;
    private ExceptionDispatchInfo? _currentFault;
    private volatile bool _disposed;
    private bool _isFirstLine = true;

    internal SseReconnectingStream(
        Stream initialStream,
        Func<string?, CancellationToken, SseReconnectResult?> reconnect,
        Func<string?, CancellationToken, ValueTask<SseReconnectResult?>> reconnectAsync,
        CancellationToken operationCancellationToken,
        bool reconnectImmediately = false,
        IDisposable? reconnectOwner = null,
        string? initialLastEventId = null,
        bool requireLastEventId = false)
    {
        _current = new SseReconnectResult(initialStream);
        _reconnect = reconnect;
        _reconnectAsync = reconnectAsync;
        _operationCancellationToken = operationCancellationToken;
        _reconnectImmediately = reconnectImmediately;
        _reconnectOwner = reconnectOwner;
        _lastEventId = initialLastEventId;
        _eventIdBuffer = initialLastEventId;
        _requireLastEventId = requireLastEventId;
    }

    public override bool CanRead => !_disposed;
    public override bool CanSeek => false;
    public override bool CanWrite => false;
    public override long Length => throw new NotSupportedException();
    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        ValidateReadArguments(buffer, offset, count);
        ThrowIfDisposed();
        if (count == 0)
        {
            return 0;
        }

        while (true)
        {
            ThrowIfDisposed();
            int ready = CopyReadyEvents(
                buffer.AsSpan(offset, count));
            if (ready > 0)
            {
                return ready;
            }
            if (_endOfStream)
            {
                return 0;
            }

            using CancellationTokenSource linkedCancellation =
                CreateLinkedCancellationSource(CancellationToken.None);
            int read = 0;
            if (!_currentFaulted)
            {
                try
                {
                    linkedCancellation.Token.ThrowIfCancellationRequested();
                    read = GetCurrentStream().Read(
                        _readBuffer,
                        0,
                        _readBuffer.Length);
                }
                catch (IOException ex) when (
                    !linkedCancellation.IsCancellationRequested)
                {
                    read = 0;
                    MarkCurrentFaulted(ex);
                }
            }

            if (read > 0)
            {
                ProcessBytes(_readBuffer.AsSpan(0, read));
                continue;
            }

            FinalizePendingCarriageReturn();
            if (!_currentFaulted)
            {
                _endOfStream = true;
            }

            ready = CopyReadyEvents(
                buffer.AsSpan(offset, count));
            if (ready > 0)
            {
                return ready;
            }

            DiscardIncompleteEvent();
            if (_endOfStream)
            {
                return 0;
            }

            if (!Reconnect(linkedCancellation.Token))
            {
                return 0;
            }
        }
    }

    public override async Task<int> ReadAsync(
        byte[] buffer,
        int offset,
        int count,
        CancellationToken cancellationToken)
    {
        ValidateReadArguments(buffer, offset, count);
        ThrowIfDisposed();
        if (count == 0)
        {
            return 0;
        }

        while (true)
        {
            ThrowIfDisposed();
            int ready = CopyReadyEvents(
                buffer.AsSpan(offset, count));
            if (ready > 0)
            {
                return ready;
            }
            if (_endOfStream)
            {
                return 0;
            }

            using CancellationTokenSource linkedCancellation =
                CreateLinkedCancellationSource(cancellationToken);
            int read = 0;
            if (!_currentFaulted)
            {
                try
                {
                    read = await GetCurrentStream().ReadAsync(
                        _readBuffer,
                        0,
                        _readBuffer.Length,
                        linkedCancellation.Token).ConfigureAwait(false);
                }
                catch (IOException ex) when (
                    !linkedCancellation.IsCancellationRequested)
                {
                    read = 0;
                    MarkCurrentFaulted(ex);
                }
            }

            if (read > 0)
            {
                ProcessBytes(_readBuffer.AsSpan(0, read));
                continue;
            }

            FinalizePendingCarriageReturn();
            if (!_currentFaulted)
            {
                _endOfStream = true;
            }

            ready = CopyReadyEvents(
                buffer.AsSpan(offset, count));
            if (ready > 0)
            {
                return ready;
            }

            DiscardIncompleteEvent();
            if (_endOfStream)
            {
                return 0;
            }

            if (!await ReconnectAsync(
                linkedCancellation.Token).ConfigureAwait(false))
            {
                return 0;
            }
        }
    }

#if NET8_0_OR_GREATER
    public override async ValueTask<int> ReadAsync(
        Memory<byte> buffer,
        CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();
        if (buffer.IsEmpty)
        {
            return 0;
        }

        while (true)
        {
            ThrowIfDisposed();
            int ready = CopyReadyEvents(buffer.Span);
            if (ready > 0)
            {
                return ready;
            }
            if (_endOfStream)
            {
                return 0;
            }

            using CancellationTokenSource linkedCancellation =
                CreateLinkedCancellationSource(cancellationToken);
            int read = 0;
            if (!_currentFaulted)
            {
                try
                {
                    read = await GetCurrentStream().ReadAsync(
                        _readBuffer,
                        linkedCancellation.Token).ConfigureAwait(false);
                }
                catch (IOException ex) when (
                    !linkedCancellation.IsCancellationRequested)
                {
                    read = 0;
                    MarkCurrentFaulted(ex);
                }
            }

            if (read > 0)
            {
                ProcessBytes(_readBuffer.AsSpan(0, read));
                continue;
            }

            FinalizePendingCarriageReturn();
            if (!_currentFaulted)
            {
                _endOfStream = true;
            }

            ready = CopyReadyEvents(buffer.Span);
            if (ready > 0)
            {
                return ready;
            }

            DiscardIncompleteEvent();
            if (_endOfStream)
            {
                return 0;
            }

            if (!await ReconnectAsync(
                linkedCancellation.Token).ConfigureAwait(false))
            {
                return 0;
            }
        }
    }
#endif

    private void MarkCurrentFaulted(IOException exception)
    {
        _currentFaulted = true;
        _currentFault = ExceptionDispatchInfo.Capture(exception);
    }

    // Reconnection follows the WHATWG processing model: a lost connection is
    // retried, and Last-Event-ID is sent only when a last event id is
    // non-empty. A missing or explicitly cleared id does not stop the
    // reconnect - it only means the header is omitted and the service may
    // replay events the caller has already seen, which streaming consumers
    // are expected to handle. Refusing would guarantee the rest of the stream
    // could never be received, which is the worse outcome.
    //
    // The one exception is RFC 9110 section 9.2.2: a non-idempotent request
    // must not be replayed automatically, because it may already have been
    // applied. A server-issued last event id lifts that restriction, since
    // publishing a resumption token is the service asking to be continued
    // from a point rather than to have the request applied again.
    private bool CanResumeFaithfully
        => !string.IsNullOrEmpty(_lastEventId) || !_requireLastEventId;

    private bool TryFailUnresumableStream()
    {
        if (CanResumeFaithfully)
        {
            return false;
        }

        _endOfStream = true;
        _currentFault?.Throw();
        return true;
    }

    private bool Reconnect(CancellationToken cancellationToken)
    {
        if (_endOfStream)
        {
            return false;
        }

        if (TryFailUnresumableStream())
        {
            return false;
        }

        ReleaseCurrent();
        ResetConnectionParsingState();

        try
        {
            while (true)
            {
                if (!_reconnectImmediately)
                {
                    WaitForReconnectionInterval(cancellationToken);
                }
                _reconnectImmediately = false;

                try
                {
                    SseReconnectResult? next = _reconnect(
                        string.IsNullOrEmpty(_lastEventId)
                            ? null
                            : _lastEventId,
                        cancellationToken);
                    if (next is null)
                    {
                        _endOfStream = true;
                        return false;
                    }
                    if (!TrySetCurrent(next))
                    {
                        next.Dispose();
                        cancellationToken.ThrowIfCancellationRequested();
                        throw new ObjectDisposedException(
                            GetType().FullName);
                    }

                    return true;
                }
                catch (IOException) when (
                    !cancellationToken.IsCancellationRequested)
                {
                }
            }
        }
        catch
        {
            _endOfStream = true;
            throw;
        }
    }

    private void WaitForReconnectionInterval(
        CancellationToken cancellationToken)
    {
        if (_reconnectionInterval <= TimeSpan.Zero)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return;
        }

        if (cancellationToken.WaitHandle.WaitOne(_reconnectionInterval))
        {
            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    private async ValueTask<bool> ReconnectAsync(
        CancellationToken cancellationToken)
    {
        if (_endOfStream)
        {
            return false;
        }

        if (TryFailUnresumableStream())
        {
            return false;
        }

        ReleaseCurrent();
        ResetConnectionParsingState();

        try
        {
            while (true)
            {
                if (!_reconnectImmediately)
                {
                    await Task.Delay(
                        _reconnectionInterval,
                        cancellationToken).ConfigureAwait(false);
                }
                _reconnectImmediately = false;

                try
                {
                    SseReconnectResult? next = await _reconnectAsync(
                        string.IsNullOrEmpty(_lastEventId)
                            ? null
                            : _lastEventId,
                        cancellationToken).ConfigureAwait(false);
                    if (next is null)
                    {
                        _endOfStream = true;
                        return false;
                    }
                    if (!TrySetCurrent(next))
                    {
                        next.Dispose();
                        cancellationToken.ThrowIfCancellationRequested();
                        throw new ObjectDisposedException(
                            GetType().FullName);
                    }

                    return true;
                }
                catch (IOException) when (
                    !cancellationToken.IsCancellationRequested)
                {
                }
            }
        }
        catch
        {
            _endOfStream = true;
            throw;
        }
    }

    private void ProcessBytes(ReadOnlySpan<byte> bytes)
    {
        foreach (byte value in bytes)
        {
            if (_pendingCarriageReturn)
            {
                if (value == (byte)'\n')
                {
                    _pendingEvent.WriteByte(value);
                    if (_pendingCarriageReturnWasBlank)
                    {
                        CommitEvent();
                    }
                    _pendingCarriageReturn = false;
                    _pendingCarriageReturnWasBlank = false;
                    continue;
                }

                FinalizePendingCarriageReturn();
            }

            _pendingEvent.WriteByte(value);
            if (value == (byte)'\r')
            {
                _pendingCarriageReturnWasBlank = ProcessLine();
                _lineBuffer.SetLength(0);
                _pendingCarriageReturn = true;
            }
            else if (value == (byte)'\n')
            {
                if (ProcessLine())
                {
                    CommitEvent();
                }
                _lineBuffer.SetLength(0);
            }
            else
            {
                _lineBuffer.WriteByte(value);
            }
        }
    }

    private bool ProcessLine()
    {
        int length = checked((int)_lineBuffer.Length);
        if (length == 0)
        {
            _lastEventId = _eventIdBuffer;
            return true;
        }

        byte[] bytes = _lineBuffer.GetBuffer();
        string text = Encoding.UTF8.GetString(bytes, 0, length);
        if (_isFirstLine)
        {
            text = text.TrimStart('\uFEFF');
            _isFirstLine = false;
        }

        int colon = text.IndexOf(':');
        string field = colon < 0 ? text : text.Substring(0, colon);
        string value = colon < 0
            ? string.Empty
            : text.Substring(colon + 1);
        if (value.StartsWith(" ", StringComparison.Ordinal))
        {
            value = value.Substring(1);
        }

        if (field == "id" && value.IndexOf('\0') < 0)
        {
            _eventIdBuffer = value;
        }
        else if (field == "retry" &&
            long.TryParse(
                value,
                NumberStyles.None,
                CultureInfo.InvariantCulture,
                out long milliseconds) &&
            milliseconds >= 0)
        {
            _reconnectionInterval = TimeSpan.FromMilliseconds(
                Math.Min(milliseconds, MaximumRetryMilliseconds));
        }

        return false;
    }

    private void CommitEvent()
    {
        if (_pendingEvent.Length > 0 &&
            _pendingEvent.TryGetBuffer(
                out ArraySegment<byte> eventBytes))
        {
            _readyEvents.Position = _readyEvents.Length;
            _readyEvents.Write(
                eventBytes.Array!,
                eventBytes.Offset,
                checked((int)_pendingEvent.Length));
        }

        _pendingEvent.SetLength(0);
        _pendingEvent.Position = 0;
    }

    private int CopyReadyEvents(Span<byte> destination)
    {
        int available = checked(
            (int)_readyEvents.Length - _readyOffset);
        if (available <= 0)
        {
            return 0;
        }

        int count = Math.Min(available, destination.Length);
        _readyEvents.GetBuffer()
            .AsSpan(_readyOffset, count)
            .CopyTo(destination);
        _readyOffset += count;
        if (_readyOffset == _readyEvents.Length)
        {
            _readyEvents.SetLength(0);
            _readyEvents.Position = 0;
            _readyOffset = 0;
        }
        return count;
    }

    private void FinalizePendingCarriageReturn()
    {
        if (!_pendingCarriageReturn)
        {
            return;
        }

        if (_pendingCarriageReturnWasBlank)
        {
            CommitEvent();
        }
        _pendingCarriageReturn = false;
        _pendingCarriageReturnWasBlank = false;
    }

    private void DiscardIncompleteEvent()
    {
        _pendingEvent.SetLength(0);
        _pendingEvent.Position = 0;
        _lineBuffer.SetLength(0);
        _lineBuffer.Position = 0;
        _eventIdBuffer = _lastEventId;
        _pendingCarriageReturn = false;
        _pendingCarriageReturnWasBlank = false;
    }

    private void ResetConnectionParsingState()
    {
        DiscardIncompleteEvent();
        _isFirstLine = true;
    }

    private CancellationTokenSource CreateLinkedCancellationSource(
        CancellationToken cancellationToken)
    {
        if (_operationCancellationToken.CanBeCanceled &&
            cancellationToken.CanBeCanceled &&
            _operationCancellationToken != cancellationToken)
        {
            return CancellationTokenSource.CreateLinkedTokenSource(
                _operationCancellationToken,
                cancellationToken,
                _disposeCancellation.Token);
        }

        CancellationToken callerCancellation =
            cancellationToken.CanBeCanceled
                ? cancellationToken
                : _operationCancellationToken;
        return CancellationTokenSource.CreateLinkedTokenSource(
            callerCancellation,
            _disposeCancellation.Token);
    }

    private void ReleaseCurrent()
    {
        SseReconnectResult current;
        lock (_currentSync)
        {
            current = _current;
            _current = new SseReconnectResult(Stream.Null);
        }
        current.Dispose();
    }

    private Stream GetCurrentStream()
    {
        lock (_currentSync)
        {
            return _current.Stream;
        }
    }

    private bool TrySetCurrent(SseReconnectResult next)
    {
        lock (_currentSync)
        {
            if (_disposed)
            {
                return false;
            }

            _current = next;
            _currentFaulted = false;
            _currentFault = null;
            return true;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            lock (_currentSync)
            {
                if (_disposed)
                {
                    return;
                }
                _disposed = true;
            }
            _disposeCancellation.Cancel();
            ReleaseCurrent();
            _reconnectOwner?.Dispose();
            _pendingEvent.Dispose();
            _readyEvents.Dispose();
            _lineBuffer.Dispose();
            _disposeCancellation.Dispose();
        }
        base.Dispose(disposing);
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(GetType().FullName);
        }
    }

    private static void ValidateReadArguments(
        byte[] buffer,
        int offset,
        int count)
    {
        if (buffer is null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }
        if ((uint)offset > (uint)buffer.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(offset));
        }
        if ((uint)count > (uint)(buffer.Length - offset))
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }
    }

    public override void Flush() => throw new NotSupportedException();
    public override long Seek(long offset, SeekOrigin origin)
        => throw new NotSupportedException();
    public override void SetLength(long value)
        => throw new NotSupportedException();
    public override void Write(byte[] buffer, int offset, int count)
        => throw new NotSupportedException();
}
