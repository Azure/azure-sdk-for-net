// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Linq;
#if SOURCE_GENERATOR
using System.ClientModel.SourceGeneration.Tests;
#else
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
#endif
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class UnknownBaseModelTests : ModelJsonTests<BaseModel>
    {
        protected override BaseModel GetModelInstance()
        {
            var typeToActivate = typeof(BaseModel).Assembly.GetTypes().FirstOrDefault(t => t.Name == $"Unknown{typeof(BaseModel).Name}") ?? throw new InvalidOperationException("Unable to find BaseModel type");
            return Activator.CreateInstance(typeToActivate, true) as BaseModel ?? throw new InvalidOperationException($"Unable to create model instance of BaseModel");
        }

        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"kind\":\"Z\",\"name\":\"zmodel\",\"zProperty\":1.5,\"extra\":\"stuff\"}";

#if SOURCE_GENERATOR
        protected override ModelReaderWriterContext Context => BasicContext.Default;
#else
        protected override ModelReaderWriterContext Context => new TestClientModelReaderWriterContext();
#endif

        protected override void CompareModels(BaseModel model, BaseModel model2, string format)
        {
            Assert.That(model.GetType().Name, Is.EqualTo("UnknownBaseModel"));
            Assert.That(model2.GetType().Name, Is.EqualTo("UnknownBaseModel"));
            Assert.That(model2.Kind, Is.EqualTo(model.Kind));
            Assert.That(model2.Name, Is.EqualTo(model.Name));
            var rawData = GetRawData(model);
            var rawData2 = GetRawData(model2);
            Assert.That(rawData, Is.Not.Null);
            Assert.That(rawData2, Is.Not.Null);
            if (format == "J")
            {
                Assert.That(rawData2.Count, Is.EqualTo(rawData.Count));
                Assert.That(rawData2["zProperty"].ToObjectFromJson<double>(), Is.EqualTo(rawData["zProperty"].ToObjectFromJson<double>()));
                Assert.That(rawData2["extra"].ToObjectFromJson<string>(), Is.EqualTo(rawData["extra"].ToObjectFromJson<string>()));
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
