// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Service Principal datastore credentials configuration. </summary>
    public partial class MachineLearningServicePrincipalDatastoreCredentials : ServicePrincipalDatastoreCredentials, IJsonModel<MachineLearningServicePrincipalDatastoreCredentials>
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningServicePrincipalDatastoreCredentials"/>. </summary>
        public MachineLearningServicePrincipalDatastoreCredentials(Guid clientId, MachineLearningServicePrincipalDatastoreSecrets secrets, Guid tenantId) : base(clientId, secrets, tenantId)
        {
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningServicePrincipalDatastoreCredentials"/>. </summary>
        public MachineLearningServicePrincipalDatastoreCredentials(Guid clientId, Guid tenantId, MachineLearningServicePrincipalDatastoreSecrets secrets) : this(clientId, secrets, tenantId)
        {
        }

        void IJsonModel<MachineLearningServicePrincipalDatastoreCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ServicePrincipalDatastoreCredentials>)this).Write(writer, options);
        }

        MachineLearningServicePrincipalDatastoreCredentials IJsonModel<MachineLearningServicePrincipalDatastoreCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningServicePrincipalDatastoreCredentials(document.RootElement, options);
        }

        BinaryData IPersistableModel<MachineLearningServicePrincipalDatastoreCredentials>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<ServicePrincipalDatastoreCredentials>)this).Write(options);
        }

        MachineLearningServicePrincipalDatastoreCredentials IPersistableModel<MachineLearningServicePrincipalDatastoreCredentials>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningServicePrincipalDatastoreCredentials>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeMachineLearningServicePrincipalDatastoreCredentials(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningServicePrincipalDatastoreCredentials)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningServicePrincipalDatastoreCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static MachineLearningServicePrincipalDatastoreCredentials DeserializeMachineLearningServicePrincipalDatastoreCredentials(JsonElement element, ModelReaderWriterOptions options)
        {
            ServicePrincipalDatastoreCredentials credentials = ServicePrincipalDatastoreCredentials.DeserializeServicePrincipalDatastoreCredentials(element, options);
            if (credentials is null)
            {
                return null;
            }

            var secrets = new MachineLearningServicePrincipalDatastoreSecrets
            {
                ClientSecret = credentials.Secrets?.ClientSecret
            };
            return new MachineLearningServicePrincipalDatastoreCredentials(credentials.ClientId, credentials.TenantId, secrets)
            {
                AuthorityUri = credentials.AuthorityUri,
                ResourceUri = credentials.ResourceUri
            };
        }
    }
}
