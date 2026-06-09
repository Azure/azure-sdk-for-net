// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Resolved optimization config returned by <see cref="OptimizationConfigLoader.LoadConfigAsync"/>.
/// Contains the optimized instructions, model, temperature, skills, and tool definitions.
/// </summary>
public class OptimizationConfig
{
    /// <summary>Environment variable name for inline JSON config (Priority 1).</summary>
    public const string EnvironmentVariableConfig = "OPTIMIZATION_CONFIG";

    /// <summary>Environment variable name for the candidate ID (Priority 2).</summary>
    public const string EnvironmentVariableCandidateId = "OPTIMIZATION_CANDIDATE_ID";

    /// <summary>Environment variable name for the resolver API endpoint (Priority 2).</summary>
    public const string EnvironmentVariableResolveEndpoint = "OPTIMIZATION_RESOLVE_ENDPOINT";

    /// <summary>Environment variable name for the local config directory override (Priority 3).</summary>
    public const string EnvironmentVariableLocalDir = "OPTIMIZATION_LOCAL_DIR";

    // ── Default paths / filenames ───────────────────────────────────
    internal const string DefaultLocalDir = ".agent_configs";
    internal const string MetadataFile = "metadata.yaml";
    internal const string InstructionsFile = "instructions.md";
    internal const string ToolsFile = "tools.json";
    internal const string SkillsDir = "skills";
    internal const string SkillFile = "SKILL.md";
    internal const string BaselineDir = "baseline";

    /// <summary>
    /// Initializes a new instance of the <see cref="OptimizationConfig"/> class.
    /// </summary>
    public OptimizationConfig(
        string instructions = null,
        string model = null,
        double? temperature = null,
        IReadOnlyList<OptimizationSkill> skills = null,
        string skillsDirectory = null,
        IReadOnlyList<BinaryData> toolDefinitions = null,
        string source = "defaults",
        string candidateId = null)
    {
        Instructions = instructions;
        Model = model;
        Temperature = temperature;
        Skills = skills ?? Array.Empty<OptimizationSkill>();
        SkillsDirectory = skillsDirectory;
        ToolDefinitions = toolDefinitions ?? Array.Empty<BinaryData>();
        Source = source;
        CandidateId = candidateId;
    }

    /// <summary>Optimized system prompt text.</summary>
    public string Instructions { get; }

    /// <summary>Model deployment name (e.g. "gpt-4o").</summary>
    public string Model { get; }

    /// <summary>Sampling temperature.</summary>
    public double? Temperature { get; }

    /// <summary>Learned skills from optimization.</summary>
    public IReadOnlyList<OptimizationSkill> Skills { get; }

    /// <summary>Path to a directory containing skill files for on-demand loading.</summary>
    public string SkillsDirectory { get; }

    /// <summary>Tool definitions in OpenAI function-calling format, serialized as JSON.</summary>
    public IReadOnlyList<BinaryData> ToolDefinitions { get; }

    /// <summary>Where the config was loaded from (e.g. "env:OPTIMIZATION_CONFIG", "api:candidate:abc", "local:/path").</summary>
    public string Source { get; }

    /// <summary>The candidate identifier, if resolved from API or local directory.</summary>
    public string CandidateId { get; }

    /// <summary>
    /// Gets a value indicating whether this config carries any skill data (inline or via directory).
    /// </summary>
    public bool HasSkills => Skills.Count > 0 || SkillsDirectory != null;

    /// <summary>
    /// Builds a lookup of optimized tool definitions keyed by function name.
    /// </summary>
    /// <returns>A dictionary mapping function name to the full tool definition JSON.</returns>
    public IReadOnlyDictionary<string, BinaryData> GetToolDefinitionsByName()
    {
        var lookup = new Dictionary<string, BinaryData>(StringComparer.Ordinal);
        foreach (var tool in ToolDefinitions)
        {
            try
            {
                using var doc = JsonDocument.Parse(tool);
                if (doc.RootElement.TryGetProperty("function", out var func) &&
                    func.TryGetProperty("name", out var nameProp) &&
                    nameProp.ValueKind == JsonValueKind.String)
                {
                    string name = nameProp.GetString();
                    if (name.Length > 0)
                    {
                        lookup[name] = tool;
                    }
                }
            }
            catch (JsonException)
            {
                // Skip malformed tool definitions
            }
        }
        return lookup;
    }

    /// <summary>
    /// Gets the optimized description for a tool by function name.
    /// </summary>
    /// <param name="functionName">The function name to look up.</param>
    /// <returns>The optimized description, or <c>null</c> if not found.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="functionName"/> is null.</exception>
    public string GetToolDescription(string functionName)
    {
        if (string.IsNullOrEmpty(functionName))
        {
            throw new ArgumentNullException(nameof(functionName));
        }

        foreach (var tool in ToolDefinitions)
        {
            try
            {
                using var doc = JsonDocument.Parse(tool);
                if (doc.RootElement.TryGetProperty("function", out var func) &&
                    func.TryGetProperty("name", out var nameProp) &&
                    nameProp.ValueKind == JsonValueKind.String &&
                    nameProp.GetString() == functionName &&
                    func.TryGetProperty("description", out var descProp) &&
                    descProp.ValueKind == JsonValueKind.String)
                {
                    return descProp.GetString();
                }
            }
            catch (JsonException)
            {
                // Skip malformed tool definitions
            }
        }
        return null;
    }

    /// <summary>
    /// Returns instructions with a skill catalog appended (if any skills are present).
    /// </summary>
    /// <returns>The composed instructions string.</returns>
    public string ComposeInstructions()
    {
        string baseInstructions = Instructions ?? "";

        if (Skills.Count == 0)
        {
            return baseInstructions;
        }

        var sb = new StringBuilder();
        if (!string.IsNullOrEmpty(baseInstructions))
        {
            sb.AppendLine(baseInstructions);
            sb.AppendLine();
        }
        sb.AppendLine("## Available Skills");
        foreach (var skill in Skills)
        {
            sb.AppendLine($"- **{skill.Name}**: {skill.Description}");
        }
        return sb.ToString().TrimEnd();
    }

    /// <inheritdoc/>
    public override string ToString() => $"OptimizationConfig(source={Source}, model={Model}, candidate_id={CandidateId})";
}
