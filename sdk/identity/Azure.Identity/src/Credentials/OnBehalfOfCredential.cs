// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using an On-Behalf-Of flow.
    /// </summary>
    public class OnBehalfOfCredential : TokenCredential, ISupportsClearAccountCache
    {
        internal MsalConfidentialClient Client { get; }
        private readonly string _tenantId;
        private readonly CredentialPipeline _pipeline;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly UserAssertion _userAssertion;
        private IAccount _account;
        internal readonly string[] AdditionallyAllowedTenantIds;

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected OnBehalfOfCredential()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="OnBehalfOfCredential"/> with the details needed to authenticate against Azure Active Directory with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificate">The authentication X509 Certificate of the service principal</param>
        /// <param name="userAssertion">The access token that will be used by <see cref="OnBehalfOfCredential"/> as the user assertion when requesting On-Behalf-Of tokens.</param>
        public OnBehalfOfCredential(string tenantId, string clientId, X509Certificate2 clientCertificate, string userAssertion)
            : this(tenantId, clientId, clientCertificate, userAssertion, null, null, null)
        { }

        /// <summary>
        /// Creates an instance of the <see cref="OnBehalfOfCredential"/> with the details needed to authenticate against Azure Active Directory with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificate">The authentication X509 Certificate of the service principal</param>
        /// <param name="userAssertion">The access token that will be used by <see cref="OnBehalfOfCredential"/> as the user assertion when requesting On-Behalf-Of tokens.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public OnBehalfOfCredential(string tenantId, string clientId, X509Certificate2 clientCertificate, string userAssertion, OnBehalfOfCredentialOptions options)
            : this(tenantId, clientId, clientCertificate, userAssertion, options, null, null)
        { }

        /// <summary>
        /// Creates an instance of the <see cref="OnBehalfOfCredential"/> with the details needed to authenticate with Azure Active Directory.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="userAssertion">The access token that will be used by <see cref="OnBehalfOfCredential"/> as the user assertion when requesting On-Behalf-Of tokens.</param>
        public OnBehalfOfCredential(
            string tenantId,
            string clientId,
            string clientSecret,
            string userAssertion)
            : this(tenantId, clientId, clientSecret, userAssertion, null, null, null)
        { }

        /// <summary>
        /// Creates an instance of the <see cref="OnBehalfOfCredential"/> with the details needed to authenticate with Azure Active Directory.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="userAssertion">The access token that will be used by <see cref="OnBehalfOfCredential"/> as the user assertion when requesting On-Behalf-Of tokens.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public OnBehalfOfCredential(
            string tenantId,
            string clientId,
            string clientSecret,
            string userAssertion,
            OnBehalfOfCredentialOptions options)
            : this(tenantId, clientId, clientSecret, userAssertion, options, null, null)
        { }

        internal OnBehalfOfCredential(
            string tenantId,
            string clientId,
            X509Certificate2 certificate,
            string userAssertion,
            OnBehalfOfCredentialOptions options,
            CredentialPipeline pipeline,
            MsalConfidentialClient client)
            : this(
                tenantId,
                clientId,
                new X509Certificate2FromObjectProvider(certificate ?? throw new ArgumentNullException(nameof(certificate))),
                userAssertion,
                options,
                pipeline,
                client)
        { }

        internal OnBehalfOfCredential(
            string tenantId,
            string clientId,
            IX509Certificate2Provider certificateProvider,
            string userAssertion,
            OnBehalfOfCredentialOptions options,
            CredentialPipeline pipeline,
            MsalConfidentialClient client)
        {
            _tenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            options ??= new OnBehalfOfCredentialOptions();
            _userAssertion = new UserAssertion(userAssertion);

            Client = client ??
                      new MsalConfidentialClient(
                          _pipeline,
                          tenantId,
                          clientId,
                          certificateProvider,
                          options.SendCertificateChain,
                          options);

            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
        }

        internal OnBehalfOfCredential(
            string tenantId,
            string clientId,
            string clientSecret,
            string userAssertion,
            OnBehalfOfCredentialOptions options,
            CredentialPipeline pipeline,
            MsalConfidentialClient client)
        {
            Argument.AssertNotNull(clientId, nameof(clientId));
            Argument.AssertNotNull(clientSecret, nameof(clientSecret));

            options ??= new OnBehalfOfCredentialOptions();
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            _tenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            _clientId = clientId;
            _clientSecret = clientSecret;
            _userAssertion = new UserAssertion(userAssertion);
            Client = client ?? new MsalConfidentialClient(_pipeline, _tenantId, _clientId, _clientSecret, null, options);

            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds(options?.AdditionallyAllowedTenants);
        }

        /// <summary>
        /// Authenticates with Azure Active Directory and returns an access token if successful.
        /// Acquired tokens are cached by the credential instance. Token lifetime and refreshing is
        /// handled automatically. Where possible, reuse credential instances to optimize cache
        /// effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
            GetTokenInternalAsync(requestContext, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Authenticates with Azure Active Directory and returns an access token if successful.
        /// Acquired tokens are cached by the credential instance. Token lifetime and refreshing is
        /// handled automatically. Where possible, reuse credential instances to optimize cache
        /// effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
            GetTokenInternalAsync(requestContext, true, cancellationToken);

#pragma warning disable CA2119 // Seal methods that satisfy private interfaces
        /// <inheritdoc/>
        [ForwardsClientCalls(true)]
        public virtual async Task ClearAccountCacheAsync(CancellationToken cancellationToken = default)
        {
            if (_account != null)
            {
                return;
            }
            await Client.RemoveUserAsync(_account, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        [ForwardsClientCalls(true)]
        public virtual void ClearAccountCache(CancellationToken cancellationToken = default)
        {
            if (_account != null)
            {
                return;
            }
            Client.RemoveUser(_account, cancellationToken);
        }
#pragma warning restore CA2119 // Seal methods that satisfy private interfaces

        internal async ValueTask<AccessToken> GetTokenInternalAsync(TokenRequestContext requestContext, bool async, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("OnBehalfOfCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(_tenantId, requestContext, AdditionallyAllowedTenantIds);

                AuthenticationResult result = await Client
                    .AcquireTokenOnBehalfOfAsync(requestContext.Scopes, tenantId, _userAssertion, async, cancellationToken)
                    .ConfigureAwait(false);

                _account = result.Account;

                return new AccessToken(result.AccessToken, result.ExpiresOn);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }
    }
}
