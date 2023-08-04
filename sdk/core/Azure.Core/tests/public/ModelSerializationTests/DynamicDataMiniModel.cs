// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public class DynamicDataMiniModel : IUtf8JsonSerializable, IModelJsonSerializable<DynamicDataMiniModel>
    {
        public DynamicDataMiniModel(string x)
        {
            X = x;
        }

        internal DynamicDataMiniModel()
        {
        }

        public string X { get; set; }

        #region Serialization
        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("foo"u8);
            writer.WriteStringValue(X);

            writer.WriteEndObject();
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DynamicDataMiniModel>)this).Serialize(writer, new ModelSerializerOptions(ModelSerializerFormat.Wire));

        void IModelJsonSerializable<DynamicDataMiniModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

        internal static DynamicDataMiniModel DeserializeDynamicDataMiniModel(JsonElement element, ModelSerializerOptions options)
        {
            string x = "";

            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("foo"u8))
                {
                    x = property.Value.GetString();
                    continue;
                }
            }
            return new DynamicDataMiniModel(x);
        }

        #endregion

        #region InterfaceImplementation

        DynamicDataMiniModel IModelJsonSerializable<DynamicDataMiniModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDynamicDataMiniModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DynamicDataMiniModel>.Serialize(ModelSerializerOptions options) => ModelSerializer.ConvertToBinaryData(this, options);

        DynamicDataMiniModel IModelSerializable<DynamicDataMiniModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeDynamicDataMiniModel(JsonDocument.Parse(data.ToString()).RootElement, options);
        }
        #endregion
    }
}
