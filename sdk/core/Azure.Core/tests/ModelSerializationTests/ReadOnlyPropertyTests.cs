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
    public class ReadOnlyPropertyTests
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
            string serviceResponse = "{\"latinName\":\"Canis lupus familiaris\",\"weight\":5.5,\"name\":\"Doggo\",\"numberOfLegs\":4}";

            StringBuilder expectedSerialized = new StringBuilder("{");
            if (!ignoreReadOnly)
            {
                expectedSerialized.Append("\"latinName\":\"Canis lupus familiaris\",");
            }
            expectedSerialized.Append("\"name\":\"Doggo\",");
            expectedSerialized.Append("\"isHungry\":false,");
            expectedSerialized.Append("\"weight\":5.5");
            if (!ignoreUnknown)
            {
                expectedSerialized.Append(",\"numberOfLegs\":4");
            }
            expectedSerialized.Append("}");
            var expectedSerializedString = expectedSerialized.ToString();

            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly, IgnoreAdditionalProperties = ignoreUnknown };

            var model = new Animal();
            model.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), out long bytesConsumed, options: options);

            if (!ignoreReadOnly)
            {
                Assert.That(model.LatinName, Is.EqualTo("Canis lupus familiaris"));
            }
            Assert.That(model.Name, Is.EqualTo("Doggo"));
            Assert.IsFalse(model.IsHungry);
            Assert.That(model.Weight, Is.EqualTo(5.5));

            if (!ignoreUnknown)
            {
                var additionalProperties = typeof(Animal).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(model) as Dictionary<string, BinaryData>;
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

            var model2 = new Animal();
            model2.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), out bytesConsumed, options: options);

            VerifyModels.CheckAnimals(model, model2, options);
        }

        [Test]
        public void PrettyPrint()
        {
            CatReadOnlyProperty model = new CatReadOnlyProperty(3.2, "Felis catus", "Catto", true, false);

            Stream stream = new MemoryStream();
            model.TrySerialize(stream, out long bytesWritten, options: new SerializableOptions() { PrettyPrint = true });;
            stream.Position = 0;
            var actualJson = new StreamReader(stream).ReadToEnd();

            var expectedJson = """
                {
                  "latinName": "Felis catus",
                  "hasWhiskers": false,
                  "name": "Catto",
                  "isHungry": true,
                  "weight": 3.2
                }
                """;

            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
