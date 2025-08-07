// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.IO;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class ModelXTests : ModelJsonTests<ModelX>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ModelX/ModelXWireFormat.json")).TrimEnd();

        protected override ModelReaderWriterContext Context => new TestClientModelReaderWriterContext();

        protected override void CompareModels(ModelX model, ModelX model2, string format)
        {
            Assert.AreEqual(model.Name, model2.Name);
            Assert.AreEqual(model.Kind, model2.Kind);

            Assert.AreEqual(model.Fields, model2.Fields);
            Assert.AreEqual(model.KeyValuePairs, model2.KeyValuePairs);
            Assert.AreEqual(model.NullProperty, model2.NullProperty);

            if (format == "J")
            {
                Assert.AreEqual(model.XProperty, model2.XProperty);
                var rawData = GetRawData(model);
                var rawData2 = GetRawData(model2);
                Assert.IsNotNull(rawData);
                Assert.IsNotNull(rawData2);
                Assert.AreEqual(rawData.Count, rawData2.Count);
                Assert.AreEqual(rawData["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
            }
        }

        protected override string GetExpectedResult(string format)
        {
            string expected = "{\"kind\":\"X\",\"name\":\"xmodel\"";
            expected += ",\"fields\":[\"testField\"]";
            expected += ",\"keyValuePairs\":{\"color\":\"red\"}";
            if (format == "J")
                expected += ",\"xProperty\":100";
            if (format == "J")
                expected += ",\"extra\":\"stuff\"";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(ModelX model, string format)
        {
            Assert.AreEqual("X", model.Kind);
            Assert.AreEqual("xmodel", model.Name);

            Assert.AreEqual(1, model.Fields.Count);
            Assert.AreEqual("testField", model.Fields[0]);
            Assert.AreEqual(1, model.KeyValuePairs.Count);
            Assert.AreEqual("red", model.KeyValuePairs["color"]);
            Assert.IsNull(model.NullProperty);

            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == "J")
            {
                Assert.AreEqual(100, model.XProperty);
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
            }
        }
    }
}
