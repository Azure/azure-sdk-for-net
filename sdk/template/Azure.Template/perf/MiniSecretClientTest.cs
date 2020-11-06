// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace System.PerfStress
{
    public class MiniSecretClientTest : PerfTest<PerfOptions>
    {
        public MiniSecretClientTest(PerfOptions options) : base(options) { }

        public override void Run(CancellationToken cancellationToken)
        {
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
