// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// A descriptor of a registered task: its name, input/output types, handler,
/// multi-turn behavior, steerability resolver, and per-task options. The wire
/// <c>source.name</c> routes back to the registration by name.
/// </summary>
internal sealed class TaskRegistration
{
    private readonly Func<bool> _isSteerable;

    public TaskRegistration(
        string name,
        Type inputType,
        Type outputType,
        Delegate handler,
        bool requiresServiceScope,
        bool multiTurn,
        Func<bool> isSteerable,
        TaskRegistrationOptions? options,
        System.Text.Json.Serialization.Metadata.JsonTypeInfo? inputTypeInfo = null)
    {
        Name = name;
        InputType = inputType;
        OutputType = outputType;
        Handler = handler;
        RequiresServiceScope = requiresServiceScope;
        MultiTurn = multiTurn;
        _isSteerable = isSteerable
            ?? throw new ArgumentNullException(nameof(isSteerable));
        Options = options;
        InputTypeInfo = inputTypeInfo;
    }

    /// <summary>The unique task name (routes from wire <c>source.name</c>).</summary>
    public string Name { get; }

    /// <summary>The handler input type.</summary>
    public Type InputType { get; }

    /// <summary>The handler output type.</summary>
    public Type OutputType { get; }

    /// <summary>
    /// The direct handler delegate, or a scoped handler delegate whose first argument is the
    /// attempt's service provider.
    /// </summary>
    public Delegate Handler { get; }

    /// <summary>Whether each handler attempt requires a fresh dependency-injection scope.</summary>
    public bool RequiresServiceScope { get; }

    /// <summary>Whether the task is multi-turn.</summary>
    public bool MultiTurn { get; }

    /// <summary>Whether the multi-turn task accepts steering input.</summary>
    public bool Steerable => _isSteerable();

    /// <summary>The per-task registration options, if any.</summary>
    public TaskRegistrationOptions? Options { get; }

    /// <summary>
    /// Optional source-generated <see cref="System.Text.Json.Serialization.Metadata.JsonTypeInfo"/>
    /// for the input type, supplied by a Native-AOT / trimming-safe registration overload. When set,
    /// the engine serializes and deserializes the task input through this metadata instead of the
    /// reflection-based serializer. Stored type-erased; the engine casts it back to
    /// <c>JsonTypeInfo&lt;TInput&gt;</c> at each payload boundary. Only the input crosses the
    /// serialization boundary — the framework never serializes the output.
    /// </summary>
    public System.Text.Json.Serialization.Metadata.JsonTypeInfo? InputTypeInfo { get; }

    /// <summary>
    /// A type-erased recovery dispatcher that resumes a persisted record on the engine
    /// with the registration's compile-time input/output types. Set by the builder.
    /// </summary>
    public Func<object, Serialization.TaskRecord, System.Threading.Tasks.Task>? RecoverDispatch { get; set; }
}
