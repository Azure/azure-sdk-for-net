// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SelfHelp.Tests
{
    public class SelfHelpManagementTestBase : ManagementRecordedTestBase<SelfHelpManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        public AzureLocation DefaultLocation => AzureLocation.EastUS;
        public const string DefaultResourceGroupNamePrefix = "DiagnosticsRp-Synthetics-Public-Global";
        public const string SubId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";

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
