// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using OpenTelemetry;
using Xunit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using System.Net.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests
{
    public class DocumentHelperTests
    {
        private const string TestServerUrl = "http://localhost:9996/";

        [Fact]
        public void VerifyRemoteDependencyDocument()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);
            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            // ACT
            using var activity = activitySource.StartActivity(name: "HelloWorld", kind: ActivityKind.Client);
            Assert.NotNull(activity);
            activity.SetTag("url.full", "http://bing.com");
            activity.SetTag("http.response.status_code", 200);
            activity.Stop();

            var remoteDependencyDocument = DocumentHelper.ConvertToRemoteDependency(activity);

            // ASSERT
            Assert.Equal(DocumentIngressDocumentType.RemoteDependency, remoteDependencyDocument.DocumentType);
            Assert.Equal("HelloWorld", remoteDependencyDocument.Name);
            Assert.Equal(activity.Duration.TotalMilliseconds, remoteDependencyDocument.Extension_Duration);
            Assert.Equal("http://bing.com", remoteDependencyDocument.CommandName);
            Assert.Equal("200", remoteDependencyDocument.ResultCode);
        }

        [Fact]
        public void VerifyRequestDocument()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);
            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            // ACT
            using var activity = activitySource.StartActivity(name: "HelloWorld", kind: ActivityKind.Server);
            Assert.NotNull(activity);
            activity.SetTag("http.response.status_code", 200);
            activity.SetTag("url.scheme", "http");
            activity.SetTag("server.address", "example.com");
            activity.SetTag("server.port", "8080");
            activity.SetTag("url.path", "/search");
            activity.SetTag("url.query", "?q=OpenTelemetry");
            activity.Stop();

            var requestDocument = DocumentHelper.ConvertToRequest(activity);

            // ASSERT
            Assert.Equal(DocumentIngressDocumentType.Request, requestDocument.DocumentType);
            Assert.Equal("HelloWorld", requestDocument.Name);
            Assert.Equal(activity.Duration.TotalMilliseconds, requestDocument.Extension_Duration);
            Assert.Equal("http://example.com:8080/search?q=OpenTelemetry", requestDocument.Url);
            Assert.Equal("200", requestDocument.ResponseCode);
        }

#if !NET462
        [Fact]
        public async Task VerifyRequestDocument_Actual()
        {
            var exportedActivities = new List<Activity>();

            // SETUP WEBAPPLICATION WITH OPENTELEMETRY
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddOpenTelemetry()
                .WithTracing(builder => builder
                    .AddAspNetCoreInstrumentation()
                    .AddInMemoryExporter(exportedActivities));

            var app = builder.Build();
            app.MapGet("/", () =>
            {
                return "Response from Test Server";
            });

            _ = app.RunAsync(TestServerUrl);

            // ACT
            using var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync(TestServerUrl).ConfigureAwait(false);
            Assert.True(res.Equals("Response from Test Server"), "If this assert fails, the in-process test server is not running.");

            // Shutdown
            //response.EnsureSuccessStatusCode();
            Assert.NotNull(exportedActivities);
            this.WaitForActivityExport(exportedActivities);

            // Assert
            Assert.True(exportedActivities.Any(), "test project did not capture telemetry");
            var requestActivity = exportedActivities.First(x => x.Kind == ActivityKind.Server)!;

            var requestDocument = DocumentHelper.ConvertToRequest(requestActivity);

            Assert.Equal(DocumentIngressDocumentType.Request, requestDocument.DocumentType);
            Assert.Equal("GET /", requestDocument.Name);
            Assert.Equal(requestActivity.Duration.TotalMilliseconds, requestDocument.Extension_Duration);
            Assert.Equal(TestServerUrl, requestDocument.Url);
            Assert.Equal("200", requestDocument.ResponseCode);
        }

        [Fact]
        public async Task VerifyRemoteDependencyDocument_Actual()
        {
            var exportedActivities = new List<Activity>();

            // SETUP
            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddHttpClientInstrumentation()
                .AddInMemoryExporter(exportedActivities)
                .Build();

            // ACT
            using var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync("http://bing.com").ConfigureAwait(false);

            this.WaitForActivityExport(exportedActivities);

            // Assert
            Assert.True(exportedActivities.Any(), "test project did not capture telemetry");
            var dependencyActivity = exportedActivities.Last();

            var dependencyDocument = DocumentHelper.ConvertToRemoteDependency(dependencyActivity);

            Assert.Equal(DocumentIngressDocumentType.RemoteDependency, dependencyDocument.DocumentType);
            Assert.Equal("GET", dependencyDocument.Name);
            Assert.Equal(dependencyActivity.Duration.TotalMilliseconds, dependencyDocument.Extension_Duration);
            Assert.Equal("http://www.bing.com/", dependencyDocument.CommandName);
            Assert.Equal("200", dependencyDocument.ResultCode);
        }
#endif

        /// <summary>
        /// Wait for End callback to execute because it is executed after response was returned.
        /// </summary>
        /// <remarks>
        /// Copied from <see href="https://github.com/open-telemetry/opentelemetry-dotnet/blob/f471a9f197d797015123fe95d3e12b6abf8e1f5f/test/OpenTelemetry.Instrumentation.AspNetCore.Tests/BasicTests.cs#L558-L570"/>.
        /// </remarks>
        internal void WaitForActivityExport(List<Activity> telemetryItems)
        {
            var result = SpinWait.SpinUntil(
                condition: () =>
                {
                    Thread.Sleep(10);
                    return telemetryItems.Any();
                },
                timeout: TimeSpan.FromSeconds(10));

            Assert.True(result, $"{nameof(WaitForActivityExport)} failed.");
        }
    }
}
