// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text.Json;

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// One logical outbound frame before its exact wire envelope is prepared.
/// </summary>
internal readonly record struct VoiceFramePayload(
    string MessageType,
    IReadOnlyDictionary<string, object?> Fields);

/// <summary>
/// The single owner of outbound frame preparation, ordering, reservation, wire
/// attempts, and post-send commit for one Voice connection.
/// </summary>
internal sealed class VoiceSendTransaction
{
    private readonly WebSocket _webSocket;
    private readonly SemaphoreSlim _sendGate = new(1, 1);
    private readonly CancellationToken _wireCancellation;
    private int _abortRequested;

    public VoiceSendTransaction(WebSocket webSocket, CancellationToken wireCancellation = default)
    {
        _webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
        _wireCancellation = wireCancellation;
    }

    public bool Ending => Volatile.Read(ref _abortRequested) != 0 || _webSocket.State != WebSocketState.Open;

    /// <summary>
    /// Sends a stateless frame through the same transaction owner used by
    /// stateful response operations.
    /// </summary>
    public Task SendAsync(
        string messageType,
        IReadOnlyDictionary<string, object?> fields,
        CancellationToken cancellationToken) =>
        ExecuteAsync(
            new VoiceFramePayload(messageType, fields),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            cancellationToken);

    /// <summary>
    /// Prepares one exact frame before invoking <paramref name="reserveAsync"/>,
    /// attempts the wire write only after reservation succeeds, and invokes
    /// <paramref name="commitAsync"/> only after the complete frame was sent.
    /// </summary>
    public Task<TReservation> ExecuteAsync<TReservation>(
        VoiceFramePayload frame,
        Func<CancellationToken, ValueTask<TReservation>> reserveAsync,
        Func<TReservation, ValueTask<bool>> commitAsync,
        CancellationToken cancellationToken,
        CancellationToken responseCancellation = default,
        Func<ValueTask>? beforeWireAsync = null,
        Action? wireWriteCompleted = null) =>
        ExecuteAsync(
            new[] { frame },
            reserveAsync,
            commitAsync,
            cancellationToken,
            responseCancellation,
            beforeWireAsync,
            wireWriteCompleted);

