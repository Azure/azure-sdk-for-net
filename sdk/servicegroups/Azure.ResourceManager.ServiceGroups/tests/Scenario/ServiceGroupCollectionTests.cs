// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
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
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                var collection = tenant.GetServiceGroups();

                string serviceGroupName = Recording.GenerateAssetName("testsg");
                var data = new ServiceGroupData();

                var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, serviceGroupName, data);
                var serviceGroup = lro.Value;

                Assert.IsNotNull(serviceGroup);
                Assert.AreEqual(serviceGroupName, serviceGroup.Data.Name);
                break;
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                var collection = tenant.GetServiceGroups();

                string serviceGroupName = Recording.GenerateAssetName("testsg");
                var data = new ServiceGroupData();

                await collection.CreateOrUpdateAsync(WaitUntil.Completed, serviceGroupName, data);

                var serviceGroup = await collection.GetAsync(serviceGroupName);

                Assert.IsNotNull(serviceGroup);
                Assert.AreEqual(serviceGroupName, serviceGroup.Value.Data.Name);
                break;
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                var collection = tenant.GetServiceGroups();

                string serviceGroupName = Recording.GenerateAssetName("testsg");
                var data = new ServiceGroupData();

                await collection.CreateOrUpdateAsync(WaitUntil.Completed, serviceGroupName, data);

                bool exists = await collection.ExistsAsync(serviceGroupName);

                Assert.IsTrue(exists);
                break;
            }
        }
    }
}
