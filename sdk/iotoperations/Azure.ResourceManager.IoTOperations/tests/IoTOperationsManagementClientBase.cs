// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IoTOperations.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.IoTOperations.Tests
{
    public abstract class IoTOperationsManagementClientBase
        : ManagementRecordedTestBase<IoTOperationsManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ArmClient ArmClient { get; private set; }
        public ResourceGroupCollection ResourceGroupsOperations { get; set; }
        public SubscriptionResource Subscription { get; set; }
        public string InstanceName { get; set; }
        public string BrokersName { get; set; }
        public string DataflowProfilesName { get; set; }

        protected IoTOperationsManagementClientBase(bool isAsync)
            : base(isAsync) { }

        protected IoTOperationsManagementClientBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode) { }

        protected async Task InitializeClients()
        {
            ArmClient = GetArmClient();
            Subscription = await ArmClient.GetDefaultSubscriptionAsync();
            ResourceGroupsOperations = Subscription.GetResourceGroups();
            InstanceName = "aio-o5fjq";
            BrokersName = "default";
            DataflowProfilesName = "default";
        }

        public async Task<ResourceGroupResource> GetResourceGroupAsync(string name)
        {
            return await Subscription.GetResourceGroups().GetAsync(name);
        }

        // Get Instances
        protected async Task<InstanceResourceCollection> GetInstanceResourceCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return rg.GetInstanceResources();
        }

        // Get Brokers
        protected async Task<BrokerResourceCollection> GetBrokerResourceCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            InstanceResourceCollection instances = rg.GetInstanceResources();
            InstanceResource instance = await instances.GetAsync(InstanceName);
            return instance.GetBrokerResources();
        }

        // Get BrokerAuthentications
        protected async Task<BrokerAuthenticationResourceCollection> GetBrokerAuthenticationResourceCollectionAsync(
            string resourceGroupName
        )
        {
            BrokerResourceCollection brokers = await GetBrokerResourceCollectionAsync(
                resourceGroupName
            );
            BrokerResource broker = await brokers.GetAsync(BrokersName);
            return broker.GetBrokerAuthenticationResources();
        }

        // Get BrokerAuthorizations
        protected async Task<BrokerAuthorizationResourceCollection> GetBrokerAuthorizationResourceCollectionAsync(
            string resourceGroupName
        )
        {
            BrokerResourceCollection brokers = await GetBrokerResourceCollectionAsync(
                resourceGroupName
            );
            BrokerResource broker = await brokers.GetAsync(BrokersName);
            return broker.GetBrokerAuthorizationResources();
        }

        // Get BrokerListeners
        protected async Task<BrokerListenerResourceCollection> GetBrokerListenerResourceCollectionAsync(
            string resourceGroupName
        )
        {
            BrokerResourceCollection brokers = await GetBrokerResourceCollectionAsync(
                resourceGroupName
            );
            BrokerResource broker = await brokers.GetAsync(BrokersName);
            return broker.GetBrokerListenerResources();
        }

        // Get DataflowProfiles
        protected async Task<DataflowProfileResourceCollection> GetDataflowProfileResourceCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            InstanceResourceCollection instances = rg.GetInstanceResources();
            InstanceResource instance = await instances.GetAsync(InstanceName);
            return instance.GetDataflowProfileResources();
        }

        // Get Dataflows
        protected async Task<DataflowResourceCollection> GetDataflowResourceCollectionAsync(
            string resourceGroupName
        )
        {
            DataflowProfileResourceCollection dataflowProfiles =
                await GetDataflowProfileResourceCollectionAsync(resourceGroupName);
            DataflowProfileResource dataflowProfile = await dataflowProfiles.GetAsync(DataflowProfilesName);
            return dataflowProfile.GetDataflowResources();
        }

        // Get DataflowEndpoints
        protected async Task<DataflowEndpointResourceCollection> GetDataflowEndpointResourceCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            InstanceResourceCollection instances = rg.GetInstanceResources();
            InstanceResource instance = await instances.GetAsync(InstanceName);
            return instance.GetDataflowEndpointResources();
        }
    }
}
