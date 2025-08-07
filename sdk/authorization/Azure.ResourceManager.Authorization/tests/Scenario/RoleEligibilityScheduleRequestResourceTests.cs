// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleEligibilityScheduleRequestResourceTests : AuthorizationManagementTestBase
    {
        public RoleEligibilityScheduleRequestResourceTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<RoleEligibilityScheduleRequestCollection> GetRoleEligibilityScheduleRequestCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetRoleEligibilityScheduleRequests();
        }

        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetRoleEligibilityScheduleRequestCollectionAsync();
            var roleEligibilityScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            var roleEligibilityScheduleRequest1 = roleEligibilityScheduleRequests.FirstOrDefault();
            if (roleEligibilityScheduleRequest1 != null)
            {
                var roleEligibilityScheduleRequest2 = await roleEligibilityScheduleRequest1.GetAsync();
                Assert.AreEqual(roleEligibilityScheduleRequest2.Value.Data.Name, roleEligibilityScheduleRequest1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task Update()
        {
            var collection = await GetRoleEligibilityScheduleRequestCollectionAsync();
            var roleEligibilityScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            var roleEligibilityScheduleRequest1 = roleEligibilityScheduleRequests.FirstOrDefault();
            if (roleEligibilityScheduleRequest1 != null)
            {
                var data = roleEligibilityScheduleRequest1.Data;
                var roleEligibilityScheduleRequest2 = await roleEligibilityScheduleRequest1.UpdateAsync(WaitUntil.Completed, data);
                Assert.AreEqual(roleEligibilityScheduleRequest2.Value.Data.Name, roleEligibilityScheduleRequest1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task Validate()
        {
            var collection = await GetRoleEligibilityScheduleRequestCollectionAsync();
            var roleEligibilityScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            var roleEligibilityScheduleRequest1 = roleEligibilityScheduleRequests.FirstOrDefault();
            if (roleEligibilityScheduleRequest1 != null)
            {
                var data = roleEligibilityScheduleRequest1.Data;
                var roleEligibilityScheduleRequest2 = await roleEligibilityScheduleRequest1.ValidateAsync(data);
                Assert.AreEqual(roleEligibilityScheduleRequest2.Value.Data.Name, roleEligibilityScheduleRequest1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task Cancel()
        {
            var collection = await GetRoleEligibilityScheduleRequestCollectionAsync();
            var roleEligibilityScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            var roleEligibilityScheduleRequest1 = roleEligibilityScheduleRequests.FirstOrDefault();
            if (roleEligibilityScheduleRequest1 != null)
            {
                Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await roleEligibilityScheduleRequest1.CancelAsync();
                });
            }
        }
    }
}
