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
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.DocumentTests
{
    public class RequestTests : DocumentTestBase
    {
        private const string TestServerUrl = "http://localhost:9997/";

        public RequestTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void VerifyRequestAttributes()
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
            requestActivity.SetTag("url.scheme", "http");
            requestActivity.SetTag("server.address", "example.com");
            requestActivity.SetTag("server.port", "8080");
            requestActivity.SetTag("url.path", "/search");
            requestActivity.SetTag("url.query", "?q=OpenTelemetry");
            requestActivity.Stop();

            var requestDocument = DocumentHelper.ConvertToRequest(requestActivity);

            // ASSERT
            Assert.Equal(DocumentIngressDocumentType.Request, requestDocument.DocumentType);
            Assert.Equal("HelloWorld", requestDocument.Name);
            Assert.Equal("200", requestDocument.ResponseCode);
            Assert.Equal("http://example.com:8080/search?q=OpenTelemetry", requestDocument.Url);

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
            var requestDocument = DocumentHelper.ConvertToRequest(requestActivity);

            Assert.Equal(DocumentIngressDocumentType.Request, requestDocument.DocumentType);
            Assert.Equal(requestActivity.Duration.ToString("c"), requestDocument.Duration);
            Assert.Equal("GET /", requestDocument.Name);
            Assert.Equal("200", requestDocument.ResponseCode);
            Assert.Equal(TestServerUrl, requestDocument.Url);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(requestActivity.Duration.TotalMilliseconds, requestDocument.Extension_Duration);
            Assert.True(requestDocument.Extension_IsSuccess);
        }
#endif
    }
}
