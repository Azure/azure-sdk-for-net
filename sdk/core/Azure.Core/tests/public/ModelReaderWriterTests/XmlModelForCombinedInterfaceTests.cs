// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        protected override string GetExpectedResult(string format)
        {
            if (format == "W")
            {
                var expectedSerializedString = "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>";
                if (format.Equals("J"))
                    expectedSerializedString += "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>";
                expectedSerializedString += "</Tag>";
                return expectedSerializedString;
            }
            if (format == "J")
            {
                var expectedSerializedString = "{\"key\":\"Color\",\"value\":\"Red\"";
                if (format.Equals("J"))
                    expectedSerializedString += ",\"readOnlyProperty\":\"ReadOnly\"";
                expectedSerializedString += "}";
                return expectedSerializedString;
            }
            throw new InvalidOperationException($"Unknown format used in test {format}");
        }

        protected override void VerifyModel(XmlModelForCombinedInterface model, string format)
        {
            Assert.Multiple(() =>
            {
                Assert.That(model.Key, Is.EqualTo("Color"));
                Assert.That(model.Value, Is.EqualTo("Red"));
            });
            if (format.Equals("J"))
                Assert.That(model.ReadOnlyProperty, Is.EqualTo("ReadOnly"));
        }

        protected override void CompareModels(XmlModelForCombinedInterface model, XmlModelForCombinedInterface model2, string format)
        {
            Assert.Multiple(() =>
            {
                Assert.That(model2.Key, Is.EqualTo(model.Key));
                Assert.That(model2.Value, Is.EqualTo(model.Value));
            });
            if (format.Equals("J"))
                Assert.That(model2.ReadOnlyProperty, Is.EqualTo(model.ReadOnlyProperty));
        }
    }
}
