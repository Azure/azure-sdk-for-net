// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using Azure.Core.Tests.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelReaderWriterTests
{
    public class ModelReaderWriterRequestContentTests
    {
        private const string json = "{\"kind\":\"X\",\"name\":\"Name\",\"xProperty\":100}";
        private ModelX _modelX;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _modelX = ModelReaderWriter.Read<ModelX>(BinaryData.FromString(json));
        }

        [Test]
        public void CanCalculateLength()
        {
            //use IModelSerializable
            var content = RequestContent.Create(_modelX);
            content.TryComputeLength(out long lengthNonJson);
            Assert.Greater(lengthNonJson, 0);

            //use IModelJsonSerializable
            var jsonContent = RequestContent.Create(_modelX);
            content.TryComputeLength(out long lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);

            //use default
            jsonContent = RequestContent.Create(_modelX);
            content.TryComputeLength(out lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);
        }
    }
}
