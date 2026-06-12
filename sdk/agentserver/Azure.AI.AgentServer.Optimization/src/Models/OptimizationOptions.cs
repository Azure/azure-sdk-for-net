// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Settable mirror of <see cref="OptimizationConfig"/> intended for binding from
/// <c>Microsoft.Extensions.Configuration</c> (or for population by hand).
/// </summary>
/// <remarks>
/// <para>
/// <see cref="OptimizationConfig"/> is intentionally immutable so callers can pass
/// it through without defensive copies. The configuration binder, however, requires
/// settable properties and parameterless constructors. <see cref="OptimizationOptions"/>
/// satisfies the binder contract while still round-tripping cleanly to and from the
/// immutable type.
/// </para>
/// <para>
/// This type lives in the core package so that downstream packages
/// (<c>Azure.AI.AgentServer.Optimization.Configuration</c>,
/// <c>Azure.AI.AgentServer.Optimization.AgentFramework</c>) can share it without
/// forcing the core package to depend on <c>Microsoft.Extensions.*</c>.
/// </para>
/// </remarks>
public class OptimizationOptions
{
    /// <summary>Optimized system prompt text. Required at runtime unless explicitly opted out.</summary>
    public string Instructions { get; set; }

    /// <summary>Model deployment name (e.g. "gpt-4o"). Optional advisory hint to the runtime.</summary>
    public string Model { get; set; }

    /// <summary>Sampling temperature; must be in [0, 2] when set.</summary>
    public double? Temperature { get; set; }

    /// <summary>Learned skills from optimization.</summary>
    public IList<SkillOptions> Skills { get; set; } = new List<SkillOptions>();

    /// <summary>Path to a directory containing skill files for on-demand loading.</summary>
    public string SkillsDirectory { get; set; }

    /// <summary>Optimized tool definitions (function name + optimized description).</summary>
    public IList<ToolDefinitionOptions> ToolDefinitions { get; set; } = new List<ToolDefinitionOptions>();

    /// <summary>Where the config was loaded from (e.g. <c>env:OPTIMIZATION_CONFIG</c>, <c>api:candidate:...</c>).</summary>
    public string Source { get; set; }

    /// <summary>Candidate identifier, if resolved against a specific optimization candidate.</summary>
    public string CandidateId { get; set; }

    /// <summary>
    /// Returns instructions with a skill catalog appended (if any skills are present).
    /// Mirrors <see cref="OptimizationConfig.ComposeInstructions"/>.
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
    /// Converts these options into the immutable <see cref="OptimizationConfig"/>.
    /// </summary>
    public OptimizationConfig ToOptimizationConfig()
    {
        var skills = new List<OptimizationSkill>(Skills?.Count ?? 0);
        if (Skills is not null)
        {
            foreach (var skill in Skills)
            {
                if (skill is null || string.IsNullOrEmpty(skill.Name))
                {
                    continue;
                }
                skills.Add(new OptimizationSkill(skill.Name, skill.Description ?? string.Empty, skill.Body ?? string.Empty));
            }
        }

        var tools = new List<ToolDefinition>(ToolDefinitions?.Count ?? 0);
        if (ToolDefinitions is not null)
        {
            foreach (var tool in ToolDefinitions)
            {
                if (tool is null || string.IsNullOrEmpty(tool.Name))
                {
                    continue;
                }
                tools.Add(new ToolDefinition(tool.Type ?? "function", tool.Name, tool.Description ?? string.Empty));
            }
        }

        return new OptimizationConfig(
            instructions: Instructions,
            model: Model,
            temperature: Temperature,
            skills: skills,
            skillsDirectory: SkillsDirectory,
            toolDefinitions: tools,
            source: Source ?? "options",
            candidateId: CandidateId);
    }

    /// <summary>
    /// Creates an <see cref="OptimizationOptions"/> from an immutable <see cref="OptimizationConfig"/>.
    /// </summary>
    public static OptimizationOptions FromOptimizationConfig(OptimizationConfig config)
    {
        if (config is null)
        {
            throw new ArgumentNullException(nameof(config));
        }

        var opts = new OptimizationOptions
        {
            Instructions = config.Instructions,
            Model = config.Model,
            Temperature = config.Temperature,
            SkillsDirectory = config.SkillsDirectory,
            Source = config.Source,
            CandidateId = config.CandidateId,
        };

        foreach (var skill in config.Skills)
        {
            opts.Skills.Add(new SkillOptions
            {
                Name = skill.Name,
                Description = skill.Description,
                Body = skill.Body,
            });
        }

        foreach (var tool in config.ToolDefinitions)
        {
            opts.ToolDefinitions.Add(new ToolDefinitionOptions
            {
                Type = tool.Type,
                Name = tool.Name,
                Description = tool.Description,
            });
        }

        return opts;
    }
}

/// <summary>
/// Settable mirror of <see cref="OptimizationSkill"/> for configuration binding.
/// </summary>
public class SkillOptions
{
    /// <summary>The skill name.</summary>
    public string Name { get; set; }

    /// <summary>A short description of the skill.</summary>
    public string Description { get; set; }

    /// <summary>The skill body text.</summary>
    public string Body { get; set; }
}

/// <summary>
/// Settable mirror of <see cref="ToolDefinition"/> for configuration binding.
/// </summary>
public class ToolDefinitionOptions
{
    /// <summary>The tool type (e.g. "function").</summary>
    public string Type { get; set; }

    /// <summary>The function name.</summary>
    public string Name { get; set; }

    /// <summary>The optimized description.</summary>
    public string Description { get; set; }
}
