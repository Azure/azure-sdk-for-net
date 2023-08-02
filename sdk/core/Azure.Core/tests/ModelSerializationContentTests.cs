// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            var modelX = new ModelX("X", "Name", 100, new Dictionary<string, BinaryData>());

            //use IModelSerializable
            var content = RequestContent.Create((IModelSerializable<ModelX>)modelX);
            bool useJsonContent = (bool)content.GetType().GetField("_useJsonInterface", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(content);
            Assert.IsFalse(useJsonContent);
            content.TryComputeLength(out long lengthNonJson);
            Assert.Greater(lengthNonJson, 0);

            //use IModelJsonSerializable
            var jsonContent = RequestContent.Create((IModelJsonSerializable<ModelX>)modelX);
            useJsonContent = (bool)jsonContent.GetType().GetField("_useJsonInterface", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(jsonContent);
            Assert.IsTrue(useJsonContent);
            content.TryComputeLength(out long lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);

            //use default
            jsonContent = RequestContent.Create(modelX);
            useJsonContent = (bool)jsonContent.GetType().GetField("_useJsonInterface", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(jsonContent);
            Assert.IsTrue(useJsonContent);
            content.TryComputeLength(out lengthJson);
            Assert.Greater(lengthJson, 0);

            Assert.AreEqual(lengthNonJson, lengthJson);
        }
    }
}
