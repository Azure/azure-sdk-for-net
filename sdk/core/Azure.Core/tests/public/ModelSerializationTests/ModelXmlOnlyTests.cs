// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Serialization;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ModelXmlOnlyTests : ModelTests<ModelXmlOnly>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ModelXml.xml")).TrimEnd();

        protected override string JsonPayload => string.Empty;

        protected override Func<ModelXmlOnly, RequestContent> ToRequestContent => model => model;

        protected override Func<Response, ModelXmlOnly> FromResponse => response => (ModelXmlOnly)response;

        protected override string GetExpectedResult(ModelSerializerFormat format)
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

        protected override void VerifyModel(ModelXmlOnly model, ModelSerializerFormat format)
        {
            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            Assert.IsNotNull(model.RenamedChildModelXml);
            Assert.AreEqual("ChildRed", model.RenamedChildModelXml.ChildValue);
            Assert.AreEqual("ChildReadOnly", model.RenamedChildModelXml.ChildReadOnlyProperty);
        }

        protected override void CompareModels(ModelXmlOnly model, ModelXmlOnly model2, ModelSerializerFormat format)
        {
            Assert.AreEqual(model.Key, model2.Key);
            Assert.AreEqual(model.Value, model2.Value);
            if (format.Equals(ModelSerializerFormat.Json))
                Assert.AreEqual(model.ReadOnlyProperty, model2.ReadOnlyProperty);
            Assert.AreEqual(model.RenamedChildModelXml.ChildValue, model2.RenamedChildModelXml.ChildValue);
            //TODO this is broken until we update the IXmlSerializable interface to include ModelSerializerOptions
            //if (format.Equals(ModelSerializerFormat.Json))
            //    Assert.AreEqual(model.RenamedChildModelXml.ChildReadOnlyProperty, model2.RenamedChildModelXml.ChildReadOnlyProperty);
        }
    }
}
