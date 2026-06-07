// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Loads optimization config with graceful fallback using a 4-priority resolution waterfall.
/// </summary>
/// <remarks>
/// Resolution order (first match wins):
/// <list type="number">
/// <item><description><b>Inline JSON</b> — <c>OPTIMIZATION_CONFIG</c> env var contains the full config as JSON.</description></item>
/// <item><description><b>Resolver API</b> — <c>OPTIMIZATION_CANDIDATE_ID</c> and <c>OPTIMIZATION_RESOLVE_ENDPOINT</c> are both set.</description></item>
/// <item><description><b>Local directory</b> — reads from <c>&lt;config_dir&gt;/&lt;candidate_id&gt;/</c> (or <c>&lt;config_dir&gt;/baseline/</c>).</description></item>
/// <item><description>When none of the above match, returns <c>null</c>.</description></item>
/// </list>
/// </remarks>
public static class OptimizationConfigLoader
{
    /// <summary>
    /// Loads optimization config asynchronously using the 4-priority resolution waterfall.
    /// </summary>
    /// <param name="options">Optional loader configuration.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved config, or <c>null</c> if no config source was found.</returns>
    public static async Task<OptimizationConfig?> LoadConfigAsync(
        ConfigLoaderOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        options ??= new ConfigLoaderOptions();

        // ── Priority 1: Inline JSON env var ─────────────────────────
        string rawConfig = Environment.GetEnvironmentVariable(OptimizationConfig.EnvConfig)?.Trim() ?? "";
        if (!string.IsNullOrEmpty(rawConfig))
        {
            return LoadFromEnvVar(rawConfig);
        }

        // ── Priority 2: Candidate ID → resolver API ────────────────
        string candidateId = Environment.GetEnvironmentVariable(OptimizationConfig.EnvCandidateId)?.Trim() ?? "";
        string endpoint = Environment.GetEnvironmentVariable(OptimizationConfig.EnvResolveEndpoint)?.Trim()?.TrimEnd('/') ?? "";

        if (!string.IsNullOrEmpty(candidateId) && !string.IsNullOrEmpty(endpoint))
        {
            string localDir = LocalConfigReader.ResolveLocalDir(options.ConfigDirectory);
            var resolved = await CandidateResolver.ResolveAsync(
                candidateId, endpoint, localDir, options.Credential, cancellationToken).ConfigureAwait(false);

            if (resolved.HasValue)
            {
                var candidate = CandidateConfig.FromDictionary(resolved.Value);
                string? skillsDir = resolved.Value.TryGetProperty("skills_dir", out var sdProp) && sdProp.ValueKind == JsonValueKind.String
                    ? sdProp.GetString()
                    : null;

                return new OptimizationConfig(
                    instructions: candidate.Instructions,
                    model: candidate.Model,
                    temperature: candidate.Temperature,
                    skills: candidate.Skills,
                    skillsDirectory: skillsDir,
                    toolDefinitions: candidate.ToolDefinitions,
                    source: $"api:candidate:{candidateId}",
                    candidateId: candidateId);
            }
        }

        // ── Priority 3: Local directory ─────────────────────────────
        string? effectiveCandidateId = string.IsNullOrEmpty(candidateId) ? null : candidateId;
        var localConfig = LocalConfigReader.Load(effectiveCandidateId, options.ConfigDirectory);
        if (localConfig is not null)
            return localConfig;

        // ── Priority 4: No config found ─────────────────────────────
        return null;
    }

    /// <summary>
    /// Loads optimization config synchronously using the 4-priority resolution waterfall.
    /// </summary>
    /// <param name="options">Optional loader configuration.</param>
    /// <returns>The resolved config, or <c>null</c> if no config source was found.</returns>
    public static OptimizationConfig? LoadConfig(ConfigLoaderOptions? options = null)
    {
#pragma warning disable AZC0102 // TaskExtensions.EnsureCompleted not available in this context
        return LoadConfigAsync(options).GetAwaiter().GetResult();
#pragma warning restore AZC0102
    }

    /// <summary>
    /// Loads skills from a directory of skill folders.
    /// </summary>
    /// <param name="skillsDirectory">Path to the skills directory.</param>
    /// <returns>A list of parsed skills.</returns>
    public static IReadOnlyList<OptimizationSkill> LoadSkillsFromDirectory(string skillsDirectory)
    {
        return LocalConfigReader.LoadSkillsFromDirectory(skillsDirectory);
    }

    private static OptimizationConfig LoadFromEnvVar(string rawConfig)
    {
        try
        {
            using var doc = JsonDocument.Parse(rawConfig);
            var candidate = CandidateConfig.FromDictionary(doc.RootElement);
            return new OptimizationConfig(
                instructions: candidate.Instructions,
                model: candidate.Model,
                temperature: candidate.Temperature,
                skills: candidate.Skills,
                toolDefinitions: candidate.ToolDefinitions,
                source: $"env:{OptimizationConfig.EnvConfig}");
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException($"Bad {OptimizationConfig.EnvConfig} env var: {ex.Message}", ex);
        }
    }
}
