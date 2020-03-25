// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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
        private static readonly JsonEncodedText PolicyPropertyNameBytes = JsonEncodedText.Encode(PolicyPropertyName);
        private static readonly JsonEncodedText AttributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText EnabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);
        private static readonly JsonEncodedText TagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);

        public CertificateCreateParameters(CertificatePolicy policy, bool? enabled, IDictionary<string, string> tags)
        {
            Policy = policy;
            Enabled = enabled;
            Tags = tags;
        }

        public CertificatePolicy Policy { get; set; }

        public bool? Enabled { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Policy != null)
            {
                json.WriteStartObject(PolicyPropertyNameBytes);

                ((IJsonSerializable)Policy).WriteProperties(json);

                json.WriteEndObject();
            }

            if(Enabled.HasValue)
            {
                json.WriteStartObject(AttributesPropertyNameBytes);

                json.WriteBoolean(EnabledPropertyNameBytes, Enabled.Value);

                json.WriteEndObject();
            }

            if(Tags != null)
            {
                json.WriteStartObject(TagsPropertyNameBytes);

                foreach(var kvp in Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }
        }
    }
}
