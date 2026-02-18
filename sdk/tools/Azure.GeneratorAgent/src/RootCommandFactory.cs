// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.CommandLine;
using Azure.GeneratorAgent;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent.Commands;

/// <summary>
/// Factory for creating command line interface commands.
/// </summary>
public class RootCommandFactory
{
    private const string DefaultOwner = "Azure";
    private const string DefaultSpecsRepository = "azure-rest-api-specs";
    private const string TspLocationFileName = "tsp-location.yaml";
    private const string CommitField = "commit";
    private const string DirectoryField = "directory";
    private const string EmitterPackageJsonPathField = "emitterPackageJsonPath";
    private const string DefaultEmitterPackageJsonPath = "\"eng/azure-typespec-http-client-csharp-emitter-package.json\"";

    private readonly ValidationService _validator;
    private readonly GitService _gitService;
    private readonly FileService _fileService;
    private readonly CopilotService _copilotService;
    private readonly ILogger<RootCommandFactory> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="RootCommandFactory"/> class.
    /// </summary>
    /// <param name="validator">Validation service.</param>
    /// <param name="gitService">Git service.</param>
    /// <param name="fileService">File service.</param>
    /// <param name="copilotService">Copilot service.</param>
    /// <param name="logger">Logger instance.</param>
    public RootCommandFactory(ValidationService validator, GitService gitService, FileService fileService, CopilotService copilotService, ILogger<RootCommandFactory> logger)
    {
        _validator = validator;
        _gitService = gitService;
        _fileService = fileService;
        _copilotService = copilotService;
        _logger = logger;
    }

    /// <summary>
    /// Creates the root command with all subcommands.
    /// </summary>
    /// <param name="cancellationToken">Application-wide cancellation token.</param>
    /// <returns>Configured root command.</returns>
    public RootCommand CreateRootCommand(CancellationToken cancellationToken = default)
    {
        var rootCommand = new RootCommand("Azure SDK Code Generation CLI");

        rootCommand.Add(CreateGenerateCommand(cancellationToken));
        rootCommand.Add(CreateMigrateCommand(cancellationToken));

        return rootCommand;
    }

    private Command CreateGenerateCommand(CancellationToken appCancellationToken)
    {
        var sdkPathArgument = new Argument<string>("sdk-path") { Description = "Path to the SDK directory" };
        var generateCommand = new Command("generate", "Generate code for Azure SDK");
        generateCommand.Add(sdkPathArgument);

        generateCommand.SetAction(async (parseResult) =>
        {
            var sdkPath = parseResult.GetValue(sdkPathArgument);
            _logger.LogInformation("Starting generate command for SDK path: {SdkPath}", sdkPath);

            try
            {
                // TODO: Implement generate workflow
                _logger.LogInformation("Generate workflow - TODO: Implementation pending");
                Environment.ExitCode = 0;
            }
            catch (OperationCanceledException) when (appCancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Generate command was cancelled by user (Ctrl+C)");
                Environment.ExitCode = 1;
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Generate command was cancelled");
                Environment.ExitCode = 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generate command failed for SDK path: {SdkPath}", sdkPath);
                Environment.ExitCode = 1;
            }
        });

        return generateCommand;
    }

