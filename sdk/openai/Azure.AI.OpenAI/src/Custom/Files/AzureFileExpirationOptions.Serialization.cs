// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.OpenAI;

namespace Azure.AI.OpenAI.Files
{
    /// <summary></summary>
    public partial class AzureFileExpirationOptions : IJsonModel<AzureFileExpirationOptions>
    {
        internal AzureFileExpirationOptions()
        {
        }

        void IJsonModel<AzureFileExpirationOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureFileExpirationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureFileExpirationOptions)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("seconds") != true)
            {
                writer.WritePropertyName("seconds"u8);
                writer.WriteNumberValue(Seconds);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("anchor") != true)
            {
                writer.WritePropertyName("anchor"u8);
                writer.WriteStringValue(Anchor.ToString());
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                    {
                        continue;
                    }
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        AzureFileExpirationOptions IJsonModel<AzureFileExpirationOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual AzureFileExpirationOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureFileExpirationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureFileExpirationOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureFileExpirationOptions(document.RootElement, options);
        }

        internal static AzureFileExpirationOptions DeserializeAzureFileExpirationOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int seconds = default;
            AzureFileExpirationAnchor anchor = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("seconds"u8))
                {
                    seconds = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("anchor"u8))
                {
                    anchor = new AzureFileExpirationAnchor(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new AzureFileExpirationOptions(seconds, anchor, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<AzureFileExpirationOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureFileExpirationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureAIOpenAIContext.Default);
                default:
                    throw new FormatException($"The model {nameof(AzureFileExpirationOptions)} does not support writing '{options.Format}' format.");
            }
        }

        AzureFileExpirationOptions IPersistableModel<AzureFileExpirationOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual AzureFileExpirationOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureFileExpirationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeAzureFileExpirationOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AzureFileExpirationOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AzureFileExpirationOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="azureFileExpirationOptions"> The <see cref="AzureFileExpirationOptions"/> to serialize into <see cref="BinaryContent"/>. </param>
        public static implicit operator BinaryContent(AzureFileExpirationOptions azureFileExpirationOptions)
        {
            if (azureFileExpirationOptions == null)
            {
                return null;
            }
            return BinaryContent.Create(azureFileExpirationOptions, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="result"> The <see cref="ClientResult"/> to deserialize the <see cref="AzureFileExpirationOptions"/> from. </param>
        public static explicit operator AzureFileExpirationOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeAzureFileExpirationOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
