// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Provides consumer access to the event stream associated with one task input.
/// </summary>
public class TaskStream
{
    private readonly TaskStreamState? _state;

    /// <summary>Initializes an instance for mocking.</summary>
    protected TaskStream()
    {
    }

    internal TaskStream(TaskStreamState state) => _state = state;

    private TaskStreamState State => _state
        ?? throw new System.InvalidOperationException(
            "TaskStream was not initialized by the task engine.");

    /// <summary>
    /// Subscribes to events for this task input.
    /// </summary>
    /// <param name="afterEventId">The event id after which replay begins, or <see langword="null"/>.</param>
    /// <param name="cancellationToken">A token to stop iteration.</param>
    /// <returns>An asynchronous sequence of event items.</returns>
    public virtual async IAsyncEnumerable<SseItem<string>> Subscribe(
        string? afterEventId = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        Streaming.AgentEventStream stream =
            await State.GetStreamAsync(cancellationToken).ConfigureAwait(false);
        await foreach (SseItem<string> item in stream
            .Subscribe(afterEventId, cancellationToken)
            .ConfigureAwait(false))
        {
            yield return item;
        }
    }

    /// <summary>Gets the most recently assigned event id.</summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The most recently assigned event id, or <see langword="null"/>.</returns>
    public virtual async ValueTask<string?> GetLastEventIdAsync(
        CancellationToken cancellationToken = default)
    {
        Streaming.AgentEventStream stream =
            await State.GetStreamAsync(cancellationToken).ConfigureAwait(false);
        return await stream.GetLastEventIdAsync(cancellationToken).ConfigureAwait(false);
    }
}
