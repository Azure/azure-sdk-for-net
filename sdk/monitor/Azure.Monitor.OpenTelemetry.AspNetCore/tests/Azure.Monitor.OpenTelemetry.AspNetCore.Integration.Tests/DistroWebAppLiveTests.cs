// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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

#if NET6_0_OR_GREATER
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class DistroWebAppLiveTests : RecordedTestBase<AzureMonitorTestEnvironment>
    {
        private const string TestServerUrl = "http://localhost:9998/";

        // DEVELOPER TIP: Change roleName to something unique when working locally (Example "Test##") to easily find your records.
        // Can search for all records in the portal via Log Analytics using this query:   Union * | where AppRoleName == 'Test##'
        private const string RoleName = nameof(DistroWebAppLiveTests);

        private const string LogMessage = "Message via ILogger";

        private LogsQueryClient? _logsQueryClient = null;

        // DEVELOPER TIP: Can pass RecordedTestMode.Live into the base ctor to run this test with a live resource.
        // DEVELOPER TIP: Can pass RecordedTestMode.Record into the base ctor to re-record the SessionRecords.
        public DistroWebAppLiveTests(bool isAsync) : base(isAsync) { }

        [RecordedTest]
        [SyncOnly] // This test cannot run concurrently with another test because OTel instruments the process and will cause side effects.
        [Ignore("Test fails in Mac-OS.")]
        public async Task VerifyDistro()
        {
            // SETUP TELEMETRY CLIENT (FOR QUERYING LOG ANALYTICS)
            _logsQueryClient = InstrumentClient(new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()
                {
                    Diagnostics = { IsLoggingContentEnabled = true }
                })
            ));

            _logsQueryClient.SetQueryWorkSpaceId(TestEnvironment.WorkspaceId);

            // SETUP WEBAPPLICATION WITH OPENTELEMETRY
            var resourceAttributes = new Dictionary<string, object>
            {
                { "service.name", RoleName },
            };

            var resourceBuilder = ResourceBuilder.CreateDefault();
            resourceBuilder.AddAttributes(resourceAttributes);

            var builder = WebApplication.CreateBuilder();
            builder.Logging.ClearProviders();
            builder.Services.AddOptions<OpenTelemetryLoggerOptions>()
                .Configure(options =>
                {
                    options.SetResourceBuilder(resourceBuilder);
                });
            builder.Services.AddOpenTelemetry()
                .ConfigureResource(x => x.AddAttributes(resourceAttributes))
                .UseAzureMonitor(options =>
                {
                    options.ConnectionString = TestEnvironment.ConnectionString;
                });

            var app = builder.Build();
            app.MapGet("/", () =>
            {
                app.Logger.LogInformation(LogMessage);

                return "Response from Test Server";
            });

            _ = app.RunAsync(TestServerUrl);

            // ACT
            using var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync(TestServerUrl).ConfigureAwait(false);
            Assert.True(res.Equals("Response from Test Server"), "If this assert fails, the in-process test server is not running.");

            // SHUTDOWN
            var tracerProvider = app.Services.GetRequiredService<TracerProvider>();
            tracerProvider.ForceFlush();
            tracerProvider.Shutdown();

            var meterProvider = app.Services.GetRequiredService<MeterProvider>();
            meterProvider.ForceFlush();
            meterProvider.Shutdown();

            await app.StopAsync(); // shutdown to prevent collecting the log queries.

            // ASSERT
            // NOTE: The following queries are using the LogAnalytics schema.
            // TODO: NEED TO PERFORM COLUMN LEVEL VALIDATIONS.
            await VerifyTelemetry(
                description: "Dependency for invoking HttpClient, from testhost",
                query: $"AppDependencies | where Data == '{TestServerUrl}' | where AppRoleName == '{RoleName}' | top 1 by TimeGenerated");

            await VerifyTelemetry(
                description: "RequestTelemetry, from WebApp",
                query: $"AppRequests | where Url == '{TestServerUrl}' | where AppRoleName == '{RoleName}' | top 1 by TimeGenerated");

            await VerifyTelemetry(
                description: "Metric for outgoing request, from testhost",
                query: $"AppMetrics | where Name == 'http.client.duration' | where AppRoleName == '{RoleName}' | where Properties.['net.peer.name'] == 'localhost' | top 1 by TimeGenerated");

            await VerifyTelemetry(
                description: "Metric for incoming request, from WebApp",
                query: $"AppMetrics | where Name == 'http.server.duration' | where AppRoleName == '{RoleName}' | where Properties.['net.host.name'] == 'localhost' | top 1 by TimeGenerated");

            await VerifyTelemetry(
                description: "ILogger LogInformation, from WebApp",
                query: $"AppTraces | where Message == '{LogMessage}' | where AppRoleName == '{RoleName}' | top 1 by TimeGenerated");
        }

        private async Task VerifyTelemetry(string description, string query)
        {
            LogsTable? table = await _logsQueryClient!.CheckForRecordAsync(query);

            var rowCount = table?.Rows.Count;
            if (rowCount == null || rowCount == 0)
            {
                Assert.Fail($"No telemetry records were found: {description}");
            }
            else
            {
                Assert.Pass();
            }
        }
    }
}
#endif
