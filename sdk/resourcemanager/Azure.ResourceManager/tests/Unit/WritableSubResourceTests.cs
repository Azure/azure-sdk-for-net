﻿using System.Text.Json;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class WritableSubResourceTests
    {
        [Test]
        public void Deserialization()
        {
            var id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1";
            var expected = "{\"id\":\"" + id + "\"}";
            var resource1 = new WritableSubResource(id);
            var jsonString = JsonHelper.SerializeToString(resource1);
            var json = JsonDocument.Parse(jsonString).RootElement;
            var resource2 = WritableSubResource.DeserializeWritableSubResource(json);
            Assert.AreEqual(expected, jsonString);
            Assert.AreEqual(jsonString, JsonHelper.SerializeToString(resource2));

            var resource3 = new WritableSubResource();
            resource3.Id = id;
            Assert.AreEqual(jsonString, JsonHelper.SerializeToString(resource3));
        }
    }
}
