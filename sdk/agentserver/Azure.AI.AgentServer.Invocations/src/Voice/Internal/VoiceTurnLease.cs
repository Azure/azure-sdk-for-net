// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

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
    Task? CustomerTask)
{
    public static VoiceTurnTermination None(string terminalKind) =>
        new(false, terminalKind, default, null, null);
}

/// <summary>
/// Current state of the shared active turn slot.
/// </summary>
internal sealed class VoiceTurnLeaseState
{
    private readonly TaskCompletionSource _completion =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource? _release;
    private readonly Activity? _activity;

    public VoiceTurnLeaseState(
        VoiceTurnToken token,
        VoiceResponse response,
        string kind,
        TaskCompletionSource? release,
        Activity? activity)
    {
        Token = token;
        Response = response;
        Kind = kind;
        _release = release;
        _activity = activity;
    }

    public VoiceTurnToken Token { get; }

    public VoiceResponse Response { get; }

    public string Kind { get; }

    public Task Completion => _completion.Task;

    public Task? CustomerTask { get; private set; }

    internal void SetCustomerTask(Task customerTask) => CustomerTask = customerTask;

    internal void ClearCustomerTask(Task customerTask)
    {
        if (ReferenceEquals(CustomerTask, customerTask))
        {
            CustomerTask = null;
        }
    }

    internal void Complete(string terminalKind)
    {
        StopActivity(_activity, terminalKind);
        _completion.TrySetResult();
        _release?.TrySetResult();
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
    private VoiceTurnLeaseState? _current;
    private long _nextGeneration;

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
            _current = new VoiceTurnLeaseState(token, response, kind, release, activity);
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

        terminal.Complete(terminalKind);
        return new VoiceTurnTermination(
            true,
            terminalKind,
            terminal.Token,
            terminal.Response,
            terminal.CustomerTask);
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
