// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.TelemetryValidationHelper;

#if NET6_0_OR_GREATER
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class DistroWebAppLiveTests : RecordedTestBase<AzureMonitorTestEnvironment>
    {
        private const string TestServerPort = "9998";
        private const string TestServerTarget = $"localhost:{TestServerPort}";
        private const string TestServerUrl = $"http://{TestServerTarget}/";

        private const string LogMessage = "Message via ILogger";

        private LogsQueryClient? _logsQueryClient = null;

        // DEVELOPER TIP: Can pass RecordedTestMode.Live into the base ctor to run this test with a live resource.
        // DEVELOPER TIP: Can pass RecordedTestMode.Record into the base ctor to re-record the SessionRecords.
        public DistroWebAppLiveTests(bool isAsync) : base(isAsync) { }

        [RecordedTest]
        [SyncOnly] // This test cannot run concurrently with another test because OTel instruments the process and will cause side effects.
        public async Task VerifyDistro()
        {
            Console.WriteLine($"Integration test '{nameof(VerifyDistro)}' running in mode '{TestEnvironment.Mode}'");

            // DEVELOPER TIP: This test implicitly checks for telemetry within the last 30 minutes.
            // When working locally, this has the benefit of "priming" telemetry so that additional runs can complete faster without waiting for ingestion.
            // This can negatively impact the test results if you are debugging locally and making changes to the telemetry.
            // To mitigate this, you can include a timestamp in the query to only check for telemetry created since this test started.
            // IMPORTANT: we cannot include timestamps in the Recorded test because it breaks queries during playback.
            // C#:      var testStartTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
            // QUERY:   | where TimeGenerated >= datetime({ testStartTimeStamp})

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
            string serviceName = "TestName", serviceNamespace = "TestNamespace", serviceVersion = "TestVersion";
            string roleName = $"[{serviceNamespace}]/{serviceName}";
            var resourceAttributes = new Dictionary<string, object>
            {
                { "service.name", serviceName },
                { "service.namespace", serviceNamespace },
                { "service.version", serviceVersion }
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
                    options.EnableLiveMetrics = false;
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
            await QueryAndVerifyDependency(
                description: "Dependency for invoking HttpClient, from testhost",
                query: $"AppDependencies | where Data == '{TestServerUrl}' | where AppRoleName == '{roleName}' | top 1 by TimeGenerated",
                expectedAppDependency: new ExpectedAppDependency
                {
                    Target = TestServerTarget,
                    DependencyType = "HTTP",
                    Name = "GET /",
                    Data = TestServerUrl,
                    Success = "True",
                    ResultCode = "200",
                    AppVersion = serviceVersion,
                    AppRoleName = roleName,
                    ClientIP = "0.0.0.0",
                    Type = "AppDependencies",
                });

            await QueryAndVerifyRequest(
                description: "RequestTelemetry, from WebApp",
                query: $"AppRequests | where Url == '{TestServerUrl}' | where AppRoleName == '{roleName}' | top 1 by TimeGenerated",
                expectedAppRequest: new ExpectedAppRequest
                {
                    Url = TestServerUrl,
                    AppRoleName = roleName,
                });

            await QueryAndVerifyMetric(
                description: "Metric for outgoing request, from testhost",
                query: $"AppMetrics | where Name == 'http.client.request.duration' | where AppRoleName == '{roleName}' | where Properties.['server.address'] == 'localhost' | top 1 by TimeGenerated",
                expectedAppMetric: new ExpectedAppMetric
                {
                    Name = "http.client.request.duration",
                    AppRoleName = roleName,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("server.address", "localhost"),
                    },
                });

            await QueryAndVerifyMetric(
                description: "Metric for incoming request, from WebApp",
                query: $"AppMetrics | where Name == 'http.server.request.duration' | where AppRoleName == '{roleName}' | top 1 by TimeGenerated",
                expectedAppMetric: new ExpectedAppMetric
                {
                    Name = "http.server.request.duration",
                    AppRoleName = roleName,
                    Properties = new(),
                });

            await QueryAndVerifyTrace(
                description: "ILogger LogInformation, from WebApp",
                query: $"AppTraces | where Message == '{LogMessage}' | where AppRoleName == '{roleName}' | top 1 by TimeGenerated",
                expectedAppTrace: new ExpectedAppTrace
                {
                    Message = LogMessage,
                    AppRoleName = roleName,
                });
        }

        private async Task QueryAndVerifyDependency(string description, string query, ExpectedAppDependency expectedAppDependency)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppDependency);
        }

        private async Task QueryAndVerifyRequest(string description, string query, ExpectedAppRequest expectedAppRequest)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppRequest);
        }

        private async Task QueryAndVerifyMetric(string description, string query, ExpectedAppMetric expectedAppMetric)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppMetric);
        }

        private async Task QueryAndVerifyTrace(string description, string query, ExpectedAppTrace expectedAppTrace)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppTrace);
        }
    }
}
#endif
