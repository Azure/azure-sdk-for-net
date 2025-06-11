// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace ClientModel.Tests;

public class TestClientActivityListener : IDisposable
{
    private readonly ActivityListener _listener;

    public ConcurrentQueue<Activity> Activities { get; } = new();

    public TestClientActivityListener(string name, Action<Activity>? activityStartedCallback = default)
    {
        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == name,
            ActivityStarted = activity =>
            {
                Activities.Enqueue(activity);
                activityStartedCallback?.Invoke(activity);
            },
            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
            {
                if (options.Tags?.Any(t => t.Key == "sampled-out" && bool.TrueString == t.Value?.ToString()) ?? false)
                {
                    return ActivitySamplingResult.None;
                }

                return ActivitySamplingResult.AllDataAndRecorded;
            }
        };
        ActivitySource.AddActivityListener(_listener);
    }

    public Activity? AssertAndRemoveActivity(string name)
    {
        bool gotActivity = Activities.TryDequeue(out Activity? activity);
        Assert.True(gotActivity);
        Assert.AreEqual(name, activity?.OperationName);
        return activity;
    }

    public void Dispose()
    {
        _listener.Dispose();
    }
}
