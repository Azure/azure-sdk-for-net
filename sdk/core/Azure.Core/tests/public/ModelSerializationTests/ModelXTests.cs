// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ModelXTests : ModelTests<ModelX>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

        protected override Func<ModelX, RequestContent> ToRequestContent => model => model;

        protected override Func<Response, ModelX> FromResponse => response => (ModelX)response;

        protected override void CompareModels(ModelX model, ModelX model2, ModelSerializerFormat format)
        {
            Assert.AreEqual(model.Name, model2.Name);
            Assert.AreEqual(model.Kind, model2.Kind);
            if (format == ModelSerializerFormat.Json)
            {
                Assert.AreEqual(model.XProperty, model2.XProperty);
                var rawData = GetRawData(model);
                var rawData2 = GetRawData(model2);
                Assert.IsNotNull(rawData);
                Assert.IsNotNull(rawData2);
                Assert.AreEqual(rawData.Count, rawData2.Count);
                Assert.AreEqual(rawData["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
            }
        }

        protected override string GetExpectedResult(ModelSerializerFormat format)
        {
            string expected = "{\"kind\":\"X\",\"name\":\"xmodel\"";
            if (format == ModelSerializerFormat.Json)
                expected += ",\"xProperty\":100";
            if (format == ModelSerializerFormat.Json)
                expected += ",\"extra\":\"stuff\"";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(ModelX model, ModelSerializerFormat format)
        {
            Assert.AreEqual("X", model.Kind);
            Assert.AreEqual("xmodel", model.Name);
            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == ModelSerializerFormat.Json)
            {
                Assert.AreEqual(100, model.XProperty);
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
            }
        }
    }
}
