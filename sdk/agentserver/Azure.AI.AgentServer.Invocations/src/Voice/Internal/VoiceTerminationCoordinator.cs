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
    private readonly VoiceResourceGovernor _resourceGovernor;
    private readonly Action<int> _selectCloseCode;
    private readonly Func<
        VoiceConnectionTerminationRequest,
        CancellationToken,
        ValueTask<VoiceConnectionTerminationSnapshot>> _sealAsync;
    private readonly Func<VoiceConnectionTerminationSnapshot, ValueTask> _applyAsync;
    private readonly Func<SessionEndEvent, CancellationToken, ValueTask> _notifySessionEndAsync;
    private readonly HashSet<string> _terminalResponseIds = new(StringComparer.Ordinal);
    private readonly TaskCompletionSource<VoiceConnectionTerminationSnapshot> _beginCompletion =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource _completeCompletion =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource _completedSignal =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource _failAllCompletion =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource _applyCompletion =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly HashSet<Task> _structuralOwners = new();
    private readonly CancellationTokenSource _structuralOwnerCancellation = new();

    private VoiceConnectionTerminationRequest? _request;
    private VoiceConnectionTerminationSnapshot? _capturedSnapshot;
    private TaskCompletionSource? _structuralOwnersDrained;
    private bool _deadlineExpiredBeforeBegin;
    private bool _structuralOwnersClosed;
    private int _beginStarted;
    private int _completeStarted;
    private int _deadlineEnforcementStarted;
    private int _failAllStarted;
    private int _applyStarted;
    private int _completed;
    private long _terminalIdBytes;

    public VoiceTerminationCoordinator(
        CleanupDeadline deadline,
        CancellationTokenSource runtimeCancellation,
        WebSocket webSocket,
        VoiceTurnLease turnLease,
        Action<int> selectCloseCode,
        Func<
            VoiceConnectionTerminationRequest,
            CancellationToken,
            ValueTask<VoiceConnectionTerminationSnapshot>> sealAsync,
        Func<VoiceConnectionTerminationSnapshot, ValueTask> applyAsync,
        Func<SessionEndEvent, CancellationToken, ValueTask> notifySessionEndAsync,
        VoiceResourceGovernor? resourceGovernor = null)
    {
        _deadline = deadline ?? throw new ArgumentNullException(nameof(deadline));
        _runtimeCancellation = runtimeCancellation ?? throw new ArgumentNullException(nameof(runtimeCancellation));
        _webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
        _turnLease = turnLease ?? throw new ArgumentNullException(nameof(turnLease));
        _resourceGovernor = resourceGovernor ?? new VoiceResourceGovernor();
        _selectCloseCode = selectCloseCode ?? throw new ArgumentNullException(nameof(selectCloseCode));
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
        var isWinner = false;
        var ownerCompletion = new TaskCompletionSource<VoiceConnectionTerminationSnapshot>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        VoiceConnectionTerminationSnapshot? expiredSnapshot = null;
        lock (_sync)
        {
            if (_deadlineExpiredBeforeBegin)
            {
                _request ??= request;
                expiredSnapshot = VoiceConnectionTerminationSnapshot.Empty(_request);
            }
            else
            {
                if (_structuralOwnersClosed)
                {
                    throw new VoiceBridgeConnectionClosedException("Voice termination finalization has started.");
                }

                isWinner = _beginStarted == 0;
                if (isWinner)
                {
                    _beginStarted = 1;
                    _request = request;
                }

                EnsureStructuralOwnerOpenLocked();
                RegisterStructuralOwnerLocked(ownerCompletion.Task);
            }
        }
        if (expiredSnapshot is not null)
        {
            _beginCompletion.TrySetResult(expiredSnapshot);
            if (request.StopRuntime)
            {
                CancelRuntime();
            }
            return new VoiceTerminationOutcome(expiredSnapshot, IsWinner: false);
        }
        ObserveStructuralOwner(ownerCompletion.Task);

        Task<VoiceConnectionTerminationSnapshot> requestCompletion;
        if (isWinner)
        {
            StartDeadline();
            _ = RunStructuralOwnerFactoryAsync(
                token => RunBeginOwnerAsync(request, token),
                ownerCompletion);
            requestCompletion = _beginCompletion.Task;
        }
        else
        {
            _ = RunStructuralOwnerFactoryAsync(
                token => CompleteLateRequestAsync(request, token),
                ownerCompletion);
            requestCompletion = ownerCompletion.Task;
        }

        try
        {
            var snapshot = await requestCompletion.WaitAsync(cancellationToken).ConfigureAwait(false);
            return new VoiceTerminationOutcome(snapshot, isWinner);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            ObserveFaults(requestCompletion);
            throw;
        }
    }

    private async Task<VoiceConnectionTerminationSnapshot> RunBeginOwnerAsync(
        VoiceConnectionTerminationRequest request,
        CancellationToken structuralCancellation)
    {
        try
        {
            var snapshot = await _sealAsync(request, structuralCancellation).ConfigureAwait(false);
            snapshot = PublishCapturedSnapshot(snapshot);
            await ApplySnapshotOnceAsync(snapshot).ConfigureAwait(false);
            if (request.StopRuntime)
            {
                CancelRuntime();
            }

            _beginCompletion.TrySetResult(snapshot);
            return snapshot;
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

    private async Task<VoiceConnectionTerminationSnapshot> CompleteLateRequestAsync(
        VoiceConnectionTerminationRequest request,
        CancellationToken structuralCancellation)
    {
        var existing = await _beginCompletion.Task.WaitAsync(structuralCancellation).ConfigureAwait(false);
        structuralCancellation.ThrowIfCancellationRequested();
        if (request.SessionEndEvent is not null)
        {
            await _notifySessionEndAsync(request.SessionEndEvent, structuralCancellation).ConfigureAwait(false);
        }

        if (request.StopRuntime)
        {
            CancelRuntime();
        }

        return existing;
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
            await AwaitStructuralOwnersAsync().ConfigureAwait(false);
            if (Volatile.Read(ref _failAllStarted) != 0 ||
                (Volatile.Read(ref _beginStarted) != 0 && !_beginCompletion.Task.IsCompletedSuccessfully))
            {
                await CloseStructuralOwnersAsync().ConfigureAwait(false);
            }
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

    private async Task RunStructuralOwnerFactoryAsync<T>(
        Func<CancellationToken, Task<T>> ownerFactory,
        TaskCompletionSource<T> completion)
    {
        try
        {
            _structuralOwnerCancellation.Token.ThrowIfCancellationRequested();
            var owner = ownerFactory(_structuralOwnerCancellation.Token) ?? throw new InvalidOperationException(
                "A structural termination owner returned a null task.");
            completion.TrySetResult(await owner.ConfigureAwait(false));
        }
#pragma warning disable CA1031 // Every detached structural owner is represented by its completion task.
        catch (Exception exception)
#pragma warning restore CA1031
        {
            completion.TrySetException(exception);
        }
    }

    private void EnsureStructuralOwnerOpenLocked()
    {
        if (_structuralOwnersClosed)
        {
            throw new VoiceBridgeConnectionClosedException("Voice termination finalization has started.");
        }

        _structuralOwnersDrained ??= new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
    }

    private void RegisterStructuralOwnerLocked(Task owner)
    {
        _structuralOwners.Add(owner);
    }

    private void ObserveStructuralOwner(Task owner)
    {
        _ = owner.ContinueWith(
            completed =>
            {
                TaskCompletionSource? drained = null;
                lock (_sync)
                {
                    _structuralOwners.Remove(completed);
                    if (_structuralOwners.Count == 0)
                    {
                        drained = _structuralOwnersDrained;
                        _structuralOwnersDrained = null;
                    }
                }

                if (completed.IsFaulted)
                {
                    _ = completed.Exception;
                }
                drained?.TrySetResult();
            },
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }

    private async Task AwaitStructuralOwnersAsync()
    {
        while (true)
        {
            Task? drained;
            lock (_sync)
            {
                if (_structuralOwners.Count == 0)
                {
                    _structuralOwnersClosed = true;
                    return;
                }

                drained = _structuralOwnersDrained?.Task;
            }

            var remaining = _deadline.Remaining;
            if (remaining <= TimeSpan.Zero || drained is null)
            {
                await CloseStructuralOwnersAsync().ConfigureAwait(false);
                return;
            }

            try
            {
                await drained.WaitAsync(remaining).ConfigureAwait(false);
            }
            catch (TimeoutException)
            {
                await CloseStructuralOwnersAsync().ConfigureAwait(false);
                return;
            }
        }
    }

    private async Task CloseStructuralOwnersAsync()
    {
        if (Interlocked.CompareExchange(ref _failAllStarted, 1, 0) != 0)
        {
            await _failAllCompletion.Task.ConfigureAwait(false);
            return;
        }

        var failure = new VoiceBridgeConnectionClosedException(
            "Voice structural termination exceeded its cleanup deadline.");
        lock (_sync)
        {
            _structuralOwnersClosed = true;
        }

        _beginCompletion.TrySetException(failure);
        CancelRuntime();
        AbortBestEffort();
        try
        {
            _structuralOwnerCancellation.Cancel();
        }
        catch (ObjectDisposedException)
        {
        }

        try
        {
            var request = Request;
            if (request is not null)
            {
                var snapshot = GetCapturedSnapshot();
                if (snapshot is null)
                {
                    snapshot = await _sealAsync(request, CancellationToken.None).ConfigureAwait(false);
                    snapshot = PublishCapturedSnapshot(snapshot);
                }

                await ApplySnapshotOnceAsync(snapshot).ConfigureAwait(false);
            }
        }
#pragma warning disable CA1031 // Emergency fail-all is best effort before bounded final release.
        catch (Exception)
#pragma warning restore CA1031
        {
        }
        finally
        {
            _failAllCompletion.TrySetResult();
        }
    }

    private VoiceConnectionTerminationSnapshot PublishCapturedSnapshot(
        VoiceConnectionTerminationSnapshot snapshot)
    {
        lock (_sync)
        {
            _capturedSnapshot ??= snapshot;
            return _capturedSnapshot;
        }
    }

    private VoiceConnectionTerminationSnapshot? GetCapturedSnapshot()
    {
        lock (_sync)
        {
            return _capturedSnapshot;
        }
    }

    private async Task ApplySnapshotOnceAsync(VoiceConnectionTerminationSnapshot snapshot)
    {
        if (Interlocked.CompareExchange(ref _applyStarted, 1, 0) != 0)
        {
            await _applyCompletion.Task.ConfigureAwait(false);
            return;
        }

        try
        {
            await _applyAsync(snapshot).ConfigureAwait(false);
            _applyCompletion.TrySetResult();
        }
#pragma warning disable CA1031 // Every apply caller must observe the same structural failure.
        catch (Exception exception)
#pragma warning restore CA1031
        {
            _applyCompletion.TrySetException(exception);
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
            added = false;
            if (!_terminalResponseIds.Contains(response.ResponseId))
            {
                if (_terminalIdBytes > VoiceProtocolConstants.MaxTrackedIdentityBytes - EstimatedTerminalIdBytes)
                {
                    throw new VoiceResourceExhaustedException("connection terminal identity tracking bytes");
                }

                _resourceGovernor.ReserveIdentityBytes(EstimatedTerminalIdBytes);
                added = _terminalResponseIds.Add(response.ResponseId);
                _terminalIdBytes = checked(_terminalIdBytes + EstimatedTerminalIdBytes);
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

    public VoiceResponseTermination CaptureResponseForConnectionShutdown(
        VoiceResponse response,
        string terminalKind)
    {
        try
        {
            return TryTerminateResponse(response, terminalKind);
        }
        catch (VoiceResourceExhaustedException)
        {
            // Connection shutdown is already fail-closed. Keep structural
            // terminalization independent of normal retained-identity admission.
            var captured = response.TryCaptureConnectionShutdown();
            var turnTermination = captured
                ? _turnLease.TryDetach(response, terminalKind)
                : VoiceTurnTermination.None(terminalKind);
            return new VoiceResponseTermination(
                IsNewTerminal: captured,
                terminalKind,
                response,
                turnTermination);
        }
    }

    public static Task ApplyResponseTermination(VoiceResponseTermination termination)
    {
        if (!termination.IsNewTerminal)
        {
            return Task.CompletedTask;
        }

        termination.Response.ReleaseOutputBuffers();
        if (!termination.Response.IsWireOpened)
        {
            termination.Response.ReleaseRetainedIdentities();
        }

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
            if (_terminalIdBytes > 0)
            {
                _resourceGovernor.ReleaseIdentityBytes(_terminalIdBytes);
            }
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

        _selectCloseCode(1006);
        bool closeOwners;
        lock (_sync)
        {
            closeOwners = _request is not null;
            if (!closeOwners)
            {
                _beginStarted = 1;
                _deadlineExpiredBeforeBegin = true;
                _structuralOwnersClosed = true;
            }
        }
        if (closeOwners)
        {
            await CloseStructuralOwnersAsync().ConfigureAwait(false);
        }
        else
        {
            CancelRuntime();
            AbortBestEffort();
        }
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

    private static void ObserveFaults(Task task) =>
        _ = task.ContinueWith(
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
