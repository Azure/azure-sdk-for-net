// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// An immutable descriptor of a registered task: its name, input/output types,
/// the handler delegate, whether it is multi-turn/steerable, and its per-task
/// options. The wire <c>source.name</c> routes back to the registration by name.
/// </summary>
internal sealed class TaskRegistration
{
    public TaskRegistration(
        string name,
        Type inputType,
        Type outputType,
        Delegate handler,
        bool multiTurn,
        bool steerable,
        TaskRegistrationOptions? options)
    {
        Name = name;
        InputType = inputType;
        OutputType = outputType;
        Handler = handler;
        MultiTurn = multiTurn;
        Steerable = steerable;
        Options = options;
    }

    /// <summary>The unique task name (routes from wire <c>source.name</c>).</summary>
    public string Name { get; }

    /// <summary>The handler input type.</summary>
    public Type InputType { get; }

    /// <summary>The handler output type.</summary>
    public Type OutputType { get; }

    /// <summary>The handler delegate (<c>Func&lt;TaskContext&lt;TInput&gt;, CancellationToken, Task&lt;TOutput&gt;&gt;</c>).</summary>
    public Delegate Handler { get; }

    /// <summary>Whether the task is multi-turn.</summary>
    public bool MultiTurn { get; }

    /// <summary>Whether the multi-turn task accepts steering input.</summary>
    public bool Steerable { get; }

    /// <summary>The per-task registration options, if any.</summary>
    public TaskRegistrationOptions? Options { get; }

    /// <summary>
    /// A type-erased recovery dispatcher that resumes a persisted record on the engine
    /// with the registration's compile-time input/output types. Set by the builder.
    /// </summary>
    public Func<object, Serialization.TaskRecord, System.Threading.Tasks.Task>? RecoverDispatch { get; set; }
}
