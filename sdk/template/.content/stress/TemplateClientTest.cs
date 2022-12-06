// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Test.Stress;
using CommandLine;

namespace Azure.Template.Stress
{
    public class TemplateClientTest : StressTest<TemplateClientTest.TemplateClientStressOptions, TemplateClientTest.TemplateClientStressMetrics>
    {
        public TemplateClientTest(TemplateClientStressOptions options, TemplateClientStressMetrics metrics) : base(options, metrics)
        {
        }

        /* please refer to StressSampleLink to write stress tests. */

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("exec some async operation");
            });
        }
        public class TemplateClientStressMetrics : StressMetrics
        {
        }

        public class TemplateClientStressOptions : StressOptions
        {
        }
    }
}
