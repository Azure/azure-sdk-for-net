using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class GenericResourceDataTests
    {
        const string Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1";
        
        [Test]
        public void SerializationTestType1()
        {
            string expected = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "Unit", "TestAssets", "GenericResourceData", "SerializationTestType1.json"));
            ResourceIdentifier id = new ResourceIdentifier(Id);
            ArmPlan plan = new ArmPlan("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan");
            ResourcesSku sku = new ResourcesSku("NameForSku", ArmSkuTier.Basic.ToString(), "SizeForSku", "FamilyForSku", "ModelForSku", 15464547, null);
            GenericResourceData data = new GenericResourceData(id, id.Name, id.ResourceType, null, new Dictionary<string, string>(), AzureLocation.EastUS, null, null, plan, null, "KindForResource", "ManagedByForResource", sku, null, null, null, null);
            var json = JsonHelper.SerializePropertiesToString(data, indented: true) + Environment.NewLine;
            Assert.AreEqual(expected, json);
        }

        [Test]
        public void SerializationTestType2()
        {
            string expected = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "Unit", "TestAssets", "GenericResourceData", "SerializationTestType2.json"));
            ResourceIdentifier id = new ResourceIdentifier(Id);
            var plan = new ArmPlan("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan");
            var kind = "KindForResource";
            var managedBy = "ManagedByForResource";
            var sku = new ResourcesSku("NameForSku", ArmSkuTier.Basic.ToString(), "SizeForSku", "FamilyForSku", "ModelForSku", 15464547, null);
            GenericResourceData genericResource = new GenericResourceData(id, id.Name, id.ResourceType, null, new Dictionary<string, string>(), AzureLocation.EastUS, null, null, plan, null, kind, managedBy, sku, null, null, null, null);
            genericResource.Tags.Add("key1", "value1");
            genericResource.Tags.Add("key2", "value2");

            var json = JsonHelper.SerializePropertiesToString(genericResource, indented: true) + Environment.NewLine;
            Assert.AreEqual(expected, json);
        }

        [Test]
        public void InvalidSerializationTest()
        {
            string expected = "{\"properties\":{\"tags\":{},\"location\":\"eastus\"}}";
            ResourceIdentifier id = new ResourceIdentifier(Id);
            GenericResourceData data = new GenericResourceData(id, id.Name, id.ResourceType, null, new Dictionary<string, string>(), AzureLocation.EastUS, null, null, null, null, null, null, null, null, null, null, null);

            var json = JsonHelper.SerializePropertiesToString(data);
            Assert.AreEqual(expected, json);
        }

        [Test]
        public void DeserializationTest()
        {
            string json = "{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"kind\":\"KindForResource\",\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"Basic\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":\"Microsoft.ClassicStorage/storageAccounts\"}";
            using var jsonDocument = JsonDocument.Parse(json);
            JsonElement element = jsonDocument.RootElement;
            GenericResourceData data = GenericResourceData.DeserializeGenericResourceData(element);
            Assert.AreEqual("account1", data.Name);
            Assert.AreEqual(AzureLocation.EastUS, data.Location);
            Assert.AreEqual("PromotionCodeForPlan", data.Plan.PromotionCode);
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            string json = "{\"notId\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"Basic\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":\"Microsoft.ClassicStorage/storageAccounts\"}";
            using var jsonDocument = JsonDocument.Parse(json);
            JsonElement element = jsonDocument.RootElement;
            GenericResourceData data = GenericResourceData.DeserializeGenericResourceData(element);
            Assert.IsNull(data.Id);
            Assert.IsNull(data.Kind);
        }
    }
}
