// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Communication
{
    /// <summary>
    /// The Communication Token Refresh Options
    /// </summary>
    public class CommunicationTokenRefreshOptions
    {
        internal bool RefreshProactively { get; }
        internal Func<CancellationToken, string> TokenRefresher { get; }

        /// <summary>The initial token.</summary>
        public string InitialToken { get; set; }

        /// <summary>The token refresher.</summary>
        public Func<CancellationToken, ValueTask<string>> AsyncTokenRefresher { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationTokenRefreshOptions"/>.
        /// </summary>
        /// <param name="refreshProactively">Indicates whether the token should be proactively renewed prior to expiry or renew on demand.</param>
        /// <param name="tokenRefresher">The function that provides the token acquired from CommunicationIdentityClient.</param>
        public CommunicationTokenRefreshOptions(
            bool refreshProactively,
            Func<CancellationToken, string> tokenRefresher)
        {
            Argument.AssertNotNull(tokenRefresher, nameof(tokenRefresher));

            RefreshProactively = refreshProactively;
            TokenRefresher = tokenRefresher;
            AsyncTokenRefresher = AsyncTokenRefresher ?? (cancellationToken => new ValueTask<string>(tokenRefresher(cancellationToken)));
        }
    }
}
