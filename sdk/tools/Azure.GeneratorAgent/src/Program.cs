// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.CommandLine;
using Azure.GeneratorAgent.Commands;
using Azure.GeneratorAgent.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent;

/// <summary>
/// Main program class for the Azure Generator Agent.
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
        ILogger? logger = null;
        try
        {
            using var appCts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                appCts.Cancel();
            };

            var builder = Host.CreateApplicationBuilder(args);

            // Configure logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Register services
            builder.Services.AddApplicationServices(builder.Configuration);

            using var host = builder.Build();
            var loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
            logger = loggerFactory.CreateLogger(typeof(GeneratorAgentProgram).FullName!);

            logger.LogInformation("Starting Azure SDK Code Generation CLI");

            var commandFactory = host.Services.GetRequiredService<RootCommandFactory>();
            var rootCommand = commandFactory.CreateRootCommand(appCts.Token);

            var parseResult = rootCommand.Parse(args);
            var exitCode = await parseResult.InvokeAsync().ConfigureAwait(false);

            logger.LogInformation("Azure SDK Code Generation CLI completed with exit code: {ExitCode}", exitCode);
            return exitCode;
        }
        catch (OperationCanceledException) when (args.Contains("--help") || args.Contains("-h"))
        {
            // Help was requested - this is normal, not an error
            return 0;
        }
        catch (OperationCanceledException)
        {
            logger?.LogInformation("Application was cancelled by user (Ctrl+C)");
            return 1;
        }
        catch (Exception ex)
        {
            if (logger != null)
            {
                logger.LogError(ex, "Fatal error during application startup");
            }
            else
            {
                // Fallback if logger isn't available yet
                Console.Error.WriteLine($"Fatal error during startup: {ex.Message}");
            }
            return 1;
        }
    }
}
