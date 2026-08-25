// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Provides producer access to the event stream associated with one task input.
/// </summary>
public class TaskStreamWriter
{
    private readonly TaskStreamState? _state;

    /// <summary>Initializes an instance for mocking.</summary>
    protected TaskStreamWriter()
    {
    }

    internal TaskStreamWriter(TaskStreamState state) => _state = state;

    private TaskStreamState State => _state
        ?? throw new System.InvalidOperationException(
            "TaskStreamWriter was not initialized by the task engine.");

    /// <summary>Publishes one event to this task input's stream.</summary>
    /// <param name="item">The event item to publish.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the event has been published.</returns>
    public virtual async ValueTask EmitAsync(
        SseItem<string> item,
        CancellationToken cancellationToken = default)
    {
        Streaming.AgentEventStream stream =
            await State.GetStreamAsync(cancellationToken).ConfigureAwait(false);
        await stream.EmitAsync(item, cancellationToken: cancellationToken).ConfigureAwait(false);
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
