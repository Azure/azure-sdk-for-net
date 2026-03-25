// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Hosting;
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
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());

        var headers = new HeaderDictionary();

        using var activity = source.StartInvocationActivity(context, headers);

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.OperationName, Does.Contain("invoke_agent"));
        Assert.That(activity!.OperationName, Does.Contain("test-agent:1.0.0"));
    }

    [Test]
    public void StartInvocationActivity_SetsGenAiTags()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "my-agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "2.0.0");
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
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());

        using var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.GetTagItem("gen_ai.system"), Is.EqualTo("azure.ai.agentserver"));
        Assert.That(activity!.GetTagItem("gen_ai.operation.name"), Is.EqualTo("invoke_agent"));
        Assert.That(activity!.GetTagItem("azure.ai.agentserver.invocation.id"), Is.EqualTo("inv-abc"));
        Assert.That(activity!.GetTagItem("azure.ai.agentserver.session.id"), Is.EqualTo("sess-def"));
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
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());

        using var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.GetBaggageItem("invocation_id"), Is.EqualTo("inv-1"));
        Assert.That(activity!.GetBaggageItem("session_id"), Is.EqualTo("sess-2"));
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
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());

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
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());

        var activity = source.StartInvocationActivity(context, new HeaderDictionary());

        Assert.That(activity, Is.Null);
    }
}
