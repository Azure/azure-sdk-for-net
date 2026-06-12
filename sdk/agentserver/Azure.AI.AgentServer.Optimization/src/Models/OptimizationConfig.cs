// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Resolved optimization config returned by <see cref="OptimizationConfigLoader.LoadConfigAsync(System.ClientModel.AuthenticationTokenProvider, System.Threading.CancellationToken)"/>.
/// Contains the optimized instructions, model, temperature, skills, and tool definitions.
/// </summary>
public class OptimizationConfig
{
    /// <summary>Environment variable name for inline JSON config (Priority 2).</summary>
    public const string EnvironmentVariableConfig = "OPTIMIZATION_CONFIG";

    /// <summary>Environment variable name for the candidate ID (Priority 1).</summary>
    public const string EnvironmentVariableCandidateId = "OPTIMIZATION_CANDIDATE_ID";

    /// <summary>Environment variable name for the resolver API endpoint (Priority 1).</summary>
    public const string EnvironmentVariableResolveEndpoint = "OPTIMIZATION_RESOLVE_ENDPOINT";

    /// <summary>Environment variable name for the local baseline directory (Priority 3).</summary>
    public const string EnvironmentVariableLocalDirectory = "OPTIMIZATION_LOCAL_DIR";

    /// <summary>
    /// Initializes a new instance of the <see cref="OptimizationConfig"/> class.
    /// </summary>
    public OptimizationConfig(
        string instructions = null,
        string model = null,
        double? temperature = null,
        IReadOnlyList<OptimizationSkill> skills = null,
        string skillsDirectory = null,
        IReadOnlyList<ToolDefinition> toolDefinitions = null,
        string source = "defaults",
        string candidateId = null)
    {
        Instructions = instructions;
        Model = model;
        Temperature = temperature;
        Skills = skills ?? Array.Empty<OptimizationSkill>();
        SkillsDirectory = skillsDirectory;
        ToolDefinitions = toolDefinitions ?? Array.Empty<ToolDefinition>();
        Source = source;
        CandidateId = candidateId;
    }

    /// <summary>
    /// Creates an <see cref="OptimizationConfig"/> from a JSON element (API response or env var payload).
    /// </summary>
    internal static OptimizationConfig FromJson(JsonElement data, string source = "defaults", string candidateId = null)
    {
        string instructions = data.TryGetProperty("instructions", out var instrProp) && instrProp.ValueKind == JsonValueKind.String
            ? instrProp.GetString()
            : null;

        string model = data.TryGetProperty("model", out var modelProp) && modelProp.ValueKind == JsonValueKind.String
            ? modelProp.GetString()
            : null;

        double? temperature = data.TryGetProperty("temperature", out var tempProp) && tempProp.ValueKind == JsonValueKind.Number
            ? tempProp.GetDouble()
            : (double?)null;

        return new OptimizationConfig(
            instructions: instructions,
            model: model,
            temperature: temperature,
            skills: ParseSkills(data),
            toolDefinitions: ParseToolDefinitions(data),
            source: source,
            candidateId: candidateId);
    }

    private static List<OptimizationSkill> ParseSkills(JsonElement data)
    {
        var skills = new List<OptimizationSkill>();

        if (!data.TryGetProperty("skills", out var skillsArray) || skillsArray.ValueKind != JsonValueKind.Array)
        {
            return skills;
        }

        foreach (var item in skillsArray.EnumerateArray())
        {
            if (item.ValueKind != JsonValueKind.Object)
            {
                continue;
            }

            if (!item.TryGetProperty("name", out var skillName) || skillName.ValueKind != JsonValueKind.String)
            {
                continue;
            }

            string name = skillName.GetString() ?? string.Empty;
            if (name.Length == 0)
            {
                continue;
            }

            string description = item.TryGetProperty("description", out var descProp) && descProp.ValueKind == JsonValueKind.String
                ? descProp.GetString() ?? ""
                : "";

            string body = item.TryGetProperty("body", out var bodyProp) && bodyProp.ValueKind == JsonValueKind.String
                ? bodyProp.GetString() ?? ""
                : "";

            skills.Add(new OptimizationSkill(name, description, body));
        }

        return skills;
    }

    private static List<ToolDefinition> ParseToolDefinitions(JsonElement data)
    {
        var tools = new List<ToolDefinition>();

        if (!data.TryGetProperty("tools", out var toolsArray))
        {
            return tools;
        }

        if (toolsArray.ValueKind != JsonValueKind.Array)
        {
            throw new InvalidOperationException($"Expected 'tools' to be an array, got {toolsArray.ValueKind}");
        }

        foreach (var item in toolsArray.EnumerateArray())
        {
            if (item.ValueKind != JsonValueKind.Object)
            {
                continue;
            }

            string type = item.TryGetProperty("type", out var typeProp) && typeProp.ValueKind == JsonValueKind.String
                ? typeProp.GetString() ?? "function"
                : "function";

            if (item.TryGetProperty("function", out var func) && func.ValueKind == JsonValueKind.Object)
            {
                string name = func.TryGetProperty("name", out var nameProp) && nameProp.ValueKind == JsonValueKind.String
                    ? nameProp.GetString() ?? string.Empty
                    : string.Empty;

                if (name.Length == 0)
                {
                    continue;
                }

                string description = func.TryGetProperty("description", out var descProp) && descProp.ValueKind == JsonValueKind.String
                    ? descProp.GetString() ?? ""
                    : "";

                tools.Add(new ToolDefinition(type, name, description));
            }
        }

        return tools;
    }

    /// <summary>Optimized system prompt text.</summary>
    public string Instructions { get; }

    /// <summary>Model deployment name (e.g. "gpt-4o").</summary>
    public string Model { get; }

    /// <summary>Sampling temperature.</summary>
    public double? Temperature { get; }

    /// <summary>Learned skills from optimization.</summary>
    public IReadOnlyList<OptimizationSkill> Skills { get; }

    /// <summary>Path to a directory containing skill files for on-demand loading via <see cref="OptimizationConfigLoader.LoadSkillsFromDirectory"/>.</summary>
    public string SkillsDirectory { get; }

    /// <summary>Optimized tool definitions.</summary>
    public IReadOnlyList<ToolDefinition> ToolDefinitions { get; }

    /// <summary>Where the config was loaded from (e.g. "env:OPTIMIZATION_CONFIG" or "api:candidate:abc").</summary>
    public string Source { get; }

    /// <summary>The candidate identifier, if resolved from the API.</summary>
    public string CandidateId { get; }

    /// <summary>
    /// Gets a value indicating whether this config carries any inline skill data.
    /// </summary>
    public bool HasSkills => Skills.Count > 0 || SkillsDirectory != null;

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
