// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Certificate datastore credentials configuration. </summary>
    public partial class MachineLearningCertificateDatastoreCredentials : CertificateDatastoreCredentials, IJsonModel<MachineLearningCertificateDatastoreCredentials>
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningCertificateDatastoreCredentials"/>. </summary>
        public MachineLearningCertificateDatastoreCredentials(Guid clientId, MachineLearningCertificateDatastoreSecrets secrets, Guid tenantId, string thumbprint) : base(clientId, secrets, tenantId, thumbprint)
        {
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningCertificateDatastoreCredentials"/>. </summary>
        public MachineLearningCertificateDatastoreCredentials(Guid clientId, Guid tenantId, string thumbprint, MachineLearningCertificateDatastoreSecrets secrets) : this(clientId, secrets, tenantId, thumbprint)
        {
        }

        void IJsonModel<MachineLearningCertificateDatastoreCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<CertificateDatastoreCredentials>)this).Write(writer, options);
        }

        MachineLearningCertificateDatastoreCredentials IJsonModel<MachineLearningCertificateDatastoreCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningCertificateDatastoreCredentials(document.RootElement, options);
        }

        BinaryData IPersistableModel<MachineLearningCertificateDatastoreCredentials>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<CertificateDatastoreCredentials>)this).Write(options);
        }

        MachineLearningCertificateDatastoreCredentials IPersistableModel<MachineLearningCertificateDatastoreCredentials>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningCertificateDatastoreCredentials>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeMachineLearningCertificateDatastoreCredentials(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningCertificateDatastoreCredentials)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningCertificateDatastoreCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static MachineLearningCertificateDatastoreCredentials DeserializeMachineLearningCertificateDatastoreCredentials(JsonElement element, ModelReaderWriterOptions options)
        {
            CertificateDatastoreCredentials credentials = CertificateDatastoreCredentials.DeserializeCertificateDatastoreCredentials(element, options);
            if (credentials is null)
            {
                return null;
            }

            var secrets = new MachineLearningCertificateDatastoreSecrets
            {
                Certificate = credentials.Secrets?.Certificate
            };
            return new MachineLearningCertificateDatastoreCredentials(credentials.ClientId, credentials.TenantId, credentials.Thumbprint, secrets)
            {
                AuthorityUri = credentials.AuthorityUri,
                ResourceUri = credentials.ResourceUri
            };
        }
    }
}
