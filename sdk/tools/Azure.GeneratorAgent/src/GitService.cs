// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Azure.GeneratorAgent;

/// <summary>
/// Executes Git commands to retrieve repository information.
/// </summary>
public sealed class GitService
{
    private const string DefaultUserAgent = "AzureGeneratorAgent";

    private readonly ILogger<GitService> _logger;
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="GitService"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    /// <param name="httpClient">HTTP client for making requests to GitHub API.</param>
    public GitService(ILogger<GitService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    /// <summary>
    /// Gets the latest commit SHA from a remote GitHub repository, optionally for a specific path.
    /// </summary>
    /// <param name="owner">Repository owner</param>
    /// <param name="repoName">Repository name</param>
    /// <param name="path">Optional path within the repository. If null, gets latest commit from main branch.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The latest commit SHA, or null if path-specific request fails.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the GitHub API call fails for repository-wide requests.</exception>
    public async Task<string?> GetLatestCommitAsync(string owner, string repoName, string? path = null, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Getting latest commit from remote: {Owner}/{Repo}{Path}", owner, repoName, path != null ? $":{path}" : "");

        var apiUrl = path != null
            ? $"https://api.github.com/repos/{owner}/{repoName}/commits?sha=main&path={Uri.EscapeDataString(path)}&per_page=1"
            : $"https://api.github.com/repos/{owner}/{repoName}/commits?sha=main&per_page=1";

        if (!_httpClient.DefaultRequestHeaders.UserAgent.Any())
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"{DefaultUserAgent}/1.0");
        }

        if (!_httpClient.DefaultRequestHeaders.Contains("Accept"))
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
        }

        var response = await _httpClient.GetAsync(apiUrl, cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Failed to fetch commits from GitHub API: {StatusCode} {ReasonPhrase}", response.StatusCode, response.ReasonPhrase);
            throw new InvalidOperationException($"Failed to fetch commits from GitHub API: {response.StatusCode} {response.ReasonPhrase}");
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
            throw new InvalidOperationException($"No commits found for repository {owner}/{repoName}");
        }

        var commitSha = root[0].GetProperty("sha").GetString();
        if (string.IsNullOrEmpty(commitSha))
        {
            throw new InvalidOperationException("Invalid commit SHA received from GitHub API");
        }

        _logger.LogInformation("Latest commit SHA for {Owner}/{Repo}{Path}: {CommitSha}", owner, repoName, path != null ? $":{path}" : "", commitSha);

        return commitSha;
    }
}
