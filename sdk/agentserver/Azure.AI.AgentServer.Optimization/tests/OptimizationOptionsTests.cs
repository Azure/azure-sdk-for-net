// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class OptimizationOptionsTests
{
    [Test]
    public void RoundTrip_Config_To_Options_To_Config_PreservesAllFields()
    {
        var original = new OptimizationConfig(
            instructions: "Be helpful.",
            model: "gpt-4o",
            temperature: 0.7,
            skills: new[]
            {
                new OptimizationSkill("greet", "Say hello", "Hello {name}!"),
                new OptimizationSkill("farewell", "Say goodbye", "See you, {name}."),
            },
            skillsDirectory: "/skills",
            toolDefinitions: new[]
            {
                new ToolDefinition("function", "get_weather", "Look up the weather."),
            },
            source: "test:roundtrip",
            candidateId: "cand_42");

        var opts = OptimizationOptions.FromOptimizationConfig(original);
        var roundtripped = opts.ToOptimizationConfig();

        Assert.That(roundtripped.Instructions, Is.EqualTo(original.Instructions));
        Assert.That(roundtripped.Model, Is.EqualTo(original.Model));
        Assert.That(roundtripped.Temperature, Is.EqualTo(original.Temperature));
        Assert.That(roundtripped.Source, Is.EqualTo(original.Source));
        Assert.That(roundtripped.CandidateId, Is.EqualTo(original.CandidateId));
        Assert.That(roundtripped.SkillsDirectory, Is.EqualTo(original.SkillsDirectory));

        Assert.That(roundtripped.Skills.Count, Is.EqualTo(2));
        Assert.That(roundtripped.Skills[0].Name, Is.EqualTo("greet"));
        Assert.That(roundtripped.Skills[0].Description, Is.EqualTo("Say hello"));
        Assert.That(roundtripped.Skills[0].Body, Is.EqualTo("Hello {name}!"));

        Assert.That(roundtripped.ToolDefinitions.Count, Is.EqualTo(1));
        Assert.That(roundtripped.ToolDefinitions[0].Name, Is.EqualTo("get_weather"));
        Assert.That(roundtripped.ToolDefinitions[0].Description, Is.EqualTo("Look up the weather."));
    }

    [Test]
    public void ToOptimizationConfig_DefaultsSourceWhenUnset()
    {
        var opts = new OptimizationOptions { Instructions = "x" };

        var cfg = opts.ToOptimizationConfig();

        Assert.That(cfg.Source, Is.EqualTo("options"));
    }

    [Test]
    public void ToOptimizationConfig_SkipsSkillsAndToolsWithEmptyNames()
    {
        var opts = new OptimizationOptions
        {
            Instructions = "x",
            Skills =
            {
                new SkillOptions { Name = "valid", Description = "d", Body = "b" },
                new SkillOptions { Name = "", Description = "skipme", Body = "skipme" },
                null!,
            },
            ToolDefinitions =
            {
                new ToolDefinitionOptions { Name = "ok", Description = "d" },
                new ToolDefinitionOptions { Name = "", Description = "skipme" },
                null!,
            },
        };

        var cfg = opts.ToOptimizationConfig();

        Assert.That(cfg.Skills.Count, Is.EqualTo(1));
        Assert.That(cfg.Skills[0].Name, Is.EqualTo("valid"));
        Assert.That(cfg.ToolDefinitions.Count, Is.EqualTo(1));
        Assert.That(cfg.ToolDefinitions[0].Name, Is.EqualTo("ok"));
    }

    [Test]
    public void ToOptimizationConfig_DefaultsToolTypeToFunction()
    {
        var opts = new OptimizationOptions
        {
            ToolDefinitions =
            {
                new ToolDefinitionOptions { Name = "foo", Description = "bar" }, // Type unset
            },
        };

        var cfg = opts.ToOptimizationConfig();

        Assert.That(cfg.ToolDefinitions[0].Type, Is.EqualTo("function"));
    }

    [Test]
    public void ComposeInstructions_WithoutSkills_ReturnsInstructionsVerbatim()
    {
        var opts = new OptimizationOptions { Instructions = "Be helpful." };

        Assert.That(opts.ComposeInstructions(), Is.EqualTo("Be helpful."));
    }

    [Test]
    public void ComposeInstructions_WithSkills_AppendsCatalog()
    {
        var opts = new OptimizationOptions
        {
            Instructions = "Be helpful.",
            Skills =
            {
                new SkillOptions { Name = "greet", Description = "Say hello" },
                new SkillOptions { Name = "farewell", Description = "Say goodbye" },
            },
        };

        string composed = opts.ComposeInstructions();

        Assert.That(composed, Does.Contain("Be helpful."));
        Assert.That(composed, Does.Contain("## Available Skills"));
        Assert.That(composed, Does.Contain("- **greet**: Say hello"));
        Assert.That(composed, Does.Contain("- **farewell**: Say goodbye"));
    }

    [Test]
    public void ComposeInstructions_NullInstructions_StillIncludesSkills()
    {
        var opts = new OptimizationOptions
        {
            Skills = { new SkillOptions { Name = "greet", Description = "Say hello" } },
        };

        string composed = opts.ComposeInstructions();

        Assert.That(composed, Does.Contain("## Available Skills"));
        Assert.That(composed, Does.Contain("greet"));
    }

    [Test]
    public void FromOptimizationConfig_NullThrows()
    {
        Assert.Throws<ArgumentNullException>(
            () => OptimizationOptions.FromOptimizationConfig(null!));
    }

    [Test]
    public void DefaultOptions_SkillsAndToolDefinitions_AreNonNullEmpty()
    {
        var opts = new OptimizationOptions();

        Assert.That(opts.Skills, Is.Not.Null);
        Assert.That(opts.Skills, Is.Empty);
        Assert.That(opts.ToolDefinitions, Is.Not.Null);
        Assert.That(opts.ToolDefinitions, Is.Empty);
    }
}
