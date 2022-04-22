// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   Performs the actions needed to generate <see cref="CbsToken" /> instances for
    ///   authorization within an AMQP scope.
    /// </summary>
    ///
    /// <seealso cref="Microsoft.Azure.Amqp.ICbsTokenProvider" />
    ///
    internal sealed class CbsTokenProvider : ICbsTokenProvider, IDisposable
    {
        /// <summary>The type to consider a token if it is based on an Event Hubs shared access signature.</summary>
        private const string SharedAccessTokenType = "servicebus.windows.net:sastoken";

        /// <summary>The type to consider a token if not based on a shared access signature.</summary>
        private const string JsonWebTokenType = "jwt";

        /// <summary>The type to consider a token generated from the associated <see cref="Credential" />.</summary>
        private readonly string TokenType;

        /// <summary>The credential used to generate access tokens.</summary>
        private readonly EventHubTokenCredential Credential;

        /// <summary>The primitive for synchronizing access when an authorization token is being acquired.</summary>
        private readonly SemaphoreSlim TokenAcquireGuard;

        /// <summary>The amount of buffer to when evaluating token expiration; the token's expiration date will be adjusted earlier by this amount.</summary>
        private readonly TimeSpan TokenExpirationBuffer;

        /// <summary>The cancellation token to consider when making requests.</summary>
        private readonly CancellationToken CancellationToken;

        /// <summary>The JWT-based <see cref="CbsToken" /> that is currently cached for authorization.</summary>
        private CbsToken _cachedJwtToken;

        /// <summary>
        ///   Initializes a new instance of the <see cref="CbsTokenProvider"/> class.
        /// </summary>
        ///
        /// <param name="credential">The credential to use for access token generation.</param>
        /// <param name="tokenExpirationBuffer">The amount of time to buffer expiration</param>
        /// <param name="cancellationToken">The cancellation token to consider when making requests.</param>
        ///
        public CbsTokenProvider(EventHubTokenCredential credential,
                                TimeSpan tokenExpirationBuffer,
                                CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNegative(tokenExpirationBuffer, nameof(tokenExpirationBuffer));

            Credential = credential;
            TokenExpirationBuffer = tokenExpirationBuffer;
            CancellationToken = cancellationToken;

            TokenType = (credential.IsSharedAccessCredential)
                ? SharedAccessTokenType
                : JsonWebTokenType;

            // Tokens are only cached for JWT-based credentials; no need
            // to instantiate the semaphore if no caching is taking place.

            if (!credential.IsSharedAccessCredential)
            {
                TokenAcquireGuard = new SemaphoreSlim(1, 1);
            }
        }

        /// <summary>
        ///   Asynchronously requests a CBS token to be used for authorization within an AMQP
        ///   scope.
        /// </summary>
        ///
        /// <param name="namespaceAddress">The address of the namespace to be authorized.</param>
        /// <param name="appliesTo">The resource to which the token should apply.</param>
        /// <param name="requiredClaims">The set of claims that are required for authorization.</param>
        ///
        /// <returns>The token to use for authorization.</returns>
        ///
        public async Task<CbsToken> GetTokenAsync(Uri namespaceAddress,
                                                  string appliesTo,
                                                  string[] requiredClaims) =>
            Credential switch
            {
                _ when Credential.IsSharedAccessCredential => await AcquireSharedAccessTokenAsync().ConfigureAwait(false),
                _ => await AcquireJwtTokenAsync().ConfigureAwait(false)
            };

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="CbsTokenProvider" />.
        /// </summary>
        ///
        public void Dispose() => TokenAcquireGuard?.Dispose();

        /// <summary>
        ///   Acquires a token for a JWT-type credential.
        /// </summary>
        ///
        /// <returns>The <see cref="CbsToken"/> to use for authorization.</returns>
        ///
        private async Task<CbsToken> AcquireJwtTokenAsync()
        {
            var token = Volatile.Read(ref _cachedJwtToken);
            var guardAcquired = false;

            // If the token is expiring, attempt to acquire the semaphore needed to
            // refresh it.

            if (IsNearingExpiration(token))
            {
                try
                {
                    // Attempt to acquire the semaphore synchronously, in case it is not currently
                    // held.

                    if (!TokenAcquireGuard.Wait(0, CancellationToken.None))
                    {
                        await TokenAcquireGuard.WaitAsync(CancellationToken).ConfigureAwait(false);
                    }

                    guardAcquired = true;

                    // Because the token may have been refreshed while waiting for the semaphore,
                    // check expiration again to avoid making an necessary request.  Because the token
                    // is only updated when the semaphore is held, there's no need to perform a volatile
                    // read for this refresh.

                    token = _cachedJwtToken;

                    if (IsNearingExpiration(token))
                    {
                        var accessToken = await Credential.GetTokenUsingDefaultScopeAsync(CancellationToken).ConfigureAwait(false);
                        token = new CbsToken(accessToken.Token, TokenType, accessToken.ExpiresOn.UtcDateTime);

                        _cachedJwtToken = token;
                    }
                }
                finally
                {
                    if (guardAcquired)
                    {
                        TokenAcquireGuard.Release();
                    }
                }
            }

            return token;
        }

        /// <summary>
        ///   Acquires a token for a shared access credential.
        /// </summary>
        ///
        /// <returns>The <see cref="CbsToken"/> to use for authorization.</returns>
        ///
        private async Task<CbsToken> AcquireSharedAccessTokenAsync()
        {
            var accessToken = await Credential.GetTokenUsingDefaultScopeAsync(CancellationToken).ConfigureAwait(false);
            return new CbsToken(accessToken.Token, TokenType, accessToken.ExpiresOn.UtcDateTime);
        }

        /// <summary>
        ///   Determines whether the specified token is nearing its expiration and a new
        ///   token should be acquired.
        /// </summary>
        ///
        /// <param name="token">The token to consider.</param>
        ///
        /// <returns><c>true</c> if the specified token is near expiring; otherwise, <c>false</c>.</returns>
        ///
        private bool IsNearingExpiration(CbsToken token) =>
            ((token == null) || token.ExpiresAtUtc.Subtract(TokenExpirationBuffer) <= DateTimeOffset.UtcNow);
    }
}
