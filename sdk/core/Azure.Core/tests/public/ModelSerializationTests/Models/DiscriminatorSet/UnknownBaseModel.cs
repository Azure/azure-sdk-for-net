﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    internal class UnknownBaseModel : BaseModel, IUtf8JsonSerializable, IModelJsonSerializable<BaseModel>
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public UnknownBaseModel()
        {
            Kind = "Unknown";
        }

        internal UnknownBaseModel(string kind, string name, Dictionary<string, BinaryData> rawData)
        {
            Kind = kind;
            Name = name;
            RawData = rawData;
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<BaseModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

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

        internal static BaseModel DeserializeUnknownBaseModel(JsonElement element, ModelSerializerOptions options = default) => DeserializeBaseModel(element, options);

        BaseModel IModelSerializable<BaseModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeUnknownBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        BaseModel IModelJsonSerializable<BaseModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeUnknownBaseModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<BaseModel>.Serialize(ModelSerializerOptions options) => ModelSerializer.ConvertToBinaryData(this, options);
    }
}
