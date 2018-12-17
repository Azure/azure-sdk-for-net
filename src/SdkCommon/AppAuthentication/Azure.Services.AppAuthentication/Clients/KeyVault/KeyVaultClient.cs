﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    internal class KeyVaultClient
    {
        // These members allow for unit testing
        private readonly HttpClient _httpClient;
        private NonInteractiveAzureServiceTokenProviderBase _tokenProvider;

        // Key Vault constants and well-known values
        private const string KeyVaultRestApiVersion = "2016-10-01";
        private const string AzureKeyVaultDnsSuffix = "vault.azure.net";
        private const string ChinaKeyVaultDnsSuffix = "vault.azure.cn";
        private const string USGovernmentKeyVaultDnsSuffix = "vault.usgovcloudapi.net";
        private const string GermanKeyVaultDnsSuffix = "vault.microsoftazure.de";
        private readonly List<string> WellKnownKeyVaultDnsSuffixes = new List<string>()
        {
            AzureKeyVaultDnsSuffix,
            ChinaKeyVaultDnsSuffix,
            USGovernmentKeyVaultDnsSuffix,
            GermanKeyVaultDnsSuffix
        };

        // Error messages
        internal const string BearerChallengeMissingOrInvalidError = "A bearer challenge was not returned or is invalid.";
        internal const string EndpointNotAvailableError = "Unable to connect to the Key Vault endpoint. Please check that the secret identifier is correct.";
        internal const string KeyVaultAccessTokenRetrievalError = "Unable to get a Key Vault access token to acquire certificate.";
        internal const string KeyVaultResponseError = "Key Vault returned an error.";
        internal const string SecretBundleInvalidContentTypeError = "Specified secret identifier does not contain private key data. Please check you are providing the secret identifier for the Key Vault client certificate.";
        internal const string SecretIdentifierInvalidHostError = "Specified secret identifier has an unrecognized hostname.";
        internal const string SecretIdentifierInvalidSchemeError = "Specified identifier must use HTTPS.";
        internal const string SecretIdentifierInvalidTypeError = "Specified identifier is not a secret identifier.";
        internal const string SecretIdentifierInvalidUriError = "Specified secret identifier is not a valid URI.";
        internal const string TokenProviderErrorsFormat = "Tried the following {0} methods to get a Key Vault access token, but none of them worked.";

        public KeyVaultClient(HttpClient httpClient = null, NonInteractiveAzureServiceTokenProviderBase tokenProvider = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _tokenProvider = tokenProvider;
        }

        public async Task<X509Certificate2> GetCertificateAsync(string secretIdentifier)
        {
            try
            {
                ValidateSecretIdentifier(secretIdentifier);

                string accessToken = await GetKeyVaultAccessToken(secretIdentifier).ConfigureAwait(false);

                var requestUrl = $"{secretIdentifier}?api-version={KeyVaultRestApiVersion}";

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {accessToken}");

                HttpResponseMessage response = await _httpClient.SendAsync(request).ConfigureAwait(false);

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

                X509Certificate2 certificate = new X509Certificate2(rawCertBytes);
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

            // Ensure secret URI host ends in well-known Key Vault DNS suffix
            if (!WellKnownKeyVaultDnsSuffixes.Any(dnsSuffix => secretUri.Host.EndsWith(dnsSuffix, StringComparison.OrdinalIgnoreCase)))
                throw new Exception(SecretIdentifierInvalidHostError);

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
        private async Task<string> GetKeyVaultAccessToken(string secretUrl)
        {
            // Send an anonymous request to Key Vault endpoint to get an OAuth2 HTTP Bearer challenge
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, secretUrl);
            HttpResponseMessage response = await _httpClient.SendAsync(request).ConfigureAwait(false);

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
                    var authResult = await tokenProvider.GetAuthResultAsync(challenge.AuthorizationServer,
                        challenge.Resource, challenge.Scope).ConfigureAwait(false);

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