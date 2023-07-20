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

            string serviceResponse =
                "<Tag>"+
                "<Key>Color</Key>"+
                "<Value>Red</Value>"+
                "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>" +
                "<RenamedChildModelXml><ChildValue>ChildRed</ChildValue><ChildReadOnlyProperty>ChildReadOnly</ChildReadOnlyProperty></RenamedChildModelXml>" +
                "</Tag>";

            var expectedSerializedString = "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>";
            if (format.Equals(ModelSerializerFormat.Data))
                expectedSerializedString += "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>";
            expectedSerializedString += "<RenamedChildModelXml><ChildValue>ChildRed</ChildValue>";
            //TODO this is broken until we update the IXmlSerializable interface to include ModelSerializerOptions
            //if (format.Equals(ModelSerializerFormat.Data))
            //    expectedSerializedString += "<ChildReadOnlyProperty>ChildReadOnly</ChildReadOnlyProperty>";
            expectedSerializedString += "</RenamedChildModelXml></Tag>";

            ModelXml model = ModelSerializer.Deserialize<ModelXml>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)), options);

            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            Assert.IsNotNull(model.RenamedChildModelXml);
            Assert.AreEqual("ChildRed", model.RenamedChildModelXml.ChildValue);
            Assert.AreEqual("ChildReadOnly", model.RenamedChildModelXml.ChildReadOnlyProperty);
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
            Assert.AreEqual(correctModelXml.RenamedChildModelXml.ChildValue, model2.RenamedChildModelXml.ChildValue);
            //TODO this is broken until we update the IXmlSerializable interface to include ModelSerializerOptions
            //if (format.Equals(ModelSerializerFormat.Data))
            //    Assert.AreEqual(correctModelXml.RenamedChildModelXml.ChildReadOnlyProperty, model2.RenamedChildModelXml.ChildReadOnlyProperty);
        }

        [TestCase("D")]
        [TestCase("W")]
        public void UsingChildAsRootUsingDefaultName(string format)
        {
            ModelSerializerOptions options = new ModelSerializerOptions(format);

            string serviceResponse =
                "<ChildTag><ChildValue>ChildRed</ChildValue><ChildReadOnlyProperty>ChildReadOnly</ChildReadOnlyProperty></ChildTag>";

            var expectedSerializedString = "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><ChildTag><ChildValue>ChildRed</ChildValue>";
            if (format.Equals(ModelSerializerFormat.Data))
                expectedSerializedString += "<ChildReadOnlyProperty>ChildReadOnly</ChildReadOnlyProperty>";
            expectedSerializedString += "</ChildTag>";

            ChildModelXml model = ModelSerializer.Deserialize<ChildModelXml>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)), options);

            Assert.AreEqual("ChildRed", model.ChildValue);
            Assert.AreEqual("ChildReadOnly", model.ChildReadOnlyProperty);
            var data = ModelSerializer.Serialize(model, options);
            string roundTrip = data.ToString();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            ChildModelXml model2 = ModelSerializer.Deserialize<ChildModelXml>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip)), options);
            VerifyChildModelXml(model, model2, format);
        }

        internal static void VerifyChildModelXml(ChildModelXml model1, ChildModelXml model2, string format)
        {
            Assert.AreEqual(model1.ChildValue, model2.ChildValue);
            if (format.Equals(ModelSerializerFormat.Data))
                Assert.AreEqual(model1.ChildReadOnlyProperty, model2.ChildReadOnlyProperty);
        }
    }
}