    private Command CreateMigrateCommand(CancellationToken appCancellationToken)
    {
        var sdkPathArgument = new Argument<string>("sdk-path") { Description = "Path to the SDK directory" };
        var migrateCommand = new Command("migrate", "Migrate existing code to new Azure SDK");
        migrateCommand.Add(sdkPathArgument);

        migrateCommand.SetAction(async (parseResult) =>
        {
            var sdkPath = parseResult.GetValue(sdkPathArgument);

            if (string.IsNullOrEmpty(sdkPath))
            {
                _logger.LogError("SDK path argument is required but was not provided");
                Environment.ExitCode = 1;
                return;
            }

            _logger.LogInformation("Starting migrate command for SDK path: {SdkPath}", sdkPath);

            // Create command-specific timeout linked to app cancellation
            using var commandCts = CancellationTokenSource.CreateLinkedTokenSource(appCancellationToken);
            commandCts.CancelAfter(TimeSpan.FromMinutes(10));
            var cancellationToken = commandCts.Token;

            try
            {
                // Step 1: Validate SDK path
                _logger.LogDebug("Step 1: Validating SDK path");
                var validatedPath = await _validator.ValidateAsync(sdkPath, cancellationToken).ConfigureAwait(false);

                // Step 2: Validate tsp-location.yaml
                _logger.LogDebug("Step 2: Validating tsp-location.yaml file");
                var tspLocationPath = Path.Combine(validatedPath, TspLocationFileName);
                _validator.ValidateTspLocationFile(tspLocationPath);

                // Step 3: Initialize Copilot
                _logger.LogDebug("Step 3: Initializing Copilot service");
                await _copilotService.InitializeCopilotAsync(validatedPath, cancellationToken).ConfigureAwait(false);

                // Step 4: Get directory from tsp-location.yaml and validate it
                _logger.LogDebug("Step 4: Reading and validating directory field");
                var relativeDirectory = await _fileService.ReadDirectoryFieldAsync(tspLocationPath, cancellationToken).ConfigureAwait(false);
                _validator.ValidateRepositoryPath(relativeDirectory);

                // Step 5: Get valid commit SHA and directory path
                _logger.LogDebug("Step 5: Resolving commit information and directory path");
                var (commitSha, finalDirectory) = await ResolveCommitAndDirectoryAsync(validatedPath, tspLocationPath, relativeDirectory, cancellationToken).ConfigureAwait(false);

                if (commitSha == null || string.IsNullOrEmpty(finalDirectory))
                {
                    _logger.LogError("Unable to resolve valid commit and directory path");
                    Environment.ExitCode = 1;
                    return;
                }

                _logger.LogInformation("Retrieved latest commit: {CommitSha} for path: {Directory}", commitSha, finalDirectory);

                // Step 6: Update the commit ID and emitterPackageJsonPath in tsp-location.yaml (directory already updated by Copilot if needed)
                _logger.LogDebug("Step 6: Updating tsp-location.yaml fields");
                await _fileService.WriteFieldAsync(tspLocationPath, CommitField, commitSha, cancellationToken).ConfigureAwait(false);
                await _fileService.WriteFieldAsync(tspLocationPath, EmitterPackageJsonPathField, DefaultEmitterPackageJsonPath, cancellationToken).ConfigureAwait(false);

                _logger.LogInformation("Successfully completed migration for SDK path: {SdkPath}", sdkPath);
                Environment.ExitCode = 0;
            }
            catch (OperationCanceledException) when (appCancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Migrate command was cancelled by user (Ctrl+C)");
                Environment.ExitCode = 1;
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                _logger.LogWarning("Migrate command timed out after 10 minutes");
                Environment.ExitCode = 1;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Invalid argument provided to migrate command: {Message}", ex.Message);
                Environment.ExitCode = 1;
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger.LogError("Directory not found: {Message}", ex.Message);
                Environment.ExitCode = 1;
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError("Required file not found: {Message}", ex.Message);
                Environment.ExitCode = 1;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Migration operation failed: {Message}", ex.Message);
                Environment.ExitCode = 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during migration for SDK path: {SdkPath}", sdkPath);
                Environment.ExitCode = 1;
            }
        });

        return migrateCommand;
    }

    /// <summary>
    /// Resolves a valid commit SHA and directory path, using Copilot to correct the path if needed.
    /// </summary>
    /// <param name="validatedPath">The validated SDK path.</param>
    /// <param name="tspLocationPath">Path to tsp-location.yaml file.</param>
    /// <param name="initialDirectory">Initial directory path from tsp-location.yaml.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Tuple of (commitSha, finalDirectory) if successful, (null, null) if failed.</returns>
    private async Task<(string? CommitSha, string? FinalDirectory)> ResolveCommitAndDirectoryAsync(string validatedPath, string tspLocationPath, string? initialDirectory, CancellationToken cancellationToken)
    {
        // Try with initial directory first
        if (!string.IsNullOrEmpty(initialDirectory))
        {
            var commitSha = await _gitService.TryGetCommitForPath(DefaultOwner, DefaultSpecsRepository, initialDirectory, cancellationToken).ConfigureAwait(false);
            if (commitSha != null)
            {
                _logger.LogInformation("Found valid commit {CommitSha} for existing directory: {Directory}", commitSha, initialDirectory);
                return (commitSha, initialDirectory);
            }
        }

        // Directory not found or invalid, use Copilot to fix it
        _logger.LogInformation("Directory path {Path} not found or invalid, using Copilot to find and update correct path", initialDirectory);

        await _copilotService.UpdateTspLocationFileAsync(validatedPath, DefaultSpecsRepository, cancellationToken).ConfigureAwait(false);

        var updatedDirectory = await _fileService.ReadDirectoryFieldAsync(tspLocationPath, cancellationToken).ConfigureAwait(false);

        if (string.IsNullOrEmpty(updatedDirectory))
        {
            _logger.LogError("Failed to read updated directory from tsp-location.yaml after Copilot update");
            return (null, null);
        }

        // Try with updated directory
        var updatedCommitSha = await _gitService.TryGetCommitForPath(DefaultOwner, DefaultSpecsRepository, updatedDirectory, cancellationToken).ConfigureAwait(false);

        if (updatedCommitSha != null)
        {
            _logger.LogInformation("Found valid commit {CommitSha} for Copilot-updated directory: {Directory}", updatedCommitSha, updatedDirectory);
            return (updatedCommitSha, updatedDirectory);
        }

        _logger.LogError("Unable to retrieve commit information even after Copilot updated the directory path: {Path}", updatedDirectory);
        return (null, null);
    }
}
