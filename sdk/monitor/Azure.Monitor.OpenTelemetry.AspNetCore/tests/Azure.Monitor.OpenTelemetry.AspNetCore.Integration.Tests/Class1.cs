// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

#if NET7_0

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class Class1 : RecordedTestBase<MonitorExporterTestEnvironment>
    {
        private const string _activitySourceName = "TestActivitySource";
        private const string _meterName = "TestMeterName";
        private const string _roleName = nameof(Class1);

        private readonly LogsQueryClient _logsQueryClient;

        private readonly ActivitySource _activitySource = new ActivitySource(_activitySourceName);
        private readonly Meter _meter = new Meter(_meterName);

        public Class1(bool isAsync) : base(isAsync, RecordedTestMode.Live)
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
        public async Task Test_Activity()
        {
            // SETUP
            // CONFIGURE OTEL
            var resourceAttributes = new Dictionary<string, object>
            {
                { "service.name", _roleName },
            };

            IServiceCollection services = new ServiceCollection();
            services.AddOpenTelemetry()
                .ConfigureResource(x => x.AddAttributes(resourceAttributes))
                .WithTracing(builder =>
                {
                    builder.AddSource(_activitySourceName);
                })
                .UseAzureMonitor(o => o.ConnectionString = TestEnvironment.ConnectionString);

            using var serviceProvider = services.BuildServiceProvider();

            // GetRequiredService must be invoked to initialize OTel.
            var tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();

            // ACT
            await TracesScenarioAsync(tracerProvider);
            MetricsScenario();
            LogsScenario();
        }

        private async Task TracesScenarioAsync(TracerProvider tracerProvider)
        {
            // CREATE ACTIVITY
            string activityName = "MyTestActivity";
            using (var activity = _activitySource.StartActivity(activityName, ActivityKind.Internal))
            {
                activity?.SetTag("foo", "bar");
            }

            // Export
            tracerProvider?.ForceFlush();
            tracerProvider?.Shutdown(); // shutdown to stop collecting / transmitting Traces during the remainder of the test.

            // Query
            string query = $"AppDependencies | where Target == '{activityName}' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated";
            LogsTable? loggedTraces = await CheckForRecordAsync(_logsQueryClient, query);

            // Assert
            var rowCount = loggedTraces?.Rows.Count;
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

        private void MetricsScenario()
        {
            // TODO
            // CREATE METRICS
            //string counterName = "MyTestCounter";
            //var counter = _meter.CreateCounter<long>(counterName);
            //for (int i = 0; i < 20000; i++)
            //{
            //    counter.Add(1, new("tag1", "value1"), new("tag2", "value2"));
            //}
        }

        private void LogsScenario()
        {
            // TODO
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
