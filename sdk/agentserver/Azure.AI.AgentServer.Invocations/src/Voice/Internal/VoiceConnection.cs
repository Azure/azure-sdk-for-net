// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using Azure.AI.AgentServer.Invocations.Internal;

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// Per-WebSocket Voice Live Bridge Protocol runtime. A single receive pump owns
/// the socket reader while an ordered callback worker runs customer code.
/// </summary>
internal sealed class VoiceConnection : IVoiceConnection
{
    private const int MaxCallbackQueueBytes = 8 * 1024 * 1024;
    private const int MaxTrackedIds = 4096;
    private const int MaxRecentResponses = 64;
    private const int MaxResolvedPrefixes = 64;

    private static readonly HashSet<string> AgentToBridgeMessageTypes = new(StringComparer.Ordinal)
    {
        "session.ready",
        "session.rejected",
        "conversation.item.created",
        "conversation.item.deleted",
        "conversation.item.failed",
        "response.created",
        "response.none",
        "response.output_text.delta",
        "response.output_text.done",
        "response.done",
        "response.cancel",
        "handoff",
        "end_call",
        "dtmf.collect",
        "dtmf.collect.cancel",
        "error",
    };

    private readonly WebSocket _webSocket;
    private readonly VoiceHandler _handler;
    private readonly VoiceSendTransaction _sendTransaction;
    private readonly CleanupDeadline _cleanupDeadline;
    private readonly VoiceTurnLease _turnLease;
    private readonly VoiceTerminationCoordinator _termination;
    private readonly ActivityContext _connectionActivityContext;
    private readonly CancellationToken _connectionCancellationToken;
    private readonly CancellationTokenSource _runtimeCancellation;
    private readonly SemaphoreSlim _stateGate = new(1, 1);
    private readonly Channel<CallbackWork> _callbackQueue;
    private readonly ConcurrentDictionary<Task, byte> _cleanupTasks = new();
    private readonly Dictionary<string, string> _seenMessages = new(StringComparer.Ordinal);
    private readonly HashSet<string> _seenInputIdDigests = new(StringComparer.Ordinal);
    private readonly HashSet<string> _seenResponseIds = new(StringComparer.Ordinal);
    private readonly HashSet<string> _playbackOutcomes = new(StringComparer.Ordinal);
    private readonly HashSet<string> _abandonedProactiveCancels = new(StringComparer.Ordinal);
    private readonly Dictionary<string, VoiceResponse> _pendingTurns = new(StringComparer.Ordinal);
    private readonly LinkedList<string> _pendingTurnOrder = new();
    private readonly LinkedList<ResolvedPrefix> _resolvedPrefixes = new();
    private readonly Dictionary<string, VoiceResponse> _recentResponses = new(StringComparer.Ordinal);
    private readonly LinkedList<string> _recentResponseOrder = new();
    private readonly Dictionary<string, TaskCompletionSource<ResponseCancellationOutcome>> _cancelWaiters = new(StringComparer.Ordinal);
    private readonly Dictionary<string, PendingProactive> _pendingProactive = new(StringComparer.Ordinal);
    private readonly Dictionary<string, string> _dtmfCollections = new(StringComparer.Ordinal);
    private readonly HashSet<string> _dtmfCancelPending = new(StringComparer.Ordinal);
    private readonly HashSet<string> _recentDtmfCancelRaces = new(StringComparer.Ordinal);
    private readonly LinkedList<string> _recentDtmfCancelRaceOrder = new();
    private readonly Dictionary<string, long> _responseStartTimestamps = new(StringComparer.Ordinal);
    private readonly HashSet<string> _firstOutputRecorded = new(StringComparer.Ordinal);
    private readonly TaskCompletionSource _sessionEndSignal =
        new(TaskCreationOptions.RunContinuationsAsynchronously);

    private VoiceSession? _session;
    private SessionEndEvent? _sessionEndEvent;
    private Task? _callbackWorker;
    private long _queuedCallbackBytes;
    private bool _ready;
    private bool _closed;
    private bool _ending;
    private bool _activationRecorded;
    private int _closeRecorded;
    private int _sessionEndCallbackStarted;

