// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class OptimizationSkillTests
{
    [Test]
    public void Parameterless_DefaultsAllPropertiesToNull()
    {
        var skill = new OptimizationSkill();

        Assert.That(skill.Name, Is.Null);
        Assert.That(skill.Description, Is.Null);
        Assert.That(skill.Body, Is.Null);
    }

    [Test]
    public void Ctor_SetsProperties()
    {
        var skill = new OptimizationSkill("budget-checker", "Checks budget limits", "body text");

        Assert.That(skill.Name, Is.EqualTo("budget-checker"));
        Assert.That(skill.Description, Is.EqualTo("Checks budget limits"));
        Assert.That(skill.Body, Is.EqualTo("body text"));
    }

    [Test]
    public void Ctor_DefaultsBodyToEmpty()
    {
        var skill = new OptimizationSkill("test", "desc");

        Assert.That(skill.Body, Is.EqualTo(""));
    }

    [Test]
    public void Ctor_ThrowsOnNullName()
    {
        Assert.Throws<ArgumentNullException>(() => new OptimizationSkill(null!, "desc"));
    }

    [Test]
    public void Ctor_ThrowsOnNullDescription()
    {
        Assert.Throws<ArgumentNullException>(() => new OptimizationSkill("name", null!));
    }

    [Test]
    public void Settable_PropertiesAllowMutation()
    {
        var skill = new OptimizationSkill();
        skill.Name = "x";
        skill.Description = "y";
        skill.Body = "z";

        Assert.That(skill.Name, Is.EqualTo("x"));
        Assert.That(skill.Description, Is.EqualTo("y"));
        Assert.That(skill.Body, Is.EqualTo("z"));
    }

    [Test]
    public void ToString_ContainsNameAndDescription()
    {
        var skill = new OptimizationSkill("budget", "Checks budget");

        Assert.That(skill.ToString(), Does.Contain("budget"));
        Assert.That(skill.ToString(), Does.Contain("Checks budget"));
    }
}

[TestFixture]
public class ToolDefinitionTests
{
    [Test]
    public void Parameterless_DefaultsTypeToFunctionAndDescriptionToEmpty()
    {
        var tool = new ToolDefinition();

        Assert.That(tool.Type, Is.EqualTo("function"));
        Assert.That(tool.Name, Is.Null);
        Assert.That(tool.Description, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Ctor_SetsProperties()
    {
        var tool = new ToolDefinition("function", "get_weather", "Look up weather");

        Assert.That(tool.Type, Is.EqualTo("function"));
        Assert.That(tool.Name, Is.EqualTo("get_weather"));
        Assert.That(tool.Description, Is.EqualTo("Look up weather"));
    }

    [Test]
    public void Ctor_ThrowsOnNullType()
    {
        Assert.Throws<ArgumentNullException>(() => new ToolDefinition(null!, "name", "desc"));
    }

    [Test]
    public void Ctor_ThrowsOnNullName()
    {
        Assert.Throws<ArgumentNullException>(() => new ToolDefinition("function", null!, "desc"));
    }

    [Test]
    public void Ctor_NullDescriptionBecomesEmpty()
    {
        var tool = new ToolDefinition("function", "name", null!);

        Assert.That(tool.Description, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Settable_PropertiesAllowMutation()
    {
        var tool = new ToolDefinition();
        tool.Type = "function";
        tool.Name = "n";
        tool.Description = "d";

        Assert.That(tool.Type, Is.EqualTo("function"));
        Assert.That(tool.Name, Is.EqualTo("n"));
        Assert.That(tool.Description, Is.EqualTo("d"));
    }
}
