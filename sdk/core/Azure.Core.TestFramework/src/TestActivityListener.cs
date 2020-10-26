// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Core.Tests
{
    public class TestActivityListener: IDisposable
    {
        private readonly ActivityListener _listener;

        public Queue<Activity> Activities { get; } =
            new Queue<Activity>();

        public TestActivityListener(string name) : this(source => source.Name == name)
        {
        }

        public TestActivityListener(Func<ActivitySource, bool> sourceSelector)
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
                },
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllDataAndRecorded
            };

            ActivitySource.AddActivityListener(_listener);
        }

        public void Dispose()
        {
            _listener?.Dispose();
        }
    }
}