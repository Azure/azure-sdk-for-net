// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Core.Tests
{
#if NET5_0_OR_GREATER
    public class TestActivitySourceListener: IDisposable
    {
        private readonly ActivityListener _listener;

        public Queue<Activity> Activities { get; } =
            new Queue<Activity>();

        public TestActivitySourceListener(string name) : this(source => source.Name == name)
        {
        }

        public TestActivitySourceListener(Func<ActivitySource, bool> sourceSelector)
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
#endif
}