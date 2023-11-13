// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core.Tests.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    public class UsingJsonSerializerTests
    {
        [TestCase("J")]
        [TestCase("W")]
        public void CanSerializeTwoModelsWithSameConverter(string format)
        {
            string modelYResponse = "{\"kind\":\"Y\",\"name\":\"ymodel\",\"yProperty\":\"100\",\"extra\":\"stuff\"}";
            string modelXResponse = "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

            var options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(new ModelReaderWriterOptions(format)));
            ModelY modelY = JsonSerializer.Deserialize<ModelY>(modelYResponse, options);

            Assert.AreEqual("Y", modelY.Kind);
            Assert.AreEqual("ymodel", modelY.Name);
            if (format == "J")
                Assert.AreEqual("100", modelY.YProperty);

            var additionalProperties = ModelTests<ModelY>.GetRawData(modelY);
            Assert.IsNotNull(additionalProperties);
            if (format == "J")
                Assert.AreEqual("stuff", additionalProperties["extra"].ToObjectFromJson<string>());

            string expectedModelY = "{";
            expectedModelY += "\"kind\":\"Y\",\"name\":\"ymodel\"";
            if (format == "J")
                expectedModelY += ",\"yProperty\":\"100\",\"extra\":\"stuff\"";
            expectedModelY += "}";

            var actualModelY = JsonSerializer.Serialize(modelY, options);
            Assert.AreEqual(expectedModelY, actualModelY);

            ModelX modelX = JsonSerializer.Deserialize<ModelX>(modelXResponse, options);

            Assert.AreEqual("X", modelX.Kind);
            Assert.AreEqual("xmodel", modelX.Name);
            if (format == "J")
                Assert.AreEqual(100, modelX.XProperty);

            additionalProperties = ModelTests<ModelX>.GetRawData(modelX);
            Assert.IsNotNull(additionalProperties);
            if (format == "J")
                Assert.AreEqual("stuff", additionalProperties["extra"].ToObjectFromJson<string>());

            string expectedModelX = "{";
            expectedModelX += "\"kind\":\"X\"";
            expectedModelX += ",\"name\":\"xmodel\"";
            if (format == "J")
                expectedModelX += ",\"xProperty\":100";
            if (format == "J")
                expectedModelX += ",\"extra\":\"stuff\"";
            expectedModelX += "}";

            var actualModelX = JsonSerializer.Serialize(modelX, options);
            Assert.AreEqual(expectedModelX, actualModelX);
        }
    }
}
