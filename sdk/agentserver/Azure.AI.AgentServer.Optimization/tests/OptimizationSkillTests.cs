// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class OptimizationSkillTests
{
    [Test]
    public void Constructor_SetsProperties()
    {
        var skill = new OptimizationSkill("budget-checker", "Checks budget limits", "body text");

        Assert.That(skill.Name, Is.EqualTo("budget-checker"));
        Assert.That(skill.Description, Is.EqualTo("Checks budget limits"));
        Assert.That(skill.Body, Is.EqualTo("body text"));
    }

    [Test]
    public void Constructor_DefaultsBodyToEmpty()
    {
        var skill = new OptimizationSkill("test", "desc");

        Assert.That(skill.Body, Is.EqualTo(""));
    }

    [Test]
    public void Constructor_ThrowsOnNullName()
    {
        Assert.Throws<ArgumentNullException>(() => new OptimizationSkill(null!, "desc"));
    }

    [Test]
    public void Constructor_ThrowsOnNullDescription()
    {
        Assert.Throws<ArgumentNullException>(() => new OptimizationSkill("name", null!));
    }

    [Test]
    public void Equals_TrueForSameValues()
    {
        var a = new OptimizationSkill("s1", "d1", "b1");
        var b = new OptimizationSkill("s1", "d1", "b1");

        Assert.That(a.Equals(b), Is.True);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
    }

    [Test]
    public void Equals_FalseForDifferentValues()
    {
        var a = new OptimizationSkill("s1", "d1", "b1");
        var b = new OptimizationSkill("s2", "d1", "b1");

        Assert.That(a.Equals(b), Is.False);
    }

    [Test]
    public void Equals_FalseForNull()
    {
        var skill = new OptimizationSkill("s1", "d1");

        Assert.That(skill.Equals(null), Is.False);
    }

    [Test]
    public void ToString_ContainsNameAndDescription()
    {
        var skill = new OptimizationSkill("budget", "Checks budget");

        Assert.That(skill.ToString(), Does.Contain("budget"));
        Assert.That(skill.ToString(), Does.Contain("Checks budget"));
    }
}
