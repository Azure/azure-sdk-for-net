// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;

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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            FrontDoorEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdSecurityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            FrontDoorSecurityPolicyResource afdSecurityPolicy = await CreateAfdSecurityPolicy(afdProfile, afdEndpointInstance, afdSecurityPolicyName);
            await afdSecurityPolicy.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdSecurityPolicy.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName1 = Recording.GenerateAssetName("AFDEndpoint-");
            FrontDoorEndpointResource afdEndpointInstance1 = await CreateAfdEndpoint(afdProfile, afdEndpointName1);
            string afdSecurityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            FrontDoorSecurityPolicyResource afdSecurityPolicy = await CreateAfdSecurityPolicy(afdProfile, afdEndpointInstance1, afdSecurityPolicyName);
            string afdEndpointName2 = Recording.GenerateAssetName("AFDEndpoint-");
            FrontDoorEndpointResource afdEndpointInstance2 = await CreateAfdEndpoint(afdProfile, afdEndpointName2);
            FrontDoorSecurityPolicyPatch updateOptions = new FrontDoorSecurityPolicyPatch
            {
                Properties = new SecurityPolicyWebApplicationFirewall
                {
                    WafPolicy = new WritableSubResource
                    {
                        Id = new ResourceIdentifier("/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/azure_cli_test/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/azureCliTest")
                    }
                }
            };
            SecurityPolicyWebApplicationFirewallAssociation securityPolicyWebApplicationFirewallAssociation = new SecurityPolicyWebApplicationFirewallAssociation();
            securityPolicyWebApplicationFirewallAssociation.Domains.Add(new FrontDoorActivatedResourceInfo
            {
                Id = afdEndpointInstance1.Id
            });
            securityPolicyWebApplicationFirewallAssociation.Domains.Add(new FrontDoorActivatedResourceInfo
            {
                Id = afdEndpointInstance2.Id
            });
            securityPolicyWebApplicationFirewallAssociation.PatternsToMatch.Add("/*");
            ((SecurityPolicyWebApplicationFirewall)updateOptions.Properties).Associations.Add(securityPolicyWebApplicationFirewallAssociation);
            var lro = await afdSecurityPolicy.UpdateAsync(WaitUntil.Completed, updateOptions);
            FrontDoorSecurityPolicyResource updatedSecurityPolicy = lro.Value;
            ResourceDataHelper.AssertAfdSecurityPolicyUpdate(updatedSecurityPolicy, updateOptions);
        }
    }
}
