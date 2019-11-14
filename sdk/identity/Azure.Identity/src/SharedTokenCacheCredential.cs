// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Identity.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Azure.Identity
{
    /// <summary>
    /// Authenticates using tokens in the local cache shared between Microsoft applications.
    /// </summary>
    public class SharedTokenCacheCredential : TokenCredential, IExtendedTokenCredential
    {
        internal const string NoAccountsInCacheMessage = "No accounts were found in thecache.  To authenticate with the SharedTokenCacheCredential, login an account through developer tooling supporting Azure single sign on.";
        internal const string MultipleAccountsInCacheMessage = "Multiple accounts were found in the cache. To authenticate with the SharedTokenCacheCredential, set the AZURE_USERNAME and AZURE_TENANT_ID environment variables to the preferred username and tenantId, or specify them to the constructor. {0}";
        internal const string NoMatchingAccountsInCacheMessage = "No account matching the specified{0}{1} was found in the cache. To authenticate with the SharedTokenCacheCredential, login an account through developer tooling supporting Azure single sign on. {2}";
        internal const string MultipleMatchingAccountsInCacheMessage = "Multiple accounts matching the specified{0}{1} were found in the cache. To authenticate with the SharedTokenCacheCredential, set the AZURE_USERNAME and AZURE_TENANT_ID environment variables to the preferred username and tenantId, or specify them to the constructor. {2}";

        private readonly MsalPublicClient _client;
        private readonly CredentialPipeline _pipeline;
        private readonly string _tenantId;
        private readonly string _username;
        private readonly Lazy<Task<(IAccount, Exception)>> _account;

        /// <summary>
        /// Creates a new <see cref="SharedTokenCacheCredential"/> which will authenticate users signed in through developer tools supporting Azure single sign on.
        /// </summary>
        public SharedTokenCacheCredential()
            : this(null, null, CredentialPipeline.GetInstance(null))
        {

        }

        /// <summary>
        /// Creates a new <see cref="SharedTokenCacheCredential"/> which will authenticate users signed in through developer tools supporting Azure single sign on.
        /// </summary>
        /// <param name="options">The client options for the newly created <see cref="SharedTokenCacheCredential"/></param>
        public SharedTokenCacheCredential(SharedTokenCacheCredentialOptions options)
            : this(options?.TenantId, options?.Username, CredentialPipeline.GetInstance(options))
        {
        }

        /// <summary>
        /// Creates a new <see cref="SharedTokenCacheCredential"/> which will authenticate users signed in through developer tools supporting Azure single sign on.
        /// </summary>
        /// <param name="username">The username of the user to authenticate</param>
        /// <param name="options">The client options for the newly created <see cref="SharedTokenCacheCredential"/></param>
        public SharedTokenCacheCredential(string username, TokenCredentialOptions options = default)
            : this(tenantId: null, username: username, pipeline: CredentialPipeline.GetInstance(options))
        {
        }

        internal SharedTokenCacheCredential(string tenantId, string username, CredentialPipeline pipeline)
            : this(tenantId: tenantId, username: username, pipeline: pipeline, client: pipeline.CreateMsalPublicClient(Constants.DeveloperSignOnClientId, tenantId: tenantId, attachSharedCache: true))
        {
        }

        internal SharedTokenCacheCredential(string tenantId, string username, CredentialPipeline pipeline, MsalPublicClient client)
        {
            _tenantId = tenantId;

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
                return new ExtendedAccessToken(scope.Failed(new CredentialUnavailableException($"Token acquisition failed for user {_username}. To fix, re-authenticate through developer tooling supporting Azure single sign on.")));
            }
            catch (Exception e)
            {
                return new ExtendedAccessToken(scope.Failed(e));
            }
        }

        private async Task<(IAccount, Exception)> GetAccountAsync()
        {
            List<IAccount> accounts = (await _client.GetAccountsAsync().ConfigureAwait(false)).ToList();

            List<IAccount> filteredAccounts = accounts.Where(a => (string.IsNullOrEmpty(_username) || a.Username == _username) && (string.IsNullOrEmpty(_tenantId) || a.HomeAccountId?.TenantId == _tenantId)).ToList();

            if (filteredAccounts.Count != 1)
            {
                return (null, new CredentialUnavailableException(GetCredentialUnavailableMessage(accounts, filteredAccounts)));
            }

            return (filteredAccounts.First(), null);
        }

        private string GetCredentialUnavailableMessage(List<IAccount> accounts, List<IAccount> filteredAccounts)
        {
            if (accounts.Count == 0)
            {
                return NoAccountsInCacheMessage;
            }

            var discoveredAccountsStr = $"[ {{{string.Join("}, {", accounts.Select(a => $"username: {a.Username} tenantId: {a.HomeAccountId?.TenantId}"))}}} ]";

            if (string.IsNullOrEmpty(_username) && string.IsNullOrEmpty(_tenantId))
            {
                return string.Format(CultureInfo.InvariantCulture, MultipleAccountsInCacheMessage, discoveredAccountsStr);
            }

            var usernameStr = string.IsNullOrEmpty(_username) ? string.Empty : $" username: {_username}";
            var tenantIdStr = string.IsNullOrEmpty(_tenantId) ? string.Empty : $" tenantId: {_tenantId}";

            if (filteredAccounts.Count == 0)
            {
                return string.Format(CultureInfo.InvariantCulture, NoMatchingAccountsInCacheMessage, usernameStr, tenantIdStr, discoveredAccountsStr);
            }

            return string.Format(CultureInfo.InvariantCulture, MultipleMatchingAccountsInCacheMessage, usernameStr, tenantIdStr, discoveredAccountsStr);
        }
    }
}
