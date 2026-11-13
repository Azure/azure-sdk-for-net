// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Orchestration;

/// <summary>
/// Shared test helper that collects events from an <see cref="IAsyncObserver{T}"/>
/// and signals completion via a <see cref="TaskCompletionSource"/>.
/// </summary>
internal sealed class CollectingObserver : IAsyncObserver<ResponseStreamEvent>
{
    private readonly List<ResponseStreamEvent> _events;
    private readonly TaskCompletionSource _completionTcs;

    public CollectingObserver(List<ResponseStreamEvent> events)
        : this(events, new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously))
    {
    }

    public CollectingObserver(List<ResponseStreamEvent> events, TaskCompletionSource completionTcs)
    {
        _events = events;
        _completionTcs = completionTcs;
    }

    /// <summary>Gets the task that completes when <see cref="OnCompletedAsync"/> is called.</summary>
    public Task Completed => _completionTcs.Task;

    public ValueTask OnNextAsync(ResponseStreamEvent value)
    {
        _events.Add(value);
        return default;
    }

    public ValueTask OnErrorAsync(Exception error)
    {
        _completionTcs.TrySetException(error);
        return default;
    }

    public ValueTask OnCompletedAsync()
    {
        _completionTcs.TrySetResult();
        return default;
    }
}
