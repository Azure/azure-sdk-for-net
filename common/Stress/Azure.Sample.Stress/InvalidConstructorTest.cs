// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Stress;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Stress
{
    // Verifies the perf framework prints a nice error for invalid constructors
    public class InvalidConstructorTest : StressTest<StressOptions, StressMetrics>
    {
        public InvalidConstructorTest(StressOptions options) : base(options, null)
        {
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }
    }
}
