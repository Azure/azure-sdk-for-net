// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Internal typed representation of the candidate config payload from the resolver API.
/// </summary>
internal class CandidateConfig
{
    public string? Name { get; init; }
    public string? Instructions { get; init; }
    public string? Model { get; init; }
    public double? Temperature { get; init; }
    public IReadOnlyList<OptimizationSkill> Skills { get; init; } = Array.Empty<OptimizationSkill>();
    public IReadOnlyList<BinaryData> ToolDefinitions { get; init; } = Array.Empty<BinaryData>();

    /// <summary>
    /// Parses a <see cref="CandidateConfig"/> from a raw API response dictionary.
    /// </summary>
    public static CandidateConfig FromDictionary(JsonElement data)
    {
        string? name = data.TryGetProperty("name", out var nameProp) && nameProp.ValueKind == JsonValueKind.String
            ? nameProp.GetString()
            : null;

        string? instructions = data.TryGetProperty("instructions", out var instrProp) && instrProp.ValueKind == JsonValueKind.String
            ? instrProp.GetString()
            : null;

        string? model = data.TryGetProperty("model", out var modelProp) && modelProp.ValueKind == JsonValueKind.String
            ? modelProp.GetString()
            : null;

        double? temperature = data.TryGetProperty("temperature", out var tempProp) && tempProp.ValueKind == JsonValueKind.Number
            ? tempProp.GetDouble()
            : null;

        var skills = ParseSkills(data);
        var toolDefinitions = ParseToolDefinitions(data);

        return new CandidateConfig
        {
            Name = name,
            Instructions = instructions,
            Model = model,
            Temperature = temperature,
            Skills = skills,
            ToolDefinitions = toolDefinitions,
        };
    }

    private static List<OptimizationSkill> ParseSkills(JsonElement data)
    {
        var skills = new List<OptimizationSkill>();

        if (!data.TryGetProperty("skills", out var skillsArray) || skillsArray.ValueKind != JsonValueKind.Array)
            return skills;

        foreach (var item in skillsArray.EnumerateArray())
        {
            if (item.ValueKind != JsonValueKind.Object)
                continue;

            if (!item.TryGetProperty("name", out var skillName) || skillName.ValueKind != JsonValueKind.String)
                continue;

            string name = skillName.GetString()!;
            if (string.IsNullOrEmpty(name))
                continue;

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

    private static List<BinaryData> ParseToolDefinitions(JsonElement data)
    {
        if (!data.TryGetProperty("tools", out var toolsArray))
            return new List<BinaryData>();

        if (toolsArray.ValueKind != JsonValueKind.Array)
            throw new InvalidOperationException($"Expected 'tools' to be an array, got {toolsArray.ValueKind}");

        var tools = new List<BinaryData>();
        foreach (var item in toolsArray.EnumerateArray())
        {
            tools.Add(BinaryData.FromString(item.GetRawText()));
        }
        return tools;
    }
}
