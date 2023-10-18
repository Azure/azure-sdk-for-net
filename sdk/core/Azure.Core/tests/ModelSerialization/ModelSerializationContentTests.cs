// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using Azure.Core.Tests.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerialization
{
    public class ModelSerializationContentTests
    {
        private const string json = "{\"kind\":\"X\",\"name\":\"Name\",\"xProperty\":100}";
        private ModelX _modelX;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _modelX = ModelSerializer.Deserialize<ModelX>(BinaryData.FromString(json));
        }

        [Test]
        public void CanCalculateLength()
        {
            //use IModelSerializable
            var content = RequestContent.Create((IModelSerializable<ModelX>)_modelX);
            Assert.AreEqual("ModelSerializableContent", content.GetType().Name);
            content.TryComputeLength(out long lengthNonJson);
            Assert.Greater(lengthNonJson, 0);

            //use IModelJsonSerializable
            var jsonContent = RequestContent.Create((IModelJsonSerializable<ModelX>)_modelX);
            Assert.AreEqual("ModelJsonSerializableContent", jsonContent.GetType().Name);
            content.TryComputeLength(out long lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);

            //use default
            jsonContent = RequestContent.Create(_modelX);
            Assert.AreEqual("ModelJsonSerializableContent", jsonContent.GetType().Name);
            content.TryComputeLength(out lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);
        }

        [Test]
        public void ValidatePrivateClassType()
        {
            IModelSerializable<ModelX> modelX = _modelX;

            RequestContent content = RequestContent.Create(modelX);
            Assert.AreEqual("ModelSerializableContent", content.GetType().Name);
        }
    }
}
