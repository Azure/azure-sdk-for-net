﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    public class ModelX : BaseModel, IUtf8JsonSerializable, IModelJsonSerializable<ModelX>
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public ModelX()
        {
            Kind = "X";
        }

        internal ModelX(string kind, string name, int xProperty, Dictionary<string, BinaryData> rawData)
        {
            Kind = kind;
            Name = name;
            XProperty = xProperty;
            RawData = rawData;
        }

        public int XProperty { get; private set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelX>)this).Serialize(writer, new ModelSerializerOptions(ModelSerializerFormat.Wire));

        public static implicit operator RequestContent(ModelX modelX)
        {
            return new Utf8JsonDelayedRequestContent(modelX, new ModelSerializerOptions(ModelSerializerFormat.Wire));
        }

        public static explicit operator ModelX(Response response)
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(response.ContentStream);
            return DeserializeModelX(jsonDocument.RootElement, new ModelSerializerOptions(ModelSerializerFormat.Wire));
        }

        void IModelJsonSerializable<ModelX>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

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
                //write out the raw data
                foreach (var property in RawData)
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

        internal static ModelX DeserializeModelX(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultServiceOptions;

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
            return DeserializeModelX(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        //public method to serialize with internal interface
        public void Serialize(Utf8JsonWriter writer)
        {
            ((IUtf8JsonSerializable)this).Write(writer);
        }

        ModelX IModelJsonSerializable<ModelX>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelX(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ModelX>.Serialize(ModelSerializerOptions options) => ModelSerializerHelper.SerializeToBinaryData(writer => Serialize(writer, options));
    }
}
