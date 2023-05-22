// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure;
using Azure.Core.Serialization;
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
        public void CanRoundTripFutureVersionWithoutLoss(bool ignoreReadOnly, bool ignoreUnknown)
        {
            Stream stream = new MemoryStream();
            string serviceResponse =
                "{\"latinName\":\"Animalia\",\"weight\":1.1,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"], \"numberOfLegs\":4}";

            StringBuilder expectedSerialized = new StringBuilder("{");
            if (!ignoreReadOnly)
            {
                expectedSerialized.Append("\"latinName\":\"Animalia\",");
            }
            expectedSerialized.Append("\"name\":\"Doggo\",");
            expectedSerialized.Append("\"isHungry\":false,");
            expectedSerialized.Append("\"weight\":1.1,");
            expectedSerialized.Append("\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"]");
            if (!ignoreUnknown)
            {
                expectedSerialized.Append(",\"numberOfLegs\":4");
            }
            expectedSerialized.Append("}");
            var expectedSerializedString = expectedSerialized.ToString();

            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly, IgnoreAdditionalProperties = ignoreUnknown };

            var model = new DogListProperty();
            model.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), out long bytesConsumed, options: options);

            if (!ignoreReadOnly)
            {
                Assert.That(model.LatinName, Is.EqualTo("Animalia"));
            }
            Assert.That(model.Name, Is.EqualTo("Doggo"));
            Assert.IsFalse(model.IsHungry);
#if NET6_0_OR_GREATER
            Assert.That(model.Weight, Is.EqualTo(1.1));
#endif
            Assert.That(model.FoodConsumed, Is.EqualTo(new List<string> { "kibble", "egg", "peanut butter" }));

            if (!ignoreUnknown)
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

#if NET6_0_OR_GREATER
            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));
            Assert.That(expectedSerialized.Length, Is.EqualTo(bytesWritten));
#endif

            var model2 = new DogListProperty();
            model2.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), out bytesConsumed, options: options);
            VerifyModels.CheckDogs(model, model2, options);
        }

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void CanRoundTripNoTry(bool ignoreReadOnly, bool ignoreUnknown)
        {
            Stream stream = new MemoryStream();
            string serviceResponse =
                "{\"latinName\":\"Animalia\",\"weight\":1.1,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"], \"numberOfLegs\":4}";

            StringBuilder expectedSerialized = new StringBuilder("{");
            if (!ignoreReadOnly)
            {
                expectedSerialized.Append("\"latinName\":\"Animalia\",");
            }
            expectedSerialized.Append("\"name\":\"Doggo\",");
            expectedSerialized.Append("\"isHungry\":false,");
            expectedSerialized.Append("\"weight\":1.1,");
            expectedSerialized.Append("\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"]");
            if (!ignoreUnknown)
            {
                expectedSerialized.Append(",\"numberOfLegs\":4");
            }
            expectedSerialized.Append("}");
            var expectedSerializedString = expectedSerialized.ToString();

            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly, IgnoreAdditionalProperties = ignoreUnknown };

            var model = new DogListProperty();
            model.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);

            if (!ignoreReadOnly)
            {
                Assert.That(model.LatinName, Is.EqualTo("Animalia"));
            }
            Assert.That(model.Name, Is.EqualTo("Doggo"));
            Assert.IsFalse(model.IsHungry);
#if NET6_0_OR_GREATER
            Assert.That(model.Weight, Is.EqualTo(1.1));
#endif
            Assert.That(model.FoodConsumed, Is.EqualTo(new List<string> { "kibble", "egg", "peanut butter" }));

            if (!ignoreUnknown)
            {
                var additionalProperties = typeof(DogListProperty).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(model) as Dictionary<string, BinaryData>;
                Assert.AreEqual(1, additionalProperties.Count);
                Assert.IsTrue(additionalProperties.ContainsKey("numberOfLegs"));
                Assert.IsTrue(additionalProperties["numberOfLegs"].ToString() == "4");
            }

            model.Serialize(stream, options: options);
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();

#if NET6_0_OR_GREATER
            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));
#endif

            var model2 = new DogListProperty();
            model2.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), options: options);
            VerifyModels.CheckDogs(model, model2, options);
        }

        [Test]
        public void PrettyPrint()
        {
#if NET6_0_OR_GREATER
            DogListProperty model = new DogListProperty("Doggo")
            {
                FoodConsumed = { "kibble", "egg", "peanut butter" }
            };

            Stream stream = new MemoryStream();
            model.TrySerialize(stream, out long bytesWritten, options: new SerializableOptions() { IgnoreReadOnlyProperties = true, PrettyPrint = true });
            stream.Position = 0;
            var actualJson = new StreamReader(stream).ReadToEnd();

            var expectedJson = """
                {
                  "name": "Doggo",
                  "isHungry": false,
                  "weight": 1.1,
                  "foodConsumed": [
                    "kibble",
                    "egg",
                    "peanut butter"
                  ]
                }
                """;

            Assert.AreEqual(VerifyModels.NormalizeNewLines(expectedJson), VerifyModels.NormalizeNewLines(actualJson));
#endif
        }
    }
}
