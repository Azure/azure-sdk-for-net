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
}
