// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp;

namespace Azure.GeneratorAgent;

/// <summary>
/// Main program class for the Azure Generator Agent MCP server.
/// </summary>
public static class GeneratorAgentProgram
{
    /// <summary>
    /// Application entry point. Starts the MCP server over stdio transport.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    /// <returns>Exit code.</returns>
    public static async Task<int> Main(string[] args)
    {
        return await McpServerHost.RunAsync(args).ConfigureAwait(false);
    }
}
