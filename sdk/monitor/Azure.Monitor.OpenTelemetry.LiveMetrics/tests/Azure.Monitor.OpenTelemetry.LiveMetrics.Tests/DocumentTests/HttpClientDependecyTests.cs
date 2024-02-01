// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using Microsoft.AspNetCore.Builder;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;

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
            using var dependencyActivity = activitySource.StartActivity(name: "HelloWorld", kind: ActivityKind.Client);
            Assert.NotNull(dependencyActivity);
            dependencyActivity.SetTag("http.method", "GET");
            dependencyActivity.SetTag("url.full", "http://bing.com");
            dependencyActivity.SetTag("http.response.status_code", 200);
            dependencyActivity.Stop();

            var dependencyDocument = DocumentHelper.ConvertToRemoteDependency(dependencyActivity);

            // ASSERT
            Assert.Equal("http://bing.com", dependencyDocument.CommandName);
            Assert.Equal(DocumentIngressDocumentType.RemoteDependency, dependencyDocument.DocumentType);
            Assert.Equal("HelloWorld", dependencyDocument.Name);
            Assert.Equal("200", dependencyDocument.ResultCode);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(dependencyActivity.Duration.TotalMilliseconds, dependencyDocument.Extension_Duration);
            Assert.True(dependencyDocument.Extension_IsSuccess);
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
            catch (HttpRequestException)
            {
                // ignored. This can be thrown for a failed request.
            }

            WaitForActivityExport(exportedActivities);

            // Assert
            Assert.True(exportedActivities.Any(), "test project did not capture telemetry");
            var dependencyActivity = exportedActivities.Last();

            var dependencyDocument = DocumentHelper.ConvertToRemoteDependency(dependencyActivity);

            Assert.Equal(requestUrl, dependencyDocument.CommandName);
            Assert.Equal(DocumentIngressDocumentType.RemoteDependency, dependencyDocument.DocumentType);
            Assert.Equal(dependencyActivity.Duration.ToString("c"), dependencyDocument.Duration);
            Assert.Equal("GET", dependencyDocument.Name);
            Assert.Equal(successfulRequest ? "200" : "404", dependencyDocument.ResultCode);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
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
