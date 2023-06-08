// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.ModelSerializationTests
{
    [JsonConverter(typeof(DogListPropertyConverter))]
    public class DogListProperty : Animal, IModelSerializable, IModelInternalSerializable, IUtf8JsonSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();
        public IList<string> FoodConsumed { get; private set; }

        public DogListProperty(string name) : base(name)
        {
            Name = name;
            FoodConsumed = new ChangeTrackingList<string>();
        }

        internal DogListProperty(double weight, string latinName, string name, bool isHungry, IList<string> foodConsumed, Dictionary<string, BinaryData> rawData) : base(weight, latinName, name, isHungry, rawData)
        {
            RawData = rawData;
            FoodConsumed = foodConsumed;
        }

        public DogListProperty()
        {
            FoodConsumed = new ChangeTrackingList<string>();
        }

        public static explicit operator DogListProperty(Response response)
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(response.ContentStream);
            var serializationOptions = new SerializableOptions()
            {
                IgnoreReadOnlyProperties = false,
                IgnoreAdditionalProperties = false
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

            if (Optional.IsCollectionDefined(FoodConsumed))
            {
                writer.WritePropertyName("foodConsumed"u8);
                writer.WriteStartArray();
                foreach (var item in FoodConsumed)
                {
                    writer.WriteStringValue($"{item}");
                }
                writer.WriteEndArray();
            }

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

        internal class DogListPropertyConverter : JsonConverter<DogListProperty>
        {
            public override DogListProperty Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var model = DeserializeDogListProperty(JsonDocument.ParseValue(ref reader).RootElement, ConvertOptions(options));
                //marker used for testing to know if this converter fires
                model.RawData.Add("DogListPropertyConverterMarker", new BinaryData("true"));
                return model;
            }

            public override void Write(Utf8JsonWriter writer, DogListProperty value, JsonSerializerOptions options)
            {
                ((IUtf8JsonSerializable)value).Write(writer, ConvertOptions(options));
            }

            private SerializableOptions ConvertOptions(JsonSerializerOptions options)
            {
                var serializableOptions = new SerializableOptions();
                //pulls the additional properties setting from the ModelJsonConverter if it exists
                //if it does not exist it uses the default value of true for azure sdk use cases
                var modelConverter = options.Converters.FirstOrDefault(c=>c.GetType() == typeof(ModelJsonConverter)) as ModelJsonConverter;
                serializableOptions.IgnoreAdditionalProperties = modelConverter is not null ? modelConverter.IgnoreAdditionalProperties : true;
                serializableOptions.IgnoreReadOnlyProperties = options.IgnoreReadOnlyProperties;
                return serializableOptions;
            }
        }
    }
}
