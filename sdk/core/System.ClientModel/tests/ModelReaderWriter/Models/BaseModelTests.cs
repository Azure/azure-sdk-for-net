// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Linq;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class BaseModelTests : ModelJsonTests<BaseModel>
    {
        protected override BaseModel GetModelInstance()
        {
            var typeToActivate = typeof(BaseModel).Assembly.GetTypes().FirstOrDefault(t => t.Name == $"Unknown{typeof(BaseModel).Name}") ?? throw new InvalidOperationException("Unable to find BaseModel type");
            return Activator.CreateInstance(typeToActivate, true) as BaseModel ?? throw new InvalidOperationException($"Unable to create model instance of BaseModel");
        }

        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

        protected override void CompareModels(BaseModel model, BaseModel model2, string format)
        {
            Assert.AreEqual(model.Name, model2.Name);
            Assert.AreEqual(model.Kind, model2.Kind);
            if (format == "J")
            {
                var rawData = GetRawData(model);
                var rawData2 = GetRawData(model2);
                Assert.IsNotNull(rawData);
                Assert.IsNotNull(rawData2);
                Assert.AreEqual(rawData.Count, rawData2.Count);
                Assert.AreEqual(rawData["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
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
            Assert.AreEqual("X", model.Kind);
            Assert.AreEqual("xmodel", model.Name);
            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == "J")
            {
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
            }
        }
    }
}
