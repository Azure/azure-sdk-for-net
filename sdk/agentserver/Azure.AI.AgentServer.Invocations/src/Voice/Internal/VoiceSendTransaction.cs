// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text.Json;

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// One logical outbound frame before its exact wire envelope is prepared.
/// </summary>
internal readonly record struct VoiceFramePayload(
    string MessageType,
    IReadOnlyDictionary<string, object?> Fields,
    string? OwnerResponseId = null,
    string? TerminalKind = null,
    VoiceResponseResources? OutputResources = null);

/// <summary>
/// The single in-flight logical send after it crossed the irreversible socket
/// attempt boundary and before its local semantic commit completed.
/// </summary>
internal sealed record VoiceOutboundAttempt(
    long Generation,
    IReadOnlyList<VoiceFramePayload> Frames,
    int AttemptedPrefix);

internal sealed class VoiceWireAttemptSignal
{
    private int _attempted;

    public bool IsAttempted => Volatile.Read(ref _attempted) != 0;

    public void MarkAttempted() => Volatile.Write(ref _attempted, 1);
}

/// <summary>
/// The single owner of outbound frame preparation, ordering, reservation, wire
/// attempts, and post-send commit for one Voice connection.
/// </summary>
internal sealed class VoiceSendTransaction
{
    private readonly WebSocket _webSocket;
    private readonly VoiceResourceGovernor _resourceGovernor;
    private readonly SemaphoreSlim _sendGate = new(1, 1);
    private readonly CancellationToken _wireCancellation;
    private readonly TimeSpan? _physicalSendTimeout;
    private readonly TimeSpan? _terminalSendDrainTimeout;
    private VoiceOutboundAttempt? _currentAttempt;
    private long _nextAttemptGeneration;
    private int _abortRequested;

    public VoiceSendTransaction(
        WebSocket webSocket,
        CancellationToken wireCancellation = default,
        TimeSpan? physicalSendTimeout = null,
        TimeSpan? terminalSendDrainTimeout = null)
        : this(
            webSocket,
            new VoiceResourceGovernor(),
            wireCancellation,
            physicalSendTimeout,
            terminalSendDrainTimeout)
    {
    }

