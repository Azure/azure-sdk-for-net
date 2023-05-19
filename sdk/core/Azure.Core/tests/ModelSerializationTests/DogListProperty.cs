// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.Core.Tests.ModelSerializationTests
{
    public class DogListProperty : Animal, IJsonSerializable, IUtf8JsonSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();
        public List<string> FoodConsumed { get; set; } = new List<string> {"kibble", "egg", "peanut butter"};

        public DogListProperty(string name) : base(name)
        {
            Name = name;
        }

        internal DogListProperty(double weight, string latinName, string name, bool isHungry, List<string> foodConsumed, Dictionary<string, BinaryData> rawData) : base(weight, latinName, name, isHungry, rawData)
        {
            RawData = rawData;
            FoodConsumed = foodConsumed;
        }

        public DogListProperty()
        {
        }

        public static explicit operator DogListProperty(Response response)
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(response.ContentStream);
            var serializationOptions = new SerializableOptions()
            {
                IgnoreReadOnlyProperties = true,
                IgnoreAdditionalProperties = true
            };
            return DeserializeDogListProperty(jsonDocument.RootElement, serializationOptions);
        }

        public static explicit operator RequestContent(DogListProperty dog)
        {
            var content = new Utf8JsonRequestContent();
            //content.JsonWriter.WriteObjectValue(dog);
            //temp implementation due to IUtf8JsonSerializable signature mismatch since we added an options parameter
            ((IUtf8JsonSerializable)dog).Write(content.JsonWriter, new SerializableOptions());
            return content;
        }

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

            writer.WritePropertyName("foodConsumed"u8);
            writer.WriteStartArray();
            foreach (var item in FoodConsumed)
            {
                writer.WriteStringValue($"{item}");
            }
            writer.WriteEndArray();

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

        internal static DogListProperty DeserializeDogListProperty(JsonElement element, SerializableOptions options)
        {
            double weight = default;
            string name = "";
            string latinName = "";
            bool isHungry = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            List<string> foodConsumed = new List<string>();

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
                if (property.NameEquals("foodConsumed"u8))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        foodConsumed.Add(item.GetString());
                    }
                    continue;
                }
                if (!options.IgnoreAdditionalProperties)
                {
                    //this means its an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new DogListProperty(weight, latinName, name, isHungry, foodConsumed, rawData);
        }
        #endregion

        #region InterfaceImplementation
        public new bool TryDeserialize(Stream stream, out long bytesConsumed, SerializableOptions options = default)
        {
            bytesConsumed = 0;
            try
            {
                Deserialize(stream, options);
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
                Serialize(stream, options);
                bytesWritten = (int)stream.Length;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public new void Deserialize(Stream stream, SerializableOptions options = default)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(stream);
            var model = DeserializeDogListProperty(jsonDocument.RootElement, options ?? new SerializableOptions());
            this.Name = model.Name;
            this.Weight = model.Weight;
            this.IsHungry = model.IsHungry;
            this.FoodConsumed = model.FoodConsumed;
            this.RawData = model.RawData;
        }

        public new void Serialize(Stream stream, SerializableOptions options = default)
        {
            JsonWriterOptions jsonWriterOptions = new JsonWriterOptions();
            if (options.PrettyPrint)
            {
                jsonWriterOptions.Indented = true;
            }
            Utf8JsonWriter writer = new Utf8JsonWriter(stream, jsonWriterOptions);
            ((IUtf8JsonSerializable)this).Write(writer, options ?? new SerializableOptions());
            writer.Flush();
        }
        #endregion
    }
}
