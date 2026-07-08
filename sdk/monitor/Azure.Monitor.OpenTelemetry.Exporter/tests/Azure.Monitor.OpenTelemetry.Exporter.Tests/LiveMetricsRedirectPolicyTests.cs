// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class LiveMetricsRedirectPolicyTests
    {
        private const string RedirectHeaderName = "x-ms-qps-service-endpoint-redirect-v2";
        private const string RedirectUri = "https://westus.livediagnostics.monitor.azure.com/QuickPulseService.svc";
        private const string RedirectHost = "westus.livediagnostics.monitor.azure.com";
        private const string OriginalUri = "https://rt.services.visualstudio.com/QuickPulseService.svc/ping";

        [Fact]
        public void RedirectUpdatesRequestHost()
        {
            var mockTransport = new MockTransport(
                new MockResponse(200).AddHeader(RedirectHeaderName, RedirectUri),
                new MockResponse(200));

            var pipeline = BuildPipeline(mockTransport);
            var message = new HttpMessage(CreateMockRequest(new Uri(OriginalUri)), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(2, mockTransport.Requests.Count);
            Assert.Equal(RedirectHost, mockTransport.Requests[1].Uri.Host);
        }

        [Fact]
        public void RedirectAppliesValidatedAuthority()
        {
            var mockTransport = new MockTransport(
                new MockResponse(200).AddHeader(RedirectHeaderName, RedirectUri),
                new MockResponse(200));

            var pipeline = BuildPipeline(mockTransport);
            var message = new HttpMessage(CreateMockRequest(new Uri("http://rt.services.visualstudio.com:444/QuickPulseService.svc/ping")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(Uri.UriSchemeHttps, mockTransport.Requests[1].Uri.Scheme);
            Assert.Equal(RedirectHost, mockTransport.Requests[1].Uri.Host);
            Assert.Equal(443, mockTransport.Requests[1].Uri.Port);
        }

        [Fact]
        public void VerifyAuthHeaderPreservedOnTrustedCrossHostRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(200).AddHeader(RedirectHeaderName, RedirectUri),
                new MockResponse(200));

            var pipeline = BuildPipeline(mockTransport);
            var request = CreateMockRequest(new Uri(OriginalUri));
            request.Headers.Add(HttpHeader.Names.Authorization, "Bearer TEST_TOKEN");

            var message = new HttpMessage(request, new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(RedirectHost, mockTransport.Requests[1].Uri.Host);
            Assert.True(mockTransport.Requests[1].Headers.TryGetValue(HttpHeader.Names.Authorization, out string? token));
            Assert.Equal("Bearer TEST_TOKEN", token);
        }

        [Fact]
        public void VerifyAuthHeaderPreservedOnSameHostRedirect()
        {
            // Redirect points to the same host the request already targets.
            var sameHostRedirect = $"https://{RedirectHost}/QuickPulseService.svc";
            var mockTransport = new MockTransport(
                new MockResponse(200).AddHeader(RedirectHeaderName, sameHostRedirect),
                new MockResponse(200));

            var pipeline = BuildPipeline(mockTransport);
            var testToken = "Bearer TEST_TOKEN";
            var request = CreateMockRequest(new Uri($"https://{RedirectHost}/QuickPulseService.svc/ping"));
            request.Headers.Add(HttpHeader.Names.Authorization, testToken);

            var message = new HttpMessage(request, new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            // The redirect stays on the same host, so the Authorization header is preserved.
            Assert.True(mockTransport.Requests[1].Headers.TryGetValue(HttpHeader.Names.Authorization, out string? token));
            Assert.Equal(testToken, token);
        }

        [Fact]
        public void VerifyAuthHeaderPreservedOnCachedTrustedRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(200).AddHeader(RedirectHeaderName, RedirectUri),
                new MockResponse(200),
                new MockResponse(200));

            var pipeline = BuildPipeline(mockTransport);

            // First request establishes the cross-host redirect in the policy cache.
            var request1 = CreateMockRequest(new Uri(OriginalUri));
            request1.Headers.Add(HttpHeader.Names.Authorization, "Bearer TEST_TOKEN");
            var message1 = new HttpMessage(request1, new ResponseClassifier());
            pipeline.SendAsync(message1, CancellationToken.None);

            Assert.Equal(RedirectHost, mockTransport.Requests[1].Uri.Host);
            Assert.True(mockTransport.Requests[1].Headers.TryGetValue(HttpHeader.Names.Authorization, out string? firstToken));
            Assert.Equal("Bearer TEST_TOKEN", firstToken);

            // Second request applies the cached trusted redirect.
            var request2 = CreateMockRequest(new Uri(OriginalUri));
            request2.Headers.Add(HttpHeader.Names.Authorization, "Bearer TEST_TOKEN");
            var message2 = new HttpMessage(request2, new ResponseClassifier());
            pipeline.SendAsync(message2, CancellationToken.None);

            Assert.Equal(3, mockTransport.Requests.Count);
            Assert.Equal(RedirectHost, mockTransport.Requests[2].Uri.Host);
            Assert.True(mockTransport.Requests[2].Headers.TryGetValue(HttpHeader.Names.Authorization, out string? secondToken));
            Assert.Equal("Bearer TEST_TOKEN", secondToken);
        }

        [Fact]
        public void RejectsUntrustedRedirectWithoutCachingIt()
        {
            var mockTransport = new MockTransport(
                new MockResponse(200).AddHeader(RedirectHeaderName, "https://attacker.example/QuickPulseService.svc"),
                new MockResponse(200));

            var pipeline = BuildPipeline(mockTransport);
            var firstMessage = new HttpMessage(CreateMockRequest(new Uri(OriginalUri)), new ResponseClassifier());
            pipeline.SendAsync(firstMessage, CancellationToken.None);

            var secondMessage = new HttpMessage(CreateMockRequest(new Uri(OriginalUri)), new ResponseClassifier());
            pipeline.SendAsync(secondMessage, CancellationToken.None);

            Assert.Equal(2, mockTransport.Requests.Count);
            Assert.All(mockTransport.Requests, request => Assert.Equal(new Uri(OriginalUri).Host, request.Uri.Host));
        }

        [Theory]
        [InlineData("http://westus.livediagnostics.monitor.azure.com/QuickPulseService.svc")]
        [InlineData("https://user@westus.livediagnostics.monitor.azure.com/QuickPulseService.svc")]
        [InlineData("https://westus.livediagnostics.monitor.azure.com:444/QuickPulseService.svc")]
        [InlineData("https://westus.livediagnostics.monitor.azure.com.attacker.example/QuickPulseService.svc")]
        [InlineData("not a uri")]
        public void RejectsInvalidRedirectTarget(string redirectUri)
        {
            var mockTransport = new MockTransport(
                new MockResponse(200).AddHeader(RedirectHeaderName, redirectUri),
                new MockResponse(200));

            var pipeline = BuildPipeline(mockTransport);
            var message = new HttpMessage(CreateMockRequest(new Uri(OriginalUri)), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Single(mockTransport.Requests);
        }

        private static HttpPipeline BuildPipeline(MockTransport mockTransport)
        {
            AzureMonitorExporterOptions options = new()
            {
                Transport = mockTransport,
            };

            return HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LiveMetricsRedirectPolicy() });
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
