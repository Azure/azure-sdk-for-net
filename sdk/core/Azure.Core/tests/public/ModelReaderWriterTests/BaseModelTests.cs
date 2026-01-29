// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core.Tests.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class BaseModelTests : ModelJsonTests<BaseModel>
    {
        protected override BaseModel GetModelInstance()
        {
            var typeToActivate = typeof(BaseModel).Assembly.GetTypes().FirstOrDefault(t => t.Name == $"Unknown{typeof(BaseModel).Name}");
            return Activator.CreateInstance(typeToActivate, true) as BaseModel;
        }

        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

        protected override void CompareModels(BaseModel model, BaseModel model2, string format)
        {
            Assert.That(model2.Name, Is.EqualTo(model.Name));
            Assert.That(model2.Kind, Is.EqualTo(model.Kind));
            if (format == "J")
            {
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
            if (format == "J")
                expected += ",\"xProperty\":100";
            if (format == "J")
                expected += ",\"extra\":\"stuff\"";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(BaseModel model, string format)
        {
            Assert.That(model.Kind, Is.EqualTo("X"));
            Assert.That(model.Name, Is.EqualTo("xmodel"));
            var rawData = GetRawData(model);
            Assert.That(rawData, Is.Not.Null);
            if (format == "J")
            {
                Assert.That(rawData["extra"].ToObjectFromJson<string>(), Is.EqualTo("stuff"));
            }
        }
    }
}
