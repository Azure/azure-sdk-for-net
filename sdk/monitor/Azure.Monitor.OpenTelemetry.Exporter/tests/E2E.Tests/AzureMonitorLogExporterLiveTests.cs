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
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    /// <summary>
    /// Collection of tests to evaluate the <see cref="AzureMonitorLogExporter"/>.
    /// </summary>
    public class AzureMonitorLogExporterLiveTests : AzureMonitorTestBase
    {
        public AzureMonitorLogExporterLiveTests(bool isAsync) : base(isAsync) { }

        [RecordedTest]
        public async Task VerifyLogExporter()
        {
            // SETUP
            var exporter = this.GetAzureMonitorLogExporter();
            var processor = new BatchLogRecordExportProcessor(exporter);

            var serviceCollection = new ServiceCollection().AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace)
                    .AddOpenTelemetry(options => options
                        .AddProcessor(processor));
            });

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<AzureMonitorLogExporterLiveTests>>();

            // ACT
            // TODO: For proper test isolation, we should include a CustomProperty on telemetry items.
            // CustomProperty should be unique per test method.
            // This would allow us to run tests in parallel.
            var testMessage = "Hello World";
            logger.Log(logLevel: LogLevel.Information, message: testMessage);

            var flushResult = processor.ForceFlush(this.FlushTimeoutMilliseconds);
            Assert.IsTrue(flushResult, "Processor failed to flush");

            // VERIFY
            // TODO: Need to verify additional fields. The LogExporter is still in development.
            var telemetry = await FetchTelemetryAsync();
            Assert.AreEqual(testMessage, telemetry[0].Trace.Message);
        }

        [RecordedTest]
        public async Task VerifyTraceExporter()
        {
            ActivitySource src = new ActivitySource("TestActivitySource");
            var roleName = nameof(VerifyTraceExporter);
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

            tracerProvider.ForceFlush();

            var client = CreateClient();

            LogsTable table = await CheckForRecord(client, roleName);

            Assert.AreEqual(1, table.Rows.Count());
        }

        private async Task<LogsTable> CheckForRecord(LogsQueryClient client, string roleName)
        {
            Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                TestEnvironment.WorkspaceId,
                $"AppDependencies | where AppRoleName == '{roleName}'",
                new QueryTimeRange(TimeSpan.FromMinutes(5)));

            LogsTable table = response.Value.Table;

            while (table.Rows.Count() == 0)
            {
                Response<LogsQueryResult> retryresponse = await client.QueryWorkspaceAsync(
                TestEnvironment.WorkspaceId,
                $"AppDependencies | where AppRoleName == '{roleName}'",
                new QueryTimeRange(TimeSpan.FromMinutes(5)));

                table = retryresponse.Value.Table;
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
