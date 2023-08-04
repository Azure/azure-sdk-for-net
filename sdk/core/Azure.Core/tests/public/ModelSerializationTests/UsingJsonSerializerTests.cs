// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public class UsingJsonSerializerTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SerializeTest(bool ignoreReadonlyProperties)
        {
            string expected = "{";
            expected += "\"name\":\"Doggo\",\"isHungry\":false,";
#if NETFRAMEWORK
            expected += "\"weight\":1.1000000000000001,";
#else
            expected += "\"weight\":1.1,";
#endif
            expected += "\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"]}";
            var dog = new DogListProperty
            {
                Name = "Doggo",
                IsHungry = false,
                Weight = 1.1,
                FoodConsumed = { "kibble", "egg", "peanut butter" },
            };
            var options = new JsonSerializerOptions()
            {
                IgnoreReadOnlyProperties = ignoreReadonlyProperties
            };
            var actual = JsonSerializer.Serialize(dog, options);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void DeserializeTest(bool ignoreReadonlyProperties)
        {
            string serviceResponse = "{\"latinName\":\"Animalia\",\"weight\":1.1,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";

            var options = new JsonSerializerOptions()
            {
                IgnoreReadOnlyProperties = ignoreReadonlyProperties
            };
            var dog = JsonSerializer.Deserialize<DogListProperty>(serviceResponse, options);

            Assert.AreEqual("Doggo", dog.Name);
            Assert.AreEqual(false, dog.IsHungry);
            Assert.AreEqual(1.1, dog.Weight);
            CollectionAssert.AreEquivalent(new List<string> { "kibble", "egg", "peanut butter" }, dog.FoodConsumed);
            Assert.AreEqual("Animalia", dog.LatinName);

            var additionalProperties = typeof(Animal).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(dog) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.IsFalse(additionalProperties.ContainsKey("numberOfLegs"));

            string expected = "{";
            expected += "\"name\":\"Doggo\",\"isHungry\":false,";
#if NETFRAMEWORK
            expected += "\"weight\":1.1000000000000001,";
#else
            expected += "\"weight\":1.1,";
#endif
            expected += "\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"]}";

            var actual = JsonSerializer.Serialize(dog, options);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void CanSerializeTwoModelsWithSameConverter(string format)
        {
            string modelYResponse = "{\"kind\":\"Y\",\"name\":\"ymodel\",\"yProperty\":\"100\",\"extra\":\"stuff\"}";
            string modelXResponse = "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

            var options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(format));
            ModelY modelY = JsonSerializer.Deserialize<ModelY>(modelYResponse, options);

            Assert.AreEqual("Y", modelY.Kind);
            Assert.AreEqual("ymodel", modelY.Name);
            if (format == ModelSerializerFormat.Json)
                Assert.AreEqual("100", modelY.YProperty);

            var additionalProperties = typeof(ModelY).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(modelY) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            if (format == ModelSerializerFormat.Json)
                Assert.AreEqual("stuff", additionalProperties["extra"].ToObjectFromJson<string>());

            string expectedModelY = "{";
            expectedModelY += "\"kind\":\"Y\",\"name\":\"ymodel\"";
            if (format == ModelSerializerFormat.Json)
                expectedModelY += ",\"yProperty\":\"100\",\"extra\":\"stuff\"";
            expectedModelY += "}";

            var actualModelY = JsonSerializer.Serialize(modelY, options);
            Assert.AreEqual(expectedModelY, actualModelY);

            ModelX modelX = JsonSerializer.Deserialize<ModelX>(modelXResponse, options);

            Assert.AreEqual("X", modelX.Kind);
            Assert.AreEqual("xmodel", modelX.Name);
            if (format == ModelSerializerFormat.Json)
                Assert.AreEqual(100, modelX.XProperty);

            additionalProperties = typeof(ModelX).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(modelX) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            if (format == ModelSerializerFormat.Json)
                Assert.AreEqual("stuff", additionalProperties["extra"].ToObjectFromJson<string>());

            string expectedModelX = "{";
            expectedModelX += "\"kind\":\"X\"";
            expectedModelX += ",\"name\":\"xmodel\"";
            if (format == ModelSerializerFormat.Json)
                expectedModelX += ",\"xProperty\":100";
            if (format == ModelSerializerFormat.Json)
                expectedModelX += ",\"extra\":\"stuff\"";
            expectedModelX += "}";

            var actualModelX = JsonSerializer.Serialize(modelX, options);
            Assert.AreEqual(expectedModelX, actualModelX);
        }
    }
}
