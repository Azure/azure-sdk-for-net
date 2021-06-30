// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class SubResourceTests
    {
        [Test]
        public void Deserialization()
        {
            var id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1";
            var resource1 = new SubResource(id);
            var jsonString = JsonHelper.SerializeToString(resource1);
            var json = JsonDocument.Parse(jsonString).RootElement;
            var resource2 = SubResource.DeserializeSubResource(json);
            Assert.IsTrue(resource1.Equals(resource2));
            Assert.IsTrue(resource1.Equals(id));
            Assert.IsFalse(resource1.Equals(id + "1"));
        }
    }
}
