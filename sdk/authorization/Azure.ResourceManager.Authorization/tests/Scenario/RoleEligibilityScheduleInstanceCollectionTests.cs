// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleEligibilityScheduleInstanceCollectionTests : AuthorizationManagementTestBase
    {
        public RoleEligibilityScheduleInstanceCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<RoleEligibilityScheduleInstanceCollection> GetRoleEligibilityScheduleInstanceCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetRoleEligibilityScheduleInstances();
        }

        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetRoleEligibilityScheduleInstanceCollectionAsync();
            var roleEligibilityScheduleInstances = await collection.GetAllAsync().ToEnumerableAsync();
            var roleEligibilityScheduleInstance1 = roleEligibilityScheduleInstances.FirstOrDefault();
            if (roleEligibilityScheduleInstance1 != null)
            {
                var roleEligibilityScheduleInstance2 = await collection.GetAsync(roleEligibilityScheduleInstance1.Data.Name);
                Assert.AreEqual(roleEligibilityScheduleInstance2.Value.Data.Name, roleEligibilityScheduleInstance1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetRoleEligibilityScheduleInstanceCollectionAsync();
            var roleEligibilityScheduleInstances = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(roleEligibilityScheduleInstances.Count, 0);
        }

        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetRoleEligibilityScheduleInstanceCollectionAsync();
            var roleEligibilityScheduleInstances = await collection.GetAllAsync().ToEnumerableAsync();
            var roleEligibilityScheduleInstance = roleEligibilityScheduleInstances.FirstOrDefault();
            if (roleEligibilityScheduleInstance != null)
            {
                Assert.IsTrue(await collection.ExistsAsync(roleEligibilityScheduleInstance.Data.Name));
            }
        }
    }
}
