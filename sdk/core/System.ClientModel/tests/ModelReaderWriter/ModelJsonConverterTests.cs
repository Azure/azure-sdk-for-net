// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class ModelJsonConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public ModelJsonConverterTests()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new ModelJsonConverter());
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
            ModelX? x = JsonSerializer.Deserialize<ModelX>(data, _options);
            Assert.IsNotNull(x);
            Assert.IsNull(x!.Kind);

            object? obj = JsonSerializer.Deserialize(data, typeof(ModelX), _options);
            Assert.IsNotNull(obj);
            Assert.IsNull(((ModelX)obj!).Kind);
        }
    }
}
