// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;
using System.Net.Http.Headers;
using System.Diagnostics.CodeAnalysis;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class IngestionRedirectPolicy : HttpPipelinePolicy
    {
        // To prevent circular redirects, max redirect is set to 10.
        internal const int MaxRedirect = 10;
        internal readonly TimeSpan _defaultCacheExpirationDuration = TimeSpan.FromHours(12);

        private readonly Cache<Uri> _cache = new Cache<Uri>();

        internal async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.TryGetProperty("redirectionComplete", out object? objValue)
                && objValue != null
                && objValue is bool isComplete
                && isComplete)
            {
                return;
            }

            Request request = message.Request;

            if (_cache.TryRead(out Uri? redirectUri))
            {
                // Set up for the redirect
                request.Uri.Reset(redirectUri);
            }

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            uint redirectCount = 1;
            Response response = message.Response;

            while (redirectCount < MaxRedirect && IsRedirection(response.Status))
            {
                if (!TryGetRedirectUri(response, out redirectUri))
                {
                    AzureMonitorExporterEventSource.Log.RedirectHeaderParseFailed();
                    break;
                }

                response.Dispose();

                // Set up for the redirect
                request.Uri.Reset(redirectUri);

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

                if (!TryGetRedirectCacheTimeSpan(response, out TimeSpan cacheExpirationDuration))
                {
                    // if failed to read cache, use default
                    AzureMonitorExporterEventSource.Log.ParseRedirectCacheFailed();
                    cacheExpirationDuration = _defaultCacheExpirationDuration;
                }

                _cache.Set(redirectUri, cacheExpirationDuration);

                redirectCount++;
            }

            message.SetProperty("redirectionComplete", true);
            return;
        }

        private static bool TryGetRedirectUri(Response response, [NotNullWhen(true)] out Uri? redirectUri)
        {
            response.Headers.TryGetValue("Location", out string? locationString);
            return Uri.TryCreate(locationString, UriKind.Absolute, out redirectUri);
        }

        private static bool TryGetRedirectCacheTimeSpan(Response response, out TimeSpan cacheExpirationDuration)
        {
            cacheExpirationDuration = default;

            response.Headers.TryGetValue("Cache-Control", out string? cacheControlHeader);
            if (CacheControlHeaderValue.TryParse(cacheControlHeader, out CacheControlHeaderValue? cacheControlHeaderValue))
            {
                cacheExpirationDuration = cacheControlHeaderValue?.MaxAge ?? default;
            }

            return cacheExpirationDuration != default;
        }

        private static bool IsRedirection(int status)
        {
            switch (status)
            {
                case 307: // StatusCodes.Status307TemporaryRedirect
                case 308: // StatusCodes.Status308PermanentRedirect
                    return true;
                default:
                    return false;
            }
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        /// <summary>
        /// Simple class to encapsulate redirect cache.
        /// </summary>
        private class Cache<T>
        {
            private readonly object _lockObj = new object();

            private T? _cachedValue;

            private DateTimeOffset _expiration = DateTimeOffset.MinValue;

            public bool TryRead([NotNullWhen(true)] out T? cachedValue)
            {
                if (DateTimeOffset.UtcNow < _expiration && _cachedValue != null)
                {
                    cachedValue = _cachedValue;
                    return true;
                }
                else
                {
                    cachedValue = default;
                    return false;
                }
            }

            public void Set(T cachingValue, TimeSpan expire)
            {
                lock (_lockObj)
                {
                    _cachedValue = cachingValue;
                    _expiration = DateTimeOffset.UtcNow.Add(expire);
                }
            }
        }
    }
}
