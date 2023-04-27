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
using OpenTelemetry.Resources;

#if NET6_0_OR_GREATER
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class DistroWebAppLiveTests : RecordedTestBase<MonitorExporterTestEnvironment>
    {
        private const string _testServerUrl = "http://localhost:9999/";

        // DEVELOPER TIP: Change roleName to something unique when working locally (Example "Test##") to easily find your records.
        // Can search for all records in the portal using this query:   Union * | where AppRoleName == 'Test##'
        private const string _roleName = nameof(DistroWebAppLiveTests);

        private const string _logMessage = "Message via ILogger";

        private readonly LogsQueryClient _logsQueryClient;

        // DEVELOPER TIP: Can pass RecordedTestMode.Live to the base ctor to run this test with a live resource.
        public DistroWebAppLiveTests(bool isAsync) : base(isAsync)
        {
            _logsQueryClient = InstrumentClient(new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()
                {
                    Diagnostics = { IsLoggingContentEnabled = true }
                })
            ));

            _logsQueryClient.SetQueryWorkSpaceId(TestEnvironment.WorkspaceId);
        }

        [RecordedTest]
        public async Task Test()
        {
            // SETUP
            var resourceAttributes = new Dictionary<string, object>
            {
                { "service.name", _roleName },
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
                app.Logger.LogInformation(_logMessage);

                return "Response from Test Server";
            });

            _ = app.RunAsync(_testServerUrl);

            // ACT
            using var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync(_testServerUrl).ConfigureAwait(false);
            Assert.True(res.Equals("Response from Test Server"), "If this assert fails, the in-process test server is not running.");

            // SHUTDOWN

            // NOTE: If this test starts failing, Flushing may be necessary.
            //var tracerProvider = app.Services.GetRequiredService<TracerProvider>();
            //tracerProvider.ForceFlush();
            //tracerProvider.Shutdown();

            await app.StopAsync(); // shutdown to prevent collecting to log queries.

            // ASSERT
            // TODO: NEED TO PERFORM COLUMN LEVEL VALIDATIONS.
            await VerifyLogs(
                description: "Dependency for invoking HttpClient, from testhost",
                query: $"AppDependencies | where Data == '{_testServerUrl}' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated");

            await VerifyLogs(
                description: "RequestTelemetry, from WebApp",
                query: $"AppRequests | where Url == '{_testServerUrl}' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated");

            await VerifyLogs(
                description: "Metric for outgoing request, from testhost",
                query: $"AppMetrics | where Name == 'http.client.duration' | where AppRoleName == '{_roleName}' | where Properties.['net.peer.name'] == 'localhost' | top 1 by TimeGenerated");

            await VerifyLogs(
                description: "Metric for incoming request, from WebApp",
                query: $"AppMetrics | where Name == 'http.server.duration' | where AppRoleName == '{_roleName}' | where Properties.['net.host.name'] == 'localhost' | top 1 by TimeGenerated");

            await VerifyLogs(
                description: "ILogger LogInformation, from WebApp",
                query: $"AppTraces | where Message == '{_logMessage}' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated");
        }

        private async Task VerifyLogs(string description, string query)
        {
            LogsTable? table = await _logsQueryClient.CheckForRecordAsync(query);

            var rowCount = table?.Rows.Count;
            if (rowCount == null || rowCount == 0)
            {
                Assert.Inconclusive($"No telemetry records were found: {description}");
            }
            else
            {
                Assert.True(true);
            }
        }
    }
}
#endif
