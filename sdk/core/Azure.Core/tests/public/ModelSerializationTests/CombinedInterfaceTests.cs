// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using NUnit.Framework;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using Azure.Core.Serialization;
using System.Collections.Generic;
using System;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class CombinedInterfaceTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void CanRoundTripFutureVersionWithoutLoss(bool ignoreReadOnlyProperties)
        {
            ModelSerializerOptions options = new ModelSerializerOptions();
            options.IgnoreReadOnlyProperties = ignoreReadOnlyProperties;

            Stream stream = new MemoryStream();

            string serviceResponse =
                "<Tag>" +
                "<Key>Color</Key>" +
                "<Value>Red</Value>" +
                "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>" +
                "</Tag>";

            var expectedSerializedString = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>";
            if (!ignoreReadOnlyProperties)
                expectedSerializedString += "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>";
            expectedSerializedString += "</Tag>";

            XmlModelForCombinedInterface model = ModelSerializer.Deserialize<XmlModelForCombinedInterface>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options);

            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            stream = ModelSerializer.Serialize(model, options);
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            XmlModelForCombinedInterface model2 = ModelSerializer.Deserialize<XmlModelForCombinedInterface>(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), options);
            VerifyModelXmlModelForCombinedInterface(model, model2, ignoreReadOnlyProperties);
        }

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void CanRoundTripFutureVersionWithoutLossJson(bool ignoreReadOnlyProperties, bool ignoreAdditionalProperties)
        {
            ModelSerializerOptions options = new ModelSerializerOptions();
            options.IgnoreAdditionalProperties = ignoreAdditionalProperties;
            options.IgnoreReadOnlyProperties = ignoreReadOnlyProperties;

            Stream stream = new MemoryStream();

            string serviceResponse = "{\"key\":\"Color\",\"value\":\"Red\",\"readOnlyProperty\":\"ReadOnly\",\"x\":\"extra\"}";

            var expectedSerializedString = "{\"key\":\"Color\",\"value\":\"Red\"";
            if (!ignoreReadOnlyProperties)
                expectedSerializedString += ",\"readOnlyProperty\":\"ReadOnly\"";
            if (!ignoreAdditionalProperties)
                expectedSerializedString += ",\"x\":\"extra\"";
            expectedSerializedString += "}";

            JsonModelForCombinedInterface model = ModelSerializer.Deserialize<JsonModelForCombinedInterface>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options);

            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            var additionalProperties = typeof(JsonModelForCombinedInterface).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(model) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(!ignoreAdditionalProperties, additionalProperties.ContainsKey("x"));
            stream = ModelSerializer.Serialize(model, options);
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            JsonModelForCombinedInterface model2 = ModelSerializer.Deserialize<JsonModelForCombinedInterface>(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), options);
            VerifyModelJsonModelForCombinedInterface(model, model2, ignoreReadOnlyProperties, ignoreAdditionalProperties);
        }

        internal static void VerifyModelXmlModelForCombinedInterface(XmlModelForCombinedInterface expected, XmlModelForCombinedInterface actual, bool ignoreReadOnlyProperties)
        {
            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Value, actual.Value);
            if (!ignoreReadOnlyProperties)
                Assert.AreEqual(expected.ReadOnlyProperty, actual.ReadOnlyProperty);
        }

        internal static void VerifyModelJsonModelForCombinedInterface(JsonModelForCombinedInterface expected, JsonModelForCombinedInterface actual, bool ignoreReadOnlyProperties, bool ignoreAdditionalProperties)
        {
            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Value, actual.Value);
            if (!ignoreReadOnlyProperties)
                Assert.AreEqual(expected.ReadOnlyProperty, actual.ReadOnlyProperty);
            var rawDataProperty = typeof(JsonModelForCombinedInterface).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var expectedRawData = rawDataProperty.GetValue(expected) as Dictionary<string, BinaryData>;
            var actualRawData = rawDataProperty.GetValue(actual) as Dictionary<string, BinaryData>;
            Assert.AreEqual(expectedRawData.Count, actualRawData.Count);
            if (!ignoreAdditionalProperties)
                Assert.AreEqual(expectedRawData["x"].ToString(), actualRawData["x"].ToString());
        }
    }
}
