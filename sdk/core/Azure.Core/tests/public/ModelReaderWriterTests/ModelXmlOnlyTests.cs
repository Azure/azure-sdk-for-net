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
            Assert.That(model.Key, Is.EqualTo("Color"));
            Assert.That(model.Value, Is.EqualTo("Red"));
            Assert.That(model.ReadOnlyProperty, Is.EqualTo("ReadOnly"));
            Assert.That(model.RenamedChildModelXml, Is.Not.Null);
            Assert.That(model.RenamedChildModelXml.ChildValue, Is.EqualTo("ChildRed"));
            Assert.That(model.RenamedChildModelXml.ChildReadOnlyProperty, Is.EqualTo("ChildReadOnly"));
        }

        protected override void CompareModels(ModelXmlOnly model, ModelXmlOnly model2, string format)
        {
            Assert.That(model.Key, Is.EqualTo(model2.Key));
            Assert.That(model.Value, Is.EqualTo(model2.Value));
            if (format.Equals("J"))
                Assert.That(model.ReadOnlyProperty, Is.EqualTo(model2.ReadOnlyProperty));
            Assert.That(model.RenamedChildModelXml.ChildValue, Is.EqualTo(model2.RenamedChildModelXml.ChildValue));
        }
    }
}
