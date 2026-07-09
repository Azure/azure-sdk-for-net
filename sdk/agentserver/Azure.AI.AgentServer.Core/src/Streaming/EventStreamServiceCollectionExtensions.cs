// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// Registration entry point for the event-streaming feature. Replaces Python's
/// module-global <c>streams</c> singleton with an injectable
/// <see cref="IEventStreamRegistry"/>. A backing is selected once at startup via
/// <see cref="EventStreamOptions"/>; the default (no configuration) is the
/// in-memory live backing.
/// </summary>
public static class EventStreamServiceCollectionExtensions
{
    /// <summary>
    /// Adds the event-stream registry, selecting and configuring the single backing
    /// for the process.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">An optional configurator that selects the backing; defaults to in-memory live.</param>
    /// <returns>The same service collection for chaining.</returns>
    public static IServiceCollection AddEventStreams(
        this IServiceCollection services,
        Action<EventStreamOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        var options = new EventStreamOptions();
        configure?.Invoke(options);

        services.TryAddSingleton<IEventStreamRegistry>(_ => new EventStreamRegistry(options));
        return services;
    }
}
