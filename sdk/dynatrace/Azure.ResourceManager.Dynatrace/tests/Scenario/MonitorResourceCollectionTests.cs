// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Dynatrace.Tests
{
    public class MonitorResourceCollectionTests : DynatraceManagementTestBase
    {
        public MonitorResourceCollectionTests(bool async)
            : base(async)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("The test subscription cannot purchase the SaaS because the payment instrument is invalid")]
        public async Task CreateOrUpdate()
        {
            string monitorName = Recording.GenerateAssetName("testDT-");
            DynatraceMonitorResource monitorResource = await CreateMonitorResourceAsync(monitorName);
            Assert.AreEqual(monitorName, monitorResource.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("The test subscription cannot purchase the SaaS because the payment instrument is invalid")]
        public async Task Get()
        {
            var collection = await GetMonitorResourceCollectionAsync();

            string monitorName = Recording.GenerateAssetName("testDT-");
            var input = GetMonitorInput();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);
            DynatraceMonitorResource monitorResource1 = lro.Value;

            DynatraceMonitorResource monitorResource2 = await collection.GetAsync(monitorName);

            Assert.AreEqual(monitorResource1.Data.Name, monitorResource2.Data.Name);
            Assert.AreEqual(monitorResource1.Data.Id, monitorResource2.Data.Id);
            Assert.AreEqual(monitorResource1.Data.ResourceType, monitorResource2.Data.ResourceType);
            Assert.AreEqual(monitorResource1.Data.Location, monitorResource2.Data.Location);
            Assert.AreEqual(monitorResource1.Data.Tags, monitorResource2.Data.Tags);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("The test subscription cannot purchase the SaaS because the payment instrument is invalid")]
        public async Task Exists()
        {
            var collection = await GetMonitorResourceCollectionAsync();

            string monitorName = Recording.GenerateAssetName("testDT-");
            var input = GetMonitorInput();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);

            Assert.IsTrue(await collection.ExistsAsync(monitorName));
            Assert.IsFalse(await collection.ExistsAsync(monitorName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        [Ignore("The test subscription cannot purchase the SaaS because the payment instrument is invalid")]
        public async Task GetAll()
        {
            var collection = await GetMonitorResourceCollectionAsync();

            string monitorName = Recording.GenerateAssetName("testDT-");
            var input = GetMonitorInput();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);

            int count = 0;
            await foreach (var monitor in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }
    }
}
