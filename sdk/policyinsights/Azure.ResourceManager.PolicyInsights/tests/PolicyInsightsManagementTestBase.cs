// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.PolicyInsights.Tests
{
    public class PolicyInsightsManagementTestBase : ManagementRecordedTestBase<PolicyInsightsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected TenantResource DefaultTenant { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected const string ResourceGroupNamePrefix = "PolicyRG";
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;

        protected PolicyInsightsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected PolicyInsightsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            DefaultTenant = tenants.FirstOrDefault();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<PolicyAssignmentResource> CreatePolicyAssignment(ArmResource armResource, string policyAssignmentName, string PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d")
        {
            PolicyAssignmentData input = new PolicyAssignmentData
            {
                DisplayName = $"PolicyInsights Test ${policyAssignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            ArmOperation<PolicyAssignmentResource> lro = await armResource.GetPolicyAssignments().CreateOrUpdateAsync(WaitUntil.Completed, policyAssignmentName, input);
            return lro.Value;
        }
    }
}
