// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Coordinates Server-Sent Events (SSE) writes to an output stream so that
/// long-running responses can periodically emit <c>: keep-alive\n\n</c> comment
/// frames without interleaving with application writes.
/// </summary>
/// <remarks>
/// <para>
/// The session owns a synchronized write-only <see cref="Stream"/> (exposed via
/// <see cref="Stream"/>) that callers should use in place of the underlying
/// transport stream. All writes — both application data and the timer-driven
/// keep-alive comments — acquire the same internal lock, guaranteeing that
/// individual SSE frames are not split by a keep-alive emission.
/// </para>
/// <para>
/// Keep-alives are emitted only while a timer is active; pass
/// <see cref="System.Threading.Timeout.InfiniteTimeSpan"/> (or a non-positive
/// <see cref="TimeSpan"/>) to <see cref="Start"/> to obtain a session that only
/// provides write synchronization. Use <see cref="EnableKeepAlive"/> to activate
/// (or replace) the timer later — for example, from a content-type detection
/// hook that fires before the first response byte.
/// </para>
/// <para>
/// Dispose the session before the response completes to stop the timer and
/// release the internal lock.
/// </para>
/// </remarks>
public sealed class SseKeepAliveSession : IAsyncDisposable
{
    private static readonly byte[] s_keepAliveBytes = ": keep-alive\n\n"u8.ToArray();

    private readonly Stream _output;
    private readonly SemaphoreSlim _writeLock = new(1, 1);
    private readonly ILogger _logger;
    private readonly string _contextName;
    private Timer? _timer;
    private int _disposed;

    private SseKeepAliveSession(Stream output, ILogger logger, string contextName)
    {
        _output = output ?? throw new ArgumentNullException(nameof(output));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _contextName = contextName ?? throw new ArgumentNullException(nameof(contextName));
        Stream = new SynchronizedStream(this);
    }

    /// <summary>
    /// Gets a write-only stream that serializes writes with the keep-alive timer.
    /// Callers should write application data through this stream instead of the
    /// underlying transport stream.
    /// </summary>
    public Stream Stream { get; }

    /// <summary>
    /// Gets a value indicating whether the keep-alive timer is currently active.
    /// </summary>
    public bool IsKeepAliveActive => Volatile.Read(ref _timer) is not null;

    /// <summary>
    /// Creates a session that wraps the specified <paramref name="output"/> stream
    /// and, when <paramref name="interval"/> is positive and finite, starts emitting
    /// periodic SSE keep-alive comments.
    /// </summary>
    /// <param name="output">The underlying transport stream to write to.</param>
    /// <param name="interval">
    /// The keep-alive emission interval. Pass
    /// <see cref="System.Threading.Timeout.InfiniteTimeSpan"/> or a non-positive
    /// value to create a session without a timer (write synchronization only).
    /// </param>
    /// <param name="logger">Logger used for diagnostic messages.</param>
    /// <param name="contextName">A short identifier for log messages (for example, the response or invocation id).</param>
    public static SseKeepAliveSession Start(Stream output, TimeSpan interval, ILogger logger, string contextName)
    {
        var session = new SseKeepAliveSession(output, logger, contextName);
        session.EnableKeepAlive(interval);
        return session;
    }

    /// <summary>
    /// Activates (or replaces) the periodic keep-alive timer. A non-positive or
    /// infinite <paramref name="interval"/> is treated as a no-op so callers may
    /// invoke this unconditionally with the configured interval.
    /// </summary>
    public void EnableKeepAlive(TimeSpan interval)
    {
        if (interval == Timeout.InfiniteTimeSpan || interval <= TimeSpan.Zero)
        {
            return;
        }

        if (Volatile.Read(ref _disposed) != 0)
        {
            throw new ObjectDisposedException(nameof(SseKeepAliveSession));
        }

        var newTimer = new Timer(static state => _ = ((SseKeepAliveSession)state!).OnTimerTickAsync(), this, interval, interval);
        var existing = Interlocked.Exchange(ref _timer, newTimer);
        existing?.Dispose();
    }

    private async Task OnTimerTickAsync()
    {
        try
        {
            await _writeLock.WaitAsync().ConfigureAwait(false);
            try
            {
                await _output.WriteAsync(s_keepAliveBytes.AsMemory()).ConfigureAwait(false);
                await _output.FlushAsync().ConfigureAwait(false);
            }
            finally
            {
                _writeLock.Release();
            }
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "Keep-alive write failed: {Context}", _contextName);
        }
    }

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        if (Interlocked.Exchange(ref _disposed, 1) != 0)
        {
            return;
        }

        var timer = Interlocked.Exchange(ref _timer, null);
        if (timer is not null)
        {
            await timer.DisposeAsync().ConfigureAwait(false);
        }

        _writeLock.Dispose();
    }

    /// <summary>
    /// Write-only <see cref="Stream"/> that delegates all writes through the
    /// session's <see cref="SemaphoreSlim"/>, guaranteeing that application
    /// writes do not interleave with timer-driven keep-alive comments.
    /// </summary>
    private sealed class SynchronizedStream : Stream
    {
        private readonly SseKeepAliveSession _session;

        public SynchronizedStream(SseKeepAliveSession session) => _session = session;

        public override bool CanRead => false;
        public override bool CanSeek => false;
        public override bool CanWrite => true;
        public override long Length => throw new NotSupportedException();
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
        {
            _session._writeLock.Wait();
            try
            {
                _session._output.Write(buffer, offset, count);
            }
            finally
            {
                _session._writeLock.Release();
            }
        }

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await _session._writeLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await _session._output.WriteAsync(buffer.AsMemory(offset, count), cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _session._writeLock.Release();
            }
        }

        public override async ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
        {
            await _session._writeLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await _session._output.WriteAsync(buffer, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _session._writeLock.Release();
            }
        }

        public override void Flush()
        {
            _session._writeLock.Wait();
            try
            {
                _session._output.Flush();
            }
            finally
            {
                _session._writeLock.Release();
            }
        }

        public override async Task FlushAsync(CancellationToken cancellationToken)
        {
            await _session._writeLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await _session._output.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _session._writeLock.Release();
            }
        }
    }
}
