// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI.Files;

internal partial class AzureOpenAIFile : IJsonModel<AzureOpenAIFile>
{
    internal static void SerializeAzureOpenAIFile(AzureOpenAIFile instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        if (instance.SerializedAdditionalRawData?.ContainsKey("id") != true)
        {
            if (Optional.IsDefined(instance.Id))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(instance.Id);
            }
        }
        if (instance.SerializedAdditionalRawData?.ContainsKey("bytes") != true)
        {
            if (instance.SizeInBytes != null)
            {
                writer.WritePropertyName("bytes"u8);
                writer.WriteNumberValue(instance.SizeInBytes.Value);
            }
            else
            {
                writer.WriteNull("bytes");
            }
        }
        if (instance.SerializedAdditionalRawData?.ContainsKey("created_at") != true)
        {
            writer.WritePropertyName("created_at"u8);
            writer.WriteNumberValue(instance.CreatedAt, "U");
        }
        if (instance.SerializedAdditionalRawData?.ContainsKey("filename") != true)
        {
            writer.WritePropertyName("filename"u8);
            writer.WriteStringValue(instance.Filename);
        }
        if (instance.SerializedAdditionalRawData?.ContainsKey("object") != true)
        {
            writer.WritePropertyName("object"u8);
            writer.WriteStringValue(instance._object);
        }
        if (instance.SerializedAdditionalRawData?.ContainsKey("purpose") != true)
        {
            writer.WritePropertyName("purpose"u8);
            writer.WriteStringValue(instance._purpose);
        }
        if (instance.SerializedAdditionalRawData?.ContainsKey("status_details") != true && Optional.IsDefined(instance.StatusDetails))
        {
            writer.WritePropertyName("status_details"u8);
            writer.WriteStringValue(instance.StatusDetails);
        }
        if (instance.SerializedAdditionalRawData?.ContainsKey("status") != true)
        {
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(instance._azureStatus.ToSerialString());
        }
        if (instance.SerializedAdditionalRawData != null)
        {
            foreach (var item in instance.SerializedAdditionalRawData)
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
        writer.WriteEndObject();
    }

    // CUSTOM: Recovered the deserialization of SerializedAdditionalRawData. See https://github.com/Azure/autorest.csharp/issues/4636.
    internal static AzureOpenAIFile DeserializeAzureOpenAIFile(JsonElement element, ModelReaderWriterOptions options = null)
    {
        string id = default;
        int? bytes = default;
        DateTimeOffset createdAt = default;
        string filename = default;
        string @object = default;
        string purpose = default;
        string statusDetails = default;
        AzureOpenAIFileStatus status = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("id"u8))
            {
                id = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("bytes"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    bytes = null;
                    continue;
                }
                bytes = property.Value.GetInt32();
                continue;
            }
            if (property.NameEquals("created_at"u8))
            {
                createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                continue;
            }
            if (property.NameEquals("filename"u8))
            {
                filename = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("object"u8))
            {
                @object = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("purpose"u8))
            {
                purpose = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("status_details"u8))
            {
                statusDetails = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("status"u8))
            {
                status = property.Value.GetString().ToAzureOpenAIFileStatus();
                continue;
            }
            if (options.Format != "W")
            {
                rawDataDictionary ??= new Dictionary<string, BinaryData>();
                rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        serializedAdditionalRawData = rawDataDictionary;
        return new AzureOpenAIFile(
            id,
            bytes,
            createdAt,
            filename,
            @object,
            purpose,
            statusDetails,
            status,
            serializedAdditionalRawData);
    }

    void IJsonModel<AzureOpenAIFile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeAzureOpenAIFile, writer, options);

    AzureOpenAIFile IJsonModel<AzureOpenAIFile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeAzureOpenAIFile, ref reader, options);

    BinaryData IPersistableModel<AzureOpenAIFile>.Write(ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, options);

    AzureOpenAIFile IPersistableModel<AzureOpenAIFile>.Create(BinaryData data, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeAzureOpenAIFile, data, options);

    string IPersistableModel<AzureOpenAIFile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    /// <summary> Deserializes the model from a raw response. </summary>
    /// <param name="response"> The result to deserialize the model from. </param>
    internal static new AzureOpenAIFile FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializeAzureOpenAIFile(document.RootElement);
    }

    /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
    internal override BinaryContent ToBinaryContent()
    {
        return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
    }
}
