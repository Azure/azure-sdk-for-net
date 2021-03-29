using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class GenericResourceDataTests
    {
        const string Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1";
        
        [Test]
        public void SerializationTest()
        {
            string expected = "{\"properties\":{\"id\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"name\":\"account1\",\"parent\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg\",\"name\":\"testRg\",\"parent\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000\",\"name\":\"00000000-0000-0000-0000-000000000000\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.Resources\",\"parent\":{},\"type\":\"subscriptions\"}},\"resourceGroup\":\"testRg\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.Resources\",\"parent\":{},\"type\":\"resourceGroups\"}},\"resourceGroup\":\"testRg\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"parent\":{},\"type\":\"storageAccounts\"}},\"kind\":\"KindForResource\",\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"TierForSku\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"parent\":{},\"type\":\"storageAccounts\"}}}";
            GenericResourceData data = new(new ResourceIdentifier(Id), LocationData.EastUS)
            {
                Kind = "KindForResource",
                ManagedBy = "ManagedByForResource",
                Plan = new Plan("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan"),
                Sku = new Sku("NameForSku", "TierForSku", "FamilyForSku", "SizeForSku", 15464547), 
            };
            // TODO: If we create data this way, Tags will be null
            //data.Tags.Add("key1", "value1");
            //data.Tags.Add("key2", "value2");
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
        public void InvalidSerializationTest()
        {
            ResourceIdentifier id = null;
            GenericResourceData data = new(id);
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(data);
            writer.WriteEndObject();
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(json.Equals("{\"properties\":{\"location\":\"westus\",\"tags\":{}}}"));
        }

        [Test]
        public void DeserializationTest()
        {
            string json = "{\"id\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"name\":\"account1\",\"parent\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg\",\"name\":\"testRg\",\"parent\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000\",\"name\":\"00000000-0000-0000-0000-000000000000\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.Resources\",\"parent\":{},\"type\":\"subscriptions\"}},\"resourceGroup\":\"testRg\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.Resources\",\"parent\":{},\"type\":\"resourceGroups\"}},\"resourceGroup\":\"testRg\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"parent\":{},\"type\":\"storageAccounts\"}},\"kind\":\"KindForResource\",\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"TierForSku\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"parent\":{},\"type\":\"storageAccounts\"}}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            GenericResourceData data = GenericResourceData.DeserializeGenericResourceData(element);
            Assert.IsTrue(data.Name.Equals("account1"));
            Assert.IsTrue(data.Plan.PromotionCode.Equals("PromotionCodeForPlan"));
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            string json = "{\"NotId\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"name\":\"account1\",\"parent\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg\",\"name\":\"testRg\",\"parent\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000\",\"name\":\"00000000-0000-0000-0000-000000000000\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.Resources\",\"parent\":{},\"type\":\"subscriptions\"}},\"resourceGroup\":\"testRg\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.Resources\",\"parent\":{},\"type\":\"resourceGroups\"}},\"resourceGroup\":\"testRg\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"parent\":{},\"type\":\"storageAccounts\"}},\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"TierForSku\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"parent\":{},\"type\":\"storageAccounts\"}}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            GenericResourceData data = GenericResourceData.DeserializeGenericResourceData(element);
            Assert.IsTrue(data.Id == null);
            Assert.IsTrue(data.Kind == null);
        }
    }
}
