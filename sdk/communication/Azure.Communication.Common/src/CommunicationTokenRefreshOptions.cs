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
        /// <summary>Default time span in minutes before token expiry that `tokenRefresher` will be called.</summary>
        internal const int DefaultExpiringOffsetMinutes = 10;
        /// <summary>The initial token.</summary>
        public string InitialToken { get; set; }
        /// <summary>The asynchronous token refresher.</summary>
        public Func<CancellationToken, ValueTask<string>> AsyncTokenRefresher
        {
            get => _asyncTokenRefresher = _asyncTokenRefresher ?? (cancellationToken => new ValueTask<string>(TokenRefresher(cancellationToken)));
            set => _asyncTokenRefresher = value;
        }

        /// <summary>The time span before token expiry that causes the 'tokenRefresher' to be called if 'refreshProactively' is true.</summary>
        internal TimeSpan RefreshTimeBeforeTokenExpiry { get; } = new TimeSpan(0, 0, DefaultExpiringOffsetMinutes, 0);
        /// <summary>Determines whether the token should be proactively renewed prior to expiry or renew on demand./// </summary>
        internal bool RefreshProactively { get; }
        /// <summary>The callback function that acquires a fresh token from the Communication Identity API, e.g. by calling the CommunicationIdentityClient.</summary>
        internal Func<CancellationToken, string> TokenRefresher { get; }

        /// <summary>The asynchronous token refresher.</summary>
        private Func<CancellationToken, ValueTask<string>> _asyncTokenRefresher;

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
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationTokenRefreshOptions"/>.
        /// </summary>
        /// <param name="refreshProactively">Indicates whether the token should be proactively renewed prior to expiry or renew on demand.</param>
        /// <param name="tokenRefresher">The function that provides the token acquired from CommunicationIdentityClient.</param>
        /// <param name="refreshTimeBeforeTokenExpiry">The time span before token expiry that `tokenRefresher` will be called if `refreshProactively` is true. For example, setting it to 5min means that 5min before the cached token expires, proactive refresh will request a new token. The default value is 10min.</param>
        public CommunicationTokenRefreshOptions(
            bool refreshProactively,
            TimeSpan refreshTimeBeforeTokenExpiry,
            Func<CancellationToken, string> tokenRefresher) : this(refreshProactively, tokenRefresher)
        {
            RefreshTimeBeforeTokenExpiry = refreshTimeBeforeTokenExpiry;
        }
    }
}
