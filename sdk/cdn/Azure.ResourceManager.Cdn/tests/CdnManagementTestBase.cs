// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CdnManagementTestBase : ManagementRecordedTestBase<CdnManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected CdnManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected CdnManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(AzureLocation.WestUS);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ProfileResource> CreateCdnProfile(ResourceGroupResource rg, string profileName, CdnSkuName skuName)
        {
            ProfileData input = ResourceDataHelper.CreateProfileData(skuName);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(WaitUntil.Completed, profileName, input);
            return lro.Value;
        }

        protected async Task<ProfileResource> CreateAfdProfile(ResourceGroupResource rg, string profileName, CdnSkuName skuName)
        {
            ProfileData input = ResourceDataHelper.CreateAfdProfileData(skuName);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(WaitUntil.Completed, profileName, input);
            return lro.Value;
        }

        protected async Task<CdnEndpointResource> CreateCdnEndpoint(ProfileResource profile, string endpointName)
        {
            CdnEndpointData input = ResourceDataHelper.CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = ResourceDataHelper.CreateDeepCreatedOrigin();
            input.Origins.Add(deepCreatedOrigin);
            var lro = await profile.GetCdnEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, endpointName, input);
            return lro.Value;
        }

        protected async Task<CdnEndpointResource> CreateCdnEndpointWithOriginGroup(ProfileResource profile, string endpointName)
        {
            CdnEndpointData input = ResourceDataHelper.CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = ResourceDataHelper.CreateDeepCreatedOrigin();
            DeepCreatedOriginGroup deepCreatedOriginGroup = ResourceDataHelper.CreateDeepCreatedOriginGroup();
            deepCreatedOriginGroup.Origins.Add(new WritableSubResource
            {
                Id = new ResourceIdentifier($"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}")
            });
            input.Origins.Add(deepCreatedOrigin);
            input.OriginGroups.Add(deepCreatedOriginGroup);
            input.DefaultOriginGroupId = new ResourceIdentifier($"{profile.Id}/endpoints/{endpointName}/originGroups/{deepCreatedOriginGroup.Name}");
            var lro = await profile.GetCdnEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, endpointName, input);
            return lro.Value;
        }

        protected async Task<FrontDoorEndpointResource> CreateAfdEndpoint(ProfileResource profile, string endpointName)
        {
            FrontDoorEndpointData input = ResourceDataHelper.CreateAfdEndpointData();
            var lro = await profile.GetFrontDoorEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, endpointName, input);
            return lro.Value;
        }

        protected async Task<CdnOriginResource> CreateCdnOrigin(CdnEndpointResource endpoint, string originName)
        {
            CdnOriginData input = ResourceDataHelper.CreateOriginData();
            var lro = await endpoint.GetCdnOrigins().CreateOrUpdateAsync(WaitUntil.Completed, originName, input);
            return lro.Value;
        }

        protected async Task<FrontDoorOriginResource> CreateAfdOrigin(FrontDoorOriginGroupResource originGroup, string originName)
        {
            FrontDoorOriginData input = ResourceDataHelper.CreateAfdOriginData();
            var lro = await originGroup.GetFrontDoorOrigins().CreateOrUpdateAsync(WaitUntil.Completed, originName, input);
            return lro.Value;
        }

        protected async Task<CdnOriginGroupResource> CreateCdnOriginGroup(CdnEndpointResource endpoint, string originGroupName, string originName)
        {
            CdnOriginGroupData input = ResourceDataHelper.CreateOriginGroupData();
            input.Origins.Add(new WritableSubResource
            {
                Id = new ResourceIdentifier($"{endpoint.Id}/origins/{originName}")
            });
            var lro = await endpoint.GetCdnOriginGroups().CreateOrUpdateAsync(WaitUntil.Completed, originGroupName, input);
            return lro.Value;
        }

        protected async Task<FrontDoorOriginGroupResource> CreateAfdOriginGroup(ProfileResource profile, string originGroupName)
        {
            FrontDoorOriginGroupData input = ResourceDataHelper.CreateAfdOriginGroupData();
            var lro = await profile.GetFrontDoorOriginGroups().CreateOrUpdateAsync(WaitUntil.Completed, originGroupName, input);
            return lro.Value;
        }

        protected async Task<CdnCustomDomainResource> CreateCdnCustomDomain(CdnEndpointResource endpoint, string customDomainName, string hostName)
        {
            CdnCustomDomainCreateOrUpdateContent input = ResourceDataHelper.CreateCdnCustomDomainData(hostName);
            var lro = await endpoint.GetCdnCustomDomains().CreateOrUpdateAsync(WaitUntil.Completed, customDomainName, input);
            return lro.Value;
        }

        protected async Task<FrontDoorCustomDomainResource> CreateAfdCustomDomain(ProfileResource profile, string customDomainName, string hostName)
        {
            FrontDoorCustomDomainData input = ResourceDataHelper.CreateAfdCustomDomainData(hostName);
            var lro = await profile.GetFrontDoorCustomDomains().CreateOrUpdateAsync(WaitUntil.Completed, customDomainName, input);
            return lro.Value;
        }

        protected async Task<FrontDoorRuleSetResource> CreateAfdRuleSet(ProfileResource profile, string ruleSetName)
        {
            var lro = await profile.GetFrontDoorRuleSets().CreateOrUpdateAsync(WaitUntil.Completed, ruleSetName);
            return lro.Value;
        }

        protected async Task<FrontDoorRuleResource> CreateAfdRule(FrontDoorRuleSetResource ruleSet, string ruleName)
        {
            FrontDoorRuleData input = ResourceDataHelper.CreateAfdRuleData();
            DeliveryRuleCondition deliveryRuleCondition = ResourceDataHelper.CreateDeliveryRuleCondition();
            DeliveryRuleAction deliveryRuleAction = ResourceDataHelper.CreateDeliveryRuleOperation();
            input.Conditions.Add(deliveryRuleCondition);
            input.Actions.Add(deliveryRuleAction);
            var lro = await ruleSet.GetFrontDoorRules().CreateOrUpdateAsync(WaitUntil.Completed, ruleName, input);
            return lro.Value;
        }

        protected async Task<FrontDoorRouteResource> CreateAfdRoute(FrontDoorEndpointResource endpoint, string routeName, FrontDoorOriginGroupResource originGroup, FrontDoorRuleSetResource ruleSet)
        {
            FrontDoorRouteData input = ResourceDataHelper.CreateAfdRouteData(originGroup);
            input.RuleSets.Add(new WritableSubResource
            {
                Id = ruleSet.Id
            });
            input.PatternsToMatch.Add("/*");
            var lro = await endpoint.GetFrontDoorRoutes().CreateOrUpdateAsync(WaitUntil.Completed, routeName, input);
            return lro.Value;
        }

        protected async Task<FrontDoorSecurityPolicyResource> CreateAfdSecurityPolicy(ProfileResource profile, FrontDoorEndpointResource endpoint, string securityPolicyName)
        {
            FrontDoorSecurityPolicyData input = ResourceDataHelper.CreateAfdSecurityPolicyData(endpoint);
            SecurityPolicyWebApplicationFirewallAssociation securityPolicyWebApplicationFirewallAssociation = new SecurityPolicyWebApplicationFirewallAssociation();
            securityPolicyWebApplicationFirewallAssociation.Domains.Add(new FrontDoorActivatedResourceInfo
            {
                Id = endpoint.Id
            });
            securityPolicyWebApplicationFirewallAssociation.PatternsToMatch.Add("/*");
            ((SecurityPolicyWebApplicationFirewall)input.Properties).Associations.Add(securityPolicyWebApplicationFirewallAssociation);
            var lro = await profile.GetFrontDoorSecurityPolicies().CreateOrUpdateAsync(WaitUntil.Completed, securityPolicyName, input);
            return lro.Value;
        }

        protected async Task<FrontDoorSecretResource> CreateAfdSecret(ProfileResource profile, string secretName)
        {
            FrontDoorSecretData input = ResourceDataHelper.CreateAfdSecretData();
            var lro = await profile.GetFrontDoorSecrets().CreateOrUpdateAsync(WaitUntil.Completed, secretName, input);
            return lro.Value;
        }

        protected async Task<CdnWebApplicationFirewallPolicyResource> CreatePolicy(ResourceGroupResource rg, string policyName)
        {
            CdnWebApplicationFirewallPolicyData input = ResourceDataHelper.CreateCdnWebApplicationFirewallPolicyData();
            var lro = await rg.GetCdnWebApplicationFirewallPolicies().CreateOrUpdateAsync(WaitUntil.Completed, policyName, input);
            return lro.Value;
        }
    }
}
