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
        /// <summary>Default proactive refreshing interval in minutes.</summary>
        public const int DefaultExpiringOffsetMinutes = 5;
        internal bool RefreshProactively { get; }
        internal Func<CancellationToken, string> TokenRefresher { get; }

        /// <summary>The initial token.</summary>
        public string InitialToken { get; set; }

        /// <summary>The proactive refreshing interval.</summary>
        internal readonly TimeSpan RefreshOffsetTime;

        private Func<CancellationToken, ValueTask<string>> _asyncTokenRefresher;

        /// <summary>The asynchronous token refresher.</summary>
        public Func<CancellationToken, ValueTask<string>> AsyncTokenRefresher
        {
            get => _asyncTokenRefresher = _asyncTokenRefresher ?? (cancellationToken => new ValueTask<string>(TokenRefresher(cancellationToken)));
            set => _asyncTokenRefresher = value;
        }
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
            RefreshOffsetTime = new TimeSpan( 0, 0, DefaultExpiringOffsetMinutes, 0);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationTokenRefreshOptions"/>.
        /// </summary>
        /// <param name="refreshProactively">Indicates whether the token should be proactively renewed prior to expiry or renew on demand.</param>
        /// <param name="tokenRefresher">The function that provides the token acquired from CommunicationIdentityClient.</param>
        /// <param name="refreshOffsetTime">Proactive refresh interval.</param>
        public CommunicationTokenRefreshOptions(
            bool refreshProactively,
            TimeSpan refreshOffsetTime,
            Func<CancellationToken, string> tokenRefresher)
        {
            Argument.AssertNotNull(tokenRefresher, nameof(tokenRefresher));
            RefreshProactively = refreshProactively;
            TokenRefresher = tokenRefresher;
            RefreshOffsetTime = refreshOffsetTime;
        }
    }
}
