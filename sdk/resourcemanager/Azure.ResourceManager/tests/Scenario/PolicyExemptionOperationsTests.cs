// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PolicyExemptionOperationsTests : ResourceManagerTestBase
    {
        public PolicyExemptionOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Live)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            string policyAssignmentName = Recording.GenerateAssetName("testPolAssign-");
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            PolicyAssignment policyAssignment = await rg.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName, policyAssignmentData);
            string policyExemptionName = Recording.GenerateAssetName("polExemp-D-");
            PolicyExemptionData policyExemptionData = new PolicyExemptionData(policyAssignment.Id, new ExemptionCategory("Waiver"));
            PolicyExemption policyExemption = await rg.GetPolicyExemptions().CreateOrUpdateAsync(policyExemptionName, policyExemptionData);
            await policyExemption.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await policyExemption.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        // test values
        private const string PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d";
    }
}
