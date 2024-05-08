// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Vision.Face
{
    internal partial class IdentifyFromEntirePersonDirectoryRequest : IUtf8JsonSerializable, IJsonModel<IdentifyFromEntirePersonDirectoryRequest>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<IdentifyFromEntirePersonDirectoryRequest>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<IdentifyFromEntirePersonDirectoryRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IdentifyFromEntirePersonDirectoryRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IdentifyFromEntirePersonDirectoryRequest)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("faceIds"u8);
            writer.WriteStartArray();
            foreach (var item in FaceIds)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("personIds"u8);
            writer.WriteStartArray();
            writer.WriteStringValue("*");
            writer.WriteEndArray();
            if (Optional.IsDefined(MaxNumOfCandidatesReturned))
            {
                writer.WritePropertyName("maxNumOfCandidatesReturned"u8);
                writer.WriteNumberValue(MaxNumOfCandidatesReturned.Value);
            }
            if (Optional.IsDefined(ConfidenceThreshold))
            {
                writer.WritePropertyName("confidenceThreshold"u8);
                writer.WriteNumberValue(ConfidenceThreshold.Value);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
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
            writer.WriteEndObject();
        }

        IdentifyFromEntirePersonDirectoryRequest IJsonModel<IdentifyFromEntirePersonDirectoryRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IdentifyFromEntirePersonDirectoryRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IdentifyFromEntirePersonDirectoryRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIdentifyFromEntirePersonDirectoryRequest(document.RootElement, options);
        }

        internal static IdentifyFromEntirePersonDirectoryRequest DeserializeIdentifyFromEntirePersonDirectoryRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<Guid> faceIds = default;
            int? maxNumOfCandidatesReturned = default;
            float? confidenceThreshold = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("faceIds"u8))
                {
                    List<Guid> array = new List<Guid>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetGuid());
                    }
                    faceIds = array;
                    continue;
                }
                if (property.NameEquals("maxNumOfCandidatesReturned"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxNumOfCandidatesReturned = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("confidenceThreshold"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    confidenceThreshold = property.Value.GetSingle();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new IdentifyFromEntirePersonDirectoryRequest(faceIds, maxNumOfCandidatesReturned, confidenceThreshold, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<IdentifyFromEntirePersonDirectoryRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IdentifyFromEntirePersonDirectoryRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(IdentifyFromEntirePersonDirectoryRequest)} does not support writing '{options.Format}' format.");
            }
        }

        IdentifyFromEntirePersonDirectoryRequest IPersistableModel<IdentifyFromEntirePersonDirectoryRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IdentifyFromEntirePersonDirectoryRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeIdentifyFromEntirePersonDirectoryRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(IdentifyFromEntirePersonDirectoryRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<IdentifyFromEntirePersonDirectoryRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static IdentifyFromEntirePersonDirectoryRequest FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeIdentifyFromEntirePersonDirectoryRequest(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
