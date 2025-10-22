// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests
{
    public class LiveMetricsRedirectPolicyTests
    {
        [Fact]
        public void VerifyLiveMetricsRedirectPolicyReadsHeader()
        {
            var mockTransport = new MockTransport(new MockResponse(200).AddHeader("x-ms-qps-service-endpoint-redirect-v2", "http://new.host/Service.svc"));

            var options = new AzureMonitorLiveMetricsOptions
            {
                Transport = mockTransport
            };

            var pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LiveMetricsRedirectPolicy() });
            var message = new HttpMessage(CreateMockRequest(new Uri("http://host1/Service.svc?key=value")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal("http://new.host/Service.svc?key=value", mockTransport.Requests[1].Uri.ToString());
            Assert.Equal(2, mockTransport.Requests.Count);

            // Verify Redirect is cached.
            message = new HttpMessage(CreateMockRequest(new Uri("http://host2/Service.svc?key=value")), new ResponseClassifier());
            pipeline.SendAsync(message, CancellationToken.None);

            Assert.Equal(3, mockTransport.Requests.Count);
            Assert.Equal("http://new.host/Service.svc?key=value", mockTransport.Requests[2].Uri.ToString());
        }

        private static MockRequest CreateMockRequest(Uri uri)
        {
            MockRequest mockRequest = new();
            mockRequest.Uri.Reset(uri);
            mockRequest.Method = RequestMethod.Get;
            return mockRequest;
        }
    }
}
