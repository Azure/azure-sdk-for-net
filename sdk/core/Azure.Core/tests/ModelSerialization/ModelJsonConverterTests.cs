// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerialization
{
    public class ModelJsonConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public ModelJsonConverterTests()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new ModelJsonConverter());
        }

        [TestCaseSource(typeof(SerializationTestSource), "NullBinaryData")]
        public void ValidateNullBinaryData(BinaryData data)
        {
            Assert.IsNull(JsonSerializer.Deserialize<ModelX>(data, _options));
            Assert.IsNull(JsonSerializer.Deserialize(data, typeof(ModelX), _options));
        }

        [TestCaseSource(typeof(SerializationTestSource), "InvalidOperationBinaryData")]
        public void ValidateInvalidOperationBinaryData(BinaryData data) => ValidateJsonExceptionBinaryData(data);

        [TestCaseSource(typeof(SerializationTestSource), "JsonExceptionBinaryData")]
        public void ValidateJsonExceptionBinaryData(BinaryData data)
        {
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<ModelX>(data, _options));
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize(data, typeof(ModelX), _options));
        }

        [TestCaseSource(typeof(SerializationTestSource), "EmptyObjectBinaryData")]
        public void ValidateEmptyObjectBinaryData(BinaryData data)
        {
            ModelX x = JsonSerializer.Deserialize<ModelX>(data, _options);
            Assert.IsNotNull(x);
            Assert.IsNull(x.Kind);

            object obj = JsonSerializer.Deserialize(data, typeof(ModelX), _options);
            Assert.IsNotNull(obj);
            Assert.IsNull(((ModelX)obj).Kind);
        }
    }
}
