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
            widget.MiniModel = new DynamicDataMiniModel { X = "yProperty" };
            DynamicDataBaseModel model = (DynamicDataBaseModel)widget;
            Assert.IsNotNull(model);
        }
    }
}
