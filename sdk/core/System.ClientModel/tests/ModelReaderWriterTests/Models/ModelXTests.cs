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
            Assert.That(model2.Name, Is.EqualTo(model.Name));
            Assert.That(model2.Kind, Is.EqualTo(model.Kind));

            Assert.That(model2.Fields, Is.EqualTo(model.Fields));
            Assert.That(model2.KeyValuePairs, Is.EqualTo(model.KeyValuePairs));
            Assert.That(model2.NullProperty, Is.EqualTo(model.NullProperty));

            if (format == "J")
            {
                Assert.That(model2.XProperty, Is.EqualTo(model.XProperty));
                var rawData = GetRawData(model);
                var rawData2 = GetRawData(model2);
                Assert.IsNotNull(rawData);
                Assert.IsNotNull(rawData2);
                Assert.That(rawData2.Count, Is.EqualTo(rawData.Count));
                Assert.That(rawData2["extra"].ToObjectFromJson<string>(), Is.EqualTo(rawData["extra"].ToObjectFromJson<string>()));
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
            Assert.That(model.Kind, Is.EqualTo("X"));
            Assert.That(model.Name, Is.EqualTo("xmodel"));

            Assert.That(model.Fields.Count, Is.EqualTo(1));
            Assert.That(model.Fields[0], Is.EqualTo("testField"));
            Assert.That(model.KeyValuePairs.Count, Is.EqualTo(1));
            Assert.That(model.KeyValuePairs["color"], Is.EqualTo("red"));
            Assert.IsNull(model.NullProperty);

            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == "J")
            {
                Assert.That(model.XProperty, Is.EqualTo(100));
                Assert.That(rawData["extra"].ToObjectFromJson<string>(), Is.EqualTo("stuff"));
            }
        }
    }
}
