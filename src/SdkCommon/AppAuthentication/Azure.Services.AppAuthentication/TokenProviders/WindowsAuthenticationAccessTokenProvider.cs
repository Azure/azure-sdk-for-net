// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Uses Integrated Windows Authentication to get access token. 
    /// </summary>
    internal class WindowsAuthenticationAzureServiceTokenProvider : NonInteractiveAzureServiceTokenProviderBase
    {
        private readonly IAuthenticationContext _authenticationContext;
        private readonly string _azureAdInstance;
        private const string ClientId = "d7813711-9094-4ad3-a062-cac3ec74ebe8";

        // Current user's home tenant. 
        private static string _currentUserTenant;

        internal WindowsAuthenticationAzureServiceTokenProvider(IAuthenticationContext authenticationContext, string azureAdInstance)
        {
            _authenticationContext = authenticationContext;
            _azureAdInstance = azureAdInstance;
            
            PrincipalUsed = new Principal {Type = "User"};
        }
        
        /// <summary>
        /// Get access token by authenticating to Azure AD using Integrated Windows Authentication (IWA), 
        /// when domain is synced with Azure AD tenant. 
        /// </summary>
        /// <param name="resource">Resource to access.</param>
        /// <param name="authority">Authority where resource is present.</param>
        /// <returns></returns>
        public override async Task<string> GetTokenAsync(string resource, string authority)
        {
            // If authority is not specified, start with common. Once known, after the first time token is acquired, use that. 
            if (string.IsNullOrWhiteSpace(authority))
            {
                authority = string.IsNullOrEmpty(_currentUserTenant) ? $"{_azureAdInstance}common" : $"{_azureAdInstance}{_currentUserTenant}";
            }

            // Use ADAL's default token cache, instead of file based cache.
            // This prevents dependency on file and DPAPI, and enables service account scenarios. 
            string accessToken = null;

            try
            {
                // See if token is present in cache
                accessToken = await _authenticationContext.AcquireTokenSilentAsync(authority, resource, ClientId).ConfigureAwait(false);

            }
            catch
            {
                // If fails, use AcquireTokenAsync
            }

            // If token not in cache, acquire it
            if (accessToken == null)
            {
                // This causes ADAL to use IWA
                UserCredential userCredential = new UserCredential();

                try
                {
                    accessToken = await _authenticationContext.AcquireTokenAsync(authority, resource, ClientId, userCredential).ConfigureAwait(false);
                }
                catch (Exception exp)
                {
                    string message = $"{AzureServiceTokenProviderException.ActiveDirectoryIntegratedAuthUsed} " +
                                     $"{AzureServiceTokenProviderException.GenericErrorMessage} " +
                                     $"{exp.Message}";

                    if (exp.InnerException != null)
                    {
                        message += $"Inner Exception : {exp.InnerException.Message}";
                    }

                    throw new AzureServiceTokenProviderException(ConnectionString, resource, authority, message);
                }
            }

            if (accessToken != null)
            {
                AccessToken token = AccessToken.Parse(accessToken);

                PrincipalUsed.UserPrincipalName = !string.IsNullOrEmpty(token.Upn) ? token.Upn : token.Email;
                PrincipalUsed.TenantId = _currentUserTenant = token.TenantId;
                PrincipalUsed.IsAuthenticated = true;

                return accessToken;
            }

            // If result is null, token could not be acquired, and no exception was thrown. 
            throw new AzureServiceTokenProviderException(ConnectionString, resource, authority, 
                AzureServiceTokenProviderException.GenericErrorMessage);
        }
    }
}
