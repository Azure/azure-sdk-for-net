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
        private string _tenantId;
        private string _clientId;
        private string _clientSecret;
        private AadIdentityClient _client;


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
            _tenantId = tenantId;
            _clientId = clientId;
            _clientSecret = clientSecret;

            _client = (options != null) ? new AadIdentityClient(options) : AadIdentityClient.SharedClient;
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            return await this._client.AuthenticateAsync(_tenantId, _clientId, _clientSecret, scopes, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client secret to authenticate.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return this._client.Authenticate(_tenantId, _clientId, _clientSecret, scopes, cancellationToken);
        }
    }
}
