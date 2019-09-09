// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificateImport : IJsonSerializable
    {
        public CertificateImport(string name, byte[] value, CertificatePolicy policy, string password = default, bool? enabled = default, IDictionary<string, string> tags = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty");
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (policy == null) throw new ArgumentNullException(nameof(policy));

            Name = name;
            Value = value;
            Policy = policy;
            Password = password;
            Enabled = enabled;
            Tags = tags;
        }

        public string Name { get; private set; }

        public byte[] Value { get; set; }

        public CertificatePolicy Policy { get; set; }

        public string Password { get; set; }

        public bool? Enabled { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        private static readonly JsonEncodedText ValuePropertyNameBytes = JsonEncodedText.Encode("value");
        private static readonly JsonEncodedText PolicyPropertyNameBytes = JsonEncodedText.Encode("policy");
        private static readonly JsonEncodedText PasswordPropertyNameBytes = JsonEncodedText.Encode("pwd");
        private static readonly JsonEncodedText AttributesPropertyNameBytes = JsonEncodedText.Encode("attributes");
        private static readonly JsonEncodedText EnabledPropertyNameBytes = JsonEncodedText.Encode("enabled");
        private static readonly JsonEncodedText TagsPropertyNameBytes = JsonEncodedText.Encode("tags");

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if(Value != null)
            {
                json.WriteBase64String(ValuePropertyNameBytes, Value);
            }

            if (!string.IsNullOrEmpty(Password))
            {
                json.WriteString(PasswordPropertyNameBytes, Password);
            }

            if (Policy != null)
            {
                json.WriteStartObject(PolicyPropertyNameBytes);

                ((IJsonSerializable)Policy).WriteProperties(json);

                json.WriteEndObject();
            }

            if (Enabled.HasValue)
            {
                json.WriteStartObject(AttributesPropertyNameBytes);

                json.WriteBoolean(EnabledPropertyNameBytes, Enabled.Value);

                json.WriteEndObject();
            }

            if (Tags != null)
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
