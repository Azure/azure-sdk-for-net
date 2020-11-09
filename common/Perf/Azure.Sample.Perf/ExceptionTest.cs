// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    // Measures the overhead of creating, throwing, and catching an exception (compared to NoOpTest)
    public class ExceptionTest : PerfTest<PerfOptions>
    {
        public ExceptionTest(PerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            try
            {
                throw new InvalidOperationException();
            }
            catch
            {
            }
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
                throw new InvalidOperationException();
            }
            catch
            {
            }

            return Task.CompletedTask;
        }
    }
}
