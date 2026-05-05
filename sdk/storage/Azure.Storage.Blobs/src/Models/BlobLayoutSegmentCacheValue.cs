// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Cache entry wrapping a snapshot of <see cref="BlobLayoutSegment"/>s returned by
    /// GetLayout, along with the expiry metadata required by
    /// <see cref="AutoRefreshingCache{TValue}"/>.
    /// Layout responses become stale on the service side after roughly 5 minutes,
    /// so the cache proactively refreshes shortly before that.
    /// </summary>
    internal readonly struct BlobLayoutSegmentCacheValue
        : IExpiringValue, IEquatable<BlobLayoutSegmentCacheValue>
    {
        /// <summary>
        /// Server-side layout TTL.
        /// </summary>
        public static readonly TimeSpan LayoutLifetime = TimeSpan.FromMinutes(5);

        /// <summary>
        /// How long before <see cref="ExpiresOn"/> a background refresh should be initiated.
        /// </summary>
        public static readonly TimeSpan RefreshBuffer = TimeSpan.FromSeconds(30);

        /// <summary>
        /// The cached layout segments. Non-empty when locality routing applies.
        /// Empty when the service returned no layout (HTTP 204); cached for the full TTL.
        /// Null on a soft GetLayout failure (400/5xx); also cached for the full TTL so
        /// the rest of the download avoids re-hitting a known-bad layout endpoint.
        /// In all non-routing cases, consumers fall back to the original endpoint.
        /// </summary>
        public BlobLayoutSegment[] Segments { get; }

        /// <inheritdoc/>
        public DateTimeOffset ExpiresOn { get; }

        /// <inheritdoc/>
        public DateTimeOffset RefreshOn { get; }

        public BlobLayoutSegmentCacheValue(BlobLayoutSegment[] segments)
        {
            Segments = segments;
            DateTimeOffset now = DateTimeOffset.UtcNow;

            // Cache for the full TTL in all cases:
            //   - Success (segments populated): valid layout, valid for the service-side TTL.
            //   - 204 (empty segment array): service explicitly says no layout.
            //   - Soft failure (null): treat as "no locality available for this blob right
            //     now" and avoid hammering a degraded layout endpoint for the full TTL.
            ExpiresOn = now + LayoutLifetime;
            RefreshOn = ExpiresOn - RefreshBuffer;
        }

        private BlobLayoutSegmentCacheValue(
            BlobLayoutSegment[] segments,
            DateTimeOffset refreshOn,
            DateTimeOffset expiresOn)
        {
            Segments = segments;
            RefreshOn = refreshOn;
            ExpiresOn = expiresOn;
        }

        /// <inheritdoc/>
        public IExpiringValue WithRefreshOn(DateTimeOffset refreshOn)
            => new BlobLayoutSegmentCacheValue(Segments, refreshOn, ExpiresOn);

        public bool Equals(BlobLayoutSegmentCacheValue other)
            => ReferenceEquals(Segments, other.Segments)
               && ExpiresOn == other.ExpiresOn
               && RefreshOn == other.RefreshOn;
    }
}
