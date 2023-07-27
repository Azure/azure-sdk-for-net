// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CdnWebApplicationFirewallPolicyOperationsTests : CdnManagementTestBase
    {
        public CdnWebApplicationFirewallPolicyOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string policyName = Recording.GenerateAssetName("Policy");
            CdnWebApplicationFirewallPolicyResource policy = await CreatePolicy(rg, policyName);
            await policy.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await policy.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task Update(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string policyName = Recording.GenerateAssetName("Policy");
            CdnWebApplicationFirewallPolicyResource policy = await CreatePolicy(rg, policyName);
            var lro = await policy.AddTagAsync("newTag", "newValue");
            CdnWebApplicationFirewallPolicyResource updatedPolicy = lro.Value;
            ResourceDataHelper.AssertPolicyUpdate(updatedPolicy, "newTag", "newValue");
        }
    }
}
