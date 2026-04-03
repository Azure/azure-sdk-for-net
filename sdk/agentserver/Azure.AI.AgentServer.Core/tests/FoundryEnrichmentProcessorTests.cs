// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class FoundryEnrichmentProcessorTests
{
    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", null);
        FoundryEnvironment.Reload();
    }

    [Test]
    public void OnStart_SetsAllTags_WhenAllEnvVarsPresent()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "my-agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "2.0");
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", "/subscriptions/sub1/resourceGroups/rg1");
        FoundryEnvironment.Reload();

        var processor = new FoundryEnrichmentProcessor();
        using var activity = new Activity("test");

        processor.OnStart(activity);

        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.EqualTo("2.0"));
        Assert.That(activity.GetTagItem("gen_ai.agent.id"), Is.EqualTo("my-agent:2.0"));
        Assert.That(activity.GetTagItem("microsoft.foundry.project.id"), Is.EqualTo("/subscriptions/sub1/resourceGroups/rg1"));
    }

    [Test]
    public void OnStart_SetsAgentId_WithNameOnly_WhenVersionMissing()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "my-agent");
        FoundryEnvironment.Reload();

        var processor = new FoundryEnrichmentProcessor();
        using var activity = new Activity("test");

        processor.OnStart(activity);

        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.Null);
        Assert.That(activity.GetTagItem("gen_ai.agent.id"), Is.EqualTo("my-agent"));
    }

    [Test]
    public void OnStart_DoesNotSetTags_WhenEnvVarsAbsent()
    {
        FoundryEnvironment.Reload();

        var processor = new FoundryEnrichmentProcessor();
        using var activity = new Activity("test");

        processor.OnStart(activity);

        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.Null);
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.Null);
        Assert.That(activity.GetTagItem("gen_ai.agent.id"), Is.Null);
        Assert.That(activity.GetTagItem("microsoft.foundry.project.id"), Is.Null);
    }

    [Test]
    public void OnStart_SetsProjectId_WhenArmIdPresent()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", "/subscriptions/sub1/projects/proj1");
        FoundryEnvironment.Reload();

        var processor = new FoundryEnrichmentProcessor();
        using var activity = new Activity("test");

        processor.OnStart(activity);

        Assert.That(activity.GetTagItem("microsoft.foundry.project.id"), Is.EqualTo("/subscriptions/sub1/projects/proj1"));
    }
}
