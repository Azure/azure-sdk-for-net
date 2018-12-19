// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// The Key Vault credential class that implements <see cref="ServiceClientCredentials"/>
    /// </summary>
    public class KeyVaultCredential : ServiceClientCredentials
    {
        private KeyVaultClient _client = null;

        /// <summary>
        /// The authentication callback
        /// </summary>
        public event KeyVaultClient.AuthenticationCallback OnAuthenticate = null;

        /// <summary>
        /// Bearer token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="authenticationCallback"> the authentication callback. </param>
        public KeyVaultCredential(KeyVaultClient.AuthenticationCallback authenticationCallback)
        {
            OnAuthenticate = authenticationCallback;
        }
        
        /// <summary>
        /// Clones the current KeyVaultCredential object.
        /// </summary>
        /// <returns>A new KeyVaultCredential instance using the same authentication callback as the current instance.</returns>
        internal KeyVaultCredential Clone()
        {
            return new KeyVaultCredential(OnAuthenticate);
        }

        private async Task<string> PreAuthenticate(Uri url)
        {
            if (OnAuthenticate != null)
            {
                var challenge = HttpBearerChallengeCache.GetInstance().GetChallengeForURL(url);

                if (challenge != null)
                {
                    return await OnAuthenticate(challenge.AuthorizationServer, challenge.Resource, challenge.Scope).ConfigureAwait(false);
                }
            }

            return null;
        }

        protected async Task<string> PostAuthenticate(HttpResponseMessage response)
        {
            // An HTTP 401 Not Authorized error; handle if an authentication callback has been supplied
            if (OnAuthenticate != null)
            {
                // Extract the WWW-Authenticate header and determine if it represents an OAuth2 Bearer challenge
                var authenticateHeader = response.Headers.WwwAuthenticate.ElementAt(0).ToString();

                if (HttpBearerChallenge.IsBearerChallenge(authenticateHeader))
                {
                    var challenge = new HttpBearerChallenge(response.RequestMessage.RequestUri, authenticateHeader);

                    if (challenge != null)
                    {
                        // Update challenge cache
                        HttpBearerChallengeCache.GetInstance().SetChallengeForURL(response.RequestMessage.RequestUri, challenge);

                        // We have an authentication challenge, use it to get a new authorization token
                        return await OnAuthenticate(challenge.AuthorizationServer, challenge.Resource, challenge.Scope).ConfigureAwait(false);
                    }
                }
            }

            return null;
        }

        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            base.InitializeServiceClient(client);

            var kvClient = client as KeyVaultClient;

            if (kvClient == null)
            {
                throw new ArgumentException("KeyVaultCredential credentials are only for use with the KeyVaultClient service client.");
            }

            _client = kvClient;
        }

        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var accessToken = await PreAuthenticate(request.RequestUri).ConfigureAwait(false);
            if (!string.IsNullOrEmpty(accessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            else
            {
                HttpResponseMessage response;

                // if this credential is tied to a specific KeyVaultClient reuse it's HttpClient to send the 
                // initial unauthed request to get the challange, otherwise create a new HttpClient
                HttpClient client = _client?.HttpClient ?? new HttpClient();

                using (var r = new HttpRequestMessage(request.Method, request.RequestUri))
                {                    
                    response = await client.SendAsync(r).ConfigureAwait(false);
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    accessToken = await PostAuthenticate(response).ConfigureAwait(false);

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    }
                }
            }                          
        }
    }
}
