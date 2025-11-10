// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Contracts.Generated.OpenAI;

namespace Azure.AI.AgentServer.Responses.Invocation.Stream;

/// <summary>
/// Defines a generator for nested stream events with aggregation support.
/// </summary>
/// <typeparam name="TAggregate">The type of the aggregate object.</typeparam>
public interface INestedStreamEventGenerator<TAggregate> where TAggregate : class
{
    /// <summary>
    /// Generates groups of nested events with their aggregates.
    /// </summary>
    /// <returns>An async enumerable of nested event groups.</returns>
    IAsyncEnumerable<NestedEventsGroup<TAggregate>> Generate();
}

/// <summary>
/// Represents a group of nested events with an aggregate factory.
/// </summary>
/// <typeparam name="T">The type of the aggregate object.</typeparam>
public class NestedEventsGroup<T> where T : class
{
    /// <summary>
    /// Gets or initializes the factory function to create the aggregate object.
    /// </summary>
    required public Func<T> CreateAggregate { get; init; }

    /// <summary>
    /// Gets or initializes the async enumerable of response stream events.
    /// </summary>
    required public IAsyncEnumerable<ResponseStreamEvent> Events { get; init; }
}
