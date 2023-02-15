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
    /// Enables authentication to Azure Active Directory using a client secret that was generated for an App Registration. More information on how
    /// to configure a client secret can be found here:
    /// https://docs.microsoft.com/azure/active-directory/develop/quickstart-configure-app-access-web-apis#add-credentials-to-your-web-application
    /// </summary>
    public class ClientSecretCredential : TokenCredential, ISupportsLogout
    {
        private readonly CredentialPipeline _pipeline;

        private IAccount _account;

        internal readonly string[] AdditionallyAllowedTenantIds;

        internal MsalConfidentialClient Client { get; }

        /// <summary>
        /// Gets the Azure Active Directory tenant (directory) Id of the service principal
        /// </summary>
        internal string TenantId { get; }

        /// <summary>
        /// Gets the client (application) ID of the service principal
        /// </summary>
        internal string ClientId { get; }

        /// <summary>
        /// Gets the client secret that was generated for the App Registration used to authenticate the client.
        /// </summary>
        internal string ClientSecret { get; }

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected ClientSecretCredential()
        {
        }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a client secret.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        public ClientSecretCredential(string tenantId, string clientId, string clientSecret)
            : this(tenantId, clientId, clientSecret, null, null, null)
        {
        }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a client secret.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientSecretCredential(string tenantId, string clientId, string clientSecret, ClientSecretCredentialOptions options)
            : this(tenantId, clientId, clientSecret, options, null, null)
        {
        }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a client secret.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientSecretCredential(string tenantId, string clientId, string clientSecret, TokenCredentialOptions options)
            : this(tenantId, clientId, clientSecret, options, null, null)
        {
        }

        internal ClientSecretCredential(string tenantId, string clientId, string clientSecret, TokenCredentialOptions options, CredentialPipeline pipeline, MsalConfidentialClient client)
        {
            Argument.AssertNotNull(clientId, nameof(clientId));
            Argument.AssertNotNull(clientSecret, nameof(clientSecret));
            TenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            ClientSecret = clientSecret;
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            Client = client ??
                     new MsalConfidentialClient(
                         _pipeline,
                         tenantId,
                         clientId,
                         clientSecret,
                         null,
                         options);

            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate. Acquired tokens are cached by the credential instance. Token lifetime and refreshing is handled automatically. Where possible, reuse credential instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("ClientSecretCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds);
                AuthenticationResult result = await Client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, true, cancellationToken).ConfigureAwait(false);

                _account = result.Account;

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate. Acquired tokens are cached by the credential instance. Token lifetime and refreshing is handled automatically. Where possible, reuse credential instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("ClientSecretCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds);
                AuthenticationResult result = Client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, false, cancellationToken).EnsureCompleted();

                _account = result.Account;

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

#pragma warning disable CA2119 // Seal methods that satisfy private interfaces
        /// <inheritdoc/>
        [ForwardsClientCalls(true)]
        public virtual async Task LogoutAsync(CancellationToken cancellationToken = default)
        {
            if (_account != null)
            {
                return;
            }
            await Client.RemoveUserAsync(_account, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        [ForwardsClientCalls(true)]
        public virtual void Logout(CancellationToken cancellationToken = default)
        {
            if (_account != null)
            {
                return;
            }
            Client.RemoveUser(_account, cancellationToken);
        }
#pragma warning restore CA2119 // Seal methods that satisfy private interfaces
    }
}
