// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public class ModelJsonConverterTests
    {
        [TestCase(ModelSerializerOptions.Format.Data)]
        [TestCase(ModelSerializerOptions.Format.Wire)]
        public void SerializeTest(string format)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(format));

            string expected = "{";
            if (format == ModelSerializerOptions.Format.Data.ToString())
                expected += "\"latinName\":\"Animalia\",";
            expected += "\"name\":\"Doggo\",\"isHungry\":false,";
            expected += "\"weight\":1.5,";
            expected += "\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"]}";
            var dog = new DogListProperty
            {
                Name = "Doggo",
                IsHungry = false,
                Weight = 1.5,
                FoodConsumed = { "kibble", "egg", "peanut butter" },
            };
            var actual = JsonSerializer.Serialize(dog, options);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(ModelSerializerOptions.Format.Data)]
        [TestCase(ModelSerializerOptions.Format.Wire)]
        public void DeserializeTest(string format)
        {
            string serviceResponse = "{\"latinName\":\"Animalia\",\"weight\":1.5,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(format));

            var dog = JsonSerializer.Deserialize<DogListProperty>(serviceResponse, options);

            Assert.AreEqual("Doggo", dog.Name);
            Assert.AreEqual(false, dog.IsHungry);
            Assert.AreEqual(1.5, dog.Weight);
            CollectionAssert.AreEquivalent(new List<string> { "kibble", "egg", "peanut butter" }, dog.FoodConsumed);
            Assert.AreEqual("Animalia", dog.LatinName);

            var additionalProperties = typeof(Animal).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(dog) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(format == ModelSerializerOptions.Format.Data.ToString(), additionalProperties.ContainsKey("numberOfLegs"));
            if (format == ModelSerializerOptions.Format.Data.ToString())
                Assert.AreEqual("4", additionalProperties["numberOfLegs"].ToString());

            string expected = "{";
            if (format == ModelSerializerOptions.Format.Data.ToString())
                expected += "\"latinName\":\"Animalia\",";
            expected += "\"name\":\"Doggo\",\"isHungry\":false,";
            expected += "\"weight\":1.5,";
            expected += "\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"]";
            if (format == ModelSerializerOptions.Format.Data.ToString())
            {
                expected += ",\"numberOfLegs\":4,\"DogListPropertyConverterMarker\":true"; //validate marker exists to ensure we are using the class converter if it exists
            }
            expected += "}";

            var actual = JsonSerializer.Serialize(dog, options);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UsesMoreConcreteConverter()
        {
            string serviceResponse = "{\"latinName\":\"Animalia\",\"weight\":1.5,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter());
            options.Converters.Add(new DogListPropertyBlankConverter());

            //the more concrete converter should be used so we will validate the default values are used
            var dog = JsonSerializer.Deserialize<DogListProperty>(serviceResponse, options);

            var additionalProperties = typeof(Animal).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(dog) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            //since this falls back to the converter defined on DogListProperty it will use the default behavior and ignore additional properties
            Assert.IsFalse(additionalProperties.ContainsKey("DogListPropertyConverterMarker"));

            var actual = JsonSerializer.Serialize(dog, options);
            Assert.AreEqual("", actual);
        }

        [TestCase(ModelSerializerOptions.Format.Data)]
        [TestCase(ModelSerializerOptions.Format.Wire)]
        public void CanSerializeDerivedModel(string format)
        {
            string serviceResponse = "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(format));

            var modelX = JsonSerializer.Deserialize<ModelX>(serviceResponse, options);
            Assert.AreEqual("xmodel", modelX.Name);
            Assert.AreEqual(100, modelX.XProperty);
            Assert.AreEqual("X", modelX.Kind);
            var additionalProperties = typeof(ModelX).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(modelX) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(format == ModelSerializerOptions.Format.Data.ToString(), additionalProperties.ContainsKey("extra"));
            if (format == ModelSerializerOptions.Format.Data.ToString())
                Assert.AreEqual("\"stuff\"", additionalProperties["extra"].ToString());

            string expected = "{\"kind\":\"X\",\"name\":\"xmodel\"";
            if (format == ModelSerializerOptions.Format.Data.ToString())
                expected += ",\"xProperty\":100";
            if (format == ModelSerializerOptions.Format.Data.ToString())
                expected += ",\"extra\":\"stuff\"";
            expected += "}";
            var actual = JsonSerializer.Serialize(modelX, options);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(ModelSerializerOptions.Format.Data)]
        [TestCase(ModelSerializerOptions.Format.Wire)]
        public void CanSerializeBaseModel(string format)
        {
            string serviceResponse = "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(format));

            var baseModel = JsonSerializer.Deserialize<BaseModel>(serviceResponse, options);
            var modelX = baseModel as ModelX;
            Assert.IsNotNull(modelX);
            Assert.AreEqual("xmodel", modelX.Name);
            Assert.AreEqual(100, modelX.XProperty);
            Assert.AreEqual("X", modelX.Kind);
            var additionalProperties = typeof(ModelX).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(modelX) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(format == ModelSerializerOptions.Format.Data.ToString(), additionalProperties.ContainsKey("extra"));
            if (format == ModelSerializerOptions.Format.Data.ToString())
                Assert.AreEqual("\"stuff\"", additionalProperties["extra"].ToString());

            string expected = "{\"kind\":\"X\",\"name\":\"xmodel\"";
            if (format == ModelSerializerOptions.Format.Data.ToString())
            {
                expected += ",\"xProperty\":100";
                expected += ",\"extra\":\"stuff\"";
            }
            expected += "}";
            var actual = JsonSerializer.Serialize(baseModel, options);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(ModelSerializerOptions.Format.Data)]
        [TestCase(ModelSerializerOptions.Format.Wire)]
        public void CanSerializeUnknown(string format)
        {
            string serviceResponse = "{\"kind\":\"Z\",\"name\":\"zmodel\",\"zProperty\":1.5,\"extra\":\"stuff\"}";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(format));

            var baseModel = JsonSerializer.Deserialize<BaseModel>(serviceResponse, options);
            var unknownBaseModel = baseModel as UnknownBaseModel;
            Assert.IsNotNull(unknownBaseModel);
            Assert.AreEqual("zmodel", baseModel.Name);
            Assert.AreEqual("Z", baseModel.Kind);
            var additionalProperties = typeof(UnknownBaseModel).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(baseModel) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(format == ModelSerializerOptions.Format.Data.ToString(), additionalProperties.ContainsKey("extra"));
            Assert.AreEqual(format == ModelSerializerOptions.Format.Data.ToString(), additionalProperties.ContainsKey("zProperty"));
            if (format == ModelSerializerOptions.Format.Data.ToString())
            {
                Assert.AreEqual("\"stuff\"", additionalProperties["extra"].ToString());
                Assert.AreEqual("1.5", additionalProperties["zProperty"].ToString());
            }

            string expected = "{\"kind\":\"Z\",\"name\":\"zmodel\"";
            if (format == ModelSerializerOptions.Format.Data.ToString())
            {
                expected += ",\"zProperty\":1.5";
                expected += ",\"extra\":\"stuff\"";
            }
            expected += "}";
            var actual = JsonSerializer.Serialize(baseModel, options);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldThrowIfWrongDiscriminatorType()
        {
        }
    }
}
