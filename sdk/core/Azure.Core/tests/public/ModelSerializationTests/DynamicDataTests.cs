// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Serialization;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class DynamicDataTests
    {
        [TestCase("J")]
        [TestCase("W")]
        public void CanRoundTripFutureVersionWithoutLoss(string format)
        {
            ModelSerializerOptions options = new ModelSerializerOptions(format);

            string serviceResponse =
            "{\"name\":\"dynamo\"," +
            "\"miniModel\":{\"foo\":\"xProperty\"}" +
            "}";

            BinaryData binaryData = BinaryData.FromString(serviceResponse);

            dynamic widget = binaryData.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.IsTrue(widget.MiniModel.foo == "xProperty");
            Assert.IsTrue(widget.MiniModel.Foo == "xProperty");

            widget.MiniModel = new DynamicDataMiniModel { X = "yProperty" };
            Assert.IsTrue(widget.MiniModel.Foo == "yProperty");
            Assert.IsTrue(widget.MiniModel.foo == "yProperty");

            DynamicDataBaseModel model = (DynamicDataBaseModel)widget;
            Assert.IsNotNull(model);
            Assert.AreEqual("dynamo", model.Name);
            //Assert.AreEqual("yProperty", model.MiniModel.foo);
        }
    }
}
