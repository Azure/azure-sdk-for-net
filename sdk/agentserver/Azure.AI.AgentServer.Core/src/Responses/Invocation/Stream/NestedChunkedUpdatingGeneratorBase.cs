// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Common;

namespace Azure.AI.AgentServer.Responses.Invocation.Stream;

/// <summary>
/// Base class for nested stream event generators that process chunked updates.
/// </summary>
/// <typeparam name="TAggregate">The type of the aggregate object.</typeparam>
/// <typeparam name="TUpdate">The type of update items.</typeparam>
public abstract class NestedChunkedUpdatingGeneratorBase<TAggregate, TUpdate> : NestedStreamEventGeneratorBase<TAggregate>
    where TAggregate : class
{
    /// <summary>
    /// Gets or initializes the async enumerable of updates to process.
    /// </summary>
    required public IAsyncEnumerable<TUpdate> Updates { get; init; }

    /// <summary>
    /// Gets the sequence number generator for groups.
    /// </summary>
    protected ISequenceNumber GroupSeq { get; } = ISequenceNumber.Default;

    private bool IsChanged(TUpdate? previous, TUpdate? current) => previous != null && current != null && Changed(previous, current);

    /// <summary>
    /// Determines whether two consecutive updates represent a change.
    /// </summary>
    /// <param name="previous">The previous update.</param>
    /// <param name="current">The current update.</param>
    /// <returns>True if the updates represent a change; otherwise, false.</returns>
    protected abstract bool Changed(TUpdate previous, TUpdate current);

    /// <summary>
    /// Creates a nested events group from a chunk of updates.
    /// </summary>
    /// <param name="updateGroup">The group of updates to process.</param>
    /// <returns>A nested events group.</returns>
    protected abstract NestedEventsGroup<TAggregate> CreateGroup(IAsyncEnumerable<TUpdate> updateGroup);

    /// <summary>
    /// Generates groups of nested events by chunking updates.
    /// </summary>
    /// <returns>An async enumerable of nested event groups.</returns>
    public override async IAsyncEnumerable<NestedEventsGroup<TAggregate>> Generate()
    {
        var chunkedUpdates = Updates.ChunkOnChange(IsChanged, cancellationToken: CancellationToken);
        await foreach (var updateGroup in chunkedUpdates.WithCancellation(CancellationToken).ConfigureAwait(false))
        {
            yield return CreateGroup(updateGroup);
        }
    }
}
