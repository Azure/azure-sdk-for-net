// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Args setnt to TokenCache OnBefore and OnAfter events.
    /// </summary>
    public class TokenCacheRefreshArgs
    {
        /// <summary>
        /// A suggested token cache key, which can be used with general purpose storage mechanisms that allow
        /// storing key-value pairs and key based retrieval. Useful in applications that store 1 token cache per user,
        /// the recommended pattern for web apps.
        ///
        /// The value is:
        ///
        /// <list type="bullet">
        /// <item>the homeAccountId for AcquireTokenSilent, GetAccount(homeAccountId), RemoveAccount and when writing tokens on confidential client calls</item>
        /// <item>clientID + "_AppTokenCache" for AcquireTokenForClient</item>
        /// <item>clientID_tenantID + "_AppTokenCache" for AcquireTokenForClient when tenant specific authority</item>
        /// <item>the hash of the original token for AcquireTokenOnBehalfOf</item>
        /// </list>
        /// </summary>
        public string SuggestedCacheKey { get; }

        internal TokenCacheRefreshArgs(TokenCacheNotificationArgs args)
        {
            SuggestedCacheKey = args.SuggestedCacheKey;
        }
    }
}
