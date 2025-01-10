// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.IoTOperations.Tests
{
    public abstract class IoTOperationsManagementClientBase
        : ManagementRecordedTestBase<IoTOperationsManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ArmClient ArmClient { get; private set; }
        public SubscriptionResource Subscription { get; set; }
        public string ResourceGroup { get; set; }
        public string InstanceName { get; set; }
        public string BrokersName { get; set; }
        public string BrokersListenersName { get; set; }
        public string BrokersAuthenticationsName { get; set; }
        public string DataflowProfilesName { get; set; }
        public string DataflowEndpointsName { get; set; }
        public string ExtendedLocation { get; set; }
        public string CustomLocationName { get; set; }
        public const string DefaultResourceLocation = "eastus2";

        protected IoTOperationsManagementClientBase(bool isAsync)
            : base(isAsync) { }

        protected IoTOperationsManagementClientBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode) { }

        protected async Task InitializeClients()
        {
            ArmClient = GetArmClient();
            Subscription = await ArmClient.GetDefaultSubscriptionAsync();
            ResourceGroup = "sdk-test-cluster-112208379";
            CustomLocationName = "location-cozp6";
            InstanceName = "aio-cozp6";
            BrokersName = "default";
            BrokersListenersName = "default";
            BrokersAuthenticationsName = "default";
            DataflowProfilesName = "default";
            DataflowEndpointsName = "default";
            ExtendedLocation =
                $"/subscriptions/{Subscription.Data.Id}/resourceGroups{ResourceGroup}/providers/Microsoft.ExtendedLocation/customLocations/{CustomLocationName}";
        }

        public async Task<ResourceGroupResource> GetResourceGroupAsync(string name)
        {
            string idk = Subscription.Data.Id;
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
            DataflowProfileResource dataflowProfile = await dataflowProfiles.GetAsync(
                DataflowProfilesName
            );
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
