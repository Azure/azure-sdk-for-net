// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// A policy that describes the conditions when a key can be exported.
    /// </summary>
    public class KeyReleasePolicy : IJsonDeserializable, IJsonSerializable
    {
        // TODO: Consider adding factory support, but with changes coming in soon everything may be publicly settabe anyway.

        private const string VersionPropertyName = "version";
        private const string AuthoritiesPropertyName = "anyOf";

        private static readonly JsonEncodedText s_versionPropertyNameBytes = JsonEncodedText.Encode(VersionPropertyName);
        private static readonly JsonEncodedText s_authoritiesPropertyNameBytes = JsonEncodedText.Encode(AuthoritiesPropertyName);

        /// <summary>
        /// Creates a new instance of the <see cref="KeyReleasePolicy"/> class.
        /// </summary>
        /// <param name="authorities">A collection of <see cref="KeyReleaseAuthority"/> for which at least one must match to export a key.</param>
        /// <exception cref="ArgumentNullException"><paramref name="authorities"/> is null.</exception>
        public KeyReleasePolicy(IEnumerable<KeyReleaseAuthority> authorities)
        {
            Argument.AssertNotNull(authorities, nameof(authorities));

            Authorities = authorities.ToList();
        }

        internal KeyReleasePolicy()
        {
            Authorities = new List<KeyReleaseAuthority>();
        }

        /// <summary>
        /// Gets the schema version of the <see cref="KeyReleasePolicy"/>.
        /// </summary>
        public string Version { get; internal set; } = "0.2";

        /// <summary>
        /// Gets a collection of <see cref="KeyReleaseAuthority"/> for which at least one must match to export a key.
        /// </summary>
        public IList<KeyReleaseAuthority> Authorities { get; }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case VersionPropertyName:
                        Version = prop.Value.GetString();
                        break;
                    case AuthoritiesPropertyName:
                        foreach (JsonElement element in prop.Value.EnumerateArray())
                        {
                            KeyReleaseAuthority authority = new KeyReleaseAuthority();
                            authority.ReadProperties(element);

                            Authorities.Add(authority);
                        }
                        break;
                }
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(s_versionPropertyNameBytes, Version);

            // TODO: Determine if this collection is required and should be non-empty.
            json.WriteStartArray(s_authoritiesPropertyNameBytes);

            foreach (KeyReleaseAuthority authority in Authorities)
            {
                json.WriteStartObject();

                authority.WriteProperties(json);

                json.WriteEndObject();
            }

            json.WriteEndArray();
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
