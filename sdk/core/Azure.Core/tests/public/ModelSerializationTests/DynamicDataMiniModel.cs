// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public class DynamicDataMiniModel : IUtf8JsonSerializable, IJsonModelSerializable<DynamicDataMiniModel>, IJsonModelSerializable
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

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, new ModelSerializerOptions(ModelSerializerFormat.Wire));

        void IJsonModelSerializable<DynamicDataMiniModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

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

        DynamicDataMiniModel IModelSerializable<DynamicDataMiniModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeDynamicDataMiniModel(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        DynamicDataMiniModel IJsonModelSerializable<DynamicDataMiniModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDynamicDataMiniModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DynamicDataMiniModel>.Serialize(ModelSerializerOptions options)
        {
            return ModelSerializerHelper.SerializeToBinaryData((writer) => { Serialize(writer, options); });
        }

        #endregion

        void IJsonModelSerializable<object>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => ((IJsonModelSerializable<DynamicDataMiniModel>)this).Serialize(writer, options);

        object IJsonModelSerializable<object>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options) => ((IJsonModelSerializable<DynamicDataMiniModel>)this).Deserialize(ref reader, options);

        object IModelSerializable<object>.Deserialize(BinaryData data, ModelSerializerOptions options) => ((IModelSerializable<DynamicDataMiniModel>)this).Deserialize(data, options);

        BinaryData IModelSerializable<object>.Serialize(ModelSerializerOptions options) => ((IModelSerializable<DynamicDataMiniModel>)this).Serialize(options);
    }
}
