// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Core.Tests.ModelSerializationTests
{
    public class Animal : ISerializable, IUtf8JsonSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public bool IsHungry { get; set; } = false;
        public double Weight { get; set; } = 0;
        public readonly string LatinName = "Animalia";
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

        private string AnimalLatinName;
        private bool AnimalIsHungry;
        private double AnimalWeight;
        private string AnimalName;

        #region Serialization
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (options.SerializeReadonlyProperties)
            {
                writer.WritePropertyName("LatinName"u8);
                writer.WriteStringValue(LatinName);
            }
            writer.WritePropertyName("IsHungry"u8);
            writer.WriteBooleanValue(IsHungry);
            writer.WritePropertyName("Weight"u8);
            writer.WriteNumberValue(Weight);
            writer.WritePropertyName("Name"u8);
            writer.WriteStringValue(Name);

            if (options.HandleUnknownElements)
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
                if (property.NameEquals("Weight"u8))
                {
                    weight = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("Name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("LatinName"u8))
                {
                    latinName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("IsHungry"u8))
                {
                    isHungry = property.Value.GetBoolean();
                    continue;
                }

                if (options.HandleUnknownElements)
                {
                    //this means its an unknown property we got
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
                JsonDocument jsonDocument = JsonDocument.Parse(stream);
                var model = DeserializeAnimal(jsonDocument.RootElement, options ?? new SerializableOptions());
                this.AnimalLatinName = model.LatinName;
                this.AnimalWeight = model.Weight;
                this.AnimalIsHungry = model.IsHungry;
                this.AnimalName = model.Name;
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
                JsonWriterOptions jsonWriterOptions = new JsonWriterOptions();
                if (options.PrettyPrint)
                {
                    jsonWriterOptions.Indented = true;
                }
                Utf8JsonWriter writer = new Utf8JsonWriter(stream, jsonWriterOptions);
                ((IUtf8JsonSerializable)this).Write(writer, options ?? new SerializableOptions());
                writer.Flush();
                bytesWritten = stream.Length;
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