    /// <summary>
    /// Executes an ordered group of frames as one reservation. This is used
    /// when opening a response and sending its first output must be atomic from
    /// the SDK state machine's perspective.
    /// </summary>
    /// <remarks>
    /// <paramref name="responseCancellation"/> interrupts an in-flight wire
    /// write when the owning response terminates (for example, a caller
    /// barge-in or a response timeout) so a back-pressured send cannot remain
    /// blocked on a now-terminal response. An interrupted write leaves the
    /// message framing ambiguous, so it aborts the carrier like any other wire
    /// failure. A write that completes fully before the terminal is not
    /// interrupted: the frame is valid on the wire and the bridge drops later
    /// output for a terminal response, so the connection is left intact.
    /// </remarks>
    public async Task<TReservation> ExecuteAsync<TReservation>(
        IReadOnlyList<VoiceFramePayload> frames,
        Func<CancellationToken, ValueTask<TReservation>> reserveAsync,
        Func<TReservation, ValueTask<bool>> commitAsync,
        CancellationToken cancellationToken,
        CancellationToken responseCancellation = default,
        Func<ValueTask>? beforeWireAsync = null,
        Action? wireWriteCompleted = null)
    {
        ArgumentNullException.ThrowIfNull(frames);
        ArgumentNullException.ThrowIfNull(reserveAsync);
        ArgumentNullException.ThrowIfNull(commitAsync);
        if (frames.Count == 0)
        {
            throw new ArgumentException("A send transaction requires at least one frame.", nameof(frames));
        }

        await _sendGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            EnsureOpen();
            using var preparedFrames = PrepareFrames(frames);

            // Caller cancellation is honored before any state is reserved. Once
            // reservation succeeds, the transaction must either commit or abort
            // the carrier; cancellation cannot roll state back safely.
            cancellationToken.ThrowIfCancellationRequested();
            var reservation = await reserveAsync(CancellationToken.None).ConfigureAwait(false);

            // The wire write observes the connection runtime token and, for
            // response-scoped sends, the owning response's terminal token, so a
            // back-pressured write is interrupted when the response terminates.
            using var wireLink = responseCancellation.CanBeCanceled
                ? CancellationTokenSource.CreateLinkedTokenSource(_wireCancellation, responseCancellation)
                : null;
            var wireToken = wireLink?.Token ?? _wireCancellation;

            // Cancellation that was already visible before the first wire
            // attempt cannot have produced a partial frame. Fail the logical
            // transaction without aborting the otherwise healthy carrier. Once
            // execution crosses this check, any cancellation/error from
            // SendAsync is conservatively treated as an ambiguous wire attempt.
            if (wireToken.IsCancellationRequested)
            {
                throw new VoiceBridgeConnectionClosedException(
                    "The outbound transaction was terminal before its wire write.");
            }

            if (beforeWireAsync is not null)
            {
                await beforeWireAsync().ConfigureAwait(false);
            }

            // The pre-wire callback can race a response or connection
            // terminal. Recheck before invoking the socket so an already
            // cancelled token never reaches WebSocket.SendAsync and gets
            // misclassified as an ambiguous write attempt.
            if (wireToken.IsCancellationRequested)
            {
                throw new VoiceBridgeConnectionClosedException(
                    "The outbound transaction was terminal before its wire write.");
            }

            try
            {
                for (var index = 0; index < preparedFrames.Frames.Count; index++)
                {
                    if (wireToken.IsCancellationRequested)
                    {
                        // A terminal after an earlier frame in this transaction
                        // leaves the ordered group incomplete on the wire.
                        if (index > 0)
                        {
                            AbortBestEffort();
                        }

                        throw new VoiceBridgeConnectionClosedException(
                            "The outbound transaction was terminal before its wire write.");
                    }

                    var preparedFrame = preparedFrames.Frames[index];
                    // Calling WebSocket.SendAsync is the irreversible attempt
                    // boundary. The socket token is intentionally None: our
                    // explicit state below distinguishes pre-call cancellation
                    // from cancellation racing an already-started operation.
                    var sendTask = _webSocket.SendAsync(
                        preparedFrame.WrittenMemory,
                        WebSocketMessageType.Text,
                        endOfMessage: true,
                        CancellationToken.None).AsTask();
                    var writeState = new WireWriteState(
                        this,
                        sendTask,
                        index == preparedFrames.Frames.Count - 1 ? wireWriteCompleted : null);
                    writeState.ObserveCompletion(sendTask);
                    var cancellationRegistration = wireToken.CanBeCanceled
                        ? wireToken.UnsafeRegister(
                            static state => ((WireWriteState)state!).Cancel(),
                            writeState)
                        : default;
                    try
                    {
                        await Task.WhenAny(sendTask, writeState.Cancellation).ConfigureAwait(false);
                        if (!writeState.WasCancelled)
                        {
                            await sendTask.ConfigureAwait(false);
                            writeState.Complete(sendTask);
                        }
                    }
                    finally
                    {
                        // Never synchronously wait for an in-progress Abort
                        // callback while holding the connection send gate.
                        cancellationRegistration.Unregister();
                        if (wireToken.IsCancellationRequested)
                        {
                            writeState.Cancel();
                        }
                    }

                    if (writeState.WasCancelled)
                    {
                        // A non-cooperative WebSocket implementation may
                        // not complete its pending send after Abort. Keep
                        // the pooled frame alive until that operation really
                        // completes, but release the transaction gate now.
                        preparedFrames.TransferOwnershipTo(sendTask);
                        throw new VoiceBridgeConnectionClosedException(
                            "The voice connection closed during an outbound transaction.");
                    }
                }
            }
#pragma warning disable CA1031 // Any exception after a wire attempt makes delivery ambiguous.
            catch (Exception exception) when (exception is not VoiceBridgeConnectionClosedException)
#pragma warning restore CA1031
            {
                AbortBestEffort();
                throw new VoiceBridgeConnectionClosedException(
                    "The voice connection closed during an outbound transaction.",
                    exception);
            }

            bool committed;
            try
            {
                committed = await commitAsync(reservation).ConfigureAwait(false);
            }
#pragma warning disable CA1031 // A sent frame without a state commit requires carrier abort.
            catch (Exception exception)
#pragma warning restore CA1031
            {
                AbortBestEffort();
                throw new VoiceBridgeConnectionClosedException(
                    "The voice connection could not commit an outbound transaction.",
                    exception);
            }

            if (!committed)
            {
                // The frame was written to the wire in full, but the response
                // terminalized (for example, a racing barge-in or timeout) before
                // the SDK-side commit ran. This is a protocol-legal late frame:
                // the bridge drops later output for a terminal response, so the
                // wire and SDK remain consistent and the carrier is intentionally
                // left open — a barge-in or timeout must not tear down the call.
                // The customer send observes a terminal exception and stops.
                throw new VoiceBridgeConnectionClosedException(
                    "The outbound transaction lost terminal arbitration after its wire write.");
            }

            return reservation;
        }
        finally
        {
            _sendGate.Release();
        }
    }

    internal static void ValidateJsonValue(object value)
    {
        using var buffer = new FixedSizeBufferStream(VoiceProtocolConstants.MaxFrameBytes);
        try
        {
            using var writer = new Utf8JsonWriter(buffer);
            JsonSerializer.Serialize(writer, value);
            writer.Flush();
        }
        catch (FrameTooLargeException)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "The serialized JSON value exceeds the maximum voice frame size.");
        }
    }

    internal static int MeasureEscapedStringBytes(string value)
    {
        using var buffer = new FixedSizeBufferStream(VoiceProtocolConstants.MaxFrameBytes);
        try
        {
            using var writer = new Utf8JsonWriter(buffer);
            writer.WriteStringValue(value);
            writer.Flush();
            return checked((int)buffer.Length - 2);
        }
        catch (FrameTooLargeException)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "The JSON-escaped text exceeds the maximum voice frame size.");
        }
    }

    private PreparedFrameCollection PrepareFrames(IReadOnlyList<VoiceFramePayload> frames)
    {
        var prepared = new List<FixedSizeBufferStream>(frames.Count);
        try
        {
            foreach (var frame in frames)
            {
                prepared.Add(PrepareFrame(frame));
            }

            return new PreparedFrameCollection(prepared);
        }
        catch
        {
            foreach (var frame in prepared)
            {
                frame.Dispose();
            }

            throw;
        }
    }

    private static FixedSizeBufferStream PrepareFrame(VoiceFramePayload frame)
    {
        var payload = new Dictionary<string, object?>(frame.Fields, StringComparer.Ordinal)
        {
            ["type"] = frame.MessageType,
            ["id"] = VoiceIds.New(VoiceProtocolConstants.EnvelopeIdPrefix),
            ["ts"] = DateTimeOffset.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.CultureInfo.InvariantCulture),
        };
        var buffer = new FixedSizeBufferStream(VoiceProtocolConstants.MaxFrameBytes);
        try
        {
            using var writer = new Utf8JsonWriter(buffer);
            JsonSerializer.Serialize(writer, payload);
            writer.Flush();
            return buffer;
        }
        catch (FrameTooLargeException)
        {
            buffer.Dispose();
            throw new ArgumentOutOfRangeException(
                nameof(frame),
                "The serialized voice frame exceeds the maximum size of 1 MiB.");
        }
        catch
        {
            buffer.Dispose();
            throw;
        }
    }

    private void EnsureOpen()
    {
        if (Ending)
        {
            throw new VoiceBridgeConnectionClosedException("The voice connection is closed.");
        }
    }

    private void AbortBestEffort()
    {
        if (!TryRequestAbort())
        {
            return;
        }

        AbortSocketBestEffort();
    }

    private bool TryRequestAbort() =>
        Interlocked.CompareExchange(ref _abortRequested, 1, 0) == 0;

    private void AbortSocketBestEffort()
    {
        try
        {
            if (_webSocket.State is not (WebSocketState.Aborted or WebSocketState.Closed))
            {
                _webSocket.Abort();
            }
        }
#pragma warning disable CA1031 // Ambiguous writes must not escape without carrier abort.
        catch (Exception)
#pragma warning restore CA1031
        {
        }
    }

    private sealed class PreparedFrameCollection : IDisposable
    {
        private int _ownershipTransferred;

        public PreparedFrameCollection(IReadOnlyList<FixedSizeBufferStream> frames)
        {
            Frames = frames;
        }

        public IReadOnlyList<FixedSizeBufferStream> Frames { get; }

        public void TransferOwnershipTo(Task sendTask)
        {
            if (Interlocked.Exchange(ref _ownershipTransferred, 1) != 0)
            {
                return;
            }

            _ = sendTask.ContinueWith(
                static (completed, state) =>
                {
                    if (completed.IsFaulted)
                    {
                        _ = completed.Exception;
                    }

                    ((PreparedFrameCollection)state!).DisposeFrames();
                },
                this,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        public void Dispose()
        {
            if (Volatile.Read(ref _ownershipTransferred) != 0)
            {
                return;
            }

            DisposeFrames();
        }

        private void DisposeFrames()
        {
            foreach (var frame in Frames)
            {
                frame.Dispose();
            }
        }
    }

    private sealed class WireWriteState
    {
        private const int InFlight = 0;
        private const int Completed = 1;
        private const int Cancelled = 2;

        private readonly VoiceSendTransaction _transaction;
        private readonly Task _sendTask;
        private readonly Action? _writeCompleted;
        private readonly TaskCompletionSource _cancellation =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private int _state;

        public WireWriteState(
            VoiceSendTransaction transaction,
            Task sendTask,
            Action? writeCompleted)
        {
            _transaction = transaction;
            _sendTask = sendTask;
            _writeCompleted = writeCompleted;
        }

        public Task Cancellation => _cancellation.Task;

        public bool WasCancelled => Volatile.Read(ref _state) == Cancelled;

        public void ObserveCompletion(Task sendTask)
        {
            _ = sendTask.ContinueWith(
                static (completed, state) => ((WireWriteState)state!).Complete(completed),
                this,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        public void Cancel()
        {
            if (_sendTask.IsCompletedSuccessfully)
            {
                Complete(_sendTask);
                return;
            }

            if (Interlocked.CompareExchange(ref _state, Cancelled, InFlight) != InFlight)
            {
                return;
            }

            // The send may have completed between the first observation and
            // cancellation winning the state CAS. A completed frame is valid
            // on the wire and must win over a later terminal notification.
            if (_sendTask.IsCompletedSuccessfully &&
                Interlocked.CompareExchange(ref _state, Completed, Cancelled) == Cancelled)
            {
                _writeCompleted?.Invoke();
                return;
            }

            var shouldAbort = _transaction.TryRequestAbort();
            _cancellation.TrySetResult();
            if (shouldAbort)
            {
                _transaction.AbortSocketBestEffort();
            }
        }

        public void Complete(Task sendTask)
        {
            if (Interlocked.CompareExchange(ref _state, Completed, InFlight) == InFlight &&
                sendTask.Status == TaskStatus.RanToCompletion)
            {
                _writeCompleted?.Invoke();
            }
        }
    }

    private sealed class FixedSizeBufferStream : Stream
    {
        private readonly int _capacity;
        private byte[]? _buffer;
        private int _written;

        public FixedSizeBufferStream(int capacity)
        {
            _capacity = capacity;
            _buffer = ArrayPool<byte>.Shared.Rent(Math.Min(4096, capacity));
        }

        public ReadOnlyMemory<byte> WrittenMemory =>
            (_buffer ?? throw new ObjectDisposedException(nameof(FixedSizeBufferStream))).AsMemory(0, _written);

        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => _written;

        public override long Position
        {
            get => _written;
            set => throw new NotSupportedException();
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count) =>
            throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin) =>
            throw new NotSupportedException();

        public override void SetLength(long value) =>
            throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
        {
            ArgumentNullException.ThrowIfNull(buffer);
            Write(buffer.AsSpan(offset, count));
        }

        public override void Write(ReadOnlySpan<byte> buffer)
        {
            if (buffer.Length > _capacity - _written)
            {
                throw new FrameTooLargeException();
            }

            EnsureCapacity(_written + buffer.Length);
            buffer.CopyTo(
                (_buffer ?? throw new ObjectDisposedException(nameof(FixedSizeBufferStream)))
                    .AsSpan(_written, buffer.Length));
            _written += buffer.Length;
        }

        private void EnsureCapacity(int requiredCapacity)
        {
            var current = _buffer ?? throw new ObjectDisposedException(nameof(FixedSizeBufferStream));
            if (requiredCapacity <= current.Length)
            {
                return;
            }

            var targetCapacity = Math.Min(
                _capacity,
                Math.Max(requiredCapacity, Math.Min(_capacity, current.Length * 2)));
            var replacement = ArrayPool<byte>.Shared.Rent(targetCapacity);
            current.AsSpan(0, _written).CopyTo(replacement);
            CryptographicOperations.ZeroMemory(current.AsSpan(0, _written));
            ArrayPool<byte>.Shared.Return(current);
            _buffer = replacement;
        }

        protected override void Dispose(bool disposing)
        {
            var buffer = Interlocked.Exchange(ref _buffer, null);
            if (buffer is not null)
            {
                try
                {
                    CryptographicOperations.ZeroMemory(buffer.AsSpan(0, _written));
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(buffer);
                }
            }

            base.Dispose(disposing);
        }
    }

    private sealed class FrameTooLargeException : Exception
    {
    }
}
