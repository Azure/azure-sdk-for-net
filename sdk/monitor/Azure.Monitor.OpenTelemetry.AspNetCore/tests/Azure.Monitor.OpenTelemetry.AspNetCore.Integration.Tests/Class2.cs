// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

#if NET7_0

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    // TODO: CONVERT CLASS1 TO WebApplicationBulider example
    // Use app.Run to build a pseudo controller.
    // this will create client & server requests
    // can use app.Run to write Logs.
    // TODO: MODEL THIS off the existing Unit Test & Demo project.

    public class Class2 : RecordedTestBase<MonitorExporterTestEnvironment>
    {
        private const string _activitySourceName = "TestActivitySource";
        private const string _meterName = "TestMeterName";
        private const string _logCategoryName = $"TestLogCategoryName";
        private const LogLevel _logLevel = LogLevel.Error;
        private const string _roleName = nameof(Class2);

        private readonly LogsQueryClient _logsQueryClient;

        private readonly ActivitySource _activitySource = new ActivitySource(_activitySourceName);
        private readonly Meter _meter = new Meter(_meterName);

        public Class2(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
            _logsQueryClient = InstrumentClient(new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()
                {
                    // Testing CI.
                    Diagnostics = { IsLoggingContentEnabled = true }
                })
            ));
        }

        [RecordedTest]
        public async Task Test()
        {
            // SETUP
            var resourceAttributes = new Dictionary<string, object>
            {
                { "service.name", _roleName },
            };

            var builder = WebApplication.CreateBuilder();
            builder.Logging.ClearProviders();
            builder.Services
                .AddOpenTelemetry()
                .ConfigureResource(x => x.AddAttributes(resourceAttributes))
                .UseAzureMonitor(options =>
                {
                    options.ConnectionString = TestEnvironment.ConnectionString;
                });

            var app = builder.Build();
            app.MapGet("/", () =>
            {
                app.Logger.LogInformation("Hello World!");

                //using var client = new HttpClient();
                //var response = client.GetAsync("https://www.bing.com/").Result;

                return $"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}";
            });

            _ = app.RunAsync("http://localhost:9999");

            // Send request
            using var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync("http://localhost:9999").ConfigureAwait(false);
            Assert.NotNull(res);

            var tracerProvider = app.Services.GetRequiredService<TracerProvider>();
            tracerProvider.ForceFlush();
            tracerProvider.Shutdown(); // shutdown to prevent subscribing to log queries.

            await VerifyTracesAsync();

            await app.DisposeAsync();
        }

        private async Task VerifyTracesAsync()
        {
            // Query
            //string query = $"AppDependencies | where Target == '{activityName}' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated";
            string query = $"union * | top 1 by TimeGenerated";
            LogsTable? table = await CheckForRecordAsync(_logsQueryClient, query);

            // Assert
            var rowCount = table?.Rows.Count;
            if (rowCount == null || rowCount == 0)
            {
                // InConclusive due to ingestion delay.
                Assert.Inconclusive("No telemetry records were found");
            }
            else
            {
                Assert.True(rowCount == 1);
            }
        }

        private async Task MetricsScenarioAsync(MeterProvider meterProvider)
        {
            // CREATE METRIC
            string counterName = "MyTestCounter";
            var counter = _meter.CreateCounter<long>(counterName);
            for (int i = 0; i < 100; i++)
            {
                counter.Add(1, new("tag1", "value1"), new("tag2", "value2"));
            }

            // EXPORT
            meterProvider.ForceFlush();
            meterProvider.Shutdown();

            // Query
            string query = $"AppMetrics | where Name == '{counterName}' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated";
            LogsTable? table = await CheckForRecordAsync(_logsQueryClient, query);

            // Assert
            var rowCount = table?.Rows.Count;
            if (rowCount == null || rowCount == 0)
            {
                // InConclusive due to ingestion delay.
                Assert.Inconclusive("No telemetry records were found");
            }
            else
            {
                Assert.True(rowCount == 1);
            }
        }

        private async Task LogsScenarioAsync(ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger(_logCategoryName);
            logger.Log(
                logLevel: _logLevel,
                eventId: 0,
                exception: null,
                message: "Hello {name}.",
                args: new object[] { "World" });

            // Query
            //string query = $"AppMetrics | where Name == '{counterName}' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated";
            string query = $"AppTraces | where Message == 'Hello World.' | top 1 by TimeGenerated";
            LogsTable? table = await CheckForRecordAsync(_logsQueryClient, query);

            // Assert
            var rowCount = table?.Rows.Count;
            if (rowCount == null || rowCount == 0)
            {
                // InConclusive due to ingestion delay.
                Assert.Inconclusive("No telemetry records were found");
            }
            else
            {
                Assert.True(rowCount == 1);
            }
        }

        private async Task<LogsTable?> CheckForRecordAsync(LogsQueryClient client, string query)
        {
            LogsTable? table = null;
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

                count = table.Rows.Count;

                if (count > 0)
                {
                    break;
                }

                maxTries--;

                await Task.Delay(TimeSpan.FromSeconds(30));
            }

            return table;
        }
    }
}
#endif
