// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class ModelAsStructTests : ModelJsonTests<ModelAsStruct>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"id\":5,\"extra\":\"stuff\"}";

        protected override void CompareModels(ModelAsStruct model, ModelAsStruct model2, string format)
        {
            Assert.AreEqual(model.Id, model2.Id);
            var rawData1 = GetRawData(model);
            var rawData2 = GetRawData(model2);
            Assert.IsNotNull(rawData1);
            Assert.IsNotNull(rawData2);
            if (format == "J")
                Assert.AreEqual(rawData1["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
        }

        protected override string GetExpectedResult(string format)
        {
            object obj = format switch
            {
                "J" => new
                {
                    id = 5,
                    extra = "stuff"
                },
                _ => new
                {
                    id = 5
                }
            };
            return JsonSerializer.Serialize(obj);
        }

        protected override void VerifyModel(ModelAsStruct model, string format)
        {
            Assert.AreEqual(5, model.Id);
            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == "J")
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
        }
    }
}
