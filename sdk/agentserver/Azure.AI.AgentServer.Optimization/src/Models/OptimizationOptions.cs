// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Resolved optimization options returned by <see cref="AgentOptimizationClient.ResolveOptionsAsync(LoadOptions, System.Threading.CancellationToken)"/>.
/// Contains the optimized instructions, model, temperature, skills, and tool definitions.
/// </summary>
/// <remarks>
/// <para>
/// This type is the single canonical shape for optimization data — it is both the
/// resolver's return value and the binding target for <c>Microsoft.Extensions.Configuration</c>
/// (via the <c>Azure.AI.AgentServer.Optimization.Configuration</c> package). Properties
/// have public setters and collections are mutable so the configuration binder can
/// populate them.
/// </para>
/// <para>
/// Callers who want a defensively-immutable view should copy the relevant fields into
/// their own type; the resolver does not freeze instances after handing them out.
/// </para>
/// </remarks>
public partial class OptimizationOptions
{
    /// <summary>Environment variable name for inline JSON config (Priority 2).</summary>
    public const string EnvironmentVariableConfig = "OPTIMIZATION_CONFIG";

    /// <summary>Environment variable name for the candidate ID (Priority 1).</summary>
    public const string EnvironmentVariableCandidateId = "OPTIMIZATION_CANDIDATE_ID";

    /// <summary>Environment variable name for the resolver API endpoint (Priority 1).</summary>
    public const string EnvironmentVariableResolveEndpoint = "OPTIMIZATION_RESOLVE_ENDPOINT";

    /// <summary>Environment variable name for the local baseline directory (Priority 3).</summary>
    public const string EnvironmentVariableLocalDirectory = "OPTIMIZATION_LOCAL_DIR";

    /// <summary>Optimized system prompt text. Required at runtime unless explicitly opted out.</summary>
    public string Instructions { get; set; }

    /// <summary>Model deployment name (e.g. "gpt-4o"). Optional advisory hint to the runtime.</summary>
    public string Model { get; set; }

    /// <summary>Sampling temperature; expected to be in [0, 2] when set.</summary>
    public double? Temperature { get; set; }

    /// <summary>Learned skills from optimization.</summary>
    public IList<OptimizationSkill> Skills { get; set; } = new List<OptimizationSkill>();

    /// <summary>
    /// Path to a directory containing skill files for on-demand loading via
    /// <see cref="AgentOptimizationClient.LoadSkillsFromDirectory"/>.
    /// </summary>
    public string SkillsDirectory { get; set; }

    /// <summary>Optimized tool definitions (function name + optimized description).</summary>
    public IList<ToolDefinition> ToolDefinitions { get; set; } = new List<ToolDefinition>();

    /// <summary>
    /// Where the options were loaded from (e.g. <c>env:OPTIMIZATION_CONFIG</c>,
    /// <c>api:candidate:abc</c>, <c>local:/path/cand_abc</c>, or <c>local:/path/baseline</c>).
    /// </summary>
    public string Source { get; set; }

    /// <summary>Candidate identifier, if resolved against a specific optimization candidate.</summary>
    public string CandidateId { get; set; }

    /// <summary>Gets a value indicating whether these options carry any inline skill data.</summary>
    public bool HasSkills => (Skills?.Count ?? 0) > 0 || SkillsDirectory is not null;

    /// <summary>
    /// Returns instructions with a skill catalog appended (if any skills are present).
    /// </summary>
    public string ComposeInstructions()
    {
        string baseInstructions = Instructions ?? string.Empty;

        if (Skills is null || Skills.Count == 0)
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
            if (skill is null)
            {
                continue;
            }
            sb.AppendLine($"- **{skill.Name}**: {skill.Description}");
        }
        return sb.ToString().TrimEnd();
    }

    /// <summary>
    /// Creates an <see cref="OptimizationOptions"/> from a JSON element (API response
    /// or env-var payload). Recognises the keys <c>instructions</c>, <c>model</c>,
    /// <c>temperature</c>, <c>skills</c>, and <c>tools</c>.
    /// </summary>
    /// <param name="data">The root JSON element to parse.</param>
    /// <param name="source">Source label (e.g. <c>env:OPTIMIZATION_CONFIG</c>). Defaults to <c>defaults</c>.</param>
    /// <param name="candidateId">Optional candidate id associated with this payload.</param>
    internal static OptimizationOptions FromJson(JsonElement data, string source = "defaults", string candidateId = null)
    {
        var opts = new OptimizationOptions
        {
            Instructions = data.TryGetProperty("instructions", out var instrProp) && instrProp.ValueKind == JsonValueKind.String
                ? instrProp.GetString()
                : null,
            Model = data.TryGetProperty("model", out var modelProp) && modelProp.ValueKind == JsonValueKind.String
                ? modelProp.GetString()
                : null,
            Temperature = data.TryGetProperty("temperature", out var tempProp) && tempProp.ValueKind == JsonValueKind.Number
                ? tempProp.GetDouble()
                : (double?)null,
            Source = source,
            CandidateId = candidateId,
        };

        ParseSkills(data, opts.Skills);
        ParseToolDefinitions(data, opts.ToolDefinitions);
        return opts;
    }

    private static void ParseSkills(JsonElement data, IList<OptimizationSkill> skills)
    {
        if (!data.TryGetProperty("skills", out var skillsArray) || skillsArray.ValueKind != JsonValueKind.Array)
        {
            return;
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
    }

    private static void ParseToolDefinitions(JsonElement data, IList<ToolDefinition> tools)
    {
        if (!data.TryGetProperty("tools", out var toolsArray))
        {
            return;
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
    }

    /// <inheritdoc/>
    public override string ToString() => $"OptimizationOptions(source={Source}, model={Model}, candidate_id={CandidateId})";
}
