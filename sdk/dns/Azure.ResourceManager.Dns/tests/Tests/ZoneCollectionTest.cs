// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Dns.Tests;
using Azure.ResourceManager.Dns;
using System.Linq;
using System;
using System.IO;
using System.Collections.Generic;

namespace Azure.Management.Dns.Tests
{
    public class ZoneCollectionTest : DnsManagementClientBase
    {
        private string location;
        private string resourceGroupName;
        private ResourceGroup resourceGroup;
        private ZoneCollection zoneCollection;

        public ZoneCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
            location = "West US";
            resourceGroup = null;
        }

        [SetUp]
        public async Task SetupResource()
        {
            var client = GetArmClient();
            var subscription = await client.GetDefaultSubscriptionAsync();
            var resourceGroupCollection = subscription.GetResourceGroups();
            this.resourceGroupName = Recording.GenerateAssetName("Test-Dns-");
            await Helper.TryRegisterResourceGroupAsync(resourceGroupCollection, this.location, this.resourceGroupName);
            //Create Zone
            resourceGroup = (await resourceGroupCollection.GetAsync(this.resourceGroupName)).Value;
            zoneCollection = resourceGroup.GetZones();
            //Create Zone for Get()s
            _ = await (await zoneCollection.CreateOrUpdateAsync(TestEnvironment.TestDomain, new ZoneData("global"))).WaitForCompletionAsync();
        }

        [OneTimeTearDown]
        public void CleanupResourceGroup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        public async Task CreatOrUpdate()
        {
            string dummyDomain = "test.domain";
            Zone createZone = await (await zoneCollection.CreateOrUpdateAsync(dummyDomain, new ZoneData("global"))).WaitForCompletionAsync();
            Assert.AreEqual(dummyDomain, createZone.Data.Name);
        }

        [TestCase]
        public async Task Get()
        {
            Zone zone = await zoneCollection.GetAsync(TestEnvironment.TestDomain);
            Assert.AreEqual(TestEnvironment.TestDomain, zone.Data.Name);
        }

        [TestCase]
        public async Task GetIfExists()
        {
            Zone zone = await zoneCollection.GetAsync(TestEnvironment.TestDomain);
            Assert.AreEqual(TestEnvironment.TestDomain, zone.Data.Name);
            var nullzone = await zoneCollection.GetIfExistsAsync(TestEnvironment.TestDomain + "dummy");
            Assert.AreEqual(404 , nullzone.GetRawResponse().Status);
        }

        [TestCase]
        public async Task CheckIfExists()
        {
            bool result = await zoneCollection.ExistsAsync(TestEnvironment.TestDomain);
            Assert.IsTrue(result);
            bool falseresult = await zoneCollection.ExistsAsync(TestEnvironment.TestDomain + "dummy");
            Assert.IsFalse(falseresult);
        }

        [TestCase]
        public async Task GetAll()
        {
            var result = (await zoneCollection.GetAllAsync().ToEnumerableAsync()).ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(TestEnvironment.TestDomain,result[0].Data.Name);
        }

        [TestCase]
        public async Task GetAllAsGenericResources()
        {
            var result = (await zoneCollection.GetAllAsGenericResourcesAsync("Zone").ToEnumerableAsync()).ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(TestEnvironment.TestDomain, result[0].Data.Name);
        }
    }
}
