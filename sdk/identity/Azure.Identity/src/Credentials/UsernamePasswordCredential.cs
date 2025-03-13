// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Identity.Client;
using System;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using System.ComponentModel;

namespace Azure.Identity
{
    /// <summary>
    ///  Enables authentication to Microsoft Entra ID using a user's username and password. If the user has MFA enabled this
    ///  credential will fail to get a token throwing an <see cref="AuthenticationFailedException"/>. Also, this credential requires a high degree of
    ///  trust and is not recommended outside of prototyping when more secure credentials can be used.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This credential is deprecated because it doesn't support multifactor authentication (MFA). See https://aka.ms/azsdk/identity/mfa for details about MFA enforcement for Microsoft Entra ID and migration guidance.")]
    public class UsernamePasswordCredential : TokenCredential
    {
        private const string NoDefaultScopeMessage = "Authenticating in this environment requires specifying a TokenRequestContext.";
        private const string Troubleshooting = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/usernamepasswordcredential/troubleshoot";

        private readonly string _clientId;
        private readonly CredentialPipeline _pipeline;
        private readonly string _username;
        private readonly string _password;
        private AuthenticationRecord _record;
        private readonly string _tenantId;
        internal string[] AdditionallyAllowedTenantIds { get; }
        internal MsalPublicClient Client { get; }
        internal string DefaultScope { get; }
        internal TenantIdResolverBase TenantIdResolver { get; }

        /// <summary>
        /// Protected constructor for mocking
        /// </summary>
        protected UsernamePasswordCredential()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="UsernamePasswordCredential"/> with the details needed to authenticate against Microsoft Entra ID with a simple username
        /// and password.
        /// </summary>
        /// <param name="username">The user account's username, also known as UPN.</param>
        /// <param name="password">The user account's password.</param>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID or name.</param>
        /// <param name="clientId">The client (application) ID of an App Registration in the tenant.</param>
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId)
            : this(username, password, tenantId, clientId, (TokenCredentialOptions)null)
        { }

        /// <summary>
        /// Creates an instance of the <see cref="UsernamePasswordCredential"/> with the details needed to authenticate against Microsoft Entra ID with a simple username
        /// and password.
        /// </summary>
        /// <param name="username">The user account's user name, UPN.</param>
        /// <param name="password">The user account's password.</param>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID or name.</param>
        /// <param name="clientId">The client (application) ID of an App Registration in the tenant.</param>
        /// <param name="options">The client options for the newly created UsernamePasswordCredential</param>
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId, TokenCredentialOptions options)
            : this(username, password, tenantId, clientId, options, null, null)
        { }

        /// <summary>
        /// Creates an instance of the <see cref="UsernamePasswordCredential"/> with the details needed to authenticate against Microsoft Entra ID with a simple username
        /// and password.
        /// </summary>
        /// <param name="username">The user account's user name, UPN.</param>
        /// <param name="password">The user account's password.</param>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID or name.</param>
        /// <param name="clientId">The client (application) ID of an App Registration in the tenant.</param>
        /// <param name="options">The client options for the newly created UsernamePasswordCredential</param>
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId, UsernamePasswordCredentialOptions options)
            : this(username, password, tenantId, clientId, options, null, null)
        { }

        internal UsernamePasswordCredential(
            string username,
            string password,
            string tenantId,
            string clientId,
            TokenCredentialOptions options,
            CredentialPipeline pipeline,
            MsalPublicClient client)
        {
            Argument.AssertNotNull(username, nameof(username));
            Argument.AssertNotNull(password, nameof(password));
            Argument.AssertNotNull(clientId, nameof(clientId));
            _tenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));

            _username = username;
            _password = password;
            _clientId = clientId;
            if (options is UsernamePasswordCredentialOptions usernamePasswordOptions && usernamePasswordOptions.AuthenticationRecord != null)
            {
                _record = usernamePasswordOptions.AuthenticationRecord;
            }
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            DefaultScope = AzureAuthorityHosts.GetDefaultScope(options?.AuthorityHost ?? AzureAuthorityHosts.GetDefault());
            Client = client ?? new MsalPublicClient(_pipeline, tenantId, clientId, null, options);

            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
        }

        /// <summary>
        /// Authenticates the user using the specified username and password.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual AuthenticationRecord Authenticate(CancellationToken cancellationToken = default)
        {
            // throw if no default scope exists
            if (DefaultScope == null)
            {
                throw new CredentialUnavailableException(NoDefaultScopeMessage);
            }

            return Authenticate(new TokenRequestContext(new string[] { DefaultScope }), cancellationToken);
        }

        /// <summary>
        /// Authenticates the user using the specified username and password.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(CancellationToken cancellationToken = default)
        {
            // throw if no default scope exists
            if (DefaultScope == null)
            {
                throw new CredentialUnavailableException(NoDefaultScopeMessage);
            }

            return await AuthenticateAsync(new TokenRequestContext(new string[] { DefaultScope }), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Authenticates the user using the specified username and password.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual AuthenticationRecord Authenticate(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            AuthenticateImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
            return _record;
        }

        /// <summary>
        /// Authenticates the user using the specified username and password.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            await AuthenticateImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
            return _record;
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them using the provided username and password. Acquired tokens are
        /// <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the credential instance. Token lifetime and
        /// refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed, particularly if the specified user account has MFA enabled.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them using the provided username and password. Acquired tokens are
        /// <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the credential instance. Token lifetime and
        /// refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed, particularly if the specified user account has MFA enabled.</exception>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async Task<AuthenticationResult> AuthenticateImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope($"{nameof(UsernamePasswordCredential)}.{nameof(Authenticate)}", requestContext);
            try
            {
                var tenantId = TenantIdResolver.Resolve(_tenantId, requestContext, AdditionallyAllowedTenantIds);

                AuthenticationResult result = await Client
                    .AcquireTokenByUsernamePasswordAsync(requestContext.Scopes, requestContext.Claims, _username, _password, tenantId, requestContext.IsCaeEnabled, async, cancellationToken)
                    .ConfigureAwait(false);

                _record = new AuthenticationRecord(result, _clientId);
                return result;
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, Troubleshooting);
            }
        }

        private async Task<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("UsernamePasswordCredential.GetToken", requestContext);
            try
            {
                AuthenticationResult result;
                if (_record != null)
                {
                    var tenantId = TenantIdResolver.Resolve(_tenantId, requestContext, AdditionallyAllowedTenantIds);
                    try
                    {
                        result = await Client.AcquireTokenSilentAsync(
                            requestContext.Scopes,
                            requestContext.Claims,
                            _record,
                            tenantId,
                            requestContext.IsCaeEnabled,
                            requestContext,
                            async,
                            cancellationToken)
                            .ConfigureAwait(false);
                        return scope.Succeeded(result.ToAccessToken());
                    }
                    catch (MsalUiRequiredException msalEx)
                    {
                        AzureIdentityEventSource.Singleton.UsernamePasswordCredentialAcquireTokenSilentFailed(msalEx);
                        // fall through so that AuthenticateImplAsync is called.
                    }
                }
                result = await AuthenticateImplAsync(async, requestContext, cancellationToken).ConfigureAwait(false);
                return scope.Succeeded(result.ToAccessToken());
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, Troubleshooting);
            }
        }
    }
}
