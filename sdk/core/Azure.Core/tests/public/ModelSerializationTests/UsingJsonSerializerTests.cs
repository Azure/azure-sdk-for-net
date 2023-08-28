// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
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
            options.Converters.Add(new ModelJsonConverter(format));
            ModelY modelY = JsonSerializer.Deserialize<ModelY>(modelYResponse, options);

            Assert.AreEqual("Y", modelY.Kind);
            Assert.AreEqual("ymodel", modelY.Name);
            if (format == ModelSerializerFormat.Json)
                Assert.AreEqual("100", modelY.YProperty);

            var additionalProperties = ModelTests<ModelY>.GetRawData(modelY);
            Assert.IsNotNull(additionalProperties);
            if (format == ModelSerializerFormat.Json)
                Assert.AreEqual("stuff", additionalProperties["extra"].ToObjectFromJson<string>());

            string expectedModelY = "{";
            expectedModelY += "\"kind\":\"Y\",\"name\":\"ymodel\"";
            if (format == ModelSerializerFormat.Json)
                expectedModelY += ",\"yProperty\":\"100\",\"extra\":\"stuff\"";
            expectedModelY += "}";

            var actualModelY = JsonSerializer.Serialize(modelY, options);
            Assert.AreEqual(expectedModelY, actualModelY);

            ModelX modelX = JsonSerializer.Deserialize<ModelX>(modelXResponse, options);

            Assert.AreEqual("X", modelX.Kind);
            Assert.AreEqual("xmodel", modelX.Name);
            if (format == ModelSerializerFormat.Json)
                Assert.AreEqual(100, modelX.XProperty);

            additionalProperties = ModelTests<ModelX>.GetRawData(modelX);
            Assert.IsNotNull(additionalProperties);
            if (format == ModelSerializerFormat.Json)
                Assert.AreEqual("stuff", additionalProperties["extra"].ToObjectFromJson<string>());

            string expectedModelX = "{";
            expectedModelX += "\"kind\":\"X\"";
            expectedModelX += ",\"name\":\"xmodel\"";
            if (format == ModelSerializerFormat.Json)
                expectedModelX += ",\"xProperty\":100";
            if (format == ModelSerializerFormat.Json)
                expectedModelX += ",\"extra\":\"stuff\"";
            expectedModelX += "}";

            var actualModelX = JsonSerializer.Serialize(modelX, options);
            Assert.AreEqual(expectedModelX, actualModelX);
        }
    }
}
