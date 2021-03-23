// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.EventHubs.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class EventHubsManagementClientBase : ManagementRecordedTestBase<EventHubsManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ResourcesManagementClient ResourcesManagementClient { get; set; }
        public EventHubsManagementClient EventHubsManagementClient { get; set; }
        public Operations Operations { get; set; }
        public ResourcesOperations ResourcesOperations { get; set; }
        public ProvidersOperations ResourceProvidersOperations { get; set; }
        public EventHubsOperations EventHubsOperations { get; set; }
        public NamespacesOperations NamespacesOperations { get; set; }
        public ConsumerGroupsOperations ConsumerGroupsOperations { get; set; }
        public DisasterRecoveryConfigsOperations DisasterRecoveryConfigsOperations { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public StorageManagementClient StorageManagementClient { get; set; }
        public NetworkManagementClient NetworkManagementClient { get; set; }

        protected EventHubsManagementClientBase(bool isAsync)
             : base(isAsync)
        {
        }

        protected void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            ResourcesManagementClient = GetResourceManagementClient();
            ResourcesOperations = ResourcesManagementClient.Resources;
            ResourceProvidersOperations = ResourcesManagementClient.Providers;
            ResourceGroupsOperations = ResourcesManagementClient.ResourceGroups;

            EventHubsManagementClient = GetEventHubManagementClient();
            EventHubsOperations = EventHubsManagementClient.EventHubs;
            NamespacesOperations = EventHubsManagementClient.Namespaces;
            ConsumerGroupsOperations = EventHubsManagementClient.ConsumerGroups;
            DisasterRecoveryConfigsOperations = EventHubsManagementClient.DisasterRecoveryConfigs;
            Operations = EventHubsManagementClient.Operations;

            StorageManagementClient = GetStorageManagementClient();
            NetworkManagementClient = GetNetworkManagementClient();
        }

        internal EventHubsManagementClient GetEventHubManagementClient()
        {
            return CreateClient<EventHubsManagementClient>(this.SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new EventHubsManagementClientOptions()));
        }

        internal StorageManagementClient GetStorageManagementClient()
        {
            return CreateClient<StorageManagementClient>(this.SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new StorageManagementClientOptions()));
        }

        internal NetworkManagementClient GetNetworkManagementClient()
        {
            return CreateClient<NetworkManagementClient>(this.SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new NetworkManagementClientOptions()));
        }

        public async Task<string> GetLocation()
        {
            return await GetFirstUsableLocationAsync(ResourceProvidersOperations, "Microsoft.EventHub", "namespaces");
        }

        public void DelayInTest(int seconds)
        {
            if (Mode != RecordedTestMode.Playback)
            {
                Task.Delay(seconds * 1000);
            }
        }
    }
}
