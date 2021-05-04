using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class GenericResourceDataTests
    {
        const string Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1";
        
        [Test]
        public void SerializationTestType1()
        {
            string expected = "{\"properties\":{\"kind\":\"KindForResource\"," +
                "\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\"," +
                "\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\"," +
                "\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\"," +
                "\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"TierForSku\"," +
                "\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{}}}";
            ResourceGroupResourceIdentifier id = Id;
            Plan plan = new Plan("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan");
            Sku sku = new Sku("NameForSku", "TierForSku", "FamilyForSku", "SizeForSku", 15464547);
            GenericResourceData data = new GenericResourceData(id, id.Name, id.ResourceType, LocationData.EastUS, null, plan, null, "KindForResource", "ManagedByForResource", sku, null);
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(data);
            writer.WriteEndObject();
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(expected.Equals(json));
        }

        [Test]
        public void SerializationTestType2()
        {
            string expected = "{\"properties\":{\"kind\":\"KindForResource\"," +
                "\"managedBy\":\"ManagedByForResource\",\"plan\":{\"name\":\"NameForPlan\"," +
                "\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\"," +
                "\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"}," +
                "\"sku\":{\"name\":\"NameForSku\",\"tier\":\"TierForSku\",\"size\":\"SizeForSku\"," +
                "\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{\"key1\":\"value1\"," +
                "\"key2\":\"value2\"}}}";
            GenericResourceData genericResource = new()
            {
                Plan = new Plan("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan"),
                Kind = "KindForResource",
                ManagedBy = "ManagedByForResource",
                Sku = new Sku("NameForSku", "TierForSku", "FamilyForSku", "SizeForSku", 15464547)
            };
            genericResource.Tags.Add("key1", "value1");
            genericResource.Tags.Add("key2", "value2");
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(genericResource);
            writer.WriteEndObject();
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(expected.Equals(json));
        }

        [Test]
        public void InvalidSerializationTest()
        {
            string expected = "{\"properties\":{\"location\":\"eastus\",\"tags\":{}}}";
            ResourceGroupResourceIdentifier id = Id;
            GenericResourceData data = new GenericResourceData(id, id.Name, id.ResourceType, LocationData.EastUS, null, null, null, null, null, null, null);

            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(data);
            writer.WriteEndObject();
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(expected.Equals(json));
        }

        [Test]
        public void DeserializationTest()
        {
            string json = "{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"kind\":\"KindForResource\",\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"TierForSku\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":\"Microsoft.ClassicStorage/storageAccounts\"}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            GenericResourceData data = GenericResourceData.DeserializeGenericResource(element);
            Assert.IsTrue(data.Name.Equals("account1"));
            Assert.IsTrue(data.Location == LocationData.EastUS);
            Assert.IsTrue(data.Plan.PromotionCode.Equals("PromotionCodeForPlan"));
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            string json = "{\"notId\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"TierForSku\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":\"Microsoft.ClassicStorage/storageAccounts\"}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            GenericResourceData data = GenericResourceData.DeserializeGenericResource(element);
            Assert.IsTrue(data.Id == null);
            Assert.IsTrue(data.Kind == null);
        }
    }
}
