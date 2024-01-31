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

        public AsyncPageable<FluidRelayServerResource> GetFluidRelayServerCollectionBySubscriptionAsync()
        {
            return Subscription.GetFluidRelayServersAsync();
        }

        protected async Task<FluidRelayServerCollection> GetFluidRelayServerCollectionByResourceGroupAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return rg.GetFluidRelayServers();
        }

        protected async Task<FluidRelayContainerCollection> GetFluidRelayContainerCollectionAsync(string resourceGroupName, string serverName)
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            FluidRelayServerCollection servers = rg.GetFluidRelayServers();
            Response<FluidRelayServerResource> serverRsp = await servers.GetAsync(serverName);
            FluidRelayServerResource server = serverRsp.Value;
            return server.GetFluidRelayContainers();
        }
    }
}
