// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.EdgeOrder.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class EdgeOrderManagementClientBase : ManagementRecordedTestBase<EdgeOrderManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ArmClient ResourcesManagementClient { get; set; }
        public ResourceGroupCollection ResourceGroupsOperations { get; set; }
        public EdgeOrderManagementClient EdgeOrderManagementClient { get; set; }
        public EdgeOrderManagementOperations EdgeOrderManagementOperations { get; set; }

        protected EdgeOrderManagementClientBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new EdgeOrderManagementRecordedTestSanitizer();
        }

        protected async Task InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            ResourcesManagementClient = GetResourceManagementClient();
            Subscription sub = await ResourcesManagementClient.GetDefaultSubscriptionAsync();
            ResourceGroupsOperations = sub.GetResourceGroups();
            EdgeOrderManagementClient = GetEdgeOrderManagementClient();
            EdgeOrderManagementOperations = EdgeOrderManagementClient.EdgeOrderManagement;
        }

        internal EdgeOrderManagementClient GetEdgeOrderManagementClient()
        {
            return CreateClient<EdgeOrderManagementClient>(SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new EdgeOrderManagementClientOptions()));
        }

        protected static ContactDetails GetDefaultContactDetails()
        {
            return new ContactDetails("Public SDK Test", "1234567890",
                new List<string> { "testing@microsoft.com" })
            {
                PhoneExtension = "1234",
            };
        }

        protected static ShippingAddress GetDefaultShippingAddress()
        {
            return new ShippingAddress("16 TOWNSEND ST", "US")
            {
                StreetAddress2 = "Unit 1",
                City = "San Francisco",
                StateOrProvince = "CA",
                PostalCode = "94107",
                CompanyName = "Microsoft",
                AddressType = AddressType.Commercial
            };
        }

        protected static HierarchyInformation GetHierarchyInformation()
        {
            return new HierarchyInformation
            {
                ProductFamilyName = "AzureStackEdge",
                ProductLineName = "AzureStackEdge",
                ProductName = "AzureStackEdgeGPU",
                ConfigurationName = "EdgeP_Base"
            };
        }

        protected static OrderItemDetails GetDefaultOrderItemDetails()
        {
            return new OrderItemDetails(new ProductDetails(GetHierarchyInformation()), OrderItemType.Purchase)
            {
                Preferences = new Preferences
                {
                    TransportPreferences = new TransportPreferences(TransportShipmentTypes.MicrosoftManaged)
                }
            };
        }
    }
}
