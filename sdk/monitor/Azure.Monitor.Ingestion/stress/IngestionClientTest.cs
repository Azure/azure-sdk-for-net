// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Stress;

namespace Azure.Monitor.Ingestion.Stress
{
    public class IngestionClientTest : StressTest<IngestionClientTest.IngestionClientStressOptions, IngestionClientTest.IngestionClientStressMetrics>
    {
        public IngestionClientTest(IngestionClientStressOptions options, IngestionClientStressMetrics metrics) : base(options, metrics)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/stress/TemplateClientTest.cs to write stress tests. */

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("exec some async operation");
                throw new NotImplementedException();
            });
        }
        public class IngestionClientStressMetrics : StressMetrics
        {
        }

        public class IngestionClientStressOptions : StressOptions
        {
        }
    }
}
