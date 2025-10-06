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
    /// Authenticates by redeeming an authorization code previously obtained from Microsoft Entra ID. See
    /// <seealso href="https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow" /> for more information
    /// about the authorization code authentication flow.
    /// </summary>
    public class AuthorizationCodeCredential : TokenCredential
    {
        private readonly string _authCode;
        private readonly string _clientId;
        private readonly CredentialPipeline _pipeline;
        private AuthenticationRecord _record;
        internal MsalConfidentialClient Client { get; }
        private readonly string _redirectUri;
        private readonly string _tenantId;
        internal readonly string[] AdditionallyAllowedTenantIds;
        internal TenantIdResolverBase TenantIdResolver { get; }

        /// <summary>
        /// Protected constructor for <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        protected AuthorizationCodeCredential()
        {
        }

        /// <summary>
        /// Creates an instance of the AuthorizationCodeCredential with the details needed to authenticate against Microsoft Entra ID with a prefetched authorization code.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="authorizationCode">The authorization code obtained from a call to authorize. The code should be obtained with all required scopes.
        /// See https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow for more information.</param>
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode)
            : this(tenantId, clientId, clientSecret, authorizationCode, null)
        {
        }

        /// <summary>
        /// Creates an instance of the AuthorizationCodeCredential with the details needed to authenticate against Microsoft Entra ID with a prefetched authorization code.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="authorizationCode">The authorization code obtained from a call to authorize. The code should be obtained with all required scopes.
        /// See <see href="https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow" /> for more information.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        public AuthorizationCodeCredential(
            string tenantId,
            string clientId,
            string clientSecret,
            string authorizationCode,
            AuthorizationCodeCredentialOptions options) : this(tenantId, clientId, clientSecret, authorizationCode, options, null)
        { }

        /// <summary>
        /// Creates an instance of the AuthorizationCodeCredential with the details needed to authenticate against Microsoft Entra ID with a prefetched authorization code.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="authorizationCode">The authorization code obtained from a call to authorize. The code should be obtained with all required scopes.
        /// See <see href="https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow" /> for more information.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
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
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
        }

        /// <summary>
        /// Obtains a token from Microsoft Entra ID, using the specified authorization code to authenticate. Acquired tokens are
        /// <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the credential instance. Token lifetime and
        /// refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a token from Microsoft Entra ID, using the specified authorization code to authenticate. Acquired tokens are
        /// <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the credential instance. Token lifetime and
        /// refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope($"{nameof(AuthorizationCodeCredential)}.{nameof(GetToken)}", requestContext);

            AccessToken token;
            string tenantId = null;
            try
            {
                tenantId = TenantIdResolver.Resolve(_tenantId, requestContext, AdditionallyAllowedTenantIds);

                if (_record is null)
                {
                    token = await AcquireTokenWithCode(async, requestContext,tenantId, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    AuthenticationResult result = await Client
                        .AcquireTokenSilentAsync(requestContext.Scopes, (AuthenticationAccount)_record, tenantId, _redirectUri, requestContext.Claims, requestContext.IsCaeEnabled, async, cancellationToken)
                        .ConfigureAwait(false);
                    token = result.ToAccessToken();
                }

                return scope.Succeeded(token);
            }
            catch (MsalUiRequiredException)
            {
                // This occurs when we have an auth record but the cae or ncae cache entry is missing
                // fall through to the acquire call below
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }

            try
            {
                token = await AcquireTokenWithCode(async, requestContext, tenantId, cancellationToken).ConfigureAwait(false);
                return scope.Succeeded(token);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async Task<AccessToken> AcquireTokenWithCode(bool async, TokenRequestContext requestContext, string tenantId, CancellationToken cancellationToken)
        {
            AuthenticationResult result = await Client
                                    .AcquireTokenByAuthorizationCodeAsync(
                                        scopes: requestContext.Scopes,
                                        code: _authCode,
                                        tenantId: tenantId,
                                        redirectUri: _redirectUri,
                                        claims: requestContext.Claims,
                                        enableCae: requestContext.IsCaeEnabled,
                                        async,
                                        cancellationToken)
                                    .ConfigureAwait(false);
            _record = new AuthenticationRecord(result, _clientId);
            return result.ToAccessToken();
        }
    }
}
