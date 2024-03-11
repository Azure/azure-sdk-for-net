// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class JsonModelConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public JsonModelConverterTests()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new JsonModelConverter());
        }

        [TestCaseSource(typeof(ReaderWriterTestSource), "NullBinaryData")]
        public void ValidateNullBinaryData(BinaryData data)
        {
            Assert.IsNull(JsonSerializer.Deserialize<ModelX>(data, _options));
            Assert.IsNull(JsonSerializer.Deserialize(data, typeof(ModelX), _options));
        }

        [TestCaseSource(typeof(ReaderWriterTestSource), "InvalidOperationBinaryData")]
        public void ValidateInvalidOperationBinaryData(BinaryData data) => ValidateJsonExceptionBinaryData(data);

        [TestCaseSource(typeof(ReaderWriterTestSource), "JsonExceptionBinaryData")]
        public void ValidateJsonExceptionBinaryData(BinaryData data)
        {
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<ModelX>(data, _options));
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize(data, typeof(ModelX), _options));
        }

        [TestCaseSource(typeof(ReaderWriterTestSource), "EmptyObjectBinaryData")]
        public void ValidateEmptyObjectBinaryData(BinaryData data)
        {
            Assert.Throws<JsonException>(() => ModelReaderWriter.Read<ModelX>(data));
            Assert.Throws<JsonException>(() => ModelReaderWriter.Read(data, typeof(ModelX)));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void CanSerializeTwoModelsWithSameConverter(string format)
        {
            string modelYResponse = "{\"kind\":\"Y\",\"name\":\"ymodel\",\"yProperty\":\"100\",\"extra\":\"stuff\"}";
            string modelXResponse = "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonModelConverter(new ModelReaderWriterOptions(format)));
            ModelY? modelY = JsonSerializer.Deserialize<ModelY>(modelYResponse, options);
            Assert.IsNotNull(modelY);

            Assert.AreEqual("Y", modelY!.Kind);
            Assert.AreEqual("ymodel", modelY.Name);
            if (format == "J")
                Assert.AreEqual("100", modelY.YProperty);

            var additionalProperties = GetRawData(modelY);
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

            ModelX? modelX = JsonSerializer.Deserialize<ModelX>(modelXResponse, options);
            Assert.IsNotNull(modelX);

            Assert.AreEqual("X", modelX!.Kind);
            Assert.AreEqual("xmodel", modelX.Name);
            if (format == "J")
                Assert.AreEqual(100, modelX.XProperty);

            additionalProperties = GetRawData(modelX);
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

        private static Dictionary<string, BinaryData> GetRawData(object model)
        {
            Type modelType = model.GetType();
            Assert.IsNotNull(modelType);
            while (modelType!.BaseType != typeof(object) && modelType.BaseType != typeof(ValueType))
            {
                modelType = modelType.BaseType!;
            }
            var propertyInfo = modelType.GetField("_rawData", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(propertyInfo);
            return (Dictionary<string, BinaryData>)propertyInfo!.GetValue(model)!;
        }
    }
}
