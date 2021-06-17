// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Claims;
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
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <param name="expiresAfter">Defaults to one hour, if not specified.</param>
        /// <returns></returns>
        public virtual Uri GenerateClientAccessUri(string userId = default, string[] roles = default, TimeSpan expiresAfter = default)
        {
            if (expiresAfter == default)
            {
                expiresAfter = TimeSpan.FromHours(1);
            }

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

            string token = WebPubSubAuthenticationPolicy.GenerateAccessToken(audience, claims, _credential, expiresAfter);

            var clientEndpoint = new UriBuilder(endpoint);
            clientEndpoint.Scheme = this.endpoint.Scheme == "http" ? "ws" : "wss";
            var uriString = $"{clientEndpoint}client/hubs/{hub}?access_token={token}";

            return new Uri(uriString);
        }

        /// <summary>
        /// Parse connection string to endpoint and credential
        /// </summary>
        /// <returns></returns>
        internal static (Uri Endpoint, AzureKeyCredential Credential) ParseConnectionString(string connectionString)
        {
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
    }
}
