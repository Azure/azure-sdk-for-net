// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
public class InvocationsActivitySourceTests
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
    public void StartInvocationActivity_ReturnsActivity_WhenListenerRegistered()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "test-agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "1.0.0");
        FoundryEnvironment.Reload();

        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsActivitySource.DefaultName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-123", "sess-456",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            IsolationContext.Empty);

        var headers = new HeaderDictionary();

        using var activity = source.StartInvocationActivity(context, headers);

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.OperationName, Is.EqualTo("invoke_agent test-agent:1.0.0"));
    }

    [Test]
    public void StartInvocationActivity_SpanName_NameOnly_WhenVersionEmpty()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "my-agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        FoundryEnvironment.Reload();

        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsActivitySource.DefaultName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-1",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            IsolationContext.Empty);

        using var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.OperationName, Is.EqualTo("invoke_agent my-agent"));
    }

    [Test]
    public void StartInvocationActivity_SpanName_Bare_WhenNoAgentInfo()
    {
        // No FOUNDRY_AGENT_NAME or FOUNDRY_AGENT_VERSION set
        FoundryEnvironment.Reload();

        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsActivitySource.DefaultName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-1",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            IsolationContext.Empty);

        using var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.OperationName, Is.EqualTo("invoke_agent"));
    }

    [Test]
    public void StartInvocationActivity_SetsAllSpecTags()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "my-agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "2.0.0");
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", "/subscriptions/1234/resourceGroups/rg/providers/Microsoft.MachineLearningServices/workspaces/ws");
        FoundryEnvironment.Reload();

        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsActivitySource.DefaultName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-abc", "sess-def",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            IsolationContext.Empty);

        using var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Not.Null);

        // Identity & GenAI convention tags (§4.2)
        Assert.That(activity!.GetTagItem("service.name"), Is.EqualTo("azure.ai.agentserver"));
        Assert.That(activity.GetTagItem("gen_ai.provider.name"), Is.EqualTo("AzureAI Hosted Agents"));
        Assert.That(activity.GetTagItem("gen_ai.operation.name"), Is.EqualTo("invoke_agent"));
        Assert.That(activity.GetTagItem("gen_ai.response.id"), Is.EqualTo("inv-abc"));
        Assert.That(activity.GetTagItem("microsoft.session.id"), Is.EqualTo("sess-def"));
        Assert.That(activity.GetTagItem("gen_ai.agent.id"), Is.EqualTo("my-agent:2.0.0"));
        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.EqualTo("2.0.0"));

        // Namespaced tags (§4.2)
        Assert.That(activity.GetTagItem("azure.ai.agentserver.invocations.invocation_id"), Is.EqualTo("inv-abc"));
        Assert.That(activity.GetTagItem("azure.ai.agentserver.invocations.session_id"), Is.EqualTo("sess-def"));
        Assert.That(activity.GetTagItem("microsoft.foundry.project.id"),
            Is.EqualTo("/subscriptions/1234/resourceGroups/rg/providers/Microsoft.MachineLearningServices/workspaces/ws"));

        // gen_ai.system MUST NOT be present
        Assert.That(activity.GetTagItem("gen_ai.system"), Is.Null);
    }

    [Test]
    public void StartInvocationActivity_AgentId_NameOnly_WhenVersionMissing()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "my-agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        FoundryEnvironment.Reload();

        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsActivitySource.DefaultName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-1",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            IsolationContext.Empty);

        using var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.GetTagItem("gen_ai.agent.id"), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.Null);
    }

    [Test]
    public void StartInvocationActivity_AgentId_EmptyString_WhenNoAgentInfo()
    {
        FoundryEnvironment.Reload();

        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsActivitySource.DefaultName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-auto",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            IsolationContext.Empty);

        using var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.GetTagItem("gen_ai.agent.id"), Is.EqualTo(string.Empty));
        Assert.That(activity.GetTagItem("gen_ai.agent.name"), Is.Null);
        Assert.That(activity.GetTagItem("gen_ai.agent.version"), Is.Null);
    }

    [Test]
    public void StartInvocationActivity_SessionId_MapsToMicrosoftSessionId()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "agent");
        FoundryEnvironment.Reload();

        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsActivitySource.DefaultName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-42",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            IsolationContext.Empty);

        using var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.GetTagItem("microsoft.session.id"), Is.EqualTo("sess-42"));
        Assert.That(activity.GetTagItem("azure.ai.agentserver.invocations.session_id"), Is.EqualTo("sess-42"));

        // Session ID must NOT go to gen_ai.conversation.id
        Assert.That(activity.GetTagItem("gen_ai.conversation.id"), Is.Null);
    }

    [Test]
    public void StartInvocationActivity_SetsBaggageKeys()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "1.0");
        FoundryEnvironment.Reload();

        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsActivitySource.DefaultName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-2",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            IsolationContext.Empty);

        using var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.GetBaggageItem("azure.ai.agentserver.invocation_id"), Is.EqualTo("inv-1"));
        Assert.That(activity!.GetBaggageItem("azure.ai.agentserver.session_id"), Is.EqualTo("sess-2"));

        // Old bare keys must NOT be present
        Assert.That(activity.GetBaggageItem("invocation_id"), Is.Null);
        Assert.That(activity.GetBaggageItem("session_id"), Is.Null);
    }

    [Test]
    public void StartInvocationActivity_PropagatesXRequestId()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "agent");
        FoundryEnvironment.Reload();

        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsActivitySource.DefaultName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-2",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            IsolationContext.Empty);

        var headers = new HeaderDictionary { ["x-request-id"] = "req-abc-123" };

        using var activity = source.StartInvocationActivity(context, headers);

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.GetTagItem("azure.ai.agentserver.x-request-id"), Is.EqualTo("req-abc-123"));
        Assert.That(activity!.GetBaggageItem("x-request-id"), Is.EqualTo("req-abc-123"));
    }

    [Test]
    public void StartInvocationActivity_ReturnsNull_WhenNoListener()
    {
        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-2",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            IsolationContext.Empty);

        var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Null);
    }
}
