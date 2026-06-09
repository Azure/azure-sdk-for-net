// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Internal schema for metadata.yaml in the local directory layout.
/// </summary>
internal class MetadataConfig
{
    public string? Model { get; set; }
    public double? Temperature { get; set; }
    public string InstructionFile { get; set; } = "instructions.md";
    public string SkillDir { get; set; } = "skills";
    public string ToolFile { get; set; } = "tools.json";

    /// <summary>
    /// Creates a <see cref="MetadataConfig"/> from a parsed YAML dictionary, ignoring unknown keys.
    /// </summary>
    public static MetadataConfig FromDictionary(IDictionary<string, object?> data)
    {
        var config = new MetadataConfig();

        if (data.TryGetValue("model", out var model) && model is string modelStr)
        {
            config.Model = modelStr;
        }

        if (data.TryGetValue("temperature", out var temp))
        {
            config.Temperature = ParseTemperature(temp);
        }

        if (data.TryGetValue("instruction_file", out var instrFile) && instrFile is string instrStr)
        {
            config.InstructionFile = instrStr;
        }

        if (data.TryGetValue("skill_dir", out var skillDir) && skillDir is string skillStr)
        {
            config.SkillDir = skillStr;
        }

        if (data.TryGetValue("tool_file", out var toolFile) && toolFile is string toolStr)
        {
            config.ToolFile = toolStr;
        }

        return config;
    }

    private static double? ParseTemperature(object? temperature)
    {
        switch (temperature)
        {
            case double doubleValue:
                return doubleValue;
            case int intValue:
                return intValue;
            case long longValue:
                return longValue;
            case float floatValue:
                return floatValue;
            case decimal decimalValue:
                return (double)decimalValue;
            case string stringValue when double.TryParse(stringValue, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double parsed):
                return parsed;
            default:
                return null;
        }
    }
}
