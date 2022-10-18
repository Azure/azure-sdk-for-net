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
    public class IngestionClientTest : PerfTest<IngestionClientTest.IngestionClientPerfOptions>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/perf/TemplateClientTest.cs to write perf test. */

        protected static MonitorIngestionTestEnvironment TestEnvironment = new MonitorIngestionTestEnvironment();
        protected readonly LogsIngestionClient LogsIngestionClient;
        protected static List<Object> GenerateEntries(int numEntries)
        {
            var entries = new List<Object>();
            for (int i = 0; i < numEntries; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = DateTime.UtcNow,
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }
            return entries;
        }

        public IngestionClientTest(IngestionClientPerfOptions options) : base(options)
        {
            LogsIngestionClient = new LogsIngestionClient(new Uri(TestEnvironment.DCREndpoint), TestEnvironment.Credential, ConfigureClientOptions(new LogsIngestionClientOptions()));
        }
        public class IngestionClientPerfOptions : PerfOptions
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            LogsIngestionClient.Upload(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, GenerateEntries(100), null, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                await LogsIngestionClient.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, GenerateEntries(100), null, cancellationToken).ConfigureAwait(false);
            });
        }
    }
}
