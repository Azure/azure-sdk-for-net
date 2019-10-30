// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Identity.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Azure.Identity
{
    /// <summary>
    /// Authenticates using tokens in the local cache shared between Microsoft applications.
    /// </summary>
    public class SharedTokenCacheCredential : TokenCredential, IExtendedTokenCredential
    {
        internal const string MultipleAccountsErrorMessage = "Multiple accounts were discovered in the shared token cache. To fix, set the AZURE_USERNAME environment variable to the preferred username, or specify it when constructing SharedTokenCacheCredential.";

        internal const string NoAccountsErrorMessage = "No accounts were discovered in the shared token cache. To fix, authenticate through tooling supporting azure developer sign on.";

        private readonly MsalPublicClient _client;
        private readonly CredentialPipeline _pipeline;
        private readonly string _username;
        private readonly Lazy<Task<(IAccount, Exception)>> _account;

        /// <summary>
        /// Creates a new SharedTokenCacheCredential which will authenticate users with the specified application.
        /// </summary>
        public SharedTokenCacheCredential()
            : this(null, CredentialPipeline.GetInstance(null))
        {

        }

        /// <summary>
        /// Creates a new SharedTokenCacheCredential with the specified options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="username">The username of the user to authenticate</param>
        /// <param name="options">The client options for the newly created SharedTokenCacheCredential</param>
        public SharedTokenCacheCredential(string username, TokenCredentialOptions options = default)
            : this(username, CredentialPipeline.GetInstance(options))
        {
        }

        internal SharedTokenCacheCredential(string username, CredentialPipeline pipeline)
            : this(username, pipeline, pipeline.CreateMsalPublicClient(Constants.DeveloperSignOnClientId, attachSharedCache: true))
        {
        }

        internal SharedTokenCacheCredential(string username, CredentialPipeline pipeline, MsalPublicClient client)
        {
            _username = username;

            _pipeline = pipeline;

            _client = client;

            _account = new Lazy<Task<(IAccount, Exception)>>(GetAccountAsync);
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft application participating in SSO through a shared MSAL cache. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(requestContext, cancellationToken).GetAwaiter().GetResult().GetTokenOrThrow();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft application participating in SSO through a shared MSAL cache. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return (await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false)).GetTokenOrThrow();
        }

        ExtendedAccessToken IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImplAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
        }

        async ValueTask<ExtendedAccessToken> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<ExtendedAccessToken> GetTokenImplAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            IAccount account = null;

            Exception ex = null;

            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.SharedTokenCacheCredential.GetToken", requestContext);

            try
            {
                (account, ex) = await _account.Value.ConfigureAwait(false);

                if (account != null)
                {
                    AuthenticationResult result = await _client.AcquireTokenSilentAsync(requestContext.Scopes, account, cancellationToken).ConfigureAwait(false);

                    return new ExtendedAccessToken(scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn)));
                }
                else
                {
                    return new ExtendedAccessToken(scope.Failed(ex));
                }
            }
            catch (MsalUiRequiredException)
            {
                return new ExtendedAccessToken(scope.Failed(new CredentialUnavailableException($"Token aquisition failed for user '{_username}'. To fix, reauthenticate through tooling supporting azure developer sign on.")));
            }
            catch (Exception e)
            {
                return new ExtendedAccessToken(scope.Failed(e));
            }
        }

        private async Task<(IAccount, Exception)> GetAccountAsync()
        {
            Exception ex = null;

            IAccount account = null;

            List<IAccount> allAccounts = (await _client.GetAccountsAsync().ConfigureAwait(false)).ToList();

            List<IAccount> accounts = (!string.IsNullOrEmpty(_username)) ? allAccounts.Where(a => a.Username == _username).ToList() : allAccounts.ToList();

            if (accounts.Count == 0)
            {
                if (allAccounts.Count == 0)
                {
                    ex = new CredentialUnavailableException(NoAccountsErrorMessage);
                }
                else
                {
                    ex = new CredentialUnavailableException($"User account '{_username}' was not found in the shared token cache.{Environment.NewLine}  Discovered Accounts: [ '{string.Join("', '", allAccounts.Select(a => a.Username))}' ]");
                }
            }
            else
            {
                // we already know there is at least one account
                IAccount proposedAccount = accounts.First();

                // if all accounts have the same home account id they are interchangable, so we can just use the first account which we picked
                if (accounts.All(a => a.HomeAccountId.Identifier == proposedAccount.HomeAccountId.Identifier))
                {
                    account = proposedAccount;
                }
                // otherwise we need to error so we don't indiscriminantly choose between different tenents / subscriptions
                else
                {
                    // if username wasn't specified it's possible that they can rectify this situation by specifying
                    if (string.IsNullOrEmpty(_username))
                    {
                        ex = new CredentialUnavailableException($"{MultipleAccountsErrorMessage}{Environment.NewLine} Discovered Accounts: [ '{string.Join("', '", allAccounts.Select(a => a.Username))}' ]");
                    }
                    // if they already specified username the cache is essentially unusable to use without more information
                    else
                    {
                        ex = new CredentialUnavailableException($"Multiple entries for the user account '{_username}' were found in the shared token cache. This is not currently supported by the SharedTokenCacheCredential.");
                    }
                }
            }

            return (account, ex);
        }

    }
}
