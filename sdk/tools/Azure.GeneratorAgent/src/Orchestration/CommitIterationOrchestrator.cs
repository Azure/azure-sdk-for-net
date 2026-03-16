// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.GeneratorAgent.Mcp.Tools;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent.Orchestration;

/// <summary>
/// Replaces the LocalSpecsCommitIterationPrompt entirely with deterministic logic.
/// Iterates through commits to find one with a valid tspconfig.yaml, or creates a fallback.
/// </summary>
public sealed class CommitIterationOrchestrator
{
    private readonly ILogger<CommitIterationOrchestrator> _logger;
    private readonly FileService _fileService;

    public CommitIterationOrchestrator(ILogger<CommitIterationOrchestrator> logger, FileService fileService)
    {
        _logger = logger;
        _fileService = fileService;
    }

    /// <summary>
    /// Iterates through commits to find one with a valid tspconfig.yaml emitter config.
    /// If none found, creates a fallback commit with the correct config.
    /// </summary>
    public async Task ExecuteAsync(
        string sdkProjectPath,
        string tspLocationPath,
        string specsRelativeDirectory,
        string localSpecsPath,
        CancellationToken cancellationToken = default)
    {
        var sdkNamespace = Path.GetFileName(sdkProjectPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

        _logger.LogInformation("Starting commit iteration for namespace: {Namespace}", sdkNamespace);

        // Phase 1: Read current state
        var currentCommit = await _fileService.ReadFieldAsync(tspLocationPath, "commit", cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrEmpty(currentCommit))
        {
            _logger.LogWarning("No commit field found in tsp-location.yaml");
            return;
        }

        _logger.LogInformation("Starting commit: {Commit}", currentCommit);

        // Get newer commits
        var newerCommits = await GetNewerCommitsAsync(localSpecsPath, currentCommit, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);
        var candidates = new List<string> { currentCommit };
        candidates.AddRange(newerCommits);

        _logger.LogInformation("Found {Count} candidate commits (including starting commit)", candidates.Count);

        // Phase 2: Iterate commits
        foreach (var commit in candidates)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _logger.LogInformation("Checking commit: {Commit}", commit);

            // Checkout the commit's tspconfig
            await RunGitAsync(localSpecsPath, $"checkout {commit} -- {specsRelativeDirectory}", cancellationToken).ConfigureAwait(false);

            var tspConfigPath = Path.Combine(localSpecsPath, specsRelativeDirectory.Replace('/', Path.DirectorySeparatorChar), "tspconfig.yaml");
            var validation = ValidateTspConfigTool.ValidateInProcess(tspConfigPath, sdkNamespace);

            if (validation.IsValid)
            {
                _logger.LogInformation("Found valid commit: {Commit}", commit);
                await _fileService.WriteFieldAsync(tspLocationPath, "commit", commit, cancellationToken).ConfigureAwait(false);
                await RestoreWorkingTree(localSpecsPath, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);
                return;
            }

            _logger.LogInformation("Commit {Commit} invalid: {Reason}", commit, validation.Reason);
        }

        // Phase 3: Fallback — fix the latest commit's tspconfig
        _logger.LogWarning("No valid commit found. Creating fallback.");
        var latestCommit = candidates[^1];

        // Capture the current branch/HEAD so we can restore after creating the fallback
        var originalBranch = (await RunGitAsync(localSpecsPath, "rev-parse --abbrev-ref HEAD", cancellationToken).ConfigureAwait(false)).Trim();
        if (originalBranch == "HEAD")
        {
            // Detached HEAD — save the SHA instead
            originalBranch = (await RunGitAsync(localSpecsPath, "rev-parse HEAD", cancellationToken).ConfigureAwait(false)).Trim();
        }

        await RunGitAsync(localSpecsPath, $"checkout {latestCommit} -- {specsRelativeDirectory}", cancellationToken).ConfigureAwait(false);

        var fallbackConfigPath = Path.Combine(localSpecsPath, specsRelativeDirectory.Replace('/', Path.DirectorySeparatorChar), "tspconfig.yaml");
        var (fixSuccess, fixError) = ValidateTspConfigTool.FixTspConfig(fallbackConfigPath, sdkNamespace);
        if (!fixSuccess)
        {
            _logger.LogError("Failed to fix tspconfig.yaml: {Error}", fixError);
            await RestoreWorkingTree(localSpecsPath, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);
            return;
        }

        // Create a fallback branch and commit
        await RunGitAsync(localSpecsPath, "checkout -b sdk-migration-fallback", cancellationToken).ConfigureAwait(false);
        await RunGitAsync(localSpecsPath, $"add {specsRelativeDirectory}/tspconfig.yaml", cancellationToken).ConfigureAwait(false);
        await RunGitAsync(localSpecsPath, "commit -m \"Update tspconfig.yaml for SDK migration: set @azure-typespec/http-client-csharp emitter config\"", cancellationToken).ConfigureAwait(false);

        var newCommitSha = (await RunGitAsync(localSpecsPath, "rev-parse HEAD", cancellationToken).ConfigureAwait(false)).Trim();
        await _fileService.WriteFieldAsync(tspLocationPath, "commit", newCommitSha, cancellationToken).ConfigureAwait(false);

        _logger.LogInformation("Created fallback commit: {Commit}", newCommitSha);

        // Phase 4: Restore original branch and working tree
        await RunGitAsync(localSpecsPath, $"checkout {originalBranch}", cancellationToken).ConfigureAwait(false);
        await RestoreWorkingTree(localSpecsPath, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);
    }

    private async Task<List<string>> GetNewerCommitsAsync(string localSpecsPath, string startingCommit, string specsDir, CancellationToken cancellationToken)
    {
        var output = await RunGitAsync(localSpecsPath, $"log --format=\"%H\" --reverse {startingCommit}..HEAD -- {specsDir}", cancellationToken).ConfigureAwait(false);
        return output
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Where(l => l.Length == 40 && l.All(char.IsAsciiHexDigit))
            .ToList();
    }

    private async Task RestoreWorkingTree(string localSpecsPath, string specsDir, CancellationToken cancellationToken)
    {
        await RunGitAsync(localSpecsPath, $"checkout HEAD -- {specsDir}", cancellationToken).ConfigureAwait(false);
    }

    private async Task<string> RunGitAsync(string workingDirectory, string arguments, CancellationToken cancellationToken)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "git",
            Arguments = arguments,
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(psi)!;
        var stdout = await process.StandardOutput.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
        var stderr = await process.StandardError.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
        await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);

        if (process.ExitCode != 0)
        {
            _logger.LogWarning("Git command failed: git {Args} → exit {ExitCode}: {StdErr}", arguments, process.ExitCode, stderr);
        }

        return stdout;
    }
}
