// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class IngestionRedirectPolicyTests
    {
        [Fact]
        public void UsesLocationResponseHeaderAsNewRequestUri()
        {
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", "http://new.host/"), new MockResponse(200));

            // 307
            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions()
            {
                Transport = mockTransport,
            };
            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });

            var message = new HttpMessage(CreateMockRequest(new Uri("http://host1")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal("http://new.host/", mockTransport.Requests[1].Uri.ToString());
            Assert.Equal(2, mockTransport.Requests.Count);

            // 308
            mockTransport = new MockTransport(new MockResponse(308).AddHeader("Location", "http://new.host/"), new MockResponse(200));
            options = new AzureMonitorExporterOptions() { Transport = mockTransport };
            pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
            message = new HttpMessage(CreateMockRequest(new Uri("http://host1")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal("http://new.host/", mockTransport.Requests[1].Uri.ToString());
            Assert.Equal(2, mockTransport.Requests.Count);

            // Other failure code.
            mockTransport = new MockTransport(new MockResponse(400).AddHeader("Location", "http://new.host/"), new MockResponse(200));
            options = new AzureMonitorExporterOptions() { Transport = mockTransport };
            pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
            message = new HttpMessage(CreateMockRequest(new Uri("http://host1")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            // No redirection.
            Assert.Single(mockTransport.Requests);
        }

        [Fact]
        public void UsesCachedIngestionUri()
        {
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", "http://new.host/"),
                                new MockResponse(200).AddHeader("Cache-Control", "public,max-age=1"),
                                new MockResponse(200),
                                new MockResponse(200));

            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions()
            {
                Transport = mockTransport,
            };
            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });

            // Default behavior, request gets redirected.
            var message = new HttpMessage(CreateMockRequest(new Uri("http://host1")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal("http://new.host/", mockTransport.Requests[1].Uri.ToString());
            Assert.Equal(2, mockTransport.Requests.Count);

            // Redirect is cached.
            message = new HttpMessage(CreateMockRequest(new Uri("http://host2")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(3, mockTransport.Requests.Count);
            Assert.Equal("http://new.host/", mockTransport.Requests[2].Uri.ToString());

            // wait for cache to expire
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();

            message = new HttpMessage(CreateMockRequest(new Uri("http://host3")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(4, mockTransport.Requests.Count);
            Assert.Equal("http://host3/", mockTransport.Requests[3].Uri.ToString());
        }

        [Fact]
        public void ReturnsOnMaxIngestionRedirects()
        {
            var mockTransport = new MockTransport(_ =>
                                    new MockResponse(307).AddHeader("Location", "http://new.host/"));

            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions()
            {
                Transport = mockTransport,
            };
            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });

            var message = new HttpMessage(CreateMockRequest(new Uri("http://host1")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(10, mockTransport.Requests.Count);
        }

        [Fact]
        public void VerifyAuthHeaderPreserved()
        {
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", "http://new.host/"), new MockResponse(200));

            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions()
            {
                Transport = mockTransport,
            };
            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });

            var request = CreateMockRequest(new Uri("http://host1"));
            var testToken = "Bearer TEST_TOKEN";
            request.Headers.Add(HttpHeader.Names.Authorization, testToken);
            var message = new HttpMessage(request, new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal("http://new.host/", mockTransport.Requests[1].Uri.ToString());
            Assert.True(mockTransport.Requests[1].Headers.TryGetValue(HttpHeader.Names.Authorization, out string token));
            Assert.Equal(testToken, token);
        }

        private static MockRequest CreateMockRequest(Uri uri)
        {
            MockRequest mockRequest = new MockRequest();
            mockRequest.Uri.Reset(uri);
            mockRequest.Method = RequestMethod.Get;
            return mockRequest;
        }
    }
}
