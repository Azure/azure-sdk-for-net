// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Azure.GeneratorAgent.Services;

/// <summary>
/// Executes Git commands to retrieve repository information.
/// </summary>
public sealed class GitService
{
    private readonly ILogger<GitService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="GitService"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    public GitService(ILogger<GitService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets the latest commit SHA from the repository.
    /// </summary>
    /// <param name="path">Path to any directory within a git repository.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The commit SHA.</returns>
    /// <exception cref="InvalidOperationException">Thrown when not a git repository or git command fails.</exception>
    public async Task<string> GetLatestCommitAsync(string path, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Getting latest commit from: {Path}", path);

        var repositoryPath = FindRepositoryRoot(path);
        if (repositoryPath == null)
        {
            throw new InvalidOperationException($"Not within a git repository: {path}");
        }

        await EnsureGitAvailableAsync(cancellationToken).ConfigureAwait(false);

        using var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = "rev-parse HEAD",
                WorkingDirectory = repositoryPath,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        var output = await process.StandardOutput.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
        var error = await process.StandardError.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
        await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);

        if (process.ExitCode != 0)
        {
            _logger.LogError("Git command failed: {Error}", error);
            throw new InvalidOperationException($"Git command failed: {error}");
        }

        var commitSha = output.Trim();
        _logger.LogInformation("Latest commit SHA: {CommitSha}", commitSha);

        return commitSha;
    }

    /// <summary>
    /// Ensures Git is available on the system PATH.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <exception cref="InvalidOperationException">Thrown when Git is not available.</exception>
    private static async Task EnsureGitAvailableAsync(CancellationToken cancellationToken)
    {
        using var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = "--version",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        try
        {
            process.Start();
            await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException("Git is not available or not properly installed. Please ensure Git is installed and available on the system PATH.");
            }
        }
        catch (Exception ex) when (ex is not InvalidOperationException)
        {
            throw new InvalidOperationException("Git is not available or not properly installed. Please ensure Git is installed and available on the system PATH.", ex);
        }
    }

    /// <summary>
    /// Finds the git repository root by walking up the directory tree.
    /// </summary>
    /// <param name="startPath">Starting path to search from.</param>
    /// <returns>The repository root path, or null if not found.</returns>
    private static string? FindRepositoryRoot(string startPath)
    {
        var currentPath = Path.GetFullPath(startPath);

        while (currentPath != null)
        {
            var gitDir = Path.Combine(currentPath, ".git");
            if (Directory.Exists(gitDir))
            {
                return currentPath;
            }

            var parent = Directory.GetParent(currentPath);
            currentPath = parent?.FullName;
        }

        return null;
    }
}
