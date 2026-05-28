// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SelfHelp.Tests
{
    public class SelfHelpManagementTestBase : ManagementRecordedTestBase<SelfHelpManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected TenantResource DefaultTenantResource { get; private set; }
        public AzureLocation DefaultLocation => AzureLocation.EastUS;
        public const string DefaultResourceGroupNamePrefix = "DiagnosticsRp-Synthetics-Public-Global";
        public const string SubId = "6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba";

        protected SelfHelpManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected SelfHelpManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            // DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            SubscriptionCollection subscriptions = Client.GetSubscriptions();
            DefaultSubscription = await subscriptions.GetAsync(SubId);

            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            DefaultTenantResource = tenants.FirstOrDefault();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(string rgNamePrefix = DefaultResourceGroupNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
