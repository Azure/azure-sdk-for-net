// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Responses.Tests;

[TestFixture]
public class ResponsesExceptionFilterTests
{
    [Test]
    public void RecordException_SetsErrorStatus()
    {
        using var activity = new Activity("test").Start();
        var exception = new InvalidOperationException("test error");

        ResponsesExceptionFilter.RecordException(activity, exception);

        Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
        Assert.That(activity.StatusDescription, Is.EqualTo("test error"));
    }

    [Test]
    public void RecordException_SetsErrorTags()
    {
        using var activity = new Activity("test").Start();
        var exception = new InvalidOperationException("test error");

        ResponsesExceptionFilter.RecordException(activity, exception);

        var tags = activity.TagObjects.ToDictionary(t => t.Key, t => t.Value);
        Assert.That(tags["azure.ai.agentserver.responses.error.code"], Is.EqualTo(typeof(InvalidOperationException).FullName));
        Assert.That(tags["azure.ai.agentserver.responses.error.message"], Is.EqualTo("test error"));
        Assert.That(tags["error.type"], Is.EqualTo(typeof(InvalidOperationException).FullName));
        Assert.That(tags["otel.status_description"], Is.EqualTo("test error"));
    }

    [Test]
    public void RecordException_AddsExceptionEvent()
    {
        using var activity = new Activity("test").Start();
        var exception = new InvalidOperationException("test error");

        ResponsesExceptionFilter.RecordException(activity, exception);

        var events = activity.Events.ToList();
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
            () => ResponsesExceptionFilter.RecordException(null, exception),
            Throws.Nothing);
    }

    [Test]
    public void RecordException_WithNullException_DoesNotThrow()
    {
        using var activity = new Activity("test").Start();

        Assert.That(
            () => ResponsesExceptionFilter.RecordException(activity, null),
            Throws.Nothing);

        Assert.That(activity.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
    }
}
