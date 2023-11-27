// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Linq;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;

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

        protected override void CompareModels(BaseModel model, BaseModel model2, string format)
        {
            Assert.AreEqual("UnknownBaseModel", model.GetType().Name);
            Assert.AreEqual("UnknownBaseModel", model2.GetType().Name);
            Assert.AreEqual(model.Kind, model2.Kind);
            Assert.AreEqual(model.Name, model2.Name);
            var rawData = GetRawData(model);
            var rawData2 = GetRawData(model2);
            Assert.IsNotNull(rawData);
            Assert.IsNotNull(rawData2);
            if (format == "J")
            {
                Assert.AreEqual(rawData.Count, rawData2.Count);
                Assert.AreEqual(rawData["zProperty"].ToObjectFromJson<double>(), rawData2["zProperty"].ToObjectFromJson<double>());
                Assert.AreEqual(rawData["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
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
            Assert.AreEqual("UnknownBaseModel", model.GetType().Name);
            Assert.AreEqual("Z", model.Kind);
            Assert.AreEqual("zmodel", model.Name);
            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == "J")
            {
                Assert.AreEqual(1.5, rawData["zProperty"].ToObjectFromJson<double>());
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
            }
        }
    }
}
