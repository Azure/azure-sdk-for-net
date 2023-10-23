// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Core.Content;
using System.Net.ClientModel.Tests.Client.ModelReaderWriterTests.Models;

namespace System.Net.ClientModel.Tests.ModelReaderWriterTests
{
    public class ModelReaderWriterPipelineContentTests
    {
        private const string json = "{\"kind\":\"X\",\"name\":\"Name\",\"xProperty\":100}";
        private ModelX? _modelX;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _modelX = ModelReaderWriter.Read<ModelX>(BinaryData.FromString(json));
        }

        [Test]
        public void CanCalculateLength()
        {
            //use IModelSerializable
            var content = PipelineMessageContent.CreateContent((IModel<ModelX>)_modelX!);
            AssertContentType(content, "ModelWriterContent");
            content.TryComputeLength(out long lengthNonJson);
            Assert.Greater(lengthNonJson, 0);

            //use IModelJsonSerializable
            var jsonContent = PipelineMessageContent.CreateContent((IJsonModel<ModelX>)_modelX!);
            AssertContentType(jsonContent, "JsonModelWriterContent");
            content.TryComputeLength(out long lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);

            //use default
            jsonContent = PipelineMessageContent.CreateContent(_modelX!);
            AssertContentType(jsonContent, "JsonModelWriterContent");
            content.TryComputeLength(out lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);
        }

        private static void AssertContentType(PipelineMessageContent content, string expectedContent)
        {
            Assert.AreEqual(expectedContent, content.GetType().Name);
        }

        [Test]
        public void ValidatePrivateClassType()
        {
            IModel<ModelX> modelX = _modelX!;

            PipelineMessageContent content = PipelineMessageContent.CreateContent(modelX);
            AssertContentType(content, "ModelWriterContent");
        }
    }
}
