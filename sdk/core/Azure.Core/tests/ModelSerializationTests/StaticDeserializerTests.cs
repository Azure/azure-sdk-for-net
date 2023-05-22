﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class StaticDeserializerTests
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
                "{\"latinName\":\"Animalia\",\"weight\":2.3,\"name\":\"Rabbit\",\"isHungry\":false,\"numberOfLegs\":4}";

            StringBuilder expectedSerialized = new StringBuilder("{");
            if (!ignoreReadOnly)
            {
                expectedSerialized.Append("\"latinName\":\"Animalia\",");
            }
            expectedSerialized.Append("\"name\":\"Rabbit\",");
            expectedSerialized.Append("\"isHungry\":false,");
            expectedSerialized.Append("\"weight\":2.3");
            if (!ignoreUnknown)
            {
                expectedSerialized.Append(",\"numberOfLegs\":4");
            }
            expectedSerialized.Append("}");
            var expectedSerializedString = expectedSerialized.ToString();

            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly, IgnoreAdditionalProperties = ignoreUnknown };

            var model = Animal.StaticDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);

            if (!ignoreReadOnly)
            {
                Assert.That(model.LatinName, Is.EqualTo("Animalia"));
            }
            Assert.That(model.Name, Is.EqualTo("Rabbit"));
            Assert.IsFalse(model.IsHungry);
#if NET6_0_OR_GREATER
            Assert.That(model.Weight, Is.EqualTo(2.3));
#endif

            if (!ignoreUnknown)
            {
                var additionalProperties = typeof(Animal).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(model) as Dictionary<string, BinaryData>;
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

            var model2 = Animal.StaticDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), options: options);
            VerifyModels.CheckAnimals(model, model2, options);
        }
    }
}
