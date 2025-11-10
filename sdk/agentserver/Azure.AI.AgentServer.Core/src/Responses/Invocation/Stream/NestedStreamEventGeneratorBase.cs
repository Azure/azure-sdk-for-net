// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Invocation.Stream;

/// <summary>
/// Base class for nested stream event generators.
/// </summary>
/// <typeparam name="TAggregate">The type of the aggregate object.</typeparam>
public abstract class NestedStreamEventGeneratorBase<TAggregate>
    : INestedStreamEventGenerator<TAggregate>
    where TAggregate : class
{
    /// <summary>
    /// Gets or initializes the sequence number generator for events.
    /// </summary>
    required public ISequenceNumber Seq { get; init; }

    /// <summary>
    /// Gets or initializes the cancellation token for the generation process.
    /// </summary>
    public CancellationToken CancellationToken { get; init; } = CancellationToken.None;

    /// <summary>
    /// Generates groups of nested events with their aggregates.
    /// </summary>
    /// <returns>An async enumerable of nested event groups.</returns>
    public abstract IAsyncEnumerable<NestedEventsGroup<TAggregate>> Generate();
}
