// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Communication.Identity
{
    /// <summary>
    /// The Azure Communication Services User token credential.
    /// </summary>
    public sealed class CommunicationUserCredential : IDisposable
    {
        private readonly IUserCredential _userTokenCredential;
        private bool _isDisposed;

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationUserCredential"/>.
        /// </summary>
        /// <param name="userToken">User token acquired from Azure.Communication.Administration package.</param>
        public CommunicationUserCredential(string userToken)
            => _userTokenCredential = new StaticUserCredential(userToken);

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationUserCredential"/> that automatically renews the token upon expiry or proactively prior to expiration to speed up the requests.
        /// </summary>
        /// <param name="refreshProactively">Indicates wheter user token should be proactively renewed prior to expiry or renew on demand.</param>
        /// <param name="tokenRefresher">The function that provides the user token acquired from the configurtaion SDK.</param>
        /// <param name="asyncTokenRefresher">The async function that provides the user token acquired from the configurtaion SDK.</param>
        /// <param name="initialToken">Optional user token to initialize.</param>
        public CommunicationUserCredential(
            bool refreshProactively,
            Func<CancellationToken, string> tokenRefresher,
            Func<CancellationToken, ValueTask<string>>? asyncTokenRefresher = null,
            string? initialToken = null)
            => _userTokenCredential = new AutoRefreshUserCredential(
                tokenRefresher,
                asyncTokenRefresher ?? (cancellationToken => new ValueTask<string>(tokenRefresher(cancellationToken))),
                initialToken,
                refreshProactively);

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the user.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns>
        /// A task that represents the asynchronous get token operation. The value of its <see cref="ValueTask{AccessToken}.Result"/> property contains the access token for the user.
        /// </returns>
        public ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(nameof(CommunicationUserCredential));

            return _userTokenCredential.GetTokenAsync(cancellationToken);
        }

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the user.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns>/// Contains the access token for the user.</returns>
        public AccessToken GetToken(CancellationToken cancellationToken = default)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(nameof(CommunicationUserCredential));

            return _userTokenCredential.GetToken(cancellationToken);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _userTokenCredential.Dispose();
            _isDisposed = true;
        }
    }
}
