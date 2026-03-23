// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that iterates through commits to find one with a valid tspconfig.yaml emitter config,
/// or creates a fallback commit with the correct config.
/// </summary>
[McpServerToolType]
public static class CommitIterationTool
{
    [McpServerTool(Name = "commit_iteration"), Description("Iterate through spec repo commits to find one with a valid tspconfig.yaml emitter config for the given SDK namespace. Creates a fallback commit if none found. If commitOverride is provided, skips all iteration and uses that commit directly.")]
    public static async Task<string> Execute(
        [Description("Path to the SDK project directory (e.g., sdk/translation/Azure.AI.Translation.Document)")] string sdkProjectPath,
        [Description("Path to the tsp-location.yaml file")] string tspLocationPath,
        [Description("Relative directory path within the specs repo (from tsp-location.yaml 'directory' field)")] string specsRelativeDirectory,
        [Description("Full path to the local specs directory (e.g., .../azure-rest-api-specs/specification/translation/...)")] string localSpecsPath,
        [Description("Optional. If provided, skip all iteration/validation and use this commit SHA directly.")] string? commitOverride = null)
    {
        try
        {
            sdkProjectPath = Path.GetFullPath(sdkProjectPath);
            tspLocationPath = Path.GetFullPath(tspLocationPath);
            localSpecsPath = Path.GetFullPath(localSpecsPath);

            var (success, message) = await ExecuteInProcessAsync(sdkProjectPath, tspLocationPath, specsRelativeDirectory, localSpecsPath, commitOverride, CancellationToken.None).ConfigureAwait(false);
            return JsonSerializer.Serialize(new { success, message });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// In-process execution for direct invocation from the CLI command.
    /// </summary>
    public static async Task<(bool Success, string Message)> ExecuteInProcessAsync(
        string sdkProjectPath,
        string tspLocationPath,
        string specsRelativeDirectory,
        string localSpecsPath,
        string? commitOverride,
        CancellationToken cancellationToken)
    {
        // If a commit override is provided, skip all iteration/validation and use it directly
        if (!string.IsNullOrWhiteSpace(commitOverride))
        {
            await WriteYamlFieldAsync(tspLocationPath, "commit", commitOverride.Trim(), cancellationToken).ConfigureAwait(false);
            return (true, $"Using provided commit override: {commitOverride.Trim()}");
        }

        var sdkNamespace = Path.GetFileName(sdkProjectPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

        var specsRepoRoot = FindGitRepoRoot(localSpecsPath);
        if (specsRepoRoot is null)
        {
            return (false, $"Could not find git repo root from specs path: {localSpecsPath}");
        }

        // Resolve the actual spec directory: localSpecsPath may be the repo root or the full spec dir.
        // If tspconfig.yaml doesn't exist directly under localSpecsPath, combine with specsRelativeDirectory.
        var actualSpecDir = localSpecsPath;
        if (!File.Exists(Path.Combine(localSpecsPath, "tspconfig.yaml"))
            && File.Exists(Path.Combine(localSpecsPath, specsRelativeDirectory, "tspconfig.yaml")))
        {
            actualSpecDir = Path.Combine(localSpecsPath, specsRelativeDirectory);
        }

        // Read current commit from tsp-location.yaml
        var tspContent = await File.ReadAllTextAsync(tspLocationPath, cancellationToken).ConfigureAwait(false);
        var currentCommit = ReadYamlField(tspContent, "commit");
        if (string.IsNullOrEmpty(currentCommit))
        {
            return (false, "No commit field found in tsp-location.yaml");
        }

        // Get newer commits (limited to last 20, in chronological order oldest→newest)
        var newerCommits = await GetNewerCommitsAsync(specsRepoRoot, currentCommit, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);

        // Search order: current commit first, then newer commits oldest→newest.
        // We want the OLDEST commit that has a valid tspconfig (new emitter config),
        // because that minimizes spec drift from the starting point.
        var candidates = new List<string> { currentCommit };
        candidates.AddRange(newerCommits);

        // Iterate commits to find one with valid tspconfig
        foreach (var commit in candidates)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await RunGitAsync(specsRepoRoot, $"checkout {commit} -- {specsRelativeDirectory}", cancellationToken).ConfigureAwait(false);

            var tspConfigPath = Path.Combine(actualSpecDir, "tspconfig.yaml");
            var validation = ValidateTspConfigTool.ValidateInProcess(tspConfigPath, sdkNamespace);

            if (validation.IsValid)
            {
                await WriteYamlFieldAsync(tspLocationPath, "commit", commit, cancellationToken).ConfigureAwait(false);
                await RestoreWorkingTree(specsRepoRoot, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);
                return (true, $"Found valid commit: {commit}");
            }
        }

        // Fallback — fix the latest commit's tspconfig
        var latestCommit = candidates[^1];

        var originalBranch = (await RunGitAsync(specsRepoRoot, "rev-parse --abbrev-ref HEAD", cancellationToken).ConfigureAwait(false)).Trim();
        if (originalBranch == "HEAD")
        {
            originalBranch = (await RunGitAsync(specsRepoRoot, "rev-parse HEAD", cancellationToken).ConfigureAwait(false)).Trim();
        }

        await RunGitAsync(specsRepoRoot, $"checkout {latestCommit} -- {specsRelativeDirectory}", cancellationToken).ConfigureAwait(false);

        var fallbackConfigPath = Path.Combine(actualSpecDir, "tspconfig.yaml");
        var (fixSuccess, fixError) = ValidateTspConfigTool.FixTspConfig(fallbackConfigPath, sdkNamespace);
        if (!fixSuccess)
        {
            await RestoreWorkingTree(specsRepoRoot, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);
            return (false, $"Failed to fix tspconfig.yaml: {fixError}");
        }

        await RunGitAsync(specsRepoRoot, "checkout -b sdk-migration-fallback", cancellationToken).ConfigureAwait(false);
        await RunGitAsync(specsRepoRoot, $"add {specsRelativeDirectory}/tspconfig.yaml", cancellationToken).ConfigureAwait(false);
        await RunGitAsync(specsRepoRoot, "commit -m \"Update tspconfig.yaml for SDK migration: set @azure-typespec/http-client-csharp emitter config\"", cancellationToken).ConfigureAwait(false);

        var newCommitSha = (await RunGitAsync(specsRepoRoot, "rev-parse HEAD", cancellationToken).ConfigureAwait(false)).Trim();
        await WriteYamlFieldAsync(tspLocationPath, "commit", newCommitSha, cancellationToken).ConfigureAwait(false);

        // Restore original branch
        await RunGitAsync(specsRepoRoot, $"checkout {originalBranch}", cancellationToken).ConfigureAwait(false);
        await RestoreWorkingTree(specsRepoRoot, specsRelativeDirectory, cancellationToken).ConfigureAwait(false);

        return (true, $"Created fallback commit: {newCommitSha}");
    }

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

    private static async Task<List<string>> GetNewerCommitsAsync(string repoRoot, string startingCommit, string specsDir, CancellationToken cancellationToken)
    {
        // Limit to last 20 commits to avoid slow iteration on large repos like azure-rest-api-specs
        var output = await RunGitAsync(repoRoot, $"log --format=\"%H\" --reverse -20 {startingCommit}..HEAD -- {specsDir}", cancellationToken).ConfigureAwait(false);
        return output
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Where(l => l.Length == 40 && l.All(char.IsAsciiHexDigit))
            .ToList();
    }

    private static async Task RestoreWorkingTree(string repoRoot, string specsDir, CancellationToken cancellationToken)
    {
        await RunGitAsync(repoRoot, $"checkout HEAD -- {specsDir}", cancellationToken).ConfigureAwait(false);
    }

    private static string? ReadYamlField(string yamlContent, string fieldName)
    {
        foreach (var line in yamlContent.Split('\n'))
        {
            var trimmed = line.Trim();
            if (trimmed.StartsWith($"{fieldName}:", StringComparison.OrdinalIgnoreCase))
            {
                var value = trimmed[($"{fieldName}:".Length)..].Trim().Trim('"', '\'');
                return string.IsNullOrEmpty(value) ? null : value;
            }
        }
        return null;
    }

    private static async Task WriteYamlFieldAsync(string filePath, string fieldName, string value, CancellationToken cancellationToken)
    {
        var lines = await File.ReadAllLinesAsync(filePath, cancellationToken).ConfigureAwait(false);
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].TrimStart().StartsWith($"{fieldName}:", StringComparison.OrdinalIgnoreCase))
            {
                lines[i] = $"{fieldName}: {value}";
                break;
            }
        }
        await File.WriteAllLinesAsync(filePath, lines, cancellationToken).ConfigureAwait(false);
    }

    private static readonly Dictionary<string, string> s_gitEnv = new()
    {
        ["GIT_TERMINAL_PROMPT"] = "0"
    };

    private static async Task<string> RunGitAsync(string workingDirectory, string arguments, CancellationToken cancellationToken)
    {
        var (output, _) = await ProcessRunner.RunAsync("git", arguments, workingDirectory, s_gitEnv, cancellationToken).ConfigureAwait(false);
        return output;
    }
}
