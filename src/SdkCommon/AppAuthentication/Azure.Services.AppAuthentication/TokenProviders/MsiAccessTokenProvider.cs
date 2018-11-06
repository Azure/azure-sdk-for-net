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
        private readonly HttpClient _httpClient;

        // This client ID can be specified in the constructor to specify a specific managed identity to use (e.g. user-assigned identity)
        private readonly string _managedIdentityClientId;

        // HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
        private static readonly HttpClient DefaultHttpClient = new HttpClient();

        // Azure Instance Metadata Service (IDMS) endpoint
        private const string AzureVmIdmsEndpoint = "http://169.254.169.254/metadata/identity/oauth2/token";

        internal MsiAccessTokenProvider(string managedIdentityClientId = default(string))
        {
            _managedIdentityClientId = managedIdentityClientId;

            PrincipalUsed = new Principal { Type = "App" };
        }

        internal MsiAccessTokenProvider(HttpClient httpClient, string managedIdentityClientId = null) : this(managedIdentityClientId)
        {
            _httpClient = httpClient;
        }

        public override async Task<AppAuthenticationResult> GetAuthResultAsync(string resource, string authority)
        {
            try
            {
                // Check if App Services MSI is available. If both these environment variables are set, then it is. 
                string msiEndpoint = Environment.GetEnvironmentVariable("MSI_ENDPOINT");
                string msiSecret = Environment.GetEnvironmentVariable("MSI_SECRET");
                var isAppServicesMsiAvailable = !string.IsNullOrWhiteSpace(msiEndpoint) && !string.IsNullOrWhiteSpace(msiSecret);

                // If managed identity is specified, include client_id parameter in request
                string clientIdParameter = _managedIdentityClientId != default(string)
                    ? $"&client_id={_managedIdentityClientId}"
                    : string.Empty;

                // Craft request as per the MSI protocol
                var requestUrl = isAppServicesMsiAvailable
                    ? $"{msiEndpoint}?resource={resource}&api-version=2017-09-01"
                    : $"{AzureVmIdmsEndpoint}?resource={resource}{clientIdParameter}&api-version=2018-02-01";

                // Use the httpClient specified in the constructor. If it was not specified in the constructor, use the default httpclient. 
                HttpClient httpClient = _httpClient ?? DefaultHttpClient;

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                if (isAppServicesMsiAvailable)
                {
                    request.Headers.Add("Secret", msiSecret);
                }
                else
                {
                    request.Headers.Add("Metadata", "true");
                }

                HttpResponseMessage response = await httpClient.SendAsync(request).ConfigureAwait(false);

                // If the response is successful, it should have JSON response with an access_token field
                if (response.IsSuccessStatusCode)
                {
                    PrincipalUsed.IsAuthenticated = true;

                    string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    // Parse the JSON response
                    TokenResponse tokenResponse = TokenResponse.Parse(jsonResponse);

                    AccessToken token = AccessToken.Parse(tokenResponse.AccessToken);

                    // If token is null, then there has been a parsing issue, which means the access token format has changed
                    if (token != null)
                    {
                        PrincipalUsed.AppId = token.AppId;
                        PrincipalUsed.TenantId = token.TenantId;
                    }

                    TokenResponse.DateFormat expectedDateFormat = isAppServicesMsiAvailable
                        ? TokenResponse.DateFormat.DateTimeString
                        : TokenResponse.DateFormat.Unix;

                    return AppAuthenticationResult.Create(tokenResponse, expectedDateFormat);
                }

                string exceptionText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                throw new Exception($"MSI ResponseCode: {response.StatusCode}, Response: {exceptionText}");
            }
            catch (HttpRequestException)
            {
                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                    $"{AzureServiceTokenProviderException.ManagedServiceIdentityUsed} {AzureServiceTokenProviderException.MsiEndpointNotListening}");
            }
            catch (Exception exp)
            {
                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                    $"{AzureServiceTokenProviderException.ManagedServiceIdentityUsed} {AzureServiceTokenProviderException.GenericErrorMessage} {exp.Message}");
            }
        }
    }
}
