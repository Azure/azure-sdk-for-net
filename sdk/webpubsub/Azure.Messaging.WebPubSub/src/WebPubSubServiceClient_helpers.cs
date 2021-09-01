// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Azure Web PubSub Service Client.
    /// </summary>
    public partial class WebPubSubServiceClient
    {
        private const string EndpointPropertyName = "Endpoint";
        private const string AccessKeyPropertyName = "AccessKey";
        private const string PortPropertyName = "Port";
        private const string ClientTokenResponseTokenPropertyName = "token";
        private static readonly char[] KeyValueSeparator = { '=' };
        private static readonly char[] PropertySeparator = { ';' };

        internal static byte[] s_role = Encoding.UTF8.GetBytes("role");

        /// <summary>
        /// Creates a URI with authentication token.
        /// </summary>
        /// <param name="expiresAt">UTC time when the token expires.</param>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public virtual Response<Uri> GenerateClientAccessUri(DateTimeOffset expiresAt, string userId = default, params string[] roles)
        {
            string token;
            Response clientTokenResponse = null;

            if (_tokenCredential != null)
            {
                clientTokenResponse = GenerateClientToken(userId, roles, expiresAt.Minute);
                token = JsonDocument.Parse(clientTokenResponse.Content).RootElement.GetProperty(ClientTokenResponseTokenPropertyName).GetString();
            }
            else
            {
                token = GetTokenFromAzureKeyCredential(expiresAt, userId, roles);
            }

            Uri clientAccessUri = CreateClientAccessUri(token);

            return Response.FromValue(clientAccessUri, clientTokenResponse);
        }

        /// <summary>
        /// Creates a URI with authentication token.
        /// </summary>
        /// <param name="expiresAt">UTC time when the token expires.</param>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public virtual async Task<Response<Uri>> GenerateClientAccessUriAsync(DateTimeOffset expiresAt, string userId = default, params string[] roles)
        {
            string token;
            Response clientTokenResponse = null;

            if (_tokenCredential != null)
            {
                clientTokenResponse = await GenerateClientTokenAsync(userId, roles, expiresAt.Minute).ConfigureAwait(false);
                token = JsonDocument.Parse(clientTokenResponse.Content).RootElement.GetProperty(ClientTokenResponseTokenPropertyName).GetString();
            }
            else
            {
                token = GetTokenFromAzureKeyCredential(expiresAt, userId, roles);
            }

            Uri clientAccessUri = CreateClientAccessUri(token);

            return Response.FromValue(clientAccessUri, clientTokenResponse);
        }

        /// <summary>
        /// Creates a URI with authentication token.
        /// </summary>
        /// <param name="expiresAfter">Defaults to one hour, if not specified. Must be greater or equal zero.</param>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public virtual Uri GenerateClientAccessUri(TimeSpan expiresAfter = default, string userId = default, params string[] roles)
        {
            if (expiresAfter.TotalMilliseconds < 0)
                throw new ArgumentOutOfRangeException(nameof(expiresAfter));

            DateTimeOffset expiresAt = DateTimeOffset.UtcNow;
            if (expiresAfter == default)
            {
                expiresAt += TimeSpan.FromHours(1);
            }
            else
            {
                expiresAt += expiresAfter;
            }
            return GenerateClientAccessUri(expiresAt, userId, roles);
        }

        /// <summary>
        /// Parse connection string to endpoint and credential.
        /// </summary>
        /// <returns></returns>
        internal static (Uri Endpoint, AzureKeyCredential Credential) ParseConnectionString(string connectionString)
        {
            Argument.AssertNotNull(connectionString, nameof(connectionString));

            var properties = connectionString.Split(PropertySeparator, StringSplitOptions.RemoveEmptyEntries);

            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var property in properties)
            {
                var kvp = property.Split(KeyValueSeparator, 2);
                if (kvp.Length != 2)
                    continue;

                var key = kvp[0].Trim();
                if (dict.ContainsKey(key))
                {
                    throw new ArgumentException($"Duplicate properties found in connection string: {key}.");
                }

                dict.Add(key, kvp[1].Trim());
            }

            if (!dict.TryGetValue(EndpointPropertyName, out var endpoint))
            {
                throw new ArgumentException($"Required property not found in connection string: {EndpointPropertyName}.");
            }
            endpoint = endpoint.TrimEnd('/');

            if (!dict.TryGetValue(AccessKeyPropertyName, out var accessKey))
            {
                throw new ArgumentException($"Required property not found in connection string: {AccessKeyPropertyName}.");
            }

            int? port = null;
            if (dict.TryGetValue(PortPropertyName, out var rawPort))
            {
                if (int.TryParse(rawPort, out var portValue) && portValue > 0 && portValue <= 0xFFFF)
                {
                    port = portValue;
                }
                else
                {
                    throw new ArgumentException($"Invalid Port value: {rawPort}");
                }
            }

            var uriBuilder = new UriBuilder(endpoint);
            if (port.HasValue)
            {
                uriBuilder.Port = port.Value;
            }

            return (uriBuilder.Uri, new AzureKeyCredential(accessKey));
        }

        internal static string PermissionToString(WebPubSubPermission permission)
        {
            switch (permission)
            {
                case WebPubSubPermission.SendToGroup:
                    return "sendToGroup";
                case WebPubSubPermission.JoinLeaveGroup:
                    return "joinLeaveGroup";
                default:
                    throw new ArgumentOutOfRangeException(nameof(permission));
            }
        }

        private string GetTokenFromAzureKeyCredential(DateTimeOffset expiresAt, string userId = default, params string[] roles)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_credential.Key);

            var jwt = new JwtBuilder(keyBytes);
            var now = DateTimeOffset.UtcNow;

            string endpoint = this.endpoint.AbsoluteUri;
            if (!endpoint.EndsWith("/", StringComparison.Ordinal))
            {
                endpoint += "/";
            }
            var audience = $"{endpoint}client/hubs/{hub}";

            if (userId != default)
            {
                jwt.AddClaim(JwtBuilder.Sub, userId);
            }
            if (roles != default && roles.Length > 0)
            {
                jwt.AddClaim(s_role, roles);
            }
            jwt.AddClaim(JwtBuilder.Nbf, now);
            jwt.AddClaim(JwtBuilder.Exp, expiresAt);
            jwt.AddClaim(JwtBuilder.Iat, now);
            jwt.AddClaim(JwtBuilder.Aud, audience);

            return jwt.BuildString();
        }

        private Uri CreateClientAccessUri(string token)
        {
            UriBuilder clientEndpoint = new(endpoint)
            {
                Scheme = endpoint.Scheme == "http" ? "ws" : "wss"
            };

            return new Uri($"{clientEndpoint}client/hubs/{hub}?access_token={token}");
        }
    }
}
