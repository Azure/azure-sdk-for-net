// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using Azure.Core.Tests.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ModelAsStructTests : ModelJsonTests<ModelAsStruct>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"id\":5,\"extra\":\"stuff\"}";

        protected override Func<ModelAsStruct, RequestContent> ToRequestContent => model => model;

        protected override Func<Response, ModelAsStruct> FromResponse => response => (ModelAsStruct)response;

        protected override void CompareModels(ModelAsStruct model, ModelAsStruct model2, ModelSerializerFormat format)
        {
            Assert.AreEqual(model.Id, model2.Id);
            var rawData1 = GetRawData(model);
            var rawData2 = GetRawData(model2);
            Assert.IsNotNull(rawData1);
            Assert.IsNotNull(rawData2);
            if (format == ModelSerializerFormat.Json)
                Assert.AreEqual(rawData1["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
        }

        protected override string GetExpectedResult(ModelSerializerFormat format)
        {
            string expected = "{\"id\":5";
            if (format == ModelSerializerFormat.Json)
                expected += ",\"extra\":\"stuff\"";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(ModelAsStruct model, ModelSerializerFormat format)
        {
            Assert.AreEqual(5, model.Id);
            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == ModelSerializerFormat.Json)
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
        }
    }
}
