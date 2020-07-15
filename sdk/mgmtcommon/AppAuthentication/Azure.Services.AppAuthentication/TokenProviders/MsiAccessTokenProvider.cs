// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
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
#if NETSTANDARD1_4 || net452 || net461
        private static readonly HttpClient DefaultHttpClient = new HttpClient();
#else
        private static readonly HttpClient DefaultHttpClient = new HttpClient(new HttpClientHandler() { CheckCertificateRevocationList = true });
#endif

        // Azure Instance Metadata Service (IMDS) endpoint
        private const string AzureVmImdsEndpoint = "http://169.254.169.254/metadata/identity/oauth2/token";

        // Timeout for Azure IMDS probe request
        internal const int AzureVmImdsProbeTimeoutInSeconds = 2;
        internal readonly TimeSpan AzureVmImdsProbeTimeout = TimeSpan.FromSeconds(AzureVmImdsProbeTimeoutInSeconds);

        // Configurable timeout for MSI retry logic
        internal readonly int _retryTimeoutInSeconds = 0;

        internal MsiAccessTokenProvider(int retryTimeoutInSeconds = 0, string managedIdentityClientId = default)
        {
            // require storeLocation if using subject name or thumbprint identifier
            if (retryTimeoutInSeconds < 0)
            {
                throw new ArgumentException(
                    $"MsiRetryTimeout {retryTimeoutInSeconds} is not valid. Valid values are integers greater than or equal to 0.");
            }

            _managedIdentityClientId = managedIdentityClientId;
            _retryTimeoutInSeconds = retryTimeoutInSeconds;

            PrincipalUsed = new Principal { Type = "App" };
        }

        internal MsiAccessTokenProvider(HttpClient httpClient, int retryTimeoutInSeconds = 0, string managedIdentityClientId = null) : this(retryTimeoutInSeconds, managedIdentityClientId)
        {
            _httpClient = httpClient;
        }

        public override async Task<AppAuthenticationResult> GetAuthResultAsync(string resource, string authority,
            CancellationToken cancellationToken = default)
        {
            // Use the httpClient specified in the constructor. If it was not specified in the constructor, use the default httpClient. 
            HttpClient httpClient = _httpClient ?? DefaultHttpClient;

            try
            {
                // Check if App Services MSI is available. If both these environment variables are set, then it is. 
                string msiEndpoint = Environment.GetEnvironmentVariable("IDENTITY_ENDPOINT");
                string msiHeader = Environment.GetEnvironmentVariable("IDENTITY_HEADER");
                var isAppServicesMsiAvailable = !string.IsNullOrWhiteSpace(msiEndpoint) && !string.IsNullOrWhiteSpace(msiHeader);

                // if App Service MSI is not available then Azure VM IMDS may be available, test with a probe request
                if (!isAppServicesMsiAvailable)
                {
                    using (var internalTokenSource = new CancellationTokenSource())
                    using (var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(internalTokenSource.Token, cancellationToken))
                    {
                        HttpRequestMessage imdsProbeRequest = new HttpRequestMessage(HttpMethod.Get, AzureVmImdsEndpoint);

                        try
                        {
                            internalTokenSource.CancelAfter(AzureVmImdsProbeTimeout);
                            await httpClient.SendAsync(imdsProbeRequest, linkedTokenSource.Token).ConfigureAwait(false);
                        }
                        catch (OperationCanceledException)
                        {
                            // request to IMDS timed out (internal cancellation token cancelled), neither Azure VM IMDS nor App Services MSI are available
                            if (internalTokenSource.Token.IsCancellationRequested)
                            {
                                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                                    $"{AzureServiceTokenProviderException.ManagedServiceIdentityUsed} {AzureServiceTokenProviderException.MsiEndpointNotListening}");
                            }

                            throw;
                        }
                    }
                }

                // If managed identity is specified, include client ID parameter in request
                string clientIdParameter = _managedIdentityClientId != default
                    ? $"&client_id={_managedIdentityClientId}"
                    : string.Empty;

                // Craft request as per the MSI protocol
                var requestUrl = isAppServicesMsiAvailable
                    ? $"{msiEndpoint}?resource={resource}{clientIdParameter}&api-version=2019-08-01"
                    : $"{AzureVmImdsEndpoint}?resource={resource}{clientIdParameter}&api-version=2018-02-01";

                Func<HttpRequestMessage> getRequestMessage = () =>
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                    if (isAppServicesMsiAvailable)
                    {
                        request.Headers.Add("X-IDENTITY-HEADER", msiHeader);
                    }
                    else
                    {
                        request.Headers.Add("Metadata", "true");
                    }

                    return request;
                };

                HttpResponseMessage response;
                try
                {
                    response = await httpClient.SendAsyncWithRetry(getRequestMessage, _retryTimeoutInSeconds, cancellationToken).ConfigureAwait(false);
                }
                catch (HttpRequestException)
                {
                    throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                        $"{AzureServiceTokenProviderException.ManagedServiceIdentityUsed} {AzureServiceTokenProviderException.RetryFailure} {AzureServiceTokenProviderException.MsiEndpointNotListening}");
                }

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
                    
                    return AppAuthenticationResult.Create(tokenResponse);
                }

                string errorStatusDetail = response.IsRetryableStatusCode()
                    ? AzureServiceTokenProviderException.RetryFailure
                    : AzureServiceTokenProviderException.NonRetryableError;

                string errorText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                throw new Exception($"{errorStatusDetail} MSI ResponseCode: {response.StatusCode}, Response: {errorText}");
            }
            catch (Exception exp)
            {
                if (exp is AzureServiceTokenProviderException) throw;

                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                    $"{AzureServiceTokenProviderException.ManagedServiceIdentityUsed} {AzureServiceTokenProviderException.GenericErrorMessage} {exp.Message}");
            }
        }
    }
}