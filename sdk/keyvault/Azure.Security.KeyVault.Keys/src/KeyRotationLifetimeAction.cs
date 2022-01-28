// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Xml;

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
        /// Gets or sets he <see cref="KeyRotationPolicyAction"/> that will be executed.
        /// </summary>
        public KeyRotationPolicyAction Action { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TimeSpan"/> after creation to attempt to rotate. It only applies to <see cref="KeyRotationPolicyAction.Rotate"/>.
        /// </summary>
        public TimeSpan? TimeAfterCreate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TimeSpan"/> before expiry to attempt to <see cref="KeyRotationPolicyAction.Rotate"/> or <see cref="KeyRotationPolicyAction.Notify"/>.
        /// </summary>
        public TimeSpan? TimeBeforeExpiry { get; set; }

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
                                    TimeAfterCreate = XmlConvert.ToTimeSpan(triggerProp.Value.GetString());
                                    break;

                                case TimeBeforeExpiryPropertyName:
                                    TimeBeforeExpiry = XmlConvert.ToTimeSpan(triggerProp.Value.GetString());
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
            if (TimeAfterCreate.HasValue || TimeBeforeExpiry.HasValue)
            {
                json.WriteStartObject(s_triggerPropertyNameBytes);

                if (TimeAfterCreate.HasValue)
                {
                    json.WriteString(s_timeAfterCreatePropertyNameBytes, XmlConvert.ToString(TimeAfterCreate.Value));
                }

                if (TimeBeforeExpiry.HasValue)
                {
                    json.WriteString(s_timeBeforeExpiryPropertyNameBytes, XmlConvert.ToString(TimeBeforeExpiry.Value));
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
