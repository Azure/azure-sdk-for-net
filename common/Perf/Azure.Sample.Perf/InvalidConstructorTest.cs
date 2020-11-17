// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    // Verifies the perf framework prints a nice error for invalid constructors
    public class InvalidConstructorTest : PerfTest<PerfOptions>
    {
        public InvalidConstructorTest(PerfOptions options, string _) : base(options)
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
