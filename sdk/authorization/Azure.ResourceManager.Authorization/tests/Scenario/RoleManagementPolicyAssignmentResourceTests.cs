// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class RoleManagementPolicyAssignmentResourceTests : AuthorizationManagementTestBase
    {
        public RoleManagementPolicyAssignmentResourceTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
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
                var policyAssignment2 = await policyAssignment1.GetAsync();
                Assert.AreEqual(policyAssignment2.Value.Data.Name, policyAssignment1.Data.Name);
            }
        }

        [Ignore("Not implemented exception")]
        [RecordedTest]
        public async Task Update()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var policyAssignmentCollection = resourceGroup.GetRoleManagementPolicyAssignments();
            var policyAssignmentList = await policyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            var policyAssignment1 = policyAssignmentList.FirstOrDefault();
            if (policyAssignment1 != null)
            {
                var data = policyAssignment1.Data;
                var policyAssignment2 = await policyAssignment1.UpdateAsync(WaitUntil.Completed, data);
                Assert.AreEqual(policyAssignment2.Value.Data.Name, policyAssignment1.Data.Name);
            }
        }
    }
}
