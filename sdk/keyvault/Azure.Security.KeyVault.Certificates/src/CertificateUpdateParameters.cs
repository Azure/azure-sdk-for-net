// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    internal class CertificateUpdateParameters : IJsonSerializable
    {
        public CertificateUpdateParameters(bool? enabled, IDictionary<string, string> tags)
        {
            Enabled = enabled;
            Tags = tags;
        }

        public bool? Enabled { get; private set; }

        public IDictionary<string, string> Tags { get; private set; }

        private const string AttributesPropertyName = "attributes";
        private static readonly JsonEncodedText AttributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private const string EnabledPropertyName = "enabled";
        private static readonly JsonEncodedText EnabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);
        private const string TagsPropertyName = "tags";
        private static readonly JsonEncodedText TagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if(Enabled.HasValue)
            {
                json.WriteStartObject(AttributesPropertyNameBytes);

                json.WriteBoolean(EnabledPropertyNameBytes, Enabled.Value);

                json.WriteEndObject();
            }

            if(Tags != null)
            {
                json.WriteStartObject(TagsPropertyNameBytes);

                foreach (var kvp in Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }
        }
    }
}
