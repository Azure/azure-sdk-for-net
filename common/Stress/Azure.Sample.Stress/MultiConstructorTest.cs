// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Stress;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Stress
{
    // Verifies the perf framework handles multiple constructors
    public class MultiConstructorTest : StressTest<StressOptions, StressMetrics>
    {
        public MultiConstructorTest() : base(null, null)
        {
        }

        public MultiConstructorTest(StressOptions options, StressMetrics metrics) : base(options, metrics)
        {
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }
    }
}
