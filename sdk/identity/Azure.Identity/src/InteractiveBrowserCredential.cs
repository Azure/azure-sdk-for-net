// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// A <see cref="TokenCredential"/> implementation which launches the system default browser to interactively authenticate a user, and obtain an access token.
    /// The browser will only be launched to authenticate the user once, then will silently aquire access tokens through the users refresh token as long as it's valid.
    /// </summary>
    public class InteractiveBrowserCredential : TokenCredential
    {
        private IPublicClientApplication _pubApp = null;
        private IAccount _account = null;
        private IdentityClientOptions _options;
        private string _clientId;

        /// <summary>
        /// Creates a new InteractiveBrowserCredential which will authenticate users with the specified application.
        /// </summary>
        /// <param name="clientId">The client id of the application to which the users will authenticate.</param>
        /// TODO: need to link to info on how the application has to be created to authenticate users, for multiple applications
        public InteractiveBrowserCredential(string clientId)
            : this (clientId, null)
        {

        }

        /// <summary>
        /// Creates a new InteractiveBrowserCredential with the specifeid options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        /// TODO: need to link to info on how the application has to be created to authenticate users, for multiple applications
        /// <param name="options">The client options for the newly created DeviceCodeCredential</param>
        public InteractiveBrowserCredential(string clientId, IdentityClientOptions options)
        {
            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            _options = options ??= new IdentityClientOptions();

            var pipeline = HttpPipelineBuilder.Build(_options, bufferResponse: true);

            _pubApp = PublicClientApplicationBuilder.Create(_clientId).WithHttpClientFactory(new HttpPipelineClientFactory(pipeline)).WithRedirectUri("http://localhost").Build();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the default browser is launched to authenticate the user.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return GetTokenAsync(scopes, cancellationToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated, otherwise the default browser is launched to authenticate the user.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            if (_account != null)
            {
                try
                {
                    AuthenticationResult result = await _pubApp.AcquireTokenSilent(scopes, _account).ExecuteAsync(cancellationToken).ConfigureAwait(false);

                    return new AccessToken(result.AccessToken, result.ExpiresOn);
                }
                catch (MsalUiRequiredException)
                {
                    return await GetTokenViaBrowserLoginAsync(scopes, cancellationToken).ConfigureAwait(false);
                }
            }
            else
            {
                return await GetTokenViaBrowserLoginAsync(scopes, cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task<AccessToken> GetTokenViaBrowserLoginAsync(string[] scopes, CancellationToken cancellationToken)
        {
            AuthenticationResult result = await _pubApp.AcquireTokenInteractive(scopes).WithPrompt(Prompt.SelectAccount).ExecuteAsync(cancellationToken).ConfigureAwait(false);

            _account = result.Account;

            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }
    }
}

