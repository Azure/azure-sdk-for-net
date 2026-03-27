// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that finds a valid spec commit for SDK code generation by validating
/// tspconfig.yaml and main.tsp remotely via GitHub.
/// </summary>
[McpServerToolType]
public static class CommitIterationTool
{
    private const int CommitShaDisplayLength = 12;
    private const string GitHubRawBaseUrl = "https://raw.githubusercontent.com";
    private const string GitHubApiBaseUrl = "https://api.github.com";
    private const string GitHubApiMediaType = "application/vnd.github+json";

    private static readonly HttpClient s_httpClient = CreateHttpClient();

    private static readonly Regex s_repoSlugRegex = new(
        @"^[a-zA-Z0-9._-]+/[a-zA-Z0-9._-]+$",
        RegexOptions.Compiled);

    [McpServerTool(Name = "commit_iteration"), Description(
        "Find a valid spec commit for SDK code generation. " +
        "Validates tspconfig.yaml and main.tsp remotely from GitHub. " +
        "Three modes: commitOverride (strict), auto-resolve (iterates forward), " +
        "fallback (fixes tspconfig.yaml locally when localSpecsPath is provided — no git commit needed).")]
    public static async Task<string> ExecuteAsync(
        [Description("Absolute path to the SDK project directory")] string sdkProjectPath,
        [Description("Absolute path to the tsp-location.yaml file")] string tspLocationPath,
        [Description("Relative spec directory path (from tsp-location.yaml 'directory' field)")] string specsRelativeDirectory,
        [Description("Optional. GitHub repo slug (e.g., Azure/azure-rest-api-specs). Defaults to tsp-location.yaml 'repo' field.")] string? repo = null,
        [Description("Absolute path to the local azure-rest-api-specs clone. Required. Used for fallback tspconfig.yaml fixes when no valid remote commit is found.")] string? localSpecsPath = null,
        [Description("Optional. User-provided commit SHA. Validated strictly, never iterates.")] string? commitOverride = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await ExecuteInProcessAsync(
                Path.GetFullPath(sdkProjectPath),
                Path.GetFullPath(tspLocationPath),
                specsRelativeDirectory,
                repo,
                localSpecsPath is not null ? Path.GetFullPath(localSpecsPath) : null,
                commitOverride?.Trim(),
                cancellationToken).ConfigureAwait(false);

            return JsonSerializer.Serialize(result);
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new CommitIterationResult { Success = false, Message = ex.Message });
        }
    }

    /// <summary>
    /// In-process execution for direct invocation from CLI or orchestrator.
    /// </summary>
    public static async Task<CommitIterationResult> ExecuteInProcessAsync(
        string sdkProjectPath,
        string tspLocationPath,
        string specsRelativeDirectory,
        string? repo,
        string? localSpecsPath,
        string? commitOverride,
        CancellationToken cancellationToken)
    {
        if (!File.Exists(tspLocationPath))
        {
            return Fail($"tsp-location.yaml not found: {tspLocationPath}");
        }

        var sdkNamespace = Path.GetFileName(
            sdkProjectPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

        repo = await ResolveRepoAsync(repo, tspLocationPath, cancellationToken).ConfigureAwait(false);
        if (repo is null)
        {
            return Fail("No 'repo' field in tsp-location.yaml and no repo parameter provided.");
        }

        if (!s_repoSlugRegex.IsMatch(repo))
        {
            return Fail($"Invalid repo format '{repo}'. Expected 'owner/name' (e.g., Azure/azure-rest-api-specs).");
        }

        // Strict mode: validate exactly one commit, no iteration
        if (!string.IsNullOrWhiteSpace(commitOverride))
        {
            return await ValidateAndUseCommitAsync(
                tspLocationPath, specsRelativeDirectory, repo, sdkNamespace,
                commitOverride, strict: true, cancellationToken).ConfigureAwait(false);
        }

        // Auto-resolve mode: validate current commit, iterate forward if invalid
        return await AutoResolveCommitAsync(
            tspLocationPath, specsRelativeDirectory, repo, sdkNamespace,
            localSpecsPath, cancellationToken).ConfigureAwait(false);
    }

    // ── Core validation ──────────────────────────────────────────────────

    /// <summary>
    /// Validates a commit by fetching main.tsp and tspconfig.yaml from GitHub.
    /// If valid, writes the commit SHA to tsp-location.yaml.
    /// </summary>
    private static async Task<CommitIterationResult> ValidateAndUseCommitAsync(
        string tspLocationPath,
        string specsRelativeDirectory,
        string repo,
        string sdkNamespace,
        string commit,
        bool strict,
        CancellationToken cancellationToken)
    {
        var mainTspPath = $"{specsRelativeDirectory}/main.tsp";
        if (await FetchFileFromGitHubAsync(repo, commit, mainTspPath, cancellationToken).ConfigureAwait(false) is null)
        {
            return MakeInvalidResult(commit, $"main.tsp not found at {mainTspPath}", strict);
        }

        var tspConfigPath = $"{specsRelativeDirectory}/tspconfig.yaml";
        var tspConfigContent = await FetchFileFromGitHubAsync(repo, commit, tspConfigPath, cancellationToken).ConfigureAwait(false);
        if (tspConfigContent is null)
        {
            return MakeInvalidResult(commit, $"tspconfig.yaml not found at {tspConfigPath}", strict);
        }

        var validation = ValidateTspConfigTool.ValidateContent(tspConfigContent, sdkNamespace);
        if (!validation.IsValid)
        {
            return MakeInvalidResult(commit, validation.Reason, strict);
        }

        await WriteYamlFieldAsync(tspLocationPath, "commit", commit, cancellationToken).ConfigureAwait(false);
        return new CommitIterationResult { Success = true, Commit = commit, Message = $"Found valid commit: {commit}" };
    }

    // ── Auto-resolve ─────────────────────────────────────────────────────

    /// <summary>
    /// Validates the current commit and iterates forward through newer commits if invalid.
    /// Falls back to local branch creation when all remote candidates are exhausted.
    /// </summary>
    private static async Task<CommitIterationResult> AutoResolveCommitAsync(
        string tspLocationPath,
        string specsRelativeDirectory,
        string repo,
        string sdkNamespace,
        string? localSpecsPath,
        CancellationToken cancellationToken)
    {
        var startingCommit = await ResolveStartingCommitAsync(tspLocationPath, repo, cancellationToken).ConfigureAwait(false);
        if (startingCommit is null)
        {
            return Fail("Could not determine a starting commit from tsp-location.yaml or GitHub HEAD.");
        }

        var startResult = await ValidateAndUseCommitAsync(
            tspLocationPath, specsRelativeDirectory, repo, sdkNamespace,
            startingCommit, strict: false, cancellationToken).ConfigureAwait(false);
        if (startResult.Success)
        {
            return startResult;
        }

        // Iterate newer commits
        var newerCommits = await GetNewerCommitsAsync(
            repo, startingCommit, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);

        var invalidReasons = new List<string>(newerCommits.Count + 1)
        {
            $"{AbbrevSha(startingCommit)}: {startResult.Message}"
        };

        foreach (var commit in newerCommits)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await ValidateAndUseCommitAsync(
                tspLocationPath, specsRelativeDirectory, repo, sdkNamespace,
                commit, strict: false, cancellationToken).ConfigureAwait(false);
            if (result.Success)
            {
                return result;
            }

            invalidReasons.Add($"{AbbrevSha(commit)}: {result.Message}");
        }

        // All candidates invalid
        var candidateCount = 1 + newerCommits.Count;
        var summary = string.Join("\n", invalidReasons);

        if (localSpecsPath is not null)
        {
            return await FixTspConfigLocallyAsync(
                specsRelativeDirectory, localSpecsPath, sdkNamespace,
                cancellationToken).ConfigureAwait(false);
        }

        return new CommitIterationResult
        {
            Success = false,
            Message = $"No valid commit found among {candidateCount} candidates. " +
                      $"Provide localSpecsPath so tspconfig.yaml can be fixed locally.\n{summary}"
        };
    }

    /// <summary>
    /// Reads the starting commit from tsp-location.yaml, or fetches the HEAD SHA
    /// of the repo's main branch from GitHub when no commit is present.
    /// </summary>
    private static async Task<string?> ResolveStartingCommitAsync(
        string tspLocationPath,
        string repo,
        CancellationToken cancellationToken)
    {
        var tspContent = await File.ReadAllTextAsync(tspLocationPath, cancellationToken).ConfigureAwait(false);
        var commit = ReadYamlField(tspContent, "commit");

        return !string.IsNullOrEmpty(commit)
            ? commit
            : await GetHeadCommitShaAsync(repo, cancellationToken).ConfigureAwait(false);
    }

    // ── Fallback: fix tspconfig locally ─────────────────────────────────

    /// <summary>
    /// Fixes tspconfig.yaml locally in the spec repo without creating a git branch or commit.
    /// Returns success with <see cref="CommitIterationResult.UseLocalSpecs"/> set to true,
    /// indicating that all subsequent code generation should use the local spec path.
    /// </summary>
    private static async Task<CommitIterationResult> FixTspConfigLocallyAsync(
        string specsRelativeDirectory,
        string localSpecsPath,
        string sdkNamespace,
        CancellationToken cancellationToken)
    {
        var specDir = ResolveSpecDirectory(localSpecsPath, specsRelativeDirectory);
        var configPath = Path.Combine(specDir, "tspconfig.yaml");

        if (!File.Exists(configPath))
        {
            return Fail($"tspconfig.yaml not found at: {configPath}");
        }

        var (fixSuccess, fixError) = ValidateTspConfigTool.FixTspConfig(configPath, sdkNamespace);
        if (!fixSuccess)
        {
            return Fail($"Failed to fix tspconfig.yaml: {fixError}");
        }

        await Task.CompletedTask.ConfigureAwait(false); // keep async signature for consistency

        return new CommitIterationResult
        {
            Success = true,
            UseLocalSpecs = true,
            Message = $"Fixed tspconfig.yaml locally at {configPath}. Use localSpecsPath for all subsequent code generation."
        };
    }

    // ── GitHub API helpers ───────────────────────────────────────────────

    /// <summary>
    /// Fetches a file from GitHub at a specific commit via raw.githubusercontent.com.
    /// Returns null when the file does not exist (404) or the request fails.
    /// </summary>
    internal static async Task<string?> FetchFileFromGitHubAsync(
        string repo, string commitSha, string filePath, CancellationToken cancellationToken)
    {
        var normalizedPath = filePath.Replace('\\', '/');
        var url = $"{GitHubRawBaseUrl}/{repo}/{commitSha}/{normalizedPath}";

        try
        {
            using var response = await s_httpClient.GetAsync(url, cancellationToken).ConfigureAwait(false);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)
                : null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the HEAD commit SHA of the repo's main branch.
    /// </summary>
    internal static async Task<string?> GetHeadCommitShaAsync(string repo, CancellationToken cancellationToken)
    {
        var url = $"{GitHubApiBaseUrl}/repos/{repo}/commits/main";

        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(GitHubApiMediaType));

            using var response = await s_httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.TryGetProperty("sha", out var sha) ? sha.GetString() : null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    /// <summary>
    /// Gets newer commits that touched the given spec directory, in chronological order (oldest first).
    /// </summary>
    internal static async Task<List<string>> GetNewerCommitsAsync(
        string repo, string sinceCommit, string specsDir, CancellationToken cancellationToken)
    {
        var commitDate = await GetCommitDateAsync(repo, sinceCommit, cancellationToken).ConfigureAwait(false);
        if (commitDate is null)
        {
            return [];
        }

        var sinceParam = Uri.EscapeDataString(commitDate);
        var pathParam = Uri.EscapeDataString(specsDir);
        var url = $"{GitHubApiBaseUrl}/repos/{repo}/commits?sha=main&path={pathParam}&since={sinceParam}";

        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(GitHubApiMediaType));

            using var response = await s_httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return [];
            }

            var json = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.ValueKind != JsonValueKind.Array)
            {
                return [];
            }

            var result = new List<string>();
            foreach (var item in doc.RootElement.EnumerateArray())
            {
                if (item.TryGetProperty("sha", out var shaElement))
                {
                    var sha = shaElement.GetString();
                    if (sha is not null && sha != sinceCommit)
                    {
                        result.Add(sha);
                    }
                }
            }

            // GitHub API returns newest first; reverse to oldest first
            result.Reverse();
            return result;
        }
        catch (HttpRequestException)
        {
            return [];
        }
    }

    /// <summary>
    /// Gets the committer date for a specific commit SHA.
    /// </summary>
    private static async Task<string?> GetCommitDateAsync(
        string repo, string commitSha, CancellationToken cancellationToken)
    {
        var url = $"{GitHubApiBaseUrl}/repos/{repo}/commits/{commitSha}";

        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(GitHubApiMediaType));

            using var response = await s_httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("commit", out var commitObj)
                && commitObj.TryGetProperty("committer", out var committer)
                && committer.TryGetProperty("date", out var date))
            {
                return date.GetString();
            }

            return null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    // ── Local git helpers ────────────────────────────────────────────────

    /// <summary>
    /// Walks up the directory tree to find the .git root.
    /// </summary>
    internal static string? FindGitRepoRoot(string startPath)
    {
        var dir = Directory.Exists(startPath) ? startPath : Path.GetDirectoryName(startPath);
        while (dir is not null)
        {
            if (Directory.Exists(Path.Combine(dir, ".git")))
            {
                return dir;
            }
            dir = Path.GetDirectoryName(dir);
        }
        return null;
    }

    // ── YAML helpers ─────────────────────────────────────────────────────

    /// <summary>
    /// Reads a top-level YAML field value using simple line parsing.
    /// </summary>
    internal static string? ReadYamlField(string yamlContent, string fieldName)
    {
        var prefix = $"{fieldName}:";
        foreach (var line in yamlContent.Split('\n'))
        {
            var trimmed = line.Trim();
            if (trimmed.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                var value = trimmed[prefix.Length..].Trim().Trim('"', '\'');
                return string.IsNullOrEmpty(value) ? null : value;
            }
        }
        return null;
    }

    /// <summary>
    /// Writes a YAML field value in-place, or appends it if it does not exist.
    /// </summary>
    private static async Task WriteYamlFieldAsync(
        string filePath, string fieldName, string value, CancellationToken cancellationToken)
    {
        var lines = await File.ReadAllLinesAsync(filePath, cancellationToken).ConfigureAwait(false);
        var prefix = $"{fieldName}:";
        var found = false;

        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].TrimStart().StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                lines[i] = $"{fieldName}: {value}";
                found = true;
                break;
            }
        }

        if (found)
        {
            await File.WriteAllLinesAsync(filePath, lines, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            await File.AppendAllTextAsync(filePath, $"\n{fieldName}: {value}\n", cancellationToken).ConfigureAwait(false);
        }
    }

    // ── Shared utilities ─────────────────────────────────────────────────

    private static async Task<string?> ResolveRepoAsync(
        string? repo, string tspLocationPath, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(repo))
        {
            return repo;
        }

        var tspContent = await File.ReadAllTextAsync(tspLocationPath, cancellationToken).ConfigureAwait(false);
        return ReadYamlField(tspContent, "repo");
    }

    private static string ResolveSpecDirectory(string localSpecsPath, string specsRelativeDirectory)
    {
        if (!File.Exists(Path.Combine(localSpecsPath, "tspconfig.yaml"))
            && Directory.Exists(Path.Combine(localSpecsPath, specsRelativeDirectory)))
        {
            return Path.Combine(localSpecsPath, specsRelativeDirectory);
        }
        return localSpecsPath;
    }

    private static CommitIterationResult MakeInvalidResult(string commit, string reason, bool strict)
    {
        return strict
            ? Fail($"Invalid commit {AbbrevSha(commit)}: {reason}")
            : Fail(reason);
    }

    private static CommitIterationResult Fail(string message)
        => new() { Success = false, Message = message };

    private static string AbbrevSha(string sha)
        => sha.Length > CommitShaDisplayLength ? sha[..CommitShaDisplayLength] : sha;

    private static HttpClient CreateHttpClient()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.Add(
            new ProductInfoHeaderValue("AzureGeneratorAgent", "1.0"));
        return client;
    }
}
