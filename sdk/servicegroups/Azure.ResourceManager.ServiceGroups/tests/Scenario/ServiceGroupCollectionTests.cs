// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ServiceGroups;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceGroups.Tests.Scenario
{
    public class ServiceGroupCollectionTests : ServiceGroupsManagementTestBase
    {
        public ServiceGroupCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var tenant = await Client.GetTenants().GetAllAsync().FirstOrDefaultAsync();
            var collection = tenant.GetServiceGroups();

            string serviceGroupName = Recording.GenerateAssetName("testsg");
            var data = new ServiceGroupData();

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, serviceGroupName, data);
            var serviceGroup = lro.Value;

            Assert.IsNotNull(serviceGroup);
            Assert.AreEqual(serviceGroupName, serviceGroup.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var tenant = await Client.GetTenants().GetAllAsync().FirstOrDefaultAsync();
            var collection = tenant.GetServiceGroups();

            string serviceGroupName = Recording.GenerateAssetName("testsg");
            var data = new ServiceGroupData();

            await collection.CreateOrUpdateAsync(WaitUntil.Completed, serviceGroupName, data);

            var serviceGroup = await collection.GetAsync(serviceGroupName);

            Assert.IsNotNull(serviceGroup);
            Assert.AreEqual(serviceGroupName, serviceGroup.Value.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var tenant = await Client.GetTenants().GetAllAsync().FirstOrDefaultAsync();
            var collection = tenant.GetServiceGroups();

            string serviceGroupName = Recording.GenerateAssetName("testsg");
            var data = new ServiceGroupData();

            await collection.CreateOrUpdateAsync(WaitUntil.Completed, serviceGroupName, data);

            bool exists = await collection.ExistsAsync(serviceGroupName);

            Assert.IsTrue(exists);
        }
    }
}
