// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// Collection of tests to evaluate the <see cref="AzureMonitorLogExporter"/>.
    /// </summary>
    public class AzureMonitorTraceExporterLiveTests : RecordedTestBase<MonitorExporterTestEnvironment>
    {
        public AzureMonitorTraceExporterLiveTests(bool isAsync) : base(isAsync) { }

        [RecordedTest]
        [PlaybackOnly("Add field level validations")]
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
                .SetSampler(new AlwaysOnSampler())
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

            string query = $"AppDependencies | where AppRoleName == '{roleName}'";

            LogsTable table = await CheckForRecord(client, query);

            // Assert
            Assert.True(table.Rows.Count() > 0);
        }

        private async Task<LogsTable> CheckForRecord(LogsQueryClient client, string query)
        {
            Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                TestEnvironment.WorkspaceId,
                query,
                new QueryTimeRange(TimeSpan.FromMinutes(30)));

            LogsTable table = response.Value.Table;

            int maxTries = 6;
            while (table.Rows.Count() == 0 && maxTries > 0)
            {
                await Task.Delay(TimeSpan.FromMinutes(5));

                Response<LogsQueryResult> retryresponse = await client.QueryWorkspaceAsync(
                TestEnvironment.WorkspaceId,
                query,
                new QueryTimeRange(TimeSpan.FromMinutes(30)));

                table = retryresponse.Value.Table;

                maxTries--;
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
