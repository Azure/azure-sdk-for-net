// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class PerfTest<TOptions> : BatchPerfTest<TOptions> where TOptions : PerfOptions
    {
        public PerfTest(TOptions options) : base(options)
        {
        }

        public sealed override int RunBatch(CancellationToken cancellationToken)
        {
            Run(cancellationToken);
            return 1;
        }

        public sealed override async Task<int> RunBatchAsync(CancellationToken cancellationToken)
        {
            await RunAsync(cancellationToken);
            return 1;
        }

        public abstract void Run(CancellationToken cancellationToken);

        public abstract Task RunAsync(CancellationToken cancellationToken);
    }
}
