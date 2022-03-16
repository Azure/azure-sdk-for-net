// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_CdnWebApplicationFirewallPolicies_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
#endregion Manage_CdnWebApplicationFirewallPolicies_Namespaces
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests.Samples
{
    public class Sample2_ManagingCdnWebApplicationFirewallPolicies
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateCdnWebApplicationFirewallPolicies()
        {
            #region Snippet:Managing_CdnWebApplicationFirewallPolicies_CreateAWebApplicationFirewallPolicy
            // Get the cdn web application firewall policy collection from the specific resource group and create a firewall policy
            string policyName = "myPolicy";
            var input = new CdnWebApplicationFirewallPolicyData("Global", new CdnSku
            {
                Name = CdnSkuName.StandardMicrosoft
            });
            ArmOperation<CdnWebApplicationFirewallPolicy> lro = await resourceGroup.GetCdnWebApplicationFirewallPolicies().CreateOrUpdateAsync(WaitUntil.Completed, policyName, input);
            CdnWebApplicationFirewallPolicy policy = lro.Value;
            #endregion Snippet:Managing_CdnWebApplicationFirewallPolicies_CreateAWebApplicationFirewallPolicy
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListCdnWebApplicationFirewallPolicies()
        {
            #region Snippet:Managing_CdnWebApplicationFirewallPolicies_ListAllWebApplicationFirewallPolicies
            // First we need to get the cdn web application firewall policy collection from the specific resource group
            CdnWebApplicationFirewallPolicyCollection policyCollection = resourceGroup.GetCdnWebApplicationFirewallPolicies();
            // With GetAllAsync(), we can get a list of the policy in the collection
            AsyncPageable<CdnWebApplicationFirewallPolicy> response = policyCollection.GetAllAsync();
            await foreach (CdnWebApplicationFirewallPolicy policy in response)
            {
                Console.WriteLine(policy.Data.Name);
            }
            #endregion Snippet:Managing_CdnWebApplicationFirewallPolicies_ListAllWebApplicationFirewallPolicies
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteCdnWebApplicationFirewallPolicies()
        {
            #region Snippet:Managing_CdnWebApplicationFirewallPolicies_DeleteAWebApplicationFirewallPolicy
            // First we need to get the cdn web application firewall policy collection from the specific resource group
            CdnWebApplicationFirewallPolicyCollection policyCollection = resourceGroup.GetCdnWebApplicationFirewallPolicies();
            // Now we can get the policy with GetAsync()
            CdnWebApplicationFirewallPolicy policy = await policyCollection.GetAsync("myPolicy");
            // With DeleteAsync(), we can delete the policy
            await policy.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_CdnWebApplicationFirewallPolicies_DeleteAWebApplicationFirewallPolicy
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with a specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroup> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = lro.Value;

            this.resourceGroup = resourceGroup;
        }
    }
}
