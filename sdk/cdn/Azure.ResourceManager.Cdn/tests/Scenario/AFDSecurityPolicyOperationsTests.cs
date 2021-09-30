﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AFDSecurityPolicyOperationsTests : CdnManagementTestBase
    {
        public AFDSecurityPolicyOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.PremiumAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            string securityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            SecurityPolicy securityPolicy = await CreateSecurityPolicy(AFDProfile, AFDEndpointInstance, securityPolicyName);
            await securityPolicy.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await securityPolicy.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Not Ready")]
        public async Task Update()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.PremiumAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            string securityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            SecurityPolicy securityPolicy = await CreateSecurityPolicy(AFDProfile, AFDEndpointInstance, securityPolicyName);
            SecurityPolicyProperties updateParameters = new SecurityPolicyProperties
            {
                Parameters = new SecurityPolicyWebApplicationFirewallParameters
                {
                    WafPolicy = new ResourceReference(id: "/subscriptions/f3d94233-a9aa-4241-ac82-2dfb63ce637a/resourceGroups/CdnTest/providers/Microsoft.Network/frontdoorWebApplicationFirewallPolicies/testAFDWaf")
                }
            };
            SecurityPolicyWebApplicationFirewallAssociation securityPolicyWebApplicationFirewallAssociation = new SecurityPolicyWebApplicationFirewallAssociation();
            securityPolicyWebApplicationFirewallAssociation.Domains.Add(new ResourceReference(AFDEndpointInstance.Id));
            securityPolicyWebApplicationFirewallAssociation.PatternsToMatch.Add("/videos");
            ((SecurityPolicyWebApplicationFirewallParameters)updateParameters.Parameters).Associations.Add(securityPolicyWebApplicationFirewallAssociation);
            var lro = await securityPolicy.UpdateAsync(updateParameters);
            SecurityPolicy updatedSecurityPolicy = lro.Value;
            ResourceDataHelper.AssertSecurityPolicy(updatedSecurityPolicy, updateParameters);
        }
    }
}
