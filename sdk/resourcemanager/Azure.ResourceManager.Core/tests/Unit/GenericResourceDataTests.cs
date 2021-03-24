using System.IO;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    class GenericResourceDataTests
    {
        [Test]
        public void SerializationTest()
        {
            string expected = "{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"location\":\"East US\",\"tags\":{}}";
            GenericResourceData data = new(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1"), LocationData.EastUS);
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            GenericResourceData.Serialize(writer, data);
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(expected.Equals(json));
        }

        [Test]
        public void InvalidSerializationTest()
        {
            GenericResourceData data = new(null, null);
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            GenericResourceData.Serialize(writer, data);
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(json.Equals("{\"tags\":{}}"));
        }

        [Test]
        public void DeserializationTest()
        {
            string json = "{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"location\":\"East US\",\"tags\":{}}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            GenericResourceData data = GenericResourceData.Deserialize(element);
            Assert.IsTrue(data.Id.Id.Equals("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1"));
            Assert.IsTrue(data.Tags == null);
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            string json = "{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"notLocation\":\"East US\"}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            GenericResourceData data = GenericResourceData.Deserialize(element);
            Assert.IsTrue(data.Location == null);
            Assert.IsTrue(data.Tags == null);
        }
    }
}
