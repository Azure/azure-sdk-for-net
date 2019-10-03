// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Options for certificates to be merged into Azure Key Vault.
    /// </summary>
    public class CertificateMergeOptions : IJsonSerializable
    {
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode("attributes");
        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode("enabled");
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode("tags");
        private static readonly JsonEncodedText s_x5cPropertyNameBytes = JsonEncodedText.Encode("x5c");

        private Dictionary<string, string> _tags;

        /// <summary>
        /// Creates an instance of the <see cref="CertificateMergeOptions"/> class.
        /// </summary>
        /// <param name="name">The name of the certificate.</param>
        /// <param name="x509certificates">The certificate or certificate chain to merge.</param>
        public CertificateMergeOptions(string name, IEnumerable<byte[]> x509certificates)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(x509certificates, nameof(x509certificates));

            Name = name;
            X509Certificates = x509certificates;
        }

        /// <summary>
        /// Gets the name of the certificate.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the certificate or certificate chain to merge.
        /// </summary>
        public IEnumerable<byte[]> X509Certificates { get; }

        /// <summary>
        /// Gets or sets whether the merged certificate should be enabled.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Tags to be applied to the merged certificate.
        /// </summary>
        public IDictionary<string, string> Tags => LazyInitializer.EnsureInitialized(ref _tags);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Enabled.HasValue)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                json.WriteBoolean(s_enabledPropertyNameBytes, Enabled.Value);

                json.WriteEndObject();
            }

            if (_tags != null && _tags.Count > 0)
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in _tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }

            if (X509Certificates != null)
            {
                json.WriteStartArray(s_x5cPropertyNameBytes);

                foreach (byte[] x509certificate in X509Certificates)
                {
                    string encoded = Base64Url.Encode(x509certificate);
                    json.WriteStringValue(encoded);
                }

                json.WriteEndArray();
            }
        }
    }
}
