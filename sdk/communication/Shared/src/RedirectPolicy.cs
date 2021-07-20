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
            var redirectCount = 0;

            while (true)
            {
                ProcessNext(message, pipeline);

                if (!TryGetRedirect(message, out Uri location))
                {
                    break;
                }

                if (++redirectCount > maxRedirects)
                {
                    break;
                }

                message.Request.Uri.Reset(location);
            }
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            var redirectCount = 0;

            while (true)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);

                if (!TryGetRedirect(message, out Uri location))
                {
                    break;
                }

                if (++redirectCount > maxRedirects)
                {
                    break;
                }

                message.Request.Uri.Reset(location);
            }
        }

        private static bool TryGetRedirect(HttpMessage message, out Uri location)
        {
            location = default;

            if (message is null || !message.HasResponse)
            {
                return false;
            }

            switch ((HttpStatusCode)message.Response.Status)
            {
                case HttpStatusCode.Moved:
                case HttpStatusCode.Found:
                    break;
                default:
                    return false;
            }

            if (!message.Response.Headers.TryGetValue(LOCATION_HEADER_STRING, out string locationHeader))
            {
                return false;
            }

            return Uri.TryCreate(locationHeader, UriKind.Absolute, out location);
        }
    }
}