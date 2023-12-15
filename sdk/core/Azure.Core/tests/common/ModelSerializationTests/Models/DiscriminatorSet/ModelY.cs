// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.ModelSerializationTests.Models
{
    public class ModelY : BaseModel, IUtf8JsonSerializable, IModelJsonSerializable<ModelY>
    {
        public ModelY()
            : base(null)
        {
            Kind = "Y";
        }

        internal ModelY(string kind, string name, string yProperty, Dictionary<string, BinaryData> rawData)
            : base(rawData)
        {
            Kind = kind;
            Name = name;
            YProperty = yProperty;
        }

        public string YProperty { get; private set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelY>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ModelY>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

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
                writer.WritePropertyName("yProperty"u8);
                writer.WriteStringValue(YProperty);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                SerializeRawData(writer);
            }
            writer.WriteEndObject();
        }

        internal static ModelY DeserializeModelY(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = default;
            Optional<string> name = default;
            Optional<string> yProperty = default;
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
                if (property.NameEquals("yProperty"u8))
                {
                    yProperty = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new ModelY(kind, name, yProperty, rawData);
        }

        ModelY IModelSerializable<ModelY>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeModelY(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        ModelY IModelJsonSerializable<ModelY>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelY(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ModelY>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }
    }
}
