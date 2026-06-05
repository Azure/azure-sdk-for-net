// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Core.Tests.Identity.Mock
{
    /// <summary>
    /// A delegating <see cref="HttpPipelineTransport"/> that intercepts MSAL's ImdsV2
    /// source-detection probe (the <c>/metadata/identity/getplatformmetadata</c> CSR
    /// metadata request) and answers it locally with a non-success response so MSAL falls
    /// back to the plain IMDS source. All other requests are forwarded to the wrapped
    /// transport unchanged.
    ///
    /// This is required because <see cref="Azure.Core.MsalManagedIdentityClient"/> now routes
    /// the source-detection probe through the configured <see cref="HttpPipelineClientFactory"/>
    /// (so it is observable/mockable). Tests that construct a real managed identity client
    /// (the ConfigurableCredentials path) would otherwise see the probe as the first request on
    /// their inner <see cref="MockTransport"/>, shifting the token request to index 1 and
    /// breaking assertions that expect the token request first. Intercepting the probe keeps the
    /// inner transport's request queue limited to the actual token requests, exactly as it was
    /// before the probe was made observable.
    /// </summary>
    internal sealed class ProbeInterceptingTransport : HttpPipelineTransport
    {
        // The ImdsV2 CSR-metadata (source-detection) probe endpoint path segment.
        private const string ProbePathSegment = "getplatformmetadata";

        private readonly HttpPipelineTransport _inner;
        private int _probeCount;

        public ProbeInterceptingTransport(HttpPipelineTransport inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// The number of ImdsV2 source-detection probe requests that were intercepted.
        /// </summary>
        public int ProbeCount => _probeCount;

        public override Request CreateRequest() => _inner.CreateRequest();

        public override void Process(HttpMessage message)
        {
            if (TryHandleProbe(message))
            {
                return;
            }

            _inner.Process(message);
        }

        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            if (TryHandleProbe(message))
            {
                return;
            }

            await _inner.ProcessAsync(message).ConfigureAwait(false);
        }

        public override void Update(HttpPipelineTransportOptions options) => _inner.Update(options);

        private bool TryHandleProbe(HttpMessage message)
        {
            string path = message.Request?.Uri?.Path;
            if (path == null || path.IndexOf(ProbePathSegment, System.StringComparison.OrdinalIgnoreCase) < 0)
            {
                return false;
            }

            Interlocked.Increment(ref _probeCount);

            // Answer the ImdsV2 probe with a 400 so MSAL concludes that ImdsV2 is not
            // available on this host and falls back to the plain IMDS source. The response is
            // produced locally and the wrapped transport never sees it, so its request queue
            // is unaffected.
            var response = new MockResponse(400);
            response.SetContent("{\"error\":\"imds_v2_unavailable\"}");
            response.ClientRequestId = message.Request.ClientRequestId;
            message.Response = response;
            return true;
        }
    }
}
