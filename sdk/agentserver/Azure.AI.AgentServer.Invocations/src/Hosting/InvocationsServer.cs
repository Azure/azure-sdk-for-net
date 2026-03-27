// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// One-line entry point for running an Invocations protocol server.
/// Creates the builder, registers the Invocations protocol with the specified handler,
/// builds, and runs the server.
/// </summary>
public static class InvocationsServer
{
    /// <summary>
    /// Builds and runs an Invocations protocol server using the specified handler type.
    /// This is the fastest path to a working server — one line of code.
    /// </summary>
    /// <typeparam name="THandler">
    /// The <see cref="InvocationHandler"/> implementation to handle invocations.
    /// </typeparam>
    /// <param name="args">Optional command-line arguments.</param>
    /// <param name="configure">Optional callback to further configure the builder before running.</param>
    public static void Run<THandler>(
        string[]? args = null,
        Action<AgentHostBuilder>? configure = null)
        where THandler : InvocationHandler
    {
        var builder = AgentHost.CreateBuilder(args);
        builder.AddInvocations<THandler>();
        configure?.Invoke(builder);
        builder.Build().Run();
    }
}
