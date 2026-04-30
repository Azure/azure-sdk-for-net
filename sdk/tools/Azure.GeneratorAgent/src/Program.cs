// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Cli;
using Azure.GeneratorAgent.Mcp;

namespace Azure.GeneratorAgent;

/// <summary>
/// Main program class for the Azure Generator Agent.
///
/// Default behavior (no args, <c>mcp</c>, or <c>--mcp-server</c>) runs the MCP server
/// over stdio for use by VS Code / Claude Desktop. Any other first argument enters
/// CLI mode (see <see cref="CliRunner"/>) for non-interactive use, e.g., from CI.
/// </summary>
public static class GeneratorAgentProgram
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    /// <returns>Exit code.</returns>
    public static async Task<int> Main(string[] args)
    {
        if (IsMcpServerInvocation(args))
        {
            // Strip our own "mcp" selector so it doesn't reach the MCP host's argument
            // parser. "--mcp-server" is left in place for backward compatibility with
            // existing IDE configurations that pass it explicitly.
            var hostArgs = args.Length > 0 && args[0] == "mcp" ? args[1..] : args;
            return await McpServerHost.RunAsync(hostArgs).ConfigureAwait(false);
        }

        return await CliRunner.RunAsync(args, Console.Out, Console.Error).ConfigureAwait(false);
    }

    private static bool IsMcpServerInvocation(string[] args)
    {
        if (args.Length == 0)
        {
            return true;
        }

        var first = args[0];
        return string.Equals(first, "mcp", StringComparison.Ordinal)
            || string.Equals(first, "--mcp-server", StringComparison.Ordinal);
    }
}
