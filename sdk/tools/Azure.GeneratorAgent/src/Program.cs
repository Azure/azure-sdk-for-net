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

            var projectPath = PreParseProjectPath(args);

            var builder = Host.CreateApplicationBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddApplicationServices(builder.Configuration, projectPath);

            using var host = builder.Build();
            var loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
            logger = loggerFactory.CreateLogger(typeof(GeneratorAgentProgram).FullName!);

            logger.LogInformation("Starting Azure SDK Code Generation CLI");

            var commandFactory = host.Services.GetRequiredService<RootCommandFactory>();
            var rootCommand = commandFactory.CreateRootCommand(appCts.Token);

            var parseResult = rootCommand.Parse(args);
            var exitCode = await parseResult.InvokeAsync().ConfigureAwait(false);

            var copilotTask = host.Services.GetService<Task<CopilotService>>();
            if (copilotTask is { IsCompletedSuccessfully: true })
            {
                await copilotTask.Result.DisposeAsync().ConfigureAwait(false);
            }

            logger.LogInformation("Azure SDK Code Generation CLI completed with exit code: {ExitCode}", exitCode);
            return exitCode;
        }
        catch (OperationCanceledException) when (args.Contains("--help") || args.Contains("-h"))
        {
            return 0;
        }
        catch (OperationCanceledException)
        {
            logger?.LogInformation("Application was cancelled by user (Ctrl+C)");
        }
        catch (Exception ex)
        {
            if (logger != null)
            {
                logger.LogError(ex, "Fatal error during application startup");
            }
            else
            {
                Console.Error.WriteLine($"Fatal error during startup: {ex.Message}");
            }
        }

        return 1;
    }

    /// <summary>
    /// Extracts the sdk-path argument from <paramref name="args"/> before the host is built.
    /// Returns null when no path is supplied (e.g. --help).
    /// </summary>
    private static string? PreParseProjectPath(string[] args)
    {
        var sdkPathArgument = new Argument<string>("sdk-path") { Arity = ArgumentArity.ZeroOrOne };

        var migrateCommand = new Command("migrate") { sdkPathArgument };
        var generateCommand = new Command("generate") { sdkPathArgument };

        var rootCommand = new RootCommand { migrateCommand, generateCommand };

        string? projectPath = null;
        var parseResult = rootCommand.Parse(args);

        if (parseResult.CommandResult.Command == migrateCommand ||
            parseResult.CommandResult.Command == generateCommand)
        {
            projectPath = parseResult.GetValue(sdkPathArgument);
        }

        return string.IsNullOrWhiteSpace(projectPath) ? null : projectPath;
    }
}
