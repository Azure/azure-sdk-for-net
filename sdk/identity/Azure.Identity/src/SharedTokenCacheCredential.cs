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
using System.ComponentModel;

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

        private static readonly ITokenCacheOptions s_DefaultCacheOptions = new SharedTokenCacheCredentialOptions();
        private readonly CredentialPipeline _pipeline;
        private readonly string _tenantId;
        private readonly string _username;
        private readonly bool _skipTenantValidation;
        private readonly AuthenticationRecord _record;
        private readonly AsyncLockWithValue<IAccount> _accountAsyncLock;

        internal MsalPublicClient Client { get; }

        /// <summary>
        /// Creates a new <see cref="SharedTokenCacheCredential"/> which will authenticate users signed in through developer tools supporting Azure single sign on.
        /// </summary>
        public SharedTokenCacheCredential()
            : this(null, null, null, null, null)
        {
        }

        /// <summary>
        /// Creates a new <see cref="SharedTokenCacheCredential"/> which will authenticate users signed in through developer tools supporting Azure single sign on.
        /// </summary>
        /// <param name="options">The client options for the newly created <see cref="SharedTokenCacheCredential"/></param>
        public SharedTokenCacheCredential(SharedTokenCacheCredentialOptions options)
            : this(options?.TenantId, options?.Username, options, null, null)
        {
        }

        /// <summary>
        /// Creates a new <see cref="SharedTokenCacheCredential"/> which will authenticate users signed in through developer tools supporting Azure single sign on.
        /// </summary>
        /// <param name="username">The username of the user to authenticate</param>
        /// <param name="options">The client options for the newly created <see cref="SharedTokenCacheCredential"/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SharedTokenCacheCredential(string username, TokenCredentialOptions options = default)
            : this(null, username, options, null, null)
        {
        }

        internal SharedTokenCacheCredential(string tenantId, string username, TokenCredentialOptions options, CredentialPipeline pipeline)
            : this(tenantId, username, options, pipeline, null)
        {
        }

        internal SharedTokenCacheCredential(string tenantId, string username, TokenCredentialOptions options, CredentialPipeline pipeline, MsalPublicClient client)
        {
            _tenantId = tenantId;

            _username = username;

            _skipTenantValidation = (options as SharedTokenCacheCredentialOptions)?.EnableGuestTenantAuthentication ?? false;

            _record = (options as SharedTokenCacheCredentialOptions)?.AuthenticationRecord;

            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);

            Client = client ?? new MsalPublicClient(_pipeline, tenantId, (options as SharedTokenCacheCredentialOptions)?.ClientId ?? Constants.DeveloperSignOnClientId, null, (options as ITokenCacheOptions) ?? s_DefaultCacheOptions);

            _accountAsyncLock = new AsyncLockWithValue<IAccount>();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft application participating in SSO through a shared MSAL cache. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft application participating in SSO through a shared MSAL cache. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
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
                IAccount account = await GetAccountAsync(async, cancellationToken).ConfigureAwait(false);
                AuthenticationResult result = await Client.AcquireTokenSilentAsync(requestContext.Scopes, account, async, cancellationToken).ConfigureAwait(false);
                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (MsalUiRequiredException)
            {
                throw scope.FailWrapAndThrow(new CredentialUnavailableException($"{nameof(SharedTokenCacheCredential)} authentication unavailable. Token acquisition failed for user {_username}. Ensure that you have authenticated with a developer tool that supports Azure single sign on."));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async ValueTask<IAccount> GetAccountAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await _accountAsyncLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            IAccount account;
            if (_record != null)
            {
                account = new AuthenticationAccount(_record);
                asyncLock.SetValue(account);
                return account;
            }

            List<IAccount> accounts = await Client.GetAccountsAsync(async, cancellationToken).ConfigureAwait(false);

            // filter the accounts to those matching the specified user and tenant
            List<IAccount> filteredAccounts = accounts.Where(a =>
                // if _username is specified it must match the account
                ((string.IsNullOrEmpty(_username) || string.Compare(a.Username, _username, StringComparison.OrdinalIgnoreCase) == 0))
                &&
                // if _skipTenantValidation is false and _tenantId is specified it must match the account
                (_skipTenantValidation || (string.IsNullOrEmpty(_tenantId) || string.Compare(a.HomeAccountId?.TenantId, _tenantId, StringComparison.OrdinalIgnoreCase) == 0))
            ).ToList();

            if (filteredAccounts.Count != 1)
            {
                throw new CredentialUnavailableException(GetCredentialUnavailableMessage(accounts, filteredAccounts));
            }

            account = filteredAccounts.First();
            asyncLock.SetValue(account);
            return account;
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
