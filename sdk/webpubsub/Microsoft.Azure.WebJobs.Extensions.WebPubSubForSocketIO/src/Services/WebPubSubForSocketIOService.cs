// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;
using Azure.Messaging.WebPubSub;
using System;
using System.Text;
using System.Web;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class WebPubSubForSocketIOService : IWebPubSubForSocketIOService
    {
        private readonly WebPubSubServiceClient _client;
        private readonly bool _useConnectionStrings;
        private readonly AzureKeyCredential _keyCredential;

        public WebPubSubForSocketIOService(Uri endpoint, AzureKeyCredential keyCredential, string hub)
            : this(new WebPubSubServiceClient(endpoint, hub, keyCredential), keyCredential)
        {
        }

        public WebPubSubForSocketIOService(Uri endpoint, TokenCredential credential, string hub)
            : this(new WebPubSubServiceClient(endpoint, hub, credential))
        {
        }

        // For tests.
        internal WebPubSubForSocketIOService(WebPubSubServiceClient client, AzureKeyCredential keyCredential = null)
        {
            _client = client;
            if (keyCredential != null)
            {
                _keyCredential = keyCredential;
                _useConnectionStrings = true;
            }
        }

        public WebPubSubServiceClient Client => _client;

        internal SocketIONegotiationResult GetNegotiationResult(string userId)
        {
            if (_useConnectionStrings)
            {
                var expireAfter = TimeSpan.FromHours(1);
                var token = GenerateTokenFromAzureKeyCredential(userId, DateTimeOffset.UtcNow.Add(expireAfter));
                return new SocketIONegotiationResult(new Uri($"{_client.Endpoint.AbsoluteUri.TrimEnd('/')}/clients/socketio/hubs/{_client.Hub}?access_token={token}"));
            }
            else
            {
                // For managed identity, the service can generate token for you.
                // TODO: Currently, there's a bug in `GetClientAccessUri` that the path in url is for wps not for socketio but the token is correct
                // We need to concat them manually.
                var url = _client.GetClientAccessUri(userId: userId);
                var token = HttpUtility.ParseQueryString(url.Query)["access_token"];
                return new SocketIONegotiationResult(new Uri($"{_client.Endpoint.AbsoluteUri.TrimEnd('/')}/clients/socketio/hubs/{_client.Hub}?access_token={token}"));
            }
        }

        private string GenerateTokenFromAzureKeyCredential(string userId, DateTimeOffset expiresAt)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_keyCredential.Key);

            var jwt = new JwtBuilder(keyBytes);
            var now = DateTimeOffset.UtcNow;

            string endpoint = _client.Endpoint.AbsoluteUri;
            var audience = $"{endpoint.TrimEnd('/')}/clients/socketio/hubs/{_client.Hub}";

            jwt.AddClaim(JwtBuilder.Nbf, now);
            jwt.AddClaim(JwtBuilder.Exp, expiresAt);
            jwt.AddClaim(JwtBuilder.Iat, now);
            jwt.AddClaim(JwtBuilder.Aud, audience);

            if (!string.IsNullOrEmpty(userId))
            {
                jwt.AddClaim(JwtBuilder.Sub, userId);
            }

            return jwt.BuildString();
        }
    }
}
