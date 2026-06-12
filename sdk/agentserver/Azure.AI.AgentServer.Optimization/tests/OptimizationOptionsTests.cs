// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class OptimizationOptionsTests
{
    [Test]
    public void DefaultOptions_HaveSensibleDefaults()
    {
        var opts = new OptimizationOptions();

        Assert.That(opts.Instructions, Is.Null);
        Assert.That(opts.Model, Is.Null);
        Assert.That(opts.Temperature, Is.Null);
        Assert.That(opts.SkillsDirectory, Is.Null);
        Assert.That(opts.Source, Is.Null);
        Assert.That(opts.CandidateId, Is.Null);
        Assert.That(opts.Skills, Is.Not.Null);
        Assert.That(opts.Skills, Is.Empty);
        Assert.That(opts.ToolDefinitions, Is.Not.Null);
        Assert.That(opts.ToolDefinitions, Is.Empty);
        Assert.That(opts.HasSkills, Is.False);
    }

    [Test]
    public void SettableProperties_AllowsBinderShapedAssignment()
    {
        var opts = new OptimizationOptions
        {
            Instructions = "Be helpful.",
            Model = "gpt-4o",
            Temperature = 0.7,
            SkillsDirectory = "/skills",
            Source = "env:OPTIMIZATION_CONFIG",
            CandidateId = "candidate-1",
            Skills = { new OptimizationSkill("s1", "d1") },
            ToolDefinitions = { new ToolDefinition("function", "test_tool", "A test tool") },
        };

        Assert.That(opts.Instructions, Is.EqualTo("Be helpful."));
        Assert.That(opts.Model, Is.EqualTo("gpt-4o"));
        Assert.That(opts.Temperature, Is.EqualTo(0.7));
        Assert.That(opts.SkillsDirectory, Is.EqualTo("/skills"));
        Assert.That(opts.Source, Is.EqualTo("env:OPTIMIZATION_CONFIG"));
        Assert.That(opts.CandidateId, Is.EqualTo("candidate-1"));
        Assert.That(opts.Skills.Count, Is.EqualTo(1));
        Assert.That(opts.ToolDefinitions.Count, Is.EqualTo(1));
    }

    [Test]
    public void HasSkills_TrueWhenSkillsPresent()
    {
        var opts = new OptimizationOptions { Skills = { new OptimizationSkill("s1", "d1") } };

        Assert.That(opts.HasSkills, Is.True);
    }

    [Test]
    public void HasSkills_TrueWhenSkillsDirectorySet()
    {
        var opts = new OptimizationOptions { SkillsDirectory = "/skills" };

        Assert.That(opts.HasSkills, Is.True);
    }

    [Test]
    public void HasSkills_FalseWhenEmpty()
    {
        var opts = new OptimizationOptions();

        Assert.That(opts.HasSkills, Is.False);
    }

    [Test]
    public void ComposeInstructions_ReturnsInstructionsVerbatimWhenNoSkills()
    {
        var opts = new OptimizationOptions { Instructions = "Be helpful." };

        Assert.That(opts.ComposeInstructions(), Is.EqualTo("Be helpful."));
    }

    [Test]
    public void ComposeInstructions_AppendsSkillCatalog()
    {
        var opts = new OptimizationOptions
        {
            Instructions = "You are a travel assistant.",
            Skills =
            {
                new OptimizationSkill("budget-checker", "Checks budget limits"),
                new OptimizationSkill("date-formatter", "Formats dates"),
            },
        };

        string composed = opts.ComposeInstructions();

        Assert.That(composed, Does.Contain("You are a travel assistant."));
        Assert.That(composed, Does.Contain("## Available Skills"));
        Assert.That(composed, Does.Contain("- **budget-checker**: Checks budget limits"));
        Assert.That(composed, Does.Contain("- **date-formatter**: Formats dates"));
    }

    [Test]
    public void ComposeInstructions_NullInstructionsWithSkills_StartsWithCatalog()
    {
        var opts = new OptimizationOptions
        {
            Skills = { new OptimizationSkill("s1", "d1") },
        };

        string composed = opts.ComposeInstructions();

        Assert.That(composed, Does.StartWith("## Available Skills"));
    }

    [Test]
    public void ComposeInstructions_SkipsNullSkillEntries()
    {
        var opts = new OptimizationOptions
        {
            Instructions = "Be helpful.",
            Skills = { new OptimizationSkill("s1", "d1"), null! },
        };

        string composed = opts.ComposeInstructions();

        Assert.That(composed, Does.Contain("s1"));
    }

    [Test]
    public void ToString_ContainsSourceAndModel()
    {
        var opts = new OptimizationOptions { Model = "gpt-4o", Source = "api:candidate:test" };

        Assert.That(opts.ToString(), Does.Contain("gpt-4o"));
        Assert.That(opts.ToString(), Does.Contain("api:candidate:test"));
    }

    [Test]
    public void ToolDefinitions_LinqAccess_WorksAsExpected()
    {
        var opts = new OptimizationOptions
        {
            ToolDefinitions =
            {
                new ToolDefinition("function", "search_flights", "Search flights"),
                new ToolDefinition("function", "get_hotels", "Get hotel prices"),
            },
        };

        var found = opts.ToolDefinitions.FirstOrDefault(t => t.Name == "search_flights")?.Description;
        var missing = opts.ToolDefinitions.FirstOrDefault(t => t.Name == "nonexistent")?.Description;

        Assert.That(found, Is.EqualTo("Search flights"));
        Assert.That(missing, Is.Null);
    }

    [Test]
    public void EnvironmentVariableConstants_HaveExpectedNames()
    {
        Assert.That(OptimizationOptions.EnvironmentVariableConfig, Is.EqualTo("OPTIMIZATION_CONFIG"));
        Assert.That(OptimizationOptions.EnvironmentVariableCandidateId, Is.EqualTo("OPTIMIZATION_CANDIDATE_ID"));
        Assert.That(OptimizationOptions.EnvironmentVariableResolveEndpoint, Is.EqualTo("OPTIMIZATION_RESOLVE_ENDPOINT"));
        Assert.That(OptimizationOptions.EnvironmentVariableLocalDirectory, Is.EqualTo("OPTIMIZATION_LOCAL_DIR"));
    }
}
