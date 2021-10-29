// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;

using Azure.Core;
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
        public ArmClient ArmClient { get; set; }
        public EventHubsManagementClient EventHubsManagementClient { get; set; }
        public Operations Operations { get; set; }
        public EventHubsOperations EventHubsOperations { get; set; }
        public NamespacesOperations NamespacesOperations { get; set; }
        public ConsumerGroupsOperations ConsumerGroupsOperations { get; set; }
        public DisasterRecoveryConfigsOperations DisasterRecoveryConfigsOperations { get; set; }

        protected EventHubsManagementClientBase(bool isAsync)
             : base(isAsync)
        {
            Sanitizer = new EventHubsManagementRecordedTestSanitizer();
        }

        protected void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            ArmClient = GetArmClient(); // TODO: use base.GetArmClient when switching to new mgmt test framework

            EventHubsManagementClient = GetEventHubManagementClient();
            EventHubsOperations = EventHubsManagementClient.EventHubs;
            NamespacesOperations = EventHubsManagementClient.Namespaces;
            ConsumerGroupsOperations = EventHubsManagementClient.ConsumerGroups;
            DisasterRecoveryConfigsOperations = EventHubsManagementClient.DisasterRecoveryConfigs;
            Operations = EventHubsManagementClient.Operations;
        }

        internal EventHubsManagementClient GetEventHubManagementClient()
        {
            return CreateClient<EventHubsManagementClient>(this.SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new EventHubsManagementClientOptions()));
        }
        internal ArmClient GetArmClient()
        {
            var options = InstrumentClientOptions(new ArmClientOptions());
            CleanupPolicy = new ResourceGroupCleanupPolicy();
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);

            return CreateClient<ArmClient>(this.TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                options);
        }
        public async Task<string> GetLocation()
        {
            Subscription sub = await ArmClient.GetDefaultSubscriptionAsync();
            var provider = (await sub.GetProviders().GetAsync("Microsoft.EventHub")).Value;
            return provider.Data.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == "namespaces")
                        return true;
                    else
                        return false;
                }
            ).First().Locations.FirstOrDefault();
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
