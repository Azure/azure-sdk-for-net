// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{


    /// <summary>
    /// Account profile information relating to an authentication request.
    /// </summary>
    public class AuthenticationProfile
    {
        private const string UsernamePropertyName = "username";
        private const string AuthorityPropertyName = "authority";
        private const string HomeAccountIdPropertyName = "homeAccountId";
        private const string TenantIdPropertyName = "tenantId";
        private const string AdditionalDataPropertyName = "additionalData";

        private static readonly JsonEncodedText s_usernamePropertyNameBytes = JsonEncodedText.Encode(UsernamePropertyName);
        private static readonly JsonEncodedText s_authorityPropertyNameBytes = JsonEncodedText.Encode(AuthorityPropertyName);
        private static readonly JsonEncodedText s_homeAccountIdPropertyNameBytes = JsonEncodedText.Encode(HomeAccountIdPropertyName);
        private static readonly JsonEncodedText s_tenantIdPropertyNameBytes = JsonEncodedText.Encode(TenantIdPropertyName);
        private static readonly JsonEncodedText s_additionalDataPropertyNameBytes = JsonEncodedText.Encode(AdditionalDataPropertyName);

        private Lazy<Dictionary<string, string>> _additionalData = new Lazy<Dictionary<string, string>>();

        internal AuthenticationProfile()
        {

        }

        internal AuthenticationProfile(Microsoft.Identity.Client.AuthenticationResult authResult)
        {
            Username = authResult.Account.Username;
            Authority = authResult.Account.Environment;
            AccountId = authResult.Account.HomeAccountId;
            TenantId = authResult.TenantId;
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
        /// Additional data to be stored in the <see cref="AuthenticationProfile"/>.
        /// </summary>
        public Dictionary<string, string> AdditionalData => _additionalData.Value;

        internal AccountId AccountId { get; private set; }

        /// <summary>
        /// Serializes the <see cref="AuthenticationProfile"/> to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> which the serialized <see cref="AuthenticationProfile"/> will be written to.</param>
        public void Serialize(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            SerializeAsync(stream, false).EnsureCompleted();
        }

        /// <summary>
        /// Serializes the <see cref="AuthenticationProfile"/> to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to which the serialized <see cref="AuthenticationProfile"/> will be written.</param>
        public async Task SerializeAsync(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            await SerializeAsync(stream, true).ConfigureAwait(false);
        }


        /// <summary>
        /// Deserializes the <see cref="AuthenticationProfile"/> from the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the serialized <see cref="AuthenticationProfile"/> will be read.</param>
        public static AuthenticationProfile Deserialize(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            return DeserializeAsync(stream, false).EnsureCompleted();
        }

        /// <summary>
        /// Deserializes the <see cref="AuthenticationProfile"/> from the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the serialized <see cref="AuthenticationProfile"/> will be read.</param>
        public static async Task<AuthenticationProfile> DeserializeAsync(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            return await DeserializeAsync(stream, true).ConfigureAwait(false);
        }

        private async Task SerializeAsync(Stream stream, bool async)
        {
            using (var json = new Utf8JsonWriter(stream))
            {

                json.WriteStartObject();

                json.WriteString(s_usernamePropertyNameBytes, Username);

                json.WriteString(s_authorityPropertyNameBytes, Authority);

                json.WriteString(s_homeAccountIdPropertyNameBytes, HomeAccountId);

                json.WriteString(s_tenantIdPropertyNameBytes, TenantId);

                json.WriteStartObject(s_additionalDataPropertyNameBytes);

                if (_additionalData.IsValueCreated)
                {
                    foreach (var kvp in AdditionalData)
                    {
                        json.WriteString(kvp.Key, kvp.Value);
                    }
                }

                json.WriteEndObject();

                json.WriteEndObject();

                if (async)
                {
                    await json.FlushAsync().ConfigureAwait(false);
                }
                else
                {
                    json.Flush();
                }
            }
        }

        private static async Task<AuthenticationProfile> DeserializeAsync(Stream stream, bool async)
        {
            var authProfile = new AuthenticationProfile();

            using JsonDocument doc = async ? await JsonDocument.ParseAsync(stream).ConfigureAwait(false) : JsonDocument.Parse(stream);

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
                    case AdditionalDataPropertyName:
                        foreach (JsonProperty addProp in prop.Value.EnumerateObject())
                        {
                            authProfile.AdditionalData.Add(addProp.Name, addProp.Value.GetString());
                        }
                        break;
                }
            }

            return authProfile;
        }
    }
}
