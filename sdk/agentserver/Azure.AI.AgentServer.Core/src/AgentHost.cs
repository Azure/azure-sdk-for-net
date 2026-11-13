// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Static entry point for creating agent servers.
/// Use <see cref="CreateBuilder"/> to compose protocols and build the server.
/// For one-line startup, use the protocol-specific <c>Run</c> methods provided
/// by each protocol package (e.g., <c>ResponsesServer.Run&lt;T&gt;()</c>).
/// </summary>
public static class AgentHost
{
    /// <summary>
    /// Creates a new <see cref="AgentHostBuilder"/> for composing protocols
    /// and configuring the agent server.
    /// </summary>
    /// <param name="args">Optional command-line arguments.</param>
    /// <returns>A new builder instance.</returns>
    public static AgentHostBuilder CreateBuilder(string[]? args = null)
    {
        return new AgentHostBuilder(args);
    }
}
