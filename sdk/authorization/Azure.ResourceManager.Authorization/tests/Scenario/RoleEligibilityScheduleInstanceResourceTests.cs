// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleEligibilityScheduleInstanceResourceTests : AuthorizationManagementTestBase
    {
        public RoleEligibilityScheduleInstanceResourceTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<RoleEligibilityScheduleInstanceCollection> GetRoleEligibilityScheduleInstanceCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetRoleEligibilityScheduleInstances();
        }

        [RecordedTest]
        [Ignore("InsufficientPermissions")]
        public async Task Get()
        {
            var collection = await GetRoleEligibilityScheduleInstanceCollectionAsync();
            var roleEligibilityScheduleInstances = await collection.GetAllAsync().ToEnumerableAsync();
            var roleEligibilityScheduleInstance1 = roleEligibilityScheduleInstances.FirstOrDefault();
            if (roleEligibilityScheduleInstance1 != null)
            {
                var roleEligibilityScheduleInstance2 = await roleEligibilityScheduleInstance1.GetAsync();
                Assert.AreEqual(roleEligibilityScheduleInstance2.Value.Data.Name, roleEligibilityScheduleInstance1.Data.Name);
            }
        }
    }
}
