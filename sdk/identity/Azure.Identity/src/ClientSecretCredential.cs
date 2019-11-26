// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using a client secret that was generated for an App Registration. More information on how
    /// to configure a client secret can be found here:
    /// https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-configure-app-access-web-apis#add-credentials-to-your-web-application
    /// </summary>
    public class ClientSecretCredential : TokenCredential
    {
        private readonly AadIdentityClient _client;
        private readonly CredentialPipeline _pipeline;

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
            : this(tenantId, clientId, clientSecret, (TokenCredentialOptions)null)
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
            : this (tenantId, clientId, clientSecret, CredentialPipeline.GetInstance(options))
        {
        }

        internal ClientSecretCredential(string tenantId, string clientId, string clientSecret, CredentialPipeline pipeline)
            : this(tenantId, clientId, clientSecret, pipeline, new AadIdentityClient(pipeline))
        {
        }

        internal ClientSecretCredential(string tenantId, string clientId, string clientSecret, CredentialPipeline pipeline, AadIdentityClient client)
        {
            TenantId = tenantId ?? throw new ArgumentNullException(nameof(tenantId));

            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            ClientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));

            _pipeline = pipeline;

            _client = client;
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.ClientSecretCredential.GetToken", requestContext);

            try
            {
                return scope.Succeeded(await _client.AuthenticateAsync(TenantId, ClientId, ClientSecret, requestContext.Scopes, cancellationToken).ConfigureAwait(false));
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);

                throw;
            }
            catch (Exception e)
            {
                throw scope.Failed(e);
            }
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.ClientSecretCredential.GetToken", requestContext);

            try
            {
                return scope.Succeeded(_client.Authenticate(TenantId, ClientId, ClientSecret, requestContext.Scopes, cancellationToken));
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);

                throw;
            }
            catch (Exception e)
            {
                throw scope.Failed(e);
            }
        }
    }
}
