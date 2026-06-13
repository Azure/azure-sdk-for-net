// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Loads <see cref="OptimizationOptions"/> with graceful fallback using a 4-priority
/// resolution waterfall.
/// </summary>
/// <remarks>
/// Resolution order (first match wins):
/// <list type="number">
/// <item><description><b>Resolver API</b> — <c>OPTIMIZATION_CANDIDATE_ID</c> and <c>OPTIMIZATION_RESOLVE_ENDPOINT</c> are both set.</description></item>
/// <item><description><b>Inline JSON</b> — <c>OPTIMIZATION_CONFIG</c> env var contains the full config as JSON.</description></item>
/// <item><description><b>Local candidate directory</b> — <c>OPTIMIZATION_CANDIDATE_ID</c> is set and <c>OPTIMIZATION_LOCAL_DIR/&lt;candidate_id&gt;/</c> exists on disk. This is what <c>azd ai agent optimize apply --candidate</c> writes.</description></item>
/// <item><description><b>Local baseline directory</b> — <c>OPTIMIZATION_LOCAL_DIR/baseline/</c> exists on disk.</description></item>
/// <item><description>When none of the above match, returns <c>null</c>.</description></item>
/// </list>
/// <para>
/// Multi-agent hosts can scope env-var lookups per agent by passing
/// <see cref="LoadOptions.AgentKey"/>: the loader prefers
/// <c>OPTIMIZATION_&lt;VAR&gt;__&lt;CANONICAL_KEY&gt;</c> over the un-suffixed variant.
/// </para>
/// </remarks>
public static class OptimizationOptionsLoader
{
    private static readonly TimeSpan s_defaultResolverTimeout = TimeSpan.FromSeconds(30);

    /// <summary>
    /// Loads <see cref="OptimizationOptions"/> synchronously using the resolution
    /// waterfall.
    /// </summary>
    /// <param name="options">Optional resolution options; when <c>null</c>, defaults are used.</param>
    /// <returns>The resolved options, or <c>null</c> when no source matched.</returns>
    public static OptimizationOptions Load(LoadOptions options = null)
    {
#pragma warning disable AZC0102 // TaskExtensions.EnsureCompleted not available in this context
        return LoadAsync(options, default).GetAwaiter().GetResult();
#pragma warning restore AZC0102
    }

    /// <summary>
    /// Loads <see cref="OptimizationOptions"/> asynchronously using the resolution
    /// waterfall.
    /// </summary>
    /// <param name="options">Optional resolution options; when <c>null</c>, defaults are used.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved options, or <c>null</c> when no source matched.</returns>
    public static async Task<OptimizationOptions> LoadAsync(
        LoadOptions options = null,
        CancellationToken cancellationToken = default)
    {
        options ??= new LoadOptions();

        string canonicalKey = null;
        if (!string.IsNullOrEmpty(options.AgentKey))
        {
            canonicalKey = AgentKeyCanonicalizer.Canonicalize(options.AgentKey, nameof(options.AgentKey) + " on " + nameof(LoadOptions));
        }

        bool allowUnsuffixedFallback = canonicalKey is null || options.FallbackToUnsuffixedEnvVars;

        string candidateId = ResolveEnvVar(OptimizationOptions.EnvironmentVariableCandidateId, canonicalKey, allowUnsuffixedFallback);
        string endpoint = ResolveEnvVar(OptimizationOptions.EnvironmentVariableResolveEndpoint, canonicalKey, allowUnsuffixedFallback)?.TrimEnd('/');

        // ── Priority 1: Resolver API ────────────────────────────────
        if (!string.IsNullOrEmpty(candidateId) && !string.IsNullOrEmpty(endpoint))
        {
            using var linked = CreateResolverCancellation(cancellationToken, options.ResolverTimeout ?? s_defaultResolverTimeout);
            try
            {
                var resolved = await CandidateResolver.ResolveAsync(
                    candidateId, endpoint, options.TokenProvider, linked.Token).ConfigureAwait(false);

                if (resolved.HasValue)
                {
                    string source = $"api:candidate:{candidateId}";
                    return OptimizationOptions.FromJson(resolved.Value, source: source, candidateId: candidateId);
                }
            }
            catch (Exception ex) when (!options.StrictMode)
            {
                Console.Error.WriteLine(
                    $"[AgentServer.Optimization] Warning: Failed to resolve config for candidate '{candidateId}' from '{endpoint}': {ex.Message}");
                // Resolver failure is non-fatal in non-strict mode — fall through to next priority.
            }
        }

        // ── Priority 2: Inline JSON env var ─────────────────────────
        // Inline JSON in OPTIMIZATION_CONFIG is an explicit signal — parse errors
        // always throw regardless of StrictMode (preserves back-compat).
        string rawConfig = ResolveEnvVar(OptimizationOptions.EnvironmentVariableConfig, canonicalKey, allowUnsuffixedFallback);
        if (!string.IsNullOrEmpty(rawConfig))
        {
            return LoadFromEnvVar(rawConfig);
        }

        // ── Priority 3: Local candidate directory ───────────────────
        // When `azd ai agent optimize apply --candidate <id>` runs, it writes the
        // candidate config to `<OPTIMIZATION_LOCAL_DIR>/<candidate_id>/` and sets
        // OPTIMIZATION_CANDIDATE_ID on the agent. If the candidate directory exists
        // on disk, prefer it over baseline so the deployed container actually exercises
        // the optimized config when the resolver API endpoint is not configured (the
        // common offline / preview case).
        string localDir = ResolveEnvVar(OptimizationOptions.EnvironmentVariableLocalDirectory, canonicalKey, allowUnsuffixedFallback);
        if (!string.IsNullOrEmpty(candidateId) && !string.IsNullOrEmpty(localDir))
        {
            if (!CandidateIdValidator.IsValid(candidateId))
            {
                string msg = $"Candidate ID '{candidateId}' is invalid (contains path separators or '..'); skipping local candidate directory.";
                if (options.StrictMode)
                {
                    throw new InvalidOperationException(msg);
                }
                Console.Error.WriteLine($"[AgentServer.Optimization] Warning: {msg}");
            }
            else
            {
                string candidatePath = Path.Combine(localDir, candidateId);
                if (Directory.Exists(candidatePath))
                {
                    return LoadFromLocalDirectory(candidatePath, candidateId, options.StrictMode);
                }
            }
        }

        // ── Priority 4: Local baseline directory ────────────────────
        if (!string.IsNullOrEmpty(localDir))
        {
            string baselinePath = Path.Combine(localDir, "baseline");
            if (Directory.Exists(baselinePath))
            {
                return LoadFromLocalDirectory(baselinePath, candidateId: null, options.StrictMode);
            }
        }

        // ── No config found ─────────────────────────────────────────
        return null;
    }

