using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class WritableSubResourceTests
    {
        private static readonly ModelReaderWriterOptions _wireOptions = new("W");

        [Test]
        public void Deserialization()
        {
            var id = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1");
            var expected = "{\"id\":\"" + id + "\"}";
            var resource1 = new WritableSubResource(id);
            var binary = ModelReaderWriter.Write(resource1, _wireOptions);
            var jsonString = binary.ToString();
            using var jsonDocument = JsonDocument.Parse(binary);
            var json = jsonDocument.RootElement;
            var resource2 = WritableSubResource.DeserializeWritableSubResource(json);
            var binary2 = ModelReaderWriter.Write(resource2, _wireOptions);
            Assert.AreEqual(expected, jsonString);
            Assert.AreEqual(jsonString, binary2.ToString());

            var resource3 = new WritableSubResource();
            resource3.Id = new ResourceIdentifier(id);
            var binary3 = ModelReaderWriter.Write(resource3, _wireOptions);
            Assert.AreEqual(jsonString, binary3.ToString());
        }
    }
}
