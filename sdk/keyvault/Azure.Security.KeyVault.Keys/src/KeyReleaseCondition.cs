// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// A claim condition that must be true to export a key.
    /// </summary>
    public class KeyReleaseCondition : IJsonDeserializable, IJsonSerializable
    {
        // TODO: Make this an abstract base class that can have an anyOf, allOf, or specific claim.

        private const string ClaimTypePropertyName = "claim";
        private const string ClaimConditionPropertyName = "condition";
        private const string ValuePropertyName = "value";

        private static readonly JsonEncodedText s_claimTypePropertyNameBytes = JsonEncodedText.Encode(ClaimTypePropertyName);
        private static readonly JsonEncodedText s_claimConditionPropertyNameBytes = JsonEncodedText.Encode(ClaimConditionPropertyName);
        private static readonly JsonEncodedText s_valuePropertyNameBytes = JsonEncodedText.Encode(ValuePropertyName);

        /// <summary>
        /// Creates an instance of the <see cref="KeyReleaseCondition"/> class.
        /// </summary>
        /// <param name="claimType">The claim type of the condition.</param>
        /// <param name="value">The value of the condition. This must be equal to the value of the specified <paramref name="claimType"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="claimType"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="claimType"/> is null.</exception>
        public KeyReleaseCondition(string claimType, string value)
        {
            Argument.AssertNotNullOrEmpty(claimType, nameof(claimType));

            ClaimType = claimType;
            Value = value;
        }

        internal KeyReleaseCondition()
        {
        }

        /// <summary>
        /// Gets the claim type of the condition.
        /// </summary>
        public string ClaimType { get; internal set; }

        /// <summary>
        /// Gets the claim condition.
        /// </summary>
        public string ClaimCondition { get; internal set; } = "equals";

        /// <summary>
        /// Gets or sets the value of the condition.
        /// </summary>
        public string Value { get; set; }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case ClaimTypePropertyName:
                        ClaimType = prop.Value.GetString();
                        break;
                    case ClaimConditionPropertyName:
                        ClaimCondition = prop.Value.GetString();
                        break;
                    case ValuePropertyName:
                        Value = prop.Value.GetString();
                        break;
                }
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(s_claimTypePropertyNameBytes, ClaimType);
            json.WriteString(s_claimConditionPropertyNameBytes, ClaimCondition);

            if (Value != null)
            {
                json.WriteString(s_valuePropertyNameBytes, Value);
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
