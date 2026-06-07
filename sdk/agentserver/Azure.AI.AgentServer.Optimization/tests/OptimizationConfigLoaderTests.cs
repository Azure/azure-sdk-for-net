// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class OptimizationConfigLoaderTests
{
    private readonly Dictionary<string, string?> _savedEnvVars = new();

    [SetUp]
    public void SetUp()
    {
        // Save and clear all optimization env vars
        string[] envVars = {
            "OPTIMIZATION_CONFIG",
            "OPTIMIZATION_CANDIDATE_ID",
            "OPTIMIZATION_RESOLVE_ENDPOINT",
            "OPTIMIZATION_LOCAL_DIR"
        };
        foreach (var v in envVars)
        {
            _savedEnvVars[v] = Environment.GetEnvironmentVariable(v);
            Environment.SetEnvironmentVariable(v, null);
        }
    }

    [TearDown]
    public void TearDown()
    {
        // Restore env vars
        foreach (var (key, value) in _savedEnvVars)
        {
            Environment.SetEnvironmentVariable(key, value);
        }
    }

    [Test]
    public async Task LoadConfigAsync_ReturnsNull_WhenNoSourceAvailable()
    {
        var result = await OptimizationConfigLoader.LoadConfigAsync(
            new ConfigLoaderOptions { ConfigDirectory = Path.Combine(Path.GetTempPath(), "nonexistent-" + Guid.NewGuid()) });

        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task LoadConfigAsync_LoadsFromEnvVar_Priority1()
    {
        string json = "{\"instructions\":\"Be helpful.\",\"model\":\"gpt-4o\",\"temperature\":0.7}";
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", json);

        var result = await OptimizationConfigLoader.LoadConfigAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Instructions, Is.EqualTo("Be helpful."));
        Assert.That(result.Model, Is.EqualTo("gpt-4o"));
        Assert.That(result.Temperature, Is.EqualTo(0.7));
        Assert.That(result.Source, Is.EqualTo("env:OPTIMIZATION_CONFIG"));
    }

    [Test]
    public async Task LoadConfigAsync_ParsesSkillsFromEnvVar()
    {
        string json = @"{
            ""instructions"": ""test"",
            ""skills"": [{""name"": ""s1"", ""description"": ""d1"", ""body"": ""b1""}],
            ""tools"": [{""type"": ""function"", ""function"": {""name"": ""get_weather""}}]
        }";
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", json);

        var result = await OptimizationConfigLoader.LoadConfigAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Skills.Count, Is.EqualTo(1));
        Assert.That(result.Skills[0].Name, Is.EqualTo("s1"));
        Assert.That(result.Skills[0].Description, Is.EqualTo("d1"));
        Assert.That(result.Skills[0].Body, Is.EqualTo("b1"));
        Assert.That(result.ToolDefinitions.Count, Is.EqualTo(1));
    }

    [Test]
    public void LoadConfigAsync_ThrowsOnInvalidJson()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "not valid json{{{");

        Assert.ThrowsAsync<InvalidOperationException>(
            async () => await OptimizationConfigLoader.LoadConfigAsync());
    }

    [Test]
    public async Task LoadConfigAsync_EnvVarTakesPriority_OverLocalDir()
    {
        // Set up both env var AND local dir
        string tempDir = Path.Combine(Path.GetTempPath(), "opt-priority-" + Guid.NewGuid().ToString("N")[..8]);
        string baseline = Path.Combine(tempDir, "baseline");
        Directory.CreateDirectory(baseline);
        File.WriteAllText(Path.Combine(baseline, "metadata.yaml"), "model: local-model\n");

        try
        {
            string json = "{\"model\":\"env-model\"}";
            Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", json);

            var result = await OptimizationConfigLoader.LoadConfigAsync(
                new ConfigLoaderOptions { ConfigDirectory = tempDir });

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Model, Is.EqualTo("env-model"));
            Assert.That(result.Source, Does.StartWith("env:"));
        }
        finally
        {
            if (Directory.Exists(tempDir))
                Directory.Delete(tempDir, recursive: true);
        }
    }

    [Test]
    public async Task LoadConfigAsync_FallsBackToLocalDir_Priority3()
    {
        string tempDir = Path.Combine(Path.GetTempPath(), "opt-local-" + Guid.NewGuid().ToString("N")[..8]);
        string baseline = Path.Combine(tempDir, "baseline");
        Directory.CreateDirectory(baseline);
        File.WriteAllText(Path.Combine(baseline, "metadata.yaml"), "model: local-gpt\n");
        File.WriteAllText(Path.Combine(baseline, "instructions.md"), "Local instructions.");

        try
        {
            var result = await OptimizationConfigLoader.LoadConfigAsync(
                new ConfigLoaderOptions { ConfigDirectory = tempDir });

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Model, Is.EqualTo("local-gpt"));
            Assert.That(result.Instructions, Is.EqualTo("Local instructions."));
            Assert.That(result.Source, Does.StartWith("local:"));
        }
        finally
        {
            if (Directory.Exists(tempDir))
                Directory.Delete(tempDir, recursive: true);
        }
    }

    [Test]
    public void LoadConfig_Sync_Works()
    {
        string json = "{\"model\":\"sync-model\"}";
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", json);

        var result = OptimizationConfigLoader.LoadConfig();

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Model, Is.EqualTo("sync-model"));
    }

    [Test]
    public void LoadSkillsFromDirectory_DelegatesToLocalConfigReader()
    {
        string tempDir = Path.Combine(Path.GetTempPath(), "opt-skills-" + Guid.NewGuid().ToString("N")[..8]);
        string skillDir = Path.Combine(tempDir, "my-skill");
        Directory.CreateDirectory(skillDir);
        File.WriteAllText(Path.Combine(skillDir, "SKILL.md"),
            "---\nname: my-skill\ndescription: A test skill\n---\nBody.");

        try
        {
            var skills = OptimizationConfigLoader.LoadSkillsFromDirectory(tempDir);

            Assert.That(skills.Count, Is.EqualTo(1));
            Assert.That(skills[0].Name, Is.EqualTo("my-skill"));
        }
        finally
        {
            if (Directory.Exists(tempDir))
                Directory.Delete(tempDir, recursive: true);
        }
    }

    [Test]
    public async Task LoadConfigAsync_HandlesEmptyEnvVar()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "   ");

        var result = await OptimizationConfigLoader.LoadConfigAsync(
            new ConfigLoaderOptions { ConfigDirectory = Path.Combine(Path.GetTempPath(), "nonexistent-" + Guid.NewGuid()) });

        Assert.That(result, Is.Null);
    }
}
