// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: the generated RegistryPrivateEndpoint model was removed when PrivateEndpointBase
    // was renamed, so this compatibility wrapper needs its own model serialization implementation.
    public partial class RegistryPrivateEndpoint : IJsonModel<RegistryPrivateEndpoint>, IPersistableModel<RegistryPrivateEndpoint>
    {
        BinaryData IPersistableModel<RegistryPrivateEndpoint>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RegistryPrivateEndpoint>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, Azure.ResourceManager.MachineLearning.AzureResourceManagerMachineLearningContext.Default);
                default:
                    throw new FormatException($"The model {nameof(RegistryPrivateEndpoint)} does not support writing '{options.Format}' format.");
            }
        }

        RegistryPrivateEndpoint IPersistableModel<RegistryPrivateEndpoint>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RegistryPrivateEndpoint>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeRegistryPrivateEndpoint(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RegistryPrivateEndpoint)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RegistryPrivateEndpoint>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<RegistryPrivateEndpoint>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<MachineLearningPrivateEndpoint>)this).Write(writer, options);

        RegistryPrivateEndpoint IJsonModel<RegistryPrivateEndpoint>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RegistryPrivateEndpoint>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RegistryPrivateEndpoint)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRegistryPrivateEndpoint(document.RootElement, options);
        }

        internal static RegistryPrivateEndpoint DeserializeRegistryPrivateEndpoint(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ResourceIdentifier id = default;
            ResourceIdentifier subnetArmId = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        id = new ResourceIdentifier(property.Value.GetString());
                    }
                    continue;
                }

                if (property.NameEquals("subnetArmId"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        subnetArmId = new ResourceIdentifier(property.Value.GetString());
                    }
                    continue;
                }

                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }

            return new RegistryPrivateEndpoint(id, additionalBinaryDataProperties, subnetArmId);
        }
    }
}
