// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.TestFramework
{
    public class MockTransport : HttpPipelineTransport
    {
        private readonly object _syncObj = new object();
        private readonly Func<HttpMessage, MockResponse> _responseFactory;
        private MockResponse _deferredResponse;

        private const string ImdsTokenPath = "/metadata/identity/oauth2/token";
        private const string MetadataHeaderName = "Metadata";

        public AsyncGate<MockRequest, MockResponse> RequestGate { get; }

        public List<MockRequest> Requests { get; } = new List<MockRequest>();

        public bool? ExpectSyncPipeline { get; set; }

        // Opt-in helper for MI tests: if a probe request gets a token payload response,
        // return an IMDS probe response and defer the token payload to the next request.
        public bool AutoHandleImdsProbeRequests { get; set; }

        public List<HttpPipelineTransportOptions> TransportUpdates { get; } = [];

        public MockTransport()
        {
            RequestGate = new AsyncGate<MockRequest, MockResponse>();
        }

        public MockTransport(params MockResponse[] responses)
        {
            var requestIndex = 0;
            _responseFactory = _ =>
            {
                lock (_syncObj)
                {
                    return responses[requestIndex++];
                }
            };
        }

        public MockTransport(Func<MockRequest, MockResponse> responseFactory) : this(req => responseFactory((MockRequest)req.Request))
        {
        }

        private MockTransport(Func<HttpMessage, MockResponse> responseFactory)
        {
            _responseFactory = responseFactory;
        }

        public static MockTransport FromMessageCallback(Func<HttpMessage, MockResponse> responseFactory) => new MockTransport(responseFactory);

        public override Request CreateRequest()
            => new MockRequest();

        public override void Process(HttpMessage message)
        {
            if (ExpectSyncPipeline == false)
            {
                throw new InvalidOperationException("Sync pipeline invocation not expected");
            }

            ProcessCore(message).GetAwaiter().GetResult();
        }

        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            if (ExpectSyncPipeline == true)
            {
                throw new InvalidOperationException("Async pipeline invocation not expected");
            }

            await ProcessCore(message);
        }

        public override void Update(HttpPipelineTransportOptions options)
        {
            TransportUpdates.Add(options);
        }

        private async Task ProcessCore(HttpMessage message)
        {
            if (!(message.Request is MockRequest request))
                throw new InvalidOperationException("the request is not compatible with the transport");

            message.Response = null;

            lock (_syncObj)
            {
                Requests.Add(request);
            }

            message.Response = await GetNextResponseAsync(request, message).ConfigureAwait(false);

            message.Response.ClientRequestId = request.ClientRequestId;

            if (message.Response.ContentStream != null && ExpectSyncPipeline != null)
            {
                message.Response.ContentStream = new AsyncValidatingStream(!ExpectSyncPipeline.Value, message.Response.ContentStream);
            }
        }

        private async Task<MockResponse> GetNextResponseAsync(MockRequest request, HttpMessage message)
        {
            if (_deferredResponse != null)
            {
                MockResponse deferred = _deferredResponse;
                _deferredResponse = null;
                return deferred;
            }

            MockResponse response;
            if (RequestGate != null)
            {
                response = await RequestGate.WaitForRelease(request).ConfigureAwait(false);
            }
            else
            {
                response = _responseFactory(message);
            }

            if (AutoHandleImdsProbeRequests && IsImdsProbeRequest(request) && LooksLikeManagedIdentityTokenResponse(response))
            {
                _deferredResponse = response;
                return CreateImdsProbeResponse();
            }

            return response;
        }

        private static bool IsImdsProbeRequest(MockRequest request)
            => request.Uri.Path == ImdsTokenPath &&
               !request.Headers.TryGetValue(MetadataHeaderName, out _);

        private static bool LooksLikeManagedIdentityTokenResponse(MockResponse response)
            => response.Status == 200 &&
               response.Content?.ToString()?.IndexOf("\"access_token\"", StringComparison.OrdinalIgnoreCase) >= 0;

        private static MockResponse CreateImdsProbeResponse()
            => new MockResponse(400).WithJson("{\"error\":\"invalid_request\",\"error_description\":\"Required metadata header not specified\"}");

        public MockRequest SingleRequest
        {
            get
            {
                lock (_syncObj)
                {
                    return Requests.Single();
                }
            }
        }
    }
}
