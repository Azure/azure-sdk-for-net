// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using NUnit.Framework;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using Azure.Core.Serialization;
using System;
using System.Text.Json;
using System.Xml;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ModelXmlTests
    {
        private const string _xmlServiceResponse =
                "<Tag>" +
                "<Key>Color</Key>" +
                "<Value>Red</Value>" +
                "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>" +
                "</Tag>";

        private const string _jsonServiceResponse = "{\"key\":\"Color\",\"value\":\"Red\",\"readOnlyProperty\":\"ReadOnly\"}";

        [Test]
        public void RoundTripWithWire() => CanRoundTripFutureVersionWithoutLoss(ModelSerializerFormat.Wire, _xmlServiceResponse);

        [Test]
        public void RoundTripWithJson() => CanRoundTripFutureVersionWithoutLoss(ModelSerializerFormat.Json, _jsonServiceResponse);

        [Test]
        public void ThrowsIfUnknownFormat()
        {
            ModelSerializerOptions options = new ModelSerializerOptions("x");
            Assert.Throws<InvalidOperationException>(() => ModelSerializer.Serialize(new ModelXml(), options));
            Assert.Throws<InvalidOperationException>(() => ModelSerializer.Deserialize<ModelXml>(new BinaryData("x"), options));
        }

        [Test]
        public void ThrowsIfMismatch()
        {
            ModelSerializerOptions jsonOptions = new ModelSerializerOptions(ModelSerializerFormat.Json);
            ModelXml model = ModelSerializer.Deserialize<ModelXml>(new BinaryData(Encoding.UTF8.GetBytes(_jsonServiceResponse)), jsonOptions);

            Assert.Throws(Is.InstanceOf<JsonException>(), () => ModelSerializer.Deserialize<ModelXml>(new BinaryData(Encoding.UTF8.GetBytes(_xmlServiceResponse)), jsonOptions));

            ModelSerializerOptions wireOptions = new ModelSerializerOptions(ModelSerializerFormat.Wire);
            Assert.Throws<XmlException>(() => ModelSerializer.Deserialize<ModelXml>(new BinaryData(Encoding.UTF8.GetBytes(_jsonServiceResponse)), wireOptions));
        }

        private void CanRoundTripFutureVersionWithoutLoss(ModelSerializerFormat format, string serviceResponse)
        {
            ModelSerializerOptions options = new ModelSerializerOptions(format);

            var expectedSerializedString = GetExpectedResult(format);

            ModelXml model = ModelSerializer.Deserialize<ModelXml>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)), options);

            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            var data = ModelSerializer.Serialize(model, options);
            string roundTrip = data.ToString();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            ModelXml model2 = ModelSerializer.Deserialize<ModelXml>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip)), options);
            VerifyModelXml(model, model2, format);
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

        internal static void VerifyModelXml(ModelXml correctModelXml, ModelXml model2, string format)
        {
            Assert.AreEqual(correctModelXml.Key, model2.Key);
            Assert.AreEqual(correctModelXml.Value, model2.Value);
            if (format.Equals(ModelSerializerFormat.Json))
                Assert.AreEqual(correctModelXml.ReadOnlyProperty, model2.ReadOnlyProperty);
        }
    }
}
