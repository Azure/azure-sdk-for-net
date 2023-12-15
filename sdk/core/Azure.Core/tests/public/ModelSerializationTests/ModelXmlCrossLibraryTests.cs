// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using Azure.Core.Serialization;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ModelXmlCrossLibraryTests : ModelJsonTests<ModelXmlCrossLibrary>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ModelXmlX.xml")).TrimEnd();

        protected override string JsonPayload => "{\"key\":\"Color\",\"value\":\"Red\",\"readOnlyProperty\":\"ReadOnly\",\"childTag\":{\"childValue\":\"ChildRed\",\"childReadOnlyProperty\":\"ChildReadOnly\"}}";

        protected override Func<ModelXmlCrossLibrary, RequestContent> ToRequestContent => model => model;

        protected override Func<Response, ModelXmlCrossLibrary> FromResponse => response => (ModelXmlCrossLibrary)response;

        [Test]
        public void ThrowsIfMismatch()
        {
            ModelSerializerOptions jsonOptions = new ModelSerializerOptions(ModelSerializerFormat.Json);
            ModelXmlCrossLibrary model = ModelSerializer.Deserialize<ModelXmlCrossLibrary>(new BinaryData(Encoding.UTF8.GetBytes(JsonPayload)), jsonOptions);

            Assert.Throws(Is.InstanceOf<JsonException>(), () => ModelSerializer.Deserialize<ModelXmlCrossLibrary>(new BinaryData(Encoding.UTF8.GetBytes(WirePayload)), jsonOptions));

            ModelSerializerOptions wireOptions = ModelSerializerOptions.DefaultWireOptions;
            Assert.Throws<XmlException>(() => ModelSerializer.Deserialize<ModelXmlCrossLibrary>(new BinaryData(Encoding.UTF8.GetBytes(JsonPayload)), wireOptions));
        }

        protected override string GetExpectedResult(ModelSerializerFormat format)
        {
            if (format == ModelSerializerFormat.Wire)
            {
                var expectedSerializedString = "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>";
                if (format.Equals(ModelSerializerFormat.Json))
                    expectedSerializedString += "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>";
                expectedSerializedString += "<ChildTag><ChildValue>ChildRed</ChildValue></ChildTag>";
                //TODO this is broken until we update the IXmlSerializable interface to include ModelSerializerOptions
                //if (format.Equals(ModelSerializerFormat.Json))
                //    expectedSerializedString += "<ChildReadOnlyProperty>ChildReadOnly</ChildReadOnlyProperty>";
                expectedSerializedString += "</Tag>";
                return expectedSerializedString;
            }
            if (format == ModelSerializerFormat.Json)
            {
                var expectedSerializedString = "{\"key\":\"Color\",\"value\":\"Red\"";
                if (format.Equals(ModelSerializerFormat.Json))
                    expectedSerializedString += ",\"readOnlyProperty\":\"ReadOnly\"";
                expectedSerializedString += ",\"childTag\":{\"childValue\":\"ChildRed\"";
                if (format.Equals(ModelSerializerFormat.Json))
                    expectedSerializedString += ",\"childReadOnlyProperty\":\"ChildReadOnly\"";
                expectedSerializedString += "}}";
                return expectedSerializedString;
            }
            throw new InvalidOperationException($"Unknown format used in test {format}");
        }

        protected override void VerifyModel(ModelXmlCrossLibrary model, ModelSerializerFormat format)
        {
            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            Assert.IsNotNull(model.ChildModelXml);
            Assert.AreEqual("ChildRed", model.ChildModelXml.ChildValue);
            Assert.AreEqual("ChildReadOnly", model.ChildModelXml.ChildReadOnlyProperty);
        }

        protected override void CompareModels(ModelXmlCrossLibrary model, ModelXmlCrossLibrary model2, ModelSerializerFormat format)
        {
            Assert.AreEqual(model.Key, model2.Key);
            Assert.AreEqual(model.Value, model2.Value);
            if (format.Equals(ModelSerializerFormat.Json))
                Assert.AreEqual(model.ReadOnlyProperty, model2.ReadOnlyProperty);
            Assert.AreEqual(model.ChildModelXml.ChildValue, model2.ChildModelXml.ChildValue);
            //TODO this is broken until we update the IXmlSerializable interface to include ModelSerializerOptions
            //if (format.Equals(ModelSerializerFormat.Data))
            //    Assert.AreEqual(model.RenamedChildModelXml.ChildReadOnlyProperty, model2.RenamedChildModelXml.ChildReadOnlyProperty);
        }
    }
}
