// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.ResourceManager.Resources.Models
{
    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    [JsonConverter(typeof(WritableSubResourceConverter))]
    public partial class WritableSubResource : IUtf8JsonSerializable, IModelJsonSerializable<WritableSubResource>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<WritableSubResource>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<WritableSubResource>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

        /// <summary>
        /// Serialize the input WritableSubResource object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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
        internal static WritableSubResource DeserializeWritableSubResource(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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

        WritableSubResource IModelJsonSerializable<WritableSubResource>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeWritableSubResource(doc.RootElement, options);
        }

        private static void SetProperty(ReadOnlySpan<byte> propertyName, ref WritableSubResourceProperties properties, ref Utf8JsonReader reader, ModelSerializerOptions options)
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

        WritableSubResource IModelSerializable<WritableSubResource>.Deserialize(BinaryData data, ModelSerializerOptions options)
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
                return DeserializeWritableSubResource(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
            }
        }

        BinaryData IModelSerializable<WritableSubResource>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }
    }
}
