// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using static Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.TelemetryValidationHelper;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class DistroWebAppLiveTests : BaseLiveTest
    {
        private const string TestServerPort = "9998";
        private const string TestServerTarget = $"localhost:{TestServerPort}";
        private const string TestServerUrl = $"http://{TestServerTarget}/";

        private const string TestServiceName = nameof(TestServiceName), TestServiceNamespace = nameof(TestServiceNamespace), TestServiceInstance = nameof(TestServiceInstance), TestServiceVersion = nameof(TestServiceVersion);
        private const string TestRoleName = $"[{TestServiceNamespace}]/{TestServiceName}";
        private readonly Dictionary<string, object> _testResourceAttributes = new()
        {
            { "service.name", TestServiceName },
            { "service.namespace", TestServiceNamespace },
            { "service.instance.id", TestServiceInstance },
            { "service.version", TestServiceVersion }
        };

        private const string TestLogCategoryName = "CustomCategoryName";
        private const string TestLogMessage = "Message via ILogger";

        // DEVELOPER TIP: Can pass RecordedTestMode.Live into the base ctor to run this test with a live resource. This is recommended for local development.
        // DEVELOPER TIP: Can pass RecordedTestMode.Record into the base ctor to re-record the SessionRecords.
        public DistroWebAppLiveTests(bool isAsync) : base(isAsync) { }

        [RecordedTest]
        [SyncOnly] // This test cannot run concurrently with another test because OTel instruments the process and will cause side effects.
        public async Task VerifyDistro_UseAzureMonitor()
        {
            // SETUP WEBAPPLICATION WITH OPENTELEMETRY
            var builder = WebApplication.CreateBuilder();
            builder.Logging.ClearProviders();
            builder.Services.ConfigureOpenTelemetryTracerProvider((sp, builder) => builder.AddProcessor(new ActivityEnrichingProcessor()));
            builder.Services.AddOpenTelemetry()
                .UseAzureMonitor(options =>
                {
                    options.EnableLiveMetrics = false;
                    options.ConnectionString = TestEnvironment.ConnectionString;
                })
                // Custom resources must be added AFTER AzureMonitor to override the included ResourceDetectors.
                .ConfigureResource(x => x.AddAttributes(_testResourceAttributes));

            using var app = builder.Build();
            app.MapGet("/", (ILoggerFactory loggerFactory) =>
            {
                var logger = loggerFactory.CreateLogger(TestLogCategoryName);
                logger.LogInformation(TestLogMessage);

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
            await VerifyTelemetry(workspaceId: TestEnvironment.WorkspaceId);
        }

        [RecordedTest]
        [SyncOnly] // This test cannot run concurrently with another test because OTel instruments the process and will cause side effects.
        public async Task VerifySendingToTwoResources_UsingExporter()
        {
            // SETUP WEBAPPLICATION WITH OPENTELEMETRY
            var builder = WebApplication.CreateBuilder();
            builder.Logging.ClearProviders();
            builder.Services.ConfigureOpenTelemetryTracerProvider((sp, builder) => builder.AddProcessor(new ActivityEnrichingProcessor()));
            builder.Services.AddOpenTelemetry()
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
                .ConfigureResource(x => x.AddAttributes(_testResourceAttributes));

            using var app = builder.Build();
            app.MapGet("/", (ILoggerFactory loggerFactory) =>
            {
                var logger = loggerFactory.CreateLogger(TestLogCategoryName);
                logger.LogInformation(TestLogMessage);

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
            await VerifyTelemetry(workspaceId: TestEnvironment.WorkspaceId);
            await VerifyTelemetry(workspaceId: TestEnvironment.SecondaryWorkspaceId);
        }

        [RecordedTest]
        [SyncOnly] // This test cannot run concurrently with another test because OTel instruments the process and will cause side effects.
        public async Task VerifyExporter_UseAzureMonitorExporter()
        {
            // SETUP WEBAPPLICATION WITH OPENTELEMETRY
            var builder = WebApplication.CreateBuilder();

            builder.WebHost.UseUrls(TestServerUrl);

            builder.Logging.ClearProviders();
            builder.Services.ConfigureOpenTelemetryTracerProvider((sp, builder) => builder.AddProcessor(new ActivityEnrichingProcessor()));
            builder.Services.AddOpenTelemetry()
                .UseAzureMonitorExporter(options =>
                {
                    options.EnableLiveMetrics = false;
                    options.ConnectionString = TestEnvironment.ConnectionString;
                })
                .WithTracing(builder => builder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation())
                .WithMetrics(builder => builder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation())
                // Custom resources must be added AFTER AzureMonitor to override the included ResourceDetectors.
                .ConfigureResource(x => x.AddAttributes(_testResourceAttributes));

            using var app = builder.Build();
            app.MapGet("/", (ILoggerFactory loggerFactory) =>
            {
                var logger = loggerFactory.CreateLogger(TestLogCategoryName);
                logger.LogInformation(TestLogMessage);

                return "Response from Test Server";
            });

            await app.StartAsync().ConfigureAwait(false); // Start HostedServices

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
            await VerifyTelemetry(workspaceId: TestEnvironment.WorkspaceId);
        }

        private async Task VerifyTelemetry(string workspaceId)
        {
            // NOTE: The following queries are using the LogAnalytics schema.

            // DEVELOPER TIP: This test implicitly checks for telemetry within the last 30 minutes.
            // When working locally, this has the benefit of "priming" telemetry so that additional runs can complete faster without waiting for ingestion.
            // This can negatively impact the test results if you are debugging locally and making changes to the telemetry.
            // To mitigate this, you can include a timestamp in the query to only check for telemetry created since this test started.
            // IMPORTANT: we cannot include timestamps in the Recorded test because queries won't match during playback.
            // C#:      var testStartTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
            // QUERY:   | where TimeGenerated >= datetime({testStartTimeStamp})

            await QueryAndVerifyDependency(
                workspaceId: workspaceId,
                description: "Dependency for invoking HttpClient, from testhost",
                query: _useTimestampInQuery!.Value
                    ? $"AppDependencies | where Data == '{TestServerUrl}' | where AppRoleName == '{TestRoleName}' | where TimeGenerated >= datetime({ _testStartTimeStamp}) | top 1 by TimeGenerated"
                    : $"AppDependencies | where Data == '{TestServerUrl}' | where AppRoleName == '{TestRoleName}' | top 1 by TimeGenerated",
                expectedAppDependency: new ExpectedAppDependency
                {
                    Target = TestServerTarget,
                    DependencyType = "HTTP",
                    Name = "GET /",
                    Data = TestServerUrl,
                    Success = "True",
                    ResultCode = "200",
                    AppVersion = TestServiceVersion,
                    AppRoleName = TestRoleName,
                    ClientIP = "0.0.0.0",
                    Type = "AppDependencies",
                    UserAuthenticatedId = "TestAuthenticatedUserId",
                    AppRoleInstance = TestServiceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')"),
                        new("network.protocol.version", "1.1"),
                        new("CustomProperty1", "Value1"),
                    },
                });

            await QueryAndVerifyRequest(
                workspaceId: TestEnvironment.WorkspaceId,
                description: "RequestTelemetry, from WebApp",
                query: _useTimestampInQuery!.Value
                    ? $"AppRequests | where Url == '{TestServerUrl}' | where AppRoleName == '{TestRoleName}' | where TimeGenerated >= datetime({_testStartTimeStamp}) | top 1 by TimeGenerated"
                    : $"AppRequests | where Url == '{TestServerUrl}' | where AppRoleName == '{TestRoleName}' | top 1 by TimeGenerated",
                expectedAppRequest: new ExpectedAppRequest
                {
                    Url = TestServerUrl,
                    AppRoleName = TestRoleName,
                    Name = "GET /",
                    Success = "True",
                    ResultCode = "200",
                    OperationName = "GET /",
                    AppVersion = TestServiceVersion,
                    ClientIP = "0.0.0.0",
                    Type = "AppRequests",
                    UserAuthenticatedId = "TestAuthenticatedUserId",
                    AppRoleInstance = TestServiceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')"),
                        new("network.protocol.version", "1.1"),
                        new("CustomProperty1", "Value1"),
                    },
                });

            await QueryAndVerifyMetric(
                workspaceId: TestEnvironment.WorkspaceId,
                description: "Metric for outgoing request, from testhost",
                query: _useTimestampInQuery!.Value
                    ? $"AppMetrics | where Name == 'http.client.request.duration' | where AppRoleName == '{TestRoleName}' | where Properties.['server.address'] == 'localhost' | where TimeGenerated >= datetime({_testStartTimeStamp}) | top 1 by TimeGenerated"
                    : $"AppMetrics | where Name == 'http.client.request.duration' | where AppRoleName == '{TestRoleName}' | where Properties.['server.address'] == 'localhost' | top 1 by TimeGenerated",
                expectedAppMetric: new ExpectedAppMetric
                {
                    Name = "http.client.request.duration",
                    AppRoleName = TestRoleName,
                    AppVersion = TestServiceVersion,
                    Type = "AppMetrics",
                    AppRoleInstance = TestServiceInstance,
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
                description: "Metric for incoming request, from WebApp",
                query: _useTimestampInQuery!.Value
                    ? $"AppMetrics | where Name == 'http.server.request.duration' | where AppRoleName == '{TestRoleName}' | where TimeGenerated >= datetime({_testStartTimeStamp}) | top 1 by TimeGenerated"
                    : $"AppMetrics | where Name == 'http.server.request.duration' | where AppRoleName == '{TestRoleName}' | top 1 by TimeGenerated",
                expectedAppMetric: new ExpectedAppMetric
                {
                    Name = "http.server.request.duration",
                    AppRoleName = TestRoleName,
                    AppVersion = TestServiceVersion,
                    Type = "AppMetrics",
                    AppRoleInstance = TestServiceInstance,
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
                description: "ILogger LogInformation, from WebApp",
                query: _useTimestampInQuery!.Value
                    ? $"AppTraces | where Message == '{TestLogMessage}' | where AppRoleName == '{TestRoleName}' | where TimeGenerated >= datetime({_testStartTimeStamp}) | top 1 by TimeGenerated"
                    : $"AppTraces | where Message == '{TestLogMessage}' | where AppRoleName == '{TestRoleName}' | top 1 by TimeGenerated",
                expectedAppTrace: new ExpectedAppTrace
                {
                    Message = TestLogMessage,
                    SeverityLevel = "1",
                    AppRoleName = TestRoleName,
                    AppVersion = TestServiceVersion,
                    ClientIP = "0.0.0.0",
                    Type = "AppTraces",
                    AppRoleInstance = TestServiceInstance,
                    Properties = new List<KeyValuePair<string, string>>
                    {
                        new("CategoryName", TestLogCategoryName),
                    }
                });
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
