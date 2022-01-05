// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.EdgeOrder.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOrder.Tests.Tests
{
    [TestFixture]
    public class ListOrderTests : EdgeOrderManagementClientBase
    {
        private string _resourceGroupName;
        private string _orderItemName;
        private OrderItemResourceCollection _orderItemResourceCollection;

        public ListOrderTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }

            await CreateOrderItem();
        }

        [OneTimeTearDown]
        public async Task Cleanup()
        {
            CleanupResourceGroups();

            //Get
            Response<OrderItemResource> getOrderItemResourceResponse = await _orderItemResourceCollection.GetAsync(_orderItemName);
            OrderItemResource orderItemResource = getOrderItemResourceResponse.Value;

            //Cancel
            _ = await orderItemResource.CancelOrderItemAsync(
                new CancellationReason("Test Order item cancelled"));

            //Get
            getOrderItemResourceResponse = await _orderItemResourceCollection.GetAsync(_orderItemName);
            orderItemResource = getOrderItemResourceResponse.Value;

            // Delete
            EdgeOrderManagementDeleteOrderItemByNameOperation deleteOrderItemByNameOperation = await orderItemResource.DeleteAsync();
            await deleteOrderItemByNameOperation.WaitForCompletionResponseAsync();
        }

        private async Task CreateOrderItem()
        {
            _resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await EdgeOrderManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EdgeOrderManagementTestUtilities.DefaultResourceLocation, _resourceGroupName);
            _orderItemName = Recording.GenerateAssetName("Sdk-OrderItem");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            AddressProperties addressProperties = new(contactDetails)
            {
                ShippingAddress = shippingAddress
            };
            AddressDetails addressDetails = new(addressProperties);
            string orderId = string.Format(EdgeOrderManagementTestUtilities.OrderArmIdFormat,
                TestEnvironment.SubscriptionId, _resourceGroupName, EdgeOrderManagementTestUtilities.DefaultResourceLocation, _orderItemName);

            _orderItemResourceCollection = GetOrderItemResourceCollection(_resourceGroupName);

            OrderItemResourceData orderItemResourceData = new(EdgeOrderManagementTestUtilities.DefaultResourceLocation,
                GetDefaultOrderItemDetails(), addressDetails, orderId);

            // Create
            EdgeOrderManagementCreateOrderItemOperation createOrderItemOperation = await
                _orderItemResourceCollection.CreateOrUpdateAsync(_orderItemName,
                orderItemResourceData);
            await createOrderItemOperation.WaitForCompletionAsync();
        }

        [TestCase, Order(1)]
        public async Task TestListOrdersAtSubscriptionLevel()
        {
            AsyncPageable<OrderResourceData> orders = SubscriptionExtensions.GetOrderAtSubscriptionLevelAsync(Subscription);
            List<OrderResourceData> ordersResult = await orders.ToEnumerableAsync();

            Assert.NotNull(ordersResult);
            Assert.IsTrue(ordersResult.Count >= 1);
        }

        [TestCase, Order(2)]
        public async Task TestListOrdersAtResourceGroupLevel()
        {
            AsyncPageable<OrderResourceData> orders =
                ResourceGroupExtensions.GetOrderAtResourceGroupLevelAsync(GetResourceGroup(_resourceGroupName));
            List<OrderResourceData> ordersResult = await orders.ToEnumerableAsync();

            Assert.NotNull(ordersResult);
            Assert.IsTrue(ordersResult.Count >= 1);
        }
    }
}
