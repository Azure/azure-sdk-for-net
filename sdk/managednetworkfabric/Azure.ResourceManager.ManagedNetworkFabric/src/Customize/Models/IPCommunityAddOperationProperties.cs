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
    /// <summary> IP Community Properties. </summary>
    public partial class IPCommunityAddOperationProperties : IJsonModel<IPCommunityAddOperationProperties>, IPersistableModel<IPCommunityAddOperationProperties>
    {
        /// <summary> Initializes a new instance of <see cref="IPCommunityAddOperationProperties"/>. </summary>
        public IPCommunityAddOperationProperties()
        {
            AddIPCommunityIds = new ChangeTrackingList<ResourceIdentifier>();
        }

        /// <summary> List of IP Community resource IDs. </summary>
        public IList<ResourceIdentifier> AddIPCommunityIds { get; }

        void IJsonModel<IPCommunityAddOperationProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
            string format = options.Format == "W" ? ((IPersistableModel<IPCommunityAddOperationProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IPCommunityAddOperationProperties)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("add"u8);
            writer.WriteStartObject();
            writer.WritePropertyName("ipCommunityIds"u8);
            writer.WriteStartArray();
            foreach (ResourceIdentifier item in AddIPCommunityIds)
            {
                writer.WriteStringValue(item?.ToString());
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        IPCommunityAddOperationProperties IJsonModel<IPCommunityAddOperationProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IPCommunityAddOperationProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IPCommunityAddOperationProperties)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIPCommunityAddOperationProperties(document.RootElement, options);
        }

        internal static IPCommunityAddOperationProperties DeserializeIPCommunityAddOperationProperties(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            IPCommunityAddOperationProperties result = new IPCommunityAddOperationProperties();
            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("add"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    IPCommunityIdList add = IPCommunityIdList.DeserializeIPCommunityIdList(prop.Value, options);
                    foreach (string id in add.IpCommunityIds)
                    {
                        result.AddIPCommunityIds.Add(id is null ? null : new ResourceIdentifier(id));
                    }
                    continue;
                }
            }
            return result;
        }

        BinaryData IPersistableModel<IPCommunityAddOperationProperties>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IPCommunityAddOperationProperties>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default),
                _ => throw new FormatException($"The model {nameof(IPCommunityAddOperationProperties)} does not support writing '{options.Format}' format.")
            };
        }

        IPCommunityAddOperationProperties IPersistableModel<IPCommunityAddOperationProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IPCommunityAddOperationProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeIPCommunityAddOperationProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(IPCommunityAddOperationProperties)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<IPCommunityAddOperationProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
