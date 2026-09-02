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
    /// Properties of the platform managed certificate. This feature is currently intended for internal use only.
    /// </summary>
    /// <remarks>
    /// Experimental, Azure Key Vault internal usage only. Any calls using this type will fail and it is not
    /// recommended to be used at this point.
    /// </remarks>
    public partial class PlatformManaged
    {
        private const string CertificateUsagePropertyName = "certificateUsage";
        private const string MetadataPropertyName = "metadata";

        private static readonly JsonEncodedText s_certificateUsagePropertyNameBytes = JsonEncodedText.Encode(CertificateUsagePropertyName);
        private static readonly JsonEncodedText s_metadataPropertyNameBytes = JsonEncodedText.Encode(MetadataPropertyName);

        private Dictionary<string, BinaryData> _metadata;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformManaged"/> class.
        /// </summary>
        /// <param name="certificateUsage">The intended usage of the certificate.</param>
        /// <exception cref="ArgumentException"><paramref name="certificateUsage"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateUsage"/> is null.</exception>
        public PlatformManaged(string certificateUsage)
        {
            Argument.AssertNotNullOrEmpty(certificateUsage, nameof(certificateUsage));

            CertificateUsage = certificateUsage;
        }

        internal PlatformManaged()
        {
        }

        /// <summary>
        /// Gets or sets the intended usage of the certificate.
        /// </summary>
        public string CertificateUsage { get; set; }

        /// <summary>
        /// Gets JSON-formatted platform managed metadata. The schema is intentionally undefined as this feature is currently intended for internal use only.
        /// </summary>
        public IDictionary<string, BinaryData> Metadata
        {
            get => LazyInitializer.EnsureInitialized(ref _metadata);
            internal set
            {
                if (value is null)
                {
                    return;
                }
                Dictionary<string, BinaryData> store = LazyInitializer.EnsureInitialized(ref _metadata);
                store.Clear();
                foreach (KeyValuePair<string, BinaryData> entry in value)
                {
                    store[entry.Key] = entry.Value;
                }
            }
        }

        internal static PlatformManaged FromJsonObject(JsonElement json)
        {
            PlatformManaged platformManaged = new PlatformManaged();
            platformManaged.ReadProperties(json);
            return platformManaged;
        }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case CertificateUsagePropertyName:
                        CertificateUsage = prop.Value.GetString();
                        break;

                    case MetadataPropertyName:
                        if (prop.Value.ValueKind != JsonValueKind.Null)
                        {
                            foreach (JsonProperty metadata in prop.Value.EnumerateObject())
                            {
                                Metadata[metadata.Name] = BinaryData.FromString(metadata.Value.GetRawText());
                            }
                        }
                        break;
                }
            }

            if (CertificateUsage is null)
            {
                throw new InvalidOperationException(
                    $"Required property '{CertificateUsagePropertyName}' was not present in the platform-managed certificate JSON.");
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (CertificateUsage is null)
            {
                throw new InvalidOperationException(
                    $"{nameof(CertificateUsage)} must be set before serializing a {nameof(PlatformManaged)} policy.");
            }

            json.WriteString(s_certificateUsagePropertyNameBytes, CertificateUsage);

            if (!_metadata.IsNullOrEmpty())
            {
                json.WriteStartObject(s_metadataPropertyNameBytes);

                foreach (KeyValuePair<string, BinaryData> metadata in Metadata)
                {
                    json.WritePropertyName(metadata.Key);

                    if (metadata.Value == null)
                    {
                        json.WriteNullValue();
                    }
                    else
                    {
                        using JsonDocument document = JsonDocument.Parse(metadata.Value.ToMemory());
                        document.RootElement.WriteTo(json);
                    }
                }

                json.WriteEndObject();
            }
        }
    }
}
