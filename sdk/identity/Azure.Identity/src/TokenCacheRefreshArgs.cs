// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Args sent to TokenCache OnBefore and OnAfter events.
    /// </summary>
    public class TokenCacheRefreshArgs
    {
        /// <summary>
        /// A suggested token cache key, which can be used with general purpose storage mechanisms that allow
        /// storing key-value pairs and key based retrieval. Useful in applications that store one token cache per user,
        /// the recommended pattern for web apps.
        ///
        /// The value is:
        ///
        /// <list type="bullet">
        /// <item><description><c>homeAccountId</c> for <c>AcquireTokenSilent</c>, <c>GetAccount(homeAccountId)</c>, <c>RemoveAccount</c> and when writing tokens on confidential client calls</description></item>
        /// <item><description><c>"{clientId}__AppTokenCache"</c> for <c>AcquireTokenForClient</c></description></item>
        /// <item><description><c>"{clientId}_{tenantId}_AppTokenCache"</c> for <c>AcquireTokenForClient</c> when using a tenant specific authority</description></item>
        /// <item><description>the hash of the original token for <c>AcquireTokenOnBehalfOf</c></description></item>
        /// </list>
        /// </summary>
        public string SuggestedCacheKey { get; }

        /// <summary>
        /// Whether or not the cache is enabled for CAE. Note that this value should be used as an indicator for how the cache will be partitioned.
        /// Token cache refresh events with this value set to `true` will originate from a different cache instance than those with this value set to `false`.
        /// </summary>
        public bool IsCaeEnabled { get; }

        internal TokenCacheRefreshArgs(TokenCacheNotificationArgs args, bool enableCae)
        {
            SuggestedCacheKey = args.SuggestedCacheKey;
            IsCaeEnabled = enableCae;
        }
    }
}
