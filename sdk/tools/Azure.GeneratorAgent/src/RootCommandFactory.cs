// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.CommandLine;
using Azure.GeneratorAgent.Services;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent.Commands;

/// <summary>
/// Factory for creating command line interface commands.
/// </summary>
public class RootCommandFactory
{
    private readonly SdkValidator Validator;
    private readonly GitService GitService;
    private readonly ILogger<RootCommandFactory> Logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="RootCommandFactory"/> class.
    /// </summary>
    /// <param name="validator">SDK validator service.</param>
    /// <param name="gitService">Git service.</param>
    /// <param name="logger">Logger instance.</param>
    public RootCommandFactory(SdkValidator validator, GitService gitService, ILogger<RootCommandFactory> logger)
    {
        Validator = validator;
        GitService = gitService;
        Logger = logger;
    }

    /// <summary>
    /// Creates the root command with all subcommands.
    /// </summary>
    /// <returns>Configured root command.</returns>
    public RootCommand CreateRootCommand()
    {
        var rootCommand = new RootCommand("Azure SDK Code Generation CLI");

        rootCommand.AddCommand(CreateGenerateCommand());
        rootCommand.AddCommand(CreateMigrateCommand());

        return rootCommand;
    }

    private Command CreateGenerateCommand()
    {
        var sdkPathArgument = new Argument<string>("sdk-path", "Path to the SDK directory");
        var generateCommand = new Command("generate", "Generate code for Azure SDK")
        {
            sdkPathArgument
        };

        generateCommand.SetHandler(async (string sdkPath) =>
        {
            Logger.LogInformation("Generate command called with SDK path: {SdkPath}", sdkPath);

            try
            {
                var (validatedPath, commitSha) = await ValidateAndPrepareAsync(sdkPath, CancellationToken.None).ConfigureAwait(false);

                Logger.LogInformation("Generate workflow ready - Path: {Path}, Commit: {Commit}", validatedPath, commitSha);
                // TODO: Continue with remaining workflow steps (Build → Parse → Fix)
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Generate command failed");
            }
        }, sdkPathArgument);

        return generateCommand;
    }

    private Command CreateMigrateCommand()
    {
        var sdkPathArgument = new Argument<string>("sdk-path", "Path to the SDK directory");
        var migrateCommand = new Command("migrate", "Migrate existing code to new Azure SDK")
        {
            sdkPathArgument
        };

        migrateCommand.SetHandler(async (string sdkPath) =>
        {
            Logger.LogInformation("Migrate command called with SDK path: {SdkPath}", sdkPath);

            try
            {
                var (validatedPath, commitSha) = await ValidateAndPrepareAsync(sdkPath, CancellationToken.None).ConfigureAwait(false);

                Logger.LogInformation("Migrate workflow ready - Path: {Path}, Commit: {Commit}", validatedPath, commitSha);
                // TODO: Step 4 (Migration specific): Update tsp-location.yaml & .csproj
                // TODO: Continue with remaining workflow steps (Build → Parse → Fix)
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Migrate command failed");
            }
        }, sdkPathArgument);

        return migrateCommand;
    }

    private async Task<(string ValidatedPath, string CommitSha)> ValidateAndPrepareAsync(
        string sdkPath,
        CancellationToken cancellationToken)
    {
        // Step 1: Validate SDK path
        var validatedPath = await Validator.ValidateAsync(sdkPath, cancellationToken).ConfigureAwait(false);

        // Step 2: Fetch latest commit ID
        var commitSha = await GitService.GetLatestCommitAsync(validatedPath, cancellationToken).ConfigureAwait(false);

        return (validatedPath, commitSha);
    }
}
