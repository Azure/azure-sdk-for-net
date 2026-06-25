// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Extends <see cref="AgentOptimizationClient"/> with a public config resolution
/// method that wraps the internal REST call with env-var and local-file fallback.
/// </summary>
public partial class AgentOptimizationClient
{
    private static readonly TimeSpan s_defaultResolverTimeout = TimeSpan.FromSeconds(30);

    /// <summary>
    /// Resolves <see cref="OptimizationOptions"/> using a priority waterfall:
    /// <list type="number">
    /// <item><description><b>Resolver API</b> — calls the optimization service when
    /// <c>OPTIMIZATION_CANDIDATE_ID</c> and <c>OPTIMIZATION_RESOLVE_ENDPOINT</c> (or a configured endpoint) are set.</description></item>
    /// <item><description><b>Inline JSON</b> — <c>OPTIMIZATION_CONFIG</c> env var contains the full config.</description></item>
    /// <item><description><b>Local candidate directory</b> — <c>OPTIMIZATION_CANDIDATE_ID</c> set and local dir exists.</description></item>
    /// <item><description><b>Local baseline directory</b> — <c>OPTIMIZATION_LOCAL_DIR/baseline/</c> exists.</description></item>
    /// </list>
    /// Returns <c>null</c> when no source matches.
    /// </summary>
    /// <param name="options">Optional resolution options.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved options, or <c>null</c> when no source matched.</returns>
#pragma warning disable AZC0015 // Not a service method — local resolution waterfall that may skip the network entirely
#pragma warning disable AZC0004 // Sync counterpart is ResolveOptions below
    public virtual async Task<OptimizationOptions> ResolveOptionsAsync(
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
        string configuredEndpoint = _endpoint?.AbsoluteUri.TrimEnd('/');
        string effectiveEndpoint = endpoint ?? configuredEndpoint;

        // ── Priority 1: Resolver API ────────────────────────────────
        if (!string.IsNullOrEmpty(candidateId) && !string.IsNullOrEmpty(effectiveEndpoint))
        {
            using var linked = CreateResolverCancellation(cancellationToken, options.ResolverTimeout ?? s_defaultResolverTimeout);
            try
            {
                CandidateIdValidator.ThrowIfInvalid(candidateId, nameof(candidateId));

                Response<CandidateDeployConfig> response;
                if (string.Equals(effectiveEndpoint, configuredEndpoint, StringComparison.OrdinalIgnoreCase))
                {
                    response = await GetCandidateConfigFlatAsync(
                        candidateId,
                        cancellationToken: linked.Token).ConfigureAwait(false);
                }
                else
                {
                    if (options.Credential is null)
                    {
                        throw new InvalidOperationException(
                            "A credential must be provided when OPTIMIZATION_RESOLVE_ENDPOINT overrides the client's configured endpoint.");
                    }

                    var resolverClient = new AgentOptimizationClient(new Uri(effectiveEndpoint), options.Credential);
                    response = await resolverClient.GetCandidateConfigFlatAsync(
                        candidateId,
                        cancellationToken: linked.Token).ConfigureAwait(false);
                }

                if (response.Value != null)
                {
                    string source = $"api:candidate:{candidateId}";
                    return MapFromDeployConfig(response.Value, source, candidateId);
                }
            }
            catch (Exception ex) when (!options.StrictMode && !linked.Token.IsCancellationRequested)
            {
                System.Console.Error.WriteLine(
                    $"[AgentServer.Optimization] Warning: Failed to resolve config for candidate '{candidateId}': {ex.Message}");
            }
        }

        // ── Priority 2: Inline JSON env var ─────────────────────────
        string rawConfig = ResolveEnvVar(OptimizationOptions.EnvironmentVariableConfig, canonicalKey, allowUnsuffixedFallback);
        if (!string.IsNullOrEmpty(rawConfig))
        {
            return LoadFromEnvVar(rawConfig);
        }

        // ── Priority 3: Local candidate directory ───────────────────
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

                System.Console.Error.WriteLine($"[AgentServer.Optimization] Warning: {msg}");
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

        return null;
    }
#pragma warning restore AZC0004
#pragma warning restore AZC0015

    /// <summary>
    /// Synchronous version of <see cref="ResolveOptionsAsync"/>.
    /// </summary>
    /// <param name="options">Optional resolution options.</param>
    /// <returns>The resolved options, or <c>null</c> when no source matched.</returns>
    public virtual OptimizationOptions ResolveOptions(LoadOptions options = null)
    {
#pragma warning disable AZC0102
        return ResolveOptionsAsync(options, default).GetAwaiter().GetResult();
#pragma warning restore AZC0102
    }

    /// <summary>
    /// Loads skills from a directory of skill folders. Each subfolder should contain
    /// a <c>SKILL.md</c> file with optional YAML frontmatter.
    /// </summary>
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
                System.Console.Error.WriteLine($"[AgentServer.Optimization] Warning: Failed to read skill file '{skillFile}': {ex.Message}");
            }
        }

        return skills;
    }

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
        string instructionsPath = Path.Combine(localDir, "instructions.md");
        string instructions = File.Exists(instructionsPath)
            ? File.ReadAllText(instructionsPath).Trim()
            : null;

        string toolsPath = Path.Combine(localDir, "tools.json");
        var tools = new List<ToolDefinition>();
        if (File.Exists(toolsPath))
        {
            try
            {
                using var doc = JsonDocument.Parse(File.ReadAllText(toolsPath));
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
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

                System.Console.Error.WriteLine($"[AgentServer.Optimization] Warning: {msg}");
            }
        }

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
        foreach (var skill in skills)
        {
            result.Skills.Add(skill);
        }

        return result;
    }

    private static OptimizationOptions MapFromDeployConfig(CandidateDeployConfig config, string source, string candidateId)
    {
        var opts = new OptimizationOptions
        {
            Instructions = config.Instructions,
            Model = config.Model,
            Temperature = config.Temperature.HasValue ? (double)config.Temperature.Value : (double?)null,
            Source = source,
            CandidateId = candidateId,
        };

        if (config.Skills != null)
        {
            foreach (var skill in config.Skills)
            {
                if (skill?.Name != null)
                {
                    opts.Skills.Add(new OptimizationSkill(skill.Name, skill.Description ?? "", ""));
                }
            }
        }

        return opts;
    }

    private static void ParseSkillFile(string content, string folderName, out string name, out string description, out string body)
    {
        name = folderName;
        description = "";
        body = content;

        if (content.StartsWith("---", StringComparison.Ordinal))
        {
            int end = content.IndexOf("---", 3, StringComparison.Ordinal);
            if (end > 0)
            {
                string frontmatter = content.Substring(3, end - 3).Trim();
                body = content.Substring(end + 3).Trim();

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

        if (!string.IsNullOrEmpty(content))
        {
            string[] lines = content.Split(new[] { '\n' }, 2);
            description = lines[0].TrimStart('#').Trim();
            body = lines.Length > 1 ? lines[1].Trim() : "";
        }
    }
}
