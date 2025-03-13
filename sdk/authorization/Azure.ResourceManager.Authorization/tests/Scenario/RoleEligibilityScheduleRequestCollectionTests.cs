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
    public class RoleEligibilityScheduleRequestCollectionTests : AuthorizationManagementTestBase
    {
        public RoleEligibilityScheduleRequestCollectionTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public AuthorizationRoleDefinitionResource Definition { get; set; }

        private async Task<RoleEligibilityScheduleRequestCollection> GetRoleEligibilityScheduleRequestCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var definitionCollection = resourceGroup.GetAuthorizationRoleDefinitions();
            Definition = (await definitionCollection.GetAllAsync().ToEnumerableAsync()).FirstOrDefault();
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
                var roleEligibilityScheduleRequest2 = await collection.GetAsync(roleEligibilityScheduleRequest1.Data.Name);
                Assert.AreEqual(roleEligibilityScheduleRequest2.Value.Data.Name, roleEligibilityScheduleRequest1.Data.Name);
            }
        }

        [Ignore("Role assignment is not supported")]
        [RecordedTest]
        public async Task Create()
        {
            var collection = await GetRoleEligibilityScheduleRequestCollectionAsync();
            var data = new RoleEligibilityScheduleRequestData()
            {
                Condition = "@Resource[Microsoft.Storage/storageAccounts/blobServices/containers:ContainerName] StringEqualsIgnoreCase 'foo_storage_container'",
                ConditionVersion = "1.0",
                StartOn = DateTimeOffset.Parse("2020-09-09T21:31:27.91Z"),
                Duration = TypeFormatters.ParseTimeSpan("P365D", "P"),
                EndOn = null,
                ExpirationType = RoleManagementScheduleExpirationType.AfterDuration,
                RequestType = RoleManagementScheduleRequestType.AdminAssign,
                RoleDefinitionId = Definition.Id,
                PrincipalId = Guid.Parse(TestEnvironment.ClientId)
            };
            var roleName = "64caffb6-55c0-4deb-a585-68e948ea1ad6";
            var roleEligibilityScheduleRequest = await collection.CreateOrUpdateAsync(WaitUntil.Completed, roleName, data);
            Assert.AreEqual(roleEligibilityScheduleRequest.Value.Data.Name, roleName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetRoleEligibilityScheduleRequestCollectionAsync();
            var roleEligibilityScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(roleEligibilityScheduleRequests.Count, 0);
        }

        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetRoleEligibilityScheduleRequestCollectionAsync();
            var roleEligibilityScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            var roleEligibilityScheduleRequest = roleEligibilityScheduleRequests.FirstOrDefault();
            if (roleEligibilityScheduleRequest != null)
            {
                Assert.IsTrue(await collection.ExistsAsync(roleEligibilityScheduleRequest.Data.Name));
            }
        }
    }
}
