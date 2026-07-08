// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using Azure.AI.AgentServer.Activity.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

[TestFixture]
public class ActivityExceptionFilterTests
{
    private const string TestSourceName = "test.activity.exception-filter";

    private static ActivityListener CreateListener()
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
    public void RecordException_SetsErrorStatus()
    {
        using var source = new ActivitySource(TestSourceName);
        using var listener = CreateListener();
        using var activity = source.StartActivity("op");
        Assert.That(activity, Is.Not.Null);

        ActivityExceptionFilter.RecordException(activity!, new InvalidOperationException("boom"));

        Assert.That(activity!.Status, Is.EqualTo(ActivityStatusCode.Error));
        Assert.That(activity.StatusDescription, Is.EqualTo("boom"));
    }

    [Test]
    public void RecordException_SetsErrorCodeAndMessageTags()
    {
        using var source = new ActivitySource(TestSourceName);
        using var listener = CreateListener();
        using var activity = source.StartActivity("op");

        var exception = new ArgumentException("bad arg");
        ActivityExceptionFilter.RecordException(activity!, exception);

        Assert.That(activity!.GetTagItem("azure.ai.agentserver.activity.error.code"),
            Is.EqualTo(typeof(ArgumentException).FullName));
        Assert.That(activity.GetTagItem("azure.ai.agentserver.activity.error.message"),
            Is.EqualTo("bad arg"));
    }

    [Test]
    public void RecordException_SetsOTelSemanticTags()
    {
        using var source = new ActivitySource(TestSourceName);
        using var listener = CreateListener();
        using var activity = source.StartActivity("op");

        var exception = new InvalidOperationException("kaboom");
        ActivityExceptionFilter.RecordException(activity!, exception);

        Assert.That(activity!.GetTagItem("error.type"),
            Is.EqualTo(typeof(InvalidOperationException).FullName));
        Assert.That(activity.GetTagItem("otel.status_description"), Is.EqualTo("kaboom"));
    }

    [Test]
    public void RecordException_AddsExceptionEvent_WithStackTrace()
    {
        using var source = new ActivitySource(TestSourceName);
        using var listener = CreateListener();
        using var activity = source.StartActivity("op");

        Exception exception;
        try
        {
            throw new InvalidOperationException("thrown");
        }
        catch (InvalidOperationException ex)
        {
            exception = ex;
        }

        ActivityExceptionFilter.RecordException(activity!, exception);

        var evt = activity!.Events.FirstOrDefault(e => e.Name == "exception");
        Assert.That(evt.Name, Is.EqualTo("exception"));
        var tags = evt.Tags.ToDictionary(t => t.Key, t => t.Value);
        Assert.That(tags["exception.type"], Is.EqualTo(typeof(InvalidOperationException).FullName));
        Assert.That(tags["exception.message"], Is.EqualTo("thrown"));
        Assert.That(tags["exception.stacktrace"], Is.Not.Null);
    }

    [Test]
    public void RecordException_WithNullActivity_DoesNotThrow()
    {
        Assert.That(
            () => ActivityExceptionFilter.RecordException(null, new Exception("x")),
            Throws.Nothing);
    }

    [Test]
    public void RecordException_WithNullException_DoesNotThrow()
    {
        using var source = new ActivitySource(TestSourceName);
        using var listener = CreateListener();
        using var activity = source.StartActivity("op");

        Assert.That(
            () => ActivityExceptionFilter.RecordException(activity, null!),
            Throws.Nothing);
        Assert.That(activity!.Status, Is.EqualTo(ActivityStatusCode.Unset));
    }
}
