﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string policyName = Recording.GenerateAssetName("Policy");
            CdnWebApplicationFirewallPolicy policy = await CreatePolicy(rg, policyName);
            await policy.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await policy.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string policyName = Recording.GenerateAssetName("Policy");
            CdnWebApplicationFirewallPolicy policy = await CreatePolicy(rg, policyName);
            CdnWebApplicationFirewallPolicyPatchParameters updateParameters = new CdnWebApplicationFirewallPolicyPatchParameters();
            updateParameters.Tags.Add("newTag", "newValue");
            var lro = await policy.UpdateAsync(updateParameters);
            CdnWebApplicationFirewallPolicy updatedPolicy = lro.Value;
            ResourceDataHelper.AssertPolicyUpdate(updatedPolicy, updateParameters);
        }
    }
}
