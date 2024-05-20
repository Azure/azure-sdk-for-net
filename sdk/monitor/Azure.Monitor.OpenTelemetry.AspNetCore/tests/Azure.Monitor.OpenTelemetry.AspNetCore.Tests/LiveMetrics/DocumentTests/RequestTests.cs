// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.DataCollection;
using Azure.Monitor.OpenTelemetry.AspNetCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.LiveMetrics.DocumentTests
{
    public class RequestTests : DocumentTestBase
    {
        private const string TestServerUrl = "http://localhost:9997/";

        public RequestTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("http", "example.com", 8080, "/search", "?q=OpenTelemetry", "http://example.com:8080/search?q=OpenTelemetry")]
        [InlineData("http", "example.com", 80, "/search", "?q=OpenTelemetry", "http://example.com/search?q=OpenTelemetry")] // as a sideeffect of setting as new Uri, the default port is removed from the Absolute Uri.
        [InlineData("http", "example.com", 443, "/search", "?q=OpenTelemetry", "http://example.com/search?q=OpenTelemetry")] // we do not record the 443 port.
        public void VerifyRequestAttributes(string urlScheme, string serverAddress, int serverPort, string urlPath, string urlQuery, string expectedUrl)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);
            // TODO: Replace this ActivityListener with an OpenTelemetry provider.
            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            // ACT
            using var requestActivity = activitySource.StartActivity(name: "HelloWorld", kind: ActivityKind.Server);
            Assert.NotNull(requestActivity);
            requestActivity.SetTag("http.response.status_code", 200);
            requestActivity.SetTag("url.scheme", urlScheme);
            requestActivity.SetTag("server.address", serverAddress);
            requestActivity.SetTag("server.port", serverPort);
            requestActivity.SetTag("url.path", urlPath);
            requestActivity.SetTag("url.query", urlQuery);
            requestActivity.SetTag("customKey1", "customValue1");
            requestActivity.SetTag("customKey2", "customValue2");
            requestActivity.SetTag("customKey3", "customValue3");
            requestActivity.SetTag("customKey4", "customValue4");
            requestActivity.SetTag("customKey5", "customValue5");
            requestActivity.SetTag("customKey6", "customValue6");
            requestActivity.SetTag("customKey7", "customValue7");
            requestActivity.SetTag("customKey8", "customValue8");
            requestActivity.SetTag("customKey9", "customValue9");
            requestActivity.SetTag("customKey10", "customValue10");
            requestActivity.SetTag("customKey11", "customValue11");
            requestActivity.Stop();

            var requestDocument = DocumentHelper.ConvertToRequestDocument(requestActivity);

            // ASSERT
            Assert.Equal(DocumentType.Request, requestDocument.DocumentType);
            Assert.Equal("HelloWorld", requestDocument.Name);
            Assert.Equal("200", requestDocument.ResponseCode);
            Assert.Equal(expectedUrl, requestDocument.Url.AbsoluteUri);

            VerifyCustomProperties(requestDocument);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(requestActivity.Duration.TotalMilliseconds, requestDocument.Extension_Duration);
            Assert.True(requestDocument.Extension_IsSuccess);
        }

#if !NET462
        [Fact(Skip = "This test is leaky and needs to be rewritten using WebApplicationFactory (same as OTel repo).")]
        public async Task VerifyRequest()
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

            WaitForActivityExport(exportedActivities);

            // Assert
            var requestActivity = exportedActivities.First(x => x.Kind == ActivityKind.Server)!;
            PrintActivity(requestActivity);
            var requestDocument = DocumentHelper.ConvertToRequestDocument(requestActivity);

            Assert.Equal(DocumentType.Request, requestDocument.DocumentType);
            Assert.Equal(requestActivity.Duration.ToString("c"), requestDocument.Duration);
            Assert.Equal("GET /", requestDocument.Name);
            Assert.Equal("200", requestDocument.ResponseCode);
            Assert.Equal(TestServerUrl, requestDocument.Url.AbsolutePath);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(requestActivity.Duration.TotalMilliseconds, requestDocument.Extension_Duration);
            Assert.True(requestDocument.Extension_IsSuccess);
        }
#endif
    }
}
