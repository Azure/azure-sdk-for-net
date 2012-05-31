// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Specialized;
using System.Data.Services.Client;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Microsoft.WindowsAzure.MediaServices.Client.OAuth
{
    internal class OAuthDataServiceAdapter
    {
        private const string AuthorizationHeader = "Authorization";
        private const string BearerTokenFormat = "Bearer {0}";
        private const string GrantType = "client_credentials";
        private const int ExpirationTimeBufferInSeconds = 10;

        private readonly string _acsBaseAddress;
        private readonly string _trustedRestCertificateHash;
        private readonly string _trustedRestSubject;
        private readonly string _clientSecret;
        private readonly string _clientId;
        private readonly string _scope;
        private DateTime _tokenExpiration;

        public OAuthDataServiceAdapter(string clientId, string clientSecret, string scope, string acsBaseAddress, string trustedRestCertificateHash, string trustedRestSubject)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _scope = scope;
            _acsBaseAddress = acsBaseAddress;
            _trustedRestCertificateHash = trustedRestCertificateHash;
            _trustedRestSubject = trustedRestSubject;
          
            ServicePointManager.ServerCertificateValidationCallback = ValidateCertificate;
        }

        public void Adapt(DataServiceContext dataServiceContext)
        {
            GetToken();
            DataServiceContext = dataServiceContext;
            DataServiceContext.SendingRequest += OnSendingRequest;
        }

        private bool ValidateCertificate(object s, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            if (error.HasFlag(SslPolicyErrors.RemoteCertificateNameMismatch) || error.HasFlag(SslPolicyErrors.RemoteCertificateChainErrors))
            {
#if DEBUG
                // This is for local deployments. DevFabric generates its own certificate for load-balancing / port forwarding
                const string azureDevFabricCertificateSubject = "CN=127.0.0.1, O=TESTING ONLY, OU=Windows Azure DevFabric";
                if (cert.Subject == azureDevFabricCertificateSubject)
                {
                    return true;
                }
#endif
                var cert2 = new X509Certificate2(cert);
                if (_trustedRestSubject == cert2.Subject && cert2.Thumbprint == _trustedRestCertificateHash)
                {
                    return true;
                }
            }

            return error == SslPolicyErrors.None;
        }

        /// <summary> 
        /// Gets OAuth Access Token to be used for web requests 
        /// </summary> 
        public string AccessToken { get; private set; }

        private DataServiceContext DataServiceContext { get; set; }

        private void GetToken()
        {
            using (var client = new WebClient())
            {
                client.BaseAddress = _acsBaseAddress;

                var oauthRequestValues = new NameValueCollection
                {
                    { "grant_type", GrantType },
                    { "client_id", _clientId },
                    { "client_secret", _clientSecret },
                    { "scope", _scope },
                };

                byte[] responseBytes = client.UploadValues("/v2/OAuth2-13", "POST", oauthRequestValues);

                using (var responseStream = new MemoryStream(responseBytes))
                {
                    var tokenResponse = (OAuth2TokenResponse)new DataContractJsonSerializer(typeof(OAuth2TokenResponse)).ReadObject(responseStream);
                    AccessToken = tokenResponse.AccessToken;
                    _tokenExpiration = DateTime.Now.AddSeconds(tokenResponse.ExpirationInSeconds - ExpirationTimeBufferInSeconds);
                }
            }
        }

        /// <summary> 
        /// When sending Http Data requests to the Azure Marketplace, inject authorization header based on the current Access token 
        /// </summary> 
        /// <param name="sender">Event sender</param> 
        /// <param name="e">Event arguments</param> 
        private void OnSendingRequest(object sender, SendingRequestEventArgs e)
        {
            AddAccessTokenToRequest(e.Request);
        }

        public void AddAccessTokenToRequest(WebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Headers[AuthorizationHeader] == null)
            {
                if (DateTime.Now > _tokenExpiration)
                {
                    GetToken();
                }

                request.Headers.Add(AuthorizationHeader, String.Format(CultureInfo.InvariantCulture, BearerTokenFormat, AccessToken));
            }
        }
    }
}
