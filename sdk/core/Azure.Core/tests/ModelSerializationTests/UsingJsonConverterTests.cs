// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerializationTests
{
    public class UsingJsonConverterTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SerializeTest(bool ignoreReadonlyProperties)
        {
            string expected = "{";
            if (!ignoreReadonlyProperties)
                expected += "\"latinName\":\"Animalia\",";
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
            Assert.IsTrue(additionalProperties.ContainsKey("numberOfLegs"));
            Assert.AreEqual("4", additionalProperties["numberOfLegs"].ToString());

            string expected = "{";
            if (!ignoreReadonlyProperties)
                expected += "\"latinName\":\"Animalia\",";
            expected += "\"name\":\"Doggo\",\"isHungry\":false,";
#if NETFRAMEWORK
            expected += "\"weight\":1.1000000000000001,";
#else
            expected += "\"weight\":1.1,";
#endif
            expected += "\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";

            var actual = JsonSerializer.Serialize(dog, options);
            Assert.AreEqual(expected, actual);
        }
    }
}
