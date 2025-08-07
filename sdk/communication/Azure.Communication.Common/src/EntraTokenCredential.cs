// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        private const string TeamsExtensionEndpoint = "/access/teamsExtension/:exchangeAccessToken";
        private const string TeamsExtensionApiVersion = "2025-06-30";
        private const string CommunicationClientsEndpoint = "/access/entra/:exchangeAccessToken";
        private const string CommunicationClientsApiVersion = "2025-03-02-preview";

        private HttpPipeline _pipeline;
        private string _resourceEndpoint;
        private ICollection<string> _scopes { get; }
        private readonly ThreadSafeRefreshableAccessTokenCache _accessTokenCache;

        /// <summary>
        /// Initializes a new instance of <see cref="EntraTokenCredential"/>.
        /// </summary>
        /// <param name="options">The options for how the token will be fetched</param>
        /// <param name="pipelineTransport">Only for testing.</param>
        public EntraTokenCredential(EntraCommunicationTokenCredentialOptions options, HttpPipelineTransport pipelineTransport = null)
        {
            Argument.AssertNotNull(options, nameof(options));
            // Should not ever happen, validated in EntraCommunicationTokenCredentialOptions
            Argument.AssertNotNullOrEmpty(options.Scopes, nameof(options.Scopes));

            this._resourceEndpoint = options.ResourceEndpoint;
            this._scopes = (ICollection<string>)options.Scopes.Clone();
            _pipeline = CreatePipelineFromOptions(options, pipelineTransport);
            _accessTokenCache = new ThreadSafeRefreshableAccessTokenCache(
                    ExchangeEntraToken,
                    ExchangeEntraTokenAsync,
                    false, null, null);
            _accessTokenCache.GetValueAsync(default);
        }

        private HttpPipeline CreatePipelineFromOptions(EntraCommunicationTokenCredentialOptions options, HttpPipelineTransport pipelineTransport)
        {
            var authenticationPolicy = new BearerTokenAuthenticationPolicy(options.TokenCredential, _scopes);
            var entraTokenGuardPolicy = new EntraTokenGuardPolicy();
            var clientOptions = ClientOptions.Default;
            if (pipelineTransport != null)
            {
                clientOptions.Transport = pipelineTransport;
            }
            return HttpPipelineBuilder.Build(clientOptions, authenticationPolicy, entraTokenGuardPolicy);
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
            => _accessTokenCache.GetValue(cancellationToken, () => true);

        /// <summary>
        /// Gets an <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns>
        /// A task that represents the asynchronous get token operation. The value of its <see cref="ValueTask{AccessToken}.Result"/> property contains the access token.
        /// </returns>
        public ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken = default)
            => _accessTokenCache.GetValueAsync(cancellationToken, () => true);

        private AccessToken ExchangeEntraToken(CancellationToken cancellationToken)
        {
            return ExchangeEntraTokenAsync(false, cancellationToken).EnsureCompleted();
        }

        private async ValueTask<AccessToken> ExchangeEntraTokenAsync(CancellationToken cancellationToken)
        {
            var result = await ExchangeEntraTokenAsync(true, cancellationToken).ConfigureAwait(false);
            return result;
        }

        private async ValueTask<AccessToken> ExchangeEntraTokenAsync(bool async, CancellationToken cancellationToken)
        {
            var message = CreateRequestMessage();
            if (async)
            {
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _pipeline.Send(message, cancellationToken);
            }
            return ParseAccessTokenFromResponse(message.Response);
        }

        private HttpMessage CreateRequestMessage()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Uri = CreateRequestUri();
            request.Method = RequestMethod.Post;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = "{}";

            return message;
        }

        private RequestUriBuilder CreateRequestUri()
        {
            var uri = new RequestUriBuilder();
            uri.Reset(new Uri(_resourceEndpoint));

            var (endpoint, apiVersion) = DetermineEndpointAndApiVersion();
            uri.AppendPath(endpoint, false);
            uri.AppendQuery("api-version", apiVersion, true);
            return uri;
        }

        private (string Endpoint, string ApiVersion) DetermineEndpointAndApiVersion()
        {
            if (_scopes.All(item => item.StartsWith(EntraCommunicationTokenScopes.TeamsExtensionScopePrefix)))
            {
                return (TeamsExtensionEndpoint, TeamsExtensionApiVersion);
            }
            else if (_scopes.All(item => item.StartsWith(EntraCommunicationTokenScopes.CommunicationClientsScopePrefix)))
            {
                return (CommunicationClientsEndpoint, CommunicationClientsApiVersion);
            }
            else
            {
                throw new ArgumentException($"Scopes validation failed. Ensure all scopes start with either {EntraCommunicationTokenScopes.TeamsExtensionScopePrefix} or {EntraCommunicationTokenScopes.CommunicationClientsScopePrefix}.", nameof(_scopes));
            }
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

        private class AcsToken
        {
            public string token { get; set; }
            public DateTimeOffset expiresOn { get; set; }
        }
    }
}
