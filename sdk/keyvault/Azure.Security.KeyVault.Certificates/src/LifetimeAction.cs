// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// An action to be executed at a prescribed time in a certificates lifecycle
    /// </summary>
    public class LifetimeAction : IJsonSerializable, IJsonDeserializable
    {
        private const string TriggerPropertyName = "trigger";
        private const string ActionPropertyName = "action";
        private const string LifetimePercentagePropertyName = "lifetime_percentage";
        private const string DaysBeforeExpiryPropertyName = "days_before_expiry";
        private const string ActionTypePropertyName = "action_type";

        private static readonly JsonEncodedText s_triggerPropertyNameBytes = JsonEncodedText.Encode(TriggerPropertyName);
        private static readonly JsonEncodedText s_actionPropertyNameBytes = JsonEncodedText.Encode(ActionPropertyName);
        private static readonly JsonEncodedText s_lifetimePercentagePropertyNameBytes = JsonEncodedText.Encode(LifetimePercentagePropertyName);
        private static readonly JsonEncodedText s_daysBeforeExpiryPropertyNameBytes = JsonEncodedText.Encode(DaysBeforeExpiryPropertyName);
        private static readonly JsonEncodedText s_actionTypePropertyNameBytes = JsonEncodedText.Encode(ActionTypePropertyName);

        /// <summary>
        /// Initializes a new instance of the <see cref="LifetimeAction"/> class.
        /// </summary>
        /// <param name="action">The <see cref="CertificatePolicyAction"/> to be performed.</param>
        public LifetimeAction(CertificatePolicyAction action)
        {
            Action = action;
        }

        private LifetimeAction()
        {
        }

        /// <summary>
        /// Gets or sets the action should be performed the specified number of days before the certificate will expire.
        /// </summary>
        public int? DaysBeforeExpiry { get; set; }

        /// <summary>
        /// Gets or sets the action should be performed when the certificate reaches the specified percentage of its lifetime. Valid values include 1-99.
        /// </summary>
        public int? LifetimePercentage { get; set; }

        /// <summary>
        /// Gets the <see cref="CertificatePolicyAction"/> to be performed.
        /// </summary>
        public CertificatePolicyAction Action { get; private set; }

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
                            switch (triggerProp.Name)
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
            json.WriteStartObject(s_triggerPropertyNameBytes);

            if (DaysBeforeExpiry.HasValue)
            {
                json.WriteNumber(s_daysBeforeExpiryPropertyNameBytes, DaysBeforeExpiry.Value);
            }

            if (LifetimePercentage.HasValue)
            {
                json.WriteNumber(s_lifetimePercentagePropertyNameBytes, LifetimePercentage.Value);
            }

            json.WriteEndObject();

            // action
            json.WriteStartObject(s_actionPropertyNameBytes);

            json.WriteString(s_actionTypePropertyNameBytes, Action.ToString());

            json.WriteEndObject();
        }
    }
}
