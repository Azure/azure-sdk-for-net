// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Invocations.Internal;

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// Generation identity for one occupancy of the connection's active turn slot.
/// </summary>
internal readonly record struct VoiceTurnToken(long Generation, string ResponseId);

/// <summary>
/// Result returned when a reactive or proactive turn occupies the shared slot.
/// </summary>
internal readonly record struct VoiceTurnActivation(VoiceTurnToken Token);

/// <summary>
/// Immutable terminal capture returned by the active turn owner.
/// </summary>
internal readonly record struct VoiceTurnTermination(
    bool IsNewTerminal,
    string TerminalKind,
    VoiceTurnToken Token,
    VoiceResponse? Response,
    Task? CustomerTask,
    VoiceTurnLeaseState? LeaseState)
{
    public static VoiceTurnTermination None(string terminalKind) =>
        new(false, terminalKind, default, null, null, null);

    internal Task Complete() => LeaseState?.Complete(TerminalKind) ?? Task.CompletedTask;
}

/// <summary>
/// Current state of the shared active turn slot.
/// </summary>
internal sealed class VoiceTurnLeaseState
{
    private readonly object _completionSync = new();
    private readonly TaskCompletionSource _completion =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource? _release;
    private readonly TelemetryCallbackDispatcher _telemetryDispatcher;
    private Activity? _activity;
    private Task? _terminalCompletion;

    public VoiceTurnLeaseState(
        VoiceTurnToken token,
        VoiceResponse response,
        string kind,
        TaskCompletionSource? release,
        Activity? activity,
        TelemetryCallbackDispatcher telemetryDispatcher)
    {
        Token = token;
        Response = response;
        Kind = kind;
        _release = release;
        _activity = activity;
        _telemetryDispatcher = telemetryDispatcher;
    }

    public VoiceTurnToken Token { get; }

    public VoiceResponse Response { get; }

    public string Kind { get; }

    public Task Completion => _completion.Task;

    public Task? CustomerTask { get; private set; }

    internal void SetCustomerTask(Task customerTask) => CustomerTask = customerTask;

    internal void SetActivity(Activity activity) => _activity = activity;

    internal void ClearCustomerTask(Task customerTask)
    {
        if (ReferenceEquals(CustomerTask, customerTask))
        {
            CustomerTask = null;
        }
    }

    internal Task Complete(string terminalKind)
    {
        lock (_completionSync)
        {
            if (_terminalCompletion is not null)
            {
                return _terminalCompletion;
            }

            _completion.TrySetResult();
            _release?.TrySetResult();
            _terminalCompletion = StopActivityAsync(_telemetryDispatcher, _activity, terminalKind);
            return _terminalCompletion;
        }
    }

    private static Task StopActivityAsync(
        TelemetryCallbackDispatcher telemetryDispatcher,
        Activity? activity,
        string terminalKind)
    {
        if (activity is null)
        {
            return Task.CompletedTask;
        }

        return InvocationsTelemetry.StopActivityAsync(
            telemetryDispatcher,
            activity,
            () => StopActivity(activity, terminalKind));
    }

    private static void StopActivity(Activity? activity, string terminalKind)
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
}

/// <summary>
/// The single owner of the active reactive/proactive turn slot. A generation
/// token prevents old callbacks from mutating a replacement turn.
/// </summary>
internal sealed class VoiceTurnLease
{
    private readonly object _sync = new();
    private readonly TelemetryCallbackDispatcher _telemetryDispatcher;
    private VoiceTurnLeaseState? _current;
    private long _nextGeneration;

    public VoiceTurnLease(TelemetryCallbackDispatcher? telemetryDispatcher = null)
    {
        _telemetryDispatcher = telemetryDispatcher ?? new TelemetryCallbackDispatcher();
    }

    public VoiceTurnLeaseState? Current
    {
        get
        {
            lock (_sync)
            {
                return _current;
            }
        }
    }

    public VoiceTurnActivation Activate(
        VoiceResponse response,
        string kind,
        TaskCompletionSource? release,
        Activity? activity)
    {
        ArgumentNullException.ThrowIfNull(response);
        ArgumentException.ThrowIfNullOrEmpty(kind);

        lock (_sync)
        {
            if (_current is not null)
            {
                throw new InvalidOperationException("Another voice turn is already active.");
            }

            var generation = checked(++_nextGeneration);
            var token = new VoiceTurnToken(generation, response.ResponseId);
            _current = new VoiceTurnLeaseState(
                token,
                response,
                kind,
                release,
                activity,
                _telemetryDispatcher);
            return new VoiceTurnActivation(token);
        }
    }

    public bool IsCurrent(VoiceTurnToken token)
    {
        lock (_sync)
        {
            return _current?.Token == token;
        }
    }

    public bool IsCurrent(VoiceResponse response)
    {
        lock (_sync)
        {
            return ReferenceEquals(_current?.Response, response);
        }
    }

    public bool TrySetCustomerTask(VoiceTurnToken token, Task customerTask)
    {
        ArgumentNullException.ThrowIfNull(customerTask);
        lock (_sync)
        {
            if (_current?.Token != token)
            {
                return false;
            }

            _current.SetCustomerTask(customerTask);
            return true;
        }
    }

    public bool TrySetActivity(VoiceTurnToken token, Activity activity)
    {
        ArgumentNullException.ThrowIfNull(activity);
        lock (_sync)
        {
            if (_current?.Token != token)
            {
                return false;
            }

            _current.SetActivity(activity);
            return true;
        }
    }

    public void ClearCustomerTask(VoiceTurnToken token, Task customerTask)
    {
        lock (_sync)
        {
            if (_current?.Token == token)
            {
                _current.ClearCustomerTask(customerTask);
            }
        }
    }

    public VoiceTurnTermination TryTerminate(VoiceResponse response, string terminalKind)
    {
        var termination = TryDetach(response, terminalKind);
        _ = termination.Complete();
        return termination;
    }

    public VoiceTurnTermination TryDetach(VoiceResponse response, string terminalKind)
    {
        ArgumentNullException.ThrowIfNull(response);
        ArgumentException.ThrowIfNullOrEmpty(terminalKind);

        VoiceTurnLeaseState? terminal;
        lock (_sync)
        {
            if (!ReferenceEquals(_current?.Response, response))
            {
                return VoiceTurnTermination.None(terminalKind);
            }

            terminal = _current;
            _current = null;
        }

        return new VoiceTurnTermination(
            true,
            terminalKind,
            terminal.Token,
            terminal.Response,
            terminal.CustomerTask,
            terminal);
    }

    public VoiceTurnTermination TryTerminateCurrent(string terminalKind)
    {
        ArgumentException.ThrowIfNullOrEmpty(terminalKind);

        VoiceTurnLeaseState? current;
        lock (_sync)
        {
            current = _current;
        }

        return current is null
            ? VoiceTurnTermination.None(terminalKind)
            : TryTerminate(current.Response, terminalKind);
    }
}
