// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Used to acquire token using client secret associated with an Azure AD application.
    /// </summary>
    internal class ClientSecretAccessTokenProvider : NonInteractiveAzureServiceTokenProviderBase
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _tenantId;
        private readonly string _azureAdInstance;
        private readonly IAuthenticationContext _authenticationContext;

        internal ClientSecretAccessTokenProvider(string clientId, string clientSecret,
            string tenantId, string azureAdInstance, IAuthenticationContext authenticationContext = null)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }

            _clientId = clientId;
            _clientSecret = clientSecret;
            _tenantId = tenantId;
            _azureAdInstance = azureAdInstance;
            _authenticationContext = authenticationContext ?? new AdalAuthenticationContext();

            PrincipalUsed = new Principal
            {
                Type = "App",
                AppId = _clientId
            };
        }

        public override async Task<AppAuthenticationResult> GetAuthResultAsync(string resource, string authority,
            CancellationToken cancellationToken = default)
        {
            string errorMessage = string.Empty;

            try
            {
                // If authority is not specified, create it using azureAdInstance and tenant Id. Tenant ID comes from the connection string. 
                if (string.IsNullOrWhiteSpace(authority))
                {
                    authority = $"{_azureAdInstance}{_tenantId}";
                }

                ClientCredential clientCredential = new ClientCredential(_clientId, _clientSecret);

                var authResult = await _authenticationContext.AcquireTokenAsync(authority, resource, clientCredential).ConfigureAwait(false);

                var accessToken = authResult?.AccessToken;

                if (accessToken != null)
                {
                    PrincipalUsed.IsAuthenticated = true;
                    PrincipalUsed.TenantId = AccessToken.Parse(accessToken).TenantId;

                    return authResult;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            // The exception will have the connection string, but with the secret redacted. 
            throw new AzureServiceTokenProviderException(ConnectionString?.Replace(_clientSecret, "<<Redacted>>"), 
                resource, authority, $"{AzureServiceTokenProviderException.GenericErrorMessage} {errorMessage}");

        }
    }
}
