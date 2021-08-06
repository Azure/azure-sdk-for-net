// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PolicyAssignmentOperationsTests : ResourceManagerTestBase
    {
        public PolicyAssignmentOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-D-");
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            PolicyAssignment policyAssignment = await Client.DefaultSubscription.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName, policyAssignmentData);
            await policyAssignment.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await policyAssignment.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        // test values
        private const string PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d";
    }
}
