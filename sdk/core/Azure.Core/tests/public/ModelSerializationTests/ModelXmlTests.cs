// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using NUnit.Framework;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using Azure.Core.Serialization;
using System;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ModelXmlTests
    {
        [TestCase("D")]
        [TestCase("W")]
        public void CanRoundTripFutureVersionWithoutLoss(string format)
        {
            ModelSerializerOptions options = new ModelSerializerOptions(format);

            Stream stream = new MemoryStream();

            string serviceResponse =
                "<Tag>"+
                "<Key>Color</Key>"+
                "<Value>Red</Value>"+
                "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>" +
                "</Tag>";

            var expectedSerializedString = "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>";
            if (format.Equals(ModelSerializerFormat.Data))
                expectedSerializedString += "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>";
            expectedSerializedString += "</Tag>";

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

        internal static void VerifyModelXml(ModelXml correctModelXml, ModelXml model2, string format)
        {
            Assert.AreEqual(correctModelXml.Key, model2.Key);
            Assert.AreEqual(correctModelXml.Value, model2.Value);
            if (format.Equals(ModelSerializerFormat.Data))
                Assert.AreEqual(correctModelXml.ReadOnlyProperty, model2.ReadOnlyProperty);
        }
    }
}
