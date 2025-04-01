// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using Microsoft.AspNetCore.Builder;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.DocumentTests
{
    public class HttpClientDependecyTests : DocumentTestBase
    {
        private const string TestServerUrl = "http://localhost:9996/";

        public HttpClientDependecyTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void VerifyHttpClientAttributes()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);
            // TODO: Replace this ActivityListener with an OpenTelemetry provider.
            using var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            // ACT
            using var dependencyActivity = activitySource.StartActivity(name: "TestActivityName", kind: ActivityKind.Client);
            Assert.NotNull(dependencyActivity);
            dependencyActivity.SetTag("http.request.method", "GET");
            dependencyActivity.SetTag("url.full", "http://bing.com");
            dependencyActivity.SetTag("http.response.status_code", 200);

            dependencyActivity.SetTag("customKey1", "customValue1");
            dependencyActivity.SetTag("customKey2", "customValue2");
            dependencyActivity.SetTag("customKey3", "customValue3");
            dependencyActivity.SetTag("customKey4", "customValue4");
            dependencyActivity.SetTag("customKey5", "customValue5");
            dependencyActivity.SetTag("customKey6", "customValue6");
            dependencyActivity.SetTag("customKey7", "customValue7");
            dependencyActivity.SetTag("customKey8", "customValue8");
            dependencyActivity.SetTag("customKey9", "customValue9");
            dependencyActivity.SetTag("customKey10", "customValue10");
            dependencyActivity.SetTag("customKey11", "customValue11");
            dependencyActivity.Stop();

            var dependencyDocument = DocumentHelper.ConvertToDependencyDocument(dependencyActivity);

            // ASSERT
            Assert.Equal("http://bing.com", dependencyDocument.CommandName);
            Assert.Equal(DocumentType.RemoteDependency, dependencyDocument.DocumentType);
            Assert.Equal("TestActivityName", dependencyDocument.Name);
            Assert.Equal("200", dependencyDocument.ResultCode);

            VerifyCustomProperties(dependencyDocument);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(dependencyActivity.Duration.TotalMilliseconds, dependencyDocument.Extension_Duration);
            Assert.True(dependencyDocument.Extension_IsSuccess);
        }

#if NET
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task VerifyHttpClientDependency(bool successfulRequest)
        {
            var exportedActivities = new List<Activity>();

            // SETUP WEBAPPLICATION
            var builder = WebApplication.CreateBuilder();
            using var app = builder.Build();
            app.MapGet("/", () => "Response from Test Server");
            _ = app.RunAsync(TestServerUrl);

            // SETUP
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
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

            tracerProvider.ForceFlush();
            WaitForActivityExport(exportedActivities);

            // Assert
            var dependencyActivity = exportedActivities.Last();
            PrintActivity(dependencyActivity);
            var dependencyDocument = DocumentHelper.ConvertToDependencyDocument(dependencyActivity);

            Assert.Equal(requestUrl, dependencyDocument.CommandName);
            Assert.Equal(DocumentType.RemoteDependency, dependencyDocument.DocumentType);
            Assert.Equal(dependencyActivity.Duration.ToString("c"), dependencyDocument.Duration);
            Assert.Equal("GET", dependencyDocument.Name);
            Assert.Equal(successfulRequest ? "200" : "404", dependencyDocument.ResultCode);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(dependencyActivity.Duration.TotalMilliseconds, dependencyDocument.Extension_Duration);
            Assert.Equal(successfulRequest, dependencyDocument.Extension_IsSuccess);
        }
#endif
    }
}