    public VoiceConnection(
        WebSocket webSocket,
        VoiceHandler handler,
        CancellationToken cancellationToken)
    {
        _webSocket = webSocket;
        _handler = handler;
        _connectionActivityContext = Activity.Current?.Context ?? default;
        _cleanupDeadline = webSocket is TrackingWebSocket trackingWebSocket
            ? trackingWebSocket.CleanupDeadline
            : new CleanupDeadline(TimeSpan.FromSeconds(VoiceProtocolConstants.CleanupTimeoutSeconds));
        _connectionCancellationToken = cancellationToken;
        _runtimeCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        // The wire owner observes the runtime cancellation token so that any
        // connection terminal (end_call, session end, protocol/transport error,
        // or cleanup deadline) aborts an in-flight, back-pressured socket write
        // and releases the send gate instead of stranding it indefinitely.
        _sendTransaction = new VoiceSendTransaction(webSocket, _runtimeCancellation.Token);
        _turnLease = new VoiceTurnLease();
        _termination = new VoiceTerminationCoordinator(
            _cleanupDeadline,
            _runtimeCancellation,
            webSocket,
            _turnLease,
            RecordCloseCode,
            SealTerminationAsync,
            ApplyTerminationAsync,
            NotifySessionEndAsync);
        _callbackQueue = Channel.CreateBounded<CallbackWork>(new BoundedChannelOptions(VoiceProtocolConstants.MaxCallbackQueue)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true,
            SingleWriter = true,
            AllowSynchronousContinuations = false,
        });
    }

    public bool Ending => _termination.IsTerminating || _closed || _sendTransaction.Ending;

    public async Task RunAsync()
    {
        VoiceMetrics.ConnectionOpened();
        Task<JsonElement?>? pendingReceive = null;
        try
        {
            var activation = await ActivateAsync().ConfigureAwait(false);
            if (!activation.Ready)
            {
                return;
            }

            pendingReceive = activation.PendingReceive;
            _callbackWorker = CallbackWorkerAsync();

            while (!_closed)
            {
                var receiveTask = pendingReceive ?? ReceivePayloadAsync(_runtimeCancellation.Token);
                pendingReceive = null;
                if (_callbackWorker is not null)
                {
                    var completed = await Task.WhenAny(receiveTask, _callbackWorker).ConfigureAwait(false);
                    if (completed == _callbackWorker)
                    {
                        await _callbackWorker.ConfigureAwait(false);
                        _callbackWorker = null;
                        if (!_termination.IsTerminating)
                        {
                            throw new InvalidOperationException("The voice callback coordinator stopped unexpectedly.");
                        }
                    }
                }

                var payload = await receiveTask.ConfigureAwait(false);
                if (payload is null)
                {
                    break;
                }

                if (!await DispatchAsync(payload.Value).ConfigureAwait(false))
                {
                    break;
                }
            }
        }
        catch (VoiceBridgeProtocolException exception)
        {
            VoiceMetrics.RecordProtocolViolation(exception.CloseCode);
            await _termination.BeginAsync(
                new VoiceConnectionTerminationRequest("protocol_error", stopRuntime: true),
                CancellationToken.None).ConfigureAwait(false);
            await CloseOutputAsync(exception.CloseCode, "Protocol error").ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (_runtimeCancellation.IsCancellationRequested)
        {
            // Request cancellation and forced terminal cleanup are transport
            // boundaries, not protocol errors.
        }
#pragma warning disable CA1031 // Runtime failures map to a sanitized WebSocket terminal.
        catch (Exception)
#pragma warning restore CA1031
        {
            await _termination.BeginAsync(
                new VoiceConnectionTerminationRequest("internal_error", stopRuntime: true),
                CancellationToken.None).ConfigureAwait(false);
            await CloseOutputAsync(VoiceProtocolConstants.CloseInternalError, "Internal server error").ConfigureAwait(false);
        }
        finally
        {
            try
            {
                if (!_termination.IsTerminating)
                {
                    await _termination.BeginAsync(
                        new VoiceConnectionTerminationRequest("connection_closed", stopRuntime: true),
                        CancellationToken.None).ConfigureAwait(false);
                }

                await _termination.CompleteAsync(DrainTerminationAsync).ConfigureAwait(false);
            }
            finally
            {
                _termination.MarkCompleted();
                VoiceMetrics.ConnectionClosed();
            }
        }
    }

    public async Task SendAsync(
        string messageType,
        IReadOnlyDictionary<string, object?> fields,
        CancellationToken cancellationToken)
    {
        long? firstOutputStarted = null;
        await _sendTransaction.ExecuteAsync(
            new VoiceFramePayload(messageType, fields),
            async transactionCancellation =>
            {
                await _stateGate.WaitAsync(transactionCancellation).ConfigureAwait(false);
                try
                {
                    if (_closed || _termination.IsTerminating)
                    {
                        throw new VoiceBridgeConnectionClosedException("The voice connection is closed.");
                    }

                    if (fields.TryGetValue("response_id", out var value) && value is string responseId &&
                        _termination.IsResponseTerminal(responseId))
                    {
                        throw new VoiceBridgeConnectionClosedException("The voice response is terminal.");
                    }

                    return 0;
                }
                finally
                {
                    _stateGate.Release();
                }
            },
            async _ =>
            {
                await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
                try
                {
                    if (messageType is "response.output_text.delta" or "response.output_text.done" or "response.none" &&
                        fields.TryGetValue("response_id", out var responseIdValue) &&
                        responseIdValue is string responseId &&
                        _responseStartTimestamps.TryGetValue(responseId, out var started) &&
                        _firstOutputRecorded.Add(responseId))
                    {
                        firstOutputStarted = started;
                    }

                    return true;
                }
                finally
                {
                    _stateGate.Release();
                }
            },
            cancellationToken).ConfigureAwait(false);

        if (firstOutputStarted.HasValue)
        {
            VoiceMetrics.RecordFirstOutput(firstOutputStarted.Value);
        }
    }

    public async Task SendResponseFrameAsync(
        VoiceResponse response,
        string messageType,
        IReadOnlyDictionary<string, object?> fields,
        Action commit,
        bool terminal,
        string? terminalKind,
        CancellationToken cancellationToken)
    {
        EnsureReady();
        ArgumentNullException.ThrowIfNull(response);
        ArgumentException.ThrowIfNullOrEmpty(messageType);
        ArgumentNullException.ThrowIfNull(fields);
        ArgumentNullException.ThrowIfNull(commit);
        if (terminal && string.IsNullOrEmpty(terminalKind))
        {
            throw new ArgumentException("A terminal response frame requires a terminal kind.", nameof(terminalKind));
        }

        var opensResponse = !response.IsWireOpened;
        var frames = new List<VoiceFramePayload>(opensResponse ? 2 : 1);
        if (opensResponse)
        {
            var inReplyTo = response.InReplyTo;
            if (inReplyTo is null || inReplyTo.Count == 0)
            {
                throw new InvalidOperationException("A reply response requires a non-empty in_reply_to prefix.");
            }

            frames.Add(new VoiceFramePayload(
                "response.created",
                new Dictionary<string, object?>
                {
                    ["response_id"] = response.ResponseId,
                    ["in_reply_to"] = inReplyTo,
                }));
        }

        frames.Add(new VoiceFramePayload(messageType, fields));
        VoiceResponseTermination responseTermination = default;
        long? firstOutputStarted = null;
        await _sendTransaction.ExecuteAsync(
            frames,
            async transactionCancellation =>
            {
                await _stateGate.WaitAsync(transactionCancellation).ConfigureAwait(false);
                try
                {
                    EnsureReadyLocked();
                    if (_termination.IsResponseTerminal(response.ResponseId))
                    {
                        throw new VoiceBridgeConnectionClosedException("The voice response is terminal.");
                    }

                    if (!_turnLease.IsCurrent(response))
                    {
                        throw new VoiceBridgeConnectionClosedException("The response is no longer active.");
                    }

                    var reservation = response.ReserveSend(opensResponse);
                    if (opensResponse)
                    {
                        var inReplyTo = response.InReplyTo!;
                        ValidatePendingPrefixLocked(inReplyTo);
                        RememberResolvedPrefixLocked(inReplyTo, response, wireOpened: true);
                        ConsumePendingPrefixLocked(inReplyTo);
                    }

                    return reservation;
                }
                finally
                {
                    _stateGate.Release();
                }
            },
            async reservation =>
            {
                await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
                try
                {
                    if (_termination.IsResponseTerminal(response.ResponseId))
                    {
                        return false;
                    }

                    if (!response.TryCommitSend(reservation, commit, terminal))
                    {
                        return false;
                    }

                    if (messageType is "response.output_text.delta" or "response.output_text.done" &&
                        _responseStartTimestamps.TryGetValue(response.ResponseId, out var started) &&
                        _firstOutputRecorded.Add(response.ResponseId))
                    {
                        firstOutputStarted = started;
                    }

                    if (terminal)
                    {
                        responseTermination = _termination.TryTerminateResponse(response, terminalKind!);
                        ForgetResponseTimingLocked(response.ResponseId);
                        RememberResponseLocked(response);
                    }

                    return true;
                }
                finally
                {
                    _stateGate.Release();
                }
            },
            cancellationToken).ConfigureAwait(false);

        if (firstOutputStarted.HasValue)
        {
            VoiceMetrics.RecordFirstOutput(firstOutputStarted.Value);
        }

        if (responseTermination.IsNewTerminal)
        {
            VoiceMetrics.RecordTerminal(responseTermination.TerminalKind);
        }
    }

    public async Task<bool> OpenResponseAsync(
        VoiceResponse response,
        IReadOnlyList<string>? inReplyTo,
        CancellationToken cancellationToken)
    {
        EnsureReady();
        if (inReplyTo is null || inReplyTo.Count == 0)
        {
            throw new InvalidOperationException("A reply response requires a non-empty in_reply_to prefix.");
        }

        var fields = new Dictionary<string, object?>
        {
            ["response_id"] = response.ResponseId,
            ["in_reply_to"] = inReplyTo,
        };
        try
        {
            await _sendTransaction.ExecuteAsync(
                new VoiceFramePayload("response.created", fields),
                async transactionCancellation =>
                {
                    await _stateGate.WaitAsync(transactionCancellation).ConfigureAwait(false);
                    try
                    {
                        EnsureReadyLocked();
                        if (_termination.IsResponseTerminal(response.ResponseId))
                        {
                            throw new VoiceBridgeConnectionClosedException("The voice response is terminal.");
                        }

                        if (!_turnLease.IsCurrent(response))
                        {
                            throw new VoiceBridgeConnectionClosedException("The response is no longer active.");
                        }

                        var reservation = response.ReserveSend(opensResponse: true);
                        ValidatePendingPrefixLocked(inReplyTo);
                        RememberResolvedPrefixLocked(inReplyTo, response, wireOpened: true);
                        ConsumePendingPrefixLocked(inReplyTo);
                        return reservation;
                    }
                    finally
                    {
                        _stateGate.Release();
                    }
                },
                async reservation =>
                {
                    await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
                    try
                    {
                        if (_termination.IsResponseTerminal(response.ResponseId))
                        {
                            return false;
                        }

                        return response.TryCommitSend(reservation, static () => { }, terminal: false);
                    }
                    finally
                    {
                        _stateGate.Release();
                    }
                },
                cancellationToken).ConfigureAwait(false);
            return true;
        }
        catch (VoiceBridgeConnectionClosedException)
        {
            await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
            try
            {
                if (_termination.IsResponseTerminal(response.ResponseId))
                {
                    return false;
                }
            }
            finally
            {
                _stateGate.Release();
            }

            throw;
        }
    }

    public async Task DeclineResponseAsync(
        VoiceResponse response,
        IReadOnlyList<string> inReplyTo,
        string? reason,
        CancellationToken cancellationToken)
    {
        EnsureReady();
        var fields = new Dictionary<string, object?> { ["in_reply_to"] = inReplyTo };
        if (reason is not null)
        {
            fields["reason"] = reason;
        }

        VoiceResponseTermination responseTermination = default;
        long? firstOutputStarted = null;
        await _sendTransaction.ExecuteAsync(
            new VoiceFramePayload("response.none", fields),
            async transactionCancellation =>
            {
                await _stateGate.WaitAsync(transactionCancellation).ConfigureAwait(false);
                try
                {
                    EnsureReadyLocked();
                    if (_termination.IsResponseTerminal(response.ResponseId))
                    {
                        throw new VoiceBridgeConnectionClosedException("The voice response is terminal.");
                    }

                    ValidatePendingPrefixLocked(inReplyTo);
                    RememberResolvedPrefixLocked(inReplyTo, response, wireOpened: false);
                    ConsumePendingPrefixLocked(inReplyTo);
                    return 0;
                }
                finally
                {
                    _stateGate.Release();
                }
            },
            async _ =>
            {
                await response.MarkTerminalAsync().ConfigureAwait(false);
                await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
                try
                {
                    if (_responseStartTimestamps.TryGetValue(response.ResponseId, out var started) &&
                        _firstOutputRecorded.Add(response.ResponseId))
                    {
                        firstOutputStarted = started;
                    }

                    responseTermination = _termination.TryTerminateResponse(response, "none");
                    ForgetResponseTimingLocked(response.ResponseId);
                    RememberResponseLocked(response);

                    return true;
                }
                finally
                {
                    _stateGate.Release();
                }
            },
            cancellationToken).ConfigureAwait(false);
        if (firstOutputStarted.HasValue)
        {
            VoiceMetrics.RecordFirstOutput(firstOutputStarted.Value);
        }

        if (responseTermination.IsNewTerminal)
        {
            VoiceMetrics.RecordTerminal("none");
        }
    }

    public async Task<Task<ResponseCancellationOutcome>> BeginCancelAsync(
        VoiceResponse response,
        string? reason,
        CancellationToken cancellationToken)
    {
        EnsureReady();
        var responseId = response.ResponseId;
        var completion = new TaskCompletionSource<ResponseCancellationOutcome>(TaskCreationOptions.RunContinuationsAsynchronously);
        var fields = new Dictionary<string, object?> { ["response_id"] = responseId };
        if (reason is not null)
        {
            fields["reason"] = reason;
        }

        await _sendTransaction.ExecuteAsync(
            new VoiceFramePayload("response.cancel", fields),
            async transactionCancellation =>
            {
                await _stateGate.WaitAsync(transactionCancellation).ConfigureAwait(false);
                try
                {
                    EnsureReadyLocked();
                    var trackedResponse = FindResponseLocked(responseId);
                    if (!ReferenceEquals(trackedResponse, response) || !response.IsWireOpened)
                    {
                        throw new VoiceBridgeConnectionClosedException("The response is not open.");
                    }

                    if (!_cancelWaiters.TryAdd(responseId, completion))
                    {
                        throw new InvalidOperationException("Response cancellation is already pending.");
                    }

                    try
                    {
                        response.ReserveCancellation();
                    }
                    catch
                    {
                        _cancelWaiters.Remove(responseId);
                        throw;
                    }

                    return 0;
                }
                finally
                {
                    _stateGate.Release();
                }
            },
            static _ => ValueTask.FromResult(true),
            cancellationToken).ConfigureAwait(false);

        return completion.Task;
    }

    public async Task RegisterDtmfCollectionAsync(
        string responseId,
        string collectionId,
        int maxDigits,
        string? terminator,
        int initialTimeoutMs,
        int interDigitTimeoutMs,
        CancellationToken cancellationToken)
    {
        EnsureReady();
        var fields = new Dictionary<string, object?>
        {
            ["response_id"] = responseId,
            ["collection_id"] = collectionId,
            ["max_digits"] = maxDigits,
            ["initial_timeout_ms"] = initialTimeoutMs,
            ["inter_digit_timeout_ms"] = interDigitTimeoutMs,
        };
        if (terminator is not null)
        {
            fields["terminator"] = terminator;
        }

        await _sendTransaction.ExecuteAsync(
            new VoiceFramePayload("dtmf.collect", fields),
            async transactionCancellation =>
            {
                await _stateGate.WaitAsync(transactionCancellation).ConfigureAwait(false);
                try
                {
                    EnsureReadyLocked();
                    if (_dtmfCollections.Count != 0)
                    {
                        throw new InvalidOperationException("Only one DTMF collection may be pending or active.");
                    }

                    var response = FindResponseLocked(responseId);
                    if (response is null || response.IsTerminal)
                    {
                        throw new VoiceBridgeConnectionClosedException("The source response is not open.");
                    }

                    _dtmfCollections.Add(collectionId, responseId);
                    return 0;
                }
                finally
                {
                    _stateGate.Release();
                }
            },
            static _ => ValueTask.FromResult(true),
            cancellationToken).ConfigureAwait(false);
    }

    public async Task CancelDtmfCollectionAsync(string collectionId, CancellationToken cancellationToken)
    {
        EnsureReady();
        await _sendTransaction.ExecuteAsync(
            new VoiceFramePayload(
                "dtmf.collect.cancel",
                new Dictionary<string, object?> { ["collection_id"] = collectionId }),
            async transactionCancellation =>
            {
                await _stateGate.WaitAsync(transactionCancellation).ConfigureAwait(false);
                try
                {
                    EnsureReadyLocked();
                    if (!_dtmfCollections.ContainsKey(collectionId))
                    {
                        throw new InvalidOperationException("Unknown or completed DTMF collection ID.");
                    }

                    if (!_dtmfCancelPending.Add(collectionId))
                    {
                        throw new InvalidOperationException("DTMF collection cancellation is already pending.");
                    }

                    return 0;
                }
                finally
                {
                    _stateGate.Release();
                }
            },
            static _ => ValueTask.FromResult(true),
            cancellationToken).ConfigureAwait(false);
    }

    public async Task EndCallAsync(string reason, string mode, CancellationToken cancellationToken)
    {
        EnsureReady();
        var fields = new Dictionary<string, object?> { ["reason"] = reason, ["mode"] = mode };
        await _sendTransaction.ExecuteAsync(
            new VoiceFramePayload("end_call", fields),
            async transactionCancellation =>
            {
                var outcome = await _termination.BeginAsync(
                    new VoiceConnectionTerminationRequest("end_call", stopRuntime: false),
                    transactionCancellation).ConfigureAwait(false);
                if (!outcome.IsWinner)
                {
                    // A different terminal already won connection arbitration.
                    // Do not emit a second terminal frame; abort the reservation
                    // before any wire write.
                    throw new VoiceBridgeConnectionClosedException("The voice session is already ending.");
                }

                return 0;
            },
            static _ => ValueTask.FromResult(true),
            cancellationToken).ConfigureAwait(false);
    }

    public async Task<VoiceResponse> StartProactiveResponseAsync(
        int admissionTimeoutMs,
        string? supersedeKey,
        CancellationToken cancellationToken)
    {
        EnsureReady();
        var response = new VoiceResponse(
            this,
            VoiceIds.New(VoiceProtocolConstants.ResponsePrefix),
            inReplyTo: null,
            wireOpened: true,
            accepted: false,
            _runtimeCancellation.Token);
        var completion = new TaskCompletionSource<ProactiveOutcome>(TaskCreationOptions.RunContinuationsAsynchronously);
        var fields = new Dictionary<string, object?>
        {
            ["response_id"] = response.ResponseId,
            ["admission_timeout_ms"] = admissionTimeoutMs,
        };
        if (supersedeKey is not null)
        {
            fields["supersede_key"] = supersedeKey;
        }

        await _sendTransaction.ExecuteAsync(
            new VoiceFramePayload("response.created", fields),
            async transactionCancellation =>
            {
                await _stateGate.WaitAsync(transactionCancellation).ConfigureAwait(false);
                try
                {
                    EnsureReadyLocked();
                    if (_pendingProactive.Count >= VoiceProtocolConstants.MaxPendingProactive)
                    {
                        throw new InvalidOperationException("Too many proactive admission outcomes are pending.");
                    }

                    AddSeenResponseIdLocked(response.ResponseId);
                    _pendingProactive.Add(response.ResponseId, new PendingProactive(response, completion));
                    return 0;
                }
                finally
                {
                    _stateGate.Release();
                }
            },
            static _ => ValueTask.FromResult(true),
            cancellationToken).ConfigureAwait(false);

        ProactiveOutcome outcome;
        try
        {
            outcome = await completion.Task.WaitAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
            try
            {
                _abandonedProactiveCancels.Add(response.ResponseId);
            }
            finally
            {
                _stateGate.Release();
            }

            try
            {
                await SendAsync(
                    "response.cancel",
                    new Dictionary<string, object?>
                    {
                        ["response_id"] = response.ResponseId,
                        ["reason"] = "cancelled_by_agent",
                    },
                    CancellationToken.None).ConfigureAwait(false);
            }
            catch (VoiceBridgeConnectionClosedException)
            {
            }

            throw;
        }

        if (!outcome.Accepted)
        {
            await response.MarkTerminalAsync().ConfigureAwait(false);
            throw new VoiceProactiveResponseDroppedException(response.ResponseId, outcome.Reason);
        }

        return response;
    }

    public async Task ReportSessionErrorAsync(string code, string message, CancellationToken cancellationToken)
    {
        EnsureReady();
        var fields = new Dictionary<string, object?> { ["code"] = code, ["message"] = message };
        await _sendTransaction.ExecuteAsync(
            new VoiceFramePayload("error", fields),
            async transactionCancellation =>
            {
                var outcome = await _termination.BeginAsync(
                    new VoiceConnectionTerminationRequest("session_error", stopRuntime: false),
                    transactionCancellation).ConfigureAwait(false);
                if (!outcome.IsWinner)
                {
                    // A different terminal already won connection arbitration.
                    // Do not emit a second terminal frame; abort the reservation
                    // before any wire write.
                    throw new VoiceBridgeConnectionClosedException("The voice session is already ending.");
                }

                return 0;
            },
            static _ => ValueTask.FromResult(true),
            cancellationToken).ConfigureAwait(false);
    }

    private async Task<ActivationResult> ActivateAsync()
    {
        JsonElement? payload;
        try
        {
            payload = await ReceivePayloadAsync(_connectionCancellationToken).ConfigureAwait(false);
        }
        catch (VoiceBridgeProtocolException exception)
        {
            await RejectAsync("invalid_session_start", exception.CloseCode).ConfigureAwait(false);
            return ActivationResult.NotReady;
        }

        if (payload is null)
        {
            RecordActivation("closed");
            return ActivationResult.NotReady;
        }

        if (VoiceProtocolCodec.GetMessageType(payload.Value) != "session.start")
        {
            await RejectAsync("invalid_session_start", VoiceProtocolConstants.CloseProtocolError).ConfigureAwait(false);
            return ActivationResult.NotReady;
        }

        SessionStartEvent startEvent;
        try
        {
            startEvent = VoiceProtocolCodec.ParseSessionStart(payload.Value);
        }
        catch (VoiceBridgeProtocolException exception)
        {
            var code = payload.Value.TryGetProperty("protocol_version", out var version) &&
                version.ValueKind == JsonValueKind.String &&
                version.GetString() != VoiceProtocolConstants.ProtocolVersion
                    ? "protocol_mismatch"
                    : "invalid_session_start";
            await RejectAsync(code, exception.CloseCode).ConfigureAwait(false);
            return ActivationResult.NotReady;
        }

        _session = new VoiceSession(this, startEvent);
        using var startupCancellation = CancellationTokenSource.CreateLinkedTokenSource(_runtimeCancellation.Token);
        var pendingReceive = ReceivePayloadAsync(_runtimeCancellation.Token);

        // Wrap the customer startup callback so a synchronous throw or a null
        // task surfaces as a faulted task rather than escaping activation and
        // being mapped to an internal-error close; startup failure must emit
        // terminal session.rejected.
        var startupTask = InvokeCustomerCallback(
            () => _handler.InvokeSessionStartAsync(_session, startEvent, startupCancellation.Token));
        var completed = await Task.WhenAny(startupTask, pendingReceive).ConfigureAwait(false);

        // If both completed concurrently, an application frame was observable
        // before readiness and therefore wins the activation protocol check.
        if (completed == pendingReceive || pendingReceive.IsCompleted)
        {
            startupCancellation.Cancel();
            if (!startupTask.IsCompleted)
            {
                TrackCleanup(startupTask);
            }
            else
            {
                await ObserveTaskAsync(startupTask).ConfigureAwait(false);
            }

            await RejectEarlyFrameAsync(pendingReceive).ConfigureAwait(false);
            return ActivationResult.NotReady;
        }

        try
        {
            await startupTask.ConfigureAwait(false);
        }
#pragma warning disable CA1031 // Customer startup failures map to a sanitized rejection.
        catch (Exception)
#pragma warning restore CA1031
        {
            await RejectAsync("startup_failed", VoiceProtocolConstants.CloseInternalError).ConfigureAwait(false);
            return ActivationResult.NotReady;
        }

        // The startup callback and an already-buffered peer frame may complete
        // on adjacent continuations. Yield once, then arbitrate again before the
        // readiness write so a frame sent while startup was pending cannot ride
        // through as the first post-ready application frame.
        await Task.Yield();
        if (pendingReceive.IsCompleted)
        {
            await RejectEarlyFrameAsync(pendingReceive).ConfigureAwait(false);
            return ActivationResult.NotReady;
        }

        // Final arbitration happens inside the readiness reservation, while the
        // send gate is held immediately before the wire write, so a frame that
        // raced in after the check above cannot ride through as the first
        // post-ready application frame. If one did, abort the readiness write
        // (no session.ready reaches the wire) and reject the leg.
        var earlyFrameBeforeReady = false;
        try
        {
            await _sendTransaction.ExecuteAsync(
                new VoiceFramePayload("session.ready", new Dictionary<string, object?>()),
                _ =>
                {
                    if (pendingReceive.IsCompleted)
                    {
                        earlyFrameBeforeReady = true;
                        throw new ActivationAbortedException();
                    }

                    return ValueTask.FromResult(0);
                },
                async _ =>
                {
                    await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
                    try
                    {
                        _ready = true;
                        return true;
                    }
                    finally
                    {
                        _stateGate.Release();
                    }
                },
                _connectionCancellationToken).ConfigureAwait(false);
        }
        catch (ActivationAbortedException)
        {
        }

        if (earlyFrameBeforeReady)
        {
            await RejectEarlyFrameAsync(pendingReceive).ConfigureAwait(false);
            return ActivationResult.NotReady;
        }

        RecordActivation("ready");
        return new ActivationResult(true, pendingReceive);
    }

    private async Task RejectEarlyFrameAsync(Task<JsonElement?> pendingReceive)
    {
        try
        {
            var earlyPayload = await pendingReceive.ConfigureAwait(false);
            if (earlyPayload is not null)
            {
                await RejectAsync("protocol_mismatch", VoiceProtocolConstants.ClosePolicyViolation).ConfigureAwait(false);
            }
        }
        catch (VoiceBridgeProtocolException exception)
        {
            await RejectAsync("protocol_mismatch", exception.CloseCode).ConfigureAwait(false);
        }
    }

    private sealed class ActivationAbortedException : Exception
    {
    }

    private async Task<bool> DispatchAsync(JsonElement payload)
    {
        var messageType = VoiceProtocolCodec.GetMessageType(payload);
        switch (messageType)
        {
            case "user.message":
                var userMessage = VoiceProtocolCodec.ParseUserMessage(payload);
                await EnqueueTurnAsync(
                    userMessage.ItemId,
                    userMessage,
                    "user.message",
                    (session, response, cancellationToken) =>
                        _handler.InvokeUserMessageAsync(session, userMessage, response, cancellationToken),
                    payload).ConfigureAwait(false);
                break;
            case "user.no_input":
                var noInput = VoiceProtocolCodec.ParseUserNoInput(payload);
                await EnqueueTurnAsync(
                    noInput.ItemId,
                    noInput,
                    "user.no_input",
                    (session, response, cancellationToken) =>
                        _handler.InvokeUserNoInputAsync(session, noInput, response, cancellationToken),
                    payload).ConfigureAwait(false);
                break;
            case "user.speech_started":
                var speechStarted = new UserSpeechStartedEvent();
                await EnqueueSignalAsync(
                    speechStarted,
                    "user.speech_started",
                    (session, cancellationToken) =>
                        _handler.InvokeUserSpeechStartedAsync(session, speechStarted, cancellationToken),
                    payload).ConfigureAwait(false);
                break;
            case "conversation.item.create":
                var create = VoiceProtocolCodec.ParseConversationItemCreate(payload);
                await EnqueueHistoryAsync(
                    create,
                    create.RequestId,
                    "conversation.item.create",
                    "conversation.item.created",
                    (session, cancellationToken) =>
                        _handler.InvokeConversationItemCreateAsync(session, create, cancellationToken),
                    payload).ConfigureAwait(false);
                break;
            case "conversation.item.delete":
                var delete = VoiceProtocolCodec.ParseConversationItemDelete(payload);
                await EnqueueHistoryAsync(
                    delete,
                    delete.RequestId,
                    "conversation.item.delete",
                    "conversation.item.deleted",
                    (session, cancellationToken) =>
                        _handler.InvokeConversationItemDeleteAsync(session, delete, cancellationToken),
                    payload).ConfigureAwait(false);
                break;
            case "dtmf":
                var dtmf = VoiceProtocolCodec.ParseDtmf(payload);
                if (dtmf is DtmfKeyEvent key)
                {
                    await EnqueueSignalAsync(
                        key,
                        "dtmf.key",
                        (session, cancellationToken) =>
                            _handler.InvokeDtmfKeyAsync(session, key, cancellationToken),
                        payload).ConfigureAwait(false);
                }
                else
                {
                    var collected = (DtmfCollectedEvent)dtmf;
                    await ConsumeDtmfCollectionAsync(collected.CollectionId, preserveCancelRace: true).ConfigureAwait(false);
                    await EnqueueTurnAsync(
                        collected.ItemId,
                        collected,
                        "dtmf.collected",
                        (session, response, cancellationToken) =>
                            _handler.InvokeDtmfCollectedAsync(session, collected, response, cancellationToken),
                        payload).ConfigureAwait(false);
                }

                break;
            case "dtmf.collect.rejected":
                var rejected = VoiceProtocolCodec.ParseDtmfCollectionRejected(payload);
                await ConsumeDtmfCollectionAsync(
                    rejected.CollectionId,
                    allowLateCancelRejection: rejected.Reason == "collection_not_found",
                    preserveCancelRace: rejected.Reason != "collection_not_found").ConfigureAwait(false);
                await EnqueueSignalAsync(
                    rejected,
                    "dtmf.collect.rejected",
                    (session, cancellationToken) =>
                        _handler.InvokeDtmfCollectionRejectedAsync(session, rejected, cancellationToken),
                    payload).ConfigureAwait(false);
                break;
            case "dtmf.collect.cancelled":
                var cancelled = VoiceProtocolCodec.ParseDtmfCollectionCancelled(payload);
                await ConsumeDtmfCollectionAsync(
                    cancelled.CollectionId,
                    preserveCancelRace: cancelled.Reason != "cancelled_by_agent").ConfigureAwait(false);
                await EnqueueSignalAsync(
                    cancelled,
                    "dtmf.collect.cancelled",
                    (session, cancellationToken) =>
                        _handler.InvokeDtmfCollectionCancelledAsync(session, cancelled, cancellationToken),
                    payload).ConfigureAwait(false);
                break;
            case "handoff.failed":
                var handoff = VoiceProtocolCodec.ParseHandoffFailed(payload);
                await EnqueueTurnAsync(
                    handoff.ItemId,
                    handoff,
                    "handoff.failed",
                    (session, response, cancellationToken) =>
                        _handler.InvokeHandoffFailedAsync(session, handoff, response, cancellationToken),
                    payload).ConfigureAwait(false);
                break;
            case "barge_in":
                await HandleBargeInAsync(VoiceProtocolCodec.ParseBargeIn(payload), payload).ConfigureAwait(false);
                break;
            case "response.cancelled":
                await HandlePlaybackTerminalAsync(VoiceProtocolCodec.ParseResponseCancelled(payload)).ConfigureAwait(false);
                break;
            case "response.timeout":
                await HandleResponseTimeoutAsync(VoiceProtocolCodec.ParseResponseTimeout(payload), payload).ConfigureAwait(false);
                break;
            case "response.accepted":
                await HandleResponseAcceptedAsync(VoiceProtocolCodec.ParseResponseId(payload)).ConfigureAwait(false);
                break;
            case "response.dropped":
                await HandleResponseDroppedAsync(
                    VoiceProtocolCodec.ParseResponseId(payload),
                    VoiceProtocolCodec.ParseReason(payload)).ConfigureAwait(false);
                break;
            case "session.end":
                await HandleSessionEndAsync(VoiceProtocolCodec.ParseSessionEnd(payload)).ConfigureAwait(false);
                return false;
            default:
                if (messageType == "session.start" || AgentToBridgeMessageTypes.Contains(messageType))
                {
                    throw new VoiceBridgeProtocolException(
                        $"{messageType} is not valid from the bridge after readiness.",
                        VoiceProtocolConstants.ClosePolicyViolation);
                }

                // Unknown future message types are ignored after readiness.
                break;
        }

        return true;
    }

    private async Task EnqueueTurnAsync<TEvent>(
        string itemId,
        TEvent @event,
        string kind,
        Func<VoiceSession, VoiceResponse, CancellationToken, Task> callback,
        JsonElement payload)
    {
        _ = @event;
        var response = new VoiceResponse(
            this,
            VoiceIds.New(VoiceProtocolConstants.ResponsePrefix),
            new[] { itemId },
            wireOpened: false,
            accepted: true,
            _runtimeCancellation.Token);

        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (_ending)
            {
                throw new VoiceBridgeProtocolException(
                    $"{kind} arrived after the session terminal.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            var itemIdDigest = HashText(itemId);
            if (!_seenInputIdDigests.Add(itemIdDigest))
            {
                throw new VoiceBridgeProtocolException(
                    "Input item_id was reused.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            if (_seenInputIdDigests.Count > MaxTrackedIds)
            {
                throw new VoiceBridgeProtocolException(
                    "Input item tracking limit exceeded.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            AddSeenResponseIdLocked(response.ResponseId);
            _pendingTurns.Add(itemId, response);
            _pendingTurnOrder.AddLast(itemId);
            _responseStartTimestamps[response.ResponseId] = Stopwatch.GetTimestamp();
        }
        finally
        {
            _stateGate.Release();
        }

        var estimatedBytes = EstimatePayloadBytes(payload);
        EnqueueWork(new CallbackWork(
            kind,
            estimatedBytes,
            cancellationToken => callback(_session!, response, cancellationToken),
            response,
            itemId));
    }

    private Task EnqueueSignalAsync<TEvent>(
        TEvent @event,
        string kind,
        Func<VoiceSession, CancellationToken, Task> callback,
        JsonElement payload)
    {
        _ = @event;
        EnqueueWork(new CallbackWork(
            kind,
            EstimatePayloadBytes(payload),
            cancellationToken => callback(_session!, cancellationToken)));
        return Task.CompletedTask;
    }

    private Task EnqueueHistoryAsync<TEvent>(
        TEvent @event,
        string requestId,
        string kind,
        string successType,
        Func<VoiceSession, CancellationToken, Task> callback,
        JsonElement payload)
    {
        _ = @event;
        EnqueueWork(new CallbackWork(
            kind,
            EstimatePayloadBytes(payload),
            cancellationToken => callback(_session!, cancellationToken),
            RequestId: requestId,
            SuccessType: successType));
        return Task.CompletedTask;
    }

    private void EnqueueWork(CallbackWork work)
    {
        var queuedBytes = Interlocked.Add(ref _queuedCallbackBytes, work.EstimatedBytes);
        if (queuedBytes > MaxCallbackQueueBytes)
        {
            Interlocked.Add(ref _queuedCallbackBytes, -work.EstimatedBytes);
            throw new VoiceBridgeProtocolException(
                "Voice callback queue byte limit exceeded.",
                VoiceProtocolConstants.ClosePolicyViolation);
        }

        if (!_callbackQueue.Writer.TryWrite(work))
        {
            Interlocked.Add(ref _queuedCallbackBytes, -work.EstimatedBytes);
            throw new VoiceBridgeProtocolException(
                "Voice callback queue limit exceeded.",
                VoiceProtocolConstants.ClosePolicyViolation);
        }
    }

    private async Task CallbackWorkerAsync()
    {
        try
        {
            await foreach (var work in _callbackQueue.Reader.ReadAllAsync(_runtimeCancellation.Token).ConfigureAwait(false))
            {
                Interlocked.Add(ref _queuedCallbackBytes, -work.EstimatedBytes);
                if (_sessionEndSignal.Task.IsCompleted)
                {
                    continue;
                }

                if (work.Response is not null)
                {
                    await ProcessTurnWorkAsync(work).ConfigureAwait(false);
                }
                else
                {
                    await ProcessSignalWorkAsync(work).ConfigureAwait(false);
                }
            }
        }
        catch (OperationCanceledException) when (_runtimeCancellation.IsCancellationRequested)
        {
        }
        finally
        {
            DrainQueuedCallbackWork();
            var sessionEnd = _sessionEndEvent;
            if (sessionEnd is not null)
            {
                await ProcessSessionEndCallbackAsync(sessionEnd).ConfigureAwait(false);
            }
        }
    }

    private async Task ProcessTurnWorkAsync(CallbackWork work)
    {
        var callbackStarted = Stopwatch.GetTimestamp();
        var callbackFailed = false;
        var response = work.Response!;
        if (response.IsTerminal)
        {
            return;
        }

        var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        VoiceTurnActivation activation = default;
        Activity? turnActivity = null;
        while (true)
        {
            Task? activeResponseWait = null;
            await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
            try
            {
                if (response.IsTerminal || _ending)
                {
                    return;
                }

                var current = _turnLease.Current;
                if (current is null)
                {
                    turnActivity = InvocationsTelemetry.ActivitySource.StartActivity(
                        "hosted_agent.turn",
                        ActivityKind.Internal,
                        _connectionActivityContext,
                        tags: new ActivityTagsCollection
                        {
                            ["gen_ai.response.id"] = response.ResponseId,
                            ["voice.callback.kind"] = work.Kind,
                        });
                    try
                    {
                        activation = _turnLease.Activate(response, work.Kind, release, turnActivity);
                    }
                    catch
                    {
                        StopDetachedTurnActivity(turnActivity, "activation_failed");
                        throw;
                    }
                }
                else
                {
                    activeResponseWait = current.Completion;
                }
            }
            finally
            {
                _stateGate.Release();
            }

            if (activeResponseWait is null)
            {
                break;
            }

            var available = await Task.WhenAny(activeResponseWait, _sessionEndSignal.Task).ConfigureAwait(false);
            if (available == _sessionEndSignal.Task)
            {
                return;
            }
        }

        var customerTask = InvokeCustomerCallback(() => work.Callback(response.CancellationToken));
        if (!_turnLease.TrySetCustomerTask(activation.Token, customerTask))
        {
            TrackCleanup(customerTask);
        }

        try
        {
            var completed = await Task.WhenAny(customerTask, release.Task).ConfigureAwait(false);
            if (completed == release.Task && !customerTask.IsCompleted)
            {
                if (!_sessionEndSignal.Task.IsCompleted)
                {
                    try
                    {
                        var remaining = _cleanupDeadline.Remaining;
                        if (remaining > TimeSpan.Zero)
                        {
                            await response.DrainPendingSendAsync()
                                .WaitAsync(remaining)
                                .ConfigureAwait(false);
                        }
                    }
                    catch (TimeoutException)
                    {
                    }
                }

                TrackCleanup(customerTask);
            }
            else
            {
                try
                {
                    await customerTask.ConfigureAwait(false);
                    await response.CompleteCallbackAsync(_runtimeCancellation.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException) when (response.IsTerminal || Ending)
                {
                }
                catch (VoiceBridgeConnectionClosedException) when (response.IsTerminal || Ending)
                {
                }
#pragma warning disable CA1031 // Customer callback failures become a sanitized response error.
                catch (Exception)
#pragma warning restore CA1031
                {
                    callbackFailed = true;
                    turnActivity?.SetStatus(ActivityStatusCode.Error);
                    turnActivity?.SetTag("error.type", "callback_error");
                    await response.FailCallbackAsync(_runtimeCancellation.Token).ConfigureAwait(false);
                }
            }
        }
        finally
        {
            _turnLease.ClearCustomerTask(activation.Token, customerTask);
            await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
            try
            {
                if (work.ItemId is not null)
                {
                    RemovePendingTurnLocked(work.ItemId);
                }

                if (response.IsWireOpened)
                {
                    RememberResponseLocked(response);
                }
            }
            finally
            {
                _stateGate.Release();
            }

            VoiceMetrics.RecordCallback(work.Kind, callbackStarted, callbackFailed);
            turnActivity?.SetTag("voice.turn.status", response.IsTerminal ? "terminal" : "completed");
        }
    }

    private async Task ProcessSignalWorkAsync(CallbackWork work)
    {
        var callbackStarted = Stopwatch.GetTimestamp();
        var callbackFailed = false;
        var customerTask = InvokeCustomerCallback(() => work.Callback(_runtimeCancellation.Token));
        await Task.WhenAny(customerTask, _sessionEndSignal.Task).ConfigureAwait(false);
        if (_sessionEndSignal.Task.IsCompleted)
        {
            if (customerTask.IsCompleted)
            {
                await ObserveTaskAsync(customerTask).ConfigureAwait(false);
            }
            else
            {
                TrackCleanup(customerTask);
            }

            VoiceMetrics.RecordCallback(work.Kind, callbackStarted, failed: false);
            return;
        }

        if (work.SuccessType is not null)
        {
            bool customerFailed;
            try
            {
                await customerTask.ConfigureAwait(false);
                customerFailed = false;
            }
#pragma warning disable CA1031 // History callback failures become a sanitized mutation result.
            catch (Exception)
#pragma warning restore CA1031
            {
                customerFailed = true;
            }

            // The customer callback outcome — not a transport failure — decides
            // whether the mutation succeeded. Emit the correlated result, but
            // treat a terminal/closed connection while sending it as an expected
            // teardown race rather than a callback failure or a worker fault.
            var resultType = customerFailed ? "conversation.item.failed" : work.SuccessType;
            var resultFields = customerFailed
                ? new Dictionary<string, object?>
                {
                    ["request_id"] = work.RequestId,
                    ["code"] = "mutation_failed",
                    ["message"] = "History mutation callback failed",
                }
                : new Dictionary<string, object?> { ["request_id"] = work.RequestId };
            try
            {
                await SendAsync(resultType, resultFields, _runtimeCancellation.Token).ConfigureAwait(false);
            }
            catch (VoiceBridgeConnectionClosedException)
            {
                // The connection terminated before the mutation result could be
                // delivered. Later frames are dropped by contract during teardown.
            }

            callbackFailed = customerFailed;
            VoiceMetrics.RecordCallback(work.Kind, callbackStarted, callbackFailed);

            return;
        }

        try
        {
            await customerTask.ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (_runtimeCancellation.IsCancellationRequested)
        {
        }
#pragma warning disable CA1031 // Signal callback failures do not fail the protocol connection.
        catch (Exception)
#pragma warning restore CA1031
        {
            callbackFailed = true;
        }

        VoiceMetrics.RecordCallback(work.Kind, callbackStarted, callbackFailed);
    }

    private async Task HandleBargeInAsync(BargeInEvent bargeIn, JsonElement payload)
    {
        var outcome = new ResponseCancellationOutcome(
            bargeIn.ResponseId,
            "barge_in",
            bargeIn.HeardText,
            bargeIn.ItemId);
        var dispatch = await HandlePlaybackTerminalCoreAsync(outcome).ConfigureAwait(false);
        if (dispatch)
        {
            await EnqueueSignalAsync(
                bargeIn,
                "barge_in",
                (session, cancellationToken) =>
                    _handler.InvokeBargeInAsync(session, bargeIn, cancellationToken),
                payload).ConfigureAwait(false);
        }
    }

    private Task HandlePlaybackTerminalAsync(ResponseCancellationOutcome outcome) =>
        HandlePlaybackTerminalCoreAsync(outcome);

    private async Task<bool> HandlePlaybackTerminalCoreAsync(ResponseCancellationOutcome outcome)
    {
        VoiceResponse response;
        TaskCompletionSource<ResponseCancellationOutcome>? waiter;
        VoiceResponseTermination termination;
        var abandoned = false;

        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (_playbackOutcomes.Contains(outcome.ResponseId))
            {
                return false;
            }

            response = FindResponseLocked(outcome.ResponseId)!;
            if (response is null)
            {
                if (_pendingProactive.ContainsKey(outcome.ResponseId))
                {
                    throw new VoiceBridgeProtocolException(
                        $"{outcome.Kind} is invalid before proactive response.accepted.",
                        VoiceProtocolConstants.ClosePolicyViolation);
                }

                if (_seenResponseIds.Contains(outcome.ResponseId))
                {
                    return false;
                }

                throw new VoiceBridgeProtocolException(
                    "Unknown playback response_id.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }
            if (outcome.ItemId is not null && !response.OwnsItem(outcome.ItemId))
            {
                throw new VoiceBridgeProtocolException(
                    "Playback item_id does not belong to response_id.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            _playbackOutcomes.Add(outcome.ResponseId);
            _cancelWaiters.Remove(outcome.ResponseId, out waiter);
            abandoned = _abandonedProactiveCancels.Remove(outcome.ResponseId);
            if (outcome.Kind == "cancelled" && waiter is null && !abandoned)
            {
                _playbackOutcomes.Remove(outcome.ResponseId);
                throw new VoiceBridgeProtocolException(
                    "response.cancelled requires a pending response.cancel.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            termination = _termination.TryTerminateResponse(response, outcome.Kind);
            ForgetResponseTimingLocked(outcome.ResponseId);
        }
        finally
        {
            _stateGate.Release();
        }

        waiter?.TrySetResult(outcome);
        await response.MarkTerminalAsync().ConfigureAwait(false);
        if (termination.IsNewTerminal)
        {
            VoiceMetrics.RecordTerminal(outcome.Kind);
        }

        return true;
    }

    private async Task HandleResponseTimeoutAsync(ResponseTimeoutEvent timeout, JsonElement payload)
    {
        var responses = new List<VoiceResponse>();
        var terminations = new List<VoiceResponseTermination>();
        TaskCompletionSource<ResponseCancellationOutcome>? cancelWaiter = null;

        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (timeout.ResponseId is not null)
            {
                if (_playbackOutcomes.Contains(timeout.ResponseId))
                {
                    return;
                }

                var response = FindResponseLocked(timeout.ResponseId);
                if (response is null)
                {
                    if (_seenResponseIds.Contains(timeout.ResponseId))
                    {
                        return;
                    }

                    throw new VoiceBridgeProtocolException(
                        "Unknown response.timeout response_id.",
                        VoiceProtocolConstants.ClosePolicyViolation);
                }

                responses.Add(response);
                _playbackOutcomes.Add(timeout.ResponseId);
                terminations.Add(_termination.TryTerminateResponse(response, "timeout"));
                ForgetResponseTimingLocked(timeout.ResponseId);

                _cancelWaiters.Remove(timeout.ResponseId, out cancelWaiter);
            }
            else
            {
                ResolveTimeoutInputBatchLocked(
                    timeout.ItemIds!,
                    responses,
                    terminations,
                    ref cancelWaiter);
            }
        }
        finally
        {
            _stateGate.Release();
        }

        foreach (var response in responses.Distinct())
        {
            await response.MarkTerminalAsync().ConfigureAwait(false);
        }

        cancelWaiter?.TrySetException(new VoiceBridgeConnectionClosedException("Response terminated by timeout."));
        foreach (var termination in terminations)
        {
            if (termination.IsNewTerminal)
            {
                VoiceMetrics.RecordTerminal("timeout");
            }
        }

        await EnqueueSignalAsync(
            timeout,
            "response.timeout",
            (session, cancellationToken) =>
                _handler.InvokeResponseTimeoutAsync(session, timeout, cancellationToken),
            payload).ConfigureAwait(false);
    }

    private async Task HandleResponseAcceptedAsync(string responseId)
    {
        PendingProactive pending;
        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (_ending)
            {
                throw new VoiceBridgeProtocolException(
                    "A proactive response was accepted after the session terminal.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            if (!_pendingProactive.Remove(responseId, out pending!))
            {
                throw new VoiceBridgeProtocolException(
                    "Unknown proactive response_id.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            if (_turnLease.Current is not null)
            {
                throw new VoiceBridgeProtocolException(
                    "A proactive response was accepted while another response was active.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            var proactiveTurnActivity = StartDetachedTurnActivity(responseId, "proactive");
            try
            {
                _turnLease.Activate(
                    pending.Response,
                    "proactive",
                    release: null,
                    proactiveTurnActivity);
            }
            catch
            {
                StopDetachedTurnActivity(proactiveTurnActivity, "activation_failed");
                throw;
            }

            _responseStartTimestamps[responseId] = Stopwatch.GetTimestamp();

            // Mark accepted and resolve the admission waiter while still holding
            // the state gate, atomically with the lease activation. This closes
            // the race where a concurrent connection terminal could capture and
            // terminalize the freshly activated response after it was removed
            // from _pendingProactive, which would otherwise strand the awaiting
            // StartProactiveResponseAsync caller. The completion uses
            // RunContinuationsAsynchronously, so it does not run continuations
            // inline under the lock.
            try
            {
                pending.Response.MarkAccepted();
            }
            catch (Exception markException)
            {
                // The awaiter must observe an outcome rather than hang; propagate.
                pending.Completion.TrySetException(markException);
                throw;
            }

            pending.Completion.TrySetResult(new ProactiveOutcome(true, string.Empty));
        }
        finally
        {
            _stateGate.Release();
        }
    }

    private async Task HandleResponseDroppedAsync(string responseId, string reason)
    {
        PendingProactive pending;
        VoiceResponseTermination termination;
        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (!_pendingProactive.Remove(responseId, out pending!))
            {
                throw new VoiceBridgeProtocolException(
                    "Unknown proactive response_id.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            _abandonedProactiveCancels.Remove(responseId);
            termination = _termination.TryTerminateResponse(pending.Response, "dropped");
            ForgetResponseTimingLocked(responseId);
        }
        finally
        {
            _stateGate.Release();
        }

        await pending.Response.MarkTerminalAsync().ConfigureAwait(false);
        if (termination.IsNewTerminal)
        {
            VoiceMetrics.RecordTerminal("dropped");
        }

        pending.Completion.TrySetResult(new ProactiveOutcome(false, VoiceValidation.SafeCode(reason, "dropped")));
    }

    private async Task HandleSessionEndAsync(SessionEndEvent sessionEnd)
    {
        await _termination.BeginAsync(
            new VoiceConnectionTerminationRequest(
                "session_end",
                stopRuntime: true,
                sessionEnd),
            _runtimeCancellation.Token).ConfigureAwait(false);
    }

    private async Task ConsumeDtmfCollectionAsync(
        string collectionId,
        bool allowLateCancelRejection = false,
        bool preserveCancelRace = false)
    {
        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (!_dtmfCollections.Remove(collectionId))
            {
                if (allowLateCancelRejection && _recentDtmfCancelRaces.Remove(collectionId))
                {
                    _recentDtmfCancelRaceOrder.Remove(collectionId);
                    return;
                }

                throw new VoiceBridgeProtocolException(
                    "Unknown DTMF collection_id.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            var cancelPending = _dtmfCancelPending.Remove(collectionId);
            if (cancelPending && preserveCancelRace)
            {
                _recentDtmfCancelRaces.Add(collectionId);
                _recentDtmfCancelRaceOrder.AddLast(collectionId);
                while (_recentDtmfCancelRaceOrder.Count > MaxRecentResponses)
                {
                    var oldest = _recentDtmfCancelRaceOrder.First!.Value;
                    _recentDtmfCancelRaceOrder.RemoveFirst();
                    _recentDtmfCancelRaces.Remove(oldest);
                }
            }
        }
        finally
        {
            _stateGate.Release();
        }
    }

    private async Task<JsonElement?> ReceivePayloadAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            var frame = await ReceiveTextFrameAsync(cancellationToken).ConfigureAwait(false);
            if (frame is null)
            {
                _closed = true;
                return null;
            }

            var payload = VoiceProtocolCodec.DecodeFrame(frame);
            var messageId = payload.GetProperty("id").GetString()!;
            var messageKey = HashText(messageId);
            var digest = VoiceProtocolCodec.ComputeCanonicalDigest(payload);
            if (_seenMessages.TryGetValue(messageKey, out var previous))
            {
                if (!string.Equals(previous, digest, StringComparison.Ordinal))
                {
                    throw new VoiceBridgeProtocolException(
                        "Message id was reused with different content.",
                        VoiceProtocolConstants.ClosePolicyViolation);
                }

                continue;
            }

            if (_seenMessages.Count >= VoiceProtocolConstants.MaxSeenMessages)
            {
                throw new VoiceBridgeProtocolException(
                    "Message dedupe limit exceeded.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            _seenMessages.Add(messageKey, digest);
            return payload;
        }
    }

    private async Task<string?> ReceiveTextFrameAsync(CancellationToken cancellationToken)
    {
        var buffer = new byte[4096];
        using var stream = new MemoryStream();
        while (true)
        {
            WebSocketReceiveResult received;
            try
            {
                received = await _webSocket.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                return null;
            }
            catch (WebSocketException)
            {
                RecordCloseCode(1006);
                return null;
            }
            catch (IOException)
            {
                RecordCloseCode(1006);
                return null;
            }

            if (received.MessageType == WebSocketMessageType.Close)
            {
                RecordCloseCode((int?)_webSocket.CloseStatus ?? VoiceProtocolConstants.CloseNormal);
                return null;
            }

            if (received.MessageType == WebSocketMessageType.Binary)
            {
                throw new VoiceBridgeProtocolException(
                    "Binary frames are not supported.",
                    VoiceProtocolConstants.CloseUnsupportedData);
            }

            if (stream.Length + received.Count > VoiceProtocolConstants.MaxFrameBytes)
            {
                throw new VoiceBridgeProtocolException(
                    "Voice bridge frame exceeds the maximum size.",
                    VoiceProtocolConstants.CloseMessageTooBig);
            }

            stream.Write(buffer, 0, received.Count);
            if (received.EndOfMessage)
            {
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }

    private async Task RejectAsync(string code, int closeCode)
    {
        if (_closed)
        {
            return;
        }

        RecordActivation(code);
        try
        {
            await _sendTransaction.SendAsync(
                "session.rejected",
                new Dictionary<string, object?>
                {
                    ["code"] = VoiceValidation.SafeCode(code, "startup_failed"),
                    ["retriable"] = false,
                },
                CancellationToken.None).ConfigureAwait(false);
        }
#pragma warning disable CA1031 // Rejection is best effort before the transport terminal.
        catch (Exception)
#pragma warning restore CA1031
        {
        }

        await _termination.BeginAsync(
            new VoiceConnectionTerminationRequest("session_rejected", stopRuntime: true),
            CancellationToken.None).ConfigureAwait(false);
        await CloseOutputAsync(closeCode, "Session rejected").ConfigureAwait(false);
    }

    private async Task CloseOutputAsync(int closeCode, string reason)
    {
        if (_closed)
        {
            return;
        }

        RecordCloseCode(closeCode);
        _closed = true;
        if (_webSocket.State is WebSocketState.Open or WebSocketState.CloseReceived)
        {
            try
            {
                using var closeCancellation = _cleanupDeadline.CreateCancellationTokenSource();
                await _webSocket.CloseOutputAsync(
                    (WebSocketCloseStatus)closeCode,
                    reason,
                    closeCancellation.Token).ConfigureAwait(false);
            }
            catch (Exception exception) when (exception is WebSocketException or ObjectDisposedException or IOException or OperationCanceledException)
            {
                try
                {
                    _webSocket.Abort();
                }
                catch (Exception abortException) when (abortException is WebSocketException or ObjectDisposedException)
                {
                }
            }
        }
    }

    private async Task DrainTerminationAsync(CleanupDeadline deadline)
    {
        await FinalizeCallbackCoordinatorAsync().ConfigureAwait(false);
        _termination.StopRuntime();

        if (_callbackWorker is not null)
        {
            try
            {
                var remaining = deadline.Remaining;
                if (remaining > TimeSpan.Zero)
                {
                    await _callbackWorker.WaitAsync(remaining).ConfigureAwait(false);
                }
                else if (!_callbackWorker.IsCompleted)
                {
                    throw new TimeoutException();
                }
            }
            catch (Exception exception) when (exception is TimeoutException or OperationCanceledException)
            {
                TrackCleanup(_callbackWorker);
            }
        }

        _closed = true;
        RecordCloseCode(VoiceProtocolConstants.CloseNormal);
        if (_cleanupTasks.Count > 0)
        {
            try
            {
                var remaining = deadline.Remaining;
                if (remaining > TimeSpan.Zero)
                {
                    await Task.WhenAll(_cleanupTasks.Keys).WaitAsync(remaining).ConfigureAwait(false);
                }
            }
            catch (Exception exception) when (exception is TimeoutException or OperationCanceledException)
            {
            }
        }

        await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
        try
        {
            _seenMessages.Clear();
            _seenInputIdDigests.Clear();
            _seenResponseIds.Clear();
            _playbackOutcomes.Clear();
            _resolvedPrefixes.Clear();
            _recentResponses.Clear();
            _recentResponseOrder.Clear();
            _responseStartTimestamps.Clear();
            _firstOutputRecorded.Clear();
        }
        finally
        {
            _stateGate.Release();
        }

        _cleanupTasks.Clear();

        // Do not dispose synchronization/cancellation objects here. Customer
        // callbacks that ignore cancellation are allowed to outlive the bounded
        // shutdown wait; they still need deterministic terminal failures rather
        // than ObjectDisposedException from connection internals.
    }

    private async ValueTask<VoiceConnectionTerminationSnapshot> SealTerminationAsync(
        VoiceConnectionTerminationRequest request,
        CancellationToken cancellationToken)
    {
        await _stateGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            _ending = true;
            if (request.SessionEndEvent is not null)
            {
                _sessionEndEvent = request.SessionEndEvent;
            }

            var responses = _pendingTurns.Values
                .Concat(_pendingProactive.Values.Select(pending => pending.Response))
                .Distinct()
                .ToList();
            var activeResponse = _turnLease.Current?.Response;
            if (activeResponse is not null && !responses.Contains(activeResponse))
            {
                responses.Add(activeResponse);
            }

            _pendingTurns.Clear();
            _pendingTurnOrder.Clear();
            var terminations = new List<VoiceResponseTermination>(responses.Count);
            foreach (var response in responses)
            {
                terminations.Add(_termination.TryTerminateResponse(response, request.TerminalKind));
                ForgetResponseTimingLocked(response.ResponseId);
            }

            FailHelperWaitersLocked($"Voice connection terminated: {request.TerminalKind}.");
            if (request.StopRuntime || request.SessionEndEvent is not null)
            {
                _callbackQueue.Writer.TryComplete();
            }

            return new VoiceConnectionTerminationSnapshot(request, terminations);
        }
        finally
        {
            _stateGate.Release();
        }
    }

    private async ValueTask ApplyTerminationAsync(VoiceConnectionTerminationSnapshot snapshot)
    {
        foreach (var termination in snapshot.ResponseTerminations)
        {
            await termination.Response.MarkTerminalAsync().ConfigureAwait(false);
            if (termination.IsNewTerminal)
            {
                VoiceMetrics.RecordTerminal(termination.TerminalKind);
            }
        }

        if (snapshot.Request.StopRuntime || snapshot.Request.SessionEndEvent is not null)
        {
            _sessionEndSignal.TrySetResult();
        }
    }

    private async ValueTask NotifySessionEndAsync(SessionEndEvent sessionEnd)
    {
        await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
        try
        {
            _sessionEndEvent ??= sessionEnd;
            _callbackQueue.Writer.TryComplete();
        }
        finally
        {
            _stateGate.Release();
        }

        _sessionEndSignal.TrySetResult();
    }

    private async Task FinalizeCallbackCoordinatorAsync()
    {
        await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
        try
        {
            _callbackQueue.Writer.TryComplete();
        }
        finally
        {
            _stateGate.Release();
        }

        _sessionEndSignal.TrySetResult();
    }

    private void FailHelperWaitersLocked(string message)
    {
        foreach (var waiter in _cancelWaiters.Values)
        {
            waiter.TrySetException(new VoiceBridgeConnectionClosedException(message));
        }

        _cancelWaiters.Clear();
        _abandonedProactiveCancels.Clear();
        _dtmfCollections.Clear();
        _dtmfCancelPending.Clear();
        _recentDtmfCancelRaces.Clear();
        _recentDtmfCancelRaceOrder.Clear();
        foreach (var pending in _pendingProactive.Values)
        {
            pending.Completion.TrySetException(new VoiceBridgeConnectionClosedException(message));
        }

        _pendingProactive.Clear();
    }

    private async Task ProcessSessionEndCallbackAsync(SessionEndEvent sessionEnd)
    {
        if (Interlocked.Exchange(ref _sessionEndCallbackStarted, 1) != 0 || _session is null)
        {
            return;
        }

        var callbackStarted = Stopwatch.GetTimestamp();
        var callbackFailed = false;
        Task? customerTask = null;
        try
        {
            using var callbackCancellation = _cleanupDeadline.CreateCancellationTokenSource();
            customerTask = InvokeCustomerCallback(() =>
                _handler.InvokeSessionEndAsync(_session, sessionEnd, callbackCancellation.Token));
            await customerTask.WaitAsync(callbackCancellation.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (_cleanupDeadline.Remaining <= TimeSpan.Zero)
        {
            if (customerTask is not null && !customerTask.IsCompleted)
            {
                TrackCleanup(customerTask);
            }
        }
#pragma warning disable CA1031 // Terminal callback failures cannot fail connection cleanup.
        catch (Exception)
#pragma warning restore CA1031
        {
            callbackFailed = true;
        }

        VoiceMetrics.RecordCallback("session.end", callbackStarted, callbackFailed);
    }

    private void DrainQueuedCallbackWork()
    {
        while (_callbackQueue.Reader.TryRead(out var work))
        {
            Interlocked.Add(ref _queuedCallbackBytes, -work.EstimatedBytes);
        }
    }

    private static Task InvokeCustomerCallback(Func<Task> callback)
    {
        try
        {
            return callback() ?? Task.FromException(new InvalidOperationException("A voice callback returned a null task."));
        }
#pragma warning disable CA1031 // Synchronous customer callback failures are represented as faulted tasks.
        catch (Exception exception)
#pragma warning restore CA1031
        {
            return Task.FromException(exception);
        }
    }

    private Activity? StartDetachedTurnActivity(string responseId, string kind)
    {
        var previous = Activity.Current;
        try
        {
            return InvocationsTelemetry.ActivitySource.StartActivity(
                "hosted_agent.turn",
                ActivityKind.Internal,
                _connectionActivityContext,
                tags: new ActivityTagsCollection
                {
                    ["gen_ai.response.id"] = responseId,
                    ["voice.callback.kind"] = kind,
                });
        }
        finally
        {
            Activity.Current = previous;
        }
    }

    private static void StopDetachedTurnActivity(Activity? activity, string terminalKind)
    {
        if (activity is null)
        {
            return;
        }

        var previous = Activity.Current;
        try
        {
            activity.SetTag("voice.turn.status", terminalKind);
            if (terminalKind is "error" or "timeout" or "connection_closed")
            {
                activity.SetStatus(ActivityStatusCode.Error);
            }

            activity.Stop();
        }
        finally
        {
            if (!ReferenceEquals(previous, activity))
            {
                Activity.Current = previous;
            }
        }
    }

    private void ResolveTimeoutInputBatchLocked(
        IReadOnlyList<string> itemIds,
        List<VoiceResponse> responses,
        List<VoiceResponseTermination> terminations,
        ref TaskCompletionSource<ResponseCancellationOutcome>? cancelWaiter)
    {
        var offset = 0;
        while (offset < itemIds.Count)
        {
            var resolvedNode = _resolvedPrefixes.First;
            ResolvedPrefix? resolved = null;
            while (resolvedNode is not null)
            {
                if (PrefixDigestsMatch(itemIds, offset, resolvedNode.Value.ItemIdDigests))
                {
                    resolved = resolvedNode.Value;
                    _resolvedPrefixes.Remove(resolvedNode);
                    break;
                }

                resolvedNode = resolvedNode.Next;
            }

            if (resolved is not null)
            {
                AddResponseForTimeoutLocked(resolved.Response, responses, terminations);
                if (resolved.WireOpened)
                {
                    _playbackOutcomes.Add(resolved.Response.ResponseId);
                    if (_cancelWaiters.Remove(resolved.Response.ResponseId, out var waiter))
                    {
                        cancelWaiter = waiter;
                    }
                }

                offset += resolved.ItemIdDigests.Count;
                continue;
            }

            var remaining = itemIds.Skip(offset).ToArray();
            ValidatePendingPrefixLocked(remaining);
            foreach (var itemId in remaining)
            {
                var response = _pendingTurns[itemId];
                if (response.IsWireOpened)
                {
                    throw new VoiceBridgeProtocolException(
                        "response.timeout item_ids referenced an open response.",
                        VoiceProtocolConstants.ClosePolicyViolation);
                }

                AddResponseForTimeoutLocked(response, responses, terminations);
            }

            ConsumePendingPrefixLocked(remaining);
            offset = itemIds.Count;
        }
    }

    private void AddResponseForTimeoutLocked(
        VoiceResponse response,
        List<VoiceResponse> responses,
        List<VoiceResponseTermination> terminations)
    {
        if (!responses.Contains(response))
        {
            responses.Add(response);
        }

        terminations.Add(_termination.TryTerminateResponse(response, "timeout"));
        ForgetResponseTimingLocked(response.ResponseId);
    }

    private VoiceResponse? FindResponseLocked(string responseId)
    {
        var activeResponse = _turnLease.Current?.Response;
        if (activeResponse is not null && activeResponse.ResponseId == responseId)
        {
            return activeResponse;
        }

        return _recentResponses.GetValueOrDefault(responseId);
    }

    private void RememberResponseLocked(VoiceResponse response)
    {
        response.ReleaseOutputBuffers();
        if (_recentResponses.ContainsKey(response.ResponseId))
        {
            _recentResponseOrder.Remove(response.ResponseId);
        }

        _recentResponses[response.ResponseId] = response;
        _recentResponseOrder.AddLast(response.ResponseId);
        while (_recentResponseOrder.Count > MaxRecentResponses)
        {
            var oldest = _recentResponseOrder.First!.Value;
            _recentResponseOrder.RemoveFirst();
            _recentResponses.Remove(oldest);
        }
    }

    private void RememberResolvedPrefixLocked(
        IReadOnlyList<string> itemIds,
        VoiceResponse response,
        bool wireOpened)
    {
        var itemIdDigests = itemIds.Select(HashText).ToArray();
        var existing = _resolvedPrefixes.First;
        while (existing is not null)
        {
            var next = existing.Next;
            if (existing.Value.ItemIdDigests.SequenceEqual(itemIdDigests))
            {
                _resolvedPrefixes.Remove(existing);
            }

            existing = next;
        }

        _resolvedPrefixes.AddLast(new ResolvedPrefix(itemIdDigests, response, wireOpened));
        while (_resolvedPrefixes.Count > MaxResolvedPrefixes)
        {
            _resolvedPrefixes.RemoveFirst();
        }
    }

    private void ValidatePendingPrefixLocked(IReadOnlyList<string> prefix)
    {
        if (prefix.Count == 0 || prefix.Count > _pendingTurnOrder.Count)
        {
            throw new InvalidOperationException("in_reply_to must be an ordered prefix of pending inputs.");
        }

        var node = _pendingTurnOrder.First;
        for (var index = 0; index < prefix.Count; index++)
        {
            if (node is null || !string.Equals(node.Value, prefix[index], StringComparison.Ordinal))
            {
                throw new InvalidOperationException("in_reply_to must be an ordered prefix of pending inputs.");
            }

            node = node.Next;
        }
    }

    private void ConsumePendingPrefixLocked(IReadOnlyList<string> prefix)
    {
        foreach (var itemId in prefix)
        {
            if (_pendingTurnOrder.First is null ||
                !string.Equals(_pendingTurnOrder.First.Value, itemId, StringComparison.Ordinal))
            {
                throw new InvalidOperationException("in_reply_to must be an ordered prefix of pending inputs.");
            }

            _pendingTurnOrder.RemoveFirst();
            _pendingTurns.Remove(itemId);
        }
    }

    private void RemovePendingTurnLocked(string itemId)
    {
        _pendingTurns.Remove(itemId);
        _pendingTurnOrder.Remove(itemId);
    }

    private void AddSeenResponseIdLocked(string responseId)
    {
        if (!_seenResponseIds.Add(responseId))
        {
            throw new InvalidOperationException("Generated response_id was already used.");
        }

        if (_seenResponseIds.Count > MaxTrackedIds)
        {
            throw new VoiceBridgeProtocolException(
                "Response tracking limit exceeded.",
                VoiceProtocolConstants.ClosePolicyViolation);
        }
    }

    private void ForgetResponseTimingLocked(string responseId)
    {
        _responseStartTimestamps.Remove(responseId);
        _firstOutputRecorded.Remove(responseId);
    }

    private void EnsureReady()
    {
        if (!_ready || _closed)
        {
            throw new VoiceBridgeConnectionClosedException("The voice connection is not ready.");
        }

        if (_ending)
        {
            throw new VoiceBridgeConnectionClosedException("The voice session is ending.");
        }
    }

    private void EnsureReadyLocked()
    {
        if (!_ready || _closed || _ending)
        {
            throw new VoiceBridgeConnectionClosedException("The voice session is ending or closed.");
        }
    }

    private void RecordActivation(string result)
    {
        if (_activationRecorded)
        {
            return;
        }

        _activationRecorded = true;
        VoiceMetrics.RecordActivation(result);
    }

    private void RecordCloseCode(int closeCode)
    {
        if (Interlocked.Exchange(ref _closeRecorded, 1) != 0)
        {
            return;
        }

        if (_webSocket is TrackingWebSocket trackingWebSocket)
        {
            trackingWebSocket.RecordCloseCode(closeCode);
        }

        VoiceMetrics.RecordCloseCode(closeCode);
    }

    private void TrackCleanup(Task task)
    {
        _ = task.ContinueWith(
            completed =>
            {
                if (completed.IsFaulted)
                {
                    _ = completed.Exception;
                }
            },
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);

        var cleanup = BoundedCleanupAsync(task, _cleanupDeadline);
        if (!_cleanupTasks.TryAdd(cleanup, 0))
        {
            return;
        }

        _ = cleanup.ContinueWith(
            completed =>
            {
                _cleanupTasks.TryRemove(completed, out _);
                if (completed.IsFaulted)
                {
                    _ = completed.Exception;
                }
            },
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    private static async Task BoundedCleanupAsync(Task task, CleanupDeadline deadline)
    {
        try
        {
            var remaining = deadline.IsStarted
                ? deadline.Remaining
                : TimeSpan.FromSeconds(VoiceProtocolConstants.CleanupTimeoutSeconds);
            if (remaining > TimeSpan.Zero)
            {
                await task.WaitAsync(remaining).ConfigureAwait(false);
            }
        }
        catch (Exception exception) when (exception is TimeoutException or OperationCanceledException)
        {
        }
#pragma warning disable CA1031 // Customer callback failures are observed by the task continuation.
        catch (Exception)
#pragma warning restore CA1031
        {
        }
    }

    private static async Task ObserveTaskAsync(Task task)
    {
        try
        {
            await task.ConfigureAwait(false);
        }
#pragma warning disable CA1031 // Observation prevents unhandled customer-task exceptions.
        catch (Exception)
#pragma warning restore CA1031
        {
        }
    }

    private static bool PrefixDigestsMatch(
        IReadOnlyList<string> values,
        int offset,
        IReadOnlyList<string> prefixDigests)
    {
        if (offset + prefixDigests.Count > values.Count)
        {
            return false;
        }

        for (var index = 0; index < prefixDigests.Count; index++)
        {
            if (!string.Equals(HashText(values[offset + index]), prefixDigests[index], StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
    }

    private static string HashText(string value) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value)));

    private static int EstimatePayloadBytes(JsonElement payload)
    {
        // The estimate is used only as a queue memory guard. Measuring the raw
        // inbound JSON is a faithful, conservative upper bound on the memory the
        // queued callback retains, and — unlike serializing the typed event —
        // it correctly accounts for nested polymorphic content (text, image
        // references, history items) that default serialization would omit.
        return Math.Max(64, Encoding.UTF8.GetByteCount(payload.GetRawText()));
    }

    private sealed record CallbackWork(
        string Kind,
        int EstimatedBytes,
        Func<CancellationToken, Task> Callback,
        VoiceResponse? Response = null,
        string? ItemId = null,
        string? RequestId = null,
        string? SuccessType = null);

    private sealed record ResolvedPrefix(
        IReadOnlyList<string> ItemIdDigests,
        VoiceResponse Response,
        bool WireOpened);

    private sealed record PendingProactive(
        VoiceResponse Response,
        TaskCompletionSource<ProactiveOutcome> Completion);

    private sealed record ProactiveOutcome(bool Accepted, string Reason);

    private readonly record struct ActivationResult(bool Ready, Task<JsonElement?>? PendingReceive)
    {
        public static ActivationResult NotReady => new(false, null);
    }
}
