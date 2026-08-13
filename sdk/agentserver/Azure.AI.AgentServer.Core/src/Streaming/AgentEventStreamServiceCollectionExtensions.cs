// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// Registration entry point for the event-streaming feature. Replaces Python's
/// module-global <c>streams</c> singleton with an injectable
/// <see cref="AgentEventStreamRegistry"/>. A backing is selected once at startup via
/// <see cref="AgentEventStreamOptions"/>; the default (no configuration) is the
/// in-memory live backing.
/// </summary>
public static class AgentEventStreamServiceCollectionExtensions
{
    /// <summary>
    /// Adds the event-stream registry, selecting and configuring the single backing
    /// for the process. Safe to call more than once: the first registration wins
    /// (<see cref="Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddSingleton{TService}(IServiceCollection, System.Func{IServiceProvider, TService})"/>
    /// semantics), so a composition where more than one component (e.g. a protocol SDK and a
    /// consumer) registers the streams selects the backing by configuration/first-registration
    /// rather than throwing on registration order.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">An optional configurator that selects the backing; defaults to in-memory live.</param>
    /// <returns>The same service collection for chaining.</returns>
    public static IServiceCollection AddAgentEventStreams(
        this IServiceCollection services,
        Action<AgentEventStreamOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        // A single backing is selected once for the process. Registration is first-wins: a later
        // call (from another protocol SDK or the consumer) is a harmless no-op rather than an
        // order-dependent throw, so configuration decides the backing regardless of call order.
        var options = new AgentEventStreamOptions();
        configure?.Invoke(options);

        services.TryAddSingleton<AgentEventStreamRegistry>(_ => new InMemoryEventStreamRegistry(options));
        return services;
    }
}
