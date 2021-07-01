﻿using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.TestFramework;
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
            string expected = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "Unit", "TestAssets", "GenericResourceData", "SerializationTestType1.json"));
            ResourceGroupResourceIdentifier id = Id;
            Plan plan = new Plan("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan");
            Sku sku = new Sku("NameForSku", "TierForSku", "SizeForSku", "FamilyForSku", "ModelForSku", 15464547);
            GenericResourceData data = new GenericResourceData(id, id.Name, id.ResourceType, LocationData.EastUS, null, plan, null, "KindForResource", "ManagedByForResource", sku, null);

            var json = JsonHelper.SerializePropertiesToString(data, indented: true) + Environment.NewLine;
            Assert.AreEqual(expected, json);
        }

        [Test]
        public void SerializationTestType2()
        {
            string expected = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "Unit", "TestAssets", "GenericResourceData", "SerializationTestType2.json"));
            ResourceGroupResourceIdentifier id = Id;
            var plan = new Plan("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan");
            var kind = "KindForResource";
            var managedBy = "ManagedByForResource";
            var sku = new Sku("NameForSku", "TierForSku", "SizeForSku", "FamilyForSku", "ModelForSku", 15464547);
            GenericResourceData genericResource = new GenericResourceData(id, id.Name, id.ResourceType, LocationData.EastUS, null, plan, null, kind, managedBy, sku, null);
            genericResource.Tags.Add("key1", "value1");
            genericResource.Tags.Add("key2", "value2");

            var json = JsonHelper.SerializePropertiesToString(genericResource, indented: true) + Environment.NewLine;
            Assert.AreEqual(expected, json);
        }

        [Test]
        public void InvalidSerializationTest()
        {
            string expected = "{\"properties\":{\"location\":\"East US\",\"tags\":{}}}";
            ResourceGroupResourceIdentifier id = Id;
            GenericResourceData data = new GenericResourceData(id, id.Name, id.ResourceType, LocationData.EastUS, null, null, null, null, null, null, null);

            var json = JsonHelper.SerializePropertiesToString(data);
            Assert.AreEqual(expected, json);
        }

        [Test]
        public void DeserializationTest()
        {
            string json = "{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"kind\":\"KindForResource\",\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"TierForSku\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":\"Microsoft.ClassicStorage/storageAccounts\"}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            GenericResourceData data = GenericResourceData.DeserializeGenericResource(element);
            Assert.AreEqual("account1", data.Name);
            Assert.AreEqual(LocationData.EastUS, data.Location);
            Assert.AreEqual("PromotionCodeForPlan", data.Plan.PromotionCode);
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            string json = "{\"notId\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"location\":\"eastus\",\"managedBy\":\"ManagedByForResource\",\"name\":\"account1\",\"plan\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"},\"sku\":{\"name\":\"NameForSku\",\"tier\":\"TierForSku\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":15464547},\"tags\":{},\"type\":\"Microsoft.ClassicStorage/storageAccounts\"}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            GenericResourceData data = GenericResourceData.DeserializeGenericResource(element);
            Assert.IsNull(data.Id);
            Assert.IsNull(data.Kind);
        }
    }
}
