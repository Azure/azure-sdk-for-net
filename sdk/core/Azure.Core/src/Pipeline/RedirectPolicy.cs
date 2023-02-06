// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A pipeline policy that detects a redirect response code and resends the request to the
    /// location specified by the response.
    /// </summary>
    public sealed class RedirectPolicy : HttpPipelinePolicy
    {
        private readonly int _maxAutomaticRedirections;
        private readonly bool _allowAutoRedirect = true;

        internal static RedirectPolicy Shared { get; } = new RedirectPolicy();

        private RedirectPolicy()
        {
            _maxAutomaticRedirections = 50;
        }

        /// <summary>
        /// Sets a value that indicates whether redirects will be automatically followed for this message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="allowAutoRedirect"></param>
        public static void SetAllowAutoRedirect(HttpMessage message, bool allowAutoRedirect)
        {
            message.SetProperty(typeof(AllowRedirectsValueKey), allowAutoRedirect);
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

            if (!AllowAutoRedirect(message))
            {
                return;
            }

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

                if (AzureCoreEventSource.Singleton.IsEnabledVerbose())
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

            if (!TryParseValue(locationString, out Uri? location))
            {
                return null;
            }

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

        /// <inheritdoc/>
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        /// <inheritdoc/>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        private static bool TryParseValue([NotNullWhen(true)] string? value, [NotNullWhen(true)] out Uri? parsedValue)
        {
            parsedValue = null;

            // Some headers support empty/null values. This one doesn't.
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            string uriString = value!;
            if (!Uri.TryCreate(uriString, UriKind.RelativeOrAbsolute, out Uri? uri))
            {
                // Some servers send the host names in Utf-8.
                uriString = DecodeUtf8FromString(uriString);

                if (!Uri.TryCreate(uriString, UriKind.RelativeOrAbsolute, out uri))
                {
                    return false;
                }
            }

            parsedValue = uri;
            return true;
        }

        // The normal client header parser just casts bytes to chars (see GetString).
        // Check if those bytes were actually utf-8 instead of ASCII.
        // If not, just return the input value.
        private static string DecodeUtf8FromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            bool possibleUtf8 = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > (char)255)
                {
                    return input; // This couldn't have come from the wire, someone assigned it directly.
                }
                else if (input[i] > (char)127)
                {
                    possibleUtf8 = true;
                    break;
                }
            }
            if (possibleUtf8)
            {
                byte[] rawBytes = new byte[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] > (char)255)
                    {
                        return input; // This couldn't have come from the wire, someone assigned it directly.
                    }
                    rawBytes[i] = (byte)input[i];
                }
                try
                {
                    // We don't want '?' replacement characters, just fail.
                    System.Text.Encoding decoder = System.Text.Encoding.GetEncoding("utf-8", System.Text.EncoderFallback.ExceptionFallback,
                        System.Text.DecoderFallback.ExceptionFallback);
                    return decoder.GetString(rawBytes, 0, rawBytes.Length);
                }
                catch (ArgumentException) { } // Not actually Utf-8
            }
            return input;
        }

        private bool AllowAutoRedirect(HttpMessage message)
        {
            if (message.TryGetProperty(typeof(AllowRedirectsValueKey), out object? value))
            {
                return (bool)value!;
            }

            return _allowAutoRedirect;
        }

        private class AllowRedirectsValueKey { }
    }
}
