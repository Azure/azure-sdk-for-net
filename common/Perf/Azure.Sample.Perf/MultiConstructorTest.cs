// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    // Verifies the perf framework handles multiple constructors
    public class MultiConstructorTest : PerfTest<PerfOptions>
    {
        public MultiConstructorTest() : base(null)
        {
        }

        public MultiConstructorTest(PerfOptions options) : base(options)
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
