// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    internal class CertificateUpdateParameters : IJsonSerializable
    {
        private const string AttributesPropertyName = "attributes";
        private const string EnabledPropertyName = "enabled";
        private const string TagsPropertyName = "tags";

        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);

        public CertificateUpdateParameters(CertificateProperties properties)
        {
            Properties = properties;
        }

        public CertificateProperties Properties { get; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Properties.Enabled.HasValue)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                json.WriteBoolean(s_enabledPropertyNameBytes, Properties.Enabled.Value);

                json.WriteEndObject();
            }

            if (Properties.HasTags && Properties.Tags.Count > 0)
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in Properties.Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }
        }
    }
}
