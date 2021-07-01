// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Claims;
using Azure.Core;
using Azure.Core.Pipeline;

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
        private static readonly char[] KeyValueSeparator = { '=' };
        private static readonly char[] PropertySeparator = { ';' };

        /// <summary>
        /// Creates a URI with authentication token.
        /// </summary>
        /// <param name="expiresAtUtc">UTC time when the token expires.</param>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public virtual Uri GenerateClientAccessUri(DateTime expiresAtUtc, string userId = default, params string[] roles)
        {
            List<Claim> claims = new List<Claim>();
            if (userId != default)
            {
                var subject = new Claim("sub", userId);
                claims.Add(subject);
            }
            if (roles != default && roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim("role", role));
                }
            }

            string endpoint = this.endpoint.AbsoluteUri;
            if (!endpoint.EndsWith("/", StringComparison.Ordinal))
            {
                endpoint += "/";
            }
            var audience = $"{endpoint}client/hubs/{hub}";

            string token = WebPubSubAuthenticationPolicy.GenerateAccessToken(audience, claims, _credential, expiresAtUtc);

            var clientEndpoint = new UriBuilder(endpoint);
            clientEndpoint.Scheme = this.endpoint.Scheme == "http" ? "ws" : "wss";
            var uriString = $"{clientEndpoint}client/hubs/{hub}?access_token={token}";

            return new Uri(uriString);
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

            DateTime expiresAt = DateTime.UtcNow;
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
        /// Parse connection string to endpoint and credential
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
    }
}
