// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel.Core.Content;
using Azure.Core.Tests.Public.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class XmlModelForCombinedInterfaceTests : ModelJsonTests<XmlModelForCombinedInterface>
    {
        protected override string JsonPayload => "{\"key\":\"Color\",\"value\":\"Red\",\"readOnlyProperty\":\"ReadOnly\"}";

        protected override string WirePayload => "<Tag>" +
        "<Key>Color</Key>" +
        "<Value>Red</Value>" +
        "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>" +
        "</Tag>";

        protected override Func<XmlModelForCombinedInterface, RequestContent> ToRequestContent => model => model;

        protected override Func<Response, XmlModelForCombinedInterface> FromResponse => response => (XmlModelForCombinedInterface)response;

        protected override string GetExpectedResult(ModelReaderWriterFormat format)
        {
            if (format == ModelReaderWriterFormat.Wire)
            {
                var expectedSerializedString = "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>";
                if (format.Equals(ModelReaderWriterFormat.Json))
                    expectedSerializedString += "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>";
                expectedSerializedString += "</Tag>";
                return expectedSerializedString;
            }
            if (format == ModelReaderWriterFormat.Json)
            {
                var expectedSerializedString = "{\"key\":\"Color\",\"value\":\"Red\"";
                if (format.Equals(ModelReaderWriterFormat.Json))
                    expectedSerializedString += ",\"readOnlyProperty\":\"ReadOnly\"";
                expectedSerializedString += "}";
                return expectedSerializedString;
            }
            throw new InvalidOperationException($"Unknown format used in test {format}");
        }

        protected override void VerifyModel(XmlModelForCombinedInterface model, ModelReaderWriterFormat format)
        {
            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            if (format.Equals(ModelReaderWriterFormat.Json))
                Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
        }

        protected override void CompareModels(XmlModelForCombinedInterface model, XmlModelForCombinedInterface model2, ModelReaderWriterFormat format)
        {
            Assert.AreEqual(model.Key, model2.Key);
            Assert.AreEqual(model.Value, model2.Value);
            if (format.Equals(ModelReaderWriterFormat.Json))
                Assert.AreEqual(model.ReadOnlyProperty, model2.ReadOnlyProperty);
        }
    }
}
