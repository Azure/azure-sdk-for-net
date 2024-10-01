// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication
{
    /// <summary>
    /// Represents a credential that exchanges an Entra token for an Azure Communication Services (ACS) token, , enabling access to ACS resources.
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

        /// <inheritdoc />
        public void Dispose()
        {
            //_pipeline.Dispose();
        }

        /// <summary>
        /// Get a Communication Identity access token.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>=
        public AccessToken GetToken(CancellationToken cancellationToken)
        {
            return GetTokenAsync(cancellationToken).Result;
        }

        /// <summary>
        /// Gets a Communication Identity access token.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        public ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken)
        {
            return ExchangeEntraToken(cancellationToken);
        }

        private async ValueTask<AccessToken> ExchangeEntraToken(CancellationToken cancellationToken)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RequestUriBuilder();
            uri.Reset(new Uri(_resourceEndpoint));
            uri.AppendPath("/access/entra/:exchangeAccessToken", false);
            uri.AppendQuery("api-version", "2024-04-01-preview", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");

            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        var accessToken = DeserializeCommunicationUserIdentifierAndToken(document.RootElement);
                        if (accessToken != null)
                        {
                            return (AccessToken)accessToken;
                        }
                        throw new RequestFailedException(message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        private AccessToken? DeserializeCommunicationUserIdentifierAndToken(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            AccessToken accessToken = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("accessToken"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    string token = default;
                    DateTimeOffset expiresOn = default;
                    foreach (var tokenProperty in property.Value.EnumerateObject())
                    {
                        if (property.NameEquals("token"u8))
                        {
                            token = tokenProperty.Value.GetString();
                            continue;
                        }
                        if (property.NameEquals("expiresOn"u8))
                        {
                            //expiresOn = property.Value;
                            continue;
                        }
                    }
                    accessToken = new AccessToken(token, expiresOn);
                    continue;
                }
            }
            return accessToken;
        }

        private HttpPipeline CreatePipelineFromOptions(EntraCommunicationTokenCredentialOptions options)
        {
            var authenticationPolicy = new BearerTokenAuthenticationPolicy(options.TokenCredential,options.Scopes);
            return HttpPipelineBuilder.Build(ClientOptions.Default, authenticationPolicy);
        }
    }
}
