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
        internal Func<CancellationToken, ValueTask<string>> AsyncTokenRefresher { get; }

#nullable enable
        internal string? InitialToken { get; }
#nullable restore

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationTokenRefreshOptions"/>.
        /// </summary>
        /// <param name="refreshProactively">Indicates whether the token should be proactively renewed prior to expiry or renew on demand.</param>
        /// <param name="tokenRefresher">The function that provides the token acquired from CommunicationIdentityClient.</param>
        /// <param name="asyncTokenRefresher">The async function that provides the token acquired from CommunicationIdentityClient, a null value defaults to <paramref name="tokenRefresher"/>.</param>
        /// <param name="initialToken">Optional token value.</param>
        public CommunicationTokenRefreshOptions(
            bool refreshProactively,
            Func<CancellationToken, string> tokenRefresher,
            Func<CancellationToken, ValueTask<string>> asyncTokenRefresher = null,
            string initialToken = null)
        {
            Argument.AssertNotNull(tokenRefresher, nameof(tokenRefresher));

            RefreshProactively = refreshProactively;
            TokenRefresher = tokenRefresher;
            AsyncTokenRefresher = asyncTokenRefresher ?? (cancellationToken => new ValueTask<string>(tokenRefresher(cancellationToken)));
            InitialToken = initialToken;
        }
    }
}
