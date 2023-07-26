﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using NUnit.Framework;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using Azure.Core.Serialization;
using System;
using System.Text.Json;
using System.Xml;
using System.Reflection;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ModelXmlTests : ModelTests<ModelXml>
    {
        protected override string WirePayload => File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "ModelSerializationTests", "TestData", "ModelXml.xml")).TrimEnd();

        protected override string JsonPayload => "{\"key\":\"Color\",\"value\":\"Red\",\"readOnlyProperty\":\"ReadOnly\",\"renamedChildModelXml\":{\"childValue\":\"ChildRed\",\"childReadOnlyProperty\":\"ChildReadOnly\"}}";

        protected override Func<ModelXml, RequestContent> ToRequestContent => model => model;

        protected override Func<Response, ModelXml> FromResponse => response => (ModelXml)response;

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
            ModelXml model = ModelSerializer.Deserialize<ModelXml>(new BinaryData(Encoding.UTF8.GetBytes(JsonPayload)), jsonOptions);

            Assert.Throws(Is.InstanceOf<JsonException>(), () => ModelSerializer.Deserialize<ModelXml>(new BinaryData(Encoding.UTF8.GetBytes(WirePayload)), jsonOptions));

            ModelSerializerOptions wireOptions = new ModelSerializerOptions(ModelSerializerFormat.Wire);
            Assert.Throws<XmlException>(() => ModelSerializer.Deserialize<ModelXml>(new BinaryData(Encoding.UTF8.GetBytes(JsonPayload)), wireOptions));
        }

        protected override string GetExpectedResult(ModelSerializerFormat format)
        {
            if (format == ModelSerializerFormat.Wire)
            {
                var expectedSerializedString = "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>";
                if (format.Equals(ModelSerializerFormat.Json))
                    expectedSerializedString += "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>";
                expectedSerializedString += "<RenamedChildModelXml><ChildValue>ChildRed</ChildValue></RenamedChildModelXml>";
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
                expectedSerializedString += ",\"renamedChildModelXml\":{\"childValue\":\"ChildRed\"";
                //TODO this is broken until we update the IXmlSerializable interface to include ModelSerializerOptions
                //if (format.Equals(ModelSerializerFormat.Json))
                //    expectedSerializedString += ",\"childReadOnlyProperty\":\"ChildReadOnly\"";
                expectedSerializedString += "}}";
                return expectedSerializedString;
            }
            throw new InvalidOperationException($"Unknown format used in test {format}");
        }

        protected override void VerifyModel(ModelXml model, ModelSerializerFormat format)
        {
            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            Assert.IsNotNull(model.RenamedChildModelXml);
            Assert.AreEqual("ChildRed", model.RenamedChildModelXml.ChildValue);
            Assert.AreEqual("ChildReadOnly", model.RenamedChildModelXml.ChildReadOnlyProperty);
        }

        protected override void CompareModels(ModelXml model, ModelXml model2, ModelSerializerFormat format)
        {
            Assert.AreEqual(model.Key, model2.Key);
            Assert.AreEqual(model.Value, model2.Value);
            if (format.Equals(ModelSerializerFormat.Json))
                Assert.AreEqual(model.ReadOnlyProperty, model2.ReadOnlyProperty);
            Assert.AreEqual(model.RenamedChildModelXml.ChildValue, model2.RenamedChildModelXml.ChildValue);
            //TODO this is broken until we update the IXmlSerializable interface to include ModelSerializerOptions
            //if (format.Equals(ModelSerializerFormat.Data))
            //    Assert.AreEqual(model.RenamedChildModelXml.ChildReadOnlyProperty, model2.RenamedChildModelXml.ChildReadOnlyProperty);
        }
    }
}
