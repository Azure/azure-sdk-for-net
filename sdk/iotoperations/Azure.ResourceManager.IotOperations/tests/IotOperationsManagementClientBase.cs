// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public abstract class IotOperationsManagementClientBase
        : ManagementRecordedTestBase<IotOperationsManagementTestEnvironment>
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

        protected IotOperationsManagementClientBase(bool isAsync)
            : base(isAsync) { }

        protected IotOperationsManagementClientBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode) { }

        protected async Task InitializeClients()
        {
            ArmClient = GetArmClient();
            Subscription = await ArmClient.GetDefaultSubscriptionAsync();
            ResourceGroup = "aio-validation-113034243";
            CustomLocationName = "location-113034243";
            InstanceName = "aio-113034243";
            BrokersName = "default";
            BrokersListenersName = "default";
            BrokersAuthenticationsName = "default";
            DataflowProfilesName = "default";
            DataflowEndpointsName = "default";
            ExtendedLocation =
                $"/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups{ResourceGroup}/providers/Microsoft.ExtendedLocation/customLocations/{CustomLocationName}";
        }

        public async Task<ResourceGroupResource> GetResourceGroupAsync(string name)
        {
            return await Subscription.GetResourceGroups().GetAsync(name);
        }

        // Get Instances
        protected async Task<IotOperationsInstanceCollection> GetInstanceCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return rg.GetIotOperationsInstances();
        }

        // Get Brokers
        protected async Task<IotOperationsBrokerCollection> GetBrokerCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            IotOperationsInstanceCollection instances = rg.GetIotOperationsInstances();
            IotOperationsInstanceResource instance = await instances.GetAsync(InstanceName);
            return instance.GetIotOperationsBrokers();
        }

        // Get BrokerAuthentications
        protected async Task<IotOperationsBrokerAuthenticationCollection> GetBrokerAuthenticationCollectionAsync(
            string resourceGroupName
        )
        {
            IotOperationsBrokerCollection brokers = await GetBrokerCollectionAsync(
                resourceGroupName
            );
            IotOperationsBrokerResource broker = await brokers.GetAsync(BrokersName);
            return broker.GetIotOperationsBrokerAuthentications();
        }

        // Get BrokerAuthorizations
        protected async Task<IotOperationsBrokerAuthorizationCollection> GetBrokerAuthorizationCollectionAsync(
            string resourceGroupName
        )
        {
            IotOperationsBrokerCollection brokers = await GetBrokerCollectionAsync(
                resourceGroupName
            );
            IotOperationsBrokerResource broker = await brokers.GetAsync(BrokersName);
            return broker.GetIotOperationsBrokerAuthorizations();
        }

        // Get BrokerListeners
        protected async Task<IotOperationsBrokerListenerCollection> GetBrokerListenerCollectionAsync(
            string resourceGroupName
        )
        {
            IotOperationsBrokerCollection brokers = await GetBrokerCollectionAsync(
                resourceGroupName
            );
            IotOperationsBrokerResource broker = await brokers.GetAsync(BrokersName);
            return broker.GetIotOperationsBrokerListeners();
        }

        // Get DataflowProfiles
        protected async Task<IotOperationsDataflowProfileCollection> GetDataflowProfileCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            IotOperationsInstanceCollection instances = rg.GetIotOperationsInstances();
            IotOperationsInstanceResource instance = await instances.GetAsync(InstanceName);
            return instance.GetIotOperationsDataflowProfiles();
        }

        // Get Dataflows
        protected async Task<IotOperationsDataflowCollection> GetDataflowCollectionAsync(
            string resourceGroupName
        )
        {
            IotOperationsDataflowProfileCollection dataflowProfiles =
                await GetDataflowProfileCollectionAsync(resourceGroupName);
            IotOperationsDataflowProfileResource dataflowProfile = await dataflowProfiles.GetAsync(
                DataflowProfilesName
            );
            return dataflowProfile.GetIotOperationsDataflows();
        }

        // Get DataflowEndpoints
        protected async Task<IotOperationsDataflowEndpointCollection> GetDataflowEndpointCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            IotOperationsInstanceCollection instances = rg.GetIotOperationsInstances();
            IotOperationsInstanceResource instance = await instances.GetAsync(InstanceName);
            return instance.GetIotOperationsDataflowEndpoints();
        }
    }
}
