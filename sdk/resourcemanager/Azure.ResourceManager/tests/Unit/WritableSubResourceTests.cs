using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class WritableSubResourceTests
    {
        [Test]
        public void Deserialization()
        {
            var id = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1");
            var expected = "{\"id\":\"" + id + "\"}";
            var resource1 = new WritableSubResource(id);
            var jsonString = JsonHelper.SerializeToString(resource1);
            using var jsonDocument = JsonDocument.Parse(jsonString);
            var json = jsonDocument.RootElement;
            var resource2 = WritableSubResource.DeserializeWritableSubResource(json);
            Assert.AreEqual(expected, jsonString);
            Assert.AreEqual(jsonString, JsonHelper.SerializeToString(resource2));

            var resource3 = new WritableSubResource();
            resource3.Id = new ResourceIdentifier(id);
            Assert.AreEqual(jsonString, JsonHelper.SerializeToString(resource3));
        }
    }
}
