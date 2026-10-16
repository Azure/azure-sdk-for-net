// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>Per-container runtime gate shared by task definitions and host startup.</summary>
internal sealed class ResilientTaskEnablementState
{
    private int _configured;
    private int _ready;

    public ResilientTaskEnablementState(
        bool enabled = false,
        bool ready = false)
    {
        _configured = enabled ? 1 : 0;
        _ready = ready ? 1 : 0;
    }

    public bool IsConfigured => Volatile.Read(ref _configured) != 0;

    public bool IsReady => Volatile.Read(ref _ready) != 0;

    public void SetConfigured(bool enabled)
    {
        Volatile.Write(ref _configured, enabled ? 1 : 0);
        if (!enabled)
        {
            MarkStopped();
        }
    }

    public void MarkReady() => Volatile.Write(ref _ready, 1);

    public void MarkStopped() => Volatile.Write(ref _ready, 0);
}
