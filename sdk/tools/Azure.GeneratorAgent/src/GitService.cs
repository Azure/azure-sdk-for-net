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
    private readonly AppSettings _settings;

    /// <summary>
    /// Initializes a new instance of the <see cref="GitService"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    /// <param name="httpClient">HTTP client for making requests to GitHub API.</param>
    /// <param name="settings">Application settings.</param>
    public GitService(ILogger<GitService> logger, HttpClient httpClient, AppSettings settings)
    {
        _logger = logger;
        _httpClient = httpClient;
        _settings = settings;
    }

    /// <summary>
    /// Attempts to get the latest commit for a specific path.
    /// </summary>
    /// <param name="owner">Repository owner</param>
    /// <param name="repoName">Repository name</param>
    /// <param name="path">Path within the repository (required)</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Commit SHA if found, null otherwise</returns>
    public async Task<string?> TryGetCommitForPath(string owner, string repoName, string path, CancellationToken cancellationToken)
    {
        var builder = new UriBuilder($"{_settings.GitHubApiUrl}/repos/{Uri.EscapeDataString(owner)}/{Uri.EscapeDataString(repoName)}/commits");
        builder.Query = $"sha=main&path={Uri.EscapeDataString(path)}&per_page=1";
        var apiUrl = builder.Uri;

        var response = await _httpClient.GetAsync(apiUrl, cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning("Failed to fetch commits for path {Path}: {StatusCode} {ReasonPhrase}", path, response.StatusCode, response.ReasonPhrase);
            return null;
        }

        var json = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

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
