// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.OpenAI.Files;

internal partial class AzureOpenAIFileCollection : IJsonModel<AzureOpenAIFileCollection>
{
    internal static void SerializeAzureOpenAIFileCollection(AzureOpenAIFileCollection instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("data"u8);
        writer.WriteStartArray();
        foreach (var item in instance.Items)
        {
            writer.WriteObjectValue(item as AzureOpenAIFile, options);
        }
        writer.WriteEndArray();
        writer.WritePropertyName("object"u8);
        writer.WriteStringValue(instance.Object.ToString());
        writer.WriteSerializedAdditionalRawData(instance.SerializedAdditionalRawData, options);
        writer.WriteEndObject();
    }

    // CUSTOM: Recovered the deserialization of SerializedAdditionalRawData. See https://github.com/Azure/autorest.csharp/issues/4636.
    internal static AzureOpenAIFileCollection DeserializeAzureOpenAIFileCollection(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        IReadOnlyList<AzureOpenAIFile> data = default;
        string @object = default;
        string firstId = default;
        string lastId = default;
        bool hasMore = false;
        IDictionary<string, BinaryData> additionalBinaryDataProperties = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("data"u8))
            {
                List<AzureOpenAIFile> array = [];
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(AzureOpenAIFile.DeserializeAzureOpenAIFile(item, options));
                }
                data = array;
                continue;
            }
            if (property.NameEquals("object"u8))
            {
                @object = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("first_id"u8))
            {
                firstId = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("last_id"u8))
            {
                lastId = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("has_more"u8))
            {
                hasMore = property.Value.GetBoolean();
                continue;
            }
            if (true)
            {
                rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        additionalBinaryDataProperties = rawDataDictionary;
        return new AzureOpenAIFileCollection(data, @object, firstId, lastId, hasMore, additionalBinaryDataProperties);
    }

    void IJsonModel<AzureOpenAIFileCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeAzureOpenAIFileCollection, writer, options);

    AzureOpenAIFileCollection IJsonModel<AzureOpenAIFileCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeAzureOpenAIFileCollection, ref reader, options);

    BinaryData IPersistableModel<AzureOpenAIFileCollection>.Write(ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, options);

    AzureOpenAIFileCollection IPersistableModel<AzureOpenAIFileCollection>.Create(BinaryData data, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeAzureOpenAIFileCollection, data, options);

    string IPersistableModel<AzureOpenAIFileCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static AzureOpenAIFileCollection FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializeAzureOpenAIFileCollection(document.RootElement);
    }
}
