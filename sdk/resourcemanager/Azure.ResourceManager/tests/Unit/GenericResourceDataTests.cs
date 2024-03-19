using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class GenericResourceDataTests
    {
        private const string Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1";
        private static readonly ModelReaderWriterOptions _wireOptions = new("W");

        [Test]
        public void SerializationTestType1()
        {
            string expected = JsonHelper.ReadJson(Path.Combine(TestContext.CurrentContext.TestDirectory, "Unit", "TestAssets", "GenericResourceData", "SerializationTestType1.json"));
            ResourceIdentifier id = new ResourceIdentifier(Id);
            ArmPlan plan = new ArmPlan("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan");
            ResourcesSku sku = new ResourcesSku("NameForSku", ArmSkuTier.Basic.ToString(), "SizeForSku", "FamilyForSku", "ModelForSku", 15464547, null);
            GenericResourceData data = ResourceManagerModelFactory.GenericResourceData(id: id, name: id.Name, resourceType: id.ResourceType, tags: new Dictionary<string, string>(), location: AzureLocation.EastUS, plan: plan, kind: "KindForResource", managedBy: "ManagedByForResource", sku: sku);
            var binary = ModelReaderWriter.Write(data, _wireOptions);
            Assert.AreEqual(expected, binary.ToString());
        }

        [Test]
        public void SerializationTestType2()
        {
            string expected = JsonHelper.ReadJson(Path.Combine(TestContext.CurrentContext.TestDirectory, "Unit", "TestAssets", "GenericResourceData", "SerializationTestType2.json"));
            ResourceIdentifier id = new ResourceIdentifier(Id);
            var plan = new ArmPlan("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan");
            var kind = "KindForResource";
            var managedBy = "ManagedByForResource";
            var sku = new ResourcesSku("NameForSku", ArmSkuTier.Basic.ToString(), "SizeForSku", "FamilyForSku", "ModelForSku", 15464547, null);
            GenericResourceData genericResource = ResourceManagerModelFactory.GenericResourceData(id: id, name: id.Name, resourceType: id.ResourceType, tags: new Dictionary<string, string>()
            {
                ["key1"] = "value1",
                ["key2"] = "value2"
            }, location: AzureLocation.EastUS, plan: plan, kind: kind, managedBy: managedBy, sku: sku);

            var binary = ModelReaderWriter.Write(genericResource, _wireOptions);
            Assert.AreEqual(expected, binary.ToString());
        }

        [Test]
        public void InvalidSerializationTest()
        {
            const string expected = "{\"tags\":{},\"location\":\"eastus\"}";
            ResourceIdentifier id = new ResourceIdentifier(Id);
            GenericResourceData data = ResourceManagerModelFactory.GenericResourceData(id: id, name: id.Name, resourceType: id.ResourceType, tags: new Dictionary<string, string>(), location: AzureLocation.EastUS);

            var binary = ModelReaderWriter.Write(data, _wireOptions);
            Assert.AreEqual(expected, binary.ToString());
        }

        [Test]
        public void DeserializationTest()
        {
            const string json = "{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"kind\":\"KindForResource\",\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"Basic\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":\"Microsoft.ClassicStorage/storageAccounts\"}";
            using var jsonDocument = JsonDocument.Parse(json);
            GenericResourceData data = GenericResourceData.DeserializeGenericResourceData(jsonDocument.RootElement);
            Assert.AreEqual("account1", data.Name);
            Assert.AreEqual(AzureLocation.EastUS, data.Location);
            Assert.AreEqual("PromotionCodeForPlan", data.Plan.PromotionCode);
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            string json = "{\"notId\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"Basic\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":\"Microsoft.ClassicStorage/storageAccounts\"}";
            using var jsonDocument = JsonDocument.Parse(json);
            GenericResourceData data = GenericResourceData.DeserializeGenericResourceData(jsonDocument.RootElement);
            Assert.IsNull(data.Id);
            Assert.IsNull(data.Kind);
        }
    }
}
