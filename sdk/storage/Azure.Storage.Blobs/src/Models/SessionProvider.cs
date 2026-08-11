// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Provides and caches session tokens used to authenticate eligible blob requests.
    /// <para>
    /// A <see cref="SessionProvider"/> owns the session cache and the machinery used to
    /// mint sessions. It can be shared across multiple clients (via
    /// <see cref="SessionOptions.SessionProvider"/>) so that independently created clients
    /// reuse a single cache instead of each creating their own, avoiding redundant
    /// create-session requests.
    /// </para>
    /// <para>
    /// This type has a closed hierarchy: it can be referenced but not derived from outside
    /// of the SDK. Use <see cref="ContainerSessionProvider"/> for token-credential based sessions.
    /// </para>
    /// </summary>
    public abstract class SessionProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionProvider"/> class.
        /// </summary>
        private protected SessionProvider()
        {
        }

        /// <summary>
        /// Returns a cached session token scoped to the given request, acquiring one on
        /// first access. The returned value may be a fallback-to-bearer sentinel
        /// (<see cref="SessionTokenInfo.IsFallbackToBearer"/>).
        /// </summary>
        internal abstract ValueTask<SessionTokenInfo> GetSessionAsync(HttpMessage message, bool async);

        /// <summary>
        /// Invalidates the cached session scoped to the given request, but only if the cache
        /// still holds <paramref name="current"/> (avoids clobbering a newer, concurrently
        /// refreshed value). The next request re-acquires a fresh session.
        /// </summary>
        internal abstract void InvalidateSession(HttpMessage message, SessionTokenInfo current);

        /// <summary>
        /// Determines whether the given request is eligible for session-token authentication.
        /// Eligibility rules are specific to the authentication scheme of the provider.
        /// </summary>
        internal abstract bool IsRequestEligible(HttpMessage message);

        /// <summary>
        /// Cached session token information returned by the Create Session API, or a
        /// fallback-to-bearer sentinel when a session could not be acquired due to a
        /// fallback-eligible error.
        /// </summary>
        internal readonly struct SessionTokenInfo : IExpiringValue, IEquatable<SessionTokenInfo>
        {
            public string SessionToken { get; }
            public string SessionKey { get; }
            public DateTimeOffset ExpiresOn { get; }
            public DateTimeOffset RefreshOn { get; }

            /// <summary>
            /// When true, this instance is a sentinel indicating that callers
            /// should fall back to bearer authentication for the duration of the cached
            /// entry. <see cref="SessionToken"/> and <see cref="SessionKey"/> are null
            /// in this state and must not be used to sign requests.
            /// </summary>
            public bool IsFallbackToBearer { get; }

            public SessionTokenInfo(
                string sessionToken,
                string sessionKey,
                DateTimeOffset expiresOn,
                DateTimeOffset refreshOn,
                bool isFallbackToBearer)
            {
                SessionToken = sessionToken;
                SessionKey = sessionKey;
                ExpiresOn = expiresOn;
                RefreshOn = refreshOn;
                IsFallbackToBearer = isFallbackToBearer;
            }

            /// <summary>
            /// Creates a sentinel value that signals callers to fall back to bearer
            /// authentication. The sentinel is treated as a normal cached value by
            /// <see cref="AutoRefreshingCache{TValue}"/> and expires after
            /// <paramref name="cooldown"/>. It intentionally has no refresh buffer
            /// (<see cref="RefreshOn"/> equals <see cref="ExpiresOn"/>) so the fallback is
            /// honored for the full cooldown with no early background re-acquisition; a
            /// single foreground re-acquire occurs at expiry.
            /// </summary>
            public static SessionTokenInfo CreateFallbackToBearer(TimeSpan cooldown)
            {
                DateTimeOffset expiresOn = DateTimeOffset.UtcNow + cooldown;
                return new SessionTokenInfo(
                    sessionToken: null,
                    sessionKey: null,
                    expiresOn: expiresOn,
                    refreshOn: expiresOn,
                    isFallbackToBearer: true);
            }

            public IExpiringValue WithRefreshOn(DateTimeOffset refreshOn) =>
                new SessionTokenInfo(SessionToken, SessionKey, ExpiresOn, refreshOn, IsFallbackToBearer);

            public bool Equals(SessionTokenInfo other) =>
                string.Equals(SessionToken, other.SessionToken);
        }
    }
}
