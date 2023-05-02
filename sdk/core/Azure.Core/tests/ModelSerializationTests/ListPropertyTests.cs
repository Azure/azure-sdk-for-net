// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure;
using Azure.Core.Tests;
using Azure.Core.Tests.ModelSerializationTests;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerializationTests
{
    public class ListPropertyTests
    {
        private readonly SerializableOptions _wireOptions = new SerializableOptions { IgnoreReadOnlyProperties = false };
        private readonly SerializableOptions _objectOptions = new SerializableOptions();

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void CanRoundTripFutureVersionWithoutLoss(bool includeReadonly, bool handleUnknown)
        {
            Stream stream = new MemoryStream();
            string serviceResponse =
                "{\"latinName\":\"Animalia\",\"weight\":1.1,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"], \"numberOfLegs\":4}";

            StringBuilder expectedSerialized = new StringBuilder("{");
            if (includeReadonly)
            {
                expectedSerialized.Append("\"latinName\":\"Animalia\",");
            }
            expectedSerialized.Append("\"name\":\"Doggo\",");
            expectedSerialized.Append("\"isHungry\":false,");
            expectedSerialized.Append("\"weight\":1.1,");
            expectedSerialized.Append("\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"]");
            if (handleUnknown)
            {
                expectedSerialized.Append(",\"numberOfLegs\":4");
            }
            expectedSerialized.Append("}");
            var expectedSerializedString = expectedSerialized.ToString();

            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = includeReadonly, IgnoreAdditionalProperties = handleUnknown };

            var model = new DogListProperty();
            model.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), out long bytesConsumed, options: options);

            if (includeReadonly)
            {
                Assert.That(model.LatinName, Is.EqualTo("Animalia"));
            }
            Assert.That(model.Name, Is.EqualTo("Doggo"));
            Assert.IsFalse(model.IsHungry);
            Assert.That(model.Weight, Is.EqualTo(1.1));
            Assert.That(model.FoodConsumed, Is.EqualTo(new List<string> { "kibble", "egg", "peanut butter" }));

            if (handleUnknown)
            {
                var additionalProperties = typeof(DogListProperty).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(model) as Dictionary<string, BinaryData>;
                Assert.AreEqual(1, additionalProperties.Count);
                Assert.IsTrue(additionalProperties.ContainsKey("numberOfLegs"));
                Assert.IsTrue(additionalProperties["numberOfLegs"].ToString() == "4");
            }
            Assert.That(serviceResponse.Length, Is.EqualTo(bytesConsumed));
            model.TrySerialize(stream, out var bytesWritten, options: options);
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();
            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));
            Assert.That(expectedSerialized.Length, Is.EqualTo(bytesWritten));

            var model2 = new DogListProperty();
            model2.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), out bytesConsumed, options: options);

            if (includeReadonly)
                Assert.That(model.LatinName, Is.EqualTo(model2.LatinName));
            Assert.That(model.Name, Is.EqualTo(model2.Name));
            Assert.That(model.Weight, Is.EqualTo(model2.Weight));
            Assert.That(roundTrip.Length, Is.EqualTo(bytesConsumed));
            Assert.That(model.FoodConsumed, Is.EqualTo(model2.FoodConsumed));
            if (handleUnknown)
            {
                var additionalProperties1 = typeof(DogListProperty).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(model) as Dictionary<string, BinaryData>;
                var additionalProperties2 = typeof(DogListProperty).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(model2) as Dictionary<string, BinaryData>;

                Assert.AreEqual(1, additionalProperties1.Count);
                Assert.IsTrue(additionalProperties1.ContainsKey("numberOfLegs"));
                Assert.IsTrue(additionalProperties1["numberOfLegs"].ToString() == "4");
                Assert.AreEqual(1, additionalProperties2.Count);
                Assert.IsTrue(additionalProperties2.ContainsKey("numberOfLegs"));
                Assert.IsTrue(additionalProperties2["numberOfLegs"].ToString() == "4");
            }
        }

        [Test]
        public void PrettyPrint()
        {
            DogListProperty model = new DogListProperty("Doggo");

            Stream stream = new MemoryStream();
            model.TrySerialize(stream, out long bytesWritten, options: new SerializableOptions() { PrettyPrint = true });
            stream.Position = 0;
            var actualJson = new StreamReader(stream).ReadToEnd();

            var expectedJson = "{\r\n  \"name\": \"Doggo\",\r\n  \"isHungry\": false,\r\n  \"weight\": 1.1,\r\n  \"foodConsumed\": [\r\n    \"kibble\",\r\n    \"egg\",\r\n    \"peanut butter\"\r\n  ]\r\n}";

            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
