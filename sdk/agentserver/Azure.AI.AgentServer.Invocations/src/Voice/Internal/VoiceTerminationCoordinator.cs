// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using Azure.AI.AgentServer.Invocations.Internal;

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// The first connection-level terminal selected for one Voice runtime.
/// </summary>
internal sealed class VoiceConnectionTerminationRequest
{
    public VoiceConnectionTerminationRequest(
        string terminalKind,
        bool stopRuntime,
        SessionEndEvent? sessionEndEvent = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(terminalKind);
        TerminalKind = terminalKind;
        StopRuntime = stopRuntime;
        SessionEndEvent = sessionEndEvent;
    }

    public string TerminalKind { get; }

    public bool StopRuntime { get; }

    public SessionEndEvent? SessionEndEvent { get; }
}

/// <summary>
/// One response terminal selected by the coordinator together with any active
/// turn state captured by the shared lease.
/// </summary>
internal readonly record struct VoiceResponseTermination(
    bool IsNewTerminal,
    string TerminalKind,
    VoiceResponse Response,
    VoiceTurnTermination TurnTermination);

/// <summary>
/// State atomically detached from a connection when its first terminal wins.
/// </summary>
internal sealed class VoiceConnectionTerminationSnapshot
{
    public VoiceConnectionTerminationSnapshot(
        VoiceConnectionTerminationRequest request,
        IReadOnlyList<VoiceResponseTermination> responseTerminations)
    {
        Request = request;
        ResponseTerminations = responseTerminations;
    }

    public VoiceConnectionTerminationRequest Request { get; }

    public IReadOnlyList<VoiceResponseTermination> ResponseTerminations { get; }

    public static VoiceConnectionTerminationSnapshot Empty(VoiceConnectionTerminationRequest request) =>
        new(request, Array.Empty<VoiceResponseTermination>());
}

/// <summary>
/// Result of a <see cref="VoiceTerminationCoordinator.BeginAsync"/> call.
/// <see cref="IsWinner"/> is <see langword="true"/> only for the single caller
/// whose request became the connection's first terminal and is therefore the
/// one permitted to emit its terminal wire frame.
/// </summary>
internal readonly record struct VoiceTerminationOutcome(
    VoiceConnectionTerminationSnapshot Snapshot,
    bool IsWinner);

/// <summary>
/// The single owner of response terminal registration and connection teardown
/// selection. It runs seal/apply/drain at most once and enforces the shared
/// monotonic cleanup deadline.
/// </summary>
internal sealed class VoiceTerminationCoordinator
{
    private const int EstimatedTerminalIdBytes = 128;
    private readonly object _sync = new();
    private readonly CleanupDeadline _deadline;
    private readonly CancellationTokenSource _runtimeCancellation;
    private readonly WebSocket _webSocket;
    private readonly VoiceTurnLease _turnLease;
    private readonly Action<int> _recordCloseCode;
    private readonly Func<
        VoiceConnectionTerminationRequest,
        CancellationToken,
        ValueTask<VoiceConnectionTerminationSnapshot>> _sealAsync;
    private readonly Func<VoiceConnectionTerminationSnapshot, ValueTask> _applyAsync;
    private readonly Func<SessionEndEvent, ValueTask> _notifySessionEndAsync;
    private readonly HashSet<string> _terminalResponseIds = new(StringComparer.Ordinal);
    private readonly TaskCompletionSource<VoiceConnectionTerminationSnapshot> _beginCompletion =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource _completeCompletion =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource _completedSignal =
        new(TaskCreationOptions.RunContinuationsAsynchronously);

    private VoiceConnectionTerminationRequest? _request;
    private int _beginStarted;
    private int _completeStarted;
    private int _deadlineEnforcementStarted;
    private int _completed;
    private long _terminalIdBytes;

    public VoiceTerminationCoordinator(
        CleanupDeadline deadline,
        CancellationTokenSource runtimeCancellation,
        WebSocket webSocket,
        VoiceTurnLease turnLease,
        Action<int> recordCloseCode,
        Func<
            VoiceConnectionTerminationRequest,
            CancellationToken,
            ValueTask<VoiceConnectionTerminationSnapshot>> sealAsync,
        Func<VoiceConnectionTerminationSnapshot, ValueTask> applyAsync,
        Func<SessionEndEvent, ValueTask> notifySessionEndAsync)
    {
        _deadline = deadline ?? throw new ArgumentNullException(nameof(deadline));
        _runtimeCancellation = runtimeCancellation ?? throw new ArgumentNullException(nameof(runtimeCancellation));
        _webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
        _turnLease = turnLease ?? throw new ArgumentNullException(nameof(turnLease));
        _recordCloseCode = recordCloseCode ?? throw new ArgumentNullException(nameof(recordCloseCode));
        _sealAsync = sealAsync ?? throw new ArgumentNullException(nameof(sealAsync));
        _applyAsync = applyAsync ?? throw new ArgumentNullException(nameof(applyAsync));
        _notifySessionEndAsync = notifySessionEndAsync ?? throw new ArgumentNullException(nameof(notifySessionEndAsync));
    }

    public CleanupDeadline Deadline => _deadline;

    public VoiceTurnLease TurnLease => _turnLease;

    public bool IsTerminating => Volatile.Read(ref _beginStarted) != 0;

    public void StartDeadline()
    {
        _deadline.Start();
        StartDeadlineEnforcement();
    }

    public VoiceConnectionTerminationRequest? Request
    {
        get
        {
            lock (_sync)
            {
                return _request;
            }
        }
    }

