// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel;
using System.Text;
using Azure.Core.Tests.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class ModelXDeserializationProxyTests
    {
        [TestCase("J")]
        [TestCase("W")]
        public void CanDeserializeModelX(string format)
        {
            ModelReaderWriterOptions options = ModelReaderWriterOptions.GetOptions(format);
            BinaryData data = new BinaryData(Encoding.UTF8.GetBytes("{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}"));
            object modelX = System.Net.ClientModel.ModelReaderWriter.Read(data, typeof(ModelXDeserializationProxy), options);
            Assert.IsNotNull(modelX);
            Assert.IsInstanceOf<ModelX>(modelX);
            Assert.AreEqual("X", ((ModelX)modelX).Kind);
            Assert.AreEqual("xmodel", ((ModelX)modelX).Name);
            Assert.AreEqual(100, ((ModelX)modelX).XProperty);
            if (format == ModelReaderWriterFormat.Json)
            {
                var rawData = ModelTests<ModelX>.GetRawData((ModelX)modelX);
                Assert.IsNotNull(rawData);
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
            }
        }
    }
}
