// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core.Serialization;
using Azure.Core.Tests.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
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

        protected override Func<BaseModel, RequestContent> ToRequestContent => model => model;

        protected override Func<Response, BaseModel> FromResponse => response => (BaseModel)response;

        protected override void CompareModels(BaseModel model, BaseModel model2, ModelSerializerFormat format)
        {
            Assert.AreEqual("UnknownBaseModel", model.GetType().Name);
            Assert.AreEqual("UnknownBaseModel", model2.GetType().Name);
            Assert.AreEqual(model.Kind, model2.Kind);
            Assert.AreEqual(model.Name, model2.Name);
            var rawData = GetRawData(model);
            var rawData2 = GetRawData(model2);
            Assert.IsNotNull(rawData);
            Assert.IsNotNull(rawData2);
            if (format == ModelSerializerFormat.Json)
            {
                Assert.AreEqual(rawData.Count, rawData2.Count);
                Assert.AreEqual(rawData["zProperty"].ToObjectFromJson<double>(), rawData2["zProperty"].ToObjectFromJson<double>());
                Assert.AreEqual(rawData["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
            }
        }

        protected override string GetExpectedResult(ModelSerializerFormat format)
        {
            string expected = "{\"kind\":\"Z\",\"name\":\"zmodel\"";
            if (format == ModelSerializerFormat.Json)
                expected += ",\"zProperty\":1.5,\"extra\":\"stuff\"";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(BaseModel model, ModelSerializerFormat format)
        {
            Assert.AreEqual("UnknownBaseModel", model.GetType().Name);
            Assert.AreEqual("Z", model.Kind);
            Assert.AreEqual("zmodel", model.Name);
            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == ModelSerializerFormat.Json)
            {
                Assert.AreEqual(1.5, rawData["zProperty"].ToObjectFromJson<double>());
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
            }
        }
    }
}