    public async Task<VoiceTerminationOutcome> BeginAsync(
        VoiceConnectionTerminationRequest request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (Interlocked.CompareExchange(ref _beginStarted, 1, 0) != 0)
        {
            var existing = await _beginCompletion.Task.WaitAsync(cancellationToken).ConfigureAwait(false);
            if (request.SessionEndEvent is not null)
            {
                await _notifySessionEndAsync(request.SessionEndEvent).ConfigureAwait(false);
            }

            if (request.StopRuntime)
            {
                CancelRuntime();
            }

            return new VoiceTerminationOutcome(existing, IsWinner: false);
        }

        lock (_sync)
        {
            _request = request;
        }

        StartDeadline();
        try
        {
            var snapshot = await _sealAsync(request, cancellationToken).ConfigureAwait(false);
            await _applyAsync(snapshot).ConfigureAwait(false);
            if (request.StopRuntime)
            {
                CancelRuntime();
            }

            _beginCompletion.TrySetResult(snapshot);
            return new VoiceTerminationOutcome(snapshot, IsWinner: true);
        }
#pragma warning disable CA1031 // A failed or partially applied seal cannot be recovered safely.
        catch (Exception exception)
#pragma warning restore CA1031
        {
            _beginCompletion.TrySetException(exception);
            CancelRuntime();
            AbortBestEffort();
            throw;
        }
    }

    public async Task CompleteAsync(Func<CleanupDeadline, Task> drainAsync)
    {
        ArgumentNullException.ThrowIfNull(drainAsync);
        if (Interlocked.CompareExchange(ref _completeStarted, 1, 0) != 0)
        {
            await _completeCompletion.Task.ConfigureAwait(false);
            return;
        }

        try
        {
            await drainAsync(_deadline).ConfigureAwait(false);
            _completeCompletion.TrySetResult();
        }
#pragma warning disable CA1031 // Every caller must observe the same cleanup failure.
        catch (Exception exception)
#pragma warning restore CA1031
        {
            _completeCompletion.TrySetException(exception);
            throw;
        }
    }

    public VoiceResponseTermination TryTerminateResponse(
        VoiceResponse response,
        string terminalKind)
    {
        ArgumentNullException.ThrowIfNull(response);
        ArgumentException.ThrowIfNullOrEmpty(terminalKind);

        bool added;
        lock (_sync)
        {
            added = _terminalResponseIds.Add(response.ResponseId);
            if (added)
            {
                _terminalIdBytes = checked(_terminalIdBytes + EstimatedTerminalIdBytes);
                if (_terminalIdBytes > VoiceProtocolConstants.MaxTrackedIdentityBytes)
                {
                    throw new VoiceBridgeProtocolException(
                        "Terminal response identity tracking byte limit exceeded.",
                        VoiceProtocolConstants.ClosePolicyViolation);
                }
            }
        }

        var turnTermination = added
            ? _turnLease.TryDetach(response, terminalKind)
            : VoiceTurnTermination.None(terminalKind);
        return new VoiceResponseTermination(
            added,
            terminalKind,
            response,
            turnTermination);
    }

    public static Task ApplyResponseTermination(VoiceResponseTermination termination)
    {
        if (!termination.IsNewTerminal)
        {
            return Task.CompletedTask;
        }

        termination.Response.ReleaseOutputBuffers();
        return termination.TurnTermination.Complete();
    }

    public bool IsResponseTerminal(string responseId)
    {
        lock (_sync)
        {
            return _terminalResponseIds.Contains(responseId);
        }
    }

    public void StopRuntime() => CancelRuntime();

    public void MarkCompleted()
    {
        lock (_sync)
        {
            _terminalResponseIds.Clear();
            _terminalIdBytes = 0;
        }

        Volatile.Write(ref _completed, 1);
        _completedSignal.TrySetResult();
    }

    private void StartDeadlineEnforcement()
    {
        if (Interlocked.CompareExchange(ref _deadlineEnforcementStarted, 1, 0) == 0)
        {
            _ = EnforceDeadlineAsync();
        }
    }

    private async Task EnforceDeadlineAsync()
    {
        using var deadlineCancellation = _deadline.CreateCancellationTokenSource();
        var deadlineTask = Task.Delay(Timeout.InfiniteTimeSpan, deadlineCancellation.Token);
        var completed = await Task.WhenAny(deadlineTask, _completedSignal.Task).ConfigureAwait(false);
        if (completed == _completedSignal.Task)
        {
            return;
        }

        try
        {
            await deadlineTask.ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (deadlineCancellation.IsCancellationRequested)
        {
        }

        if (Volatile.Read(ref _completed) != 0)
        {
            return;
        }

        _recordCloseCode(1006);
        CancelRuntime();
        AbortBestEffort();
    }

    private void CancelRuntime()
    {
        // The runtime token is linked to customer-visible response tokens, so a
        // blocking cancellation registration must not stall bounded teardown.
        // Initiate cancellation off the current stack (CancelAsync sets the
        // token state synchronously but dispatches registered callbacks) and
        // observe any faults without blocking the termination path.
        Task cancelTask;
        try
        {
            cancelTask = _runtimeCancellation.CancelAsync();
        }
        catch (ObjectDisposedException)
        {
            return;
        }

        if (!cancelTask.IsCompleted)
        {
            ObserveCancelFaults(cancelTask);
        }
        else if (cancelTask.IsFaulted)
        {
            _ = cancelTask.Exception;
        }
    }

    private static void ObserveCancelFaults(Task cancelTask) =>
        _ = cancelTask.ContinueWith(
            static completed => { _ = completed.Exception; },
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);

    private void AbortBestEffort()
    {
        try
        {
            _webSocket.Abort();
        }
#pragma warning disable CA1031 // Deadline and failed-seal aborts are terminal best effort.
        catch (Exception)
#pragma warning restore CA1031
        {
        }
    }
}
