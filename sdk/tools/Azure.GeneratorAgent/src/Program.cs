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
        try
        {
            var builder = Host.CreateApplicationBuilder(args);

            // Configure logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Register services
            builder.Services.AddApplicationServices(builder.Configuration);

            using var host = builder.Build();
            var loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger(typeof(GeneratorAgentProgram).FullName!);

            logger.LogInformation("Starting Azure SDK Code Generation CLI");

            var commandFactory = host.Services.GetRequiredService<RootCommandFactory>();
            var rootCommand = commandFactory.CreateRootCommand();

            var parseResult = rootCommand.Parse(args);
            return await parseResult.InvokeAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Fatal error during startup: {ex.Message}");
            return 1;
        }
    }
}