// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customized: the generator leaves serialization empty for this ResourceData-compatible custom base model, while generated resource methods still require these helpers.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningWorkspaceConnectionData
    {
        // Customized: generated resource deserialization creates this model as an IJsonModel shim.
        internal MachineLearningWorkspaceConnectionData()
        {
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual object PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningWorkspaceConnectionData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeMachineLearningWorkspaceConnectionData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningWorkspaceConnectionData)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningWorkspaceConnectionData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerMachineLearningContext.Default);
                default:
                    throw new FormatException($"The model {nameof(MachineLearningWorkspaceConnectionData)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<MachineLearningWorkspaceConnectionData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        MachineLearningWorkspaceConnectionData IPersistableModel<MachineLearningWorkspaceConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options) => (MachineLearningWorkspaceConnectionData)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<MachineLearningWorkspaceConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="workspaceConnectionData"> The <see cref="MachineLearningWorkspaceConnectionData"/> to serialize into <see cref="RequestContent"/>. </param>
        internal static RequestContent ToRequestContent(MachineLearningWorkspaceConnectionData workspaceConnectionData)
        {
            if (workspaceConnectionData == null)
            {
                return null;
            }
            return RequestContent.Create(workspaceConnectionData, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="response"> The <see cref="Response"/> to deserialize the <see cref="MachineLearningWorkspaceConnectionData"/> from. </param>
        internal static MachineLearningWorkspaceConnectionData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMachineLearningWorkspaceConnectionData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<MachineLearningWorkspaceConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningWorkspaceConnectionData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MachineLearningWorkspaceConnectionData)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteObjectValue(Properties, options);
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        MachineLearningWorkspaceConnectionData IJsonModel<MachineLearningWorkspaceConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (MachineLearningWorkspaceConnectionData)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual object JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningWorkspaceConnectionData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MachineLearningWorkspaceConnectionData)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningWorkspaceConnectionData(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static MachineLearningWorkspaceConnectionData DeserializeMachineLearningWorkspaceConnectionData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            MachineLearningWorkspaceConnectionProperties properties = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = new ResourceIdentifier(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceType = new ResourceType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerMachineLearningContext.Default);
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    properties = MachineLearningWorkspaceConnectionProperties.DeserializeMachineLearningWorkspaceConnectionProperties(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new MachineLearningWorkspaceConnectionData(
                id,
                name,
                resourceType,
                systemData,
                properties,
                additionalBinaryDataProperties);
        }
    }
}
