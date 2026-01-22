// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class ModelAsStructTests : ModelJsonTests<ModelAsStruct>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"id\":5,\"extra\":\"stuff\"}";

        protected override ModelReaderWriterContext Context => new TestClientModelReaderWriterContext();

        protected override void CompareModels(ModelAsStruct model, ModelAsStruct model2, string format)
        {
            Assert.That(model2.Id, Is.EqualTo(model.Id));
            var rawData1 = GetRawData(model);
            var rawData2 = GetRawData(model2);
            Assert.That(rawData1, Is.Not.Null);
            Assert.That(rawData2, Is.Not.Null);
            if (format == "J")
                Assert.That(rawData2["extra"].ToObjectFromJson<string>(), Is.EqualTo(rawData1["extra"].ToObjectFromJson<string>()));
        }

        protected override string GetExpectedResult(string format)
        {
            string expected = "{\"id\":5";
            if (format == "J")
                expected += ",\"extra\":\"stuff\"";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(ModelAsStruct model, string format)
        {
            Assert.That(model.Id, Is.EqualTo(5));
            var rawData = GetRawData(model);
            Assert.That(rawData, Is.Not.Null);
            if (format == "J")
                Assert.That(rawData["extra"].ToObjectFromJson<string>(), Is.EqualTo("stuff"));
        }
    }
}
