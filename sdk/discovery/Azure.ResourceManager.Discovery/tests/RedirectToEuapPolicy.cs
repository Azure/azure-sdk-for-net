// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// HTTP pipeline policy that redirects all requests to the EUAP endpoint.
    /// This is required because the Discovery API 2026-02-01-preview is only available
    /// in the EUAP environment, but the SDK may route requests based on resource location.
    /// </summary>
    internal class RedirectToEuapPolicy : HttpPipelinePolicy
    {
        private readonly string _euapHost;

        public RedirectToEuapPolicy(string euapHost)
        {
            _euapHost = euapHost;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            RedirectRequest(message);
            ProcessNext(message, pipeline);
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            RedirectRequest(message);
            return ProcessNextAsync(message, pipeline);
        }

        private void RedirectRequest(HttpMessage message)
        {
            var request = message.Request;
            var uri = request.Uri;

            // Replace any management.azure.com host with EUAP endpoint
            if (uri.Host == "management.azure.com" || uri.Host.EndsWith(".management.azure.com"))
            {
                var builder = new UriBuilder(uri.ToUri())
                {
                    Host = _euapHost
                };
                request.Uri.Reset(builder.Uri);
            }
        }
    }
}
