// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using global::A2A;
using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.A2A;

/// <summary>
/// Extension methods for registering native A2A applications on an <see cref="AgentHostBuilder"/>.
/// </summary>
public static class A2ABuilderExtensions
{
    /// <summary>Registers a native A2A agent handler on the shared host.</summary>
    /// <typeparam name="THandler">The native agent handler type.</typeparam>
    /// <param name="builder">The host builder.</param>
    /// <param name="agentCard">The native public agent card.</param>
    /// <param name="configure">Optional native server configuration.</param>
    /// <returns>The host builder for chaining.</returns>
    /// <remarks>
    /// Registers <typeparamref name="THandler"/> as a singleton. An explicitly registered native
    /// task store is preserved; otherwise the host selects Foundry storage when hosted and
    /// in-memory storage locally.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="builder"/> or <paramref name="agentCard"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="InvalidOperationException">A2A is already registered on this builder.</exception>
    public static AgentHostBuilder AddA2A<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler>(
        this AgentHostBuilder builder,
        AgentCard agentCard,
        Action<A2AServerOptions>? configure = null)
        where THandler : class, IAgentHandler
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(agentCard);
        builder.RegisterProtocol("A2A", endpoints => endpoints.MapFoundryA2A());
        builder.Services.AddFoundryA2A<THandler>(agentCard, configure);
        return builder;
    }

    /// <summary>Registers an existing native request handler on the shared host.</summary>
    /// <param name="builder">The host builder.</param>
    /// <param name="agentCard">The native public agent card.</param>
    /// <param name="requestHandler">The existing native request handler.</param>
    /// <returns>The host builder for chaining.</returns>
    /// <remarks>
    /// Preserves the handler's storage and native configuration. The application owns the
    /// supplied handler and is responsible for disposing it when necessary.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="builder"/>, <paramref name="agentCard"/>, or <paramref name="requestHandler"/>
    /// is <see langword="null"/>.
    /// </exception>
    /// <exception cref="InvalidOperationException">A2A is already registered on this builder.</exception>
    public static AgentHostBuilder AddA2A(
        this AgentHostBuilder builder,
        AgentCard agentCard,
        IA2ARequestHandler requestHandler)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(agentCard);
        ArgumentNullException.ThrowIfNull(requestHandler);
        builder.RegisterProtocol("A2A", endpoints => endpoints.MapFoundryA2A());
        builder.Services.AddFoundryA2A(agentCard, requestHandler);
        return builder;
    }
}
