// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Hosting;

/// <summary>
/// Static entry point for creating and running agent servers.
/// Provides <see cref="CreateBuilder"/> for composable Tier 2 usage
/// and <see cref="Run{THandler}"/> for one-line Tier 1 startup.
/// </summary>
public static class AgentServer
{
    /// <summary>
    /// Creates a new <see cref="AgentServerBuilder"/> for composing protocols
    /// and configuring the agent server.
    /// </summary>
    /// <param name="args">Optional command-line arguments.</param>
    /// <returns>A new builder instance.</returns>
    public static AgentServerBuilder CreateBuilder(string[]? args = null)
    {
        return new AgentServerBuilder(args);
    }

    /// <summary>
    /// One-line entrypoint: builds and runs a single-protocol server.
    /// The <typeparamref name="THandler"/> is registered in DI and the protocol
    /// is selected by the extension method that constrains <typeparamref name="THandler"/>.
    /// </summary>
    /// <typeparam name="THandler">
    /// The handler type. Must implement a protocol handler interface
    /// (e.g., <c>IResponseHandler</c>) or extend a protocol handler base class
    /// (e.g., <c>InvocationHandler</c>).
    /// </typeparam>
    /// <param name="args">Optional command-line arguments.</param>
    /// <param name="configure">Optional callback to configure the builder before running.</param>
    public static void Run<THandler>(
        string[]? args = null,
        Action<AgentServerBuilder>? configure = null)
        where THandler : class
    {
        var builder = CreateBuilder(args);
        configure?.Invoke(builder);
        builder.Build().Run();
    }
}
