// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.NewRelicObservability.Tests
{
    public class MonitorResourceCollectionTests : NewrelicManagementTestBase
    {
        public MonitorResourceCollectionTests(bool async)
            : base(async)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string monitorName = Recording.GenerateAssetName("testNR-");
            NewRelicMonitorResource monitorResource = await CreateMonitorResourceAsync(monitorName);
            Assert.AreEqual(monitorName, monitorResource.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateUsingLinkWithOrg()
        {
            string monitorName = Recording.GenerateAssetName("testNR-LOP-");
            NewRelicMonitorResource monitorResource = await CreateMonitorResourceLinkWithOrgWithPlanAsync(monitorName);
            Assert.AreEqual(monitorName, monitorResource.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetNewRelicMonitorResources_MonitorsListBySubscription()
        {
            // invoke the operation and iterate over the result
            await foreach (NewRelicMonitorResource item in DefaultSubscription.GetNewRelicMonitorResourcesAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                NewRelicMonitorResourceData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        /*[TestCase]
        [RecordedTest]
        public async Task Delete_Monitors()
        {
            // Create
            string monitorName = Recording.GenerateAssetName("testNR-");
            NewRelicMonitorResource monitorResource = await CreateMonitorResourceAsync(monitorName);
            Assert.AreEqual(monitorName, monitorResource.Data.Name);

            // invoke the operation to Delete
            string userEmail = "viprayjain@microsoft.com";
            await monitorResource.DeleteAsync(WaitUntil.Completed, userEmail);
            Console.WriteLine($"Succeeded");
        }*/

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetMonitorResourceCollectionAsync();

            string monitorName = Recording.GenerateAssetName("testNR-");
            var input = GetMonitorInput();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);
            NewRelicMonitorResource monitorResource1 = lro.Value;

            NewRelicMonitorResource monitorResource2 = await collection.GetAsync(monitorName);

            Assert.AreEqual(monitorResource1.Data.Name, monitorResource2.Data.Name);
            Assert.AreEqual(monitorResource1.Data.Id, monitorResource2.Data.Id);
            Assert.AreEqual(monitorResource1.Data.ResourceType, monitorResource2.Data.ResourceType);
            Assert.AreEqual(monitorResource1.Data.Location, monitorResource2.Data.Location);
            Assert.AreEqual(monitorResource1.Data.Tags, monitorResource2.Data.Tags);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetMonitorResourceCollectionAsync();

            string monitorName = Recording.GenerateAssetName("testNR-");
            var input = GetMonitorInput();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);

            Assert.IsTrue(await collection.ExistsAsync(monitorName));
            Assert.IsFalse(await collection.ExistsAsync(monitorName + "1"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetMonitorResourceCollectionAsync();

            string monitorName = Recording.GenerateAssetName("testNR-");
            var input = GetMonitorInput();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);

            int count = 0;
            await foreach (var monitor in collection.GetAllAsync())
            {
                count++;
                Console.WriteLine(count);
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                NewRelicMonitorResourceData resourceData = monitor.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
            Assert.GreaterOrEqual(count, 1);
        }
    }
}
