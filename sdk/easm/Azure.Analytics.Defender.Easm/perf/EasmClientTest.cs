// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.Analytics.Defender.Easm.Perf
{
    public class EasmClientTest : PerfTest<EasmClientTest.EasmClientPerfOptions>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/perf/TemplateClientTest.cs to write perf test. */

        public EasmClientTest(EasmClientPerfOptions options) : base(options)
        {
        }
        public class EasmClientPerfOptions : PerfOptions
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
        }

        public override async System.Threading.Tasks.Task RunAsync(CancellationToken cancellationToken)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                Console.WriteLine("exec some async operation");
            });
        }
    }
}
