// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel.Core.Content;
using Azure.Core.Tests.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class ModelAsStructTests : ModelJsonTests<ModelAsStruct>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"id\":5,\"extra\":\"stuff\"}";

        protected override Func<ModelAsStruct, RequestContent> ToRequestContent => model => model;

        protected override Func<Response, ModelAsStruct> FromResponse => response => (ModelAsStruct)response;

        protected override void CompareModels(ModelAsStruct model, ModelAsStruct model2, ModelReaderWriterFormat format)
        {
            Assert.AreEqual(model.Id, model2.Id);
            var rawData1 = GetRawData(model);
            var rawData2 = GetRawData(model2);
            Assert.IsNotNull(rawData1);
            Assert.IsNotNull(rawData2);
            if (format == ModelReaderWriterFormat.Json)
                Assert.AreEqual(rawData1["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
        }

        protected override string GetExpectedResult(ModelReaderWriterFormat format)
        {
            string expected = "{\"id\":5";
            if (format == ModelReaderWriterFormat.Json)
                expected += ",\"extra\":\"stuff\"";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(ModelAsStruct model, ModelReaderWriterFormat format)
        {
            Assert.AreEqual(5, model.Id);
            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == ModelReaderWriterFormat.Json)
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
        }
    }
}
