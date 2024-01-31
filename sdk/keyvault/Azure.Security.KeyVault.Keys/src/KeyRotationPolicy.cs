// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Management policy for a key in Key Vault.
    /// </summary>
    public class KeyRotationPolicy : IJsonSerializable, IJsonDeserializable
    {
        private const string IdPropertyName = "id";
        private const string LifetimeActionsPropertyName = "lifetimeActions";
        private const string AttributesPropertyName = "attributes";
        private const string ExpiryTimePropertyName = "expiryTime";
        private const string CreatedPropertyName = "created";
        private const string UpdatedPropertyName = "updated";

        private static readonly JsonEncodedText s_lifetimeActionsPropertyNameBytes = JsonEncodedText.Encode(LifetimeActionsPropertyName);
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText s_expiryTimePropertyNameBytes = JsonEncodedText.Encode(ExpiryTimePropertyName);

        /// <summary>
        /// Gets the identifier of the <see cref="KeyRotationPolicy"/>.
        /// </summary>
        public Uri Id { get; internal set; }

        /// <summary>
        /// Gets the actions that will be performed by Key Vault over the lifetime of a key.
        /// </summary>
        public IList<KeyRotationLifetimeAction> LifetimeActions { get; } = new List<KeyRotationLifetimeAction>();

        /// <summary>
        /// Gets or sets the ISO 8601 duration when a new <see cref="KeyVaultKey"/> version created from this policy will expire. It should be at least 28 days.
        /// </summary>
        /// <remarks>
        /// ISO 8601 duration examples:
        /// <list type="bullet">
        /// <item>
        /// <term>P90D</term>
        /// <description>90 days</description>
        /// </item>
        /// <item>
        /// <term>P3M</term>
        /// <description>3 months</description>
        /// </item>
        /// <item>
        /// <term>P1Y10D</term>
        /// <description>1 year and 10 days</description>
        /// </item>
        /// </list>
        /// </remarks>
        public string ExpiresIn { get; set; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the <see cref="KeyRotationPolicy"/> was created.
        /// </summary>
        public DateTimeOffset? CreatedOn { get; internal set; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the <see cref="KeyRotationPolicy"/> was last updated.
        /// </summary>
        public DateTimeOffset? UpdatedOn { get; internal set; }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case IdPropertyName:
                        Id = new Uri(prop.Value.GetString(), UriKind.Absolute);
                        break;

                    case LifetimeActionsPropertyName when prop.Value.ValueKind != JsonValueKind.Null:
                        foreach (JsonElement elem in prop.Value.EnumerateArray())
                        {
                            KeyRotationLifetimeAction action = new();
                            action.ReadProperties(elem);

                            LifetimeActions.Add(action);
                        }
                        break;

                    case AttributesPropertyName when prop.Value.ValueKind != JsonValueKind.Null:
                        ReadAttributeProperties(prop.Value);
                        break;
                }
            }
        }

        internal void ReadAttributeProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case ExpiryTimePropertyName:
                        ExpiresIn =prop.Value.GetString();
                        break;

                    case CreatedPropertyName:
                        CreatedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;

                    case UpdatedPropertyName:
                        UpdatedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                }
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            json.WriteStartArray(s_lifetimeActionsPropertyNameBytes);
            foreach (KeyRotationLifetimeAction action in LifetimeActions)
            {
                json.WriteStartObject();
                action.WriteProperties(json);
                json.WriteEndObject();
            }
            json.WriteEndArray();

            WriteAttributeProperties(json);
        }

        internal void WriteAttributeProperties(Utf8JsonWriter json)
        {
            if (ExpiresIn != null)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);
                json.WriteString(s_expiryTimePropertyNameBytes, ExpiresIn);
                json.WriteEndObject();
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
