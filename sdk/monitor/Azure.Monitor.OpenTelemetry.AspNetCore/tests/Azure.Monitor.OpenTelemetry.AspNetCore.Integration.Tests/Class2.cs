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
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

#if NET7_0

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class Class2 : RecordedTestBase<MonitorExporterTestEnvironment>
    {
        private const string _testServerUrl = "http://localhost:9999/";

        // DEVELOPER TIP: CHANGE THIS TO SOMETHING UNIQUE WHEN WORKING LOCALLY
        // EXAMPLE "Test##" TO EASILY FIND YOUR RECORDS.
        private const string _roleName = "Test6"; //nameof(Class2);

        private readonly LogsQueryClient _logsQueryClient;

        public Class2(bool isAsync) : base(isAsync, RecordedTestMode.Live)
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
                app.Logger.LogInformation("Message via ILogger LogInformation");

                //using var client = new HttpClient();
                //var response = client.GetAsync("https://www.bing.com/").Result;

                //return $"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}";
                return "Response from Test Server";
            });

            _ = app.RunAsync(_testServerUrl);

            // ACT
            using var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync(_testServerUrl).ConfigureAwait(false);
            //Assert.True(res.StartsWith("Hello World!"));
            Assert.True(res.Equals("Response from Test Server"));

            // SHUTDOWN
            // TODO: IS FLUSHING NECESSARY?
            var tracerProvider = app.Services.GetRequiredService<TracerProvider>();
            tracerProvider.ForceFlush();
            tracerProvider.Shutdown(); // shutdown to prevent subscribing to log queries.
            await app.StopAsync();

            // ASSERT
            await VerifyLogs(
                description: "Dependency for invoking HttpClient",
                query: $"AppDependencies | where Data == '{_testServerUrl}' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated");

            await VerifyLogs(
                description: "Server generated RequestTelemetry",
                query: $"AppRequests | where Url == '{_testServerUrl}' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated");

            await VerifyLogs(
                description: "Metric for incoming request",
                query: $"AppMetrics | where Name == 'http.server.duration' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated");

            // TODO: where Properties.http.peername == 'localhost'
            await VerifyLogs(
                description: "Metric for outgoing request",
                query: $"AppMetrics | where Name == 'http.client.duration' | where AppRoleName == '{_roleName}' | top 1 by TimeGenerated");

            // TODO: WHY IS AppRoleName set to "unknown_service:testhost"?
            await VerifyLogs(
                description: "ILogger LogInformation",
                query: $"AppTraces | where Message == 'Message via ILogger LogInformation' | top 1 by TimeGenerated");

            // TODO: IS THIS NEEDED?
            //await app.DisposeAsync();
        }

        private async Task VerifyLogs(string description, string query)
        {
            LogsTable? table = await _logsQueryClient.CheckForRecordAsync(query);
            LogsTableAssert.Any(table, $"No telemetry records were found: {description}");
        }
    }
}
#endif
