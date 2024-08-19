// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    // NOTE: comment these out because this resource comes from a preview swagger
    //public class PolicyExemptionOperationsTests : ResourceManagerTestBase
    //{
    //    public PolicyExemptionOperationsTests(bool isAsync)
    //        : base(isAsync)//, RecordedTestMode.Record)
    //    {
    //    }

    //    [TestCase]
    //    [RecordedTest]
    //    public async Task Delete()
    //    {
    //        SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
    //        string rgName = Recording.GenerateAssetName("testRg-");
    //        ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
    //        string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
    //        PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(rg, policyAssignmentName);
    //        string policyExemptionName = Recording.GenerateAssetName("polExemp-");
    //        PolicyExemptionResource policyExemption = await CreatePolicyExemption(rg, policyAssignment, policyExemptionName);
    //        await policyExemption.DeleteAsync(WaitUntil.Completed);
    //        var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await policyExemption.GetAsync());
    //        Assert.AreEqual(404, ex.Status);
    //    }
    //}
}
