// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Identity.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Authenticates using tokens in the local cache shared between Microsoft applications.
    /// </summary>
    public class SharedTokenCacheCredential : TokenCredential
    {
        internal const string NoAccountsInCacheMessage = "SharedTokenCacheCredential authentication unavailable. No accounts were found in the cache.";
        internal const string MultipleAccountsInCacheMessage = "SharedTokenCacheCredential authentication unavailable. Multiple accounts were found in the cache. Use username and tenant id to disambiguate.";
        internal const string NoMatchingAccountsInCacheMessage = "SharedTokenCacheCredential authentication unavailable. No account matching the specified{0}{1} was found in the cache.";
        internal const string MultipleMatchingAccountsInCacheMessage = "SharedTokenCacheCredential authentication unavailable. Multiple accounts matching the specified{0}{1} were found in the cache.";

        private readonly MsalPublicClient _client;
        private readonly CredentialPipeline _pipeline;
        private readonly string _tenantId;
        private readonly string _username;
        private readonly Lazy<Task<IAccount>> _account;

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

            _account = new Lazy<Task<IAccount>>(GetAccountAsync);
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft application participating in SSO through a shared MSAL cache. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft application participating in SSO through a shared MSAL cache. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("SharedTokenCacheCredential.GetToken", requestContext);

            try
            {
                IAccount account = async
                    ? await _account.Value.ConfigureAwait(false)
#pragma warning disable AZC0102
                    : _account.Value.GetAwaiter().GetResult();
#pragma warning restore AZC0102

                AuthenticationResult result = await _client.AcquireTokenSilentAsync(requestContext.Scopes, account, async, cancellationToken).ConfigureAwait(false);

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (MsalUiRequiredException)
            {
                throw scope.Failed(new CredentialUnavailableException($"{nameof(SharedTokenCacheCredential)} authentication unavailable. Token acquisition failed for user {_username}. Ensure that you have authenticated with a developer tool that supports Azure single sign on."));
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);
                throw;
            }
            catch (Exception e)
            {
                throw scope.FailAndWrap(e);
            }
        }

        private async Task<IAccount> GetAccountAsync()
        {
            List<IAccount> accounts = (await _client.GetAccountsAsync().ConfigureAwait(false)).ToList();

            List<IAccount> filteredAccounts = accounts.Where(a => (string.IsNullOrEmpty(_username) || a.Username == _username) && (string.IsNullOrEmpty(_tenantId) || a.HomeAccountId?.TenantId == _tenantId)).ToList();

            if (filteredAccounts.Count != 1)
            {
                throw new CredentialUnavailableException(GetCredentialUnavailableMessage(accounts, filteredAccounts));
            }

            return filteredAccounts.First();
        }

        private string GetCredentialUnavailableMessage(List<IAccount> accounts, List<IAccount> filteredAccounts)
        {
            if (accounts.Count == 0)
            {
                return NoAccountsInCacheMessage;
            }

            if (string.IsNullOrEmpty(_username) && string.IsNullOrEmpty(_tenantId))
            {
                return string.Format(CultureInfo.InvariantCulture, MultipleAccountsInCacheMessage);
            }

            var usernameStr = string.IsNullOrEmpty(_username) ? string.Empty : $" username: {_username}";
            var tenantIdStr = string.IsNullOrEmpty(_tenantId) ? string.Empty : $" tenantId: {_tenantId}";

            if (filteredAccounts.Count == 0)
            {
                return string.Format(CultureInfo.InvariantCulture, NoMatchingAccountsInCacheMessage, usernameStr, tenantIdStr);
            }

            return string.Format(CultureInfo.InvariantCulture, MultipleMatchingAccountsInCacheMessage, usernameStr, tenantIdStr);
        }
    }
}
