// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> IP Extended Community Properties. </summary>
    public partial class IPExtendedCommunityAddOperationProperties : IJsonModel<IPExtendedCommunityAddOperationProperties>, IPersistableModel<IPExtendedCommunityAddOperationProperties>
    {
        /// <summary> Initializes a new instance of <see cref="IPExtendedCommunityAddOperationProperties"/>. </summary>
        public IPExtendedCommunityAddOperationProperties()
        {
            AddIPExtendedCommunityIds = new ChangeTrackingList<ResourceIdentifier>();
        }

        /// <summary> List of IP Extended Community resource IDs. </summary>
        public IList<ResourceIdentifier> AddIPExtendedCommunityIds { get; }

        void IJsonModel<IPExtendedCommunityAddOperationProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <summary> Writes the model JSON payload. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IPExtendedCommunityAddOperationProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IPExtendedCommunityAddOperationProperties)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("add"u8);
            writer.WriteStartObject();
            writer.WritePropertyName("ipExtendedCommunityIds"u8);
            writer.WriteStartArray();
            foreach (ResourceIdentifier item in AddIPExtendedCommunityIds)
            {
                writer.WriteStringValue(item?.ToString());
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        IPExtendedCommunityAddOperationProperties IJsonModel<IPExtendedCommunityAddOperationProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IPExtendedCommunityAddOperationProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IPExtendedCommunityAddOperationProperties)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIPExtendedCommunityAddOperationProperties(document.RootElement, options);
        }

        internal static IPExtendedCommunityAddOperationProperties DeserializeIPExtendedCommunityAddOperationProperties(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            IPExtendedCommunityAddOperationProperties result = new IPExtendedCommunityAddOperationProperties();
            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("add"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    IPExtendedCommunityIdList add = IPExtendedCommunityIdList.DeserializeIPExtendedCommunityIdList(prop.Value, options);
                    foreach (string id in add.IPExtendedCommunityIds)
                    {
                        result.AddIPExtendedCommunityIds.Add(id is null ? null : new ResourceIdentifier(id));
                    }
                    continue;
                }
            }
            return result;
        }

        BinaryData IPersistableModel<IPExtendedCommunityAddOperationProperties>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IPExtendedCommunityAddOperationProperties>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default),
                _ => throw new FormatException($"The model {nameof(IPExtendedCommunityAddOperationProperties)} does not support writing '{options.Format}' format.")
            };
        }

        IPExtendedCommunityAddOperationProperties IPersistableModel<IPExtendedCommunityAddOperationProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IPExtendedCommunityAddOperationProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeIPExtendedCommunityAddOperationProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(IPExtendedCommunityAddOperationProperties)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<IPExtendedCommunityAddOperationProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
