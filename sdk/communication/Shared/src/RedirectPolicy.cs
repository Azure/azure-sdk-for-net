// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Pipeline
{
    internal class RedirectPolicy : HttpPipelinePolicy
    {
        private const string LOCATION_HEADER_STRING = "LOCATION";
        private readonly int maxRedirects;

        public RedirectPolicy(int maxRedirects = 10)
        {
            this.maxRedirects = maxRedirects;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            var redirectCount = 0;

            while (true)
            {
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }

                if (!IsRedirectResponse(message))
                {
                    // Request does not require a redirect, continue
                    // up the policy pipeline.
                    return;
                }

                if (!TryGetRedirect(message, out Uri location))
                {
                    throw new MissingFieldException("Location header was not retrieved from the redirect response, or URL was invalid.");
                }

                if (++redirectCount > maxRedirects)
                {
                    throw new RequestFailedException("Maximum number of redirections exceeded.");
                }

                message.Request.Uri.Reset(location);
            }
        }

        private static bool IsRedirectResponse(HttpMessage message)
        {
            if (message is null || !message.HasResponse)
            {
                return false;
            }

            switch ((HttpStatusCode)message.Response.Status)
            {
                case HttpStatusCode.Moved:
                case HttpStatusCode.Found:
                    return true;
                default:
                    return false;
            }
        }

        private static bool TryGetRedirect(HttpMessage message, out Uri location)
        {
            location = default;

            if (!message.Response.Headers.TryGetValue(LOCATION_HEADER_STRING, out string locationHeader))
            {
                return false;
            }

            return Uri.TryCreate(locationHeader, UriKind.Absolute, out location);
        }
    }
}