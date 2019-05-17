// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using System.Net.Http;
    using Rest.Azure;
    using System.Collections.Generic;
    using Rest;
    using System;
    using System.Net;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;


    /// <summary>
    /// Client class to perform cryptographic key operations and vault
    /// operations against the Key Vault service.
    /// </summary>
    public partial class KeyVaultClient
    {
        /// <summary>
        /// The authentication callback delegate which is to be implemented by the client code
        /// </summary>
        /// <param name="authority"> Identifier of the authority, a URL. </param>
        /// <param name="resource"> Identifier of the target resource that is the recipient of the requested token, a URL. </param>
        /// <param name="scope"> The scope of the authentication request. </param>
        /// <returns> access token </returns>
        public delegate Task<string> AuthenticationCallback(string authority, string resource, string scope);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationCallback">The authentication callback</param>
        /// <param name='handlers'>Optional. The delegating handlers to add to the http client pipeline.</param>
        public KeyVaultClient(AuthenticationCallback authenticationCallback, params DelegatingHandler[] handlers)
            : this(new KeyVaultCredential(authenticationCallback), handlers)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationCallback">The authentication callback</param>
        /// <param name="httpClient">Customized HTTP client </param>
        public KeyVaultClient(AuthenticationCallback authenticationCallback, HttpClient httpClient)
            : this(new KeyVaultCredential(authenticationCallback), httpClient)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="credential">Credential for key vault operations</param>
        /// <param name="httpClient">Customized HTTP client </param>
        public KeyVaultClient(KeyVaultCredential credential, HttpClient httpClient)
            // clone the KeyVaultCredential to ensure the instance is only used by this client since it
            // will use this client's HttpClient for unauthenticated calls to retrieve the auth challange
            : this(credential.Clone())
        {
            base.HttpClient = httpClient;
        }

        /// <summary>
        /// Gets the pending certificate signing request response.
        /// </summary>
        /// <param name='vaultBaseUrl'>
        /// The vault name, e.g. https://myvault.vault.azure.net
        /// </param>
        /// <param name='certificateName'>
        /// The name of the certificate
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse<string>> GetPendingCertificateSigningRequestWithHttpMessagesAsync(string vaultBaseUrl, string certificateName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (vaultBaseUrl == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "vaultBaseUrl");
            }
            if (certificateName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "certificateName");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("vaultBaseUrl", vaultBaseUrl);
                tracingParameters.Add("certificateName", certificateName);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetPendingCertificateSigningRequest", tracingParameters);
            }
            // Construct URL
            var _baseUrl = this.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "certificates/{certificate-name}/pending";
            _url = _url.Replace("{vaultBaseUrl}", vaultBaseUrl);
            _url = _url.Replace("{certificate-name}", Uri.EscapeDataString(certificateName));
            List<string> _queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                _queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += "?" + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new Uri(_url);
            _httpRequest.Headers.Add("Accept", "application/pkcs10");

            // Set Headers
            if (this.GenerateClientRequestId != null && this.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            }
            if (this.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await this.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new KeyVaultErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    KeyVaultError _errorBody = SafeJsonConvert.DeserializeObject<KeyVaultError>(_responseContent, this.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationResponse<string>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _result.Body = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }
    }
}