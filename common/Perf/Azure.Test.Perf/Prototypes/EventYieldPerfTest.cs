// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class EventYieldPerfTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        private int _eventsQueued;

        public EventYieldPerfTest(TOptions options) : base(options)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    Console.WriteLine($"_eventsQueued: {_eventsQueued}");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });
        }

        protected void EventRaisedAsync()
        {
            Interlocked.Increment(ref _eventsQueued);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException("EventYieldPerfTest only supports async");
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                if (Interlocked.Decrement(ref _eventsQueued) >= 0)
                {
                    return;
                }
                else
                {
                    Interlocked.Increment(ref _eventsQueued);
                    await Task.Yield();
                }
            }
        }
    }
}
