// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdSecurityPolicyOperationsTests : CdnManagementTestBase
    {
        public AfdSecurityPolicyOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.PremiumAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdSecurityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            AfdSecurityPolicy afdSecurityPolicy = await CreateAfdSecurityPolicy(afdProfile, afdEndpointInstance, afdSecurityPolicyName);
            await afdSecurityPolicy.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdSecurityPolicy.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdEndpointName1 = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance1 = await CreateAfdEndpoint(afdProfile, afdEndpointName1);
            string afdSecurityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            AfdSecurityPolicy afdSecurityPolicy = await CreateAfdSecurityPolicy(afdProfile, afdEndpointInstance1, afdSecurityPolicyName);
            string afdEndpointName2 = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance2 = await CreateAfdEndpoint(afdProfile, afdEndpointName2);
            SecurityPolicyProperties updateOptions = new SecurityPolicyProperties
            {
                Parameters = new SecurityPolicyWebApplicationFirewallParameters
                {
                    WafPolicy = new WritableSubResource
                    {
                        Id = new ResourceIdentifier("/subscriptions/f3d94233-a9aa-4241-ac82-2dfb63ce637a/resourceGroups/CdnTest/providers/Microsoft.Network/frontdoorWebApplicationFirewallPolicies/testAFDWaf")
                    }
                }
            };
            SecurityPolicyWebApplicationFirewallAssociation securityPolicyWebApplicationFirewallAssociation = new SecurityPolicyWebApplicationFirewallAssociation();
            securityPolicyWebApplicationFirewallAssociation.Domains.Add(new WritableSubResource
            {
                Id = afdEndpointInstance1.Id
            });
            securityPolicyWebApplicationFirewallAssociation.Domains.Add(new WritableSubResource
            {
                Id = afdEndpointInstance2.Id
            });
            securityPolicyWebApplicationFirewallAssociation.PatternsToMatch.Add("/*");
            ((SecurityPolicyWebApplicationFirewallParameters)updateOptions.Parameters).Associations.Add(securityPolicyWebApplicationFirewallAssociation);
            var lro = await afdSecurityPolicy.UpdateAsync(updateOptions);
            AfdSecurityPolicy updatedSecurityPolicy = lro.Value;
            ResourceDataHelper.AssertAfdSecurityPolicyUpdate(updatedSecurityPolicy, updateOptions);
        }
    }
}