    /// <summary>
    /// Resolves an environment variable, preferring the per-agent suffixed form
    /// (<c>&lt;VAR&gt;__&lt;CANONICAL_KEY&gt;</c>) when <paramref name="canonicalKey"/>
    /// is non-null. Falls back to the un-suffixed form only when
    /// <paramref name="allowUnsuffixedFallback"/> is <c>true</c>.
    /// </summary>
    private static string ResolveEnvVar(string varName, string canonicalKey, bool allowUnsuffixedFallback)
    {
        if (canonicalKey is not null)
        {
            string suffixed = Environment.GetEnvironmentVariable($"{varName}__{canonicalKey}")?.Trim();
            if (!string.IsNullOrEmpty(suffixed))
            {
                return suffixed;
            }

            if (!allowUnsuffixedFallback)
            {
                return null;
            }
        }

        return Environment.GetEnvironmentVariable(varName)?.Trim();
    }

    private static CancellationTokenSource CreateResolverCancellation(CancellationToken outer, TimeSpan timeout)
    {
        var cts = CancellationTokenSource.CreateLinkedTokenSource(outer);
        cts.CancelAfter(timeout);
        return cts;
    }

    /// <summary>
    /// Loads skills from a directory of skill folders. Each subfolder should contain
    /// a <c>SKILL.md</c> file with optional YAML frontmatter (name, description) and
    /// a body.
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
            catch (IOException ex)
            {
                Console.Error.WriteLine($"[AgentServer.Optimization] Warning: Failed to read skill file '{skillFile}': {ex.Message}");
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

    private static OptimizationOptions LoadFromEnvVar(string rawConfig)
    {
        try
        {
            using var doc = JsonDocument.Parse(rawConfig);
            return OptimizationOptions.FromJson(
                doc.RootElement,
                source: $"env:{OptimizationOptions.EnvironmentVariableConfig}");
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException($"Bad {OptimizationOptions.EnvironmentVariableConfig} env var: {ex.Message}", ex);
        }
    }

    private static OptimizationOptions LoadFromLocalDirectory(
        string localDir,
        string candidateId = null,
        bool strict = false)
    {
        // Read instructions.md
        string instructionsPath = Path.Combine(localDir, "instructions.md");
        string instructions = File.Exists(instructionsPath)
            ? File.ReadAllText(instructionsPath).Trim()
            : null;

        // Read tools.json
        string toolsPath = Path.Combine(localDir, "tools.json");
        var tools = new List<ToolDefinition>();
        if (File.Exists(toolsPath))
        {
            try
            {
                using var doc = JsonDocument.Parse(File.ReadAllText(toolsPath));
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    // Wrap in {"tools": [...]} so FromJson can parse it.
                    string wrapped = $"{{\"tools\":{doc.RootElement.GetRawText()}}}";
                    using var wrappedDoc = JsonDocument.Parse(wrapped);
                    var parsed = OptimizationOptions.FromJson(wrappedDoc.RootElement);
                    foreach (var t in parsed.ToolDefinitions)
                    {
                        tools.Add(t);
                    }
                }
            }
            catch (JsonException ex)
            {
                string msg = $"Failed to parse tools.json at '{toolsPath}': {ex.Message}";
                if (strict)
                {
                    throw new InvalidOperationException(msg, ex);
                }
                Console.Error.WriteLine($"[AgentServer.Optimization] Warning: {msg}");
            }
        }

        // Load skills from skills/ subdirectory
        string skillsDir = Path.Combine(localDir, "skills");
        IReadOnlyList<OptimizationSkill> skills = LoadSkillsFromDirectory(skillsDir);

        var result = new OptimizationOptions
        {
            Instructions = instructions,
            SkillsDirectory = Directory.Exists(skillsDir) ? Path.GetFullPath(skillsDir) : null,
            ToolDefinitions = tools,
            Source = $"local:{localDir}",
            CandidateId = candidateId,
        };
        foreach (var s in skills)
        {
            result.Skills.Add(s);
        }
        return result;
    }
}
