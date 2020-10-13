// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    internal class KeyVaultClient
    {
        // Configurable MSI retry timeout for internal MsiAccessTokenProvider
        private readonly int _msiRetryTimeoutInSeconds;

        // These members allow for unit testing
        private readonly HttpClient _httpClient;
        private NonInteractiveAzureServiceTokenProviderBase _tokenProvider;

        private const string KeyVaultRestApiVersion = "2016-10-01";

        // Error messages
        internal const string BearerChallengeMissingOrInvalidError = "A bearer challenge was not returned or is invalid.";
        internal const string EndpointNotAvailableError = "Unable to connect to the Key Vault endpoint. Please check that the secret identifier is correct.";
        internal const string KeyVaultAccessTokenRetrievalError = "Unable to get a Key Vault access token to acquire certificate.";
        internal const string KeyVaultResponseError = "Key Vault returned an error.";
        internal const string SecretBundleInvalidContentTypeError = "Specified secret identifier does not contain private key data. Please check you are providing the secret identifier for the Key Vault client certificate.";
        internal const string SecretIdentifierInvalidSchemeError = "Specified identifier must use HTTPS.";
        internal const string SecretIdentifierInvalidTypeError = "Specified identifier is not a secret identifier.";
        internal const string SecretIdentifierInvalidUriError = "Specified secret identifier is not a valid URI.";
        internal const string TokenProviderErrorsFormat = "Tried the following {0} methods to get a Key Vault access token, but none of them worked.";

        internal Principal PrincipalUsed { get; private set; }

        internal KeyVaultClient(int msiRetryTimeoutInSeconds = 0, HttpClient httpClient = null, NonInteractiveAzureServiceTokenProviderBase tokenProvider = null)
        {
            _msiRetryTimeoutInSeconds = msiRetryTimeoutInSeconds;
#if NETSTANDARD1_4 || net452 || net461
            _httpClient = httpClient ?? new HttpClient();
#else
            _httpClient = httpClient ?? new HttpClient(new HttpClientHandler() { CheckCertificateRevocationList = true });
#endif
            _tokenProvider = tokenProvider;
        }

        internal KeyVaultClient(HttpClient httpClient, NonInteractiveAzureServiceTokenProviderBase tokenProvider = null) : this(0, httpClient, tokenProvider)
        {
        }

        internal async Task<X509Certificate2> GetCertificateAsync(string secretIdentifier, CancellationToken cancellationToken = default)
        {
            try
            {
                ValidateSecretIdentifier(secretIdentifier);

                string accessToken = await GetKeyVaultAccessTokenAsync(secretIdentifier, cancellationToken).ConfigureAwait(false);

                var requestUrl = $"{secretIdentifier}?api-version={KeyVaultRestApiVersion}";

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {accessToken}");

                HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    string exceptionText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    throw new Exception($"{KeyVaultResponseError} KeyVault ResponseCode: {response.StatusCode}, Message: {exceptionText}");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Validate that the JSON secret bundle returned contains private key data
                SecretBundle secretBundle = SecretBundle.Parse(jsonResponse);
                if (secretBundle.ContentType != "application/x-pkcs12")
                {
                    throw new Exception(SecretBundleInvalidContentTypeError);
                }

                byte[] rawCertBytes = Convert.FromBase64String(secretBundle.Value);

                X509Certificate2 certificate = null;

                // access to key store dependent on environment, try to import to both user and machine key stores
                try
                {
                    certificate = new X509Certificate2(rawCertBytes, default(string), X509KeyStorageFlags.UserKeySet);
                }
                catch
                {
                    certificate = new X509Certificate2(rawCertBytes, default(string), X509KeyStorageFlags.MachineKeySet);
                }

                return certificate;
            }
            catch (KeyVaultAccessTokenRetrievalException exp)
            {
                throw new Exception($"{KeyVaultAccessTokenRetrievalError} {exp.Message}");
            }
            catch (HttpRequestException)
            {
                throw new Exception(EndpointNotAvailableError);
            }
        }

        private void ValidateSecretIdentifier(string secretIdentifier)
        {
            // Ensure secret identifier is a valid URI
            Uri secretUri;
            if (!Uri.TryCreate(secretIdentifier, UriKind.Absolute, out secretUri))
                throw new Exception(SecretIdentifierInvalidUriError);

            // Ensure secret URI is using HTTPS scheme
            if (!secretUri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
                throw new Exception(SecretIdentifierInvalidSchemeError);

            // Ensure secret URI is actually a secret identifier (and not key or certificate identifier)
            if (!secretUri.LocalPath.StartsWith("/secrets/", StringComparison.OrdinalIgnoreCase))
                throw new Exception(SecretIdentifierInvalidTypeError);
        }

        private class KeyVaultAccessTokenRetrievalException : Exception
        {
            internal KeyVaultAccessTokenRetrievalException(string message) :
                base(message)
            {
            }
        }

        private async Task<string> GetKeyVaultAccessTokenAsync(string secretUrl, CancellationToken cancellationToken)
        {
            // Send an anonymous request to Key Vault endpoint to get an OAuth2 HTTP Bearer challenge
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, secretUrl);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            // Parse challenge to get authorization server and resource identifier for Key Vault
            var authenticateHeader = response.Headers.WwwAuthenticate.FirstOrDefault()?.ToString();
            var challenge = HttpBearerChallenge.Parse(authenticateHeader); 
            if (challenge == null)
            {
                 throw new KeyVaultAccessTokenRetrievalException(BearerChallengeMissingOrInvalidError);
            }

            var tokenProviders = GetTokenProviders(challenge.AuthorizationServer);
            List<Exception> exceptions = new List<Exception>();

            // Use values parsed from the bearer challenge to request an access token for Key Vault
            foreach (var tokenProvider in tokenProviders)
            {
                try
                {
                    var authResult = await tokenProvider.GetAuthResultAsync(challenge.Resource,
                        challenge.AuthorizationServer, cancellationToken).ConfigureAwait(false);

                    PrincipalUsed = tokenProvider.PrincipalUsed;

                    return authResult.AccessToken;
                }
                catch (AzureServiceTokenProviderException exp)
                {
                    exceptions.Add(exp);
                }
            }

            // Compile token provider exceptions and rethrow if token request was not successful
            string message = string.Format(TokenProviderErrorsFormat, exceptions.Count) + Environment.NewLine;
            foreach (var exception in exceptions)
            {
                message += $"{exception.Message}{Environment.NewLine}";
            }

            throw new KeyVaultAccessTokenRetrievalException(message);
        }

        private List<NonInteractiveAzureServiceTokenProviderBase> GetTokenProviders(string authority)
        {
            List<NonInteractiveAzureServiceTokenProviderBase> tokenProviders = null;

            // use default user token providers if token provider not specified (e.g. by unit test)
            if (_tokenProvider == null)
            {
                string azureAdInstance = UriHelper.GetAzureAdInstanceByAuthority(authority);
                tokenProviders = new List<NonInteractiveAzureServiceTokenProviderBase>
                {
                    new MsiAccessTokenProvider(_msiRetryTimeoutInSeconds),
                    new VisualStudioAccessTokenProvider(new ProcessManager()),
                    new AzureCliAccessTokenProvider(new ProcessManager()),
#if FullNetFx
                    new WindowsAuthenticationAzureServiceTokenProvider(new AdalAuthenticationContext(), azureAdInstance)
#endif
                };
            }
            else
            {
                tokenProviders = new List<NonInteractiveAzureServiceTokenProviderBase>() { _tokenProvider };
            }

            return tokenProviders;
        }
    }
}