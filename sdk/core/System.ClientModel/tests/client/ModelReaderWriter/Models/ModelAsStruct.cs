// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.ClientShared;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    /// <summary> The InputAdditionalPropertiesModelStruct. </summary>
    public readonly partial struct ModelAsStruct : IJsonModel<ModelAsStruct>, IJsonModel<object>
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

        void IJsonModel<ModelAsStruct>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => Serialize(writer, options);

        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteNumberValue(Id);
            if (_rawData is not null && options.Format == "J")
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

        BinaryData IPersistableModel<ModelAsStruct>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            return ModelReaderWriter.Write(this, options);
        }

        public static implicit operator BinaryContent(ModelAsStruct model)
        {
            return BinaryContent.Create(model, ModelReaderWriterHelper.WireOptions);
        }

        ModelAsStruct IPersistableModel<ModelAsStruct>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeInputAdditionalPropertiesModelStruct(doc.RootElement, options);
        }

        internal static ModelAsStruct DeserializeInputAdditionalPropertiesModelStruct(JsonElement element, ModelReaderWriterOptions? options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            int id = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == "J")
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ModelAsStruct(id, rawData);
        }

        ModelAsStruct IJsonModel<ModelAsStruct>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeInputAdditionalPropertiesModelStruct(doc.RootElement, options);
        }

        public static explicit operator ModelAsStruct(ClientResult result)
        {
            if (result is null) throw new ArgumentNullException(nameof(result));

            using JsonDocument doc = JsonDocument.Parse(result.GetRawResponse().Content);
            return DeserializeInputAdditionalPropertiesModelStruct(doc.RootElement, ModelReaderWriterHelper.WireOptions);
        }

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => Serialize(writer, options);

        object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeInputAdditionalPropertiesModelStruct(doc.RootElement, options);
        }

        BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            return ModelReaderWriter.Write(this, options);
        }

        object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat<ModelAsStruct>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeInputAdditionalPropertiesModelStruct(doc.RootElement, options);
        }

        string IPersistableModel<ModelAsStruct>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        string IPersistableModel<object>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
