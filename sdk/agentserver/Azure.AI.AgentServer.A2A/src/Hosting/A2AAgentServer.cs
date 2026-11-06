// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using global::A2A;
using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.A2A;

/// <summary>
/// Entry points for running a native A2A application with Foundry hosting.
/// </summary>
/// <remarks>
/// Creates the Core host with readiness, telemetry, port configuration, and graceful shutdown.
/// Use <see cref="A2ABuilderExtensions"/> when the application needs to compose protocols or
/// configure services before building the host.
/// </remarks>
public static class A2AAgentServer
{
    /// <summary>Builds and runs a host for a native agent handler.</summary>
    /// <typeparam name="THandler">The native agent handler type.</typeparam>
    /// <param name="agentCard">The native public agent card.</param>
    /// <param name="args">Optional command-line arguments.</param>
    /// <param name="configure">Optional host configuration.</param>
    /// <remarks>
    /// The handler is registered as a singleton and must support concurrent requests.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="agentCard"/> is <see langword="null"/>.</exception>
    public static void Run<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler>(
        AgentCard agentCard,
        string[]? args = null,
        Action<AgentHostBuilder>? configure = null)
        where THandler : class, IAgentHandler
    {
        var builder = AgentHost.CreateBuilder(args);
        builder.AddA2A<THandler>(agentCard);
        configure?.Invoke(builder);
        builder.Build().Run();
    }

    /// <summary>Builds and runs a host for an existing native request handler.</summary>
    /// <param name="agentCard">The native public agent card.</param>
    /// <param name="requestHandler">The existing native request handler.</param>
    /// <param name="args">Optional command-line arguments.</param>
    /// <param name="configure">Optional host configuration.</param>
    /// <remarks>
    /// The supplied handler retains its storage and is not disposed by the host.
    /// The application owns the handler and any externally constructed dependencies.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="agentCard"/> or <paramref name="requestHandler"/> is <see langword="null"/>.
    /// </exception>
    public static void Run(
        AgentCard agentCard,
        IA2ARequestHandler requestHandler,
        string[]? args = null,
        Action<AgentHostBuilder>? configure = null)
    {
        var builder = AgentHost.CreateBuilder(args);
        builder.AddA2A(agentCard, requestHandler);
        configure?.Invoke(builder);
        builder.Build().Run();
    }
}
