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
    private const int MaxRecentResponses = 64;
    private const int MaxResolvedPrefixes = 64;
    private const int EstimatedHashEntryBytes = 128;
    private const int EstimatedMessageDigestEntryBytes = 256;
    private const int EstimatedDigestStringBytes = 160;
    private static readonly TimeSpan TelemetryStartTimeout = TimeSpan.FromMilliseconds(100);
    private static readonly Encoding StrictUtf8 = new UTF8Encoding(
        encoderShouldEmitUTF8Identifier: false,
        throwOnInvalidBytes: true);

    private static readonly HashSet<string> AgentToBridgeMessageTypes = new(StringComparer.Ordinal)
    {
        "session.ready",
        "session.rejected",
        "response.created",
        "response.none",
        "response.output_text.delta",
        "response.output_text.done",
        "response.done",
        "response.cancel",
        "handoff",
        "end_call",
        "error",
    };

    private readonly WebSocket _webSocket;
    private readonly VoiceHandler _handler;
    private readonly InvocationContext _invocationContext;
    private readonly VoiceSendTransaction _sendTransaction;
    private readonly CleanupDeadline _cleanupDeadline;
    private readonly VoiceTurnLease _turnLease;
    private readonly VoiceTerminationCoordinator _termination;
    private readonly VoiceResourceGovernor _resourceGovernor;
    private readonly VoiceResourceLease _connectionResourceLease;
    private readonly TrackedIdentityBudget _identityBudget;
    private readonly TelemetryCallbackDispatcher _telemetryDispatcher;
    private readonly bool _ownsTelemetryDispatcher;
    private readonly ActivityContext _requestActivityContext;
    private readonly ConnectionActivityContextProvider? _connectionActivityContextProvider;
    private readonly IReadOnlyList<KeyValuePair<string, string?>> _connectionActivityBaggage;
    private readonly CancellationToken _connectionCancellationToken;
    private readonly CancellationTokenSource _runtimeCancellation;
    private readonly SemaphoreSlim _stateGate = new(1, 1);
    private readonly Channel<CallbackWork> _callbackQueue;
    private readonly ConcurrentDictionary<Task, byte> _cleanupTasks = new();
    private readonly Dictionary<string, string> _seenMessages = new(StringComparer.Ordinal);
    private readonly HashSet<string> _seenItemIdDigests = new(StringComparer.Ordinal);
    private readonly HashSet<string> _seenResponseIds = new(StringComparer.Ordinal);
    private readonly HashSet<string> _playbackOutcomes = new(StringComparer.Ordinal);
    private readonly HashSet<string> _abandonedProactiveCancels = new(StringComparer.Ordinal);
    private readonly Dictionary<string, VoiceResponse> _pendingTurns = new(StringComparer.Ordinal);
    private readonly LinkedList<string> _pendingTurnOrder = new();
    private readonly LinkedList<ResolvedPrefix> _resolvedPrefixes = new();
    private readonly Dictionary<string, VoiceResponse> _recentResponses = new(StringComparer.Ordinal);
    private readonly LinkedList<string> _recentResponseOrder = new();
    private readonly Dictionary<string, CancelWaiter> _cancelWaiters = new(StringComparer.Ordinal);
    private readonly Dictionary<string, PendingProactive> _pendingProactive = new(StringComparer.Ordinal);
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
    private string? _pendingHandoffResponseId;
    private string? _pendingHandoffTarget;
    private bool _activationRecorded;
    private int _closeRecorded;
    private int _sessionEndCallbackStarted;

    public VoiceConnection(
        WebSocket webSocket,
        VoiceHandler handler,
        InvocationContext invocationContext,
        CancellationToken cancellationToken)
        : this(
            webSocket,
            handler,
            invocationContext,
            new VoiceResourceGovernor(),
            cancellationToken)
    {
    }

    internal VoiceConnection(
        WebSocket webSocket,
        VoiceHandler handler,
        InvocationContext invocationContext,
        VoiceResourceGovernor resourceGovernor,
        CancellationToken cancellationToken)
    {
        _webSocket = webSocket;
        _handler = handler;
        _invocationContext = invocationContext;
        _resourceGovernor = resourceGovernor ?? throw new ArgumentNullException(nameof(resourceGovernor));
        _identityBudget = new TrackedIdentityBudget(
            VoiceProtocolConstants.MaxTrackedIdentityBytes,
            _resourceGovernor);
        _requestActivityContext = Activity.Current?.Context ?? default;
        _connectionActivityBaggage = Activity.Current?.Baggage.ToArray() ?? [];
        if (webSocket is TrackingWebSocket trackingWebSocket)
        {
            _cleanupDeadline = trackingWebSocket.CleanupDeadline;
            _telemetryDispatcher = trackingWebSocket.TelemetryDispatcher;
            _connectionActivityContextProvider = trackingWebSocket.ConnectionActivityContext;
            _ownsTelemetryDispatcher = false;
        }
        else
        {
            _cleanupDeadline = new CleanupDeadline(TimeSpan.FromSeconds(VoiceProtocolConstants.CleanupTimeoutSeconds));
            _telemetryDispatcher = new TelemetryCallbackDispatcher();
            _ownsTelemetryDispatcher = true;
        }
        _connectionCancellationToken = cancellationToken;
        _runtimeCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        // Response terminals are semantic outcomes and do not abort the
        // carrier. The wire owner observes only connection cancellation and a
        // bounded physical-send drain so a non-cooperative socket cannot strand
        // the send gate indefinitely.
        _sendTransaction = new VoiceSendTransaction(
            webSocket,
            _resourceGovernor,
            _runtimeCancellation.Token,
            terminalSendDrainTimeout: _cleanupDeadline.Remaining);
        _turnLease = new VoiceTurnLease(_telemetryDispatcher);
        _termination = new VoiceTerminationCoordinator(
            _cleanupDeadline,
            _runtimeCancellation,
            webSocket,
            _turnLease,
            SelectCloseCode,
            SealTerminationAsync,
            ApplyTerminationAsync,
            NotifySessionEndAsync,
            _resourceGovernor);
        _callbackQueue = Channel.CreateBounded<CallbackWork>(new BoundedChannelOptions(VoiceProtocolConstants.MaxCallbackQueue)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true,
            SingleWriter = true,
            AllowSynchronousContinuations = false,
        });
        _connectionResourceLease = _resourceGovernor.AcquireConnection();
    }

    public bool Ending => _termination.IsTerminating || _closed || _sendTransaction.Ending;

    internal async Task<int> GetAbandonedProactiveCancelCountAsync()
    {
        await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
        try
        {
            return _abandonedProactiveCancels.Count;
        }
        finally
        {
            _stateGate.Release();
        }
    }

    internal long TrackedIdentityBytes => _identityBudget.Bytes;

    internal async Task<string?> GetActiveResponseIdAsync()
    {
        await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
        try
        {
            return _turnLease.Current?.Response.ResponseId;
        }
        finally
        {
            _stateGate.Release();
        }
    }

    public async Task RunAsync()
    {
        VoiceMetrics.ConnectionOpened(_telemetryDispatcher);
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
                        if (_connectionCancellationToken.IsCancellationRequested &&
                            !_termination.IsTerminating)
                        {
                            // The callback worker and receive pump observe the
                            // same linked runtime cancellation. If the worker
                            // wins the completion race, preserve the original
                            // request token instead of misclassifying its
                            // expected shutdown as a coordinator failure.
                            SelectCloseCode(1006);
                            throw new OperationCanceledException(_connectionCancellationToken);
                        }

                        if (!_termination.IsTerminating &&
                            !_runtimeCancellation.IsCancellationRequested)
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
            VoiceMetrics.RecordProtocolViolation(_telemetryDispatcher, exception.CloseCode);
            await _termination.BeginAsync(
                new VoiceConnectionTerminationRequest("protocol_error", stopRuntime: true),
                CancellationToken.None).ConfigureAwait(false);
            await CloseOutputAsync(exception.CloseCode, "Protocol error").ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (
            _connectionCancellationToken.IsCancellationRequested &&
            !_termination.IsTerminating)
        {
            // Preserve the original request-aborted token so the endpoint can
            // classify this transport boundary as local abnormal closure 1006.
            // The bridge uses that classification to decide whether reattach
            // is permitted; converting it to a clean return would emit 1000
            // and incorrectly suppress reconnect.
            SelectCloseCode(1006);
            throw new OperationCanceledException(_connectionCancellationToken);
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
            throw;
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
                VoiceMetrics.ConnectionClosed(_telemetryDispatcher);
                _connectionResourceLease.Dispose();
                if (_ownsTelemetryDispatcher)
                {
                    _telemetryDispatcher.Dispose();
                }
            }
        }
    }

    public async Task SendAsync(
        string messageType,
        IReadOnlyDictionary<string, object?> fields,
        CancellationToken cancellationToken,
        CancellationToken responseCancellation = default)
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
            cancellationToken,
            responseCancellation).ConfigureAwait(false);

        if (firstOutputStarted.HasValue)
        {
            VoiceMetrics.RecordFirstOutput(_telemetryDispatcher, firstOutputStarted.Value);
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

        frames.Add(new VoiceFramePayload(
            messageType,
            fields,
            terminal ? response.ResponseId : null,
            terminal ? terminalKind : null));
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
                        ValidatePendingPrefixLocked(response.InReplyTo!);
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

                    if (reservation.OpensResponse)
                    {
                        var inReplyTo = response.InReplyTo!;
                        RememberResolvedPrefixLocked(inReplyTo, response, wireOpened: true);
                        ConsumePendingPrefixLocked(inReplyTo);
                    }

                    if (messageType is "response.output_text.delta" or "response.output_text.done" &&
                        _responseStartTimestamps.TryGetValue(response.ResponseId, out var started) &&
                        _firstOutputRecorded.Add(response.ResponseId))
                    {
                        firstOutputStarted = started;
                    }

                    if (terminal)
                    {
                        string? handoffTarget = null;
                        if (terminalKind == "handoff")
                        {
                            if (!fields.TryGetValue("target", out var targetValue) ||
                                targetValue is not string target ||
                                string.IsNullOrEmpty(target))
                            {
                                throw new InvalidOperationException("A handoff terminal requires a target.");
                            }

                            handoffTarget = target;
                        }

                        responseTermination = _termination.TryTerminateResponse(response, terminalKind!);
                        if (handoffTarget is not null)
                        {
                            _pendingHandoffResponseId = response.ResponseId;
                            _pendingHandoffTarget = handoffTarget;
                        }
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
            cancellationToken,
            response.CancellationToken).ConfigureAwait(false);

        ApplyResponseTermination(responseTermination);

        if (firstOutputStarted.HasValue)
        {
            VoiceMetrics.RecordFirstOutput(_telemetryDispatcher, firstOutputStarted.Value);
        }

        if (responseTermination.IsNewTerminal)
        {
            VoiceMetrics.RecordTerminal(_telemetryDispatcher, responseTermination.TerminalKind);
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

                        if (!response.TryCommitSend(reservation, static () => { }, terminal: false))
                        {
                            return false;
                        }

                        RememberResolvedPrefixLocked(inReplyTo, response, wireOpened: true);
                        ConsumePendingPrefixLocked(inReplyTo);
                        return true;
                    }
                    finally
                    {
                        _stateGate.Release();
                    }
                },
                cancellationToken,
                response.CancellationToken).ConfigureAwait(false);
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
            new VoiceFramePayload("response.none", fields, response.ResponseId, "none"),
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
                    if (_termination.IsResponseTerminal(response.ResponseId))
                    {
                        return false;
                    }

                    RememberResolvedPrefixLocked(inReplyTo, response, wireOpened: false);
                    ConsumePendingPrefixLocked(inReplyTo);
                    await response.MarkTerminalAsync().ConfigureAwait(false);
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
            cancellationToken,
            response.CancellationToken).ConfigureAwait(false);
        ApplyResponseTermination(responseTermination);
        if (firstOutputStarted.HasValue)
        {
            VoiceMetrics.RecordFirstOutput(_telemetryDispatcher, firstOutputStarted.Value);
        }

        if (responseTermination.IsNewTerminal)
        {
            VoiceMetrics.RecordTerminal(_telemetryDispatcher, "none");
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
        var waiterRegistered = false;
        var fields = new Dictionary<string, object?> { ["response_id"] = responseId };
        if (reason is not null)
        {
            fields["reason"] = reason;
        }

        var sendTask = _sendTransaction.ExecuteAsync(
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

                    var waiterLease = _resourceGovernor.AcquirePendingOperation();
                    if (!_cancelWaiters.TryAdd(responseId, new CancelWaiter(completion, waiterLease)))
                    {
                        waiterLease.Dispose();
                        throw new InvalidOperationException("Response cancellation is already pending.");
                    }

                    waiterRegistered = true;

                    try
                    {
                        response.ReserveCancellation();
                    }
                    catch
                    {
                        if (_cancelWaiters.Remove(responseId, out var removedWaiter))
                        {
                            removedWaiter.Lease.Dispose();
                        }
                        waiterRegistered = false;
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
            cancellationToken,
            response.CancellationToken);
        var firstCompleted = await Task.WhenAny(sendTask, completion.Task).ConfigureAwait(false);
        if (firstCompleted == completion.Task)
        {
            TrackCleanup(sendTask);
            return completion.Task;
        }

        try
        {
            await sendTask.ConfigureAwait(false);
        }
        catch (VoiceBridgeConnectionClosedException)
        {
            // A bridge terminal can complete the authoritative waiter after
            // reservation but before or during the response.cancel wire write.
            // Preserve that outcome instead of replacing it with a transport
            // exception from the losing send transaction.
            await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
            try
            {
                if (!waiterRegistered ||
                    (!completion.Task.IsCompleted &&
                        !_termination.IsResponseTerminal(responseId)))
                {
                    throw;
                }
            }
            finally
            {
                _stateGate.Release();
            }
        }

        return completion.Task;
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
            _runtimeCancellation.Token,
            _resourceGovernor);
        var completion = new TaskCompletionSource<ProactiveOutcome>(TaskCreationOptions.RunContinuationsAsynchronously);
        var waiterRegistered = false;
        var fields = new Dictionary<string, object?>
        {
            ["response_id"] = response.ResponseId,
            ["admission_timeout_ms"] = admissionTimeoutMs,
        };
        if (supersedeKey is not null)
        {
            fields["supersede_key"] = supersedeKey;
        }

        var sendTask = _sendTransaction.ExecuteAsync(
            new VoiceFramePayload("response.created", fields),
            async transactionCancellation =>
            {
                await _stateGate.WaitAsync(transactionCancellation).ConfigureAwait(false);
                try
                {
                    EnsureReadyLocked();
                    if (_pendingHandoffTarget is not null ||
                        _sendTransaction.TryGetPotentiallyVisibleHandoff(out _, out _))
                    {
                        throw new VoiceBridgeConnectionClosedException(
                            "Proactive admission is unavailable while handoff is pending.");
                    }

                    if (_pendingProactive.Count >= VoiceProtocolConstants.MaxPendingProactive)
                    {
                        throw new InvalidOperationException("Too many proactive admission outcomes are pending.");
                    }

                    var pendingLease = _resourceGovernor.AcquirePendingOperation();
                    try
                    {
                        AddSeenResponseIdLocked(response.ResponseId);
                        _pendingProactive.Add(
                            response.ResponseId,
                            new PendingProactive(response, completion, pendingLease));
                        waiterRegistered = true;
                    }
                    catch
                    {
                        pendingLease.Dispose();
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
            cancellationToken,
            response.CancellationToken);

        var retainSendTask = await AwaitProactiveSendArbitrationAsync(
            sendTask,
            completion.Task,
            () => waiterRegistered).ConfigureAwait(false);
        if (retainSendTask)
        {
            TrackCleanup(sendTask);
        }

        ProactiveOutcome outcome;
        try
        {
            outcome = await completion.Task.WaitAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            if (_runtimeCancellation.IsCancellationRequested)
            {
                // Connection teardown completes every pending admission with
                // its authoritative terminal result. A linked request token can
                // cancel the runtime before sealing reaches this waiter, while
                // other terminals publish both outcomes on adjacent asynchronous
                // continuations. Preserve the terminal result instead of exposing
                // a scheduling-dependent TaskCanceledException.
                outcome = await completion.Task.ConfigureAwait(false);
            }
            else
            {
                var shouldCancelAdmission = false;
                await _stateGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
                try
                {
                    // Cancellation can race the bridge outcome. Register an
                    // abandoned cancel only while admission is still pending or
                    // after acceptance made the response active. A dropped or
                    // connection-terminal response has no future playback outcome
                    // that could consume this marker.
                    shouldCancelAdmission = _pendingProactive.ContainsKey(response.ResponseId) ||
                        (response.IsAccepted && !response.IsTerminal);
                    if (shouldCancelAdmission)
                    {
                        _abandonedProactiveCancels.Add(response.ResponseId);
                    }
                }
                finally
                {
                    _stateGate.Release();
                }

                if (shouldCancelAdmission)
                {
                    try
                    {
                        await SendAsync(
                            "response.cancel",
                            new Dictionary<string, object?>
                            {
                                ["response_id"] = response.ResponseId,
                                ["reason"] = "cancelled_by_agent",
                            },
                            CancellationToken.None,
                            response.CancellationToken).ConfigureAwait(false);
                    }
                    catch (VoiceBridgeConnectionClosedException)
                    {
                    }
                }

                throw;
            }
        }

        if (!outcome.Accepted)
        {
            await response.MarkTerminalAsync().ConfigureAwait(false);
            throw new VoiceProactiveResponseDroppedException(response.ResponseId, outcome.Reason);
        }

        return response;
    }

    internal static async Task<bool> AwaitProactiveSendArbitrationAsync(
        Task sendTask,
        Task outcomeTask,
        Func<bool> waiterRegistered)
    {
        ArgumentNullException.ThrowIfNull(sendTask);
        ArgumentNullException.ThrowIfNull(outcomeTask);
        ArgumentNullException.ThrowIfNull(waiterRegistered);

        await Task.WhenAny(sendTask, outcomeTask).ConfigureAwait(false);
        if (outcomeTask.IsCompleted)
        {
            return true;
        }

        try
        {
            await sendTask.ConfigureAwait(false);
        }
        catch (VoiceBridgeConnectionClosedException) when (waiterRegistered())
        {
            // A causal bridge outcome may already be in the receive path. The
            // registered waiter remains discoverable until that outcome or the
            // connection terminal gives it one authoritative completion.
            await outcomeTask.ConfigureAwait(false);
        }

        return false;
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

        _session = new VoiceSession(this, startEvent, _invocationContext);
        var startupCancellation = CancellationTokenSource.CreateLinkedTokenSource(_runtimeCancellation.Token);
        var disposeStartupCancellation = true;
        try
        {
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
                if (!startupTask.IsCompleted)
                {
                    disposeStartupCancellation = false;
                    CancelStartupWithoutBlocking(startupCancellation, startupTask);
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

            // The last pre-attempt check is the readiness protocol boundary.
            // Once the socket send has been attempted, a compliant bridge may
            // observe session.ready and return its first application frame before
            // the local send continuation commits _ready. Keep that prefetched
            // frame for the normal receive loop instead of rejecting it based on
            // local task-completion ordering.
            var readySendTask = _sendTransaction.ExecuteAsync(
                new VoiceFramePayload("session.ready", new Dictionary<string, object?>()),
                static _ => ValueTask.FromResult(0),
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
                _connectionCancellationToken,
                beforeWireAsync: () =>
                {
                    if (pendingReceive.IsCompleted)
                    {
                        throw new ActivationAbortedException();
                    }

                    return ValueTask.CompletedTask;
                });

            try
            {
                await readySendTask.ConfigureAwait(false);
            }
            catch (ActivationAbortedException)
            {
                await RejectEarlyFrameAsync(pendingReceive).ConfigureAwait(false);
                return ActivationResult.NotReady;
            }

            RecordActivation("ready");
            return new ActivationResult(true, pendingReceive);
        }
        finally
        {
            if (disposeStartupCancellation)
            {
                startupCancellation.Dispose();
            }
        }
    }

    private void CancelStartupWithoutBlocking(CancellationTokenSource cancellation, Task startupTask)
    {
        Task cancellationTask;
        try
        {
            cancellationTask = cancellation.CancelAsync();
        }
        catch (ObjectDisposedException)
        {
            return;
        }

        TrackCleanup(DisposeStartupCancellationAsync(cancellation, startupTask, cancellationTask));
    }

    private static async Task DisposeStartupCancellationAsync(
        CancellationTokenSource cancellation,
        Task startupTask,
        Task cancellationTask)
    {
        await ObserveTaskAsync(cancellationTask).ConfigureAwait(false);
        await ObserveTaskAsync(startupTask).ConfigureAwait(false);
        cancellation.Dispose();
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
        if (Volatile.Read(ref _ending) && messageType != "session.end")
        {
            // Agent-selected end_call/error terminals keep the receive pump
            // alive only long enough to observe session.end or peer close.
            // Frames already in flight after that boundary are intentionally
            // absorbed: they must neither invoke customer code nor turn an
            // otherwise valid teardown race into a protocol violation.
            return true;
        }

        switch (messageType)
        {
            case "user.message":
                var userMessage = VoiceProtocolCodec.ParseUserMessage(payload);
                if (userMessage.Content.Count == 0)
                {
                    break;
                }

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
            case "handoff.failed":
                var handoff = VoiceProtocolCodec.ParseHandoffFailed(payload);
                await ReconcileHandoffFailureAsync(handoff).ConfigureAwait(false);
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

    private async Task ReconcileHandoffFailureAsync(HandoffFailedEvent failure)
    {
        VoiceResponse? priorResponse = null;
        VoiceResponseTermination priorTermination = default;
        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (_ending)
            {
                return;
            }

            if (_pendingHandoffTarget is not null)
            {
                if (string.IsNullOrEmpty(_pendingHandoffResponseId) ||
                    !_termination.IsResponseTerminal(_pendingHandoffResponseId) ||
                    !string.Equals(_pendingHandoffTarget, failure.Target, StringComparison.Ordinal))
                {
                    throw new VoiceBridgeProtocolException(
                        "handoff.failed target does not match the pending handoff.",
                        VoiceProtocolConstants.ClosePolicyViolation);
                }

                _pendingHandoffResponseId = null;
                _pendingHandoffTarget = null;
                return;
            }

            var current = _turnLease.Current;
            if (current is null ||
                !_sendTransaction.TryGetPotentiallyVisibleHandoff(
                    failure.Target,
                    out var attemptedResponseId) ||
                !string.Equals(
                    current.Response.ResponseId,
                    attemptedResponseId,
                    StringComparison.Ordinal))
            {
                throw new VoiceBridgeProtocolException(
                    "handoff.failed does not match an attempted handoff.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            priorResponse = current.Response;
            priorTermination = _termination.TryTerminateResponse(priorResponse, "handoff");
            ForgetResponseTimingLocked(priorResponse.ResponseId);
            RememberResponseLocked(priorResponse);
        }
        finally
        {
            _stateGate.Release();
        }

        if (priorResponse is not null)
        {
            await priorResponse.MarkTerminalAsync().ConfigureAwait(false);
            ApplyResponseTermination(priorTermination);
            if (priorTermination.IsNewTerminal)
            {
                VoiceMetrics.RecordTerminal(_telemetryDispatcher, "handoff");
            }
        }
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
            _runtimeCancellation.Token,
            _resourceGovernor);

        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (_ending)
            {
                return;
            }

            if (kind != "handoff.failed" &&
                (_pendingHandoffTarget is not null ||
                    _sendTransaction.TryGetPotentiallyVisibleHandoff(out _, out _)))
            {
                throw new VoiceBridgeProtocolException(
                    "A response-producing turn is invalid while handoff is pending.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            AddSeenItemIdLocked(itemId);

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

    private async Task EnqueueSignalAsync<TEvent>(
        TEvent @event,
        string kind,
        Func<VoiceSession, CancellationToken, Task> callback,
        JsonElement payload)
    {
        _ = @event;
        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (_ending)
            {
                return;
            }

            EnqueueWork(new CallbackWork(
                kind,
                EstimatePayloadBytes(payload),
                cancellationToken => callback(_session!, cancellationToken)));
        }
        finally
        {
            _stateGate.Release();
        }
    }

    private void EnqueueWork(CallbackWork work)
    {
        var queueLease = _resourceGovernor.AcquireCallbackQueueItem(work.EstimatedBytes);
        var queuedBytes = Interlocked.Add(ref _queuedCallbackBytes, work.EstimatedBytes);
        if (queuedBytes > MaxCallbackQueueBytes)
        {
            Interlocked.Add(ref _queuedCallbackBytes, -work.EstimatedBytes);
            queueLease.Dispose();
            throw new VoiceResourceExhaustedException("connection callback queue bytes");
        }

        var admittedWork = work with { QueueLease = queueLease };
        if (!_callbackQueue.Writer.TryWrite(admittedWork))
        {
            Interlocked.Add(ref _queuedCallbackBytes, -work.EstimatedBytes);
            queueLease.Dispose();
            throw new VoiceResourceExhaustedException("connection callback queue items");
        }
    }

    private async Task CallbackWorkerAsync()
    {
        try
        {
            await foreach (var work in _callbackQueue.Reader.ReadAllAsync(_runtimeCancellation.Token).ConfigureAwait(false))
            {
                Interlocked.Add(ref _queuedCallbackBytes, -work.EstimatedBytes);
                work.QueueLease?.Dispose();
                if (_sessionEndSignal.Task.IsCompleted || Volatile.Read(ref _ending))
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
                    activation = _turnLease.Activate(response, work.Kind, release, activity: null);
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

        var activityStart = StartTurnActivityAsync(response.ResponseId, work.Kind);
        var activityStartTimeout = Task.Delay(TelemetryStartTimeout);
        var activityAvailable = await Task.WhenAny(
            activityStart,
            release.Task,
            _sessionEndSignal.Task,
            activityStartTimeout).ConfigureAwait(false);
        if (activityAvailable == release.Task || activityAvailable == _sessionEndSignal.Task)
        {
            TrackCleanup(StopTurnActivityWhenStartedAsync(activityStart, "terminal_before_callback"));
            return;
        }

        if (activityAvailable == activityStart)
        {
            turnActivity = await activityStart.ConfigureAwait(false);
        }
        else
        {
            TrackCleanup(StopTurnActivityWhenStartedAsync(activityStart, "telemetry_start_timeout"));
        }

        if (turnActivity is not null && !_turnLease.TrySetActivity(activation.Token, turnActivity))
        {
            QueueDetachedTurnActivityStop(turnActivity, "terminal_before_callback");
            return;
        }

        Task customerTask;
        var previousActivity = Activity.Current;
        try
        {
            if (turnActivity is not null)
            {
                Activity.Current = turnActivity;
            }

            customerTask = InvokeCustomerCallback(() => work.Callback(response.CancellationToken));
        }
        finally
        {
            Activity.Current = previousActivity;
        }

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
                    var drainTask = response.DrainPendingSendAsync();
                    if (!drainTask.IsCompleted)
                    {
                        TrackCleanup(drainTask);
                    }
                    else if (drainTask.IsFaulted)
                    {
                        _ = drainTask.Exception;
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
                    try
                    {
                        await response.FailCallbackAsync(_runtimeCancellation.Token).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException) when (response.IsTerminal || Ending)
                    {
                    }
                    catch (VoiceBridgeConnectionClosedException) when (response.IsTerminal || Ending)
                    {
                    }
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

            VoiceMetrics.RecordCallback(_telemetryDispatcher, work.Kind, callbackStarted, callbackFailed);
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
                callbackFailed = await ObserveSignalCallbackAsync(
                    customerTask,
                    _runtimeCancellation.Token).ConfigureAwait(false);
            }
            else
            {
                TrackCleanup(customerTask);
            }

            VoiceMetrics.RecordCallback(_telemetryDispatcher, work.Kind, callbackStarted, callbackFailed);
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

        VoiceMetrics.RecordCallback(_telemetryDispatcher, work.Kind, callbackStarted, callbackFailed);
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
        CancelWaiter? waiter;
        VoiceResponseTermination termination;
        var abandoned = false;

        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (_ending)
            {
                return false;
            }

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
            if (outcome.ItemId is not null &&
                !response.OwnsItem(outcome.ItemId) &&
                !_sendTransaction.IsItemPotentiallyVisible(outcome.ResponseId, outcome.ItemId))
            {
                throw new VoiceBridgeProtocolException(
                    "Playback item_id does not belong to response_id.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            AddPlaybackOutcomeLocked(outcome.ResponseId);
            _cancelWaiters.Remove(outcome.ResponseId, out waiter);
            abandoned = _abandonedProactiveCancels.Remove(outcome.ResponseId);
            if (outcome.Kind == "cancelled" && waiter is null && !abandoned)
            {
                RemovePlaybackOutcomeLocked(outcome.ResponseId);
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

        await response.MarkTerminalAsync().ConfigureAwait(false);
        ApplyResponseTermination(termination);
        if (waiter is not null)
        {
            waiter.Lease.Dispose();
            waiter.Completion.TrySetResult(outcome);
        }
        if (termination.IsNewTerminal)
        {
            VoiceMetrics.RecordTerminal(_telemetryDispatcher, outcome.Kind);
        }

        return true;
    }

    private async Task HandleResponseTimeoutAsync(ResponseTimeoutEvent timeout, JsonElement payload)
    {
        var responses = new List<VoiceResponse>();
        var terminations = new List<VoiceResponseTermination>();
        var cancelWaiters = new List<CancelWaiter>();

        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (_ending)
            {
                return;
            }

            if (timeout.ResponseId is not null)
            {
                if (_playbackOutcomes.Contains(timeout.ResponseId))
                {
                    return;
                }

                var response = FindResponseLocked(timeout.ResponseId);
                if (response is null)
                {
                    if (_pendingProactive.ContainsKey(timeout.ResponseId))
                    {
                        throw new VoiceBridgeProtocolException(
                            "response.timeout is invalid before proactive response.accepted.",
                            VoiceProtocolConstants.ClosePolicyViolation);
                    }

                    if (_seenResponseIds.Contains(timeout.ResponseId))
                    {
                        return;
                    }

                    throw new VoiceBridgeProtocolException(
                        "Unknown response.timeout response_id.",
                        VoiceProtocolConstants.ClosePolicyViolation);
                }

                responses.Add(response);
                AddPlaybackOutcomeLocked(timeout.ResponseId);
                _abandonedProactiveCancels.Remove(timeout.ResponseId);
                terminations.Add(_termination.TryTerminateResponse(response, "timeout"));
                ForgetResponseTimingLocked(timeout.ResponseId);

                if (_cancelWaiters.Remove(timeout.ResponseId, out var cancelWaiter))
                {
                    cancelWaiters.Add(cancelWaiter);
                }
            }
            else
            {
                ResolveTimeoutInputBatchLocked(
                    timeout.ItemIds!,
                    responses,
                    terminations,
                    cancelWaiters);
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

        foreach (var termination in terminations)
        {
            ApplyResponseTermination(termination);
        }

        foreach (var cancelWaiter in cancelWaiters)
        {
            cancelWaiter.Lease.Dispose();
            cancelWaiter.Completion.TrySetException(
                new VoiceBridgeConnectionClosedException("Response terminated by timeout."));
        }
        foreach (var termination in terminations)
        {
            if (termination.IsNewTerminal)
            {
                VoiceMetrics.RecordTerminal(_telemetryDispatcher, "timeout");
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
        VoiceTurnActivation activation = default;
        VoiceResponseTermination priorTermination = default;
        VoiceResponse? priorResponse = null;
        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (_ending)
            {
                return;
            }

            if (!_pendingProactive.Remove(responseId, out pending!))
            {
                throw new VoiceBridgeProtocolException(
                    "Unknown proactive response_id.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }
            pending.Lease.Dispose();

            try
            {
                var current = _turnLease.Current;
                if (current is not null &&
                    _sendTransaction.TryGetPotentiallyVisibleTerminal(
                        current.Response.ResponseId,
                        out var terminalKind) &&
                    terminalKind != "handoff")
                {
                    priorResponse = current.Response;
                    priorTermination = _termination.TryTerminateResponse(priorResponse, terminalKind);
                    ForgetResponseTimingLocked(priorResponse.ResponseId);
                    RememberResponseLocked(priorResponse);
                }
                else if (current is not null)
                {
                    throw new VoiceBridgeProtocolException(
                        "A proactive response was accepted while another response was active.",
                        VoiceProtocolConstants.ClosePolicyViolation);
                }

                activation = _turnLease.Activate(
                    pending.Response,
                    "proactive",
                    release: null,
                    activity: null);

                _responseStartTimestamps[responseId] = Stopwatch.GetTimestamp();
                pending.Response.MarkAccepted();
            }
            catch (Exception exception)
            {
                pending.Completion.TrySetException(exception);
                throw;
            }
        }
        finally
        {
            _stateGate.Release();
        }

        try
        {
            if (priorResponse is not null)
            {
                await priorResponse.MarkTerminalAsync().ConfigureAwait(false);
                ApplyResponseTermination(priorTermination);
                if (priorTermination.IsNewTerminal)
                {
                    VoiceMetrics.RecordTerminal(_telemetryDispatcher, priorTermination.TerminalKind);
                }
            }

            var activityAttachment = StartAndAttachProactiveActivityAsync(responseId, activation.Token);
            if (!activityAttachment.IsCompleted)
            {
                TrackCleanup(activityAttachment);
            }

            pending.Completion.TrySetResult(new ProactiveOutcome(true, string.Empty));
        }
        catch (Exception exception)
        {
            pending.Completion.TrySetException(exception);
            throw;
        }
    }

    private async Task HandleResponseDroppedAsync(string responseId, string reason)
    {
        PendingProactive pending;
        VoiceResponseTermination termination;
        await _stateGate.WaitAsync(_runtimeCancellation.Token).ConfigureAwait(false);
        try
        {
            if (_ending)
            {
                return;
            }

            if (!_pendingProactive.Remove(responseId, out pending!))
            {
                throw new VoiceBridgeProtocolException(
                    "Unknown proactive response_id.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }
            pending.Lease.Dispose();

            try
            {
                _abandonedProactiveCancels.Remove(responseId);
                termination = _termination.TryTerminateResponse(pending.Response, "dropped");
                ForgetResponseTimingLocked(responseId);
            }
            catch (Exception exception)
            {
                pending.Completion.TrySetException(exception);
                throw;
            }
        }
        finally
        {
            _stateGate.Release();
        }

        try
        {
            await pending.Response.MarkTerminalAsync().ConfigureAwait(false);
            ApplyResponseTermination(termination);
            if (termination.IsNewTerminal)
            {
                VoiceMetrics.RecordTerminal(_telemetryDispatcher, "dropped");
            }

            pending.Completion.TrySetResult(new ProactiveOutcome(false, VoiceValidation.SafeCode(reason, "dropped")));
        }
        catch (Exception exception)
        {
            pending.Completion.TrySetException(exception);
            throw;
        }
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

            _seenMessages.Add(messageKey, digest);
            try
            {
                _identityBudget.Reserve(EstimatedMessageDigestEntryBytes);
            }
            catch
            {
                _seenMessages.Remove(messageKey);
                throw;
            }

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
                if (_connectionCancellationToken.IsCancellationRequested &&
                    !_termination.IsTerminating)
                {
                    throw new OperationCanceledException(_connectionCancellationToken);
                }

                return null;
            }
            catch (WebSocketException)
            {
                SelectCloseCode(1006);
                return null;
            }
            catch (IOException)
            {
                SelectCloseCode(1006);
                return null;
            }

            if (received.MessageType == WebSocketMessageType.Close)
            {
                SelectCloseCode((int?)_webSocket.CloseStatus ?? VoiceProtocolConstants.CloseNormal);
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
                try
                {
                    return StrictUtf8.GetString(stream.GetBuffer(), 0, checked((int)stream.Length));
                }
                catch (DecoderFallbackException)
                {
                    throw new VoiceBridgeProtocolException(
                        "Text frames must contain valid UTF-8.",
                        VoiceProtocolConstants.CloseProtocolError);
                }
            }
        }
    }

    private async Task RejectAsync(string code, int closeCode)
    {
        if (_closed)
        {
            return;
        }

        _termination.StartDeadline();
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

        SelectCloseCode(closeCode);
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
        SelectCloseCode(VoiceProtocolConstants.CloseNormal);
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
            _seenItemIdDigests.Clear();
            _seenResponseIds.Clear();
            ClearPlaybackOutcomesLocked();
            ClearResolvedPrefixesLocked();
            foreach (var response in _recentResponses.Values)
            {
                response.ReleaseRetainedIdentities();
            }
            _recentResponses.Clear();
            _recentResponseOrder.Clear();
            _pendingHandoffResponseId = null;
            _pendingHandoffTarget = null;
            _responseStartTimestamps.Clear();
            _firstOutputRecorded.Clear();
            _identityBudget.Reset();
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
            Volatile.Write(ref _ending, true);
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
            ApplyResponseTermination(termination);
            termination.Response.ReleaseRetainedIdentities();
            if (termination.IsNewTerminal)
            {
                VoiceMetrics.RecordTerminal(_telemetryDispatcher, termination.TerminalKind);
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
            waiter.Lease.Dispose();
            waiter.Completion.TrySetException(new VoiceBridgeConnectionClosedException(message));
        }

        _cancelWaiters.Clear();
        _abandonedProactiveCancels.Clear();
        foreach (var pending in _pendingProactive.Values)
        {
            pending.Lease.Dispose();
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
            customerTask = InvokeCustomerCallback(
                () => _handler.InvokeSessionEndAsync(_session, sessionEnd, callbackCancellation.Token),
                terminal: true);
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

        VoiceMetrics.RecordCallback(_telemetryDispatcher, "session.end", callbackStarted, callbackFailed);
    }

    private void DrainQueuedCallbackWork()
    {
        while (_callbackQueue.Reader.TryRead(out var work))
        {
            Interlocked.Add(ref _queuedCallbackBytes, -work.EstimatedBytes);
            work.QueueLease?.Dispose();
        }
    }

    private Task InvokeCustomerCallback(Func<Task> callback, bool terminal = false) =>
        _resourceGovernor.InvokeCustomerTask(callback, terminal);

    private async Task<Activity?> StartTurnActivityAsync(string responseId, string kind)
    {
        var parentContext = _requestActivityContext;
        var usedFallbackParent = false;
        if (_connectionActivityContextProvider is not null)
        {
            if (_connectionActivityContextProvider.TryGet(out var connectionActivityContext))
            {
                parentContext = connectionActivityContext;
            }
            else
            {
                usedFallbackParent = true;
            }
        }

        var tags = new ActivityTagsCollection
        {
            ["gen_ai.response.id"] = responseId,
            ["voice.callback.kind"] = kind,
        };
        if (usedFallbackParent)
        {
            tags["azure.ai.agentserver.trace.parent_fallback"] = true;
        }

        var activity = await InvocationsTelemetry.StartActivityAsync(
            _telemetryDispatcher,
            "hosted_agent.turn",
            ActivityKind.Internal,
            parentContext,
            tags,
            _connectionActivityBaggage).ConfigureAwait(false);
        if (usedFallbackParent && activity is not null)
        {
            VoiceMetrics.RecordParentFallback(_telemetryDispatcher);
        }

        return activity;
    }

    private async Task StartAndAttachProactiveActivityAsync(string responseId, VoiceTurnToken token)
    {
        var activity = await StartTurnActivityAsync(responseId, "proactive").ConfigureAwait(false);
        if (activity is not null && !_turnLease.TrySetActivity(token, activity))
        {
            await StopTurnActivityAsync(activity, "terminal_before_callback").ConfigureAwait(false);
        }
    }

    private async Task StopTurnActivityWhenStartedAsync(Task<Activity?> activityStart, string terminalKind)
    {
        var activity = await activityStart.ConfigureAwait(false);
        if (activity is not null)
        {
            await StopTurnActivityAsync(activity, terminalKind).ConfigureAwait(false);
        }
    }

    private Task StopTurnActivityAsync(Activity activity, string terminalKind) =>
        InvocationsTelemetry.StopActivityAsync(
            _telemetryDispatcher,
            activity,
            () => StopDetachedTurnActivity(activity, terminalKind));

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

    private void QueueDetachedTurnActivityStop(Activity? activity, string terminalKind)
    {
        if (activity is null)
        {
            return;
        }

        TrackCleanup(StopTurnActivityAsync(activity, terminalKind));
    }

    private void ResolveTimeoutInputBatchLocked(
        IReadOnlyList<string> itemIds,
        List<VoiceResponse> responses,
        List<VoiceResponseTermination> terminations,
        List<CancelWaiter> cancelWaiters)
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
                    ReleaseTrackedIdentityBytesLocked(resolved.EstimatedBytes);
                    break;
                }

                resolvedNode = resolvedNode.Next;
            }

            if (resolved is not null)
            {
                AddResponseForTimeoutLocked(resolved.Response, responses, terminations);
                if (resolved.WireOpened)
                {
                    AddPlaybackOutcomeLocked(resolved.Response.ResponseId);
                    if (_cancelWaiters.Remove(resolved.Response.ResponseId, out var waiter))
                    {
                        cancelWaiters.Add(waiter);
                    }
                }

                offset += resolved.ItemIdDigests.Count;
                continue;
            }

            var remaining = itemIds.Skip(offset).ToArray();
            try
            {
                ValidatePendingPrefixLocked(remaining);
            }
            catch (InvalidOperationException)
            {
                throw new VoiceBridgeProtocolException(
                    "response.timeout item_ids must be an ordered prefix of pending inputs.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }
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
            if (_recentResponses.Remove(oldest, out var evicted))
            {
                evicted.ReleaseRetainedIdentities();
            }
        }
    }

    private void RememberResolvedPrefixLocked(
        IReadOnlyList<string> itemIds,
        VoiceResponse response,
        bool wireOpened)
    {
        var itemIdDigests = itemIds.Select(HashText).ToArray();
        var estimatedBytes = checked(itemIdDigests.Length * EstimatedDigestStringBytes);
        var existing = _resolvedPrefixes.First;
        while (existing is not null)
        {
            var next = existing.Next;
            if (existing.Value.ItemIdDigests.SequenceEqual(itemIdDigests))
            {
                _resolvedPrefixes.Remove(existing);
                ReleaseTrackedIdentityBytesLocked(existing.Value.EstimatedBytes);
            }

            existing = next;
        }

        ReserveTrackedIdentityBytesLocked(estimatedBytes);
        _resolvedPrefixes.AddLast(new ResolvedPrefix(itemIdDigests, response, wireOpened, estimatedBytes));
        while (_resolvedPrefixes.Count > MaxResolvedPrefixes)
        {
            ReleaseTrackedIdentityBytesLocked(_resolvedPrefixes.First!.Value.EstimatedBytes);
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

        ReserveTrackedIdentityBytesLocked(EstimatedHashEntryBytes);
    }

    private void AddSeenItemIdLocked(string itemId)
    {
        var itemIdDigest = HashText(itemId);
        if (!_seenItemIdDigests.Add(itemIdDigest))
        {
            throw new VoiceBridgeProtocolException(
                "Item ID was reused.",
                VoiceProtocolConstants.ClosePolicyViolation);
        }

        try
        {
            ReserveTrackedIdentityBytesLocked(EstimatedHashEntryBytes);
        }
        catch
        {
            _seenItemIdDigests.Remove(itemIdDigest);
            throw;
        }
    }

    private void AddPlaybackOutcomeLocked(string responseId)
    {
        if (!_playbackOutcomes.Add(responseId))
        {
            return;
        }

        try
        {
            ReserveTrackedIdentityBytesLocked(EstimatedHashEntryBytes);
        }
        catch
        {
            _playbackOutcomes.Remove(responseId);
            throw;
        }
    }

    private void RemovePlaybackOutcomeLocked(string responseId)
    {
        if (_playbackOutcomes.Remove(responseId))
        {
            ReleaseTrackedIdentityBytesLocked(EstimatedHashEntryBytes);
        }
    }

    private void ClearPlaybackOutcomesLocked()
    {
        foreach (var _ in _playbackOutcomes)
        {
            ReleaseTrackedIdentityBytesLocked(EstimatedHashEntryBytes);
        }

        _playbackOutcomes.Clear();
    }

    private void ReserveTrackedIdentityBytesLocked(int bytes)
    {
        _identityBudget.Reserve(bytes);
    }

    private void ReleaseTrackedIdentityBytesLocked(int bytes) =>
        _identityBudget.Release(bytes);

    private void ClearResolvedPrefixesLocked()
    {
        foreach (var resolvedPrefix in _resolvedPrefixes)
        {
            ReleaseTrackedIdentityBytesLocked(resolvedPrefix.EstimatedBytes);
        }

        _resolvedPrefixes.Clear();
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
        VoiceMetrics.RecordActivation(_telemetryDispatcher, result);
    }

    private void SelectCloseCode(int closeCode)
    {
        if (Interlocked.Exchange(ref _closeRecorded, 1) != 0)
        {
            return;
        }

        if (_webSocket is TrackingWebSocket trackingWebSocket)
        {
            trackingWebSocket.TrySelectCloseCode(closeCode);
        }

        VoiceMetrics.RecordSelectedCloseCode(_telemetryDispatcher, closeCode);
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

        VoiceResourceLease cleanupLease;
        try
        {
            cleanupLease = _resourceGovernor.AcquireCleanupTask();
        }
        catch (VoiceResourceExhaustedException)
        {
            // Fault observation above remains attached to the original task.
            // Do not allocate another cleanup wrapper after host admission is full.
            return;
        }

        var cleanup = BoundedCleanupAsync(task, _cleanupDeadline);
        if (!_cleanupTasks.TryAdd(cleanup, 0))
        {
            cleanupLease.Dispose();
            return;
        }

        _ = cleanup.ContinueWith(
            completed =>
            {
                _cleanupTasks.TryRemove(completed, out _);
                cleanupLease.Dispose();
                if (completed.IsFaulted)
                {
                    _ = completed.Exception;
                }
            },
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    private void ApplyResponseTermination(VoiceResponseTermination termination)
    {
        var completion = VoiceTerminationCoordinator.ApplyResponseTermination(termination);
        if (!completion.IsCompleted)
        {
            TrackCleanup(completion);
        }
        else if (completion.IsFaulted)
        {
            _ = completion.Exception;
        }
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

    internal static async Task<bool> ObserveSignalCallbackAsync(
        Task task,
        CancellationToken runtimeCancellation)
    {
        try
        {
            await task.ConfigureAwait(false);
            return false;
        }
        catch (OperationCanceledException) when (runtimeCancellation.IsCancellationRequested)
        {
            return false;
        }
#pragma warning disable CA1031 // Signal callback failures are reported through content-free metrics.
        catch (Exception)
#pragma warning restore CA1031
        {
            return true;
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
        // it correctly accounts for nested polymorphic content (text and image
        // references) that default serialization would omit.
        return Math.Max(64, Encoding.UTF8.GetByteCount(payload.GetRawText()));
    }

    private sealed record CallbackWork(
        string Kind,
        int EstimatedBytes,
        Func<CancellationToken, Task> Callback,
        VoiceResponse? Response = null,
        string? ItemId = null,
        VoiceResourceLease? QueueLease = null);

    private sealed record ResolvedPrefix(
        IReadOnlyList<string> ItemIdDigests,
        VoiceResponse Response,
        bool WireOpened,
        int EstimatedBytes);

    private sealed record PendingProactive(
        VoiceResponse Response,
        TaskCompletionSource<ProactiveOutcome> Completion,
        VoiceResourceLease Lease);

    private sealed record CancelWaiter(
        TaskCompletionSource<ResponseCancellationOutcome> Completion,
        VoiceResourceLease Lease);

    private sealed record ProactiveOutcome(bool Accepted, string Reason);

    private readonly record struct ActivationResult(bool Ready, Task<JsonElement?>? PendingReceive)
    {
        public static ActivationResult NotReady => new(false, null);
    }
}
