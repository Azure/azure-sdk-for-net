// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        internal static byte[] s_group = Encoding.UTF8.GetBytes("webpubsub.group");

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAt">UTC time when the token expires.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Uri GetClientAccessUri(DateTimeOffset expiresAt, string userId, IEnumerable<string> roles, CancellationToken cancellationToken)
#pragma warning restore AZC0015 // Unexpected client method return type.
            => GetClientAccessUriInternal(expiresAt, userId, roles, null, WebPubSubClientAccess.Default, async: false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAt">UTC time when the token expires.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="groups">Groups that the connection with the generated token will join when it connects.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Uri GetClientAccessUri(DateTimeOffset expiresAt, string userId, IEnumerable<string> roles, IEnumerable<string> groups, CancellationToken cancellationToken)
#pragma warning restore AZC0015 // Unexpected client method return type.
            => GetClientAccessUriInternal(expiresAt, userId, roles, groups, WebPubSubClientAccess.Default, async: false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAt">UTC time when the token expires.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="groups">Groups that the connection with the generated token will join when it connects.</param>
        /// <param name="clientType">The client type.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Uri GetClientAccessUri(DateTimeOffset expiresAt, string userId = default, IEnumerable<string> roles = default, IEnumerable<string> groups = default, WebPubSubClientAccess clientType = default, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
            => GetClientAccessUriInternal(expiresAt, userId, roles, groups, clientType, async: false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAt">UTC time when the token expires.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Uri> GetClientAccessUriAsync(DateTimeOffset expiresAt, string userId, IEnumerable<string> roles, CancellationToken cancellationToken)
            => await GetClientAccessUriInternal(expiresAt, userId, roles, null, WebPubSubClientAccess.Default, async: true, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0015 // Unexpected client method return type.

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAt">UTC time when the token expires.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="groups">Groups that the connection with the generated token will join when it connects.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Uri> GetClientAccessUriAsync(DateTimeOffset expiresAt, string userId, IEnumerable<string> roles, IEnumerable<string> groups, CancellationToken cancellationToken)
            => await GetClientAccessUriInternal(expiresAt, userId, roles, groups, WebPubSubClientAccess.Default, async: true, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0015 // Unexpected client method return type.

        /// <summary>
        /// Creates a URI with authentication token for the clients..
        /// </summary>
        /// <param name="expiresAt">UTC time when the token expires.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="groups">Groups that the connection with the generated token will join when it connects.</param>
        /// <param name="clientType">The client type.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Uri> GetClientAccessUriAsync(DateTimeOffset expiresAt, string userId = default, IEnumerable<string> roles = default, IEnumerable<string> groups = default, WebPubSubClientAccess clientType = default, CancellationToken cancellationToken = default)
            => await GetClientAccessUriInternal(expiresAt, userId, roles, groups, clientType, async: true, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0015 // Unexpected client method return type.

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAfter">Defaults to one hour, if not specified. Must be greater or equal zero.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Uri GetClientAccessUri(
            TimeSpan expiresAfter,
            string userId,
            IEnumerable<string> roles,
            CancellationToken cancellationToken)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            return GetClientAccessUriInternal(expiresAfter, userId, roles, null, WebPubSubClientAccess.Default, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAfter">Defaults to one hour, if not specified. Must be greater or equal zero.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="groups">Groups that the connection with the generated token will join when it connects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Uri GetClientAccessUri(
            TimeSpan expiresAfter,
            string userId,
            IEnumerable<string> roles,
            IEnumerable<string> groups,
            CancellationToken cancellationToken)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            return GetClientAccessUriInternal(expiresAfter, userId, roles, groups, WebPubSubClientAccess.Default, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAfter">Defaults to one hour, if not specified. Must be greater or equal zero.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="groups">Groups that the connection with the generated token will join when it connects.</param>
        /// <param name="clientType">The client type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Uri GetClientAccessUri(
            TimeSpan expiresAfter = default,
            string userId = default,
            IEnumerable<string> roles = default,
            IEnumerable<string> groups = default,
            WebPubSubClientAccess clientType = default,
            CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            return GetClientAccessUriInternal(expiresAfter, userId, roles, groups, clientType, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAfter">Defaults to one hour, if not specified. Must be greater or equal zero.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Uri> GetClientAccessUriAsync(
            TimeSpan expiresAfter,
            string userId,
            IEnumerable<string> roles,
            CancellationToken cancellationToken)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            return await GetClientAccessUriInternal(expiresAfter, userId, roles, null, WebPubSubClientAccess.Default, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAfter">Defaults to one hour, if not specified. Must be greater or equal zero.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="groups">Groups that the connection with the generated token will join when it connects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Uri> GetClientAccessUriAsync(
            TimeSpan expiresAfter,
            string userId,
            IEnumerable<string> roles,
            IEnumerable<string> groups,
            CancellationToken cancellationToken)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            return await GetClientAccessUriInternal(expiresAfter, userId, roles, groups, WebPubSubClientAccess.Default, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a URI with authentication token for the clients.
        /// </summary>
        /// <param name="expiresAfter">Defaults to one hour, if not specified. Must be greater or equal zero.</param>
        /// <param name="userId">User Id.</param>
        /// <param name="roles">Roles that the connection with the generated token will have.</param>
        /// <param name="groups">Groups that the connection with the generated token will join when it connects.</param>
        /// <param name="clientType">The client type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Uri> GetClientAccessUriAsync(
            TimeSpan expiresAfter = default,
            string userId = default,
            IEnumerable<string> roles = default,
            IEnumerable<string> groups = default,
            WebPubSubClientAccess clientType = default,
            CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            return await GetClientAccessUriInternal(expiresAfter, userId, roles, groups, clientType, true, cancellationToken).ConfigureAwait(false);
        }

        internal static int GetMinutesToExpire(TimeSpan expiresAfter) => Math.Max((int)expiresAfter.TotalMinutes, 1);

        internal static int GetMinutesToExpire(DateTimeOffset expiresAt) => Math.Max((int)expiresAt.Subtract(DateTimeOffset.UtcNow).TotalMinutes, 1);

        private async Task<Uri> GetClientAccessUriInternal(
           DateTimeOffset expiresAt,
           string userId = default,
           IEnumerable<string> roles = default,
           IEnumerable<string> groups = default,
           WebPubSubClientAccess clientType = default,
           bool async = true,
           CancellationToken cancellationToken = default)
        {
            var token = await GetClientAccessTokenCore(expiresAt, userId, roles, groups, clientType, async, cancellationToken: cancellationToken).ConfigureAwait(false);
            return GetClientAccessUriInternal(token, clientType);
        }

        private Task<Uri> GetClientAccessUriInternal(
            TimeSpan expireAfter,
            string userId = default,
            IEnumerable<string> roles = default,
            IEnumerable<string> groups = default,
            WebPubSubClientAccess clientType = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            return GetClientAccessUriInternal(expireAfter == default ? DateTimeOffset.UtcNow.Add(TimeSpan.FromHours(1)) : DateTimeOffset.UtcNow.Add(expireAfter), userId, roles, groups, clientType, async, cancellationToken);
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

        private string GenerateTokenFromAzureKeyCredential(DateTimeOffset expiresAt, WebPubSubClientAccess endpointType, string userId = default, IEnumerable<string> roles = default, IEnumerable<string> groups = default)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_credential.Key);

            var jwt = new JwtBuilder(keyBytes);
            var now = DateTimeOffset.UtcNow;

            string endpoint = Endpoint.AbsoluteUri;
            if (!endpoint.EndsWith("/", StringComparison.Ordinal))
            {
                endpoint += "/";
            }
            var audience = $"{endpoint}{GetRelativeClientEndpoint(endpointType)}";

            if (userId != default)
            {
                jwt.AddClaim(JwtBuilder.Sub, userId);
            }
            if (roles != default && roles.Any())
            {
                jwt.AddClaim(s_role, roles);
            }
            if (groups != default && groups.Any())
            {
                jwt.AddClaim(s_group, groups);
            }
            jwt.AddClaim(JwtBuilder.Nbf, now);
            jwt.AddClaim(JwtBuilder.Exp, expiresAt);
            jwt.AddClaim(JwtBuilder.Iat, now);
            jwt.AddClaim(JwtBuilder.Aud, audience);

            return jwt.BuildString();
        }

        private string GetRelativeClientEndpoint(WebPubSubClientAccess endpointType) => endpointType switch
        {
            WebPubSubClientAccess.Default => $"client/hubs/{_hub}",
            WebPubSubClientAccess.Mqtt => $"clients/mqtt/hubs/{_hub}",
            _ => throw new ArgumentOutOfRangeException(nameof(endpointType))
        };

        private async Task<string> GetClientAccessTokenCore(
             DateTimeOffset expiresAt,
             string userId,
             IEnumerable<string> roles,
             IEnumerable<string> groups,
             WebPubSubClientAccess clientAccess,
             bool async,
             CancellationToken cancellationToken = default)
        {
            if (clientAccess == WebPubSubClientAccess.Mqtt && _apiVersionEnum < WebPubSubServiceClientOptions.ServiceVersion.V2024_01_01)
            {
                throw new NotSupportedException($"Generating a client access URI for MQTT is only supported in API version {WebPubSubServiceClientOptions.ServiceVersion.V2024_01_01.ToVersionString()} or later.  You are currently using API version {_apiVersion}.");
            }
            var clientEndpointString = clientAccess switch
            {
                WebPubSubClientAccess.Default => "default",
                WebPubSubClientAccess.Mqtt => "mqtt",
                _ => throw new ArgumentOutOfRangeException(nameof(clientAccess))
            };
            if (_tokenCredential != null)
            {
                RequestContext context = new() { CancellationToken = cancellationToken };

                var minutesToExpire = GetMinutesToExpire(expiresAt);

                Response clientTokenResponse = async ?
                    await GenerateClientTokenImplAsync(userId, roles, minutesToExpire, groups, clientEndpointString, context).ConfigureAwait(false) :
                    GenerateClientTokenImpl(userId, roles, minutesToExpire, null, clientEndpointString, context);
                using var jsonDocument = JsonDocument.Parse(clientTokenResponse.Content);
                return jsonDocument.RootElement.GetProperty(ClientTokenResponseTokenPropertyName).GetString();
            }
            else if (_credential != null)
            {
                return GenerateTokenFromAzureKeyCredential(expiresAt, clientAccess, userId, roles, groups);
            }
            else
            {
                throw new InvalidOperationException($"{nameof(WebPubSubServiceClient)} must be constructed with either a {typeof(TokenCredential)} or {typeof(AzureKeyCredential)} to generate client access URIs.");
            }
        }

        private Uri GetClientAccessUriInternal(string token, WebPubSubClientAccess endpointType)
        {
            UriBuilder clientEndpoint = new(Endpoint)
            {
                Scheme = Endpoint.Scheme == "http" ? "ws" : "wss"
            };

            return new Uri($"{clientEndpoint}{GetRelativeClientEndpoint(endpointType)}?access_token={token}");
        }
    }
}
