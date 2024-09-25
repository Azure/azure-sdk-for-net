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
        private readonly Uri _endpoint;
        private readonly AzureKeyCredential _keyCredential;
        private readonly string _hub;

        public WebPubSubForSocketIOService(Uri endpoint, AzureKeyCredential keyCredential, string hub)
        {
            _client = new WebPubSubServiceClient(endpoint, hub, keyCredential);
            _endpoint = endpoint;
            _keyCredential = keyCredential;
            _hub = hub;
            _useConnectionStrings = true;
        }

        public WebPubSubForSocketIOService(Uri endpoint, TokenCredential credential, string hub)
        {
            _client = new WebPubSubServiceClient(endpoint, hub, credential);
            _endpoint = endpoint;
            _hub = hub;
            _useConnectionStrings = false;
        }

        // For tests.
        public WebPubSubForSocketIOService(WebPubSubServiceClient client, Uri endpoint = null, string hub = null, bool useConnectionStrings = false)
        {
            _client = client;
            _endpoint = endpoint;
            _hub = hub;
            _useConnectionStrings = useConnectionStrings;
        }

        public WebPubSubServiceClient Client => _client;

        internal SocketIONegotiationResult GetNegotiationResult(string userId)
        {
            if (_useConnectionStrings)
            {
                var expireAfter = TimeSpan.FromHours(1);
                var token = GenerateTokenFromAzureKeyCredential(userId, DateTimeOffset.UtcNow.Add(expireAfter));
                return new SocketIONegotiationResult(new Uri($"{_endpoint.AbsoluteUri.TrimEnd('/')}/clients/socketio/hubs/{_hub}?access_token={token}"));
            }
            else
            {
                // For managed identity, the service can generate token for you.
                // TODO: Currently, there's a bug in `GetClientAccessUri` that the path in url is for wps not for socketio but the token is correct
                // We need to concat them manually.
                var url = _client.GetClientAccessUri(userId: userId);
                var token = HttpUtility.ParseQueryString(url.Query)["access_token"];
                return new SocketIONegotiationResult(new Uri($"{_endpoint.AbsoluteUri.TrimEnd('/')}/clients/socketio/hubs/{_hub}?access_token={token}"));
            }
        }

        private string GenerateTokenFromAzureKeyCredential(string userId, DateTimeOffset expiresAt)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_keyCredential.Key);

            var jwt = new JwtBuilder(keyBytes);
            var now = DateTimeOffset.UtcNow;

            string endpoint = _endpoint.AbsoluteUri;
            if (!endpoint.EndsWith("/", StringComparison.Ordinal))
            {
                endpoint += "/";
            }
            var audience = $"{endpoint}clients/socketio/hubs/{_hub}";

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
