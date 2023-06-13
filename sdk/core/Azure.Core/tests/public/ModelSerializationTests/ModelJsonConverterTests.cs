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
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void SerializeTest(bool ignoreReadonlyProperties, bool ignoreAdditionalProperties)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(ignoreAdditionalProperties));
            options.IgnoreReadOnlyProperties = ignoreReadonlyProperties;

            string expected = "{";
            if (!ignoreReadonlyProperties)
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

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void DeserializeTest(bool ignoreReadonlyProperties, bool ignoreAdditionalProperties)
        {
            string serviceResponse = "{\"latinName\":\"Animalia\",\"weight\":1.5,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(ignoreAdditionalProperties));
            options.IgnoreReadOnlyProperties = ignoreReadonlyProperties;

            var dog = JsonSerializer.Deserialize<DogListProperty>(serviceResponse, options);

            Assert.AreEqual("Doggo", dog.Name);
            Assert.AreEqual(false, dog.IsHungry);
            Assert.AreEqual(1.5, dog.Weight);
            CollectionAssert.AreEquivalent(new List<string> { "kibble", "egg", "peanut butter" }, dog.FoodConsumed);
            Assert.AreEqual("Animalia", dog.LatinName);

            var additionalProperties = typeof(Animal).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(dog) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(!ignoreAdditionalProperties, additionalProperties.ContainsKey("numberOfLegs"));
            if (!ignoreAdditionalProperties)
                Assert.AreEqual("4", additionalProperties["numberOfLegs"].ToString());

            string expected = "{";
            if (!ignoreReadonlyProperties)
                expected += "\"latinName\":\"Animalia\",";
            expected += "\"name\":\"Doggo\",\"isHungry\":false,";
            expected += "\"weight\":1.5,";
            expected += "\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"]";
            if (!ignoreAdditionalProperties)
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
            options.Converters.Add(new ModelJsonConverter(false));
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

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void CanSerializeDerivedModel(bool ignoreReadonlyProperties, bool ignoreAdditionalProperties)
        {
            string serviceResponse = "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreReadOnlyProperties = ignoreReadonlyProperties;
            options.Converters.Add(new ModelJsonConverter(ignoreAdditionalProperties));

            var modelX = JsonSerializer.Deserialize<ModelX>(serviceResponse, options);
            Assert.AreEqual("xmodel", modelX.Name);
            Assert.AreEqual(100, modelX.XProperty);
            Assert.AreEqual("X", modelX.Kind);
            var additionalProperties = typeof(ModelX).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(modelX) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(!ignoreAdditionalProperties, additionalProperties.ContainsKey("extra"));
            if (!ignoreAdditionalProperties)
                Assert.AreEqual("\"stuff\"", additionalProperties["extra"].ToString());

            string expected = "{\"kind\":\"X\",\"name\":\"xmodel\"";
            if (!ignoreReadonlyProperties)
                expected += ",\"xProperty\":100";
            if (!ignoreAdditionalProperties)
                expected += ",\"extra\":\"stuff\"";
            expected += "}";
            var actual = JsonSerializer.Serialize(modelX, options);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void CanSerializeBaseModel(bool ignoreReadonlyProperties, bool ignoreAdditionalProperties)
        {
            string serviceResponse = "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreReadOnlyProperties = ignoreReadonlyProperties;
            options.Converters.Add(new ModelJsonConverter(ignoreAdditionalProperties));

            var baseModel = JsonSerializer.Deserialize<BaseModel>(serviceResponse, options);
            var modelX = baseModel as ModelX;
            Assert.IsNotNull(modelX);
            Assert.AreEqual("xmodel", modelX.Name);
            Assert.AreEqual(100, modelX.XProperty);
            Assert.AreEqual("X", modelX.Kind);
            var additionalProperties = typeof(ModelX).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(modelX) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(!ignoreAdditionalProperties, additionalProperties.ContainsKey("extra"));
            if (!ignoreAdditionalProperties)
                Assert.AreEqual("\"stuff\"", additionalProperties["extra"].ToString());

            string expected = "{\"kind\":\"X\",\"name\":\"xmodel\"";
            if (!ignoreReadonlyProperties)
                expected += ",\"xProperty\":100";
            if (!ignoreAdditionalProperties)
                expected += ",\"extra\":\"stuff\"";
            expected += "}";
            var actual = JsonSerializer.Serialize(baseModel, options);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void CanSerializeUnknown(bool ignoreReadonlyProperties, bool ignoreAdditionalProperties)
        {
            string serviceResponse = "{\"kind\":\"Z\",\"name\":\"zmodel\",\"zProperty\":1.5,\"extra\":\"stuff\"}";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreReadOnlyProperties = ignoreReadonlyProperties;
            options.Converters.Add(new ModelJsonConverter(ignoreAdditionalProperties));

            var baseModel = JsonSerializer.Deserialize<BaseModel>(serviceResponse, options);
            var unknownBaseModel = baseModel as UnknownBaseModel;
            Assert.IsNotNull(unknownBaseModel);
            Assert.AreEqual("zmodel", baseModel.Name);
            Assert.AreEqual("Z", baseModel.Kind);
            var additionalProperties = typeof(UnknownBaseModel).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(baseModel) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(!ignoreAdditionalProperties, additionalProperties.ContainsKey("extra"));
            Assert.AreEqual(!ignoreAdditionalProperties, additionalProperties.ContainsKey("zProperty"));
            if (!ignoreAdditionalProperties)
            {
                Assert.AreEqual("\"stuff\"", additionalProperties["extra"].ToString());
                Assert.AreEqual("1.5", additionalProperties["zProperty"].ToString());
            }

            string expected = "{\"kind\":\"Z\",\"name\":\"zmodel\"";
            if (!ignoreAdditionalProperties)
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
