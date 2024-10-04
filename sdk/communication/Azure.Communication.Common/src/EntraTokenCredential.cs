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
        private TokenCredential _tokenCredential;
        private string[] _scopes;
        private AccessToken _currentToken;
        private readonly object _syncLock = new object();
        private bool _someThreadIsExchanging;

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
            _currentToken = default;
            _pipeline = default;
        }

        /// <summary>
        /// Gets an <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns> Contains the access token.</returns>
        public AccessToken GetToken(CancellationToken cancellationToken)
        {
            return GetTokenAsync(cancellationToken).Result;
        }

        /// <summary>
        /// Gets an <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns>
        /// A task that represents the asynchronous get token operation. The value of its <see cref="ValueTask{AccessToken}.Result"/> property contains the access token.
        /// </returns>
        public ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken)
        {
            return GetValueAsync(cancellationToken);
        }

        private async ValueTask<AccessToken> GetValueAsync(CancellationToken cancellationToken)
        {
            if (IsTokenValid(_currentToken))
                return _currentToken;

            var shouldThisThreadExchange = false;
            lock (_syncLock)
            {
                while (!IsTokenValid(_currentToken))
                {
                    if (_someThreadIsExchanging)
                    {
                        if (IsTokenValid(_currentToken))
                            return _currentToken;

                        WaitForInProgressThreadFinish();
                    }
                    else
                    {
                        shouldThisThreadExchange = true;
                        _someThreadIsExchanging = true;
                        break;
                    }
                }
            }

            if (shouldThisThreadExchange)
            {
                try
                {
                    AccessToken result = await ExchangeEntraToken(cancellationToken).ConfigureAwait(false);
                    lock (_syncLock)
                    {
                        _currentToken = result;
                        Thread.MemoryBarrier();
                        _someThreadIsExchanging = false;
                        NotifyTokenExchangeDone();
                    }
                }
                catch
                {
                    lock (_syncLock)
                    {
                        _someThreadIsExchanging = false;
                        NotifyTokenExchangeDone();
                    }
                    throw;
                }
            }

            return _currentToken;

            void WaitForInProgressThreadFinish()
                => Monitor.Wait(_syncLock);

            void NotifyTokenExchangeDone()
                => Monitor.PulseAll(_syncLock);
        }

        private bool IsTokenValid(AccessToken? token)
            => token != null && DateTimeOffset.UtcNow < token?.ExpiresOn;

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
        public void SetPipeline(HttpPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        private partial class AcsToken
        {
            public string token { get; set; }
            public DateTimeOffset expiresOn { get; set; }
        }
    }
}
