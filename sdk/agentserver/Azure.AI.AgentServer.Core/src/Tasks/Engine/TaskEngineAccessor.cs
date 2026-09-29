// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// A late-bound holder for the process <see cref="TaskEngine"/>. The resilient-task builder — and
/// the <see cref="TaskDefinition{TInput, TOutput}"/> instances it returns — are created during
/// <c>AddResilientTasks</c>, before the DI container (and therefore the engine) exists. This holder
/// is populated when the <see cref="TaskEngine"/> singleton is first resolved, either during host
/// startup or when a keyed task definition is resolved from the service provider.
/// </summary>
internal sealed class TaskEngineAccessor
{
    private TaskEngine? _engine;

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
        => Volatile.Read(ref _engine) ?? throw new InvalidOperationException(
            "The task engine is not available yet. A task definition can only be run once the " +
            "application host has started, or after the definition has been resolved from its " +
            "service provider.");
}
