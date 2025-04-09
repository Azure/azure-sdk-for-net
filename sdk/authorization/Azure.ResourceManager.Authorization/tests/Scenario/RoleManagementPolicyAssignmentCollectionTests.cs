// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleManagementPolicyAssignmentCollectionTests : AuthorizationManagementTestBase
    {
        public RoleManagementPolicyAssignmentCollectionTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Ignore("Not implemented exception")]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var policyAssignmentCollection = resourceGroup.GetRoleManagementPolicyAssignments();
            var definitionCollection = resourceGroup.GetAuthorizationRoleDefinitions();
            var policyCollection = resourceGroup.GetRoleManagementPolicies();
            var definition = (await definitionCollection.GetAllAsync().ToEnumerableAsync()).FirstOrDefault();
            var policy = (await policyCollection.GetAllAsync().ToEnumerableAsync()).FirstOrDefault();
            var data = new RoleManagementPolicyAssignmentData()
            {
                Scope = resourceGroup.Data.Id,
                RoleDefinitionId = definition.Data.Id,
                PolicyId = policy.Data.Id
            };

            var name = definition.Data.Name + "_" + policy.Data.Name;
            var lro = await policyAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            var policyAssignment = lro.Value;
            Assert.AreEqual(name, policyAssignment.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var policyAssignmentCollection = resourceGroup.GetRoleManagementPolicyAssignments();
            var policyAssignmentList = await policyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(policyAssignmentList.Count, 0);
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var policyAssignmentCollection = resourceGroup.GetRoleManagementPolicyAssignments();
            var policyAssignmentList = await policyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            var policyAssignment1 = policyAssignmentList.FirstOrDefault();
            if (policyAssignment1 != null)
            {
                var policyAssignment2 = await policyAssignmentCollection.GetAsync(policyAssignment1.Data.Name);
                Assert.AreEqual(policyAssignment2.Value.Data.Name, policyAssignment1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task Exists()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var policyAssignmentCollection = resourceGroup.GetRoleManagementPolicyAssignments();
            var policyAssignmentList = await policyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            var policyAssignment1 = policyAssignmentList.FirstOrDefault();
            if (policyAssignment1 != null)
            {
                var policyAssignment2 = await policyAssignmentCollection.ExistsAsync(policyAssignment1.Data.Name);
                Assert.IsTrue(policyAssignment2.Value);
            }
        }
    }
}
