// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.WebPubSub.Chat
{
    public partial class WebPubSubChatServiceClient
    {
        private static readonly string[] ChatClientRoles = new[]
        {
            "webpubsub.getGroupState",
            "webpubsub.setGroupState"
        };

        // Token generation intentionally does not delegate to WebPubSubServiceClient. Doing so would
        // require a second options instance and a second pipeline, but ClientOptions cannot be copied
        // losslessly through its public API: reading Transport does not preserve whether it was explicitly
        // set, and policies added through AddPolicy cannot be enumerated. Retaining the credentials here
        // lets both chat operations and token generation use the one pipeline built from the caller's options.
        private readonly AzureKeyCredential _keyCredential;
        private readonly TokenCredential _tokenCredential;

        /// <summary>
        /// Generates a client access URI that a client can use to connect to the Web PubSub Chat service.
        /// The URI includes a JWT access token as a query parameter.
        /// </summary>
        /// <param name="options">Options controlling the generated token. Pass <c>null</c> to use defaults.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Uri"/> that a client can use to connect, with the access token included.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Uri GetClientAccessUri(
            ClientAccessUriOptions options = null,
            CancellationToken cancellationToken = default)
        {
            options ??= ClientAccessUriOptions.Default;
            TimeSpan expiresAfter = GetExpiresAfter(options);

            string token = _keyCredential != null
                ? GenerateClientToken(options, expiresAfter)
                : RequestClientToken(options, expiresAfter, cancellationToken);
            return CreateClientAccessUri(token);
        }
#pragma warning restore AZC0015

        /// <summary>
        /// Generates a client access URI that a client can use to connect to the Web PubSub Chat service.
        /// The URI includes a JWT access token as a query parameter.
        /// </summary>
        /// <param name="options">Options controlling the generated token. Pass <c>null</c> to use defaults.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Uri"/> that a client can use to connect, with the access token included.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Uri> GetClientAccessUriAsync(
            ClientAccessUriOptions options = null,
            CancellationToken cancellationToken = default)
        {
            options ??= ClientAccessUriOptions.Default;
            TimeSpan expiresAfter = GetExpiresAfter(options);

            string token = _keyCredential != null
                ? GenerateClientToken(options, expiresAfter)
                : await RequestClientTokenAsync(options, expiresAfter, cancellationToken).ConfigureAwait(false);
            return CreateClientAccessUri(token);
        }
#pragma warning restore AZC0015

        private string GenerateClientToken(ClientAccessUriOptions options, TimeSpan expiresAfter)
        {
            if (_keyCredential == null)
            {
                throw new InvalidOperationException("GetClientAccessUri requires the client to be constructed with credentials.");
            }

            string endpoint = _endpoint.AbsoluteUri;
            if (!endpoint.EndsWith("/", StringComparison.Ordinal))
            {
                endpoint += "/";
            }

            return WebPubSubClientAccessTokenGenerator.Generate(
                _keyCredential,
                $"{endpoint}{GetRelativeClientEndpoint()}",
                DateTimeOffset.UtcNow.Add(expiresAfter),
                options.UserId,
                ChatClientRoles);
        }

        private string RequestClientToken(ClientAccessUriOptions options, TimeSpan expiresAfter, CancellationToken cancellationToken)
        {
            EnsureTokenCredential();
            int minutesToExpire = Math.Max((int)expiresAfter.TotalMinutes, 1);
            return GenerateClientToken(options.UserId, ChatClientRoles, minutesToExpire, cancellationToken).Value.Token;
        }

        private async Task<string> RequestClientTokenAsync(ClientAccessUriOptions options, TimeSpan expiresAfter, CancellationToken cancellationToken)
        {
            EnsureTokenCredential();
            int minutesToExpire = Math.Max((int)expiresAfter.TotalMinutes, 1);
            Response<GenerateClientTokenResponse> response = await GenerateClientTokenAsync(options.UserId, ChatClientRoles, minutesToExpire, cancellationToken).ConfigureAwait(false);
            return response.Value.Token;
        }

        private Uri CreateClientAccessUri(string token)
        {
            UriBuilder clientEndpoint = new UriBuilder(_endpoint)
            {
                Scheme = _endpoint.Scheme == "http" ? "ws" : "wss"
            };

            return new Uri($"{clientEndpoint}{GetRelativeClientEndpoint()}?access_token={token}");
        }

        private string GetRelativeClientEndpoint() => $"client/hubs/{_hub}";

        private void EnsureTokenCredential()
        {
            if (_tokenCredential == null)
            {
                throw new InvalidOperationException("GetClientAccessUri requires the client to be constructed with credentials.");
            }
        }

        private static TimeSpan GetExpiresAfter(ClientAccessUriOptions options)
            => options.ExpiresAfter == default ? TimeSpan.FromHours(1) : options.ExpiresAfter;
    }
}
