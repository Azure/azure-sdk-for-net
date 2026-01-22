// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core.Tests.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class UnknownBaseModelTests : ModelJsonTests<BaseModel>
    {
        protected override BaseModel GetModelInstance()
        {
            var typeToActivate = typeof(BaseModel).Assembly.GetTypes().FirstOrDefault(t => t.Name == $"Unknown{typeof(BaseModel).Name}");
            return Activator.CreateInstance(typeToActivate, true) as BaseModel;
        }

        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"kind\":\"Z\",\"name\":\"zmodel\",\"zProperty\":1.5,\"extra\":\"stuff\"}";

        protected override void CompareModels(BaseModel model, BaseModel model2, string format)
        {
            Assert.That(model.GetType().Name, Is.EqualTo("UnknownBaseModel"));
            Assert.That(model2.GetType().Name, Is.EqualTo("UnknownBaseModel"));
            Assert.That(model.Kind, Is.EqualTo(model2.Kind));
            Assert.That(model.Name, Is.EqualTo(model2.Name));
            var rawData = GetRawData(model);
            var rawData2 = GetRawData(model2);
            Assert.That(rawData, Is.Not.Null);
            Assert.That(rawData2, Is.Not.Null);
            if (format == "J")
            {
                Assert.That(rawData.Count, Is.EqualTo(rawData2.Count));
                Assert.That(rawData["zProperty"].ToObjectFromJson<double>(), Is.EqualTo(rawData2["zProperty"].ToObjectFromJson<double>()));
                Assert.That(rawData["extra"].ToObjectFromJson<string>(), Is.EqualTo(rawData2["extra"].ToObjectFromJson<string>()));
            }
        }

        protected override string GetExpectedResult(string format)
        {
            string expected = "{\"kind\":\"Z\",\"name\":\"zmodel\"";
            if (format == "J")
                expected += ",\"zProperty\":1.5,\"extra\":\"stuff\"";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(BaseModel model, string format)
        {
            Assert.That(model.GetType().Name, Is.EqualTo("UnknownBaseModel"));
            Assert.That(model.Kind, Is.EqualTo("Z"));
            Assert.That(model.Name, Is.EqualTo("zmodel"));
            var rawData = GetRawData(model);
            Assert.That(rawData, Is.Not.Null);
            if (format == "J")
            {
                Assert.That(rawData["zProperty"].ToObjectFromJson<double>(), Is.EqualTo(1.5));
                Assert.That(rawData["extra"].ToObjectFromJson<string>(), Is.EqualTo("stuff"));
            }
        }
    }
}
