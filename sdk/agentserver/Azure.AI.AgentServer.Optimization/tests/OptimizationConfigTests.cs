// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class OptimizationConfigTests
{
    [Test]
    public void Constructor_DefaultValues()
    {
        var config = new OptimizationConfig();

        Assert.That(config.Instructions, Is.Null);
        Assert.That(config.Model, Is.Null);
        Assert.That(config.Temperature, Is.Null);
        Assert.That(config.Skills, Is.Empty);
        Assert.That(config.SkillsDirectory, Is.Null);
        Assert.That(config.ToolDefinitions, Is.Empty);
        Assert.That(config.Source, Is.EqualTo("defaults"));
        Assert.That(config.CandidateId, Is.Null);
        Assert.That(config.HasSkills, Is.False);
    }

    [Test]
    public void Constructor_SetsAllProperties()
    {
        var skills = new[] { new OptimizationSkill("s1", "d1") };
        var tools = new[] { BinaryData.FromString("{\"type\":\"function\"}") };

        var config = new OptimizationConfig(
            instructions: "You are helpful.",
            model: "gpt-4o",
            temperature: 0.7,
            skills: skills,
            skillsDirectory: "/path/to/skills",
            toolDefinitions: tools,
            source: "env:OPTIMIZATION_CONFIG",
            candidateId: "candidate-1");

        Assert.That(config.Instructions, Is.EqualTo("You are helpful."));
        Assert.That(config.Model, Is.EqualTo("gpt-4o"));
        Assert.That(config.Temperature, Is.EqualTo(0.7));
        Assert.That(config.Skills.Count, Is.EqualTo(1));
        Assert.That(config.SkillsDirectory, Is.EqualTo("/path/to/skills"));
        Assert.That(config.ToolDefinitions.Count, Is.EqualTo(1));
        Assert.That(config.Source, Is.EqualTo("env:OPTIMIZATION_CONFIG"));
        Assert.That(config.CandidateId, Is.EqualTo("candidate-1"));
    }

    [Test]
    public void HasSkills_TrueWhenSkillsPresent()
    {
        var config = new OptimizationConfig(skills: new[] { new OptimizationSkill("s1", "d1") });

        Assert.That(config.HasSkills, Is.True);
    }

    [Test]
    public void HasSkills_TrueWhenSkillsDirectorySet()
    {
        var config = new OptimizationConfig(skillsDirectory: "/some/dir");

        Assert.That(config.HasSkills, Is.True);
    }

    [Test]
    public void HasSkills_FalseWhenEmpty()
    {
        var config = new OptimizationConfig();

        Assert.That(config.HasSkills, Is.False);
    }

    [Test]
    public void ComposeInstructions_ReturnsBaseWhenNoSkills()
    {
        var config = new OptimizationConfig(instructions: "Be helpful.");

        Assert.That(config.ComposeInstructions(), Is.EqualTo("Be helpful."));
    }

    [Test]
    public void ComposeInstructions_AppendsSkillCatalog()
    {
        var skills = new[]
        {
            new OptimizationSkill("budget-checker", "Checks budget limits"),
            new OptimizationSkill("date-formatter", "Formats dates"),
        };
        var config = new OptimizationConfig(instructions: "You are a travel assistant.", skills: skills);

        string composed = config.ComposeInstructions();

        Assert.That(composed, Does.Contain("You are a travel assistant."));
        Assert.That(composed, Does.Contain("## Available Skills"));
        Assert.That(composed, Does.Contain("- **budget-checker**: Checks budget limits"));
        Assert.That(composed, Does.Contain("- **date-formatter**: Formats dates"));
    }

    [Test]
    public void ComposeInstructions_EmptyInstructionsWithSkills()
    {
        var skills = new[] { new OptimizationSkill("s1", "d1") };
        var config = new OptimizationConfig(skills: skills);

        string composed = config.ComposeInstructions();

        Assert.That(composed, Does.StartWith("## Available Skills"));
    }

    [Test]
    public void ToString_ContainsSourceAndModel()
    {
        var config = new OptimizationConfig(model: "gpt-4o", source: "local:/path");

        Assert.That(config.ToString(), Does.Contain("gpt-4o"));
        Assert.That(config.ToString(), Does.Contain("local:/path"));
    }

    [Test]
    public void GetToolDefinitionsByName_ReturnsLookup()
    {
        var tools = new[]
        {
            BinaryData.FromString("""{"type":"function","function":{"name":"search_flights","description":"Search flights"}}"""),
            BinaryData.FromString("""{"type":"function","function":{"name":"get_hotels","description":"Get hotel prices"}}"""),
        };
        var config = new OptimizationConfig(toolDefinitions: tools);

        var lookup = config.GetToolDefinitionsByName();

        Assert.That(lookup.Count, Is.EqualTo(2));
        Assert.That(lookup.ContainsKey("search_flights"), Is.True);
        Assert.That(lookup.ContainsKey("get_hotels"), Is.True);
    }

    [Test]
    public void GetToolDefinitionsByName_ReturnsEmpty_WhenNoTools()
    {
        var config = new OptimizationConfig();

        var lookup = config.GetToolDefinitionsByName();

        Assert.That(lookup, Is.Empty);
    }

    [Test]
    public void GetToolDefinitionsByName_SkipsMalformedEntries()
    {
        var tools = new[]
        {
            BinaryData.FromString("""{"type":"function","function":{"name":"valid","description":"ok"}}"""),
            BinaryData.FromString("""{"type":"function"}"""),
            BinaryData.FromString("not json at all"),
        };
        var config = new OptimizationConfig(toolDefinitions: tools);

        var lookup = config.GetToolDefinitionsByName();

        Assert.That(lookup.Count, Is.EqualTo(1));
        Assert.That(lookup.ContainsKey("valid"), Is.True);
    }

    [Test]
    public void GetToolDescription_ReturnsDescription()
    {
        var tools = new[]
        {
            BinaryData.FromString("""{"type":"function","function":{"name":"search_flights","description":"Search for flights between cities"}}"""),
        };
        var config = new OptimizationConfig(toolDefinitions: tools);

        var desc = config.GetToolDescription("search_flights");

        Assert.That(desc, Is.EqualTo("Search for flights between cities"));
    }

    [Test]
    public void GetToolDescription_ReturnsNull_WhenNotFound()
    {
        var config = new OptimizationConfig(toolDefinitions: new[]
        {
            BinaryData.FromString("""{"type":"function","function":{"name":"other","description":"x"}}"""),
        });

        Assert.That(config.GetToolDescription("nonexistent"), Is.Null);
    }

    [Test]
    public void GetToolDescription_ReturnsNull_WhenNoTools()
    {
        var config = new OptimizationConfig();

        Assert.That(config.GetToolDescription("anything"), Is.Null);
    }
}
