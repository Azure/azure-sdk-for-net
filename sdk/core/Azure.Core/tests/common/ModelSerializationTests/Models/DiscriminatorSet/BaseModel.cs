// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    public abstract class BaseModel : IUtf8JsonSerializable, IModelJsonSerializable<BaseModel>
    {
        private Dictionary<string, BinaryData> _rawData;

        public static implicit operator RequestContent(BaseModel baseModel)
        {
            return RequestContent.Create(baseModel, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator BaseModel(Response response)
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(response.ContentStream);
            return DeserializeBaseModel(jsonDocument.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        protected internal BaseModel(Dictionary<string, BinaryData> rawData)
        {
            _rawData = rawData ?? new Dictionary<string, BinaryData>();
        }

        public string Kind { get; internal set; }
        public string Name { get; set; }
        public IList<string> Fields { get; internal set; }
        public string NullProperty = null;
        public Dictionary<string, int> KeyValuePairs = new Dictionary<string, int>();

        protected internal void SerializeRawData(Utf8JsonWriter writer)
        {
            //write out the raw data
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

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<BaseModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<BaseModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            Serialize(writer, options);
        }

        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }

            writer.WritePropertyName("fields"u8);
            writer.WriteStartArray();
            foreach (string field in Fields)
            {
                writer.WriteStringValue(field);
            }
            writer.WriteEndArray();

            writer.WritePropertyName("nullProperty"u8);
            writer.WriteStringValue(NullProperty);

            writer.WritePropertyName("keyValuePairs"u8);
            writer.WriteStartArray();
            foreach (KeyValuePair<string, int> keyValuePair in KeyValuePairs)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("key"u8);
                writer.WriteStringValue(keyValuePair.Key);
                writer.WritePropertyName("value"u8);
                writer.WriteNumberValue(keyValuePair.Value);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();

            if (options.Format == ModelSerializerFormat.Json)
            {
                SerializeRawData(writer);
            }
            writer.WriteEndObject();
        }

        internal static BaseModel DeserializeBaseModel(BinaryData data, ModelSerializerOptions options)
            => DeserializeBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);

        internal static BaseModel DeserializeBaseModel(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "X":
                        return ModelX.DeserializeModelX(element, options);
                    case "Y":
                        return ModelY.DeserializeModelY(element, options);
                }
            }

            //Deserialize unknown subtype
            string kind = default;
            Optional<string> name = default;
            List<string> fields = default;
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fields"u8))
                {
                    fields = property.Value.EnumerateArray().Select(element => element.GetString()).ToList();
                    continue;
                }
                if (property.NameEquals("nullProperty"u8))
                {
                    continue;
                }
                if (property.NameEquals("keyValuePairs"u8))
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetInt32());
                    }
                    keyValuePairs = dictionary;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new UnknownBaseModel(kind, name, fields, keyValuePairs, rawData);
        }

        BaseModel IModelSerializable<BaseModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return DeserializeBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        BaseModel IModelJsonSerializable<BaseModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeBaseModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<BaseModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var writer = new ModelWriter(this, options);
            return writer.ToBinaryData();
        }
    }
}
