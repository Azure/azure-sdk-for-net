// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using global::A2A;
using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.A2A;

/// <summary>Convenience entry points for running a native A2A application in Foundry.</summary>
public static class A2AAgentServer
{
    /// <summary>Builds and runs a host for a native agent handler.</summary>
    /// <typeparam name="THandler">The native agent handler type.</typeparam>
    /// <param name="agentCard">The native public agent card.</param>
    /// <param name="args">Optional command-line arguments.</param>
    /// <param name="configure">Optional host configuration.</param>
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
