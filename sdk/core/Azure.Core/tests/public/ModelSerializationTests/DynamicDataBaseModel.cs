// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public class DynamicDataBaseModel : IUtf8JsonSerializable, IModelJsonSerializable<DynamicDataBaseModel>
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public string Name { get; set; } = "DynamicDataModel";

        public DynamicDataMiniModel MiniModel { get; set; } = new DynamicDataMiniModel();

        public DynamicDataBaseModel()
        {
        }

        public DynamicDataBaseModel(string name)
        {
            Name = name;
        }

        internal DynamicDataBaseModel(string name, DynamicDataMiniModel miniModel, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            MiniModel = miniModel;
            RawData = rawData;
        }

        #region Serialization
        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("miniModel"u8);
            ((IModelJsonSerializable<DynamicDataMiniModel>)MiniModel).Serialize(writer, options);

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

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DynamicDataBaseModel>)this).Serialize(writer, new ModelSerializerOptions(ModelSerializerFormat.Wire));

        void IModelJsonSerializable<DynamicDataBaseModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

        internal static DynamicDataBaseModel DeserializeDynamicDataBaseModel(JsonElement element, ModelSerializerOptions options)
        {
            string name = "";
            DynamicDataMiniModel miniModel = new DynamicDataMiniModel();

            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("miniModel"u8))
                {
                    miniModel = DynamicDataMiniModel.DeserializeDynamicDataMiniModel(property.Value, options);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new DynamicDataBaseModel(name, miniModel, rawData);
        }
        #endregion

        #region InterfaceImplementation
        DynamicDataBaseModel IModelJsonSerializable<DynamicDataBaseModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDynamicDataBaseModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DynamicDataBaseModel>.Serialize(ModelSerializerOptions options) => ModelSerializer.ConvertToBinaryData(this, options);

        DynamicDataBaseModel IModelSerializable<DynamicDataBaseModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeDynamicDataBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);
        }
        #endregion
    }
}
