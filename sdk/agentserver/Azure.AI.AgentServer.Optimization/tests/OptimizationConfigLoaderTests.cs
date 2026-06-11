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
        string[] envVars =
        {
            "OPTIMIZATION_CONFIG",
            "OPTIMIZATION_CANDIDATE_ID",
            "OPTIMIZATION_RESOLVE_ENDPOINT",
            "OPTIMIZATION_LOCAL_DIR",
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
        foreach (KeyValuePair<string, string?> environmentVariable in _savedEnvVars)
        {
            Environment.SetEnvironmentVariable(environmentVariable.Key, environmentVariable.Value);
        }
    }

    [Test]
    public async Task LoadConfigAsync_ReturnsNull_WhenNoSourceAvailable()
    {
        var result = await OptimizationConfigLoader.LoadConfigAsync();

        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task LoadConfigAsync_LoadsFromEnvVar_Priority2()
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
    public void LoadConfig_Sync_Works()
    {
        string json = "{\"model\":\"sync-model\"}";
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", json);

        var result = OptimizationConfigLoader.LoadConfig();

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Model, Is.EqualTo("sync-model"));
    }

    [Test]
    public async Task LoadConfigAsync_HandlesEmptyEnvVar()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "   ");

        var result = await OptimizationConfigLoader.LoadConfigAsync();

        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task LoadConfigAsync_LoadsFromLocalCandidateDirectory_Priority3()
    {
        // Simulate the layout written by `azd ai agent optimize apply --candidate`:
        //   <root>/baseline/instructions.md
        //   <root>/cand_abc123/instructions.md
        // When OPTIMIZATION_CANDIDATE_ID is set to cand_abc123, the candidate
        // folder must win over baseline.
        string root = Path.Combine(Path.GetTempPath(), $"opt-loader-tests-{Guid.NewGuid():N}");
        try
        {
            string baselineDir = Path.Combine(root, "baseline");
            string candidateDir = Path.Combine(root, "cand_abc123");
            Directory.CreateDirectory(baselineDir);
            Directory.CreateDirectory(candidateDir);
            File.WriteAllText(Path.Combine(baselineDir, "instructions.md"), "baseline instructions");
            File.WriteAllText(Path.Combine(candidateDir, "instructions.md"), "optimized instructions");

            Environment.SetEnvironmentVariable("OPTIMIZATION_LOCAL_DIR", root);
            Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "cand_abc123");

            var result = await OptimizationConfigLoader.LoadConfigAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Instructions, Is.EqualTo("optimized instructions"));
            Assert.That(result.CandidateId, Is.EqualTo("cand_abc123"));
            Assert.That(result.Source, Does.Contain("cand_abc123"));
        }
        finally
        {
            if (Directory.Exists(root)) Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task LoadConfigAsync_FallsBackToBaseline_WhenCandidateDirectoryMissing()
    {
        string root = Path.Combine(Path.GetTempPath(), $"opt-loader-tests-{Guid.NewGuid():N}");
        try
        {
            string baselineDir = Path.Combine(root, "baseline");
            Directory.CreateDirectory(baselineDir);
            File.WriteAllText(Path.Combine(baselineDir, "instructions.md"), "baseline instructions");

            Environment.SetEnvironmentVariable("OPTIMIZATION_LOCAL_DIR", root);
            Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "cand_does_not_exist");

            var result = await OptimizationConfigLoader.LoadConfigAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Instructions, Is.EqualTo("baseline instructions"));
            Assert.That(result.CandidateId, Is.Null);
            Assert.That(result.Source, Does.Contain("baseline"));
        }
        finally
        {
            if (Directory.Exists(root)) Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task LoadConfigAsync_LoadsBaseline_WhenOnlyLocalDirSet()
    {
        string root = Path.Combine(Path.GetTempPath(), $"opt-loader-tests-{Guid.NewGuid():N}");
        try
        {
            string baselineDir = Path.Combine(root, "baseline");
            Directory.CreateDirectory(baselineDir);
            File.WriteAllText(Path.Combine(baselineDir, "instructions.md"), "baseline only");

            Environment.SetEnvironmentVariable("OPTIMIZATION_LOCAL_DIR", root);

            var result = await OptimizationConfigLoader.LoadConfigAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Instructions, Is.EqualTo("baseline only"));
        }
        finally
        {
            if (Directory.Exists(root)) Directory.Delete(root, recursive: true);
        }
    }
}
