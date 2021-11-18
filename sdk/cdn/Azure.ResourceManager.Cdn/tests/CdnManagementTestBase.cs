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

        protected async Task<ResourceGroup> CreateResourceGroup(Subscription subscription, string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(Location.WestUS);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, input);
            return lro.Value;
        }

        protected async Task<Profile> CreateProfile(ResourceGroup rg, string profileName, SkuName skuName)
        {
            ProfileData input = ResourceDataHelper.CreateProfileData(skuName);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, input);
            return lro.Value;
        }

        protected async Task<Profile> CreateAFDProfile(ResourceGroup rg, string profileName, SkuName skuName)
        {
            ProfileData input = ResourceDataHelper.CreateAFDProfileData(skuName);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, input);
            return lro.Value;
        }

        protected async Task<Endpoint> CreateEndpoint(Profile profile, string endpointName)
        {
            EndpointData input = ResourceDataHelper.CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = ResourceDataHelper.CreateDeepCreatedOrigin();
            input.Origins.Add(deepCreatedOrigin);
            var lro = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, input);
            return lro.Value;
        }

        protected async Task<Endpoint> CreateEndpointWithOriginGroup(Profile profile, string endpointName)
        {
            EndpointData input = ResourceDataHelper.CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = ResourceDataHelper.CreateDeepCreatedOrigin();
            DeepCreatedOriginGroup deepCreatedOriginGroup = ResourceDataHelper.CreateDeepCreatedOriginGroup();
            deepCreatedOriginGroup.Origins.Add(new WritableSubResource
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}"
            });
            input.Origins.Add(deepCreatedOrigin);
            input.OriginGroups.Add(deepCreatedOriginGroup);
            input.DefaultOriginGroup = new EndpointPropertiesUpdateParametersDefaultOriginGroup
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/originGroups/{deepCreatedOriginGroup.Name}"
            };
            var lro = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, input);
            return lro.Value;
        }

        protected async Task<AFDEndpoint> CreateAFDEndpoint(Profile profile, string endpointName)
        {
            AFDEndpointData input = ResourceDataHelper.CreateAFDEndpointData();
            var lro = await profile.GetAFDEndpoints().CreateOrUpdateAsync(endpointName, input);
            return lro.Value;
        }

        protected async Task<Origin> CreateOrigin(Endpoint endpoint, string originName)
        {
            OriginData input = ResourceDataHelper.CreateOriginData();
            var lro = await endpoint.GetOrigins().CreateOrUpdateAsync(originName, input);
            return lro.Value;
        }

        protected async Task<AFDOrigin> CreateAFDOrigin(AFDOriginGroup originGroup, string originName)
        {
            AFDOriginData input = ResourceDataHelper.CreateAFDOriginData();
            var lro = await originGroup.GetAFDOrigins().CreateOrUpdateAsync(originName, input);
            return lro.Value;
        }

        protected async Task<OriginGroup> CreateOriginGroup(Endpoint endpoint, string originGroupName, string originName)
        {
            OriginGroupData input = ResourceDataHelper.CreateOriginGroupData();
            input.Origins.Add(new WritableSubResource
            {
                Id = $"{endpoint.Id}/origins/{originName}"
            });
            var lro = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, input);
            return lro.Value;
        }

        protected async Task<AFDOriginGroup> CreateAFDOriginGroup(Profile profile, string originGroupName)
        {
            AFDOriginGroupData input = ResourceDataHelper.CreateAFDOriginGroupData();
            var lro = await profile.GetAFDOriginGroups().CreateOrUpdateAsync(originGroupName, input);
            return lro.Value;
        }

        protected async Task<CustomDomain> CreateCustomDomain(Endpoint endpoint, string customDomainName, string hostName)
        {
            CustomDomainParameters input = ResourceDataHelper.CreateCustomDomainParameters(hostName);
            var lro = await endpoint.GetCustomDomains().CreateOrUpdateAsync(customDomainName, input);
            return lro.Value;
        }

        protected async Task<AFDDomain> CreateAFDCustomDomain(Profile profile, string customDomainName, string hostName)
        {
            AFDDomainData input = ResourceDataHelper.CreateAFDCustomDomainData(hostName);
            var lro = await profile.GetAFDDomains().CreateOrUpdateAsync(customDomainName, input);
            return lro.Value;
        }

        protected async Task<RuleSet> CreateRuleSet(Profile profile, string ruleSetName)
        {
            var lro = await profile.GetRuleSets().CreateOrUpdateAsync(ruleSetName);
            return lro.Value;
        }

        protected async Task<Rule> CreateRule(RuleSet ruleSet, string ruleName)
        {
            RuleData input = ResourceDataHelper.CreateRuleData();
            DeliveryRuleCondition deliveryRuleCondition = ResourceDataHelper.CreateDeliveryRuleCondition();
            DeliveryRuleActionAutoGenerated deliveryRuleAction = ResourceDataHelper.CreateDeliveryRuleOperation();
            input.Conditions.Add(deliveryRuleCondition);
            input.Actions.Add(deliveryRuleAction);
            var lro = await ruleSet.GetRules().CreateOrUpdateAsync(ruleName, input);
            return lro.Value;
        }

        protected async Task<Route> CreateRoute(AFDEndpoint endpoint, string routeName, AFDOriginGroup originGroup, RuleSet ruleSet)
        {
            RouteData input = ResourceDataHelper.CreateRouteData(originGroup);
            input.RuleSets.Add(new WritableSubResource
            {
                Id = ruleSet.Id
            });
            input.PatternsToMatch.Add("/*");
            var lro = await endpoint.GetRoutes().CreateOrUpdateAsync(routeName, input);
            return lro.Value;
        }

        protected async Task<SecurityPolicy> CreateSecurityPolicy(Profile profile, AFDEndpoint endpoint, string securityPolicyName)
        {
            SecurityPolicyData input = ResourceDataHelper.CreateSecurityPolicyData(endpoint);
            SecurityPolicyWebApplicationFirewallAssociation securityPolicyWebApplicationFirewallAssociation = new SecurityPolicyWebApplicationFirewallAssociation();
            securityPolicyWebApplicationFirewallAssociation.Domains.Add(new WritableSubResource
            {
                Id = endpoint.Id
            });
            securityPolicyWebApplicationFirewallAssociation.PatternsToMatch.Add("/*");
            ((SecurityPolicyWebApplicationFirewallParameters)input.Parameters).Associations.Add(securityPolicyWebApplicationFirewallAssociation);
            var lro = await profile.GetSecurityPolicies().CreateOrUpdateAsync(securityPolicyName, input);
            return lro.Value;
        }

        protected async Task<Secret> CreateSecret(Profile profile, string secretName)
        {
            SecretData input = ResourceDataHelper.CreateSecretData();
            var lro = await profile.GetSecrets().CreateOrUpdateAsync(secretName, input);
            return lro.Value;
        }

        protected async Task<CdnWebApplicationFirewallPolicy> CreatePolicy(ResourceGroup rg, string policyName)
        {
            CdnWebApplicationFirewallPolicyData input = ResourceDataHelper.CreateCdnWebApplicationFirewallPolicyData();
            var lro = await rg.GetCdnWebApplicationFirewallPolicies().CreateOrUpdateAsync(policyName, input);
            return lro.Value;
        }
    }
}
