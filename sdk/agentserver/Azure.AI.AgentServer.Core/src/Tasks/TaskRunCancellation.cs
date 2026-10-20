// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>Cancellation authority and signal lifetime for one exact input, never its successor.</summary>
internal sealed class TaskRunCancellation
{
    private readonly object _gate = new();
    private Action? _publishCause;
    private bool _requested;
    private bool _sealed;
    private bool _retired;
    private int _signalUsers;

    public CancellationTokenSource Source { get; } = new();

    public void BindCause(Action publishCause)
    {
        lock (_gate)
        {
            if (_sealed)
            {
                return;
            }

            _publishCause = publishCause;
            if (_requested)
            {
                publishCause();
            }
        }
    }

    public Task RequestAsync()
    {
        lock (_gate)
        {
            if (_sealed || _requested)
            {
                // In particular, a callback repeating this request must not await its own signal.
                return Task.CompletedTask;
            }

            _requested = true;
            _publishCause?.Invoke();
            _signalUsers++;
        }

        return SignalAndReleaseAsync();
    }

    public Task SignalAsync()
    {
        lock (_gate)
        {
            if (_retired || Source.IsCancellationRequested)
            {
                return Task.CompletedTask;
            }

            _signalUsers++;
        }

        return SignalAndReleaseAsync();
    }

    public void Signal()
    {
        lock (_gate)
        {
            if (_retired || Source.IsCancellationRequested)
            {
                return;
            }

            _signalUsers++;
        }

        try
        {
            Source.Cancel();
        }
        finally
        {
            ReleaseSignal();
        }
    }

    public void Seal()
    {
        lock (_gate)
        {
            _sealed = true;
            _publishCause = null;
        }
    }

    public void Retire()
    {
        bool dispose;
        lock (_gate)
        {
            if (_retired)
            {
                return;
            }

            _sealed = true;
            _publishCause = null;
            _retired = true;
            dispose = _signalUsers == 0;
        }

        if (dispose)
        {
            Source.Dispose();
        }
    }

    private async Task SignalAndReleaseAsync()
    {
        try
        {
            await Source.CancelAsync().ConfigureAwait(false);
        }
        finally
        {
            ReleaseSignal();
        }
    }

    private void ReleaseSignal()
    {
        bool dispose;
        lock (_gate)
        {
            _signalUsers--;
            dispose = _retired && _signalUsers == 0;
        }

        if (dispose)
        {
            Source.Dispose();
        }
    }
}
