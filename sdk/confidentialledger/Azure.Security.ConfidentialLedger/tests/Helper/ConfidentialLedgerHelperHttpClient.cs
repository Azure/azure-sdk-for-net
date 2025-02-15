// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Data.ConfidentialLedger.Tests.Helper
{
    public class ConfidentialLedgerHelperHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseUrl;
        private readonly TokenCredential _credential;

        // Confidential Ledger Authentication Scope
        private static readonly string[] AuthorizationScopes = new string[]
        {
            "https://confidential-ledger.azure.com/.default"
        };

        public ConfidentialLedgerHelperHttpClient(Uri baseUrl, TokenCredential credential)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            _credential = credential ?? throw new ArgumentNullException(nameof(credential));
        }

        /// <summary>
        /// Calls the given endpoint with Azure TokenCredential authentication.
        /// </summary>
        /// <param name="path">The API path to query.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>Tuple containing HTTP status code and response body.</returns>
        public async Task<(HttpStatusCode StatusCode, string ResponseBody)> QueryUserDefinedContentEndpointAsync(
            string path, CancellationToken cancellationToken = default, bool jwtAuth = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be null or empty.", nameof(path));
            }

            Uri endpoint = new Uri(_baseUrl, path);

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

                if (jwtAuth)
                {
                    // Get Access Token using Azure TokenCredential
                    AccessToken accessToken = await _credential.GetTokenAsync(
                        new TokenRequestContext(AuthorizationScopes),
                        cancellationToken);

                    // Add Authorization header
                    request.Headers.Add("Authorization", $"Bearer {accessToken.Token}");
                }

                // Send GET request
                HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
                string responseBody = await response.Content.ReadAsStringAsync();

                return (response.StatusCode, responseBody);
            }
            catch (Exception ex)
            {
                return (HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
}
    }
}
