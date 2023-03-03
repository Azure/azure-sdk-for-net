// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        [Theory]
        [InlineData(307)]
        [InlineData(308)]
        [InlineData(400)]
        public void UsesLocationResponseHeaderAsNewRequestUri(int statusCode)
        {
            var mockTransport = new MockTransport(new MockResponse(statusCode).AddHeader("Location", "http://new.host/"), new MockResponse(200));

            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
            var message = new HttpMessage(CreateMockRequest(new Uri("http://host")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            if (statusCode == 307 || statusCode == 308)
            {
                Assert.Equal("http://new.host/", mockTransport.Requests[1].Uri.ToString());
                Assert.Equal(2, mockTransport.Requests.Count);
            }
            else
            {
                // No redirection.
                Assert.Single(mockTransport.Requests);
            }
        }

        [Fact]
        public void UsesCachedIngestionUri()
        {
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", "http://new.host/"),
                                new MockResponse(200).AddHeader("Cache-Control", "public,max-age=1"),
                                new MockResponse(200),
                                new MockResponse(200));

            AzureMonitorExporterOptions options = new()
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
            var mockTransport = new MockTransport(_ => new MockResponse(307).AddHeader("Location", "http://new.host/"));

            AzureMonitorExporterOptions options = new()
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

            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
            var testToken = "Bearer TEST_TOKEN";
            var request = CreateMockRequest(new Uri("http://host1"));
            request.Headers.Add(HttpHeader.Names.Authorization, testToken);

            var message = new HttpMessage(request, new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal("http://new.host/", mockTransport.Requests[1].Uri.ToString());
            Assert.True(mockTransport.Requests[1].Headers.TryGetValue(HttpHeader.Names.Authorization, out string? token));
            Assert.Equal(testToken, token);
        }

        [Fact]
        public void NullResponseDoesNotImpactPolicy()
        {
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", "http://new.host/"), null);

            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
            var message = new HttpMessage(CreateMockRequest(new Uri("http://host")), new ResponseClassifier());
            // SendAsync does not throw on null response and fails silently.
            // It is handled on HttpMessage.Response property.
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal("http://new.host/", mockTransport.Requests[1].Uri.ToString());
            Assert.Equal(2, mockTransport.Requests.Count);
            Assert.Throws<InvalidOperationException>(() => message.Response);
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
