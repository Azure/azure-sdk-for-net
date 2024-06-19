// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using static Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.TelemetryValidationHelper;

#if NET6_0_OR_GREATER
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class TwoResourcesLiveTests : RecordedTestBase<AzureMonitorTestEnvironment>
    {
        private const string TestServerPort = "9997";
        private const string TestServerTarget = $"localhost:{TestServerPort}";
        private const string TestServerUrl = $"http://{TestServerTarget}/";

        private LogsQueryClient? _logsQueryClient = null;

        // DEVELOPER TIP: Can pass RecordedTestMode.Live into the base ctor to run this test with a live resource.
        // DEVELOPER TIP: Can pass RecordedTestMode.Record into the base ctor to re-record the SessionRecords.
        public TwoResourcesLiveTests(bool isAsync) : base(isAsync) { }

        [RecordedTest]
        [SyncOnly] // This test cannot run concurrently with another test because OTel instruments the process and will cause side effects.
        public async Task VerifySendingToTwoResources_UsingExporter()
        {
            var testStartTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
            Console.WriteLine($"Integration test '{nameof(VerifySendingToTwoResources_UsingExporter)}' running in mode '{TestEnvironment.Mode}'");
            var logMessage = "Message via ILogger";

            // SETUP TELEMETRY CLIENT (FOR QUERYING LOG ANALYTICS)
            _logsQueryClient = InstrumentClient(new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()
                {
                    Diagnostics = { IsLoggingContentEnabled = true }
                })
            ));

            // SETUP WEBAPPLICATION WITH OPENTELEMETRY
            string serviceName = "TestName", serviceNamespace = "TestNamespace", serviceInstance = "TestInstance", serviceVersion = "TestVersion";
            string roleName = $"[{serviceNamespace}]/{serviceName}";
            var resourceAttributes = new Dictionary<string, object>
            {
                { "service.name", serviceName },
                { "service.namespace", serviceNamespace },
                { "service.instance.id", serviceInstance },
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
            builder.Services.ConfigureOpenTelemetryTracerProvider((sp, builder) => builder.AddProcessor(new ActivityEnrichingProcessor()));
            builder.Services.AddOpenTelemetry()
                //.UseAzureMonitor(options =>
                //{
                //    options.EnableLiveMetrics = false;
                //    options.ConnectionString = TestEnvironment.ConnectionString;
                //})
                //CALLING THIS TWICE DOES NOT WORK.
                //THE SECOND CONNECTION STRING OVERRIDES THE FIRST
                //CAUSING 2x TELEMETRY IN THE SECOND RESOURCE
                //.UseAzureMonitor(options =>
                //{
                //    options.EnableLiveMetrics = false;
                //    options.ConnectionString = TestEnvironment.SecondaryConnectionString;
                //})
                .WithTracing(builder =>
                {
                    builder.AddAspNetCoreInstrumentation();
                    builder.AddHttpClientInstrumentation(o => o.FilterHttpRequestMessage = (_) =>
                    {
                        // Azure SDKs create their own client span before calling the service using HttpClient
                        // In this case, we would see two spans corresponding to the same operation
                        // 1) created by Azure SDK 2) created by HttpClient
                        // To prevent this duplication we are filtering the span from HttpClient
                        // as span from Azure SDK contains all relevant information needed.
                        var parentActivity = Activity.Current?.Parent;
                        if (parentActivity != null && parentActivity.Source.Name.Equals("Azure.Core.Http"))
                        {
                            return false;
                        }
                        return true;
                    });
                    builder.AddAzureMonitorTraceExporter(name: "primary", configure: options => options.ConnectionString = TestEnvironment.ConnectionString);
                    builder.AddAzureMonitorTraceExporter(name: "secondary", configure: options => options.ConnectionString = TestEnvironment.SecondaryConnectionString);
                })
                .WithMetrics(builder =>
                {
                    if (Environment.Version.Major >= 8)
                    {
                        builder.AddMeter("Microsoft.AspNetCore.Hosting").AddMeter("System.Net.Http");
                    }
                    else
                    {
                        builder.AddAspNetCoreInstrumentation().AddHttpClientInstrumentation();
                    }

                    builder.AddAzureMonitorMetricExporter(name: "primary", configure: options => options.ConnectionString = TestEnvironment.ConnectionString);
                    builder.AddAzureMonitorMetricExporter(name: "secondary", configure: options => options.ConnectionString = TestEnvironment.SecondaryConnectionString);
                })
                .WithLogging(builder =>
                {
                    builder.AddAzureMonitorLogExporter(name: "primary", configure: options => options.ConnectionString = TestEnvironment.ConnectionString);
                    builder.AddAzureMonitorLogExporter(name: "secondary", configure: options => options.ConnectionString = TestEnvironment.SecondaryConnectionString);
                })
                // Custom resources must be added AFTER AzureMonitor to override the included ResourceDetectors.
                .ConfigureResource(x => x.AddAttributes(resourceAttributes));

            var app = builder.Build();
            app.MapGet("/", () =>
            {
                app.Logger.LogInformation(logMessage);

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

            // DEVELOPER TIP: This test implicitly checks for telemetry within the last 30 minutes.
            // When working locally, this has the benefit of "priming" telemetry so that additional runs can complete faster without waiting for ingestion.
            // This can negatively impact the test results if you are debugging locally and making changes to the telemetry.
            // To mitigate this, you can include a timestamp in the query to only check for telemetry created since this test started.
            // IMPORTANT: we cannot include timestamps in the Recorded test because queries won't match during playback.
            // C#:      var testStartTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
            // QUERY:   | where TimeGenerated >= datetime({testStartTimeStamp})

            #region Primary Resources
            await QueryAndVerifyDependency(
                workspaceId: TestEnvironment.WorkspaceId,
                description: "PRIMARY Dependency for invoking HttpClient, from testhost",
                //query: $"AppDependencies | where Data == '{TestServerUrl}' | where AppRoleName == '{roleName}' | where TimeGenerated >= datetime({testStartTimeStamp}) | top 1 by TimeGenerated",
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
                    UserAuthenticatedId = "TestAuthenticatedUserId",
                    AppRoleInstance = serviceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')"),
                        new("CustomProperty1", "Value1"),
                    },
                });

            await QueryAndVerifyRequest(
                workspaceId: TestEnvironment.WorkspaceId,
                description: "PRIMARY RequestTelemetry, from WebApp",
                //query: $"AppRequests | where Url == '{TestServerUrl}' | where AppRoleName == '{roleName}' | where TimeGenerated >= datetime({testStartTimeStamp}) | top 1 by TimeGenerated",
                query: $"AppRequests | where Url == '{TestServerUrl}' | where AppRoleName == '{roleName}' | top 1 by TimeGenerated",
                expectedAppRequest: new ExpectedAppRequest
                {
                    Url = TestServerUrl,
                    AppRoleName = roleName,
                    Name = "GET /",
                    Success = "True",
                    ResultCode = "200",
                    OperationName = "GET /",
                    AppVersion = serviceVersion,
                    ClientIP = "0.0.0.0",
                    Type = "AppRequests",
                    UserAuthenticatedId = "TestAuthenticatedUserId",
                    AppRoleInstance = serviceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')"),
                        new("CustomProperty1", "Value1"),
                    },
                });

            await QueryAndVerifyMetric(
                workspaceId: TestEnvironment.WorkspaceId,
                description: "PRIMARY Metric for outgoing request, from testhost",
                //query: $"AppMetrics | where Name == 'http.client.request.duration' | where AppRoleName == '{roleName}' | where Properties.['server.address'] == 'localhost' | where TimeGenerated >= datetime({testStartTimeStamp}) | top 1 by TimeGenerated",
                query: $"AppMetrics | where Name == 'http.client.request.duration' | where AppRoleName == '{roleName}' | where Properties.['server.address'] == 'localhost' | top 1 by TimeGenerated",
                expectedAppMetric: new ExpectedAppMetric
                {
                    Name = "http.client.request.duration",
                    AppRoleName = roleName,
                    AppVersion = serviceVersion,
                    Type = "AppMetrics",
                    AppRoleInstance = serviceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("http.request.method", "GET"),
                        new("http.response.status_code", "200"),
                        new("network.protocol.version", "1.1"),
                        new("server.address", "localhost"),
                        new("server.port", TestServerPort),
                        new("url.scheme", "http"),
                    },
                });

            await QueryAndVerifyMetric(
                workspaceId: TestEnvironment.WorkspaceId,
                description: "PRIMARY Metric for incoming request, from WebApp",
                //query: $"AppMetrics | where Name == 'http.server.request.duration' | where AppRoleName == '{roleName}' | where TimeGenerated >= datetime({testStartTimeStamp}) | top 1 by TimeGenerated",
                query: $"AppMetrics | where Name == 'http.server.request.duration' | where AppRoleName == '{roleName}' | top 1 by TimeGenerated",
                expectedAppMetric: new ExpectedAppMetric
                {
                    Name = "http.server.request.duration",
                    AppRoleName = roleName,
                    AppVersion = serviceVersion,
                    Type = "AppMetrics",
                    AppRoleInstance = serviceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("http.request.method", "GET"),
                        new("http.response.status_code", "200"),
                        new("http.route", "/"),
                        new("network.protocol.version", "1.1"),
                        new("url.scheme", "http")
                    }
                });

            await QueryAndVerifyTrace(
                workspaceId: TestEnvironment.WorkspaceId,
                description: "PRIMARY ILogger LogInformation, from WebApp",
                //query: $"AppTraces | where Message == '{logMessage}' | where AppRoleName == '{roleName}' | where TimeGenerated >= datetime({testStartTimeStamp}) | top 1 by TimeGenerated",
                query: $"AppTraces | where Message == '{logMessage}' | where AppRoleName == '{roleName}' | top 1 by TimeGenerated",
                expectedAppTrace: new ExpectedAppTrace
                {
                    Message = logMessage,
                    SeverityLevel = "1",
                    AppRoleName = roleName,
                    AppVersion = serviceVersion,
                    ClientIP = "0.0.0.0",
                    Type = "AppTraces",
                    AppRoleInstance = serviceInstance,
                });
            #endregion

            #region Secondary Resources
            await QueryAndVerifyDependency(
                workspaceId: TestEnvironment.SecondaryWorkspaceId,
                description: "SECONDARY Dependency for invoking HttpClient, from testhost",
                //query: $"AppDependencies | where Data == '{TestServerUrl}' | where AppRoleName == '{roleName}' | where TimeGenerated >= datetime({testStartTimeStamp}) | top 1 by TimeGenerated",
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
                    UserAuthenticatedId = "TestAuthenticatedUserId",
                    AppRoleInstance = serviceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')"),
                        new("CustomProperty1", "Value1"),
                    },
                });

            await QueryAndVerifyRequest(
                workspaceId: TestEnvironment.SecondaryWorkspaceId,
                description: "SECONDARY RequestTelemetry, from WebApp",
                //query: $"AppRequests | where Url == '{TestServerUrl}' | where AppRoleName == '{roleName}' | where TimeGenerated >= datetime({testStartTimeStamp}) | top 1 by TimeGenerated",
                query: $"AppRequests | where Url == '{TestServerUrl}' | where AppRoleName == '{roleName}' | top 1 by TimeGenerated",
                expectedAppRequest: new ExpectedAppRequest
                {
                    Url = TestServerUrl,
                    AppRoleName = roleName,
                    Name = "GET /",
                    Success = "True",
                    ResultCode = "200",
                    OperationName = "GET /",
                    AppVersion = serviceVersion,
                    ClientIP = "0.0.0.0",
                    Type = "AppRequests",
                    UserAuthenticatedId = "TestAuthenticatedUserId",
                    AppRoleInstance = serviceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')"),
                        new("CustomProperty1", "Value1"),
                    },
                });

            await QueryAndVerifyMetric(
                workspaceId: TestEnvironment.SecondaryWorkspaceId,
                description: "SECONDARY Metric for outgoing request, from testhost",
                //query: $"AppMetrics | where Name == 'http.client.request.duration' | where AppRoleName == '{roleName}' | where Properties.['server.address'] == 'localhost' | where TimeGenerated >= datetime({testStartTimeStamp}) | top 1 by TimeGenerated",
                query: $"AppMetrics | where Name == 'http.client.request.duration' | where AppRoleName == '{roleName}' | where Properties.['server.address'] == 'localhost' | top 1 by TimeGenerated",
                expectedAppMetric: new ExpectedAppMetric
                {
                    Name = "http.client.request.duration",
                    AppRoleName = roleName,
                    AppVersion = serviceVersion,
                    Type = "AppMetrics",
                    AppRoleInstance = serviceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("http.request.method", "GET"),
                        new("http.response.status_code", "200"),
                        new("network.protocol.version", "1.1"),
                        new("server.address", "localhost"),
                        new("server.port", TestServerPort),
                        new("url.scheme", "http"),
                    },
                });

            await QueryAndVerifyMetric(
                workspaceId: TestEnvironment.SecondaryWorkspaceId,
                description: "SECONDARY Metric for incoming request, from WebApp",
                //query: $"AppMetrics | where Name == 'http.server.request.duration' | where AppRoleName == '{roleName}' | where TimeGenerated >= datetime({testStartTimeStamp}) | top 1 by TimeGenerated",
                query: $"AppMetrics | where Name == 'http.server.request.duration' | where AppRoleName == '{roleName}' | top 1 by TimeGenerated",
                expectedAppMetric: new ExpectedAppMetric
                {
                    Name = "http.server.request.duration",
                    AppRoleName = roleName,
                    AppVersion = serviceVersion,
                    Type = "AppMetrics",
                    AppRoleInstance = serviceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("http.request.method", "GET"),
                        new("http.response.status_code", "200"),
                        new("http.route", "/"),
                        new("network.protocol.version", "1.1"),
                        new("url.scheme", "http")
                    }
                });

            await QueryAndVerifyTrace(
                workspaceId: TestEnvironment.SecondaryWorkspaceId,
                description: "SECONDARY ILogger LogInformation, from WebApp",
                //query: $"AppTraces | where Message == '{logMessage}' | where AppRoleName == '{roleName}' | where TimeGenerated >= datetime({testStartTimeStamp}) | top 1 by TimeGenerated",
                query: $"AppTraces | where Message == '{logMessage}' | where AppRoleName == '{roleName}' | top 1 by TimeGenerated",
                expectedAppTrace: new ExpectedAppTrace
                {
                    Message = logMessage,
                    SeverityLevel = "1",
                    AppRoleName = roleName,
                    AppVersion = serviceVersion,
                    ClientIP = "0.0.0.0",
                    Type = "AppTraces",
                    AppRoleInstance = serviceInstance,
                });
            #endregion
        }

        private async Task QueryAndVerifyDependency(string workspaceId, string description, string query, ExpectedAppDependency expectedAppDependency)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(workspaceId, description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppDependency);
        }

        private async Task QueryAndVerifyRequest(string workspaceId, string description, string query, ExpectedAppRequest expectedAppRequest)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(workspaceId, description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppRequest);
        }

        private async Task QueryAndVerifyMetric(string workspaceId, string description, string query, ExpectedAppMetric expectedAppMetric)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(workspaceId, description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppMetric);
        }

        private async Task QueryAndVerifyTrace(string workspaceId, string description, string query, ExpectedAppTrace expectedAppTrace)
        {
            LogsTable? logsTable = await _logsQueryClient!.QueryTelemetryAsync(workspaceId, description, query);
            ValidateExpectedTelemetry(description, logsTable, expectedAppTrace);
        }

        public class ActivityEnrichingProcessor : BaseProcessor<Activity>
        {
            public override void OnEnd(Activity activity)
            {
                activity.SetTag("CustomProperty1", "Value1");
                activity.SetTag("enduser.id", "TestAuthenticatedUserId");
            }
        }
    }
}
#endif
