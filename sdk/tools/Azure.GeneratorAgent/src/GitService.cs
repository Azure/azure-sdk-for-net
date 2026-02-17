// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent;

/// <summary>
/// Executes Git commands to retrieve repository information.
/// </summary>
public sealed class GitService
{
    private readonly ILogger<GitService> _logger;
    private readonly HttpClient _httpClient;
    private readonly CopilotService _copilotService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GitService"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    /// <param name="httpClient">HTTP client for making requests to GitHub API.</param>
    /// <param name="copilotService">Copilot service for intelligent path discovery.</param>
    public GitService(ILogger<GitService> logger, HttpClient httpClient, CopilotService copilotService)
    {
        _logger = logger;
        _httpClient = httpClient;
        _copilotService = copilotService;
    }

    /// <summary>
    /// Gets the latest commit SHA and resolved path from a remote GitHub repository.
    /// If the provided path doesn't exist or is null, uses Copilot to intelligently find the correct service path.
    /// </summary>
    /// <param name="owner">Repository owner</param>
    /// <param name="specsRepoName">Repository name</param>
    /// <param name="projectPath">Local project path for Copilot analysis</param>
    /// <param name="path">Optional path within the repository. If null, asks Copilot to find the correct path.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A tuple containing the latest commit SHA and the resolved path, or null if no path could be found.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the GitHub API call fails.</exception>
    public async Task<(string CommitSha, string ResolvedPath)?> GetLatestCommitWithPathAsync(string owner, string specsRepoName, string projectPath, string? path = null, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Getting latest commit from remote: {Owner}/{Repo}{Path}", owner, specsRepoName, path != null ? $":{path}" : "");

        string? commitSha = null;

        if (!string.IsNullOrEmpty(path))
        {
            commitSha = await TryGetCommitForPath(owner, specsRepoName, path, cancellationToken).ConfigureAwait(false);
            if (commitSha != null)
            {
                return (commitSha, path);
            }
        }

        if (_copilotService.IsCopilotAvailable)
        {
            try
            {
                var correctedPath = await _copilotService.GetTypeSpecSpecificationPath(projectPath, specsRepoName, cancellationToken).ConfigureAwait(false);

                if (!string.IsNullOrEmpty(correctedPath))
                {
                    _logger.LogInformation("Copilot suggested path: {CorrectedPath}", correctedPath);
                    commitSha = await TryGetCommitForPath(owner, specsRepoName, correctedPath, cancellationToken).ConfigureAwait(false);

                    if (commitSha != null)
                    {
                        return (commitSha, correctedPath);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while asking Copilot for service path");
                throw new InvalidOperationException($"No commits found in repository {owner}/{specsRepoName}");
            }
        }

        throw new InvalidOperationException($"No commits found in repository {owner}/{specsRepoName}");
    }

    /// <summary>
    /// Attempts to get the latest commit for a specific path.
    /// </summary>
    /// <param name="owner">Repository owner</param>
    /// <param name="repoName">Repository name</param>
    /// <param name="path">Path within the repository (required)</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Commit SHA if found, null otherwise</returns>
    private async Task<string?> TryGetCommitForPath(string owner, string repoName, string path, CancellationToken cancellationToken)
    {
        var apiUrl = $"https://api.github.com/repos/{owner}/{repoName}/commits?sha=main&path={Uri.EscapeDataString(path)}&per_page=1";

        var response = await _httpClient.GetAsync(apiUrl, cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning("Failed to fetch commits for path {Path}: {StatusCode} {ReasonPhrase}", path, response.StatusCode, response.ReasonPhrase);
            return null;
        }

        var json = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if (json.Length > 1_000_000)
        {
            throw new InvalidOperationException("API response exceeded maximum allowed size");
        }

        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        if (root.GetArrayLength() == 0)
        {
            _logger.LogDebug("No commits found for path {Path}", path);
            return null;
        }

        var commitSha = root[0].GetProperty("sha").GetString();
        if (string.IsNullOrEmpty(commitSha))
        {
            _logger.LogDebug("Invalid commit SHA received from GitHub API");
            return null;
        }

        _logger.LogInformation("Latest commit SHA for {Owner}/{Repo}:{Path}: {CommitSha}", owner, repoName, path, commitSha);

        return commitSha;
    }
}
