// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    internal class CertificateCreateParameters : IJsonSerializable
    {
        private const string PolicyPropertyName = "policy";
        private const string AttributesPropertyName = "attributes";
        private const string EnabledPropertyName = "enabled";
        private const string TagsPropertyName = "tags";
        private const string PreserveCertificateOrderPropertyName = "preserveCertOrder";

        private static readonly JsonEncodedText s_policyPropertyNameBytes = JsonEncodedText.Encode(PolicyPropertyName);
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);
        private static readonly JsonEncodedText s_preserveCertificateOrderPropertyNameBytes = JsonEncodedText.Encode(PreserveCertificateOrderPropertyName);

        public CertificateCreateParameters(CertificatePolicy policy, bool? enabled, IDictionary<string, string> tags, bool? preserveCertificateOrder = null)
        {
            Policy = policy;
            Enabled = enabled;
            Tags = tags;
            PreserveCertificateOrder = preserveCertificateOrder;
        }

        public CertificatePolicy Policy { get; }

        public bool? Enabled { get; }

        public IDictionary<string, string> Tags { get; }

        public bool? PreserveCertificateOrder { get; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Policy != null)
            {
                json.WriteStartObject(s_policyPropertyNameBytes);

                ((IJsonSerializable)Policy).WriteProperties(json);

                json.WriteEndObject();
            }

            if (Enabled.HasValue)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                json.WriteBoolean(s_enabledPropertyNameBytes, Enabled.Value);

                json.WriteEndObject();
            }

            if (!Tags.IsNullOrEmpty())
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }

            if (PreserveCertificateOrder.HasValue)
            {
                json.WriteBoolean(s_preserveCertificateOrderPropertyNameBytes, PreserveCertificateOrder.Value);
            }
        }
    }
}
