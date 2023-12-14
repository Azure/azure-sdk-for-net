// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests.Models
{
    public class CatReadOnlyProperty : Animal, IJsonModel<CatReadOnlyProperty>, IUtf8JsonSerializable
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
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<CatReadOnlyProperty>)this).Write(writer, ModelReaderWriterHelper.WireOptions);

        void IJsonModel<CatReadOnlyProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => Serialize(writer, options);

        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == "J")
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

            if (options.Format == "J")
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

        internal static CatReadOnlyProperty DeserializeCatReadOnlyProperty(JsonElement element, ModelReaderWriterOptions options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

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
                if (options.Format == "J")
                {
                    //this means its an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new CatReadOnlyProperty(weight, latinName, name, isHungry, hasWhiskers, rawData);
        }

        CatReadOnlyProperty IPersistableModel<CatReadOnlyProperty>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            return DeserializeCatReadOnlyProperty(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        CatReadOnlyProperty IJsonModel<CatReadOnlyProperty>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeCatReadOnlyProperty(doc.RootElement, options);
        }

        BinaryData IPersistableModel<CatReadOnlyProperty>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.Write(this, options);
        }

        string IPersistableModel<CatReadOnlyProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        #endregion
    }
}
