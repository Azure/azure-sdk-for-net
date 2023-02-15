// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Authenticates by redeeming an authorization code previously obtained from Azure Active Directory. See
    /// <seealso href="https://docs.microsoft.com/azure/active-directory/develop/v2-oauth2-auth-code-flow" /> for more information
    /// about the authorization code authentication flow.
    /// </summary>
    public class AuthorizationCodeCredential : TokenCredential, ISupportsLogout
    {
        private readonly string _authCode;
        private readonly string _clientId;
        private readonly CredentialPipeline _pipeline;
        private AuthenticationRecord _record;
        internal MsalConfidentialClient Client { get; }
        private readonly string _redirectUri;
        private readonly string _tenantId;
        internal readonly string[] AdditionallyAllowedTenantIds;

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected AuthorizationCodeCredential()
        {
        }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a prefetched authorization code.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="authorizationCode">The authorization code obtained from a call to authorize. The code should be obtained with all required scopes.
        /// See https://docs.microsoft.com/azure/active-directory/develop/v2-oauth2-auth-code-flow for more information.</param>
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode)
            : this(tenantId, clientId, clientSecret, authorizationCode, null)
        {
        }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a prefetched authorization code.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="authorizationCode">The authorization code obtained from a call to authorize. The code should be obtained with all required scopes.
        /// See https://docs.microsoft.com/azure/active-directory/develop/v2-oauth2-auth-code-flow for more information.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public AuthorizationCodeCredential(
            string tenantId,
            string clientId,
            string clientSecret,
            string authorizationCode,
            AuthorizationCodeCredentialOptions options) : this(tenantId, clientId, clientSecret, authorizationCode, options, null)
        { }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a prefetched authorization code.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="authorizationCode">The authorization code obtained from a call to authorize. The code should be obtained with all required scopes.
        /// See https://docs.microsoft.com/azure/active-directory/develop/v2-oauth2-auth-code-flow for more information.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode, TokenCredentialOptions options)
            : this(tenantId, clientId, clientSecret, authorizationCode, options, null)
        { }

        internal AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode, TokenCredentialOptions options, MsalConfidentialClient client, CredentialPipeline pipeline = null)
        {
            Validations.ValidateTenantId(tenantId, nameof(tenantId));
            _tenantId = tenantId;
            Argument.AssertNotNull(clientSecret, nameof(clientSecret));
            Argument.AssertNotNull(clientId, nameof(clientId));
            Argument.AssertNotNull(authorizationCode, nameof(authorizationCode));
            _clientId = clientId;
            _authCode = authorizationCode;
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options ?? new TokenCredentialOptions());
            _redirectUri = options switch
            {
                AuthorizationCodeCredentialOptions o => o.RedirectUri?.AbsoluteUri,
                _ => null
            };

            Client = client ??
                      new MsalConfidentialClient(
                          _pipeline,
                          tenantId,
                          clientId,
                          clientSecret,
                          _redirectUri,
                          options);

            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified authorization code to authenticate. Acquired tokens
        /// are cached by the credential instance. Token lifetime and refreshing is handled automatically. Where possible, reuse credential
        /// instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

#pragma warning disable CA2119 // Seal methods that satisfy private interfaces
        /// <inheritdoc/>
        [ForwardsClientCalls(true)]
        public virtual async Task LogoutAsync(CancellationToken cancellationToken = default)
        {
            if (_record == null)
            {
                return;
            }

            await Client.RemoveUserAsync(new AuthenticationAccount(_record), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        [ForwardsClientCalls(true)]
        public virtual void Logout(CancellationToken cancellationToken = default)
        {
            if (_record == null)
            {
                return;
            }

            Client.RemoveUser(new AuthenticationAccount(_record), cancellationToken);
        }
#pragma warning restore CA2119 // Seal methods that satisfy private interfaces

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified authorization code to authenticate. Acquired tokens
        /// are cached by the credential instance. Token lifetime and refreshing is handled automatically. Where possible, reuse credential
        /// instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope($"{nameof(AuthorizationCodeCredential)}.{nameof(GetToken)}", requestContext);

            try
            {
                AccessToken token;
                var tenantId = TenantIdResolver.Resolve(_tenantId, requestContext, AdditionallyAllowedTenantIds);

                if (_record is null)
                {
                    AuthenticationResult result = await Client
                        .AcquireTokenByAuthorizationCodeAsync(requestContext.Scopes, _authCode, tenantId, _redirectUri, async, cancellationToken)
                        .ConfigureAwait(false);
                    _record = new AuthenticationRecord(result, _clientId);

                    token = new AccessToken(result.AccessToken, result.ExpiresOn);
                }
                else
                {
                    AuthenticationResult result = await Client
                        .AcquireTokenSilentAsync(requestContext.Scopes, (AuthenticationAccount)_record, tenantId, _redirectUri, async, cancellationToken)
                        .ConfigureAwait(false);
                    token = new AccessToken(result.AccessToken, result.ExpiresOn);
                }

                return scope.Succeeded(token);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }
    }
}
