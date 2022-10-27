// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Monitor.Ingestion.Tests;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.Monitor.Ingestion.Perf
{
    public class SingleUploadTest : PerfTest<PerfOptions>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/perf/TemplateClientTest.cs to write perf test. */

        private static MonitorIngestionTestEnvironment TestEnvironment = new MonitorIngestionTestEnvironment();
        private readonly LogsIngestionClient LogsIngestionClient;
        private BinaryData data = BinaryData.FromObjectAsJson(
            // Use an anonymous type to create the payload
            new[] {
                    new
                    {
                        Time = DateTime.UtcNow,
                        Computer = "Computer1",
                        AdditionalContext = 2,
                    },
                    new
                    {
                        Time = DateTime.Today,
                        Computer = "Computer2",
                        AdditionalContext = 3
                    },
            });

        public SingleUploadTest(PerfOptions options) : base(options)
        {
            LogsIngestionClient = new LogsIngestionClient(new Uri(TestEnvironment.DCREndpoint), TestEnvironment.Credential, ConfigureClientOptions(new LogsIngestionClientOptions()));
        }

        public override void Run(CancellationToken cancellationToken)
        {
            LogsIngestionClient.Upload(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, data);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await LogsIngestionClient.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, data).ConfigureAwait(false);
        }
    }
}
