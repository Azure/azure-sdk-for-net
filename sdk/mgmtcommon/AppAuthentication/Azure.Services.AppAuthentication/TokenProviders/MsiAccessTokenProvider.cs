// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Security;
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
        private enum MsiEnvironment
        {
            AppServices,
            Imds,
            ServiceFabric
        }

        private readonly HttpMessageHandler _httpMessageHandler; // This is for unit testing
        private HttpClient _httpClient;
        private string _serviceFabricMsiThumbprint;

        // singleton instance of HttpClient
        private HttpClient HttpClient
        {
            get
            {
                if (_httpClient == default)
                {
                    if (_httpMessageHandler != default)
                    {
                        _httpClient = new HttpClient(_httpMessageHandler);
                    }
                    else
                    {
#if NETSTANDARD1_4 || net452 || net461
                        var httpClientHandler = new HttpClientHandler();
#else
                        var httpClientHandler = new HttpClientHandler() { CheckCertificateRevocationList = true };
#endif

#if !net452
                        // Service Fabric requires custom certificate validation
                        if (!string.IsNullOrWhiteSpace(_serviceFabricMsiThumbprint))
                        {
                            httpClientHandler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, certChain, policyErrors) =>
                            {
                                if (policyErrors == SslPolicyErrors.None)
                                    return true;

                                // X509Certificate2.GetCertHashString() not available in .NET Core 1.4 and net452, this works for all platforms
                                var certHashString = BitConverter.ToString(cert.GetCertHash()).Replace("-", "");
                                return 0 == string.Compare(certHashString, _serviceFabricMsiThumbprint, StringComparison.OrdinalIgnoreCase);
                            };
                        }
#endif

                        _httpClient = new HttpClient(httpClientHandler);
                    }
                }

                return _httpClient;
            }
        }

        // This client ID can be specified in the constructor to specify a specific managed identity to use (e.g. user-assigned identity)
        private readonly string _managedIdentityClientId;

        // Azure Instance Metadata Service (IMDS) endpoint
        private const string ImdsEndpoint = "http://169.254.169.254";
        private const string ImdsInstanceRoute = "/metadata/instance";
        private const string ImdsTokenRoute = "/metadata/identity/oauth2/token";
        private const string ImdsInstanceApiVersion = "2020-06-01";
        private const string ImdsTokenApiVersion = "2019-11-01";

        // Azure App Services MSI endpoint constants
        private const string AppServicesApiVersion = "2019-08-01";

        // Each environment require different header
        internal const string AppServicesHeader = "X-IDENTITY-HEADER";
        internal const string AzureVMImdsHeader = "Metadata";
        internal const string ServiceFabricHeader = "secret";

        // Timeout for Azure IMDS probe request
        internal const int AzureVmImdsProbeTimeoutInSeconds = 3;
        private readonly TimeSpan AzureVmImdsProbeTimeout = TimeSpan.FromSeconds(AzureVmImdsProbeTimeoutInSeconds);

        // Configurable timeout for MSI retry logic
        private readonly int _retryTimeoutInSeconds = 0;

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

        internal MsiAccessTokenProvider(HttpMessageHandler httpMessageHandler, int retryTimeoutInSeconds = 0, string managedIdentityClientId = null) : this(retryTimeoutInSeconds, managedIdentityClientId)
        {
            _httpMessageHandler = httpMessageHandler;
        }

        public override async Task<AppAuthenticationResult> GetAuthResultAsync(string resource, string authority,
            CancellationToken cancellationToken = default)
        {
            MsiEnvironment? msiEnvironment = null;

            try
            {
                // Check if App Services MSI or Service Fabric MSI are available. Both use different set of shared env vars.
                var msiEndpoint = Environment.GetEnvironmentVariable("IDENTITY_ENDPOINT");
                var msiHeader = Environment.GetEnvironmentVariable("IDENTITY_HEADER");
                _serviceFabricMsiThumbprint = Environment.GetEnvironmentVariable("IDENTITY_SERVER_THUMBPRINT"); // only in Service Fabric, needed to create HttpClient
                var serviceFabricApiVersion = Environment.GetEnvironmentVariable("IDENTITY_API_VERSION"); // only in Service Fabric

                var endpointAndHeaderAvailable = !string.IsNullOrWhiteSpace(msiEndpoint) && !string.IsNullOrWhiteSpace(msiHeader);
                var thumbprintAndApiVersionAvailable = !string.IsNullOrWhiteSpace(_serviceFabricMsiThumbprint) && !string.IsNullOrWhiteSpace(serviceFabricApiVersion);

                if (endpointAndHeaderAvailable)
                    msiEnvironment = thumbprintAndApiVersionAvailable
                        ? MsiEnvironment.ServiceFabric
                        : MsiEnvironment.AppServices;

                // if App Service and Service Fabric MSI is not available then Azure VM IMDS may be available, test with a probe request
                if (msiEnvironment == null)
                {
                    using (var internalTokenSource = new CancellationTokenSource())
                    using (var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(internalTokenSource.Token, cancellationToken))
                    {
                        string probeRequestUrl = $"{ImdsEndpoint}{ImdsInstanceRoute}?api-version={ImdsInstanceApiVersion}";
                        HttpRequestMessage imdsProbeRequest = new HttpRequestMessage(HttpMethod.Get, probeRequestUrl);
                        imdsProbeRequest.Headers.Add(AzureVMImdsHeader, "true");

                        try
                        {
                            internalTokenSource.CancelAfter(AzureVmImdsProbeTimeout);
                            await HttpClient.SendAsync(imdsProbeRequest, linkedTokenSource.Token).ConfigureAwait(false);
                            msiEnvironment = MsiEnvironment.Imds;
                        }
                        catch (OperationCanceledException)
                        {
                            // request to IMDS timed out (internal cancellation token cancelled), neither Azure VM IMDS nor App Services MSI are available
                            if (internalTokenSource.Token.IsCancellationRequested)
                            {
                                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                                    $"{AzureServiceTokenProviderException.ManagedServiceIdentityUsed} {AzureServiceTokenProviderException.MetadataEndpointNotListening}");
                            }

                            throw;
                        }
                    }
                }

#if net452
                if (msiEnvironment == MsiEnvironment.ServiceFabric)
                {
                    throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                        $"{AzureServiceTokenProviderException.ManagedServiceIdentityUsed} Service Fabric MSI not supported on .NET 4.5.2");
                }
