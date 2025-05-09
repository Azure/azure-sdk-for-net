// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DevOpsInfrastructure.Models
{
    [PersistableModelProxy(typeof(UnknownDevOpsPoolAgentProfile))]
    public partial class DevOpsPoolAgentProfile : IUtf8JsonSerializable, IJsonModel<DevOpsPoolAgentProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DevOpsPoolAgentProfile>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DevOpsPoolAgentProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DevOpsPoolAgentProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DevOpsPoolAgentProfile)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (Optional.IsDefined(ResourcePredictions))
            {
                writer.WritePropertyName("resourcePredictions"u8);
                writer.WriteObjectValue(ResourcePredictions, options);
            }
            if (Optional.IsDefined(ResourcePredictionsProfile))
            {
                writer.WritePropertyName("resourcePredictionsProfile"u8);
                writer.WriteObjectValue(ResourcePredictionsProfile, options);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        DevOpsPoolAgentProfile IJsonModel<DevOpsPoolAgentProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DevOpsPoolAgentProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DevOpsPoolAgentProfile)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDevOpsPoolAgentProfile(document.RootElement, options);
        }

        internal static DevOpsPoolAgentProfile DeserializeDevOpsPoolAgentProfile(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Stateful": return DevOpsStateful.DeserializeDevOpsStateful(element, options);
                    case "Stateless": return DevOpsStatelessAgentProfile.DeserializeDevOpsStatelessAgentProfile(element, options);
                }
            }
            return UnknownDevOpsPoolAgentProfile.DeserializeUnknownDevOpsPoolAgentProfile(element, options);
        }

        BinaryData IPersistableModel<DevOpsPoolAgentProfile>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DevOpsPoolAgentProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDevOpsInfrastructureContext.Default);
                default:
                    throw new FormatException($"The model {nameof(DevOpsPoolAgentProfile)} does not support writing '{options.Format}' format.");
            }
        }

        DevOpsPoolAgentProfile IPersistableModel<DevOpsPoolAgentProfile>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DevOpsPoolAgentProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeDevOpsPoolAgentProfile(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DevOpsPoolAgentProfile)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DevOpsPoolAgentProfile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
