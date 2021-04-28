// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    ///
    /// </summary>
    public class OnBehalfOfCredential : TokenCredential
    {
        private readonly MsalConfidentialClient _client;
        private readonly string _tenantId;
        private readonly CredentialPipeline _pipeline;
        private readonly bool _allowMultiTenantAuthentication;

        /// <inheritdoc />
        public override bool SupportsCaching => true;

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected OnBehalfOfCredential()
        { }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a client secret.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public OnBehalfOfCredential(
            string tenantId,
            string clientId,
            string clientSecret,
            TokenCredentialOptions options = null)
            : this(tenantId, clientId, clientSecret, options, null, null)
        { }

        internal OnBehalfOfCredential(
            string tenantId,
            string clientId,
            string clientSecret,
            TokenCredentialOptions options,
            CredentialPipeline pipeline,
            MsalConfidentialClient client)
        {
            Argument.AssertNotNull(clientId, nameof(clientId));
            Argument.AssertNotNull(clientSecret, nameof(clientSecret));

            options ??= new TokenCredentialOptions();
            _allowMultiTenantAuthentication = options.AllowMultiTenantAuthentication;
            _tenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            _client = client ?? new MsalConfidentialClient(_pipeline, tenantId, clientId, clientSecret, options as ITokenCacheOptions);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenInternalAsync(requestContext, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenInternalAsync(requestContext, true, cancellationToken);
        }

        internal async ValueTask<AccessToken> GetTokenInternalAsync(TokenRequestContext requestContext, bool async, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("OnBehalfOfCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(_tenantId, requestContext, _allowMultiTenantAuthentication);

                AuthenticationResult result = await _client
                    .AcquireTokenOnBehalfOf(requestContext.Scopes, tenantId, UserAssertionScope.Current.UserAssertion, async, cancellationToken)
                    .ConfigureAwait(false);

                return new AccessToken(result.AccessToken, result.ExpiresOn);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }
    }
}