#endif

                // If managed identity is specified, include client ID parameter in request
                string clientIdParameter = _managedIdentityClientId != default
                    ? $"&client_id={_managedIdentityClientId}"
                    : string.Empty;

                // endpoint and API version dependent on environment
                string endpoint = null, apiVersion = null;
                switch (msiEnvironment)
                {
                    case MsiEnvironment.AppServices:
                        endpoint = msiEndpoint;
                        apiVersion = AppServicesApiVersion;
                        break;
                    case MsiEnvironment.Imds:
                        endpoint = $"{ImdsEndpoint}{ImdsTokenRoute}";
                        apiVersion = ImdsTokenApiVersion;
                        break;
                    case MsiEnvironment.ServiceFabric:
                        endpoint = msiEndpoint;
                        apiVersion = serviceFabricApiVersion;
                        break;
                }

                // Craft request as per the MSI protocol
                var requestUrl = $"{endpoint}?resource={resource}{clientIdParameter}&api-version={apiVersion}";

                HttpRequestMessage getRequestMessage()
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                    switch (msiEnvironment)
                    {
                        case MsiEnvironment.AppServices:
                            request.Headers.Add(AppServicesHeader, msiHeader);
                            break;
                        case MsiEnvironment.Imds:
                            request.Headers.Add(AzureVMImdsHeader, "true");
                            break;
                        case MsiEnvironment.ServiceFabric:
                            request.Headers.Add(ServiceFabricHeader, msiHeader);
                            break;
                    }

                    return request;
                }

                HttpResponseMessage response;
                try
                {
                    response = await HttpClient.SendAsyncWithRetry(getRequestMessage, _retryTimeoutInSeconds, cancellationToken).ConfigureAwait(false);
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