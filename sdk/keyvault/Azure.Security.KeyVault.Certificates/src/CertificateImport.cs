// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A certificate to be imported into Azure Key Vault
    /// </summary>
    public class CertificateImport : IJsonSerializable
    {
        private static readonly JsonEncodedText s_valuePropertyNameBytes = JsonEncodedText.Encode("value");
        private static readonly JsonEncodedText s_policyPropertyNameBytes = JsonEncodedText.Encode("policy");
        private static readonly JsonEncodedText s_passwordPropertyNameBytes = JsonEncodedText.Encode("pwd");
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode("attributes");
        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode("enabled");
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode("tags");

        /// <summary>
        /// Creates a certificate import used to import a certificate into Azure Key Vault
        /// </summary>
        /// <param name="name">A name for the imported certificate</param>
        /// <param name="value">The PFX or PEM formatted value of the certificate containing both the x509 certificates and the private key</param>
        /// <param name="policy">The policy which governs the lifecycle of the imported certificate and it's properties when it is rotated</param>
        public CertificateImport(string name, byte[] value, CertificatePolicy policy)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(value, nameof(value));
            Argument.AssertNotNull(policy, nameof(policy));

            Name = name;
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Policy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        /// <summary>
        /// The name of the certificate to import
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The PFX or PEM formatted value of the certificate containing both the x509 certificates and the private key
        /// </summary>
        public byte[] Value { get; set; }

        /// <summary>
        /// The policy which governs the lifecycle of the imported certificate and it's properties when it is rotated
        /// </summary>
        public CertificatePolicy Policy { get; set; }

        /// <summary>
        /// The password protecting the certificate specified in the Value
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Sepcifies whether the imported certificate should be initially enabled
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Tags to be applied to the imported certifiate
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Value != null)
            {
                json.WriteBase64String(s_valuePropertyNameBytes, Value);
            }

            if (!string.IsNullOrEmpty(Password))
            {
                json.WriteString(s_passwordPropertyNameBytes, Password);
            }

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

            if (Tags != null)
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }
        }
    }
}
