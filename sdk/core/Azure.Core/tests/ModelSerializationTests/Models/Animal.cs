﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.ModelSerializationTests
{
    public class Animal : IJsonSerializable, IUtf8JsonSerializable, IModelInternalSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public bool IsHungry { get; set; } = false;
        public double Weight { get; set; } = 1.1d;
        public string LatinName { get; private set; } = "Animalia";
        public string Name { get; set; } = "Animal";

        public Animal()
        {
        }

        public Animal(double weight, string latinName, string name, bool isHungry)
        {
            Weight = weight;
            LatinName = latinName;
            Name = name;
            IsHungry = isHungry;
        }

        internal Animal(double weight, string latinName, string name, bool isHungry, Dictionary<string, BinaryData> rawData)
        {
            Weight = weight;
            LatinName = latinName;
            Name = name;
            IsHungry = isHungry;
            RawData = rawData;
        }

        internal Animal(string name)
        {
            Name = name;
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

        internal static Animal DeserializeAnimal(JsonElement element, SerializableOptions options)
        {
            double weight = default;
            string name = "";
            string latinName = "";
            bool isHungry = default;

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

                if (!options.IgnoreAdditionalProperties)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new Animal(weight, latinName, name, isHungry, rawData);
        }
        #endregion

        #region InterfaceImplementation
        public bool TryDeserialize(Stream stream, out long bytesConsumed, SerializableOptions options = default)
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

        public bool TrySerialize(Stream stream, out long bytesWritten, SerializableOptions options = default)
        {
            bytesWritten = 0;
            try
            {
                Serialize(stream, options);
                bytesWritten = stream.Length;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Deserialize(Stream stream, SerializableOptions options = default)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(stream);
            var model = DeserializeAnimal(jsonDocument.RootElement, options ?? new SerializableOptions());
            CopyModel(model);
        }

        private void CopyModel(Animal model)
        {
            this.LatinName = model.LatinName;
            this.Weight = model.Weight;
            this.IsHungry = model.IsHungry;
            this.Name = model.Name;
            this.RawData = model.RawData;
        }

        public void Serialize(Stream stream, SerializableOptions options = default)
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

        #region PublicStaticDeserializer
        public static Animal StaticDeserialize(Stream stream, SerializableOptions options = default)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(stream);
            return DeserializeAnimal(jsonDocument.RootElement, options ?? new SerializableOptions());
        }

        void IModelInternalSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            ((IUtf8JsonSerializable)this).Write(writer, options ?? new SerializableOptions());
        }

        void IModelInternalSerializable.Deserialize(ref Utf8JsonReader reader, SerializableOptions options)
        {
            var model = DeserializeAnimal(JsonDocument.ParseValue(ref reader).RootElement, options);
            CopyModel(model);
        }
        #endregion
    }
}
