// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    public class ModelX : BaseModel, IUtf8JsonSerializable, IModelJsonSerializable<ModelX>
    {
        public ModelX()
            : base(null)
        {
            Kind = "X";
        }

        internal ModelX(string kind, string name, int xProperty, List<string> fields, Dictionary<string, string> keyValuePairs, Dictionary<string, BinaryData> rawData)
            : base(rawData)
        {
            Kind = kind;
            Name = name;
            XProperty = xProperty;
            Fields = fields;
            KeyValuePairs = keyValuePairs;
        }

        public int XProperty { get; private set; }
        public IList<string> Fields { get; internal set; }
        public string NullProperty = null;
        public Dictionary<string, string> KeyValuePairs = new Dictionary<string, string>();

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelX>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        public static implicit operator RequestContent(ModelX modelX)
        {
            return RequestContent.Create(modelX, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ModelX(Response response)
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(response.ContentStream);
            return DeserializeModelX(jsonDocument.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        void IModelJsonSerializable<ModelX>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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
            foreach (KeyValuePair<string, string> keyValuePair in KeyValuePairs)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("key"u8);
                writer.WriteStringValue(keyValuePair.Key);
                writer.WritePropertyName("value"u8);
                writer.WriteStringValue(keyValuePair.Value);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();

            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("xProperty"u8);
                writer.WriteNumberValue(XProperty);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                SerializeRawData(writer);
            }
            writer.WriteEndObject();
        }

        internal static ModelX DeserializeModelX(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = default;
            Optional<string> name = default;
            int xProperty = default;
            List<string> fields = default;
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
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
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    keyValuePairs = dictionary;
                }
                if (property.NameEquals("xProperty"u8))
                {
                    xProperty = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new ModelX(kind, name, xProperty, fields, keyValuePairs, rawData);
        }

        ModelX IModelSerializable<ModelX>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return DeserializeModelX(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        //public method to serialize with internal interface
        public void Serialize(Utf8JsonWriter writer)
        {
            ((IUtf8JsonSerializable)this).Write(writer);
        }

        ModelX IModelJsonSerializable<ModelX>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelX(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ModelX>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var writer = new ModelWriter(this, options);
            return writer.ToBinaryData();
        }
    }
}
