// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

[TestFixture]
[NonParallelizable]
public class ActivityProtocolActivitySourceTests
{
    private const string TestSourceName = "test.activity.baggage";
    private static readonly ActivitySource s_testSource = new(TestSourceName);

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", null);
        FoundryEnvironment.Reload();
        System.Diagnostics.Activity.Current = null;
    }

    private static ActivityListener AddListener()
    {
        var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == TestSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);
        return listener;
    }

    [Test]
    public void PropagateActivityBaggage_SetsBaggageOnCurrentActivity()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");
        Assert.That(System.Diagnostics.Activity.Current, Is.Not.Null);

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("act-123", "sess-456", null, new HeaderDictionary());

        Assert.That(System.Diagnostics.Activity.Current!.GetBaggageItem("azure.ai.agentserver.activity_id"), Is.EqualTo("act-123"));
        Assert.That(System.Diagnostics.Activity.Current!.GetBaggageItem("azure.ai.agentserver.session_id"), Is.EqualTo("sess-456"));
        Assert.That(System.Diagnostics.Activity.Current!.GetBaggageItem("azure.ai.agentserver.protocol"), Is.EqualTo("activity"));
    }

    [Test]
    public void PropagateActivityBaggage_DoesNotCreateNewActivity()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");
        var parentId = System.Diagnostics.Activity.Current!.Id;

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("act-1", "sess-1", null, new HeaderDictionary());

        Assert.That(System.Diagnostics.Activity.Current!.Id, Is.EqualTo(parentId));
    }

    [Test]
    public void PropagateActivityBaggage_SetsGenAiSemanticTags()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("act-1", "sess-1", null, new HeaderDictionary());

        var current = System.Diagnostics.Activity.Current!;
        Assert.Multiple(() =>
        {
            Assert.That(current.GetTagItem("service.name"), Is.EqualTo("azure.ai.agentserver"));
            Assert.That(current.GetTagItem("gen_ai.provider.name"), Is.EqualTo("AzureAI Hosted Agents"));
            Assert.That(current.GetTagItem("gen_ai.operation.name"), Is.EqualTo("handle_activity"));
            Assert.That(current.GetTagItem("azure.ai.agentserver.activity.protocol"), Is.EqualTo("activity"));
            Assert.That(current.GetTagItem("azure.ai.agentserver.activity.session_id"), Is.EqualTo("sess-1"));
        });
    }

    [Test]
    public void PropagateActivityBaggage_SetsAgentIdentityTag_FromNameAndVersion()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "my-agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "3");
        FoundryEnvironment.Reload();

        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("act-1", "sess-1", null, new HeaderDictionary());

        var current = System.Diagnostics.Activity.Current!;
        Assert.Multiple(() =>
        {
            Assert.That(current.GetTagItem("gen_ai.agent.id"), Is.EqualTo("my-agent:3"));
            Assert.That(current.GetTagItem("gen_ai.agent.name"), Is.EqualTo("my-agent"));
            Assert.That(current.GetTagItem("gen_ai.agent.version"), Is.EqualTo("3"));
        });
    }

    [Test]
    public void PropagateActivityBaggage_SetsConversationIdTag_WhenProvided()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("act-1", "sess-1", "conv-99", new HeaderDictionary());

        Assert.That(System.Diagnostics.Activity.Current!.GetTagItem("azure.ai.agentserver.activity.conversation_id"),
            Is.EqualTo("conv-99"));
    }

    [Test]
    public void PropagateActivityBaggage_SkipsConversationIdTag_WhenNull()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("act-1", "sess-1", null, new HeaderDictionary());

        Assert.That(System.Diagnostics.Activity.Current!.GetTagItem("azure.ai.agentserver.activity.conversation_id"),
            Is.Null);
    }

    [Test]
    public void PropagateActivityBaggage_PropagatesXRequestId()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");

        var source = new ActivityProtocolActivitySource();
        var headers = new HeaderDictionary { [PlatformHeaders.RequestId] = "req-abc-123" };
        source.PropagateActivityBaggage("act-1", "sess-1", null, headers);

        Assert.That(System.Diagnostics.Activity.Current!.GetBaggageItem(PlatformHeaders.RequestId), Is.EqualTo("req-abc-123"));
    }

    [Test]
    public void PropagateActivityBaggage_TruncatesXRequestId_At256Characters()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");

        var source = new ActivityProtocolActivitySource();
        var headers = new HeaderDictionary { [PlatformHeaders.RequestId] = new string('x', 300) };
        source.PropagateActivityBaggage("act-1", "sess-1", null, headers);

        var baggage = System.Diagnostics.Activity.Current!.GetBaggageItem(PlatformHeaders.RequestId);
        Assert.That(baggage, Is.Not.Null);
        Assert.That(baggage!.Length, Is.EqualTo(256));
    }

    [Test]
    public void PropagateActivityBaggage_NoOp_WhenNoCurrentActivity()
    {
        System.Diagnostics.Activity.Current = null;

        var source = new ActivityProtocolActivitySource();

        Assert.That(
            () => source.PropagateActivityBaggage("act-1", "sess-1", null, new HeaderDictionary()),
            Throws.Nothing);
        Assert.That(System.Diagnostics.Activity.Current, Is.Null);
    }
}
