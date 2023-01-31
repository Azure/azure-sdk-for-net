// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

#if !NETCOREAPP3_1
namespace Azure.Monitor.OpenTelemetry.Exporter.E2E.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Azure.Core.TestFramework;
    using Azure.Monitor.OpenTelemetry.Exporter;
    using Azure.Monitor.OpenTelemetry.Exporter.E2E.Tests.TestFramework;
    using Azure.Monitor.Query;
    using Azure.Monitor.Query.Models;
    using global::OpenTelemetry;
    using global::OpenTelemetry.Resources;
    using global::OpenTelemetry.Trace;

    using NUnit.Framework;

    /// <summary>
    /// Collection of tests to evaluate the <see cref="AzureMonitorTraceExporter"/>.
    /// </summary>
    public class AzureMonitorTraceExporterLiveTests : RecordedTestBase<MonitorExporterTestEnvironment>
    {
        public AzureMonitorTraceExporterLiveTests(bool isAsync) : base(isAsync) { }

        [RecordedTest]
        public async Task VerifyTraceExporter()
        {
            // SET UP
            ActivitySource src = new ActivitySource("TestActivitySource");
            string roleName = nameof(VerifyTraceExporter);

            var resourceAttributes = new Dictionary<string, object>
            {
                { "service.name", roleName },
            };

            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes);

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetResourceBuilder(resourceBuilder)
                .AddSource("TestActivitySource")
                .AddAzureMonitorTraceExporter(o => o.ConnectionString = TestEnvironment.ConnectionString)
                .Build();

            using (var activity = src.StartActivity("Test", ActivityKind.Internal))
            {
                activity?.SetTag("foo", "bar");
            }

            // Export
            tracerProvider.ForceFlush();

            // Query
            var client = CreateClient();

            string query = $"AppDependencies | where AppRoleName == '{nameof(VerifyTraceExporter)}' | top 1 by TimeGenerated";

            LogsTable table = await CheckForRecord(client, query);

            var rowCount = table.Rows.Count();

            // Assert

            // InConclusive due to ingestion delay.
            if (rowCount == 0)
            {
                Assert.Inconclusive("No telemetry records were found");
            }
            else
            {
                Assert.True(table.Rows.Count() == 1);
            }
        }

        private async Task<LogsTable> CheckForRecord(LogsQueryClient client, string query)
        {
            LogsTable table = null;
            int count = 0;

            // Try every 30 secs for total of 5 minutes.
            int maxTries = 10;
            while (count == 0 && maxTries > 0)
            {
                Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                    TestEnvironment.WorkspaceId,
                    query,
                    new QueryTimeRange(TimeSpan.FromMinutes(30)));

                table = response.Value.Table;

                count = table.Rows.Count();

                if (count > 0)
                {
                    break;
                }

                maxTries--;

                await Task.Delay(TimeSpan.FromSeconds(30));
            }

            return table;
        }

        private LogsQueryClient CreateClient()
        {
            return InstrumentClient(new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()
                {
                    Diagnostics = { IsLoggingContentEnabled = true }
                })
            ));
        }
    }
}
#endif
