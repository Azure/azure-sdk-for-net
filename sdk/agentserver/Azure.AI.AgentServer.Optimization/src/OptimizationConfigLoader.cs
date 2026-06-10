// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Text.Json;
using System.ClientModel.Primitives;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Loads optimization config with graceful fallback using a 3-priority resolution waterfall.
/// </summary>
/// <remarks>
/// Resolution order (first match wins):
/// <list type="number">
/// <item><description><b>Resolver API</b> — <c>OPTIMIZATION_CANDIDATE_ID</c> and <c>OPTIMIZATION_RESOLVE_ENDPOINT</c> are both set.</description></item>
/// <item><description><b>Inline JSON</b> — <c>OPTIMIZATION_CONFIG</c> env var contains the full config as JSON.</description></item>
/// <item><description><b>Local baseline directory</b> — <c>OPTIMIZATION_LOCAL_DIR</c> points to a folder with instructions.md, tools.json, and skills/.</description></item>
/// <item><description>When none of the above match, returns <c>null</c>.</description></item>
/// </list>
/// </remarks>
public static class OptimizationConfigLoader
{
    /// <summary>
    /// Loads optimization config asynchronously using the resolution waterfall.
    /// </summary>
    /// <param name="tokenProvider">Optional token provider for authenticating to the resolver API.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved config, or <c>null</c> if no config source was found.</returns>
    public static async Task<OptimizationConfig> LoadConfigAsync(
        AuthenticationTokenProvider tokenProvider = null,
        CancellationToken cancellationToken = default)
    {
        string candidateId = Environment.GetEnvironmentVariable(OptimizationConfig.EnvironmentVariableCandidateId)?.Trim() ?? "";
        string endpoint = Environment.GetEnvironmentVariable(OptimizationConfig.EnvironmentVariableResolveEndpoint)?.Trim()?.TrimEnd('/') ?? "";

        // ── Priority 1: Resolver API ────────────────────────────────
        if (!string.IsNullOrEmpty(candidateId) && !string.IsNullOrEmpty(endpoint))
        {
            try
            {
                var resolved = await CandidateResolver.ResolveAsync(
                    candidateId, endpoint, tokenProvider, cancellationToken).ConfigureAwait(false);

                if (resolved.HasValue)
                {
                    return OptimizationConfig.FromJson(
                        resolved.Value,
                        source: $"api:candidate:{candidateId}",
                        candidateId: candidateId);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to resolve optimization config for candidate '{candidateId}' from '{endpoint}': {ex.Message}");
                // Resolver failure is non-fatal — fall through to next priority
            }
        }

        // ── Priority 2: Inline JSON env var ─────────────────────────
        string rawConfig = Environment.GetEnvironmentVariable(OptimizationConfig.EnvironmentVariableConfig)?.Trim() ?? "";
        if (!string.IsNullOrEmpty(rawConfig))
        {
            return LoadFromEnvVar(rawConfig);
        }

        // ── Priority 3: Local baseline directory ────────────────────
        string localDir = Environment.GetEnvironmentVariable(OptimizationConfig.EnvironmentVariableLocalDirectory)?.Trim() ?? "";
        if (!string.IsNullOrEmpty(localDir))
        {
            string baselinePath = Path.Combine(localDir, "baseline");
            if (Directory.Exists(baselinePath))
            {
                return LoadFromLocalDirectory(baselinePath);
            }
        }

        // ── No config found ─────────────────────────────────────────
        return null;
    }

    /// <summary>
    /// Loads optimization config synchronously using the resolution waterfall.
    /// </summary>
    /// <param name="tokenProvider">Optional token provider for authenticating to the resolver API.</param>
    /// <returns>The resolved config, or <c>null</c> if no config source was found.</returns>
    public static OptimizationConfig LoadConfig(AuthenticationTokenProvider tokenProvider = null)
    {
#pragma warning disable AZC0102 // TaskExtensions.EnsureCompleted not available in this context
        return LoadConfigAsync(tokenProvider).GetAwaiter().GetResult();
#pragma warning restore AZC0102
    }

    /// <summary>
    /// Loads skills from a directory of skill folders.
    /// Each subfolder should contain a <c>SKILL.md</c> file with optional YAML frontmatter
    /// (name, description) and a body.
    /// </summary>
    /// <param name="skillsDirectory">Path to the skills directory.</param>
    /// <returns>A list of parsed skills.</returns>
    public static IReadOnlyList<OptimizationSkill> LoadSkillsFromDirectory(string skillsDirectory)
    {
        if (string.IsNullOrEmpty(skillsDirectory) || !Directory.Exists(skillsDirectory))
        {
            return Array.Empty<OptimizationSkill>();
        }

        var skills = new List<OptimizationSkill>();
        foreach (var skillFolder in Directory.GetDirectories(skillsDirectory).OrderBy(d => d))
        {
            string skillFile = Path.Combine(skillFolder, "SKILL.md");
            if (!File.Exists(skillFile))
            {
                continue;
            }

            try
            {
                string content = File.ReadAllText(skillFile).Trim();
                ParseSkillFile(content, Path.GetFileName(skillFolder), out string name, out string description, out string body);
                skills.Add(new OptimizationSkill(name, description, body));
            }
            catch (IOException)
            {
                // Skip unreadable skill files
            }
        }

        return skills;
    }

    private static void ParseSkillFile(string content, string folderName, out string name, out string description, out string body)
    {
        name = folderName;
        description = "";
        body = content;

        // Check for YAML frontmatter (--- delimited)
        if (content.StartsWith("---", StringComparison.Ordinal))
        {
            int end = content.IndexOf("---", 3, StringComparison.Ordinal);
            if (end > 0)
            {
                string frontmatter = content.Substring(3, end - 3).Trim();
                body = content.Substring(end + 3).Trim();

                // Simple key: value parsing for name and description
                foreach (string line in frontmatter.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    int sep = line.IndexOf(':');
                    if (sep <= 0)
                    {
                        continue;
                    }

                    string key = line.Substring(0, sep).Trim();
                    string value = line.Substring(sep + 1).Trim();

                    if (key == "name")
                    {
                        name = value;
                    }
                    else if (key == "description")
                    {
                        description = value;
                    }
                }

                return;
            }
        }

        // No frontmatter — first line is description, rest is body
        if (!string.IsNullOrEmpty(content))
        {
            string[] lines = content.Split(new[] { '\n' }, 2);
            description = lines[0].TrimStart('#').Trim();
            body = lines.Length > 1 ? lines[1].Trim() : "";
        }
    }

    private static OptimizationConfig LoadFromEnvVar(string rawConfig)
    {
        try
        {
            using var doc = JsonDocument.Parse(rawConfig);
            return OptimizationConfig.FromJson(
                doc.RootElement,
                source: $"env:{OptimizationConfig.EnvironmentVariableConfig}");
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException($"Bad {OptimizationConfig.EnvironmentVariableConfig} env var: {ex.Message}", ex);
        }
    }

    private static OptimizationConfig LoadFromLocalDirectory(string localDir)
    {
        // Read instructions.md
        string instructionsPath = Path.Combine(localDir, "instructions.md");
        string instructions = File.Exists(instructionsPath)
            ? File.ReadAllText(instructionsPath).Trim()
            : null;

        // Read tools.json
        string toolsPath = Path.Combine(localDir, "tools.json");
        IReadOnlyList<ToolDefinition> tools = Array.Empty<ToolDefinition>();
        if (File.Exists(toolsPath))
        {
            try
            {
                using var doc = JsonDocument.Parse(File.ReadAllText(toolsPath));
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    // Wrap in {"tools": [...]} so FromJson can parse it
                    string wrapped = $"{{\"tools\":{doc.RootElement.GetRawText()}}}";
                    using var wrappedDoc = JsonDocument.Parse(wrapped);
                    tools = OptimizationConfig.FromJson(wrappedDoc.RootElement).ToolDefinitions;
                }
            }
            catch (JsonException)
            {
                // Skip malformed tools.json
            }
        }

        // Load skills from skills/ subdirectory
        string skillsDir = Path.Combine(localDir, "skills");
        IReadOnlyList<OptimizationSkill> skills = LoadSkillsFromDirectory(skillsDir);

        return new OptimizationConfig(
            instructions: instructions,
            skills: skills,
            skillsDirectory: Directory.Exists(skillsDir) ? Path.GetFullPath(skillsDir) : null,
            toolDefinitions: tools,
            source: $"local:{localDir}");
    }
}
