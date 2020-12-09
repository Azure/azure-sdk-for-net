// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Identity.Client;
using System;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    ///  Enables authentication to Azure Active Directory using a user's username and password. If the user has MFA enabled this
    ///  credential will fail to get a token throwing an <see cref="AuthenticationFailedException"/>. Also, this credential requires a high degree of
    ///  trust and is not recommended outside of prototyping when more secure credentials can be used.
    /// </summary>
    public class UsernamePasswordCredential : TokenCredential
    {
        private const string NoDefaultScopeMessage = "Authenticating in this environment requires specifying a TokenRequestContext.";

        private readonly string _clientId;
        private readonly MsalPublicClient _client;
        private readonly CredentialPipeline _pipeline;
        private readonly string _username;
        private readonly SecureString _password;
        private AuthenticationRecord _record;

        /// <summary>
        /// Protected constructor for mocking
        /// </summary>
        protected UsernamePasswordCredential()
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="UsernamePasswordCredential"/> with the details needed to authenticate against Azure Active Directory with a simple username
        /// and password.
        /// </summary>
        /// <param name="username">The user account's username, also known as UPN.</param>
        /// <param name="password">The user account's password.</param>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) ID or name.</param>
        /// <param name="clientId">The client (application) ID of an App Registration in the tenant.</param>
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId)
            : this(username, password, tenantId, clientId, (TokenCredentialOptions)null)
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="UsernamePasswordCredential"/> with the details needed to authenticate against Azure Active Directory with a simple username
        /// and password.
        /// </summary>
        /// <param name="username">The user account's user name, UPN.</param>
        /// <param name="password">The user account's password.</param>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) ID or name.</param>
        /// <param name="clientId">The client (application) ID of an App Registration in the tenant.</param>
        /// <param name="options">The client options for the newly created UsernamePasswordCredential</param>
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId, TokenCredentialOptions options)
            : this(username, password, tenantId, clientId, options, null, null)
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="UsernamePasswordCredential"/> with the details needed to authenticate against Azure Active Directory with a simple username
        /// and password.
        /// </summary>
        /// <param name="username">The user account's user name, UPN.</param>
        /// <param name="password">The user account's password.</param>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) ID or name.</param>
        /// <param name="clientId">The client (application) ID of an App Registration in the tenant.</param>
        /// <param name="options">The client options for the newly created UsernamePasswordCredential</param>
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId, UsernamePasswordCredentialOptions options)
            : this(username, password, tenantId, clientId, options, null, null)
        {
        }

        internal UsernamePasswordCredential(string username, string password, string tenantId, string clientId, TokenCredentialOptions options, CredentialPipeline pipeline, MsalPublicClient client)
        {
            _username = username ?? throw new ArgumentNullException(nameof(username));

            _password = (password != null) ? password.ToSecureString() : throw new ArgumentNullException(nameof(password));

            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            Validations.ValidateTenantId(tenantId, nameof(tenantId));

            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);

            _client = client ?? new MsalPublicClient(_pipeline, tenantId, clientId, null, options as ITokenCacheOptions);
        }

        /// <summary>
        /// Authenticates the user using the specified username and password.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual AuthenticationRecord Authenticate(CancellationToken cancellationToken = default)
        {
            // get the default scope for the authority, throw if no default scope exists
            string defaultScope = AzureAuthorityHosts.GetDefaultScope(_pipeline.AuthorityHost) ?? throw new CredentialUnavailableException(NoDefaultScopeMessage);

            return Authenticate(new TokenRequestContext(new string[] { defaultScope }), cancellationToken);
        }

        /// <summary>
        /// Authenticates the user using the specified username and password.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(CancellationToken cancellationToken = default)
        {
            // get the default scope for the authority, throw if no default scope exists
            string defaultScope = AzureAuthorityHosts.GetDefaultScope(_pipeline.AuthorityHost) ?? throw new CredentialUnavailableException(NoDefaultScopeMessage);

            return await AuthenticateAsync(new TokenRequestContext(new string[] { defaultScope }), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Authenticates the user using the specified username and password.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual AuthenticationRecord Authenticate(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return AuthenticateImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Authenticates the user using the specified username and password.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await AuthenticateImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them using the given username and password.  Note: This will fail with
        /// an <see cref="AuthenticationFailedException"/> if the specified user account has MFA enabled. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them using the given username and password.  Note: This will fail with
        /// an <see cref="AuthenticationFailedException"/> if the specified user account has MFA enabled. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async Task<AuthenticationRecord> AuthenticateImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope($"{nameof(UsernamePasswordCredential)}.{nameof(Authenticate)}", requestContext);

            try
            {
                scope.Succeeded(await GetTokenImplAsync(async, requestContext, cancellationToken).ConfigureAwait(false));

                return _record;
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async Task<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("UsernamePasswordCredential.GetToken", requestContext);

            try
            {
                AuthenticationResult result = await _client
                    .AcquireTokenByUsernamePasswordAsync(requestContext.Scopes, _username, _password, async, cancellationToken)
                    .ConfigureAwait(false);

                _record = new AuthenticationRecord(result, _clientId);

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }
    }
}
