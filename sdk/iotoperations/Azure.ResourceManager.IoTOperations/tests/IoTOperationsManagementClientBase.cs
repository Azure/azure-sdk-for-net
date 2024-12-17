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

        protected IoTOperationsManagementClientBase(bool isAsync)
            : base(isAsync) { }

        protected IoTOperationsManagementClientBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode) { }

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

        protected async Task<InstanceResourceCollection> GetInstanceResourceCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return rg.GetInstanceResources();
        }

        protected async Task<BrokerResourceCollection> GetBrokerResourceCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            InstanceResourceCollection instances = rg.GetInstanceResources();
            InstanceResource instance = await instances.GetAsync("aio-instance");
            return instance.GetBrokerResources();
        }

        protected async Task<DataflowProfileResourceCollection> GetDataflowProfileResourceCollectionAsync(
            string resourceGroupName
        )
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            InstanceResourceCollection instances = rg.GetInstanceResources();
            InstanceResource instance = await instances.GetAsync("aio-instance");
            return instance.GetDataflowProfileResources();
        }

        // protected static EdgeOrderAddressContactDetails GetDefaultContactDetails()
        // {
        //     return new EdgeOrderAddressContactDetails(
        //         "Public SDK Test",
        //         "1234567890",
        //         new List<string> { "testing@microsoft.com" }
        //     )
        //     {
        //         PhoneExtension = "1234",
        //     };
        // }

        // protected static EdgeOrderShippingAddress GetDefaultShippingAddress()
        // {
        //     return new EdgeOrderShippingAddress("16 TOWNSEND ST", "US")
        //     {
        //         StreetAddress2 = "Unit 1",
        //         City = "San Francisco",
        //         StateOrProvince = "CA",
        //         PostalCode = "94107",
        //         CompanyName = "Microsoft",
        //         AddressType = EdgeOrderAddressType.Commercial
        //     };
        // }

        // protected static HierarchyInformation GetHierarchyInformation()
        // {
        //     return new HierarchyInformation
        //     {
        //         ProductFamilyName = "AzureStackEdge",
        //         ProductLineName = "AzureStackEdge",
        //         ProductName = "AzureStackEdgeGPU",
        //         ConfigurationName = "EdgeP_Base"
        //     };
        // }

        // protected static EdgeOrderItemDetails GetDefaultOrderItemDetails()
        // {
        //     return new EdgeOrderItemDetails(
        //         new ProductDetails(GetHierarchyInformation()),
        //         OrderItemType.Purchase
        //     )
        //     {
        //         Preferences = new OrderItemPreferences
        //         {
        //             TransportPreferences = new TransportPreferences(
        //                 TransportShipmentType.MicrosoftManaged
        //             )
        //         }
        //     };
        // }
    }
}
