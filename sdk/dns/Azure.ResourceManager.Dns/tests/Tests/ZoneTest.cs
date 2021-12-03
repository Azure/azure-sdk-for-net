// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Dns.Tests;
using Azure.ResourceManager.Dns;
using System.Linq;
using System;
using System.IO;
using System.Collections.Generic;

namespace Azure.Management.Dns.Tests
{
    public class ZoneTest : DnsManagementClientBase
    {
        private string location;
        private string resourceGroupName;
        private Zone zone;
        private ZoneCollection zoneCollection;

        public ZoneTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
            location = "West US";
        }

        [OneTimeSetUp]
        public async Task SetupResource()
        {
            var client = GetArmClient();
            var subscription = await client.GetDefaultSubscriptionAsync();
            var resourceGroupCollection = subscription.GetResourceGroups();
            this.resourceGroupName = Recording.GenerateAssetName("Test-Dns-");
            await Helper.TryRegisterResourceGroupAsync(resourceGroupCollection, this.location, this.resourceGroupName);
            //Create Zone
            var resourceGroup = (await resourceGroupCollection.GetAsync(this.resourceGroupName)).Value;
            zoneCollection = resourceGroup.GetZones();
            zone = await (await zoneCollection.CreateOrUpdateAsync(TestEnvironment.TestDomain, new ZoneData("global"))).WaitForCompletionAsync();
            //Add records
            //A
            RecordSetData recordASetData = new RecordSetData() { TTL = 600 };
            recordASetData.ARecords.Add(new ARecord("127.0.0.1"));
            _ = await zone.GetRecordSetAs().CreateOrUpdateAsync("A", recordASetData);
        }

        [OneTimeTearDown]
        public void CleanupResourceGroup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        public async Task Get()
        {
            Zone getzone = await zone.GetAsync();
            Assert.AreEqual(TestEnvironment.TestDomain, getzone.Data.Name);
            Assert.AreEqual(1, zone.GetRecordSetAs().GetAllAsync().ToEnumerableAsync().Result.Count);
        }

        [TestCase]
        public async Task Update()
        {
            var zoneUpdate = new ZoneUpdate();
            zoneUpdate.Tags.Add("tag1", "value1");
            zone = await zone.UpdateAsync(zoneUpdate);
            Assert.AreEqual("value1", zone.Data.Tags["tag1"]);
        }

        [TestCase]
        public async Task Delete()
        {
            string dummyDomain = "DeleteTest.domain";
            Zone deleteZone = await (await zoneCollection.CreateOrUpdateAsync(dummyDomain, new ZoneData("global"))).WaitForCompletionAsync();
            Response result = (await deleteZone.DeleteAsync()).WaitForCompletionResponseAsync().Result;
            Assert.AreEqual(200, result.Status);
        }

        [TestCase]
        public async Task AddTag()
        {
            zone = await zone.AddTagAsync("addtag1", "addvalue1");
            Assert.AreEqual("addvalue1", zone.Data.Tags["addtag1"]);
        }

        [TestCase]
        public async Task SetTags()
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("settag1","setvalue1");
            tags.Add("settag2", "setvalue2");
            zone = await zone.SetTagsAsync(tags);
            Assert.AreEqual(2, zone.Data.Tags.Count);
            Assert.AreEqual("setvalue1", zone.Data.Tags["settag1"]);
            Assert.AreEqual("setvalue2", zone.Data.Tags["settag2"]);
        }

        [TestCase]
        public async Task RemoveTag()
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("settag1", "setvalue1");
            tags.Add("settag2", "setvalue2");
            zone = await zone.SetTagsAsync(tags);
            zone = await zone.RemoveTagAsync("settag1");
            Assert.AreEqual(1, zone.Data.Tags.Count);
            Assert.AreEqual("setvalue2", zone.Data.Tags["settag2"]);
        }

        //[TestCase]
        //global region only
        public async Task GetAvailableLocations()
        {
            var locationList = await zone.GetAvailableLocationsAsync();
            Assert.AreEqual(locationList.ToArray().Length, 1);
        }

        [TestCase]
        public async Task GetRecordSets()
        {
            var recordSet = (await zone.GetRecordSetsAsync().ToEnumerableAsync()).ToList();
            Assert.AreEqual(3, recordSet.Count);
            Assert.AreEqual("127.0.0.1", recordSet[2].ARecords[0].Ipv4Address);
        }

        [TestCase]
        public async Task GetAllRecordSets()
        {
            var recordSet = (await zone.GetAllRecordSetsAsync().ToEnumerableAsync()).ToList();
            Assert.AreEqual(3, recordSet.Count);
            Assert.AreEqual("127.0.0.1", recordSet[2].ARecords[0].Ipv4Address);
        }
    }
}
