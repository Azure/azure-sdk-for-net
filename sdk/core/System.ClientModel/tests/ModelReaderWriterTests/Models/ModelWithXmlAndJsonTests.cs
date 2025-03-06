// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using NUnit.Framework;
using System.IO;
using System.ClientModel.Tests.Client;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class ModelWithXmlAndJsonTests : StreamableModelTests<ModelWithXmlAndJson>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ModelWithXmlAndJson/ModelWithXmlAndJson.xml")).TrimEnd();

        protected override string JsonPayload => File.ReadAllText(TestData.GetLocation("ModelWithXmlAndJson/ModelWithXmlAndJson.json")).TrimEnd();
        protected override ModelReaderWriterContext Context => new TestClientModelReaderWriterContext();

        protected override void CompareModels(ModelWithXmlAndJson model, ModelWithXmlAndJson model2, string format)
        {
            Assert.AreEqual(model.Key, model2.Key);
            Assert.AreEqual(model.Value, model2.Value);
            Assert.AreEqual(model.ReadOnlyProperty, model2.ReadOnlyProperty);

            var rawData1 = GetRawData(model);
            Assert.IsNotNull(rawData1);
            var rawData2 = GetRawData(model2);
            Assert.IsNotNull(rawData2);

            if (format != "W")
            {
                Assert.AreEqual(rawData1["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
            }
        }

        protected override string GetExpectedResult(string format)
        {
            if (format == "W")
            {
                return "\uFEFF<?xml version=\"1.0\" encoding=\"utf-8\"?><Tag><Key>Color</Key><Value>Red</Value>"
                    + "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty></Tag>";
            }

            if (format == "J")
            {
                return "{\"key\":\"Color\",\"value\":\"Red\"" + ",\"readOnlyProperty\":\"ReadOnly\",\"extra\":\"stuff\"}";
            }
            throw new InvalidOperationException($"Unknown format used in test {format}");
        }

        protected override void VerifyModel(ModelWithXmlAndJson model, string format)
        {
            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);

            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);

            if (format != "W")
            {
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
            }
        }
    }
}
