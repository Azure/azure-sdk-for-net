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
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignment policyAssignment = await CreatePolicyAssignment(rg, policyAssignmentName);
            string policyExemptionName = Recording.GenerateAssetName("polExemp-");
            PolicyExemption policyExemption = await CreatePolicyExemption(rg, policyAssignment, policyExemptionName);
            await policyExemption.DeleteAsync(true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await policyExemption.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
