// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp;

/// <summary>
/// Hosts an MCP server over stdio transport with auto-discovered tool classes.
/// Activated when the binary is run with the --mcp-server flag.
/// </summary>
public static class McpServerHost
{
    /// <summary>
    /// Starts the MCP server and blocks until stdin is closed or the process is terminated.
    /// </summary>
    public static async Task<int> RunAsync(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        // Logging at Warning+ to avoid polluting stdout (the MCP transport channel)
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole(opts => opts.LogToStandardErrorThreshold = LogLevel.Trace);
        builder.Logging.SetMinimumLevel(LogLevel.Warning);

        builder.Services
            .AddMcpServer()
            .WithStdioServerTransport()
            .WithToolsFromAssembly(typeof(McpServerHost).Assembly);

        using var host = builder.Build();

        try
        {
            await host.RunAsync().ConfigureAwait(false);
            return 0;
        }
        catch (OperationCanceledException)
        {
            return 0;
        }
        catch (Exception)
        {
            return 1;
        }
    }
}
