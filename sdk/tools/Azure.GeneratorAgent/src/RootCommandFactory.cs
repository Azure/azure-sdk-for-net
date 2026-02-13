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
    private const string EmitterPackageJsonPathField = "emitterPackageJsonPath";
    private const string DefaultEmitterPackageJsonPath = "\"eng/azure-typespec-http-client-csharp-emitter-package.json\"";

    private readonly ValidationService _validator;
    private readonly GitService _gitService;
    private readonly FileService _fileService;
    private readonly ILogger<RootCommandFactory> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="RootCommandFactory"/> class.
    /// </summary>
    /// <param name="validator">Validation service.</param>
    /// <param name="gitService">Git service.</param>
    /// <param name="fileService">File service.</param>
    /// <param name="logger">Logger instance.</param>
    public RootCommandFactory(ValidationService validator, GitService gitService, FileService fileService, ILogger<RootCommandFactory> logger)
    {
        _validator = validator;
        _gitService = gitService;
        _fileService = fileService;
        _logger = logger;
    }

    /// <summary>
    /// Creates the root command with all subcommands.
    /// </summary>
    /// <returns>Configured root command.</returns>
    public RootCommand CreateRootCommand()
    {
        var rootCommand = new RootCommand("Azure SDK Code Generation CLI");

        rootCommand.Add(CreateGenerateCommand());
        rootCommand.Add(CreateMigrateCommand());

        return rootCommand;
    }

    private Command CreateGenerateCommand()
    {
        var sdkPathArgument = new Argument<string>("sdk-path") { Description = "Path to the SDK directory" };
        var generateCommand = new Command("generate", "Generate code for Azure SDK");
        generateCommand.Add(sdkPathArgument);

        generateCommand.SetAction(async (parseResult) =>
        {
            var sdkPath = parseResult.GetValue(sdkPathArgument);
            _logger.LogInformation("Generate command called with SDK path: {SdkPath}", sdkPath);

            try
            {
                // TODO: Implement generate workflow
                _logger.LogInformation("Generate workflow - TODO");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generate command failed");
                Environment.Exit(1);
            }
        });

        return generateCommand;
    }

    private Command CreateMigrateCommand()
    {
        var sdkPathArgument = new Argument<string>("sdk-path") { Description = "Path to the SDK directory" };
        var migrateCommand = new Command("migrate", "Migrate existing code to new Azure SDK");
        migrateCommand.Add(sdkPathArgument);

        migrateCommand.SetAction(async (parseResult) =>
        {
            var sdkPath = parseResult.GetValue(sdkPathArgument);
            _logger.LogInformation("Migrate command called with SDK path: {SdkPath}", sdkPath);

            try
            {
                // Step 1: Validate SDK path
                var validatedPath = await _validator.ValidateAsync(sdkPath!, CancellationToken.None).ConfigureAwait(false);
                _logger.LogInformation("Step 1: SDK path validated: {Path}", validatedPath);

                // Step 2: Validate tsp-location.yaml
                var tspLocationPath = Path.Combine(validatedPath, TspLocationFileName);
                _validator.ValidateTspLocationFile(tspLocationPath);

                // Step 3: Get directory from tsp-location.yaml an validate it
                var relativeDirectory = await _fileService.ReadDirectoryFieldAsync(tspLocationPath, CancellationToken.None).ConfigureAwait(false);
                _validator.ValidateRepositoryPath(relativeDirectory);

                // Step 4: Get latest commit id
                var commitSha = await _gitService.GetLatestCommitAsync(DefaultOwner, DefaultSpecsRepository, relativeDirectory, CancellationToken.None).ConfigureAwait(false);
                _logger.LogInformation("Latest commit ID: {CommitSha}", commitSha);

                // Step 5: Update the commit ID in tsp-location.yaml
                if (!string.IsNullOrEmpty(commitSha))
                {
                    await _fileService.WriteFieldAsync(tspLocationPath, CommitField, commitSha, CancellationToken.None).ConfigureAwait(false);
                    _logger.LogInformation("Updated commit ID in tsp-location.yaml");
                }

                // Step 6: Update emitterPackageJsonPath in tsp-location.yaml
                await _fileService.WriteFieldAsync(tspLocationPath, EmitterPackageJsonPathField, DefaultEmitterPackageJsonPath, CancellationToken.None).ConfigureAwait(false);
                _logger.LogInformation("Updated emitterPackageJsonPath in tsp-location.yaml");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Migrate command failed");
                Environment.Exit(1);
            }
        });

        return migrateCommand;
    }
}
