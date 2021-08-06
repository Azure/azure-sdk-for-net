// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    internal sealed class RedirectPolicy : HttpPipelinePolicy
    {
        private readonly int _maxAutomaticRedirections;

        public static RedirectPolicy Shared { get; } = new RedirectPolicy();

        private RedirectPolicy()
        {
            _maxAutomaticRedirections = 50;
        }

        internal async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            uint redirectCount = 0;
            Uri? redirectUri;

            Request request = message.Request;
            Response response = message.Response;

            while ((redirectUri = GetUriForRedirect(request, message.Response)) != null)
            {
                redirectCount++;

                if (redirectCount > _maxAutomaticRedirections)
                {
                    // If we exceed the maximum number of redirects
                    // then just return the 3xx response.
                    if (AzureCoreEventSource.Singleton.IsEnabled())
                    {
                        AzureCoreEventSource.Singleton.RequestRedirectCountExceeded(request.ClientRequestId, request.Uri.ToString(), redirectUri.ToString());
                    }

                    break;
                }

                response.Dispose();

                // Clear the authorization header.
                request.Headers.Remove(HttpHeader.Names.Authorization);

                if (AzureCoreEventSource.Singleton.IsEnabled())
                {
                    AzureCoreEventSource.Singleton.RequestRedirect(request.ClientRequestId, request.Uri.ToString(), redirectUri.ToString(), response.Status);
                }

                // Set up for the redirect
                request.Uri.Reset(redirectUri);
                if (RequestRequiresForceGet(response.Status, request.Method))
                {
                    request.Method = RequestMethod.Get;
                    request.Content = null;
                }

                // Issue the redirected request.
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }

                response = message.Response;
            }
        }

        private static Uri? GetUriForRedirect(Request request, Response response)
        {
            switch (response.Status)
            {
                case 301:
                case 302:
                case 303:
                case 307:
                case 300:
                case 308:
                    break;

                default:
                    return null;
            }

            if (!response.Headers.TryGetValue("Location", out string? locationString))
            {
                return null;
            }

            Uri location = new Uri(locationString);
            Uri requestUri = request.Uri.ToUri();
            // Ensure the redirect location is an absolute URI.
            if (!location.IsAbsoluteUri)
            {
                location = new Uri(requestUri, location);
            }

            // Per https://tools.ietf.org/html/rfc7231#section-7.1.2, a redirect location without a
            // fragment should inherit the fragment from the original URI.
            string requestFragment = requestUri.Fragment;
            if (!string.IsNullOrEmpty(requestFragment))
            {
                string redirectFragment = location.Fragment;
                if (string.IsNullOrEmpty(redirectFragment))
                {
                    location = new UriBuilder(location) { Fragment = requestFragment }.Uri;
                }
            }

            // Disallow automatic redirection from secure to non-secure schemes
            if (IsSupportedSecureScheme(requestUri.Scheme) && !IsSupportedSecureScheme(location.Scheme))
            {
                if (AzureCoreEventSource.Singleton.IsEnabled())
                {
                    AzureCoreEventSource.Singleton.RequestRedirectBlocked(request.ClientRequestId, requestUri.ToString(), location.ToString());
                }

                return null;
            }

            return location;
        }

        private static bool RequestRequiresForceGet(int statusCode, RequestMethod requestMethod)
        {
            switch (statusCode)
            {
                case 301:
                case 302:
                case 300:
                    return requestMethod == RequestMethod.Post;
                case 303:
                    return requestMethod != RequestMethod.Get && requestMethod != RequestMethod.Head;
                default:
                    return false;
            }
        }

        internal static bool IsSupportedSecureScheme(string scheme) =>
            string.Equals(scheme, "https", StringComparison.OrdinalIgnoreCase) || IsSecureWebSocketScheme(scheme);

        internal static bool IsSecureWebSocketScheme(string scheme) =>
            string.Equals(scheme, "wss", StringComparison.OrdinalIgnoreCase);

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }
    }
}