// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public class CatReadOnlyProperty : Animal, IModelJsonSerializable<CatReadOnlyProperty>, IUtf8JsonSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public CatReadOnlyProperty(double weight, string latinName, string name, bool isHungry, bool hasWhiskers) : base(weight, "Felis catus", name, isHungry)
        {
            HasWhiskers = hasWhiskers;
        }

        internal CatReadOnlyProperty(double weight, string latinName, string name, bool isHungry, bool hasWhiskers, Dictionary<string, BinaryData> rawData) : this(weight, latinName, name, isHungry, hasWhiskers)
        {
            RawData = rawData;
        }

        internal CatReadOnlyProperty()
        {
        }

        public bool HasWhiskers { get; private set; } = true;

        #region Serialization
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<CatReadOnlyProperty>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<CatReadOnlyProperty>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("latinName"u8);
                writer.WriteStringValue(LatinName);

                writer.WritePropertyName("hasWhiskers"u8);
                writer.WriteBooleanValue(HasWhiskers);
            }
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("isHungry"u8);
            writer.WriteBooleanValue(IsHungry);
            writer.WritePropertyName("weight"u8);
            writer.WriteNumberValue(Weight);

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

        internal static CatReadOnlyProperty DeserializeCatReadOnlyProperty(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            double weight = default;
            string name = "";
            string latinName = "";
            bool isHungry = default;
            bool hasWhiskers = default;

            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("weight"u8))
                {
                    weight = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("latinName"u8))
                {
                    latinName = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("isHungry"u8))
                {
                    isHungry = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("hasWhiskers"u8))
                {
                    hasWhiskers = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    //this means its an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new CatReadOnlyProperty(weight, latinName, name, isHungry, hasWhiskers, rawData);
        }

        CatReadOnlyProperty IModelSerializable<CatReadOnlyProperty>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeCatReadOnlyProperty(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        CatReadOnlyProperty IModelJsonSerializable<CatReadOnlyProperty>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeCatReadOnlyProperty(doc.RootElement, options);
        }

        BinaryData IModelSerializable<CatReadOnlyProperty>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        #endregion
    }
}
