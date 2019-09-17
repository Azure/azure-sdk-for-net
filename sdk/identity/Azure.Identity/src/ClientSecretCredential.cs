// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using a client secret that was generated for an App Registration.  More information on how
    /// to configure a client secret can be found here:
    /// https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-configure-app-access-web-apis#add-credentials-to-your-web-application
    /// </summary>
    public class ClientSecretCredential : TokenCredential
    {
        private readonly AadIdentityClient _client;

        /// <summary>
        /// Gets the Azure Active Directory tenant (directory) Id of the service principal
        /// </summary>
        public string TenantId { get; }

        /// <summary>
        /// Gets the client (application) ID of the service principal
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        /// Gets the client secret that was generated for the App Registration used to authenticate the client.
        /// </summary>
        public string ClientSecret { get; }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a client secret.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        public ClientSecretCredential(string tenantId, string clientId, string clientSecret)
            : this(tenantId, clientId, clientSecret, null)
        {
        }

        /// <summary>
        /// Creates an instance of the ClientSecretCredential with the details needed to authenticate against Azure Active Directory with a client secret.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientSecret">A client secret that was generated for the App Registration used to authenticate the client.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientSecretCredential(string tenantId, string clientId, string clientSecret, IdentityClientOptions options)
        {
            TenantId = tenantId;
            ClientId = clientId;
            ClientSecret = clientSecret;

            _client = (options != null) ? new AadIdentityClient(options) : AadIdentityClient.SharedClient;
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate.
        /// </summary>
        /// <param name="request">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async Task<AccessToken> GetTokenAsync(TokenRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.AuthenticateAsync(TenantId, ClientId, ClientSecret, request.Scopes, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate.
        /// </summary>
        /// <param name="request">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequest request, CancellationToken cancellationToken = default)
        {
            return _client.Authenticate(TenantId, ClientId, ClientSecret, request.Scopes, cancellationToken);
        }
    }
}
