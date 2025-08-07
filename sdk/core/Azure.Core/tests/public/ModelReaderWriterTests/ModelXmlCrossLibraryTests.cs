// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.Public.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class ModelXmlCrossLibraryTests : ModelJsonTests<ModelXmlCrossLibrary>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ModelXmlX.xml")).TrimEnd();

        protected override string JsonPayload => "{\"key\":\"Color\",\"value\":\"Red\",\"readOnlyProperty\":\"ReadOnly\",\"childTag\":{\"childValue\":\"ChildRed\",\"childReadOnlyProperty\":\"ChildReadOnly\"}}";

        [Test]
        public void ThrowsIfMismatch()
        {
            ModelReaderWriterOptions jsonOptions = ModelReaderWriterOptions.Json;
            ModelXmlCrossLibrary model = ModelReaderWriter.Read<ModelXmlCrossLibrary>(new BinaryData(Encoding.UTF8.GetBytes(JsonPayload)), jsonOptions);

            Assert.Throws(Is.InstanceOf<JsonException>(), () => ModelReaderWriter.Read<ModelXmlCrossLibrary>(new BinaryData(Encoding.UTF8.GetBytes(WirePayload)), jsonOptions));

            ModelReaderWriterOptions wireOptions = ModelReaderWriterHelper.WireOptions;
            Assert.Throws<XmlException>(() => ModelReaderWriter.Read<ModelXmlCrossLibrary>(new BinaryData(Encoding.UTF8.GetBytes(JsonPayload)), wireOptions));
        }

        protected override string GetExpectedResult(string format)
        {
            if (format == "W")
            {
                var expectedSerializedString = "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>";
                if (format.Equals("J"))
                    expectedSerializedString += "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>";
                expectedSerializedString += "<ChildTag><ChildValue>ChildRed</ChildValue></ChildTag>";
                expectedSerializedString += "</Tag>";
                return expectedSerializedString;
            }
            if (format == "J")
            {
                var expectedSerializedString = "{\"key\":\"Color\",\"value\":\"Red\"";
                if (format.Equals("J"))
                    expectedSerializedString += ",\"readOnlyProperty\":\"ReadOnly\"";
                expectedSerializedString += ",\"childTag\":{\"childValue\":\"ChildRed\"";
                if (format.Equals("J"))
                    expectedSerializedString += ",\"childReadOnlyProperty\":\"ChildReadOnly\"";
                expectedSerializedString += "}}";
                return expectedSerializedString;
            }
            throw new InvalidOperationException($"Unknown format used in test {format}");
        }

        protected override void VerifyModel(ModelXmlCrossLibrary model, string format)
        {
            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            Assert.IsNotNull(model.ChildModelXml);
            Assert.AreEqual("ChildRed", model.ChildModelXml.ChildValue);
            Assert.AreEqual("ChildReadOnly", model.ChildModelXml.ChildReadOnlyProperty);
        }

        protected override void CompareModels(ModelXmlCrossLibrary model, ModelXmlCrossLibrary model2, string format)
        {
            Assert.AreEqual(model.Key, model2.Key);
            Assert.AreEqual(model.Value, model2.Value);
            if (format.Equals("J"))
                Assert.AreEqual(model.ReadOnlyProperty, model2.ReadOnlyProperty);
            Assert.AreEqual(model.ChildModelXml.ChildValue, model2.ChildModelXml.ChildValue);
        }
    }
}
