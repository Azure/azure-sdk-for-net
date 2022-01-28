﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CdnWebApplicationFirewallPolicyCollectionTests : CdnManagementTestBase
    {
        public CdnWebApplicationFirewallPolicyCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string policyName = Recording.GenerateAssetName("Policy");
            CdnWebApplicationFirewallPolicy policy = await CreatePolicy(rg, policyName);
            Assert.AreEqual(policyName, policy.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetCdnWebApplicationFirewallPolicies().CreateOrUpdateAsync(true, null, policy.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetCdnWebApplicationFirewallPolicies().CreateOrUpdateAsync(true, policyName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string policyName = Recording.GenerateAssetName("Policy");
            _ = await CreatePolicy(rg, policyName);
            int count = 0;
            await foreach (var tempPolicy in rg.GetCdnWebApplicationFirewallPolicies().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string policyName = Recording.GenerateAssetName("Policy");
            CdnWebApplicationFirewallPolicy policy = await CreatePolicy(rg, policyName);
            CdnWebApplicationFirewallPolicy getPolicy = await rg.GetCdnWebApplicationFirewallPolicies().GetAsync(policyName);
            ResourceDataHelper.AssertValidPolicy(policy, getPolicy);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetCdnWebApplicationFirewallPolicies().GetAsync(null));
        }
    }
}
