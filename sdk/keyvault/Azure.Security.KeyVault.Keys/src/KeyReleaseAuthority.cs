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
    /// An attestation authority that defines conditions which must all be true to export a key.
    /// </summary>
    public class KeyReleaseAuthority : IJsonDeserializable, IJsonSerializable
    {
        private const string UriPropertyName = "authority";
        private const string ConditionsPropertyName = "allOf";

        private static readonly JsonEncodedText s_uriPropertyNameBytes = JsonEncodedText.Encode(UriPropertyName);
        private static readonly JsonEncodedText s_conditionsPropertyNameBytes = JsonEncodedText.Encode(ConditionsPropertyName);

        /// <summary>
        /// Creates a new instance of the <see cref="KeyReleaseAuthority"/> class.
        /// </summary>
        /// <param name="uri">Base <see cref="Uri"/> of the attestation service.</param>
        /// <param name="conditions">The set of claim conditions that must all be true to export a key.</param>
        /// <exception cref="ArgumentNullException"><paramref name="uri"/> or <paramref name="conditions"/> is null.</exception>
        public KeyReleaseAuthority(Uri uri, IEnumerable<KeyReleaseCondition> conditions)
        {
            Argument.AssertNotNull(uri, nameof(uri));
            Argument.AssertNotNull(conditions, nameof(conditions));

            Uri = uri;
            Conditions = conditions.ToList();
        }

        internal KeyReleaseAuthority()
        {
            Conditions = new List<KeyReleaseCondition>();
        }

        /// <summary>
        /// Gets the base <see cref="Uri"/> of the attestation service.
        /// </summary>
        public Uri Uri { get; internal set; }

        /// <summary>
        /// Gets the set of claim conditions that must all be true to export a key.
        /// </summary>
        public IList<KeyReleaseCondition> Conditions { get; }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case UriPropertyName:
                        Uri = new Uri(prop.Value.GetString());
                        break;
                    case ConditionsPropertyName:
                        foreach (JsonElement element in prop.Value.EnumerateArray())
                        {
                            KeyReleaseCondition condition = new KeyReleaseCondition();
                            condition.ReadProperties(element);

                            Conditions.Add(condition);
                        }
                        break;
                }
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(s_uriPropertyNameBytes, Uri.ToString());

            // TODO: Determine if this collection is required and should be non-empty.
            json.WriteStartArray(s_conditionsPropertyNameBytes);

            foreach (KeyReleaseCondition condition in Conditions)
            {
                json.WriteStartObject();

                condition.WriteProperties(json);

                json.WriteEndObject();
            }

            json.WriteEndArray();
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
