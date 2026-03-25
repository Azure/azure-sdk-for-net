// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Hosting;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// One-line entry point for running a Responses protocol server.
/// Creates the builder, registers the Responses protocol with the specified handler,
/// builds, and runs the server.
/// </summary>
public static class ResponsesServer
{
    /// <summary>
    /// Builds and runs a Responses protocol server using the specified handler type.
    /// This is the fastest path to a working server — one line of code.
    /// </summary>
    /// <typeparam name="THandler">
    /// The <see cref="IResponseHandler"/> implementation to handle responses.
    /// </typeparam>
    /// <param name="args">Optional command-line arguments.</param>
    /// <param name="configure">Optional callback to further configure the builder before running.</param>
    public static void Run<THandler>(
        string[]? args = null,
        Action<AgentHostBuilder>? configure = null)
        where THandler : class, IResponseHandler
    {
        var builder = AgentHost.CreateBuilder(args);
        builder.AddResponses<THandler>();
        configure?.Invoke(builder);
        builder.Build().Run();
    }
}
