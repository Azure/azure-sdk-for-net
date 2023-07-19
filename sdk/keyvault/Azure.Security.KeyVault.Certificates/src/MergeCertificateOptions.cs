// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Options for certificates to be merged into Azure Key Vault.
    /// </summary>
    public class MergeCertificateOptions : IJsonSerializable
    {
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode("attributes");
        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode("enabled");
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode("tags");
        private static readonly JsonEncodedText s_x5cPropertyNameBytes = JsonEncodedText.Encode("x5c");

        private Dictionary<string, string> _tags;

        /// <summary>
        /// Initializes a new instance of the <see cref="MergeCertificateOptions"/> class.
        /// </summary>
        /// <param name="name">The name of the certificate.</param>
        /// <param name="x509Certificates">The certificate or certificate chain to merge.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="x509Certificates"/> is null.</exception>
        public MergeCertificateOptions(string name, IEnumerable<byte[]> x509Certificates)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(x509Certificates, nameof(x509Certificates));

            Name = name;
            X509Certificates = x509Certificates;
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
        /// Gets or sets a value indicating whether the merged certificate should be enabled. If null, the server default will be used.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets the tags to be applied to the merged certificate. Although this collection cannot be set, it can be modified
        ///  or initialized with a <see href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer">collection initializer</see>.
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

            if (!_tags.IsNullOrEmpty())
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
                    json.WriteBase64StringValue(x509certificate);
                }

                json.WriteEndArray();
            }
        }
    }
}
