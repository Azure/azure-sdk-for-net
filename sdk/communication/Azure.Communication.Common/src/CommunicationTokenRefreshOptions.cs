// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Communication
{
    /// <summary>
    /// The Communication Token Refresh Options
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CommunicationTokenRefreshOptions
    {
        /// <summary>
        /// Backing field for the <see cref="AsyncTokenRefresher"/>.
        /// </summary>
        private Func<CancellationToken, ValueTask<string>> _asyncTokenRefresher;

        /// <summary>
        /// Determines whether the token should be proactively renewed prior to its expiry or on demand.
        /// </summary>
        internal bool RefreshProactively { get; }

        /// <summary>
        /// The initial token.
        /// </summary>
        public string InitialToken { get; set; }

        /// <summary>
        /// The asynchronous callback function that acquires a fresh token from the Communication Identity API, e.g. by calling the CommunicationIdentityClient.
        /// The returned token must be valid (its expiration date must be set in the future).
        /// </summary>
        public Func<CancellationToken, ValueTask<string>> AsyncTokenRefresher
        {
            get => _asyncTokenRefresher = _asyncTokenRefresher ?? (cancellationToken => new ValueTask<string>(TokenRefresher(cancellationToken)));
            set => _asyncTokenRefresher = value;
        }

        /// <summary>
        /// The callback function that acquires a fresh token from the Communication Identity API, e.g. by calling the CommunicationIdentityClient.
        /// The returned token must be valid (its expiration date must be set in the future).
        /// </summary>
        internal Func<CancellationToken, string> TokenRefresher { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationTokenRefreshOptions"/>.
        /// </summary>
        /// <param name="refreshProactively">Indicates whether the token should be proactively renewed prior to expiry or renew on demand.</param>
        /// <param name="tokenRefresher">The function that provides the token acquired from Communication Identity API.
        /// The returned token must be valid (its expiration date must be set in the future).</param>
        public CommunicationTokenRefreshOptions(
            bool refreshProactively,
            Func<CancellationToken, string> tokenRefresher)
        {
            Argument.AssertNotNull(tokenRefresher, nameof(tokenRefresher));
            RefreshProactively = refreshProactively;
            TokenRefresher = tokenRefresher;
        }
    }
}
