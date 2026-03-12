// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// An <see cref="HttpPipelinePolicy"/> that follows HTTP 307 and 308 redirect responses
    /// while preserving the Authorization header.
    /// </summary>
    /// <remarks>
    /// Code Transparency Service nodes may return 307 (Temporary Redirect) or 308 (Permanent Redirect)
    /// responses to route write operations to the primary node. The standard redirect behavior in .NET
    /// strips the Authorization header on cross-domain redirects for security reasons. However, CTS
    /// redirects occur between trusted nodes within the same ledger, so the Authorization header must
    /// be preserved for the redirected request to succeed.
    /// </remarks>
    internal sealed class CodeTransparencyRedirectPolicy : HttpPipelinePolicy
    {
        private const int MaxRedirects = 5;

        /// <inheritdoc/>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        /// <inheritdoc/>
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            int redirectCount = 0;

            while (IsRedirectResponse(message.Response.Status))
            {
                if (++redirectCount > MaxRedirects)
                {
                    // Too many redirects; return the last redirect response as-is.
                    break;
                }

                if (!message.Response.Headers.TryGetValue("Location", out string location))
                {
                    // No Location header; return the redirect response as-is.
                    break;
                }

                Uri redirectUri = BuildRedirectUri(message.Request.Uri.ToUri(), location);

                // Disallow redirect from HTTPS to HTTP.
                if (string.Equals(message.Request.Uri.Scheme, "https", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(redirectUri.Scheme, "https", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Update the request URI to the redirect target.
                // The Authorization header is intentionally preserved because CTS redirects
                // are between trusted nodes within the same ledger.
                message.Request.Uri.Reset(redirectUri);

                // Dispose of the redirect response before re-sending.
                message.Response.Dispose();

                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
            }
        }

        private static bool IsRedirectResponse(int statusCode)
        {
            return statusCode == 307 || statusCode == 308;
        }

        private static Uri BuildRedirectUri(Uri requestUri, string location)
        {
            Uri redirectUri = new Uri(location, UriKind.RelativeOrAbsolute);

            if (!redirectUri.IsAbsoluteUri)
            {
                redirectUri = new Uri(requestUri, redirectUri);
            }

            return redirectUri;
        }
    }
}
