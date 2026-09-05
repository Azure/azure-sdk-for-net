// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Azure.AI.AgentServer.Responses.Internal.Resilience;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

/// <summary>
/// A test-only <see cref="ITaskStore"/> decorator that wraps a real inner store (typically a
/// <see cref="LocalTaskStore"/>) and layers spy/fault-injection over the create path. This lets a
/// test drive the REAL Core resilient-task engine to completion (or to the point at which it makes
/// its first persistence call) while:
/// <list type="bullet">
///   <item>capturing the exact <see cref="TaskCreateRequest"/> the engine handed to the store
///     (task name via <c>Source[SourceName]</c>, chain/task id, wire payload) for post-hoc
///     assertions;</item>
///   <item>optionally short-circuiting the create call by throwing a caller-supplied exception
///     (e.g. an <see cref="Azure.AI.AgentServer.Core.Tasks.ResilientTaskException"/> to simulate a
///     Core conflict/precondition failure, or a plain <see cref="InvalidOperationException"/> to
///     simulate a task-store infra failure).</item>
/// </list>
/// All other <see cref="ITaskStore"/> methods delegate transparently to the inner store, so the
/// engine's subsequent reads/patches/deletes on the record behave identically to production.
/// </summary>
internal sealed class SpyTaskStore : ITaskStore
{
    private readonly ITaskStore _inner;

    public SpyTaskStore(ITaskStore inner)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
    }

    /// <summary>How many times <see cref="CreateAsync"/> has been invoked (before delegation/throw).</summary>
    public int CreateCallCount { get; private set; }

    /// <summary>
    /// The most recent <see cref="TaskCreateRequest"/> handed to <see cref="CreateAsync"/>. Captured
    /// BEFORE the throw/delegate decision so exception-injection tests can still inspect what the
    /// engine attempted to persist.
    /// </summary>
    public TaskCreateRequest? LastCreateRequest { get; private set; }

    /// <summary>
    /// When non-<see langword="null"/>, <see cref="CreateAsync"/> throws this exception instead of
    /// delegating to the inner store. Leave <see langword="null"/> for a pure pass-through spy.
    /// </summary>
    public Exception? ThrowOnCreate { get; set; }

    /// <summary>
    /// The task name pulled from the last create request's <c>source.name</c> field (i.e. the
    /// registered task-definition name — the one-shot vs multi-turn primitive the endpoint dispatched
    /// to). Equivalent to the old <c>FakeTaskInvoker.LastTaskName</c>.
    /// </summary>
    public string? LastTaskName
        => LastCreateRequest?.Source is JsonObject src
            && src.TryGetPropertyValue(TaskWireKeys.SourceName, out var name)
            && name is not null
                ? name.GetValue<string>()
                : null;

    /// <summary>
    /// The last create request's persisted <c>payload.last_input_id</c>, or <see langword="null"/>
    /// when the payload does not carry one (one-shot task with no explicit input id).
    /// </summary>
    public string? LastLastInputId
        => LastCreateRequest?.Payload is JsonObject payload
            && payload.TryGetPropertyValue(TaskWireKeys.PayloadLastInputId, out var lii)
            && lii is not null
                ? lii.GetValue<string>()
                : null;

    /// <summary>
    /// Parses the last create request's <c>payload.input</c> as a <see cref="ResponseRecoveryPayload"/>,
    /// which is the exact wire schema the Responses layer writes via <see cref="ResponseTaskInput"/>.
    /// Returns <see langword="null"/> when there is no captured request or no input slot.
    /// </summary>
    public ResponseRecoveryPayload? LastResponsePayload
    {
        get
        {
            if (LastCreateRequest?.Payload is not JsonObject payload)
            {
                return null;
            }

            if (!payload.TryGetPropertyValue(TaskWireKeys.PayloadInput, out var input) || input is null)
            {
                return null;
            }

            using var doc = JsonDocument.Parse(input.ToJsonString());
            return ResponseRecoveryPayload.FromTaskInput(doc.RootElement);
        }
    }

    public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
    {
        CreateCallCount++;
        LastCreateRequest = request;

        if (ThrowOnCreate is { } ex)
        {
            return Task.FromException<TaskRecord>(ex);
        }

        return _inner.CreateAsync(request, cancellationToken);
    }

    public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
        => _inner.GetAsync(taskId, cancellationToken);

    public Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
        => _inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);

    public Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
        => _inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);

    public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
        => _inner.ListAsync(query, cancellationToken);
}
