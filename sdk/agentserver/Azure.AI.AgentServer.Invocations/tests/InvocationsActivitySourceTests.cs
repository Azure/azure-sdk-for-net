// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
[NonParallelizable]
public class InvocationsActivitySourceTests
{
    private const string TestSourceName = "test.invocations.baggage";
    private static readonly ActivitySource s_testSource = new(TestSourceName);

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", null);
        FoundryEnvironment.Reload();
        Activity.Current = null;
    }

    [Test]
    public void PropagateInvocationBaggage_SetsBaggageOnCurrentActivity()
    {
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == TestSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        using var parent = s_testSource.StartActivity("parent-request");
        Assert.That(Activity.Current, Is.Not.Null);

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-123", "sess-456",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            PlatformContext.Empty);

        source.PropagateInvocationBaggage(context, new HeaderDictionary());

        Assert.That(Activity.Current!.GetBaggageItem("azure.ai.agentserver.invocation_id"), Is.EqualTo("inv-123"));
        Assert.That(Activity.Current!.GetBaggageItem("azure.ai.agentserver.session_id"), Is.EqualTo("sess-456"));
    }

    [Test]
    public void PropagateInvocationBaggage_DoesNotCreateNewActivity()
    {
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == TestSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        using var parent = s_testSource.StartActivity("parent-request");
        var parentId = Activity.Current!.Id;

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-1",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            PlatformContext.Empty);

        source.PropagateInvocationBaggage(context, new HeaderDictionary());

        // Activity.Current should still be the same parent — no new activity created
        Assert.That(Activity.Current!.Id, Is.EqualTo(parentId));
    }

    [Test]
    public void PropagateInvocationBaggage_PropagatesXRequestId()
    {
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == TestSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        using var parent = s_testSource.StartActivity("parent-request");

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-2",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            PlatformContext.Empty);

        var headers = new HeaderDictionary { ["x-request-id"] = "req-abc-123" };

        source.PropagateInvocationBaggage(context, headers);

        Assert.That(Activity.Current!.GetBaggageItem("x-request-id"), Is.EqualTo("req-abc-123"));
    }

    [Test]
    public void PropagateInvocationBaggage_TruncatesXRequestId_At256Characters()
    {
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == TestSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        using var parent = s_testSource.StartActivity("parent-request");

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-1",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            PlatformContext.Empty);

        var longRequestId = new string('x', 300);
        var headers = new HeaderDictionary { ["x-request-id"] = longRequestId };

        source.PropagateInvocationBaggage(context, headers);

        var baggageValue = Activity.Current!.GetBaggageItem("x-request-id");
        Assert.That(baggageValue, Is.Not.Null);
        Assert.That(baggageValue!.Length, Is.EqualTo(256));
    }

    [Test]
    public void PropagateInvocationBaggage_NoOp_WhenNoCurrentActivity()
    {
        Activity.Current = null;

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-2",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            PlatformContext.Empty);

        // Should not throw
        source.PropagateInvocationBaggage(context, new HeaderDictionary());

        Assert.That(Activity.Current, Is.Null);
    }

    [Test]
    public void PropagateInvocationBaggage_OldBareKeys_NotPresent()
    {
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == TestSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        using var parent = s_testSource.StartActivity("parent-request");

        var source = new InvocationsActivitySource();
        var context = new InvocationContext(
            "inv-1", "sess-2",
            new Dictionary<string, string>(),
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
            PlatformContext.Empty);

        source.PropagateInvocationBaggage(context, new HeaderDictionary());

        // Old bare keys must NOT be present
        Assert.That(Activity.Current!.GetBaggageItem("invocation_id"), Is.Null);
        Assert.That(Activity.Current!.GetBaggageItem("session_id"), Is.Null);
    }
}
