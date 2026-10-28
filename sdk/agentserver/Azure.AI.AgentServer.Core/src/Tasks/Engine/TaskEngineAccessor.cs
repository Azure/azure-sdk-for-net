// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// A late-bound holder for the host's <see cref="TaskEngine"/>. The resilient-task builder — and
/// the <see cref="TaskDefinition{TInput, TOutput}"/> instances it returns — are created during
/// <c>AddResilientTasks</c>, before the DI container (and therefore the engine) exists. This holder
/// is populated when the enabled host resolves the <see cref="TaskEngine"/> during startup.
/// Resolving a keyed task definition is deliberately lazy and never initializes storage.
/// </summary>
internal sealed class TaskEngineAccessor
{
    private static readonly AsyncLocal<RecoveryHandlerScope?> s_recoveryHandlerScope = new();
    private static readonly AsyncLocal<ProtocolScope?> s_protocolScope = new();
    private readonly ResilientTaskEnablementState _enablement;
    private TaskEngine? _engine;

    public TaskEngineAccessor(ResilientTaskEnablementState? enablement = null)
    {
        // Direct internal test hosts construct an accessor without DI and already own an engine.
        _enablement = enablement ?? new ResilientTaskEnablementState(enabled: true, ready: true);
    }

    /// <summary>Binds the process task engine exactly once.</summary>
    public void Bind(TaskEngine engine)
    {
        ArgumentNullException.ThrowIfNull(engine);
        TaskEngine? existing = Interlocked.CompareExchange(ref _engine, engine, null);
        if (existing is not null && !ReferenceEquals(existing, engine))
        {
            throw new InvalidOperationException(
                "The resilient-task services were resolved from more than one service provider. " +
                "Build and use a single application service provider.");
        }
    }

    /// <summary>Returns the engine, or throws if it has not been populated yet.</summary>
    public TaskEngine Require()
    {
        ProtocolScope? scope = s_protocolScope.Value;
        if (scope is not null
            && (!scope.Enabled || !ReferenceEquals(scope.Enablement, _enablement)))
        {
            throw new ResilientTaskException(
                ResilientTaskErrorCode.NotEnabled,
                "Resilient tasks are disabled for this protocol.");
        }

        if (!_enablement.IsConfigured)
        {
            throw new ResilientTaskException(
                ResilientTaskErrorCode.NotEnabled,
                "Resilient tasks are disabled for this host. Call SetResilientTasksEnabled() before host startup.");
        }

        TaskEngine? engine = Volatile.Read(ref _engine);
        if (!_enablement.IsReady
            && s_recoveryHandlerScope.Value?.Allows(engine) != true)
        {
            throw new InvalidOperationException(
                "The resilient-task runtime is not ready. Task definitions can run only after " +
                "host startup recovery has completed and before host shutdown begins.");
        }

        return engine ?? throw new InvalidOperationException(
            "The task engine is not available yet. A task definition can only be run after the " +
            "enabled application host has started.");
    }

    internal static IDisposable EnterRecoveryHandlerScope(TaskEngine engine)
    {
        var scope = new RecoveryHandlerScope(engine, s_recoveryHandlerScope.Value);
        s_recoveryHandlerScope.Value = scope;
        return scope;
    }

    internal static IDisposable EnterProtocolScope(ResilientTaskEnablementState? enablement, bool enabled)
    {
        var scope = new ProtocolScope(enablement, enabled, s_protocolScope.Value);
        s_protocolScope.Value = scope;
        return scope;
    }

    private sealed class ProtocolScope(
        ResilientTaskEnablementState? enablement,
        bool enabled,
        ProtocolScope? priorScope) : IDisposable
    {
        public ResilientTaskEnablementState? Enablement { get; } = enablement;

        public bool Enabled { get; } = enabled;

        public void Dispose()
        {
            if (ReferenceEquals(s_protocolScope.Value, this))
            {
                s_protocolScope.Value = priorScope;
            }
        }
    }

    private sealed class RecoveryHandlerScope(
        TaskEngine engine,
        RecoveryHandlerScope? priorScope) : IDisposable
    {
        private int _active = 1;
        private int _disposed;

        public bool Allows(TaskEngine? candidate)
            => Volatile.Read(ref _active) != 0
                && ReferenceEquals(engine, candidate);

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 0)
            {
                Volatile.Write(ref _active, 0);
                if (ReferenceEquals(s_recoveryHandlerScope.Value, this))
                {
                    s_recoveryHandlerScope.Value = priorScope;
                }
            }
        }
    }
}
