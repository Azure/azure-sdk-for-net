// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.Template.Perf
{
    public class TemplateClientTest : PerfTest<TemplateClientTest.TemplateClientPerfOptions>
    {
        /* please refer to PerfSampleLink to write perf test. */

        public TemplateClientTest(TemplateClientPerfOptions options) : base(options)
        {
        }
        public class TemplateClientPerfOptions : PerfOptions
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("exec some async operation");
            });
        }
    }
}
