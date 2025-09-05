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

        Assert.NotNull(activity);
        Assert.AreEqual("Client.Method", activity!.OperationName);
        Assert.AreEqual(ActivityKind.Internal, activity.Kind); // default
        Assert.AreEqual(ScmScopeValue, activity.GetCustomProperty(ScmScopeLabel));
        Assert.AreEqual(activity, Activity.Current);

        activity.Dispose();
        Assert.AreEqual(1, listener.Activities.Count);

        listener.Activities.TryDequeue(out Activity? listenerActivity);
        Assert.NotNull(listenerActivity);
        Assert.AreEqual(activity, listenerActivity);
    }

    [Test]
    public void DistributedTracingDisabled()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = false };

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method");

        Assert.IsNull(Activity.Current);
        Assert.IsNull(activity);
        Assert.AreEqual(0, listener.Activities.Count);
    }

    [Test]
    public void DistributedTracingEnabledByDefault()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new();

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method");

        Assert.IsNotNull(Activity.Current);
        Assert.IsNotNull(activity);
        Assert.AreEqual(1, listener.Activities.Count);
    }

    [Test]
    public void CanSetKind()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method", ActivityKind.Client);

        Assert.NotNull(activity);
        Assert.NotNull(Activity.Current);
        Assert.AreEqual(ActivityKind.Client, activity!.Kind);
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

        Assert.NotNull(activity);
        Assert.AreEqual(spanId, activity!.ParentSpanId);
        StringAssert.Contains(traceId.ToString(), activity.ParentId);
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

        Assert.NotNull(activity);
        Assert.AreEqual(2, activity!.Tags.Count());
        Assert.AreEqual("value1", activity.Tags.Single(t => t.Key == "tag1").Value);
        Assert.AreEqual("value2", activity.Tags.Single(t => t.Key == "tag2").Value);
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

        Assert.NotNull(parent);
        Assert.NotNull(child);
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

        Assert.NotNull(parent);
        Assert.AreEqual(ScmScopeValue, parent!.GetCustomProperty(ScmScopeLabel));
        Assert.Null(child);
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

        Assert.NotNull(activity);
        Assert.AreEqual(message, activity!.StatusDescription);
        Assert.AreEqual("500", activity.Tags.Single(kv => kv.Key == "error.type").Value);
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

        Assert.NotNull(activity);
        Assert.AreEqual(message, activity!.StatusDescription);
        Assert.AreEqual("System.ArgumentNullException", activity.Tags.Single(kv => kv.Key == "error.type").Value);
    }

    [Test]
    public void FailureIsMarkedWithOther()
    {
        using TestClientActivityListener listener = new("SampleClients.Client");
        ActivitySource activitySource = new("SampleClients.Client");
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };

        using Activity? activity = activitySource.StartClientActivity(options, "Client.Method");

        activity?.MarkClientActivityFailed(null);

        Assert.NotNull(activity);
        Assert.AreEqual(null, activity!.StatusDescription);
        Assert.AreEqual("_OTHER", activity.Tags.Single(kv => kv.Key == "error.type").Value);
    }
}
