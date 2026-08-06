// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Core.TestFramework
{
    /// <summary>
    /// A <see cref="MockTransport"/> that automatically handles IMDS probe requests.
    /// When a probe request (no Metadata header) receives a token-payload response,
    /// it returns a synthetic IMDS 400 probe response and defers the token payload
    /// to the next request.
    /// </summary>
    public class MockImdsManagedIdentityTransport : MockTransport
    {
        private readonly object _imdsSyncObj = new object();
        private MockResponse _deferredResponse;

        private const string ImdsTokenPath = "/metadata/identity/oauth2/token";
        private const string MetadataHeaderName = "Metadata";

        public MockImdsManagedIdentityTransport(params MockResponse[] responses) : base(responses)
        {
        }

        public MockImdsManagedIdentityTransport(Func<MockRequest, MockResponse> responseFactory) : base(responseFactory)
        {
        }

        protected override async Task<MockResponse> GetNextResponseAsync(MockRequest request, HttpMessage message)
        {
            lock (_imdsSyncObj)
            {
                if (_deferredResponse != null)
                {
                    MockResponse deferred = _deferredResponse;
                    _deferredResponse = null;
                    return deferred;
                }
            }

            MockResponse response = await base.GetNextResponseAsync(request, message).ConfigureAwait(false);

            if (IsImdsProbeRequest(request) && LooksLikeManagedIdentityTokenResponse(response))
            {
                lock (_imdsSyncObj)
                {
                    _deferredResponse = response;
                }
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
    }
}
