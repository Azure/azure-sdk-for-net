// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerializationTests
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
                expected += ",\"numberOfLegs\":4";
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
            Assert.AreEqual("Animal", dog.Name);
            Assert.AreEqual(false, dog.IsHungry);
            Assert.AreEqual(1.1d, dog.Weight);
            CollectionAssert.AreEquivalent(new List<string>(), dog.FoodConsumed);
            Assert.AreEqual("Animalia", dog.LatinName);

            var additionalProperties = typeof(Animal).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(dog) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(0, additionalProperties.Count);

            var actual = JsonSerializer.Serialize(dog, options);
            Assert.AreEqual("", actual);
        }
    }
}
