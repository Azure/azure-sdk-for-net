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
    private readonly AppSettings _settings;
    private readonly Task<CopilotService>? _copilotServiceTask;
    private readonly ILogger<RootCommandFactory> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="RootCommandFactory"/> class.
    /// </summary>
    /// <param name="validator">Validation service.</param>
    /// <param name="gitService">Git service.</param>
    /// <param name="fileService">File service.</param>
    /// <param name="settings">Application settings.</param>
    /// <param name="logger">Logger instance.</param>
    /// <param name="copilotServiceTask">Optional task that resolves to the initialized CopilotService singleton.</param>
    public RootCommandFactory(ValidationService validator, GitService gitService, FileService fileService, AppSettings settings, ILogger<RootCommandFactory> logger, Task<CopilotService>? copilotServiceTask = null)
    {
        _validator = validator;
        _gitService = gitService;
        _fileService = fileService;
        _settings = settings;
        _copilotServiceTask = copilotServiceTask;
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
        var localSpecsPathArgument = new Argument<string>("local-specs-path") { Description = "Path to the local specs repository." };
        var generateCommand = new Command("generate", "Generate code for Azure SDK");
        generateCommand.Add(sdkPathArgument);
        generateCommand.Add(localSpecsPathArgument);

        generateCommand.SetAction(async (parseResult) =>
        {
            var sdkPath = parseResult.GetValue(sdkPathArgument);
            _logger.LogInformation("Starting generate command for SDK path: {SdkPath}", sdkPath);

            // TODO: Implement generate workflow
            _logger.LogInformation("Generate workflow - TODO: Implementation pending");
        });

        return generateCommand;
    }

    private Command CreateMigrateCommand(CancellationToken appCancellationToken)
    {
        var sdkPathArgument = new Argument<string>("sdk-path") { Description = "Path to the SDK directory" };
        var localSpecsPathArgument = new Argument<string>("local-specs-path") { Description = "Path to the local specs repository. Used to iterate through commits to find one that generates successfully." };
        var migrateCommand = new Command("migrate", "Migrate existing code to new Azure SDK");
        migrateCommand.Add(sdkPathArgument);
        migrateCommand.Add(localSpecsPathArgument);

        migrateCommand.SetAction(async (parseResult) =>
        {
            var sdkPath = parseResult.GetValue(sdkPathArgument);
            var localSpecsPath = parseResult.GetValue(localSpecsPathArgument);

            if (string.IsNullOrEmpty(sdkPath))
            {
                throw new ArgumentException("SDK path argument is required but was not provided", nameof(sdkPath));
            }

            if (string.IsNullOrEmpty(localSpecsPath))
            {
                throw new ArgumentException("Local specs path argument is required but was not provided", nameof(localSpecsPath));
            }

            _logger.LogInformation("Migrating: {SdkPath}", sdkPath);
            _logger.LogInformation("Using local specs: {LocalSpecsPath}", localSpecsPath);

            using var commandCts = CancellationTokenSource.CreateLinkedTokenSource(appCancellationToken);
            commandCts.CancelAfter(_settings.WorkflowTimeout);
            var cancellationToken = commandCts.Token;

            try
            {
                // Step 1: Validate inputs
                _logger.LogDebug("Step 1: Validating SDK path");
                var validatedSdkPath = await _validator.ValidateAsync(sdkPath, cancellationToken).ConfigureAwait(false);

                _logger.LogDebug("Step 1b: Validating local specs path");
                var validatedSpecsPath = _validator.ValidateLocalSpecsPath(localSpecsPath);

                // Step 2: Validate tsp-location.yaml
                _logger.LogDebug("Step 2: Validating tsp-location.yaml file");
                var tspLocationPath = Path.Combine(validatedSdkPath, TspLocationFileName);
                _validator.ValidateTspLocationFile(tspLocationPath);

                // Step 3: Read directory from tsp-location.yaml
                _logger.LogDebug("Step 3: Reading directory field");
                var specsRelativeDirectory = await _fileService.ReadFieldAsync(tspLocationPath, DirectoryField, cancellationToken).ConfigureAwait(false);

                // Step 4: Initialize Copilot
                _logger.LogDebug("Step 4: Initializing Copilot service");
                if (_copilotServiceTask is null)
                {
                    throw new InvalidOperationException("Copilot service task was not initialized");
                }
                var copilotService = await _copilotServiceTask.ConfigureAwait(false);

                // Step 5: Verify directory exists in remote specs repo; if not, ask Copilot to correct it
                _logger.LogDebug("Step 5: Verifying specs directory exists in remote repo");
                specsRelativeDirectory = await ResolveSpecsDirectoryAsync(
                    validatedSdkPath, tspLocationPath, specsRelativeDirectory, copilotService, cancellationToken).ConfigureAwait(false);
                _validator.ValidateRepositoryPath(specsRelativeDirectory);

                // Step 6: Ensure valid commit in tsp-location.yaml; fallback to latest if missing or invalid
                _logger.LogDebug("Step 6: Resolving commit SHA");
                await ResolveCommitAsync(tspLocationPath, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);

                // Step 7: Update emitterPackageJsonPath
                _logger.LogDebug("Step 7: Updating emitterPackageJsonPath in tsp-location.yaml");
                await _fileService.WriteFieldAsync(tspLocationPath, EmitterPackageJsonPathField, DefaultEmitterPackageJsonPath, cancellationToken).ConfigureAwait(false);

                // Step 8: Delegate commit iteration to Copilot (uses local specs repo)
                _logger.LogDebug("Step 8: Delegating local specs commit iteration to Copilot");
                await copilotService.HandleLocalSpecsCommitIterationAsync(
                    validatedSdkPath, tspLocationPath, specsRelativeDirectory, validatedSpecsPath, cancellationToken).ConfigureAwait(false);

                // Step 9: Build-fix cycle
                _logger.LogDebug("Step 9: Delegating build-fix cycle to Copilot");
                await copilotService.HandleBuildFixCycleAsync(validatedSdkPath, cancellationToken).ConfigureAwait(false);

                _logger.LogInformation("Migration completed: {SdkPath}", sdkPath);
            }
            catch (OperationCanceledException) when (appCancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Migrate command was cancelled by user (Ctrl+C)");
                throw;
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                _logger.LogWarning("Migrate command timed out after {Timeout}", _settings.WorkflowTimeout);
                throw;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Invalid argument provided to migrate command: {Message}", ex.Message);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger.LogError("Directory not found: {Message}", ex.Message);
                throw;
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError("Required file not found: {Message}", ex.Message);
                throw;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Migration operation failed: {Message}", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during migration for SDK path: {SdkPath}", sdkPath);
                throw;
            }
        });

        return migrateCommand;
    }

    /// <summary>
    /// Verifies the specs directory exists in the remote specs repo via the GitHub API.
    /// If not found, delegates to Copilot to correct the directory field in tsp-location.yaml.
    /// </summary>
    private async Task<string> ResolveSpecsDirectoryAsync(
        string validatedSdkPath,
        string tspLocationPath,
        string? specsRelativeDirectory,
        CopilotService copilotService,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(specsRelativeDirectory))
        {
            var commitForPath = await _gitService.TryGetCommitForPath(
                DefaultOwner, DefaultSpecsRepository, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);

            if (commitForPath is not null)
            {
                _logger.LogDebug("Specs directory '{Directory}' verified in remote repo", specsRelativeDirectory);
                return specsRelativeDirectory;
            }

            _logger.LogWarning("Specs directory '{Directory}' not found in remote repo, asking Copilot to correct it", specsRelativeDirectory);
        }
        else
        {
            _logger.LogWarning("No directory field found in tsp-location.yaml, asking Copilot to determine it");
        }

        await copilotService.UpdateTspLocationFileAsync(validatedSdkPath, DefaultSpecsRepository, cancellationToken).ConfigureAwait(false);

        var correctedDirectory = await _fileService.ReadFieldAsync(tspLocationPath, DirectoryField, cancellationToken).ConfigureAwait(false);

        if (string.IsNullOrEmpty(correctedDirectory))
        {
            throw new InvalidOperationException("Copilot was unable to determine the correct specs directory path");
        }

        var verifyCommit = await _gitService.TryGetCommitForPath(
            DefaultOwner, DefaultSpecsRepository, correctedDirectory, cancellationToken).ConfigureAwait(false);

        if (verifyCommit is null)
        {
            throw new InvalidOperationException(
                $"Copilot suggested specs directory '{correctedDirectory}' but it was not found in {DefaultOwner}/{DefaultSpecsRepository}");
        }

        _logger.LogInformation("Copilot corrected specs directory to: {Directory}", correctedDirectory);
        return correctedDirectory;
    }

    /// <summary>
    /// Ensures the commit field in tsp-location.yaml contains a valid SHA.
    /// If missing or invalid (not a 40-char hex string), fetches the latest commit for the directory
    /// from the GitHub API and writes it into tsp-location.yaml.
    /// </summary>
    private async Task ResolveCommitAsync(
        string tspLocationPath,
        string specsRelativeDirectory,
        CancellationToken cancellationToken)
    {
        var currentCommit = await _fileService.ReadFieldAsync(tspLocationPath, CommitField, cancellationToken).ConfigureAwait(false);

        if (IsValidCommitSha(currentCommit))
        {
            _logger.LogDebug("Commit SHA '{Commit}' is valid", currentCommit);
            return;
        }

        _logger.LogWarning("Commit field is missing or invalid ('{Commit}'), fetching latest commit for '{Directory}'",
            currentCommit ?? "(empty)", specsRelativeDirectory);

        var latestCommit = await _gitService.TryGetCommitForPath(
            DefaultOwner, DefaultSpecsRepository, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);

        if (string.IsNullOrEmpty(latestCommit))
        {
            throw new InvalidOperationException(
                $"Unable to fetch latest commit for directory '{specsRelativeDirectory}' from {DefaultOwner}/{DefaultSpecsRepository}");
        }

        await _fileService.WriteFieldAsync(tspLocationPath, CommitField, latestCommit, cancellationToken).ConfigureAwait(false);
        _logger.LogInformation("Updated commit in tsp-location.yaml to latest: {Commit}", latestCommit);
    }

    /// <summary>
    /// Validates that a string is a well-formed 40-character hexadecimal git commit SHA.
    /// </summary>
    internal static bool IsValidCommitSha(string? sha)
    {
        if (string.IsNullOrEmpty(sha) || sha.Length != 40)
        {
            return false;
        }

        foreach (var c in sha)
        {
            if (!char.IsAsciiHexDigit(c))
            {
                return false;
            }
        }

        return true;
    }
}
