// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class DelayTest : PerfTest<DelayTest.DelayOptions>
    {
        private static int _instanceCount = 0;
        private TimeSpan _delay;

        public DelayTest(DelayTest.DelayOptions options) : base(options)
        {
            var instanceCount = Interlocked.Increment(ref _instanceCount) - 1;

            _delay = TimeSpan.FromMilliseconds(options.InitialDelayMs * Math.Pow(options.InstanceGrowthFactor, instanceCount));
        }

        public override void Run(CancellationToken cancellationToken)
        {
            Thread.Sleep(_delay);
            _delay = TimeSpan.FromMilliseconds(_delay.TotalMilliseconds * Options.IterationGrowthFactor);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(_delay, cancellationToken);
            _delay = TimeSpan.FromMilliseconds(_delay.TotalMilliseconds * Options.IterationGrowthFactor);
        }

        public class DelayOptions : PerfOptions
        {
            [Option("initialDelayMs", Default = 1000, HelpText = "Initial delay (in milliseconds)")]
            public int InitialDelayMs { get; set; }

            // Used for verifying the perf framework correctly computes average throughput across parallel tests of different speed.
            // Each instance of this test completes operations at a different rate, to allow for testing scenarios where
            // some instances are still waiting when time expires.  The first instance completes in 1 second per operation,
            // the second instance in 2 seconds, the third instance in 4 seconds, and so on.
            [Option("instanceGrowthFactor", Default = 1, HelpText = "Instance growth factor.  The delay of instance N will be (InitialDelayMS * (InstanceGrowthFactor ^ InstanceCount)).")]
            public double InstanceGrowthFactor { get; set; }

            [Option("iterationGrowthFactor", Default = 1, HelpText = "Iteration growth factor.  The delay of iteration N will be (InitialDelayMS * (IterationGrowthFactor ^ IterationCount)).")]
            public double IterationGrowthFactor { get; set; }
        }
    }
}
