// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication
{
    /// <summary>
    /// Represents a credential that exchanges an Entra token for an Azure Communication Services (ACS) token, enabling access to ACS resources.
    /// </summary>
    internal sealed class EntraTokenCredential : ICommunicationTokenCredential
    {
        private HttpPipeline _pipeline;
        private string _resourceEndpoint;
        private readonly ThreadSafeRefreshableAccessTokenCache _accessTokenCache;

        /// <summary>
        /// Initializes a new instance of <see cref="EntraTokenCredential"/>.
        /// </summary>
        /// <param name="options">The options for how the token will be fetched</param>
        /// <param name="pipelineTransport">Only for testing.</param>
        public EntraTokenCredential(EntraCommunicationTokenCredentialOptions options, HttpPipelineTransport pipelineTransport = null)
        {
            this._resourceEndpoint = options.ResourceEndpoint;
            _pipeline = CreatePipelineFromOptions(options, pipelineTransport);
            _accessTokenCache = new ThreadSafeRefreshableAccessTokenCache(
                    ExchangeEntraToken,
                    ExchangeEntraTokenAsync,
                    false, null, null);
        }

        private HttpPipeline CreatePipelineFromOptions(EntraCommunicationTokenCredentialOptions options, HttpPipelineTransport pipelineTransport)
        {
            var authenticationPolicy = new BearerTokenAuthenticationPolicy(options.TokenCredential, options.Scopes);
            var clientOptions = ClientOptions.Default;
            if (pipelineTransport != null)
            {
                clientOptions.Transport = pipelineTransport;
            }
            return HttpPipelineBuilder.Build(clientOptions, authenticationPolicy);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _pipeline = default;
            _accessTokenCache.Dispose();
        }

        /// <summary>
        /// Gets an <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns> Contains the access token.</returns>
        public AccessToken GetToken(CancellationToken cancellationToken = default)
            => _accessTokenCache.GetValue(cancellationToken);

        /// <summary>
        /// Gets an <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns>
        /// A task that represents the asynchronous get token operation. The value of its <see cref="ValueTask{AccessToken}.Result"/> property contains the access token.
        /// </returns>
        public ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken = default)
            => _accessTokenCache.GetValueAsync(cancellationToken);

        private AccessToken ExchangeEntraToken(CancellationToken cancellationToken)
        {
            return ExchangeEntraTokenAsync(cancellationToken).Result;
        }

        private async ValueTask<AccessToken> ExchangeEntraTokenAsync(CancellationToken cancellationToken)
        {
            var message = CreateRequestMessage();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            return ParseAccessTokenFromResponse(message.Response);
        }

        private HttpMessage CreateRequestMessage()
        {
            var uri = new RequestUriBuilder();
            uri.Reset(new Uri(_resourceEndpoint));
            uri.AppendPath("/access/entra/:exchangeAccessToken", false);
            uri.AppendQuery("api-version", "2024-04-01-preview", true);

            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = "{}";

            return message;
        }

        private AccessToken ParseAccessTokenFromResponse(Response response)
        {
            switch (response.Status)
            {
                case 200:
                    try
                    {
                        var json = JsonDocument.Parse(response.Content);
                        var accessTokenJson = json.RootElement.GetProperty("accessToken").GetRawText();
                        var acsToken = JsonSerializer.Deserialize<AcsToken>(accessTokenJson);
                        return new AccessToken(acsToken.token, acsToken.expiresOn);
                    }
                    catch (Exception)
                    {
                        throw new RequestFailedException(response);
                    }
                default:
                    throw new RequestFailedException(response);
            }
        }

        private partial class AcsToken
        {
            public string token { get; set; }
            public DateTimeOffset expiresOn { get; set; }
        }
    }
}
