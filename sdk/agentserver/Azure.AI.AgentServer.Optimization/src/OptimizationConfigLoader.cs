// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Loads optimization config with graceful fallback using a 3-priority resolution waterfall.
/// </summary>
/// <remarks>
/// Resolution order (first match wins):
/// <list type="number">
/// <item><description><b>Resolver API</b> — <c>OPTIMIZATION_CANDIDATE_ID</c> and <c>OPTIMIZATION_RESOLVE_ENDPOINT</c> are both set.</description></item>
/// <item><description><b>Inline JSON</b> — <c>OPTIMIZATION_CONFIG</c> env var contains the full config as JSON.</description></item>
/// <item><description>When none of the above match, returns <c>null</c>.</description></item>
/// </list>
/// </remarks>
public static class OptimizationConfigLoader
{
    /// <summary>
    /// Loads optimization config asynchronously using the 3-priority resolution waterfall.
    /// </summary>
    /// <param name="options">Optional loader configuration.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved config, or <c>null</c> if no config source was found.</returns>
    public static async Task<OptimizationConfig> LoadConfigAsync(
        ConfigLoaderOptions options = null,
        CancellationToken cancellationToken = default)
    {
        options ??= new ConfigLoaderOptions();

        string candidateId = Environment.GetEnvironmentVariable(OptimizationConfig.EnvironmentVariableCandidateId)?.Trim() ?? "";
        string endpoint = Environment.GetEnvironmentVariable(OptimizationConfig.EnvironmentVariableResolveEndpoint)?.Trim()?.TrimEnd('/') ?? "";

        // ── Priority 1: Resolver API ────────────────────────────────
        if (!string.IsNullOrEmpty(candidateId) && !string.IsNullOrEmpty(endpoint))
        {
            try
            {
                var resolved = await CandidateResolver.ResolveAsync(
                    candidateId, endpoint, options.Credential, cancellationToken).ConfigureAwait(false);

                if (resolved.HasValue)
                {
                    return OptimizationConfig.FromJson(
                        resolved.Value,
                        source: $"api:candidate:{candidateId}",
                        candidateId: candidateId);
                }
            }
            catch (Exception)
            {
                // Resolver failure is non-fatal — fall through to next priority
            }
        }

        // ── Priority 2: Inline JSON env var ─────────────────────────
        string rawConfig = Environment.GetEnvironmentVariable(OptimizationConfig.EnvironmentVariableConfig)?.Trim() ?? "";
        if (!string.IsNullOrEmpty(rawConfig))
        {
            return LoadFromEnvVar(rawConfig);
        }

        // ── Priority 3: No config found ─────────────────────────────
        return null;
    }

    /// <summary>
    /// Loads optimization config synchronously using the 3-priority resolution waterfall.
    /// </summary>
    /// <param name="options">Optional loader configuration.</param>
    /// <returns>The resolved config, or <c>null</c> if no config source was found.</returns>
    public static OptimizationConfig LoadConfig(ConfigLoaderOptions options = null)
    {
#pragma warning disable AZC0102 // TaskExtensions.EnsureCompleted not available in this context
        return LoadConfigAsync(options).GetAwaiter().GetResult();
#pragma warning restore AZC0102
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
}
