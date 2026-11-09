// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Threading;
using Azure.AI.AgentServer.Core.Tasks.Serialization;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>Per-container runtime gate shared by task definitions and host startup.</summary>
internal sealed class ResilientTaskEnablementState
{
    private int _configured;
    private int _explicitlyEnabled;
    private int _ready;
    private readonly ConcurrentDictionary<string, Func<bool>> _protocols = new(StringComparer.Ordinal);

    public ResilientTaskEnablementState(
        bool enabled = false,
        bool ready = false)
    {
        _configured = enabled ? 1 : 0;
        _ready = ready ? 1 : 0;
    }

    public bool IsConfigured => Volatile.Read(ref _configured) != 0;

    public bool IsExplicitlyEnabled => Volatile.Read(ref _explicitlyEnabled) != 0;

    public bool IsReady => Volatile.Read(ref _ready) != 0;

    public void RegisterProtocol(string protocol, Func<bool> enabled)
    {
        if (!_protocols.TryAdd(protocol, enabled))
        {
            throw new InvalidOperationException($"Task protocol '{protocol}' is already registered for this host.");
        }
    }

    public bool IsProtocolEnabled(string protocol)
        => protocol is TaskWireKeys.ProtocolCore or TaskWireKeys.ProtocolInvocations
            ? IsExplicitlyEnabled
            : _protocols.TryGetValue(protocol, out Func<bool>? enabled) && enabled();

    public void SetExplicitlyEnabled(bool enabled)
    {
        Volatile.Write(ref _explicitlyEnabled, enabled ? 1 : 0);
        SetConfigured(enabled);
    }

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
