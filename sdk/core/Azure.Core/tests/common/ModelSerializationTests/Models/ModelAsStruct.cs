// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.ModelSerializationTests.Models
{
    /// <summary> The InputAdditionalPropertiesModelStruct. </summary>
    public readonly partial struct ModelAsStruct : IUtf8JsonSerializable, IModelJsonSerializable<ModelAsStruct>, IModelJsonSerializable<object>
    {
        private readonly Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of InputAdditionalPropertiesModelStruct. </summary>
        /// <param name="id"></param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <param name="rawData"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="additionalProperties"/> is null. </exception>
        public ModelAsStruct(int id, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            _rawData = rawData;
        }

        /// <summary> Gets the id. </summary>
        public int Id { get; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelAsStruct>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ModelAsStruct>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteNumberValue(Id);
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        BinaryData IModelSerializable<ModelAsStruct>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        public static implicit operator RequestContent(ModelAsStruct model)
        {
            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        ModelAsStruct IModelSerializable<ModelAsStruct>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeInputAdditionalPropertiesModelStruct(doc.RootElement, options);
        }

        internal static ModelAsStruct DeserializeInputAdditionalPropertiesModelStruct(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            int id = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ModelAsStruct(id, rawData);
        }

        ModelAsStruct IModelJsonSerializable<ModelAsStruct>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeInputAdditionalPropertiesModelStruct(doc.RootElement, options);
        }

        public static explicit operator ModelAsStruct(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeInputAdditionalPropertiesModelStruct(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        void IModelJsonSerializable<object>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

        object IModelJsonSerializable<object>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeInputAdditionalPropertiesModelStruct(doc.RootElement, options);
        }

        BinaryData IModelSerializable<object>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        object IModelSerializable<object>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeInputAdditionalPropertiesModelStruct(doc.RootElement, options);
        }
    }
}
