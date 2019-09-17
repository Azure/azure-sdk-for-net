﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// An action to be executed at a perscribed time in a certificates lifecycle
    /// </summary>
    public class LifetimeAction : IJsonSerializable, IJsonDeserializable
    {
        private const string TriggerPropertyName = "trigger";
        private static readonly JsonEncodedText TriggerPropertyNameBytes = JsonEncodedText.Encode(TriggerPropertyName);
        private const string ActionPropertyName = "action";
        private static readonly JsonEncodedText ActionPropertyNameBytes = JsonEncodedText.Encode(ActionPropertyName);
        private const string LifetimePercentagePropertyName = "lifetime_percentage";
        private static readonly JsonEncodedText LifetimePercentagePropertyNameBytes = JsonEncodedText.Encode(LifetimePercentagePropertyName);
        private const string DaysBeforeExpiryPropertyName = "days_before_expiry";
        private static readonly JsonEncodedText DaysBeforeExpiryPropertyNameBytes = JsonEncodedText.Encode(DaysBeforeExpiryPropertyName);
        private const string ActionTypePropertyName = "action_type";
        private static readonly JsonEncodedText ActionTypePropertyNameBytes = JsonEncodedText.Encode(ActionTypePropertyName);

        /// <summary>
        /// Specifies the action should be performed the specified number of days before the certificate will expire
        /// </summary>
        public int? DaysBeforeExpiry { get; set; }

        /// <summary>
        /// Specifies the action should be performed when the certificate reaches the specified percentage of its lifetime. Valid values include 1-99
        /// </summary>
        public int? LifetimePercentage { get; set; }

        /// <summary>
        /// The action to be performed
        /// </summary>
        public Action Action { get; set; }

        internal static LifetimeAction FromJsonObject(JsonElement json)
        {
            var action = new LifetimeAction();

            ((IJsonDeserializable)action).ReadProperties(json);

            return action;
        }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case TriggerPropertyName:
                        foreach (JsonProperty triggerProp in prop.Value.EnumerateObject())
                        {
                            switch(triggerProp.Name)
                            {
                                case LifetimePercentagePropertyName:
                                    LifetimePercentage = triggerProp.Value.GetInt32();
                                    break;
                                case DaysBeforeExpiryPropertyName:
                                    DaysBeforeExpiry = triggerProp.Value.GetInt32();
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

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            // trigger
            json.WriteStartObject(TriggerPropertyNameBytes);

            if (DaysBeforeExpiry.HasValue)
            {
                json.WriteNumber(DaysBeforeExpiryPropertyNameBytes, DaysBeforeExpiry.Value);
            }

            if (LifetimePercentage.HasValue)
            {
                json.WriteNumber(LifetimePercentagePropertyNameBytes, DaysBeforeExpiry.Value);
            }

            json.WriteEndObject();

            // action
            json.WriteStartObject(ActionPropertyNameBytes);

            json.WriteString(ActionTypePropertyNameBytes, Action);

            json.WriteEndObject();

        }
    }
}
