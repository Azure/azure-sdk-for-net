// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleAssignmentScheduleRequestResourceTests : AuthorizationManagementTestBase
    {
        public RoleAssignmentScheduleRequestResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<RoleAssignmentScheduleRequestCollection> GetRoleAssignmentScheduleRequestCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetRoleAssignmentScheduleRequests();
        }

        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetRoleAssignmentScheduleRequestCollectionAsync();
            var roleAssignmentScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            var roleAssignmentScheduleRequest1 = roleAssignmentScheduleRequests.FirstOrDefault();
            if (roleAssignmentScheduleRequest1 != null)
            {
                var roleAssignmentScheduleRequest2 = await roleAssignmentScheduleRequest1.GetAsync();
                Assert.AreEqual(roleAssignmentScheduleRequest2.Value.Data.Name, roleAssignmentScheduleRequest1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task Update()
        {
            var collection = await GetRoleAssignmentScheduleRequestCollectionAsync();
            var roleAssignmentScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            var roleAssignmentScheduleRequest1 = roleAssignmentScheduleRequests.FirstOrDefault();
            if (roleAssignmentScheduleRequest1 != null)
            {
                var data = roleAssignmentScheduleRequest1.Data;
                var roleAssignmentScheduleRequest2 = await roleAssignmentScheduleRequest1.UpdateAsync(WaitUntil.Completed, data);
                Assert.AreEqual(roleAssignmentScheduleRequest2.Value.Data.Name, roleAssignmentScheduleRequest1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task Validate()
        {
            var collection = await GetRoleAssignmentScheduleRequestCollectionAsync();
            var roleAssignmentScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            var roleAssignmentScheduleRequest1 = roleAssignmentScheduleRequests.FirstOrDefault();
            if (roleAssignmentScheduleRequest1 != null)
            {
                var data = roleAssignmentScheduleRequest1.Data;
                var roleAssignmentScheduleRequest2 = await roleAssignmentScheduleRequest1.ValidateAsync(data);
                Assert.AreEqual(roleAssignmentScheduleRequest2.Value.Data.Name, roleAssignmentScheduleRequest1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task Cancel()
        {
            var collection = await GetRoleAssignmentScheduleRequestCollectionAsync();
            var roleAssignmentScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            var roleAssignmentScheduleRequest1 = roleAssignmentScheduleRequests.FirstOrDefault();
            if (roleAssignmentScheduleRequest1 != null)
            {
                Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await roleAssignmentScheduleRequest1.CancelAsync();
                });
            }
        }
    }
}
