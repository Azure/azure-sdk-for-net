// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using System;
using System.Threading.Tasks;

namespace Azure.Base.Testing
{
    public class MockTransport : HttpPipelineTransport
    {
        private readonly Func<MockRequest, MockResponse> _responseFactory;

        public MockTransport(Func<MockRequest, MockResponse> responseFactory)
        {
            _responseFactory = responseFactory;
        }

        public override HttpPipelineRequest CreateRequest(IServiceProvider services)
            => new MockRequest();

        public override Task ProcessAsync(HttpPipelineMessage message)
        {
            var request = message.Request as MockRequest;
            if (request == null) throw new InvalidOperationException("the request is not compatible with the transport");

            message.Response = _responseFactory(request);

            return Task.CompletedTask;
        }
    }
}
