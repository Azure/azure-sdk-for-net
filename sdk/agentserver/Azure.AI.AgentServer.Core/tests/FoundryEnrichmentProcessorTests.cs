// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core.Internal;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class FoundryEnrichmentProcessorTests
{
    private string _sourceName = null!;
    private ActivitySource _activitySource = null!;
    private TracerProvider _tracerProvider = null!;

    [SetUp]
    public void SetUp()
    {
        _sourceName = $"Test.Foundry.{Guid.NewGuid():N}";
        _activitySource = new ActivitySource(_sourceName);
    }

    [TearDown]
    public void TearDown()
    {
        _tracerProvider?.Dispose();
        _activitySource?.Dispose();
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", null);
        FoundryEnvironment.Reload();
    }

    private void BuildProvider()
    {
        _tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource(_sourceName)
            .AddProcessor(new FoundryEnrichmentProcessor())
            .Build()!;
    }

    [Test]
    public void SetsAllTags_WhenAllEnvVarsPresent()
    {
        SetEnv("my-agent", "2.0", "/subscriptions/sub1/resourceGroups/rg1");
        BuildProvider();

        using var activity = _activitySource.StartActivity("test")!;
        activity.Stop();

        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.EqualTo("2.0"));
        Assert.That(activity.GetTagItem("gen_ai.agent.id"), Is.EqualTo("my-agent:2.0"));
        Assert.That(activity.GetTagItem("microsoft.foundry.project.id"), Is.EqualTo("/subscriptions/sub1/resourceGroups/rg1"));
    }

    [Test]
    public void SetsAgentId_WithNameOnly_WhenVersionMissing()
    {
        SetEnv("my-agent");
        BuildProvider();

        using var activity = _activitySource.StartActivity("test")!;
        activity.Stop();

        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.Null);
        Assert.That(activity.GetTagItem("gen_ai.agent.id"), Is.EqualTo("my-agent"));
    }

    [Test]
    public void DoesNotSetTags_WhenEnvVarsAbsent()
    {
        FoundryEnvironment.Reload();
        BuildProvider();

        using var activity = _activitySource.StartActivity("test")!;
        activity.Stop();

        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.Null);
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.Null);
        Assert.That(activity.GetTagItem("gen_ai.agent.id"), Is.Null);
        Assert.That(activity.GetTagItem("microsoft.foundry.project.id"), Is.Null);
    }

    [Test]
    public void SetsProjectId_WhenArmIdPresent()
    {
        SetEnv(projectArmId: "/subscriptions/sub1/projects/proj1");
        BuildProvider();

        using var activity = _activitySource.StartActivity("test")!;
        activity.Stop();

        Assert.That(activity.GetTagItem("microsoft.foundry.project.id"), Is.EqualTo("/subscriptions/sub1/projects/proj1"));
    }

    [Test]
    public void AgentTags_SurviveOverwrite_ByUnderlyingFramework()
    {
        SetEnv("my-agent", "2.0");
        BuildProvider();

        using var activity = _activitySource.StartActivity("test")!;

        // Simulate an underlying framework (e.g. OpenAI SDK) overwriting tags mid-span.
        activity.SetTag("gen_ai.agent.name", "framework-agent");
        activity.SetTag("gen_ai.agent.version", "9.9");
        activity.SetTag("gen_ai.agent.id", "framework-agent:9.9");

        activity.Stop();

        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.EqualTo("2.0"));
        Assert.That(activity.GetTagItem("gen_ai.agent.id"), Is.EqualTo("my-agent:2.0"));
    }

    [Test]
    public void AgentTags_SurvivePartialOverwrite()
    {
        SetEnv("my-agent", "1.0");
        BuildProvider();

        using var activity = _activitySource.StartActivity("test")!;

        // Framework only overwrites the name.
        activity.SetTag("gen_ai.agent.name", "other-agent");

        activity.Stop();

        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.EqualTo("1.0"));
        Assert.That(activity.GetTagItem("gen_ai.agent.id"), Is.EqualTo("my-agent:1.0"));
    }

    private static void SetEnv(string? agentName = null, string? agentVersion = null, string? projectArmId = null)
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", agentName);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", agentVersion);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", projectArmId);
        FoundryEnvironment.Reload();
    }
}
