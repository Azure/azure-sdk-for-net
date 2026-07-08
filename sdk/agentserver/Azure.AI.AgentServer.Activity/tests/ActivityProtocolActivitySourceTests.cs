// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

[TestFixture]
[NonParallelizable]
public class ActivityProtocolActivitySourceTests
{
    private const string TestSourceName = "test.activity.baggage";
    private const string BaggageSessionId = "azure.ai.agentserver.session_id";
    private const string BaggageConversationId = "azure.ai.agentserver.conversation_id";

    private static readonly ActivitySource s_testSource = new(TestSourceName);

    [TearDown]
    public void TearDown()
    {
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
    public void PropagateActivityBaggage_SetsSessionIdBaggage_OnCurrentActivity()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");
        Assert.That(System.Diagnostics.Activity.Current, Is.Not.Null);

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("sess-456");

        Assert.That(System.Diagnostics.Activity.Current!.GetBaggageItem(BaggageSessionId), Is.EqualTo("sess-456"));
    }

    [Test]
    public void PropagateActivityBaggage_SetsConversationIdBaggage_WhenProvided()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("sess-1", "conv-99");

        Assert.Multiple(() =>
        {
            Assert.That(System.Diagnostics.Activity.Current!.GetBaggageItem(BaggageSessionId), Is.EqualTo("sess-1"));
            Assert.That(System.Diagnostics.Activity.Current!.GetBaggageItem(BaggageConversationId), Is.EqualTo("conv-99"));
        });
    }

    [Test]
    public void PropagateActivityBaggage_SkipsConversationIdBaggage_WhenNullOrEmpty()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("sess-1");

        Assert.That(System.Diagnostics.Activity.Current!.GetBaggageItem(BaggageConversationId), Is.Null);
    }

    [Test]
    public void PropagateActivityBaggage_DoesNotSetSpanTags()
    {
        // The core FoundryEnrichmentProcessor owns all gen_ai / agent / project span attributes.
        // This layer must only set baggage, never tags.
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("sess-1", "conv-1");

        var current = System.Diagnostics.Activity.Current!;
        Assert.Multiple(() =>
        {
            Assert.That(current.GetTagItem("gen_ai.agent.id"), Is.Null);
            Assert.That(current.GetTagItem("gen_ai.conversation.id"), Is.Null);
            Assert.That(current.GetTagItem("service.name"), Is.Null);
            Assert.That(current.GetTagItem("microsoft.foundry.project.id"), Is.Null);
        });
    }

    [Test]
    public void PropagateActivityBaggage_DoesNotCreateNewActivity()
    {
        using var listener = AddListener();
        using var parent = s_testSource.StartActivity("parent-request");
        var parentId = System.Diagnostics.Activity.Current!.Id;

        var source = new ActivityProtocolActivitySource();
        source.PropagateActivityBaggage("sess-1");

        Assert.That(System.Diagnostics.Activity.Current!.Id, Is.EqualTo(parentId));
    }

    [Test]
    public void PropagateActivityBaggage_NoOp_WhenNoCurrentActivity()
    {
        System.Diagnostics.Activity.Current = null;

        var source = new ActivityProtocolActivitySource();

        Assert.That(() => source.PropagateActivityBaggage("sess-1"), Throws.Nothing);
        Assert.That(System.Diagnostics.Activity.Current, Is.Null);
    }
}
