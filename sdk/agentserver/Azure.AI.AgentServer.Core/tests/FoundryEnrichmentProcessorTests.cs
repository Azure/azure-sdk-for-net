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

    // ── Session ID / Conversation ID baggage enrichment ────────────────

    [Test]
    public void SetsSessionId_WhenBaggagePresent()
    {
        BuildProvider();

        using var parent = _activitySource.StartActivity("parent")!;
        parent.SetBaggage("azure.ai.agentserver.session_id", "sess-123");

        using var child = _activitySource.StartActivity("child")!;
        child.Stop();

        Assert.That(child.GetTagItem("microsoft.session.id"), Is.EqualTo("sess-123"));
    }

    [Test]
    public void SetsConversationId_WhenBaggagePresent()
    {
        BuildProvider();

        using var parent = _activitySource.StartActivity("parent")!;
        parent.SetBaggage("azure.ai.agentserver.conversation_id", "conv-456");

        using var child = _activitySource.StartActivity("child")!;
        child.Stop();

        Assert.That(child.GetTagItem("gen_ai.conversation.id"), Is.EqualTo("conv-456"));
    }

    [Test]
    public void SetsBothIds_WhenBothBaggagePresent()
    {
        BuildProvider();

        using var parent = _activitySource.StartActivity("parent")!;
        parent.SetBaggage("azure.ai.agentserver.session_id", "sess-A");
        parent.SetBaggage("azure.ai.agentserver.conversation_id", "conv-B");

        using var child = _activitySource.StartActivity("child")!;
        child.Stop();

        Assert.That(child.GetTagItem("microsoft.session.id"), Is.EqualTo("sess-A"));
        Assert.That(child.GetTagItem("gen_ai.conversation.id"), Is.EqualTo("conv-B"));
    }

    [Test]
    public void DoesNotSetSessionId_WhenBaggageAbsent()
    {
        BuildProvider();

        using var activity = _activitySource.StartActivity("test")!;
        activity.Stop();

        Assert.That(activity.GetTagItem("microsoft.session.id"), Is.Null);
    }

    [Test]
    public void DoesNotSetConversationId_WhenBaggageAbsent()
    {
        BuildProvider();

        using var activity = _activitySource.StartActivity("test")!;
        activity.Stop();

        Assert.That(activity.GetTagItem("gen_ai.conversation.id"), Is.Null);
    }

    [Test]
    public void SessionId_DoesNotGoToConversationId()
    {
        BuildProvider();

        using var parent = _activitySource.StartActivity("parent")!;
        parent.SetBaggage("azure.ai.agentserver.session_id", "sess-only");

        using var child = _activitySource.StartActivity("child")!;
        child.Stop();

        Assert.That(child.GetTagItem("microsoft.session.id"), Is.EqualTo("sess-only"));
        Assert.That(child.GetTagItem("gen_ai.conversation.id"), Is.Null);
    }

    [Test]
    public void ConversationId_DoesNotGoToSessionId()
    {
        BuildProvider();

        using var parent = _activitySource.StartActivity("parent")!;
        parent.SetBaggage("azure.ai.agentserver.conversation_id", "conv-only");

        using var child = _activitySource.StartActivity("child")!;
        child.Stop();

        Assert.That(child.GetTagItem("gen_ai.conversation.id"), Is.EqualTo("conv-only"));
        Assert.That(child.GetTagItem("microsoft.session.id"), Is.Null);
    }

    [Test]
    public void SessionIdAndConversationId_AreIndependent()
    {
        BuildProvider();

        using var parent = _activitySource.StartActivity("parent")!;
        parent.SetBaggage("azure.ai.agentserver.session_id", "sess-X");
        // No conversation_id baggage

        using var child = _activitySource.StartActivity("child")!;
        child.Stop();

        Assert.That(child.GetTagItem("microsoft.session.id"), Is.EqualTo("sess-X"));
        Assert.That(child.GetTagItem("gen_ai.conversation.id"), Is.Null);
    }

    [Test]
    public void DoesNotSetSessionId_WhenBaggageIsEmpty()
    {
        BuildProvider();

        using var parent = _activitySource.StartActivity("parent")!;
        parent.SetBaggage("azure.ai.agentserver.session_id", string.Empty);

        using var child = _activitySource.StartActivity("child")!;
        child.Stop();

        Assert.That(child.GetTagItem("microsoft.session.id"), Is.Null);
    }

    [Test]
    public void DoesNotSetConversationId_WhenBaggageIsEmpty()
    {
        BuildProvider();

        using var parent = _activitySource.StartActivity("parent")!;
        parent.SetBaggage("azure.ai.agentserver.conversation_id", string.Empty);

        using var child = _activitySource.StartActivity("child")!;
        child.Stop();

        Assert.That(child.GetTagItem("gen_ai.conversation.id"), Is.Null);
    }

    [Test]
    public void DoesNotSetSessionId_WhenBaggageIsWhitespace()
    {
        BuildProvider();

        using var parent = _activitySource.StartActivity("parent")!;
        parent.SetBaggage("azure.ai.agentserver.session_id", "   ");

        using var child = _activitySource.StartActivity("child")!;
        child.Stop();

        Assert.That(child.GetTagItem("microsoft.session.id"), Is.Null);
    }

    private static void SetEnv(string? agentName = null, string? agentVersion = null, string? projectArmId = null)
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", agentName);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", agentVersion);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", projectArmId);
        FoundryEnvironment.Reload();
    }
}
