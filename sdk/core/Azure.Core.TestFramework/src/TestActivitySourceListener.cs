// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class TestActivitySourceListener: IDisposable
    {
        private readonly ActivityListener _listener;

        public Queue<Activity> Activities { get; } =
            new Queue<Activity>();

        public TestActivitySourceListener(string name, Action<Activity> activityStartedCallback = default) : this(source => source.Name.Equals(name), activityStartedCallback)
        {
        }

        public TestActivitySourceListener(Func<ActivitySource, bool> sourceSelector, Action<Activity> activityStartedCallback = default)
        {
            _listener = new ActivityListener
            {
                ShouldListenTo = sourceSelector,
                ActivityStarted = activity =>
                {
                    lock (Activities)
                    {
                        Activities.Enqueue(activity);
                    }
                    activityStartedCallback?.Invoke(activity);
                },
                Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
                {
                    if (options.Tags.Any(t => t.Key == "sampled-out" && bool.TrueString == t.Value.ToString()))
                    {
                        return ActivitySamplingResult.None;
                    }

                    return ActivitySamplingResult.AllDataAndRecorded;
                }
            };

            ActivitySource.AddActivityListener(_listener);
        }

        public Activity AssertAndRemoveActivity(string name)
        {
            var activity = Activities.Dequeue();
            Assert.That(activity.OperationName, Is.EqualTo(name));
            return activity;
        }

        public void Dispose()
        {
            _listener?.Dispose();
        }
    }
}
