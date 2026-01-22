// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
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
            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            BinaryData data = new BinaryData(Encoding.UTF8.GetBytes("{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}"));
            object modelX = ModelReaderWriter.Read(data, typeof(ModelXDeserializationProxy), options);
            Assert.That(modelX, Is.Not.Null);
            Assert.That(modelX, Is.InstanceOf<ModelX>());
            Assert.That(((ModelX)modelX).Kind, Is.EqualTo("X"));
            Assert.That(((ModelX)modelX).Name, Is.EqualTo("xmodel"));
            Assert.That(((ModelX)modelX).XProperty, Is.EqualTo(100));
            if (format == "J")
            {
                var rawData = ModelTests<ModelX>.GetRawData((ModelX)modelX);
                Assert.That(rawData, Is.Not.Null);
                Assert.That(rawData["extra"].ToObjectFromJson<string>(), Is.EqualTo("stuff"));
            }
        }
    }
}
