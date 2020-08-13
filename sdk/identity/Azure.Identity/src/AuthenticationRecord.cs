// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Account information relating to an authentication request.
    /// </summary>
    internal class AuthenticationRecord
    {
        private const string UsernamePropertyName = "username";
        private const string AuthorityPropertyName = "authority";
        private const string HomeAccountIdPropertyName = "homeAccountId";
        private const string TenantIdPropertyName = "tenantId";
        private const string ClientIdPropertyName = "clientId";

        private static readonly JsonEncodedText s_usernamePropertyNameBytes = JsonEncodedText.Encode(UsernamePropertyName);
        private static readonly JsonEncodedText s_authorityPropertyNameBytes = JsonEncodedText.Encode(AuthorityPropertyName);
        private static readonly JsonEncodedText s_homeAccountIdPropertyNameBytes = JsonEncodedText.Encode(HomeAccountIdPropertyName);
        private static readonly JsonEncodedText s_tenantIdPropertyNameBytes = JsonEncodedText.Encode(TenantIdPropertyName);
        private static readonly JsonEncodedText s_clientIdPropertyNameBytes = JsonEncodedText.Encode(ClientIdPropertyName);

        internal AuthenticationRecord()
        {

        }

        internal AuthenticationRecord(AuthenticationResult authResult, string clientId)
        {
            Username = authResult.Account.Username;
            Authority = authResult.Account.Environment;
            AccountId = authResult.Account.HomeAccountId;
            TenantId = authResult.TenantId;
            ClientId = clientId;
        }

        internal AuthenticationRecord(string username, string authority, string homeAccountId, string tenantId, string clientId)
        {

            Username = username;
            Authority = authority;
            AccountId = new AccountId(homeAccountId);
            TenantId = tenantId;
            ClientId = clientId;
        }

        /// <summary>
        /// The user principal or service principal name of the account.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// The authority host used to authenticate the account.
        /// </summary>
        public string Authority { get; private set; }

        /// <summary>
        /// A unique identifier of the account.
        /// </summary>
        public string HomeAccountId { get => AccountId.Identifier; }

        /// <summary>
        /// The tenant the account should authenticate in.
        /// </summary>
        public string TenantId { get; private set; }

        /// <summary>
        /// The client id of the application which performed the original authentication
        /// </summary>
        public string ClientId { get; private set; }

        internal AccountId AccountId { get; private set; }

        /// <summary>
        /// Serializes the <see cref="AuthenticationRecord"/> to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> which the serialized <see cref="AuthenticationRecord"/> will be written to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public void Serialize(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream is null) throw new ArgumentNullException(nameof(stream));

            SerializeAsync(stream, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Serializes the <see cref="AuthenticationRecord"/> to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to which the serialized <see cref="AuthenticationRecord"/> will be written.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public async Task SerializeAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream is null) throw new ArgumentNullException(nameof(stream));

            await SerializeAsync(stream, true, cancellationToken).ConfigureAwait(false);
        }


        /// <summary>
        /// Deserializes the <see cref="AuthenticationRecord"/> from the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the serialized <see cref="AuthenticationRecord"/> will be read.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public static AuthenticationRecord Deserialize(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream is null) throw new ArgumentNullException(nameof(stream));

            return DeserializeAsync(stream, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Deserializes the <see cref="AuthenticationRecord"/> from the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the serialized <see cref="AuthenticationRecord"/> will be read.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public static async Task<AuthenticationRecord> DeserializeAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream is null) throw new ArgumentNullException(nameof(stream));

            return await DeserializeAsync(stream, true, cancellationToken).ConfigureAwait(false);
        }

        private async Task SerializeAsync(Stream stream, bool async, CancellationToken cancellationToken)
        {
            using (var json = new Utf8JsonWriter(stream))
            {

                json.WriteStartObject();

                json.WriteString(s_usernamePropertyNameBytes, Username);

                json.WriteString(s_authorityPropertyNameBytes, Authority);

                json.WriteString(s_homeAccountIdPropertyNameBytes, HomeAccountId);

                json.WriteString(s_tenantIdPropertyNameBytes, TenantId);

                json.WriteString(s_clientIdPropertyNameBytes, ClientId);

                json.WriteEndObject();

                if (async)
                {
                    await json.FlushAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    json.Flush();
                }
            }
        }

        private static async Task<AuthenticationRecord> DeserializeAsync(Stream stream, bool async, CancellationToken cancellationToken)
        {
            var authProfile = new AuthenticationRecord();

            using JsonDocument doc = async ? await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken).ConfigureAwait(false) : JsonDocument.Parse(stream);

            foreach (JsonProperty prop in doc.RootElement.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case UsernamePropertyName:
                        authProfile.Username = prop.Value.GetString();
                        break;
                    case AuthorityPropertyName:
                        authProfile.Authority = prop.Value.GetString();
                        break;
                    case HomeAccountIdPropertyName:
                        authProfile.AccountId = new AccountId(prop.Value.GetString());
                        break;
                    case TenantIdPropertyName:
                        authProfile.TenantId = prop.Value.GetString();
                        break;
                    case ClientIdPropertyName:
                        authProfile.ClientId = prop.Value.GetString();
                        break;
                }
            }

            return authProfile;
        }
    }
}
