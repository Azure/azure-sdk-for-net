// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Authorization.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleAssignmentScheduleRequestCollectionTests : AuthorizationManagementTestBase
    {
        public RoleAssignmentScheduleRequestCollectionTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public AuthorizationRoleDefinitionResource Definition { get; set; }

        private async Task<RoleAssignmentScheduleRequestCollection> GetRoleAssignmentScheduleRequestCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var definitionCollection = resourceGroup.GetAuthorizationRoleDefinitions();
            Definition = (await definitionCollection.GetAllAsync().ToEnumerableAsync()).FirstOrDefault();
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
                var roleAssignmentScheduleRequest2 = await collection.GetAsync(roleAssignmentScheduleRequest1.Data.Name);
                Assert.AreEqual(roleAssignmentScheduleRequest2.Value.Data.Name, roleAssignmentScheduleRequest1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetRoleAssignmentScheduleRequestCollectionAsync();
            var roleAssignmentScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(roleAssignmentScheduleRequests.Count, 0);
        }

        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetRoleAssignmentScheduleRequestCollectionAsync();
            var roleAssignmentScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            var roleAssignmentScheduleRequest = roleAssignmentScheduleRequests.FirstOrDefault();
            if (roleAssignmentScheduleRequest != null)
            {
                var result = await collection.ExistsAsync(roleAssignmentScheduleRequest.Data.Name);
                Assert.IsTrue(result);
            }
        }
    }
}