    internal VoiceSendTransaction(
        WebSocket webSocket,
        VoiceResourceGovernor resourceGovernor,
        CancellationToken wireCancellation = default,
        TimeSpan? physicalSendTimeout = null,
        TimeSpan? terminalSendDrainTimeout = null)
    {
        _webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
        _resourceGovernor = resourceGovernor ?? throw new ArgumentNullException(nameof(resourceGovernor));
        _wireCancellation = wireCancellation;
        _physicalSendTimeout = physicalSendTimeout;
        _terminalSendDrainTimeout = terminalSendDrainTimeout;
        if (_physicalSendTimeout is { } timeout && timeout <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(physicalSendTimeout));
        }
        if (_terminalSendDrainTimeout is { } terminalTimeout && terminalTimeout <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(terminalSendDrainTimeout));
        }
    }

    public bool Ending => Volatile.Read(ref _abortRequested) != 0 || _webSocket.State != WebSocketState.Open;

    internal long OutstandingPreparedFrameBytes => _resourceGovernor.PreparedFrameBytes;

    public bool IsItemPotentiallyVisible(string responseId, string itemId)
    {
        var attempt = Volatile.Read(ref _currentAttempt);
        if (attempt is null)
        {
            return false;
        }

        var attemptedPrefix = attempt.AttemptedPrefix;
        for (var index = 0; index < attemptedPrefix; index++)
        {
            var frame = attempt.Frames[index];
            if (frame.MessageType is "response.output_text.delta" or "response.output_text.done" &&
                frame.Fields.TryGetValue("response_id", out var responseValue) &&
                string.Equals(responseValue as string, responseId, StringComparison.Ordinal) &&
                frame.Fields.TryGetValue("item_id", out var itemValue) &&
                string.Equals(itemValue as string, itemId, StringComparison.Ordinal))
            {
                return true;
            }
        }

        return false;
    }

    public bool TryGetPotentiallyVisibleTerminal(string responseId, out string terminalKind)
    {
        var attempt = Volatile.Read(ref _currentAttempt);
        if (attempt is not null)
        {
            var attemptedPrefix = attempt.AttemptedPrefix;
            for (var index = 0; index < attemptedPrefix; index++)
            {
                var frame = attempt.Frames[index];
                if (frame.TerminalKind is null ||
                    !string.Equals(frame.OwnerResponseId, responseId, StringComparison.Ordinal))
                {
                    continue;
                }

                terminalKind = frame.TerminalKind;
                return true;
            }
        }

        terminalKind = string.Empty;
        return false;
    }

    public bool TryGetPotentiallyVisibleHandoff(string target, out string responseId)
    {
        if (TryGetPotentiallyVisibleHandoff(out responseId, out var attemptedTarget) &&
            string.Equals(attemptedTarget, target, StringComparison.Ordinal))
        {
            return true;
        }

        responseId = string.Empty;
        return false;
    }

    public bool TryGetPotentiallyVisibleHandoff(out string responseId, out string target)
    {
        var attempt = Volatile.Read(ref _currentAttempt);
        if (attempt is not null)
        {
            var attemptedPrefix = attempt.AttemptedPrefix;
            for (var index = 0; index < attemptedPrefix; index++)
            {
                var frame = attempt.Frames[index];
                if (frame.TerminalKind != "handoff" ||
                    !frame.Fields.TryGetValue("target", out var targetValue) ||
                    targetValue is not string attemptedTarget ||
                    string.IsNullOrEmpty(frame.OwnerResponseId))
                {
                    continue;
                }

                responseId = frame.OwnerResponseId;
                target = attemptedTarget;
                return true;
            }
        }

        responseId = string.Empty;
        target = string.Empty;
        return false;
    }

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
        Action? wireWriteCompleted = null,
        CancellationToken operationDeadlineCancellation = default,
        VoiceWireAttemptSignal? wireAttempted = null,
        Action<Task>? retainedSend = null,
        Action? encodedCommitStarted = null) =>
        ExecuteAsync(
            new[] { frame },
            reserveAsync,
            commitAsync,
            cancellationToken,
            responseCancellation,
            beforeWireAsync,
            wireWriteCompleted,
            operationDeadlineCancellation,
            wireAttempted,
            retainedSend,
            encodedCommitStarted);

    /// <summary>
    /// Executes an ordered group of frames as one reservation. This is used
    /// when opening a response and sending its first output must be atomic from
    /// the SDK state machine's perspective.
    /// </summary>
    /// <remarks>
    /// <paramref name="responseCancellation"/> prevents a pre-attempt write.
    /// Once a frame has entered the irreversible socket-attempt boundary, a
    /// response terminal starts bounded physical drain instead of immediately
    /// cancelling the write. The bridge owns protocol-legal late-frame dropping;
    /// expiry of the drain, connection cancellation, or socket failure remains
    /// a transport-level failure and aborts the carrier.
    /// </remarks>
    public async Task<TReservation> ExecuteAsync<TReservation>(
        IReadOnlyList<VoiceFramePayload> frames,
        Func<CancellationToken, ValueTask<TReservation>> reserveAsync,
        Func<TReservation, ValueTask<bool>> commitAsync,
        CancellationToken cancellationToken,
        CancellationToken responseCancellation = default,
        Func<ValueTask>? beforeWireAsync = null,
        Action? wireWriteCompleted = null,
        CancellationToken operationDeadlineCancellation = default,
        VoiceWireAttemptSignal? wireAttempted = null,
        Action<Task>? retainedSend = null,
        Action? encodedCommitStarted = null)
    {
        ArgumentNullException.ThrowIfNull(frames);
        ArgumentNullException.ThrowIfNull(reserveAsync);
        ArgumentNullException.ThrowIfNull(commitAsync);
        if (frames.Count == 0)
        {
            throw new ArgumentException("A send transaction requires at least one frame.", nameof(frames));
        }
        if (operationDeadlineCancellation.CanBeCanceled && beforeWireAsync is not null)
        {
            throw new ArgumentException(
                "An operation deadline requires all pre-wire work to observe its cancellation token.",
                nameof(beforeWireAsync));
        }

        long attemptGeneration = 0;
        long? terminalDrainStarted = null;
        var retainAttemptUntilUnderlyingSendCompletes = false;
        var socketCallStarted = false;
        using var gateCancellation = cancellationToken.CanBeCanceled && operationDeadlineCancellation.CanBeCanceled
            ? CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, operationDeadlineCancellation)
            : null;
        var gateCancellationToken = gateCancellation?.Token ??
            (operationDeadlineCancellation.CanBeCanceled ? operationDeadlineCancellation : cancellationToken);
        await _sendGate.WaitAsync(gateCancellationToken).ConfigureAwait(false);
        try
        {
            EnsureOpen();
            var reservedBytes = checked((long)frames.Count * VoiceProtocolConstants.MaxFrameBytes);
            var control = IsControlTransaction(frames);
            var frameLease = _resourceGovernor.AcquirePreparedFrames(
                frames.Count,
                reservedBytes,
                control);
            using var preparedFrames = PrepareFrames(frames, frameLease);
            using var encodedOutputReservation = ReserveEncodedOutput(frames, preparedFrames);

            // Caller cancellation is honored before any state is reserved. Once
            // reservation succeeds, the transaction must physically drain and
            // then either commit or lose semantic arbitration.
            cancellationToken.ThrowIfCancellationRequested();
            operationDeadlineCancellation.ThrowIfCancellationRequested();
            if (responseCancellation.IsCancellationRequested)
            {
                throw new VoiceBridgeConnectionClosedException(
                    "The outbound transaction was terminal before state reservation.");
            }

            var reservation = await reserveAsync(
                operationDeadlineCancellation.CanBeCanceled
                    ? operationDeadlineCancellation
                    : CancellationToken.None).ConfigureAwait(false);

            // Cancellation that was already visible before the first wire
            // attempt cannot have produced a partial frame. Fail the logical
            // transaction without aborting the otherwise healthy carrier. Once
            // execution crosses this check, any cancellation/error from
            // SendAsync is conservatively treated as an ambiguous wire attempt.
            if (_wireCancellation.IsCancellationRequested)
            {
                throw new VoiceBridgeConnectionClosedException(
                    "The outbound transaction was terminal before its wire write.");
            }

            operationDeadlineCancellation.ThrowIfCancellationRequested();

            if (beforeWireAsync is not null)
            {
                await beforeWireAsync().ConfigureAwait(false);
            }

            // The pre-wire callback can race a response or connection
            // terminal. Only connection-level cancellation aborts the physical
            // carrier after reservation; response terminals are reconciled by
            // the post-send generation-safe commit.
            if (_wireCancellation.IsCancellationRequested)
            {
                throw new VoiceBridgeConnectionClosedException(
                    "The outbound transaction was terminal before its wire write.");
            }

            operationDeadlineCancellation.ThrowIfCancellationRequested();

            if (responseCancellation.IsCancellationRequested)
            {
                throw new VoiceBridgeConnectionClosedException(
                    "The outbound transaction lost semantic arbitration before its wire write.");
            }

            try
            {
                for (var index = 0; index < preparedFrames.Frames.Count; index++)
                {
                    if (_wireCancellation.IsCancellationRequested)
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

                    if (attemptGeneration == 0)
                    {
                        attemptGeneration = PublishAttempt(frames);
                    }

                    var preparedFrame = preparedFrames.Frames[index];
                    var sendOrOperationDeadline = new SendOperationDeadlineArbiter();
                    var operationDeadlineRegistration = operationDeadlineCancellation.CanBeCanceled
                        ? operationDeadlineCancellation.UnsafeRegister(
                            static state => ((SendOperationDeadlineArbiter)state!).DeadlineElapsed(),
                            sendOrOperationDeadline)
                        : default;
                    // Calling WebSocket.SendAsync is the irreversible attempt
                    // boundary. The socket token is intentionally None: our
                    // explicit state below distinguishes pre-call cancellation
                    // from cancellation racing an already-started operation.
                    Task sendTask;
                    try
                    {
                        if (index == 0)
                        {
                            encodedOutputReservation?.Commit(
                                () =>
                                {
                                    if (_wireCancellation.IsCancellationRequested)
                                    {
                                        throw new VoiceBridgeConnectionClosedException(
                                            "The outbound transaction was terminal before its wire write.");
                                    }

                                    operationDeadlineCancellation.ThrowIfCancellationRequested();
                                    if (responseCancellation.IsCancellationRequested)
                                    {
                                        throw new VoiceBridgeConnectionClosedException(
                                            "The outbound transaction lost semantic arbitration before its wire write.");
                                    }
                                },
                                encodedCommitStarted);
                        }
                        MarkFrameAttempted(attemptGeneration, index);
                        wireAttempted?.MarkAttempted();
                        socketCallStarted = true;
                        sendTask = _webSocket.SendAsync(
                            preparedFrame.WrittenMemory,
                            WebSocketMessageType.Text,
                            endOfMessage: true,
                            CancellationToken.None).AsTask();
                    }
                    catch
                    {
                        operationDeadlineRegistration.Unregister();
                        throw;
                    }
                    sendOrOperationDeadline.SetSendTask(sendTask);
                    var transportCancellation = new TaskCompletionSource(
                        TaskCreationOptions.RunContinuationsAsynchronously);
                    var cancellationRegistration = _wireCancellation.CanBeCanceled
                        ? _wireCancellation.UnsafeRegister(
                            static state => ((TaskCompletionSource)state!).TrySetResult(),
                            transportCancellation)
                        : default;
                    var semanticCancellation = new TaskCompletionSource(
                        TaskCreationOptions.RunContinuationsAsynchronously);
                    var semanticCancellationRegistration = responseCancellation.CanBeCanceled
                        ? responseCancellation.UnsafeRegister(
                            static state => ((TaskCompletionSource)state!).TrySetResult(),
                            semanticCancellation)
                        : default;
                    using var timeoutCancellation = new CancellationTokenSource();
                    var timeoutTask = _physicalSendTimeout is { } sendTimeout
                        ? Task.Delay(sendTimeout, timeoutCancellation.Token)
                        : Task.Delay(Timeout.InfiniteTimeSpan, timeoutCancellation.Token);
                    var semanticDrainStart = _terminalSendDrainTimeout.HasValue
                        ? semanticCancellation.Task
                        : Task.Delay(Timeout.InfiniteTimeSpan, timeoutCancellation.Token);
                    using var terminalFrameDrainCancellation = new CancellationTokenSource();
                    var terminalFrameDrainTask = Task.Delay(
                        Timeout.InfiniteTimeSpan,
                        terminalFrameDrainCancellation.Token);
                    if (frames[index].TerminalKind is not null &&
                        _terminalSendDrainTimeout is { } responseTerminalDrainTimeout)
                    {
                        terminalDrainStarted ??= Stopwatch.GetTimestamp();
                        var remaining = responseTerminalDrainTimeout -
                            Stopwatch.GetElapsedTime(terminalDrainStarted.Value);
                        terminalFrameDrainTask = remaining <= TimeSpan.Zero
                            ? Task.CompletedTask
                            : Task.Delay(remaining, terminalFrameDrainCancellation.Token);
                    }
                    try
                    {
                        var completed = await Task.WhenAny(
                            sendOrOperationDeadline.Completion,
                            transportCancellation.Task,
                            semanticDrainStart,
                            timeoutTask,
                            terminalFrameDrainTask).ConfigureAwait(false);
                        var sendWonOperationDeadline = sendOrOperationDeadline.TryClaimCompletedSend();
                        if (sendWonOperationDeadline)
                        {
                            await sendTask.ConfigureAwait(false);
                            if (index == preparedFrames.Frames.Count - 1)
                            {
                                wireWriteCompleted?.Invoke();
                            }
                            continue;
                        }

                        var terminalDrainExpired = false;
                        if (completed == semanticDrainStart &&
                            _terminalSendDrainTimeout is { } terminalDrainTimeout)
                        {
                            terminalDrainStarted ??= Stopwatch.GetTimestamp();
                            if (frames[index].TerminalKind is null)
                            {
                                var remaining = terminalDrainTimeout -
                                    Stopwatch.GetElapsedTime(terminalDrainStarted.Value);
                                terminalFrameDrainTask = remaining <= TimeSpan.Zero
                                    ? Task.CompletedTask
                                    : Task.Delay(remaining, terminalFrameDrainCancellation.Token);
                            }

                            completed = await Task.WhenAny(
                                sendOrOperationDeadline.Completion,
                                transportCancellation.Task,
                                timeoutTask,
                                terminalFrameDrainTask).ConfigureAwait(false);
                            terminalDrainExpired = completed == terminalFrameDrainTask;

                            sendWonOperationDeadline = sendOrOperationDeadline.TryClaimCompletedSend();
                            if (sendWonOperationDeadline)
                            {
                                await sendTask.ConfigureAwait(false);
                                if (index == preparedFrames.Frames.Count - 1)
                                {
                                    wireWriteCompleted?.Invoke();
                                }
                                continue;
                            }
                        }
                        else
                        {
                            terminalDrainExpired = completed == terminalFrameDrainTask;
                        }

                        if (sendWonOperationDeadline)
                        {
                            await sendTask.ConfigureAwait(false);
                        }

                        AbortBestEffort();
                        retainAttemptUntilUnderlyingSendCompletes = true;
                        preparedFrames.TransferOwnershipTo(
                            sendTask,
                            () => ClearAttempt(attemptGeneration));
                        retainedSend?.Invoke(sendTask);
                        throw new VoiceBridgeConnectionClosedException(
                            completed == sendOrOperationDeadline.Completion && !sendWonOperationDeadline
                                ? "The outbound transaction exceeded its operation deadline."
                                : completed == timeoutTask || terminalDrainExpired
                                ? "The physical voice send exceeded its bounded drain deadline."
                                : "The voice connection closed during an outbound transaction.");
                    }
                    finally
                    {
                        cancellationRegistration.Unregister();
                        semanticCancellationRegistration.Unregister();
                        operationDeadlineRegistration.Unregister();
                        timeoutCancellation.Cancel();
                        terminalFrameDrainCancellation.Cancel();
                    }
                }
            }
#pragma warning disable CA1031 // Explicit wire phase, not exception type, decides whether delivery is ambiguous.
            catch (Exception exception)
#pragma warning restore CA1031
            {
                if (socketCallStarted)
                {
                    AbortBestEffort();
                }
                else if (exception is VoiceBridgeConnectionClosedException or OperationCanceledException)
                {
                    throw;
                }

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
            if (!retainAttemptUntilUnderlyingSendCompletes)
            {
                ClearAttempt(attemptGeneration);
            }
            _sendGate.Release();
        }
    }

    private sealed class SendOperationDeadlineArbiter
    {
        private readonly object _sync = new();
        private readonly TaskCompletionSource<bool> _completion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private Task? _sendTask;
        private bool _deadlineElapsed;

        public Task<bool> Completion => _completion.Task;

        public void SetSendTask(Task sendTask)
        {
            ArgumentNullException.ThrowIfNull(sendTask);
            lock (_sync)
            {
                _sendTask = sendTask;
                if (sendTask.IsCompleted || _deadlineElapsed)
                {
                    _completion.TrySetResult(sendTask.IsCompleted);
                    return;
                }
            }

            _ = sendTask.ContinueWith(
                static (_, state) => ((SendOperationDeadlineArbiter)state!).SendCompleted(),
                this,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        public void DeadlineElapsed()
        {
            lock (_sync)
            {
                _deadlineElapsed = true;
                if (_sendTask is not null)
                {
                    _completion.TrySetResult(_sendTask.IsCompleted);
                }
            }
        }

        public bool TryClaimCompletedSend()
        {
            lock (_sync)
            {
                if (_completion.Task.IsCompletedSuccessfully)
                {
                    return _completion.Task.Result;
                }

                if (_sendTask?.IsCompleted == true)
                {
                    _completion.TrySetResult(true);
                    return true;
                }

                return false;
            }
        }

        private void SendCompleted()
        {
            lock (_sync)
            {
                _completion.TrySetResult(true);
            }
        }
    }

    private long PublishAttempt(IReadOnlyList<VoiceFramePayload> frames)
    {
        var generation = checked(Interlocked.Increment(ref _nextAttemptGeneration));
        Volatile.Write(
            ref _currentAttempt,
            new VoiceOutboundAttempt(generation, frames.ToArray(), AttemptedPrefix: 0));
        return generation;
    }

    private void MarkFrameAttempted(long generation, int index)
    {
        while (true)
        {
            var attempt = Volatile.Read(ref _currentAttempt);
            if (attempt?.Generation != generation || attempt.AttemptedPrefix != index)
            {
                throw new InvalidOperationException(
                    "The outbound frame attempt generation or prefix changed unexpectedly.");
            }

            var updated = attempt with { AttemptedPrefix = index + 1 };
            if (Interlocked.CompareExchange(ref _currentAttempt, updated, attempt) == attempt)
            {
                return;
            }
        }
    }

    private void ClearAttempt(long generation)
    {
        if (generation == 0)
        {
            return;
        }

        var attempt = Volatile.Read(ref _currentAttempt);
        if (attempt?.Generation == generation)
        {
            Interlocked.CompareExchange(ref _currentAttempt, null, attempt);
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

    private static bool IsControlFrame(string messageType) =>
        messageType is
            "session.ready" or
            "session.rejected" or
            "response.none" or
            "response.done" or
            "response.cancel" or
            "handoff" or
            "end_call" or
            "error";

    private static bool IsControlTransaction(IReadOnlyList<VoiceFramePayload> frames)
    {
        if (frames.All(static frame => IsControlFrame(frame.MessageType)))
        {
            return true;
        }

        if (frames.Count != 2 ||
            frames[0].MessageType != "response.created" ||
            !IsControlFrame(frames[1].MessageType))
        {
            return false;
        }

        return frames[0].Fields.TryGetValue("response_id", out var openedResponseId) &&
            frames[1].Fields.TryGetValue("response_id", out var terminalResponseId) &&
            string.Equals(openedResponseId as string, terminalResponseId as string, StringComparison.Ordinal);
    }

    private static VoiceOutputReservation? ReserveEncodedOutput(
        IReadOnlyList<VoiceFramePayload> frames,
        PreparedFrameCollection preparedFrames)
    {
        VoiceResponseResources? owner = null;
        long encodedBytes = 0;
        long terminalEncodedBytes = 0;
        var protectedControl = IsControlTransaction(frames);
        for (var index = 0; index < frames.Count; index++)
        {
            var frame = frames[index];
            if (frame.OutputResources is null)
            {
                continue;
            }

            if (owner is not null && !ReferenceEquals(owner, frame.OutputResources))
            {
                throw new InvalidOperationException(
                    "One outbound transaction cannot reserve output for multiple responses.");
            }

            owner = frame.OutputResources;
            if (!protectedControl)
            {
                encodedBytes = checked(encodedBytes + preparedFrames.Frames[index].WrittenMemory.Length);
            }
            else
            {
                terminalEncodedBytes = checked(
                    terminalEncodedBytes + preparedFrames.Frames[index].WrittenMemory.Length);
            }
        }

        return owner?.Reserve(
            encodedBytes: encodedBytes,
            terminalEncodedBytes: terminalEncodedBytes);
    }

    private PreparedFrameCollection PrepareFrames(
        IReadOnlyList<VoiceFramePayload> frames,
        VoiceResourceLease frameLease)
    {
        var prepared = new List<FixedSizeBufferStream>(frames.Count);
        try
        {
            foreach (var frame in frames)
            {
                prepared.Add(PrepareFrame(frame));
            }

            return new PreparedFrameCollection(prepared, frameLease);
        }
        catch
        {
            foreach (var frame in prepared)
            {
                frame.Dispose();
            }

            frameLease.Dispose();
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
        private readonly VoiceResourceLease _frameLease;
        private int _ownershipTransferred;
        private int _disposed;

        public PreparedFrameCollection(
            IReadOnlyList<FixedSizeBufferStream> frames,
            VoiceResourceLease frameLease)
        {
            Frames = frames;
            _frameLease = frameLease;
        }

        public IReadOnlyList<FixedSizeBufferStream> Frames { get; }

        public void TransferOwnershipTo(Task sendTask, Action? ownershipReleased = null)
        {
            if (Interlocked.Exchange(ref _ownershipTransferred, 1) != 0)
            {
                return;
            }

            _ = sendTask.ContinueWith(
                (completed, state) =>
                {
                    if (completed.IsFaulted)
                    {
                        _ = completed.Exception;
                    }

                    ((PreparedFrameCollection)state!).DisposeFrames();
                    ownershipReleased?.Invoke();
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
            if (Interlocked.Exchange(ref _disposed, 1) != 0)
            {
                return;
            }

            foreach (var frame in Frames)
            {
                frame.Dispose();
            }

            _frameLease.Dispose();
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
