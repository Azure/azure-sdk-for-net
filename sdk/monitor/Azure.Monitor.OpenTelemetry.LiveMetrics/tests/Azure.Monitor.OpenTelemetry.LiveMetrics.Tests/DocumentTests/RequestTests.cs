// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.DocumentTests
{
    public class RequestTests : DocumentTestBase, IClassFixture<WebApplicationFactory<AspNetCoreTestApp.Program>>, IDisposable
    {
        private readonly WebApplicationFactory<AspNetCoreTestApp.Program> _factory;

        public RequestTests(WebApplicationFactory<AspNetCoreTestApp.Program> factory, ITestOutputHelper output) : base(output)
        {
            _factory = factory;
        }

        public void Dispose()
        {
            // OpenTelemetry is registered on a nested Factory which is not disposed between test runs!
            // MUST explicitly dispose the nested Factory to avoid test conflicts.
            _factory.Factories.LastOrDefault()?.Dispose();

            _factory.Dispose();
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
            using var listener = new ActivityListener
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

        [Fact]
        public void VerifyRequest()
        {
            var exportedActivities = new List<Activity>();

            // SETUP WEBAPPLICATIONFACTORY WITH OPENTELEMETRY
            using (var client = _factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(serviceCollection =>
                    {
                        serviceCollection.AddOpenTelemetry()
                            .WithTracing(x =>
                            {
                                x.AddAspNetCoreInstrumentation();
                                x.AddInMemoryExporter(exportedActivities);
                            });
                    });

                    builder.Configure(app =>
                    {
                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapGet("/", async context =>
                            {
                                context.Response.StatusCode = 200;
                                await context.Response.WriteAsync("Response from Test Server");
                            });
                        });
                    });
                })
                .CreateClient())
            {
                using var response = client.GetAsync("/").Result;
                Assert.True(response.Content.ReadAsStringAsync().Result.Equals("Response from Test Server"), "If this assert fails, the in-process test server is not running.");
            }

            // SHUTDOWN
            var tracerProvider = _factory.Factories.Last().Services.GetRequiredService<TracerProvider>();
            tracerProvider.ForceFlush();

            WaitForActivityExport(exportedActivities);

            // Assert
            var requestActivity = exportedActivities.First(x => x.Kind == ActivityKind.Server)!;
            PrintActivity(requestActivity);
            var requestDocument = DocumentHelper.ConvertToRequestDocument(requestActivity);

            Assert.Equal(DocumentType.Request, requestDocument.DocumentType);
            Assert.Equal(requestActivity.Duration.ToString("c"), requestDocument.Duration);
            Assert.Equal("GET /", requestDocument.Name);
            Assert.Equal("200", requestDocument.ResponseCode);
            Assert.Equal("/", requestDocument.Url.AbsolutePath);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(requestActivity.Duration.TotalMilliseconds, requestDocument.Extension_Duration);
            Assert.True(requestDocument.Extension_IsSuccess);
        }
    }
}
#endif
