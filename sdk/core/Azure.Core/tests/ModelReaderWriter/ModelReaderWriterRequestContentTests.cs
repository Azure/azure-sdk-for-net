// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Reflection;
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
            var content = RequestContent.Create((IModel<ModelX>)_modelX);
            AssertContentType(content, "ModelMessageBody");
            content.TryComputeLength(out long lengthNonJson);
            Assert.Greater(lengthNonJson, 0);

            //use IModelJsonSerializable
            var jsonContent = RequestContent.Create((IJsonModel<ModelX>)_modelX);
            AssertContentType(jsonContent, "ModelMessageBody");
            content.TryComputeLength(out long lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);

            //use default
            jsonContent = RequestContent.Create(_modelX);
            AssertContentType(jsonContent, "ModelMessageBody");
            content.TryComputeLength(out lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);
        }

        private static void AssertContentType(RequestContent content, string expectedContent)
        {
            Assert.AreEqual("MessageBodyContent", content.GetType().Name);
            var field = content.GetType().GetField("_content", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(field);
            Assert.AreEqual(expectedContent, field.GetValue(content).GetType().Name);
        }

        [Test]
        public void ValidatePrivateClassType()
        {
            IModel<ModelX> modelX = _modelX;

            RequestContent content = RequestContent.Create(modelX);
            AssertContentType(content, "ModelMessageBody");
        }
    }
}
