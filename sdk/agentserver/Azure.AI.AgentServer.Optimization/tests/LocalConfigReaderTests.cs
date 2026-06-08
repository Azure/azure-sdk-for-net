// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class LocalConfigReaderTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "opt-tests-" + Guid.NewGuid().ToString("N")[..8]);
        Directory.CreateDirectory(_tempDir);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_tempDir))
        {
            Directory.Delete(_tempDir, recursive: true);
        }
    }

    [Test]
    public void Load_ReturnsNull_WhenDirectoryDoesNotExist()
    {
        var result = LocalConfigReader.Load(null, Path.Combine(_tempDir, "nonexistent"));

        Assert.That(result, Is.Null);
    }

    [Test]
    public void Load_ReturnsNull_WhenNoBaselineOrCandidate()
    {
        var result = LocalConfigReader.Load(null, _tempDir);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void Load_LoadsFromBaseline_WhenNoCandidateId()
    {
        string baseline = Path.Combine(_tempDir, "baseline");
        Directory.CreateDirectory(baseline);
        File.WriteAllText(Path.Combine(baseline, "metadata.yaml"), "model: gpt-4o\ntemperature: 0.5\n");
        File.WriteAllText(Path.Combine(baseline, "instructions.md"), "Be helpful.");

        var result = LocalConfigReader.Load(null, _tempDir);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Model, Is.EqualTo("gpt-4o"));
        Assert.That(result.Temperature, Is.EqualTo(0.5));
        Assert.That(result.Instructions, Is.EqualTo("Be helpful."));
        Assert.That(result.Source, Does.Contain("baseline"));
    }

    [Test]
    public void Load_LoadsFromCandidateFolder_WhenCandidateIdMatches()
    {
        string candidateDir = Path.Combine(_tempDir, "candidate-123");
        Directory.CreateDirectory(candidateDir);
        File.WriteAllText(Path.Combine(candidateDir, "metadata.yaml"), "model: gpt-4o-mini\n");
        File.WriteAllText(Path.Combine(candidateDir, "instructions.md"), "Optimized prompt.");

        var result = LocalConfigReader.Load("candidate-123", _tempDir);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Model, Is.EqualTo("gpt-4o-mini"));
        Assert.That(result.Instructions, Is.EqualTo("Optimized prompt."));
        Assert.That(result.CandidateId, Is.EqualTo("candidate-123"));
    }

    [Test]
    public void Load_FallsBackToBaseline_WhenCandidateIdNotFound()
    {
        string baseline = Path.Combine(_tempDir, "baseline");
        Directory.CreateDirectory(baseline);
        File.WriteAllText(Path.Combine(baseline, "metadata.yaml"), "model: gpt-4o\n");

        var result = LocalConfigReader.Load("nonexistent-candidate", _tempDir);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Model, Is.EqualTo("gpt-4o"));
    }

    [TestCase("..\\evil")]
    [TestCase("evil\\child")]
    [TestCase("evil/child")]
    public void Load_FallsBackToBaseline_WhenCandidateIdIsInvalid(string candidateId)
    {
        string baseline = Path.Combine(_tempDir, "baseline");
        Directory.CreateDirectory(baseline);
        File.WriteAllText(Path.Combine(baseline, "metadata.yaml"), "model: gpt-4o\n");

        var result = LocalConfigReader.Load(candidateId, _tempDir);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Model, Is.EqualTo("gpt-4o"));
        Assert.That(result.CandidateId, Is.Null);
        Assert.That(result.Source, Does.Contain("baseline"));
    }

    [Test]
    public void Load_LoadsToolDefinitions()
    {
        string baseline = Path.Combine(_tempDir, "baseline");
        Directory.CreateDirectory(baseline);
        File.WriteAllText(Path.Combine(baseline, "metadata.yaml"), "");
        File.WriteAllText(Path.Combine(baseline, "tools.json"),
            "[{\"type\":\"function\",\"function\":{\"name\":\"get_weather\"}}]");

        var result = LocalConfigReader.Load(null, _tempDir);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.ToolDefinitions.Count, Is.EqualTo(1));
        Assert.That(result.ToolDefinitions[0].ToString(), Does.Contain("get_weather"));
    }

    [Test]
    public void Load_LoadsSkills_WhenSkillsFolderExists()
    {
        string baseline = Path.Combine(_tempDir, "baseline");
        string skillsDir = Path.Combine(baseline, "skills");
        string skillDir = Path.Combine(skillsDir, "budget-checker");
        Directory.CreateDirectory(skillDir);
        File.WriteAllText(Path.Combine(baseline, "metadata.yaml"), "");
        File.WriteAllText(Path.Combine(skillDir, "SKILL.md"),
            "---\nname: budget-checker\ndescription: Checks budget limits\n---\nSkill body here.");

        var result = LocalConfigReader.Load(null, _tempDir);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.SkillsDirectory, Is.Not.Null);
        Assert.That(result.Skills.Count, Is.EqualTo(1));
        Assert.That(result.Skills[0].Name, Is.EqualTo("budget-checker"));
    }

    [Test]
    public void Load_HandlesEmptyMetadataFile()
    {
        string baseline = Path.Combine(_tempDir, "baseline");
        Directory.CreateDirectory(baseline);
        File.WriteAllText(Path.Combine(baseline, "metadata.yaml"), "");

        var result = LocalConfigReader.Load(null, _tempDir);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Model, Is.Null);
        Assert.That(result.Temperature, Is.Null);
    }

    [Test]
    public void Load_HandlesNoMetadataFile()
    {
        string baseline = Path.Combine(_tempDir, "baseline");
        Directory.CreateDirectory(baseline);
        File.WriteAllText(Path.Combine(baseline, "instructions.md"), "Just instructions.");

        var result = LocalConfigReader.Load(null, _tempDir);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Instructions, Is.EqualTo("Just instructions."));
        Assert.That(result.Model, Is.Null);
    }

    [Test]
    public void LoadSkillsFromDirectory_LoadsSkillsWithFrontmatter()
    {
        string skillsDir = Path.Combine(_tempDir, "skills");
        string skill1Dir = Path.Combine(skillsDir, "budget-checker");
        Directory.CreateDirectory(skill1Dir);
        File.WriteAllText(Path.Combine(skill1Dir, "SKILL.md"),
            "---\nname: budget-checker\ndescription: Checks budget limits\n---\nSkill body here.");

        var skills = LocalConfigReader.LoadSkillsFromDirectory(skillsDir);

        Assert.That(skills.Count, Is.EqualTo(1));
        Assert.That(skills[0].Name, Is.EqualTo("budget-checker"));
        Assert.That(skills[0].Description, Is.EqualTo("Checks budget limits"));
        Assert.That(skills[0].Body, Is.EqualTo("Skill body here."));
    }

    [Test]
    public void LoadSkillsFromDirectory_LoadsSkillsWithoutFrontmatter()
    {
        string skillsDir = Path.Combine(_tempDir, "skills");
        string skill1Dir = Path.Combine(skillsDir, "simple-skill");
        Directory.CreateDirectory(skill1Dir);
        File.WriteAllText(Path.Combine(skill1Dir, "SKILL.md"),
            "# Simple Skill Title\nBody content here.");

        var skills = LocalConfigReader.LoadSkillsFromDirectory(skillsDir);

        Assert.That(skills.Count, Is.EqualTo(1));
        Assert.That(skills[0].Name, Is.EqualTo("simple-skill"));
        Assert.That(skills[0].Description, Is.EqualTo("Simple Skill Title"));
        Assert.That(skills[0].Body, Is.EqualTo("Body content here."));
    }

    [Test]
    public void LoadSkillsFromDirectory_ReturnsEmpty_WhenDirMissing()
    {
        var skills = LocalConfigReader.LoadSkillsFromDirectory(Path.Combine(_tempDir, "nonexistent"));

        Assert.That(skills, Is.Empty);
    }

    [Test]
    public void LoadSkillsFromDirectory_SkipsFolderWithoutSkillFile()
    {
        string skillsDir = Path.Combine(_tempDir, "skills");
        Directory.CreateDirectory(Path.Combine(skillsDir, "no-skill-file"));

        var skills = LocalConfigReader.LoadSkillsFromDirectory(skillsDir);

        Assert.That(skills, Is.Empty);
    }

    [Test]
    public void ParseSkillFrontmatter_ParsesValidFrontmatter()
    {
        string content = "---\nname: test\ndescription: A test skill\n---\nBody text.";

        var (frontmatter, body) = LocalConfigReader.ParseSkillFrontmatter(content);

        Assert.That(frontmatter["name"], Is.EqualTo("test"));
        Assert.That(frontmatter["description"], Is.EqualTo("A test skill"));
        Assert.That(body, Is.EqualTo("Body text."));
    }

    [Test]
    public void ParseSkillFrontmatter_ReturnsBodyOnly_WhenNoFrontmatter()
    {
        string content = "Just plain text content.";

        var (frontmatter, body) = LocalConfigReader.ParseSkillFrontmatter(content);

        Assert.That(frontmatter, Is.Empty);
        Assert.That(body, Is.EqualTo("Just plain text content."));
    }

    [Test]
    public void ParseSkillFrontmatter_HandlesUnclosedFrontmatter()
    {
        string content = "---\nname: test\nNo closing delimiter";

        var (frontmatter, body) = LocalConfigReader.ParseSkillFrontmatter(content);

        Assert.That(frontmatter, Is.Empty);
        Assert.That(body, Is.EqualTo(content));
    }
}
