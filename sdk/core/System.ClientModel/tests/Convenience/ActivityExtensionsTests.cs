// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

[NonParallelizable]
public class ActivityExtensionsTests
{
    private const string ScmScopeLabel = "scm.sdk.scope";
    private static readonly string ScmScopeValue = bool.TrueString;

    [Test]
    public void ActivityIsStarted()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };

        Activity? activity = activitySource.StartClientActivity(options, "Client.Method");

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.OperationName, Is.EqualTo("Client.Method"));
        Assert.That(activity.Kind, Is.EqualTo(ActivityKind.Internal)); // default
        Assert.That(activity.GetCustomProperty(ScmScopeLabel), Is.EqualTo(ScmScopeValue));
        Assert.That(Activity.Current, Is.EqualTo(activity));

        activity.Dispose();
        Assert.That(listener.Activities.Count, Is.EqualTo(1));

        listener.Activities.TryDequeue(out Activity? listenerActivity);
        Assert.That(listenerActivity, Is.Not.Null);
        Assert.That(listenerActivity, Is.EqualTo(activity));
    }

    [Test]
    public void DistributedTracingDisabled()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = false };

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method");

        Assert.That(Activity.Current, Is.Null);
        Assert.That(activity, Is.Null);
        Assert.That(listener.Activities.Count, Is.EqualTo(0));
    }

    [Test]
    public void DistributedTracingEnabledByDefault()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new();

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method");

        Assert.That(Activity.Current, Is.Not.Null);
        Assert.That(activity, Is.Not.Null);
        Assert.That(listener.Activities.Count, Is.EqualTo(1));
    }

    [Test]
    public void CanSetKind()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method", ActivityKind.Client);

        Assert.That(activity, Is.Not.Null);
        Assert.That(Activity.Current, Is.Not.Null);
        Assert.That(activity!.Kind, Is.EqualTo(ActivityKind.Client));
    }

    [Test]
    public void CanSetContext()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");

        ActivityTraceId traceId = ActivityTraceId.CreateRandom();
        ActivitySpanId spanId = ActivitySpanId.CreateRandom();
        ActivityContext context = new(traceId, spanId, ActivityTraceFlags.Recorded);
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };
        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method", ActivityKind.Internal, context);

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.ParentSpanId, Is.EqualTo(spanId));
        Assert.That(activity.ParentId, Does.Contain(traceId.ToString()));
    }

    [Test]
    public void CanSetTags()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };

        KeyValuePair<string, object?>[] tags =
        [
            new KeyValuePair<string, object?>("tag1", "value1"),
            new KeyValuePair<string, object?>("tag2", "value2"),
        ];

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method", tags: tags);

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.Tags.Count(), Is.EqualTo(2));
        Assert.That(activity.Tags.Single(t => t.Key == "tag1").Value, Is.EqualTo("value1"));
        Assert.That(activity.Tags.Single(t => t.Key == "tag2").Value, Is.EqualTo("value2"));
    }

    [Test]
    [TestCase(ActivityKind.Producer, ActivityKind.Internal)]
    [TestCase(ActivityKind.Client, ActivityKind.Producer)]
    [TestCase(ActivityKind.Producer, ActivityKind.Server)]
    public void NestedSpansAreNotSuppressedWhenNotInternalOrClient(ActivityKind parentKind, ActivityKind childKind)
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };

        using Activity? parent = activitySource.StartClientActivity(options, "Client.Method", parentKind);
        using Activity? child = activitySource.StartClientActivity(options, "Client.Method", childKind);

        Assert.That(parent, Is.Not.Null);
        Assert.That(child, Is.Not.Null);
    }

    [Test]
    [TestCase(ActivityKind.Client, ActivityKind.Client)]
    [TestCase(ActivityKind.Internal, ActivityKind.Internal)]
    [TestCase(ActivityKind.Internal, ActivityKind.Client)]
    [TestCase(ActivityKind.Client, ActivityKind.Internal)]
    public void NestedSpansAreSuppressed(ActivityKind parentKind, ActivityKind childKind)
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };

        using Activity? parent = activitySource.StartClientActivity(options, "Client.Method", parentKind);
        using Activity? child = activitySource.StartClientActivity(options, "Client.Method", childKind);

        Assert.That(parent, Is.Not.Null);
        Assert.That(parent!.GetCustomProperty(ScmScopeLabel), Is.EqualTo(ScmScopeValue));
        Assert.That(child, Is.Null);
    }

    [Test]
    public void FailureIsMarkedWithStatus()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method");

        string message = "Client failed";
        MockPipelineResponse response = new(500, "Internal Server error");
        ClientResultException exception = new(message, response);

        activity?.MarkClientActivityFailed(exception);

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.StatusDescription, Is.EqualTo(message));
        Assert.That(activity.Tags.Single(kv => kv.Key == "error.type").Value, Is.EqualTo("500"));
    }

    [Test]
    public void FailureIsMarkedWithExceptionType()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method");

        ArgumentNullException exception = new("parameter");
#if NET462
        string message = "Value cannot be null.\r\nParameter name: parameter";
#else
        string message = "Value cannot be null. (Parameter 'parameter')";
#endif

        activity?.MarkClientActivityFailed(exception);

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.StatusDescription, Is.EqualTo(message));
        Assert.That(activity.Tags.Single(kv => kv.Key == "error.type").Value, Is.EqualTo("System.ArgumentNullException"));
    }

    [Test]
    public void FailureIsMarkedWithOther()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method");

        activity?.MarkClientActivityFailed(null);

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity!.StatusDescription, Is.EqualTo(null));
        Assert.That(activity.Tags.Single(kv => kv.Key == "error.type").Value, Is.EqualTo("_OTHER"));
    }
}
