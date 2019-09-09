// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Identity.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Authenticates using tokens in the local cache shared between Microsoft applications.
    /// </summary>
    public class SharedTokenCacheCredential : TokenCredential
    {
        private IPublicClientApplication _pubApp = null;
        private string _username;
        private MsalCacheReader _cacheReader;
        private string _clientId;

        /// <summary>
        /// Creates a new InteractiveBrowserCredential which will authenticate users with the specified application.
        /// </summary>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        /// <param name="username">The username (typically an email address) of the user to authenticate, this is required because the local cache may contain tokens for multiple identities</param>
        /// TODO: need to link to info on how the application has to be created to authenticate users, for multiple applications
        public SharedTokenCacheCredential(string clientId, string username)
            : this(clientId, username, null)
        {

        }

        /// <summary>
        /// Creates a new InteractiveBrowserCredential with the specifeid options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        /// <param name="username">The username of the user to authenticate</param>
        /// TODO: need to link to info on how the application has to be created to authenticate users, for multiple applications
        /// <param name="options">The client options for the newly created SharedTokenCacheCredential</param>
        public SharedTokenCacheCredential(string clientId, string username, SharedTokenCacheCredentialOptions options)
        {
            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            options ??= new SharedTokenCacheCredentialOptions();

            _username = username;

            _pubApp = PublicClientApplicationBuilder.Create(_clientId).Build();

            _cacheReader = new MsalCacheReader(_pubApp.UserTokenCache, options.CacheFilePath, options.CacheAccessRetryCount, options.CacheAccessRetryDelay);
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft application participating in SSO through the MSAL cache
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return GetTokenAsync(scopes, cancellationToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft application participating in SSO through the MSAL cache
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            try
            {
                AuthenticationResult result = await _pubApp.AcquireTokenSilent(scopes, _username).ExecuteAsync(cancellationToken).ConfigureAwait(false);

                return new AccessToken(result.AccessToken, result.ExpiresOn);
            }
            catch (MsalUiRequiredException)
            {
                return default;
            }
        }
    }
}
