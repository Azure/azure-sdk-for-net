// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FluidRelay.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.FluidRelay.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class FluidRelayManagementClientBase : ManagementRecordedTestBase<fluidrelayManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ArmClient ArmClient { get; private set; }
        public ResourceGroupCollection ResourceGroupsOperations { get; set; }
        public SubscriptionResource Subscription { get; set; }

        protected FluidRelayManagementClientBase(bool isAsync) : base(isAsync)
        {
        }

        protected FluidRelayManagementClientBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected async Task InitializeClients()
        {
            ArmClient = GetArmClient();
            Subscription = await ArmClient.GetDefaultSubscriptionAsync();
            ResourceGroupsOperations = Subscription.GetResourceGroups();
        }

        public async Task<ResourceGroupResource> GetResourceGroupAsync(string name)
        {
            return await Subscription.GetResourceGroups().GetAsync(name);
        }

        protected async Task<FluidRelayServerCollection> GetFluidRelayServerCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return rg.GetFluidRelayServers();
        }
    }
}
