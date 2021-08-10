// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class InterlockedIncrementTest : PerfTest<PerfOptions>
    {
        private int _counter;

        public InterlockedIncrementTest(PerfOptions options) : base(options)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    Console.WriteLine($"_counter: {_counter}");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });

            Task.Run(() =>
            {
                while (true)
                {
                    Interlocked.Increment(ref _counter);
                }
            });
        }

        public override void Run(CancellationToken cancellationToken)
        {
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                if (Interlocked.Decrement(ref _counter) >= 0)
                {
                    return;
                }
                else
                {
                    Interlocked.Increment(ref _counter);
                    await Task.Yield();
                }
            }

            //Interlocked.Decrement(ref _counter);
            //return Task.CompletedTask;
        }
    }
}
