// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication;
using Azure.Core;

namespace Azure.Communication
{
    /// <summary>
    /// The Azure Communication Services Token Credential.
    /// </summary>
    public sealed class CommunicationTokenCredential : IDisposable
    {
        private readonly ICommunicationTokenCredential _tokenCredential;
        private bool _isDisposed;

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationTokenCredential"/>.
        /// </summary>
        /// <param name="token">User token acquired from Azure.Communication.Administration package.</param>
        public CommunicationTokenCredential(string token)
            => _tokenCredential = new StaticTokenCredential(token);

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationTokenCredential"/> that automatically renews the token upon expiry or proactively prior to expiration to speed up the requests.
        /// </summary>
        /// <param name="options">Options for how the token will be refreshed</param>
        public CommunicationTokenCredential(CommunicationTokenRefreshOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));
            _tokenCredential = new AutoRefreshTokenCredential(options);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationTokenCredential"/>.
        /// </summary>
        /// <param name="options">The options for how the token will be fetched</param>
        public CommunicationTokenCredential(EntraCommunicationTokenCredentialOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));
            _tokenCredential = new EntraTokenCredential(options);
        }

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
                throw new ObjectDisposedException(nameof(CommunicationTokenCredential));

            return _tokenCredential.GetTokenAsync(cancellationToken);
        }

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the user.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns> Contains the access token for the user.</returns>
        public AccessToken GetToken(CancellationToken cancellationToken = default)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(nameof(CommunicationTokenCredential));

            return _tokenCredential.GetToken(cancellationToken);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_isDisposed)
                return;

            _tokenCredential.Dispose();
            _isDisposed = true;
        }
    }
}
