// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.Public.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class ModelXmlOnlyTests : ModelTests<ModelXmlOnly>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ModelXml.xml")).TrimEnd();

        protected override string JsonPayload => string.Empty;

        protected override string GetExpectedResult(string format)
        {
            var expectedSerializedString = "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>";
            if (format.Equals("J"))
                expectedSerializedString += "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>";
            expectedSerializedString += "<RenamedChildModelXml><ChildValue>ChildRed</ChildValue></RenamedChildModelXml>";
            expectedSerializedString += "</Tag>";
            return expectedSerializedString;
        }

        protected override void VerifyModel(ModelXmlOnly model, string format)
        {
            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            Assert.IsNotNull(model.RenamedChildModelXml);
            Assert.AreEqual("ChildRed", model.RenamedChildModelXml.ChildValue);
            Assert.AreEqual("ChildReadOnly", model.RenamedChildModelXml.ChildReadOnlyProperty);
        }

        protected override void CompareModels(ModelXmlOnly model, ModelXmlOnly model2, string format)
        {
            Assert.AreEqual(model.Key, model2.Key);
            Assert.AreEqual(model.Value, model2.Value);
            if (format.Equals("J"))
                Assert.AreEqual(model.ReadOnlyProperty, model2.ReadOnlyProperty);
            Assert.AreEqual(model.RenamedChildModelXml.ChildValue, model2.RenamedChildModelXml.ChildValue);
        }
    }
}
