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
    /// Authenticates using tokens in a local cache file. This is a legacy mechanism for authenticating clients using credentials provided to Visual Studio.
    /// This mechanism for Visual Studio authentication has been replaced by the <see cref="VisualStudioCredential"/>.
    /// </summary>
    public class SharedTokenCacheCredential : TokenCredential
    {
        internal const string NoAccountsInCacheMessage = "SharedTokenCacheCredential authentication unavailable. No accounts were found in the cache.";
        internal const string MultipleAccountsInCacheMessage = "SharedTokenCacheCredential authentication unavailable. Multiple accounts were found in the cache. Use username and tenant id to disambiguate.";
        internal const string NoMatchingAccountsInCacheMessage = "SharedTokenCacheCredential authentication unavailable. No account matching the specified{0}{1} was found in the cache.";
        internal const string MultipleMatchingAccountsInCacheMessage = "SharedTokenCacheCredential authentication unavailable. Multiple accounts matching the specified{0}{1} were found in the cache.";
        private static readonly SharedTokenCacheCredentialOptions s_DefaultCacheOptions = new SharedTokenCacheCredentialOptions();
        private readonly CredentialPipeline _pipeline;
        private readonly bool _skipTenantValidation;
        private readonly AuthenticationRecord _record;
        private readonly AsyncLockWithValue<IAccount> _accountAsyncLock;
        internal string TenantId { get; }
        internal string Username { get; }
        internal MsalPublicClient Client { get; }
        internal TenantIdResolverBase TenantIdResolver { get; }
        internal bool UseOperatingSystemAccount { get; }

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
            TenantId = tenantId;
            Username = username;
            var sharedTokenCredentialOptions = options as SharedTokenCacheCredentialOptions;
            _skipTenantValidation = sharedTokenCredentialOptions?.EnableGuestTenantAuthentication ?? false;
            _record = sharedTokenCredentialOptions?.AuthenticationRecord;
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            Client = client ?? new MsalPublicClient(
                _pipeline,
                tenantId,
                sharedTokenCredentialOptions?.ClientId ?? Constants.DeveloperSignOnClientId,
                null,
                options ?? s_DefaultCacheOptions);
            _accountAsyncLock = new AsyncLockWithValue<IAccount>();
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            UseOperatingSystemAccount = (options as IMsalPublicClientInitializerOptions)?.UseOperatingSystemAccount ?? false;
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft
        /// application participating in SSO through a shared MSAL cache. Acquired tokens are cached by the credential instance. Token
        /// lifetime and refreshing is handled automatically. Where possible, reuse credential instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> token for a user account silently if the user has already authenticated to another Microsoft
        /// application participating in SSO through a shared MSAL cache. Acquired tokens are cached by the credential instance. Token
        /// lifetime and refreshing is handled automatically. Where possible, reuse credential instances to optimize cache effectiveness.
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
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, TenantIdResolverBase.AllTenants);

                IAccount account = UseOperatingSystemAccount ?
                    PublicClientApplication.OperatingSystemAccount :
                    await GetAccountAsync(tenantId, requestContext.IsCaeEnabled, async, cancellationToken).ConfigureAwait(false);

                AuthenticationResult result = await Client.AcquireTokenSilentAsync(
                    requestContext.Scopes,
                    requestContext.Claims,
                    account,
                    tenantId,
                    requestContext.IsCaeEnabled,
                    async,
                    cancellationToken).ConfigureAwait(false);

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (MsalUiRequiredException ex)
            {
                throw scope.FailWrapAndThrow(
                    new CredentialUnavailableException(
                        $"{nameof(SharedTokenCacheCredential)} authentication unavailable. Token acquisition failed for user {Username}. Ensure that you have authenticated with a developer tool that supports Azure single sign on.",
                        ex));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async ValueTask<IAccount> GetAccountAsync(string tenantId, bool enableCae, bool async, CancellationToken cancellationToken)
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

            List<IAccount> accounts = await Client.GetAccountsAsync(async, enableCae, cancellationToken).ConfigureAwait(false);

            if (accounts.Count == 0)
            {
                throw new CredentialUnavailableException(NoAccountsInCacheMessage);
            }

            // filter the accounts to those matching the specified user and tenant
            List<IAccount> filteredAccounts = accounts.Where(a =>
                    // if _username is specified it must match the account
                    (string.IsNullOrEmpty(Username) || string.Compare(a.Username, Username, StringComparison.OrdinalIgnoreCase) == 0)
                    &&
                    // if _skipTenantValidation is false and _tenantId is specified it must match the account
                    (_skipTenantValidation || string.IsNullOrEmpty(tenantId) || string.Compare(a.HomeAccountId?.TenantId, tenantId, StringComparison.OrdinalIgnoreCase) == 0)
                )
                .ToList();

            if (_skipTenantValidation && filteredAccounts.Count > 1)
            {
                filteredAccounts = filteredAccounts
                    .Where(a => string.IsNullOrEmpty(tenantId) || string.Compare(a.HomeAccountId?.TenantId, tenantId, StringComparison.OrdinalIgnoreCase) == 0)
                    .ToList();
            }

            if (filteredAccounts.Count != 1)
            {
                throw new CredentialUnavailableException(GetCredentialUnavailableMessage(filteredAccounts));
            }

            account = filteredAccounts[0];
            asyncLock.SetValue(account);
            return account;
        }

        private string GetCredentialUnavailableMessage(List<IAccount> filteredAccounts)
        {
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(TenantId))
            {
                return string.Format(CultureInfo.InvariantCulture, MultipleAccountsInCacheMessage);
            }

            var usernameStr = string.IsNullOrEmpty(Username) ? string.Empty : $" username: {Username}";
            var tenantIdStr = string.IsNullOrEmpty(TenantId) ? string.Empty : $" tenantId: {TenantId}";

            if (filteredAccounts.Count == 0)
            {
                return string.Format(CultureInfo.InvariantCulture, NoMatchingAccountsInCacheMessage, usernameStr, tenantIdStr);
            }

            return string.Format(CultureInfo.InvariantCulture, MultipleMatchingAccountsInCacheMessage, usernameStr, tenantIdStr);
        }
    }
}
