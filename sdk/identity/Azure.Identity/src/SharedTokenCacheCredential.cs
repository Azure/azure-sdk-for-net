﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    /// Authenticates using tokens in the local cache shared between Microsoft applications.
    /// </summary>
    public class SharedTokenCacheCredential : TokenCredential
    {
        private readonly IPublicClientApplication _pubApp = null;
        private readonly string _username;
        private readonly Lazy<Task<IAccount>> _account;
        private readonly MsalCacheReader _cacheReader;
        private readonly string _clientId;

        /// <summary>
        /// Creates a new SharedTokenCacheCredential which will authenticate users with the specified application.
        /// </summary>
        public SharedTokenCacheCredential()
            : this(null, null)
        {

        }

        /// <summary>
        /// Creates a new SharedTokenCacheCredential with the specifeid options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="username">The username of the user to authenticate</param>
        /// <param name="options">The client options for the newly created SharedTokenCacheCredential</param>
        public SharedTokenCacheCredential(string username, TokenCredentialOptions options = default)
        {
            _clientId = Constants.DeveloperSignOnClientId;

            options ??= new TokenCredentialOptions();

            _username = username;

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options);

            _pubApp = PublicClientApplicationBuilder.Create(_clientId).WithHttpClientFactory(new HttpPipelineClientFactory(pipeline)).Build();

            _cacheReader = new MsalCacheReader(_pubApp.UserTokenCache, Constants.SharedTokenCacheFilePath, Constants.SharedTokenCacheAccessRetryCount, Constants.SharedTokenCacheAccessRetryDelay);

            _account = new Lazy<Task<IAccount>>(GetAccountAsync);
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft application participating in SSO through the MSAL cache
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft application participating in SSO through the MSAL cache
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            try
            {
                IAccount account = await _account.Value.ConfigureAwait(false);

                if (account != null)
                {
                    AuthenticationResult result = await _pubApp.AcquireTokenSilent(requestContext.Scopes, account).ExecuteAsync(cancellationToken).ConfigureAwait(false);

                    return new AccessToken(result.AccessToken, result.ExpiresOn);
                }
            }
            catch (MsalUiRequiredException) { } // account cannot be silently authenticated

            return default;
        }

        private async Task<IAccount> GetAccountAsync()
        {
            IAccount account = null;

            try
            {
                if (string.IsNullOrEmpty(_username))
                {
                    IEnumerable<IAccount> accounts = await _pubApp.GetAccountsAsync().ConfigureAwait(false);

                    account = accounts.Single();
                }
                else
                {
                    account = (await _pubApp.GetAccountsAsync().ConfigureAwait(false)).Where(a => a.Username == _username).Single();
                }
            }
            catch (InvalidOperationException) { } // more than on account

            return account;
        }
    }
}
