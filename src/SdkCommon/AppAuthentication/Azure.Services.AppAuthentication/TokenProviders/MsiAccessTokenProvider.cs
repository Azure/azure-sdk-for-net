// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Gets a token using Azure VM or App Services MSI. 
    /// https://docs.microsoft.com/en-us/azure/active-directory/msi-overview
    /// </summary>
    internal class MsiAccessTokenProvider : NonInteractiveAzureServiceTokenProviderBase
    {
        // This is for unit testing
        private readonly HttpMessageHandler _httpMessageHandler;

        // HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
        private static readonly HttpClient HttpClient = new HttpClient();

        // Default Azure VM MSI endpoint
        private const string AzureVmMsiEndpoint = "http://localhost:50342/oauth2/token";

        internal MsiAccessTokenProvider()
        {
            PrincipalUsed = new Principal { Type = "App" };
        }

        internal MsiAccessTokenProvider(HttpMessageHandler httpMessageHandler) : this()
        {
            _httpMessageHandler = httpMessageHandler;
        }

        public override async Task<string> GetTokenAsync(string resource, string authority)
        {
            try
            {
                // Check if App Services MSI is available. If both these environment variables are set, then it is. 
                string msiEndpoint = Environment.GetEnvironmentVariable("MSI_ENDPOINT");
                string msiSecret = Environment.GetEnvironmentVariable("MSI_SECRET");
                var isAppServicesMsiAvailable = !string.IsNullOrWhiteSpace(msiEndpoint) && !string.IsNullOrWhiteSpace(msiSecret);

                string authorityParameter = string.IsNullOrEmpty(authority) ? string.Empty : $"&authority={authority}";

                // Craft request as per the MSI protocol
                var request = isAppServicesMsiAvailable
                    ? $"{msiEndpoint}?resource={resource}&api-version=2017-09-01"
                    : $"{AzureVmMsiEndpoint}?resource={resource}{authorityParameter}";

                // If _httpMessageHandler is specified, use a new HttpClient with the handler (This is for unit testing). 
                HttpClient httpClient = _httpMessageHandler == null ? HttpClient : new HttpClient(_httpMessageHandler);

                if (isAppServicesMsiAvailable)
                {
                    httpClient.DefaultRequestHeaders.Add("Secret", msiSecret);
                }
                else
                {
                    httpClient.DefaultRequestHeaders.Add("Metadata", "true");
                }

                HttpResponseMessage response = await httpClient.GetAsync(request).ConfigureAwait(false);

                // If the response is successful, it should have JSON response with an access_token field
                if (response.IsSuccessStatusCode)
                {
                    PrincipalUsed.IsAuthenticated = true;

                    string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    // Parse the JSON response
                    TokenResponse tokenResponse = TokenResponse.Parse(jsonResponse);

                    // If something goes wrong in the parsing, the protocol has likely changed
                    // Throw an exception with details
                    if (string.IsNullOrWhiteSpace(tokenResponse?.AccessToken))
                    {
                        throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                            AzureServiceTokenProviderException.UnableToParseMsiTokenResponse);
                    }

                    AccessToken token = AccessToken.Parse(tokenResponse.AccessToken);

                    // If token is null, then there has been a parsing issue, which means the access token format has changed
                    if (token != null)
                    {
                        PrincipalUsed.AppId = token.AppId;
                        PrincipalUsed.TenantId = token.TenantId;
                    }

                    return tokenResponse.AccessToken;
                }

                string exceptionText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority, 
                    $"{AzureServiceTokenProviderException.ManagedServiceIdentityUsed} ResponseCode: {response.StatusCode}, Response: {exceptionText}");
            }
            catch (HttpRequestException)
            {
                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                    $"{AzureServiceTokenProviderException.ManagedServiceIdentityUsed} {AzureServiceTokenProviderException.MsiEndpointNotListening}");
            }
        }
    }
}
