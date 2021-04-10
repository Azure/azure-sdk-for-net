// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    // Used for measuring the overhead of the perf framework with the fastest possible test
    public class NoOpTest : PerfTest<PerfOptions>
    {
        public NoOpTest(PerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
