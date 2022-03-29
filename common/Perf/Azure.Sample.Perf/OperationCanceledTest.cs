// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    // The perf framework should ignore OperationCanceledException thrown by Run/RunAsync(), but only
    // if the test is being cancelled.  This verifies that an OperationCanceledException thrown earlier
    // will cause the perf framework to fail fast.
    // https://github.com/Azure/azure-sdk-for-net/issues/21241

    public class OperationCanceledTest : PerfTest<PerfOptions>
    {
        public OperationCanceledTest(PerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new OperationCanceledException();
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            throw new OperationCanceledException();
        }
    }
}
