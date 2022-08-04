// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// An action and its trigger that will be performed by Key Vault over the lifetime of a key.
    /// </summary>
    public class KeyRotationLifetimeAction : IJsonSerializable, IJsonDeserializable
    {
        private const string ActionPropertyName = "action";
        private const string ActionTypePropertyName = "type";
        private const string TriggerPropertyName = "trigger";
        private const string TimeAfterCreatePropertyName = "timeAfterCreate";
        private const string TimeBeforeExpiryPropertyName = "timeBeforeExpiry";

        private static readonly JsonEncodedText s_actionPropertyNameBytes = JsonEncodedText.Encode(ActionPropertyName);
        private static readonly JsonEncodedText s_actionTypePropertyNameBytes = JsonEncodedText.Encode(ActionTypePropertyName);
        private static readonly JsonEncodedText s_triggerPropertyNameBytes = JsonEncodedText.Encode(TriggerPropertyName);
        private static readonly JsonEncodedText s_timeAfterCreatePropertyNameBytes = JsonEncodedText.Encode(TimeAfterCreatePropertyName);
        private static readonly JsonEncodedText s_timeBeforeExpiryPropertyNameBytes = JsonEncodedText.Encode(TimeBeforeExpiryPropertyName);

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyRotationLifetimeAction"/> structure.
        /// </summary>
        /// <param name="action">The <see cref="KeyRotationPolicyAction"/> that will be executed.</param>
        public KeyRotationLifetimeAction(KeyRotationPolicyAction action)
        {
            Action = action;
        }

        internal KeyRotationLifetimeAction()
        {
        }

        /// <summary>
        /// Gets the <see cref="KeyRotationPolicyAction"/> that will be executed.
        /// </summary>
        public KeyRotationPolicyAction Action { get; private set; }

        /// <summary>
        /// Gets or sets the ISO 8601 duration after creation to attempt to rotate. It only applies to <see cref="KeyRotationPolicyAction.Rotate"/>.
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
        public string TimeAfterCreate { get; set; }

        /// <summary>
        /// Gets or sets the ISO 8601 duration before expiry to attempt to <see cref="KeyRotationPolicyAction.Rotate"/> or <see cref="KeyRotationPolicyAction.Notify"/>.
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
        public string TimeBeforeExpiry { get; set; }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case TriggerPropertyName:
                        foreach (JsonProperty triggerProp in prop.Value.EnumerateObject())
                        {
                            switch (triggerProp.Name)
                            {
                                case TimeAfterCreatePropertyName:
                                    TimeAfterCreate = triggerProp.Value.GetString();
                                    break;

                                case TimeBeforeExpiryPropertyName:
                                    TimeBeforeExpiry = triggerProp.Value.GetString();
                                    break;
                            }
                        }
                        break;

                    case ActionPropertyName:
                        Action = prop.Value.GetProperty(ActionTypePropertyName).GetString();
                        break;
                }
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (TimeAfterCreate != null || TimeBeforeExpiry != null)
            {
                json.WriteStartObject(s_triggerPropertyNameBytes);

                if (TimeAfterCreate != null)
                {
                    json.WriteString(s_timeAfterCreatePropertyNameBytes, TimeAfterCreate);
                }

                if (TimeBeforeExpiry != null)
                {
                    json.WriteString(s_timeBeforeExpiryPropertyNameBytes, TimeBeforeExpiry);
                }

                json.WriteEndObject();
            }

            json.WriteStartObject(s_actionPropertyNameBytes);
            json.WriteString(s_actionTypePropertyNameBytes, Action.ToString());
            json.WriteEndObject();
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
