// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using NUnit.Framework;

namespace Azure.ResourceManager.AgFoodPlatform.Tests.Unit
{
    public class ExtensionDataTests
    {
        [Test]
        public void ExtensionIdCanBeSetThroughReflection()
        {
            var data = new ExtensionData();
            FieldInfo extensionIdField = typeof(ExtensionData).GetField("<ExtensionId>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.That(extensionIdField, Is.Not.Null);
            extensionIdField.SetValue(data, "extension-id");

            Assert.That(data.ExtensionId, Is.EqualTo("extension-id"));
        }
    }
}
