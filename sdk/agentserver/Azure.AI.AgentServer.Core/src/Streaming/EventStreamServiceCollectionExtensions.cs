// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// Registration entry point for the event-streaming feature. Replaces Python's
/// module-global <c>streams</c> singleton with an injectable
/// <see cref="EventStreamRegistry"/>. A backing is selected once at startup via
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

        // A single backing is selected once for the process. TryAddSingleton would silently
        // discard a second call's configuration, so detect a repeated configuring call and fail
        // loudly rather than letting the developer's intended backing be dropped without warning.
        bool alreadyRegistered = services.Any(d => d.ServiceType == typeof(EventStreamRegistry));
        if (alreadyRegistered && configure is not null)
        {
            throw new InvalidOperationException(
                "AddEventStreams has already been called; the event-stream backing is selected once " +
                "per process. Remove the duplicate registration or its configuration.");
        }

        var options = new EventStreamOptions();
        configure?.Invoke(options);

        services.TryAddSingleton<EventStreamRegistry>(_ => new InMemoryEventStreamRegistry(options));
        return services;
    }
}
