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
        private static readonly Uri s_originalUri = new Uri("https://westus-0.in.applicationinsights.azure.com/");
        private const string TrustedRedirectUri = "https://eastus-0.in.applicationinsights.azure.com/";

        [Theory]
        [InlineData(307)]
        [InlineData(308)]
        [InlineData(400)]
        public void UsesLocationResponseHeaderAsNewRequestUri(int statusCode)
        {
            var mockTransport = new MockTransport(new MockResponse(statusCode).AddHeader("Location", TrustedRedirectUri), new MockResponse(200));

            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
            var message = new HttpMessage(CreateMockRequest(s_originalUri), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            if (statusCode == 307 || statusCode == 308)
            {
                Assert.Equal(TrustedRedirectUri, mockTransport.Requests[1].Uri.ToString());
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
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", TrustedRedirectUri),
                                new MockResponse(200).AddHeader("Cache-Control", "public,max-age=1"),
                                new MockResponse(200),
                                new MockResponse(200));

            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });

            // Default behavior, request gets redirected.
            var message = new HttpMessage(CreateMockRequest(s_originalUri), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(TrustedRedirectUri, mockTransport.Requests[1].Uri.ToString());
            Assert.Equal(2, mockTransport.Requests.Count);

            // Redirect is cached.
            message = new HttpMessage(CreateMockRequest(s_originalUri), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(3, mockTransport.Requests.Count);
            Assert.Equal(TrustedRedirectUri, mockTransport.Requests[2].Uri.ToString());

            // wait for cache to expire
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();

            message = new HttpMessage(CreateMockRequest(s_originalUri), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(4, mockTransport.Requests.Count);
            Assert.Equal(s_originalUri, mockTransport.Requests[3].Uri.ToUri());
        }

        [Fact]
        public void ReturnsOnMaxIngestionRedirects()
        {
            var mockTransport = new MockTransport(_ => new MockResponse(307).AddHeader("Location", TrustedRedirectUri));

            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
            var message = new HttpMessage(CreateMockRequest(s_originalUri), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(10, mockTransport.Requests.Count);
        }

        [Fact]
        public void RejectsUntrustedRedirect()
        {
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", "https://attacker.example/"), new MockResponse(200));

            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
            var request = CreateMockRequest(s_originalUri);
            request.Headers.Add(HttpHeader.Names.Authorization, "Bearer TEST_TOKEN");

            var message = new HttpMessage(request, new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Single(mockTransport.Requests);
            Assert.Equal(s_originalUri, mockTransport.Requests[0].Uri.ToUri());
        }

        [Fact]
        public void VerifyAuthHeaderPreservedOnSameOriginRedirect()
        {
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", s_originalUri + "newpath"), new MockResponse(200));

            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
            var testToken = "Bearer TEST_TOKEN";
            var request = CreateMockRequest(s_originalUri);
            request.Headers.Add(HttpHeader.Names.Authorization, testToken);

            var message = new HttpMessage(request, new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            // The redirect stays within the same origin, so the Authorization header
            // is preserved for the legitimate endpoint.
            Assert.Equal(s_originalUri + "newpath", mockTransport.Requests[1].Uri.ToString());
            Assert.True(mockTransport.Requests[1].Headers.TryGetValue(HttpHeader.Names.Authorization, out string? token));
            Assert.Equal(testToken, token);
        }

        [Fact]
        public void RejectedRedirectIsNotCached()
        {
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", "https://attacker.example/"),
                                new MockResponse(200));

            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });

            var request1 = CreateMockRequest(s_originalUri);
            var message1 = new HttpMessage(request1, new ResponseClassifier());
            pipeline.SendAsync(message1, CancellationToken.None);

            var request2 = CreateMockRequest(s_originalUri);
            var message2 = new HttpMessage(request2, new ResponseClassifier());
            pipeline.SendAsync(message2, CancellationToken.None);

            Assert.Equal(2, mockTransport.Requests.Count);
            Assert.All(mockTransport.Requests, request => Assert.Equal(s_originalUri, request.Uri.ToUri()));
        }

        [Theory]
        [InlineData("http://eastus-0.in.applicationinsights.azure.com/")]
        [InlineData("https://user@eastus-0.in.applicationinsights.azure.com/")]
        [InlineData("https://eastus-0.in.applicationinsights.azure.com:444/")]
        [InlineData("https://eastus-0.in.applicationinsights.azure.com.attacker.example/")]
        [InlineData("not a uri")]
        public void RejectsInvalidRedirectTarget(string redirectUri)
        {
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", redirectUri), new MockResponse(200));
            AzureMonitorExporterOptions options = new() { Transport = mockTransport };
            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });

            var message = new HttpMessage(CreateMockRequest(s_originalUri), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Single(mockTransport.Requests);
        }

        [Fact]
        public void NullResponseDoesNotImpactPolicy()
        {
            var mockTransport = new MockTransport(new MockResponse(307).AddHeader("Location", TrustedRedirectUri), null);

            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
            var message = new HttpMessage(CreateMockRequest(s_originalUri), new ResponseClassifier());
            // SendAsync does not throw on null response and fails silently.
            // It is handled on HttpMessage.Response property.
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(TrustedRedirectUri, mockTransport.Requests[1].Uri.ToString());
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
