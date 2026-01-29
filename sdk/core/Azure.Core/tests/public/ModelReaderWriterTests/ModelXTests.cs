// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class ModelXTests : ModelJsonTests<ModelX>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ModelX/ModelXWireFormat.json")).TrimEnd();

        protected override void CompareModels(ModelX model, ModelX model2, string format)
        {
            Assert.That(model.Name, Is.EqualTo(model2.Name));
            Assert.That(model.Kind, Is.EqualTo(model2.Kind));

            Assert.That(model.Fields, Is.EqualTo(model2.Fields));
            Assert.That(model.KeyValuePairs, Is.EqualTo(model2.KeyValuePairs));
            Assert.That(model.NullProperty, Is.EqualTo(model2.NullProperty));

            if (format == "J")
            {
                Assert.That(model.XProperty, Is.EqualTo(model2.XProperty));
                var rawData = GetRawData(model);
                var rawData2 = GetRawData(model2);
                Assert.That(rawData, Is.Not.Null);
                Assert.That(rawData2, Is.Not.Null);
                Assert.That(rawData.Count, Is.EqualTo(rawData2.Count));
                Assert.That(rawData["extra"].ToObjectFromJson<string>(), Is.EqualTo(rawData2["extra"].ToObjectFromJson<string>()));
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
            Assert.That(model.NullProperty, Is.Null);

            var rawData = GetRawData(model);
            Assert.That(rawData, Is.Not.Null);
            if (format == "J")
            {
                Assert.That(model.XProperty, Is.EqualTo(100));
                Assert.That(rawData["extra"].ToObjectFromJson<string>(), Is.EqualTo("stuff"));
            }
        }
    }
}
