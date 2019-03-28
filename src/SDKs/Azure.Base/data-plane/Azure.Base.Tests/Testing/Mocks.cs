// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using System;
using System.Threading.Tasks;
using Azure.Base.Tests;
using Azure.Base.Tests.Testing;

namespace Azure.Base.Testing
{
    public class MockTransport : HttpPipelineTransport
    {
        private readonly Func<MockRequest, MockResponse> _responseFactory;

        public AsyncGate<MockRequest, MockResponse> RequestGate { get; }

        public MockTransport()
        {
            RequestGate = new AsyncGate<MockRequest, MockResponse>();
        }

        public MockTransport(params MockResponse[] responses)
        {
            var requestIndex = 0;
            _responseFactory = req => responses[requestIndex++];
        }

        public MockTransport(Func<MockRequest, MockResponse> responseFactory)
        {
            _responseFactory = responseFactory;
        }

        public override HttpPipelineRequest CreateRequest(IServiceProvider services)
            => new MockRequest();

        public override async Task ProcessAsync(HttpPipelineMessage message)
        {
            var request = message.Request as MockRequest;
            if (request == null) throw new InvalidOperationException("the request is not compatible with the transport");

            if (RequestGate != null)
            {
                message.Response = await RequestGate.WaitForRelease(request);
            }
            else
            {
                message.Response = _responseFactory(request);
            }
        }
    }
}
