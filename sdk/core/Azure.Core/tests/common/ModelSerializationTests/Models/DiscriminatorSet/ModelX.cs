// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        internal ModelX(string kind, string name, int xProperty, Dictionary<string, BinaryData> rawData)
            : base(rawData)
        {
            Kind = kind;
            Name = name;
            XProperty = xProperty;
        }

        public int XProperty { get; private set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelX>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        public static implicit operator RequestContent(ModelX modelX)
        {
            if (modelX == null)
            {
                return null;
            }

            return RequestContent.Create(modelX, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ModelX(Response response)
        {
            if (response == null)
            {
                return null;
            }

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
            return new ModelX(kind, name, xProperty, rawData);
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
