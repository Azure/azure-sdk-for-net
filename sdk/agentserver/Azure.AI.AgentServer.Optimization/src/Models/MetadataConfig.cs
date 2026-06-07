// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Internal schema for metadata.yaml in the local directory layout.
/// </summary>
internal record MetadataConfig
{
    public string? Model { get; init; }
    public double? Temperature { get; init; }
    public string InstructionFile { get; init; } = "instructions.md";
    public string SkillDir { get; init; } = "skills";
    public string ToolFile { get; init; } = "tools.json";

    /// <summary>
    /// Creates a <see cref="MetadataConfig"/> from a parsed YAML dictionary, ignoring unknown keys.
    /// </summary>
    public static MetadataConfig FromDictionary(IDictionary<string, object?> data)
    {
        var config = new MetadataConfig();

        if (data.TryGetValue("model", out var model) && model is string modelStr)
            config = config with { Model = modelStr };

        if (data.TryGetValue("temperature", out var temp))
        {
            config = config with
            {
                Temperature = temp switch
                {
                    double d => d,
                    int i => i,
                    float f => f,
                    string s when double.TryParse(s, out var parsed) => parsed,
                    _ => null,
                }
            };
        }

        if (data.TryGetValue("instruction_file", out var instrFile) && instrFile is string instrStr)
            config = config with { InstructionFile = instrStr };

        if (data.TryGetValue("skill_dir", out var skillDir) && skillDir is string skillStr)
            config = config with { SkillDir = skillStr };

        if (data.TryGetValue("tool_file", out var toolFile) && toolFile is string toolStr)
            config = config with { ToolFile = toolStr };

        return config;
    }
}
