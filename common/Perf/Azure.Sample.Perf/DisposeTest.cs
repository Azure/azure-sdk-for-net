// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    // Used to verify framework calls DisposeAsync()
    public class DisposeTest : PerfTest<PerfOptions>
    {
        public DisposeTest(PerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public override void Dispose(bool disposing)
        {
            Console.WriteLine($"Dispose({disposing})");
            base.Dispose(disposing);
        }

        public override ValueTask DisposeAsyncCore()
        {
            Console.WriteLine("DisposeAsyncCore()");
            return base.DisposeAsyncCore();
        }
    }
}
