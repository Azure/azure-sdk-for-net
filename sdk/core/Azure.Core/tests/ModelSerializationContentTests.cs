// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Azure.Core.Serialization;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ModelSerializationContentTests
    {
        [Test]
        public void CanCalculateLength()
        {
            ModelX modelX = new ModelX("X", "Name", 100, new Dictionary<string, BinaryData>());

            //use IModelSerializable
            var content = RequestContent.Create((IModelSerializable<ModelX>)modelX);
            Assert.AreEqual("ModelSerializableContent", content.GetType().Name);
            content.TryComputeLength(out long lengthNonJson);
            Assert.Greater(lengthNonJson, 0);

            //use IModelJsonSerializable
            var jsonContent = RequestContent.Create((IModelJsonSerializable<ModelX>)modelX);
            Assert.AreEqual("ModelJsonSerializableContent", jsonContent.GetType().Name);
            content.TryComputeLength(out long lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);

            //use default
            jsonContent = RequestContent.Create(modelX);
            Assert.AreEqual("ModelJsonSerializableContent", jsonContent.GetType().Name);
            content.TryComputeLength(out lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);
        }

        [Test]
        public void ValidatePrivateClassType()
        {
            IModelSerializable<ModelX> modelX = new ModelX("X", "Name", 100, new Dictionary<string, BinaryData>());

            RequestContent content = RequestContent.Create(modelX);
            Assert.AreEqual("ModelSerializableContent", content.GetType().Name);
        }
    }
}
