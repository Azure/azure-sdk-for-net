// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Collections.Generic;
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

        // Bounds the per-endpoint redirect cache in multi-tenant mode.
        internal const int MaxCachedRedirects = 256;

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

            // Materializing the key costs a Uri and a string, so it is deferred until something can
            // use it. A process that never sees a redirect never pays for one.
            string? originKey = null;

            if (!_cache.IsEmpty)
            {
                // Captured before any rewrite, and includes the path: endpoints can differ only by
                // path on a shared gateway host, and the same-host trust branch does not compare paths.
                originKey = request.Uri.ToUri().GetLeftPart(UriPartial.Path);

                if (_cache.TryRead(originKey, out Uri? cachedRedirect)
                    && RedirectPolicyHelper.IsTrustedIngestionRedirect(request.Uri.ToUri(), cachedRedirect))
                {
                    // Set up for the redirect
                    request.Uri.Reset(cachedRedirect);
                }
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
            Uri? redirectUri;

            while (redirectCount < MaxRedirect && IsRedirection(response.Status))
            {
                // Nothing has rewritten the address yet on this pass, so this is still the origin.
                originKey ??= request.Uri.ToUri().GetLeftPart(UriPartial.Path);

                if (!TryGetRedirectUri(response, out redirectUri))
                {
                    AzureMonitorExporterEventSource.Log.RedirectHeaderParseFailed();
                    break;
                }

                if (!RedirectPolicyHelper.IsTrustedIngestionRedirect(request.Uri.ToUri(), redirectUri))
                {
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

                // Only a target that answered is worth remembering. Caching one that failed pins
                // every later request for this endpoint to a destination known not to work, for the
                // full cache lifetime, with nothing to invalidate it: the replayed request is not a
                // redirect, so this loop never runs again to correct it.
                if (!IsRedirection(response.Status) && response.Status >= 400)
                {
                    break;
                }

                _cache.Set(originKey, redirectUri, cacheExpirationDuration);

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
        /// Keyed by the endpoint the redirect was learned for. A single pipeline serves every
        /// ingestion endpoint in multi-tenant mode, so an unkeyed cache would let one region's
        /// redirect rewrite another region's request.
        /// </summary>
        private class Cache<T>
        {
            private readonly object _lockObj = new object();

            private readonly Dictionary<string, Entry> _entries = new(StringComparer.Ordinal);

            private volatile int _count;

            /// <summary>
            /// Read without the lock so the common case, a pipeline that has never been redirected,
            /// does not synchronize on every request.
            /// </summary>
            public bool IsEmpty => _count == 0;

            public bool TryRead(string key, [NotNullWhen(true)] out T? cachedValue)
            {
                lock (_lockObj)
                {
                    if (_entries.TryGetValue(key, out var entry))
                    {
                        if (DateTimeOffset.UtcNow < entry.Expiration && entry.Value != null)
                        {
                            cachedValue = entry.Value;
                            return true;
                        }

                        // Frees the slot: otherwise a process that has seen the maximum number of
                        // origins stops caching redirects for the rest of its life.
                        _entries.Remove(key);
                        _count = _entries.Count;
                    }
                }

                cachedValue = default;
                return false;
            }

            public void Set(string key, T cachingValue, TimeSpan expire)
            {
                lock (_lockObj)
                {
                    // Bounded so a caller routing to many endpoints cannot grow this without limit.
                    if (_entries.Count >= MaxCachedRedirects && !_entries.ContainsKey(key))
                    {
                        return;
                    }

                    _entries[key] = new Entry(cachingValue, DateTimeOffset.UtcNow.Add(expire));
                    _count = _entries.Count;
                }
            }

            private readonly struct Entry
            {
                internal Entry(T value, DateTimeOffset expiration)
                {
                    Value = value;
                    Expiration = expiration;
                }

                internal T Value { get; }

                internal DateTimeOffset Expiration { get; }
            }
        }
    }
}
