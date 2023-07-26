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
        private const string _xmlServiceResponse =
        "<Tag>" +
        "<Key>Color</Key>" +
        "<Value>Red</Value>" +
        "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>" +
        "</Tag>";

        private const string _jsonServiceResponse = "{\"key\":\"Color\",\"value\":\"Red\",\"readOnlyProperty\":\"ReadOnly\"}";

        [Test]
        public void RoundTripXmlModelWithWire() => CanRoundTripFutureVersionWithoutLossXml(ModelSerializerFormat.Wire, _xmlServiceResponse);

        [Test]
        public void RoundTripXmlModelWithJson() => CanRoundTripFutureVersionWithoutLossXml(ModelSerializerFormat.Json, _jsonServiceResponse);

        private void CanRoundTripFutureVersionWithoutLossXml(ModelSerializerFormat format, string serviceResponse)
        {
            ModelSerializerOptions options = new ModelSerializerOptions(format);

            var expectedSerializedString = GetExpectedResult(format);

            XmlModelForCombinedInterface model = ModelSerializer.Deserialize<XmlModelForCombinedInterface>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)), options);

            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            var data = ModelSerializer.Serialize(model, options);
            string roundTrip = data.ToString();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            XmlModelForCombinedInterface model2 = ModelSerializer.Deserialize<XmlModelForCombinedInterface>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip)), options);
            VerifyModelXmlModelForCombinedInterface(model, model2, format);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void CanRoundTripFutureVersionWithoutLossJson(string format)
        {
            ModelSerializerOptions options = new ModelSerializerOptions(format);

            string serviceResponse = "{\"key\":\"Color\",\"value\":\"Red\",\"readOnlyProperty\":\"ReadOnly\",\"x\":\"extra\"}";

            var expectedSerializedString = "{\"key\":\"Color\",\"value\":\"Red\"";
            if (format == ModelSerializerFormat.Json)
            {
                expectedSerializedString += ",\"readOnlyProperty\":\"ReadOnly\"";
                expectedSerializedString += ",\"x\":\"extra\"";
            }
            expectedSerializedString += "}";

            JsonModelForCombinedInterface model = ModelSerializer.Deserialize<JsonModelForCombinedInterface>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)), options);

            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            var additionalProperties = typeof(JsonModelForCombinedInterface).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(model) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.AreEqual(format == ModelSerializerFormat.Json, additionalProperties.ContainsKey("x"));
            var data = ModelSerializer.Serialize(model, options);
            string roundTrip = data.ToString();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            JsonModelForCombinedInterface model2 = ModelSerializer.Deserialize<JsonModelForCombinedInterface>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip)), options);
            VerifyModelJsonModelForCombinedInterface(model, model2, format);
        }

        internal static void VerifyModelXmlModelForCombinedInterface(XmlModelForCombinedInterface expected, XmlModelForCombinedInterface actual, ModelSerializerFormat format)
        {
            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Value, actual.Value);
            if (format.Equals(ModelSerializerFormat.Json))
                Assert.AreEqual(expected.ReadOnlyProperty, actual.ReadOnlyProperty);
        }

        internal static void VerifyModelJsonModelForCombinedInterface(JsonModelForCombinedInterface expected, JsonModelForCombinedInterface actual, ModelSerializerFormat format)
        {
            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Value, actual.Value);
            if (format.Equals(ModelSerializerFormat.Json))
                Assert.AreEqual(expected.ReadOnlyProperty, actual.ReadOnlyProperty);
            var rawDataProperty = typeof(JsonModelForCombinedInterface).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var expectedRawData = rawDataProperty.GetValue(expected) as Dictionary<string, BinaryData>;
            var actualRawData = rawDataProperty.GetValue(actual) as Dictionary<string, BinaryData>;
            Assert.AreEqual(expectedRawData.Count, actualRawData.Count);
            if (format.Equals(ModelSerializerFormat.Json))
                Assert.AreEqual(expectedRawData["x"].ToString(), actualRawData["x"].ToString());
        }

        private string GetExpectedResult(ModelSerializerFormat format)
        {
            if (format == ModelSerializerFormat.Wire)
            {
                var expectedSerializedString = "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>";
                if (format.Equals(ModelSerializerFormat.Json))
                    expectedSerializedString += "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>";
                expectedSerializedString += "</Tag>";
                return expectedSerializedString;
            }
            if (format == ModelSerializerFormat.Json)
            {
                var expectedSerializedString = "{\"key\":\"Color\",\"value\":\"Red\"";
                if (format.Equals(ModelSerializerFormat.Json))
                    expectedSerializedString += ",\"readOnlyProperty\":\"ReadOnly\"";
                expectedSerializedString += "}";
                return expectedSerializedString;
            }
            throw new InvalidOperationException($"Unknown format used in test {format}");
        }
    }
}
