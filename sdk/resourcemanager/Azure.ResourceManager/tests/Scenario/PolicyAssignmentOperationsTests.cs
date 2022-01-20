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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignment policyAssignment = await CreatePolicyAssignment(subscription, policyAssignmentName);
            await policyAssignment.DeleteAsync(true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await policyAssignment.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
