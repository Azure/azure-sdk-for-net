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
        protected ResourceIdentifier DefaultPolicyAssignmentId { get; private set; }
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
            DefaultPolicyAssignmentId = new ResourceIdentifier($"{DefaultSubscription.Id}/providers/microsoft.authorization/policyassignments/3bbee6571e0340dba6df72bf");
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
