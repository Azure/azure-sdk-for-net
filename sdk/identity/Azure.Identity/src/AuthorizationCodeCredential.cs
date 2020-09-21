// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Authenticates by redeeming and authorization code previously obtained from Azure Active Directory.  See
    /// https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-auth-code-flow for more information
    /// about the autorization code authentication flow.
    /// </summary>
    public class AuthorizationCodeCredential : TokenCredential
    {
        private readonly IConfidentialClientApplication _confidentialClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly string _authCode;
        private readonly string _clientId;
        private readonly CredentialPipeline _pipeline;
        private AuthenticationRecord _record;

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
        /// See https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-auth-code-flow for more information.</param>
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
        /// See https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-auth-code-flow for more information.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode, TokenCredentialOptions options)
        {
            if (tenantId is null) throw new ArgumentNullException(nameof(tenantId));
            if (clientSecret is null) throw new ArgumentNullException(nameof(clientSecret));

            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            _authCode = authorizationCode ?? throw new ArgumentNullException(nameof(authorizationCode));

            options ??= new TokenCredentialOptions();

            _pipeline = CredentialPipeline.GetInstance(options);

            _confidentialClient = ConfidentialClientApplicationBuilder.Create(clientId).WithHttpClientFactory(new HttpPipelineClientFactory(_pipeline.HttpPipeline)).WithTenantId(tenantId).WithClientSecret(clientSecret).Build();

            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified authorization code authenticate. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified authorization code authenticate. This method is called by Azure SDK clients. It isn't intended for use in application code.
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
                AccessToken token = default;

                if (_record is null)
                {
                    AuthenticationResult result = await _confidentialClient.AcquireTokenByAuthorizationCode(requestContext.Scopes, _authCode).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);

                    _record = new AuthenticationTokenRecord(result, _clientId);

                    token = new AccessToken(result.AccessToken, result.ExpiresOn);
                }
                else
                {
                    AuthenticationResult result = await _confidentialClient.AcquireTokenSilent(requestContext.Scopes, (AuthenticationAccount)_record).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);

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
