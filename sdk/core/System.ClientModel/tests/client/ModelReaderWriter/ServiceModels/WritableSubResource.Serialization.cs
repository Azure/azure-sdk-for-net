// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClientModel.Tests.ClientShared;

namespace System.ClientModel.Tests.Client.Models.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    [JsonConverter(typeof(WritableSubResourceConverter))]
    public partial class WritableSubResource : IJsonModel<WritableSubResource>
    {
        void IJsonModel<WritableSubResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => Serialize(writer, options);

        /// <summary>
        /// Serialize the input WritableSubResource object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (Patch.Contains("$"u8))
            {
                writer.WriteRawValue(Patch.GetJson("$"u8));
                return;
            }

            writer.WriteStartObject();
            if (OptionalProperty.IsDefined(Id) && !Patch.Contains("$.id"u8))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }

            Patch.WriteTo(writer);

            writer.WriteEndObject();
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        }

        /// <summary>
        /// Deserialize the input JSON element to a WritableSubResource object.
        /// </summary>
        /// <param name="element">The JSON element to be deserialized.</param>
        /// <returns>Deserialized WritableSubResource object.</returns>
        internal static WritableSubResource DeserializeWritableSubResource(JsonElement element, ModelReaderWriterOptions? options, BinaryData? data)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            string? id = default;
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            JsonPatch jsonPatch = new(data is null ? ReadOnlyMemory<byte>.Empty : data.ToMemory());
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = property.Value.GetString();
                    continue;
                }

                jsonPatch.Set([.. "$."u8, .. Encoding.UTF8.GetBytes(property.Name)], property.Value.GetUtf8Bytes());
            }
            var model = new WritableSubResource(id, jsonPatch);

            return model;
        }

        private struct WritableSubResourceProperties
        {
            public string Id { get; set; }
        }

        WritableSubResource IJsonModel<WritableSubResource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeWritableSubResource(doc.RootElement, options, null);
        }

        private static void SetProperty(ReadOnlySpan<byte> propertyName, ref WritableSubResourceProperties properties, ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            if (propertyName.SequenceEqual("id"u8))
            {
                reader.Read();
                if (reader.TokenType != JsonTokenType.Null)
                {
                    properties.Id = reader.GetString()!;
                }
                return;
            }
            reader.Skip();
        }

        WritableSubResource IPersistableModel<WritableSubResource>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeWritableSubResource(doc.RootElement, options, data);
        }

        internal partial class WritableSubResourceConverter : JsonConverter<WritableSubResource>
        {
            public override void Write(Utf8JsonWriter writer, WritableSubResource model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override WritableSubResource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeWritableSubResource(document.RootElement, ModelReaderWriterHelper.WireOptions, null);
            }
        }

        BinaryData IPersistableModel<WritableSubResource>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.Write(this, options);
        }

        string IPersistableModel<WritableSubResource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
