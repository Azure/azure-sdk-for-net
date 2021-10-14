// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
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
        private const string ClientTokenResponseTokenPropertyName = "token";
        private static readonly char[] KeyValueSeparator = { '=' };
        private static readonly char[] PropertySeparator = { ';' };

        internal static byte[] s_role = Encoding.UTF8.GetBytes("role");

        /// <summary>
        /// Creates a URI with authentication token.
        /// </summary>
        /// <param name="expiresAt">UTC time when the token expires.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Uri GenerateClientAccessUri(DateTimeOffset expiresAt, string userId = default, IEnumerable<string> roles = default, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
            => GenerateClientAccessUriInternal(expiresAt, userId, roles, async: false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Creates a URI with authentication token.
        /// </summary>
        /// <param name="expiresAt">UTC time when the token expires.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Uri> GenerateClientAccessUriAsync(DateTimeOffset expiresAt, string userId = default, IEnumerable<string> roles = default, CancellationToken cancellationToken = default)
            => await GenerateClientAccessUriInternal(expiresAt, userId, roles, async: true, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0015 // Unexpected client method return type.

        /// <summary>
        /// Creates a URI with authentication token.
        /// </summary>
        /// <param name="expiresAfter">Defaults to one hour, if not specified. Must be greater or equal zero.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Uri GenerateClientAccessUri(
            TimeSpan expiresAfter = default,
            string userId = default,
            IEnumerable<string> roles = default,
            CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            DateTimeOffset expiresAt = GetExpiryTimeFromTimeSpan(expiresAfter);

            return GenerateClientAccessUri(expiresAt, userId, roles, cancellationToken);
        }

        /// <summary>
        /// Creates a URI with authentication token.
        /// </summary>
        /// <param name="expiresAfter">Defaults to one hour, if not specified. Must be greater or equal zero.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Uri> GenerateClientAccessUriAsync(TimeSpan expiresAfter = default, string userId = default, IEnumerable<string> roles = default, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            DateTimeOffset expiresAt = GetExpiryTimeFromTimeSpan(expiresAfter);

            return await GenerateClientAccessUriAsync(expiresAt, userId, roles, cancellationToken).ConfigureAwait(false);
        }

        private async Task<Uri> GenerateClientAccessUriInternal(
            DateTimeOffset expiresAt,
            string userId = default,
            IEnumerable<string> roles = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            string token;

            if (_tokenCredential != null)
            {
                RequestOptions options = new() { CancellationToken = cancellationToken };

                Response clientTokenResponse = async ?
                    await GenerateClientTokenImplAsync(options, userId, roles, expiresAt.Minute).ConfigureAwait(false) :
                    GenerateClientTokenImpl(options, userId, roles, expiresAt.Minute);
                token = JsonDocument.Parse(clientTokenResponse.Content).RootElement.GetProperty(ClientTokenResponseTokenPropertyName).GetString();
            }
            else if (_credential != null)
            {
                token = GenerateTokenFromAzureKeyCredential(expiresAt, userId, roles);
            }
            else
            {
                throw new InvalidOperationException($"{nameof(WebPubSubServiceClient)} must be constructed with either a {typeof(TokenCredential)} or {typeof(AzureKeyCredential)} to generate client access URIs.");
            }

            UriBuilder clientEndpoint = new(_endpoint)
            {
                Scheme = _endpoint.Scheme == "http" ? "ws" : "wss"
            };

            return new Uri($"{clientEndpoint}client/hubs/{_hub}?access_token={token}");
        }

        /// <summary>
        /// Computes expiry time as a <see cref="DateTimeOffset"/> from <see cref="DateTimeOffset.UtcNow"/>
        /// </summary>
        /// <param name="expiresAfter">Interval of expiry represented as a <see cref="TimeSpan"/></param>
        /// <returns>Expiration time.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If <c>expiresAfter.TotalMilliseconds</c> is less than 0.</exception>
        private static DateTimeOffset GetExpiryTimeFromTimeSpan(TimeSpan expiresAfter)
        {
            if (expiresAfter.TotalMilliseconds < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(expiresAfter));
            }

            DateTimeOffset expiresAt = DateTimeOffset.UtcNow;
            if (expiresAfter == default)
            {
                expiresAt += TimeSpan.FromHours(1);
            }
            else
            {
                expiresAt += expiresAfter;
            }

            return expiresAt;
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

        private string GenerateTokenFromAzureKeyCredential(DateTimeOffset expiresAt, string userId = default, IEnumerable<string> roles = default)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_credential.Key);

            var jwt = new JwtBuilder(keyBytes);
            var now = DateTimeOffset.UtcNow;

            string endpoint = _endpoint.AbsoluteUri;
            if (!endpoint.EndsWith("/", StringComparison.Ordinal))
            {
                endpoint += "/";
            }
            var audience = $"{endpoint}client/hubs/{_hub}";

            if (userId != default)
            {
                jwt.AddClaim(JwtBuilder.Sub, userId);
            }
            if (roles != default && roles.Any())
            {
                jwt.AddClaim(s_role, roles);
            }
            jwt.AddClaim(JwtBuilder.Nbf, now);
            jwt.AddClaim(JwtBuilder.Exp, expiresAt);
            jwt.AddClaim(JwtBuilder.Iat, now);
            jwt.AddClaim(JwtBuilder.Aud, audience);

            return jwt.BuildString();
        }
    }
}
