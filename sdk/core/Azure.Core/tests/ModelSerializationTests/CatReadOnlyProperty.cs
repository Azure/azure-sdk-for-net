// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.Core.Tests.ModelSerializationTests
{
    public class CatReadOnlyProperty : Animal, IJsonSerializable, IUtf8JsonSerializable
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

        public bool HasWhiskers { get; private set; } = true;

        #region Serialization
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (!options.IgnoreReadOnlyProperties)
            {
                writer.WritePropertyName("latinName"u8);
                writer.WriteStringValue(LatinName);
            }
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("isHungry"u8);
            writer.WriteBooleanValue(IsHungry);
            writer.WritePropertyName("weight"u8);
            writer.WriteNumberValue(Weight);
            writer.WritePropertyName("hasWhiskers"u8);
            writer.WriteBooleanValue(HasWhiskers);

            if (!options.IgnoreAdditionalProperties)
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

        internal static CatReadOnlyProperty DeserializeCatReadOnlyProperty(JsonElement element, SerializableOptions options)
        {
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
                if (property.NameEquals("hasWhiskers"u8))
                {
                    hasWhiskers = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("isHungry"u8))
                {
                    isHungry = property.Value.GetBoolean();
                    continue;
                }

                if (options.IgnoreAdditionalProperties)
                {
                    //this means its an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new CatReadOnlyProperty(weight, latinName, name, isHungry, hasWhiskers, rawData);
        }
        #endregion

        #region InterfaceImplementation
        public new bool TryDeserialize(Stream stream, out long bytesConsumed, SerializableOptions options = default)
        {
            bytesConsumed = 0;
            try
            {
                JsonDocument jsonDocument = JsonDocument.Parse(stream);
                var model = DeserializeCatReadOnlyProperty(jsonDocument.RootElement, options ?? new SerializableOptions());
                this.Weight = model.Weight;
                this.IsHungry = model.IsHungry;
                this.HasWhiskers = model.HasWhiskers;
                this.IsHungry = model.IsHungry;
                bytesConsumed = stream.Length;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public new bool TrySerialize(Stream stream, out long bytesWritten, SerializableOptions options = default)
        {
            bytesWritten = 0;
            try
            {
                JsonWriterOptions jsonWriterOptions = new JsonWriterOptions();
                if (options.PrettyPrint)
                {
                    jsonWriterOptions.Indented = true;
                }
                Utf8JsonWriter writer = new Utf8JsonWriter(stream, jsonWriterOptions);
                ((IUtf8JsonSerializable)this).Write(writer, options ?? new SerializableOptions());
                writer.Flush();
                bytesWritten = (int)stream.Length;
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
