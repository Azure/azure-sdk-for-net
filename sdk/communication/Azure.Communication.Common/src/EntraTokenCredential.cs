// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication
{
    /// <summary>
    /// Entra token credential
    /// </summary>
    internal sealed class EntraTokenCredential : ICommunicationTokenCredential
    {
        private HttpClient _httpClient;
        private string _resourceEndpoint;
        private TokenCredential _tokenCredential;
        private string[] _scopes;

        /// <summary>
        /// Create EntraTokenCredentials
        /// </summary>
        /// <param name="options"></param>
        public EntraTokenCredential(EntraCommunicationTokenCredentialOptions options)
        {
            this._tokenCredential = options.TokenCredential;
            this._resourceEndpoint = options.ResourceEndpoint;
            this._scopes = options.Scopes;

            var pipeline = CreatePipelineFromOptions(options);
            this._httpClient = new HttpClient();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Skype token
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public AccessToken GetToken(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Skype token
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        private AccessToken GetTokenInternalAsync(CancellationToken cancellationToken)
        {
            var tokenRequestContext = new TokenRequestContext(_scopes);
            var entraToken = _tokenCredential.GetToken(tokenRequestContext, cancellationToken);

            // TODO: Call token exchange. Entra token -> ACS token.

            return new AccessToken();
        }

        private async Task ExchangeEntraToken(string resourceEndpoint, CancellationToken cancellationToken)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, string.Concat(_resourceEndpoint, "/access/entra:exchangeToken"))).ConfigureAwait(false);
        }

        private static HttpPipeline CreatePipelineFromOptions(EntraCommunicationTokenCredentialOptions options)
        {
            var authenticationPolicy = new BearerTokenAuthenticationPolicy(options.TokenCredential, "");
            return HttpPipelineBuilder.Build(ClientOptions.Default, authenticationPolicy);
        }
    }
}
