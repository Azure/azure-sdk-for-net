// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Invocations.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
public class InvocationsExceptionFilterTests
{
    [Test]
    public void RecordException_SetsErrorStatus()
    {
        using var source = new ActivitySource("test.exception-filter");
        using var listener = new ActivityListener
        {
            ShouldListenTo = s => s.Name == "test.exception-filter",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        using var activity = source.StartActivity("test-op");
        Assert.That(activity, Is.Not.Null);

        var exception = new InvalidOperationException("something broke");
        InvocationsExceptionFilter.RecordException(activity!, exception);

        Assert.That(activity!.Status, Is.EqualTo(ActivityStatusCode.Error));
        Assert.That(activity.StatusDescription, Is.EqualTo("something broke"));
    }

    [Test]
    public void RecordException_SetsErrorTags()
    {
        using var source = new ActivitySource("test.exception-filter.tags");
        using var listener = new ActivityListener
        {
            ShouldListenTo = s => s.Name == "test.exception-filter.tags",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        using var activity = source.StartActivity("test-op");
        Assert.That(activity, Is.Not.Null);

        var exception = new ArgumentException("bad arg");
        InvocationsExceptionFilter.RecordException(activity!, exception);

        Assert.That(activity!.GetTagItem("azure.ai.agentserver.invocations.error.code"),
            Is.EqualTo(typeof(ArgumentException).FullName));
        Assert.That(activity.GetTagItem("azure.ai.agentserver.invocations.error.message"),
            Is.EqualTo("bad arg"));

        // OTel semantic convention attributes
        Assert.That(activity.GetTagItem("error.type"),
            Is.EqualTo(typeof(ArgumentException).FullName));
        Assert.That(activity.GetTagItem("otel.status_description"),
            Is.EqualTo("bad arg"));
    }

    [Test]
    public void RecordException_AddsExceptionEvent()
    {
        using var source = new ActivitySource("test.exception-filter.event");
        using var listener = new ActivityListener
        {
            ShouldListenTo = s => s.Name == "test.exception-filter.event",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);

        using var activity = source.StartActivity("test-op");
        Assert.That(activity, Is.Not.Null);

        var exception = new InvalidOperationException("test error");
        InvocationsExceptionFilter.RecordException(activity!, exception);

        var events = activity!.Events.ToList();
        Assert.That(events, Has.Count.EqualTo(1));
        Assert.That(events[0].Name, Is.EqualTo("exception"));

        var tags = events[0].Tags.ToDictionary(t => t.Key, t => t.Value);
        Assert.That(tags["exception.type"], Is.EqualTo(typeof(InvalidOperationException).FullName));
        Assert.That(tags["exception.message"], Is.EqualTo("test error"));
        Assert.That(tags["exception.stacktrace"], Does.Contain("InvalidOperationException"));
    }

    [Test]
    public void RecordException_WithNullActivity_DoesNotThrow()
    {
        var exception = new InvalidOperationException("should not throw");

        Assert.That(
            () => InvocationsExceptionFilter.RecordException(null, exception),
            Throws.Nothing);
    }

    [Test]
    public void RecordException_WithNullException_DoesNotThrow()
    {
        using var activity = new Activity("test").Start();

        Assert.That(
            () => InvocationsExceptionFilter.RecordException(activity, null!),
            Throws.Nothing);

        Assert.That(activity.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
    }
}
