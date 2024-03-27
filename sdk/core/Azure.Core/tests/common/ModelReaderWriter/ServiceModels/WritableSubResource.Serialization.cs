// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Tests.Common;

namespace Azure.Core.Tests.Models.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    [JsonConverter(typeof(WritableSubResourceConverter))]
    public partial class WritableSubResource : IUtf8JsonSerializable, IJsonModel<WritableSubResource>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<WritableSubResource>)this).Write(writer, ModelReaderWriterHelper.WireOptions);

        void IJsonModel<WritableSubResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => Serialize(writer, options);

        /// <summary>
        /// Serialize the input WritableSubResource object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input JSON element to a WritableSubResource object.
        /// </summary>
        /// <param name="element">The JSON element to be deserialized.</param>
        /// <returns>Deserialized WritableSubResource object.</returns>
        internal static WritableSubResource DeserializeWritableSubResource(JsonElement element, ModelReaderWriterOptions options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            ResourceIdentifier id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
            }
            return new WritableSubResource(id);
        }

        private struct WritableSubResourceProperties
        {
            public ResourceIdentifier Id { get; set; }
        }

        WritableSubResource IJsonModel<WritableSubResource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeWritableSubResource(doc.RootElement, options);
        }

        private static void SetProperty(ReadOnlySpan<byte> propertyName, ref WritableSubResourceProperties properties, ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            if (propertyName.SequenceEqual("id"u8))
            {
                reader.Read();
                if (reader.TokenType != JsonTokenType.Null)
                    properties.Id = new ResourceIdentifier(reader.GetString());
                return;
            }
            reader.Skip();
        }

        WritableSubResource IPersistableModel<WritableSubResource>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeWritableSubResource(doc.RootElement, options);
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
                return DeserializeWritableSubResource(document.RootElement, ModelReaderWriterHelper.WireOptions);
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
