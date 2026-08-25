// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// A late-bound holder for the process <see cref="TaskEngine"/>. The resilient-task builder — and
/// the <see cref="TaskDefinition{TInput, TOutput}"/> instances it returns — are created during
/// <c>AddResilientTasks</c>, before the DI container (and therefore the engine) exists. This holder
/// is populated when the <see cref="TaskEngine"/> singleton is constructed (always before any task
/// runs, because invocation flows through the engine), letting a task definition resolve the engine
/// at invocation time without forcing callers to build the container first.
/// </summary>
internal sealed class TaskEngineAccessor
{
    /// <summary>The process task engine, set once the container is built.</summary>
    public TaskEngine? Engine { get; set; }

    /// <summary>Returns the engine, or throws if it has not been populated yet.</summary>
    public TaskEngine Require()
        => Engine ?? throw new InvalidOperationException(
            "The task engine is not available yet. A task definition can only be run once the " +
            "application container that hosts the resilient-task services has been built.");
}
