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
        private readonly HttpPipeline _pipeline;
        private string _resourceEndpoint;
        private TokenCredential _tokenCredential;
        private string[] _scopes;

        /// <summary>
        /// Initializes a new instance of <see cref="EntraTokenCredential"/>.
        /// </summary>
        /// <param name="options">The options for how the token will be fetched</param>
        public EntraTokenCredential(EntraCommunicationTokenCredentialOptions options)
        {
            this._tokenCredential = options.TokenCredential;
            this._resourceEndpoint = options.ResourceEndpoint;
            this._scopes = options.Scopes;
            _pipeline = CreatePipelineFromOptions(options);
        }

        private HttpPipeline CreatePipelineFromOptions(EntraCommunicationTokenCredentialOptions options)
        {
            var authenticationPolicy = new BearerTokenAuthenticationPolicy(options.TokenCredential, options.Scopes);
            return HttpPipelineBuilder.Build(ClientOptions.Default, authenticationPolicy);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            //_pipeline.Dispose();
        }

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the user.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns> Contains the access token for the user.</returns>
        public AccessToken GetToken(CancellationToken cancellationToken)
        {
            return GetTokenAsync(cancellationToken).Result;
        }

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the user.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns>
        /// A task that represents the asynchronous get token operation. The value of its <see cref="ValueTask{AccessToken}.Result"/> property contains the access token for the user.
        /// </returns>
        public ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken)
        {
            return ExchangeEntraToken(cancellationToken);
        }

        private async ValueTask<AccessToken> ExchangeEntraToken(CancellationToken cancellationToken)
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
                    var json = JsonDocument.Parse(response.Content);
                    var accessTokenJson = json.RootElement.GetProperty("accessToken").GetRawText();
                    var acsToken = JsonSerializer.Deserialize<AcsToken>(accessTokenJson);
                    if (acsToken != null)
                    {
                        return new AccessToken(acsToken.token, acsToken.expiresOn);
                    }
                    throw new RequestFailedException(response);
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
