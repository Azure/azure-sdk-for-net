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
using Microsoft.Data.SqlClient;
using System.Data;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.DocumentTests
{
    public class HttpClientDependecyTests
    {
        private const string TestServerUrl = "http://localhost:9996/";

        [Fact]
        public void VerifyHttpClientAttributes()
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
            activity.SetTag("http.method", "GET");
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

#if !NET462
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task VerifyHttpClientDependency(bool successfulRequest)
        {
            var exportedActivities = new List<Activity>();

            // SETUP WEBAPPLICATION
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            app.MapGet("/", () => "Response from Test Server");
            _ = app.RunAsync(TestServerUrl);

            // SETUP
            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddHttpClientInstrumentation()
                .AddInMemoryExporter(exportedActivities)
                .Build();

            // ACT
            using var httpClient = new HttpClient();

            var requestUrl = successfulRequest ? TestServerUrl : TestServerUrl + "Fail";

            try
            {
                await httpClient.GetStringAsync(requestUrl).ConfigureAwait(false);
            }
            catch (System.Exception)
            {
                // ignored
            }

            WaitForActivityExport(exportedActivities);

            // Assert
            Assert.True(exportedActivities.Any(), "test project did not capture telemetry");
            var dependencyActivity = exportedActivities.Last();

            var dependencyDocument = DocumentHelper.ConvertToRemoteDependency(dependencyActivity);

            Assert.Equal(DocumentIngressDocumentType.RemoteDependency, dependencyDocument.DocumentType);
            Assert.Equal("GET", dependencyDocument.Name);
            Assert.Equal(requestUrl, dependencyDocument.CommandName);
            Assert.Equal(successfulRequest ? "200" : "404", dependencyDocument.ResultCode);
            Assert.NotNull(dependencyDocument.Duration);

            Assert.Equal(dependencyActivity.Duration.TotalMilliseconds, dependencyDocument.Extension_Duration);
            Assert.Equal(successfulRequest, dependencyDocument.Extension_IsSuccess);
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
