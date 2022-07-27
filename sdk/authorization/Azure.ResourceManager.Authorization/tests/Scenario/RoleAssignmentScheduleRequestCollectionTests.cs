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

        public RoleDefinitionResource Definition { get; set; }

        private async Task<RoleAssignmentScheduleRequestCollection> GetRoleAssignmentScheduleRequestCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var definitionCollection = resourceGroup.GetRoleDefinitions();
            Definition = (await definitionCollection.GetAllAsync().ToEnumerableAsync()).FirstOrDefault();
            return resourceGroup.GetRoleAssignmentScheduleRequests();
        }

        //[PlaybackOnly("This is a time senstive case")]
        [Ignore("The Role assignment does not exist")]
        [Test]
        public async Task Create()
        {
            var collection = await GetRoleAssignmentScheduleRequestCollectionAsync();
            var name = "fea7a502-9a96-4806-a26f-eee560e52045";
            var data = new RoleAssignmentScheduleRequestData()
            {
                PrincipalId = Guid.Parse(TestEnvironment.ClientId),
                RoleDefinitionId = Definition.Id,
                RequestType = RequestType.SelfActivate,
                LinkedRoleEligibilityScheduleId = new Guid("b1477448-2cc6-4ceb-93b4-54a202a89413"),
                ScheduleInfo = new RoleAssignmentScheduleInfo()
                {
                    StartOn = DateTimeOffset.Parse("2022-07-13T21:35:27.91Z"),
                    Expiration = new RoleAssignmentScheduleInfoExpiration()
                    {
                        RoleAssignmentExpirationType = RoleAssignmentScheduleType.AfterDuration,
                        EndOn = null,
                        Duration = TypeFormatters.ParseTimeSpan("PT8H", "P")
                    }
                },
                Condition = "@Resource[Microsoft.Storage/storageAccounts/blobServices/containers:ContainerName] StringEqualsIgnoreCase 'foo_storage_container'",
                ConditionVersion = "1.0"
            };
            var roleAssignmentScheduleRequest = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            Assert.AreEqual(roleAssignmentScheduleRequest.Value.Data.Name, name);
        }

        [Test]
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

        [Test]
        public async Task GetAll()
        {
            var collection = await GetRoleAssignmentScheduleRequestCollectionAsync();
            var roleAssignmentScheduleRequests = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(roleAssignmentScheduleRequests.Count, 0);
        }

        [Test]
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
