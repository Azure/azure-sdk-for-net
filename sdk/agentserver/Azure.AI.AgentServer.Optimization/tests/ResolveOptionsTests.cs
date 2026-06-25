// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class ResolveOptionsTests
{
    private readonly Dictionary<string, string?> _savedEnvVars = new();

    private static readonly string[] s_envVars =
    {
        "OPTIMIZATION_CONFIG",
        "OPTIMIZATION_CANDIDATE_ID",
    };

    [SetUp]
    public void SetUp()
    {
        foreach (string envVar in s_envVars)
        {
            _savedEnvVars[envVar] = Environment.GetEnvironmentVariable(envVar);
            Environment.SetEnvironmentVariable(envVar, null);
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
    public async Task ResolveOptionsAsync_ReturnsNull_WhenCandidateIdIsNullAndNoEnvVarIsSet()
    {
        CandidateDeployConfig? options = await new TestAgentOptimizationClient().ResolveOptionsAsync(candidateId: null);

        Assert.That(options, Is.Null);
    }

    [Test]
    public async Task ResolveOptionsAsync_UsesOptimizationConfigEnvVar()
    {
        Environment.SetEnvironmentVariable(
            "OPTIMIZATION_CONFIG",
            "{\"instructions\":\"Be helpful.\",\"model\":\"gpt-4o\",\"temperature\":0.7," +
            "\"skills\":[{\"name\":\"greet\",\"description\":\"Say hi\"}]}");

        CandidateDeployConfig? options = await new TestAgentOptimizationClient().ResolveOptionsAsync(candidateId: null);

        Assert.That(options, Is.Not.Null);
        Assert.That(options!.Instructions, Is.EqualTo("Be helpful."));
        Assert.That(options.Model, Is.EqualTo("gpt-4o"));
        Assert.That(options.Temperature, Is.EqualTo(0.7f));
        Assert.That(options.Skills.Count, Is.EqualTo(1));
        Assert.That(options.Skills[0].Name, Is.EqualTo("greet"));
        Assert.That(options.Skills[0].Description, Is.EqualTo("Say hi"));
    }

    [Test]
    public void ResolveOptions_Sync_UsesOptimizationConfigEnvVar()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"model\":\"sync-model\"}");

        CandidateDeployConfig? options = new TestAgentOptimizationClient().ResolveOptions(candidateId: null);

        Assert.That(options, Is.Not.Null);
        Assert.That(options!.Model, Is.EqualTo("sync-model"));
    }

    [Test]
    public async Task ResolveOptionsAsync_WithCandidateIdAndNoEndpoint_FallsBackToEnvVar()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"fallback\"}");

        CandidateDeployConfig? options = await new TestAgentOptimizationClient().ResolveOptionsAsync("candidate-123");

        Assert.That(options, Is.Not.Null);
        Assert.That(options!.Instructions, Is.EqualTo("fallback"));
    }

    [Test]
    public void ResolveOptionsAsync_InvalidEnvVarJson_Throws()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{not-json");

        Assert.ThrowsAsync<Exception>(async () =>
            await new TestAgentOptimizationClient().ResolveOptionsAsync(candidateId: null));
    }
}
