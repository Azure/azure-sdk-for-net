// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.EdgeOrder.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOrder.Tests.Tests
{
    [TestFixture]
    public class ListOrderTests : EdgeOrderManagementClientBase
    {
        private string _resourceGroupName;
        private string _orderItemName;
        private EdgeOrderItemCollection _orderItemResourceCollection;

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
            Response<EdgeOrderItemResource> getOrderItemResourceResponse = await _orderItemResourceCollection.GetAsync(_orderItemName);
            EdgeOrderItemResource orderItemResource = getOrderItemResourceResponse.Value;

            //Cancel
            _ = await orderItemResource.CancelAsync(
                new EdgeOrderItemCancellationReason("Test Order item cancelled"));

            //Get
            getOrderItemResourceResponse = await _orderItemResourceCollection.GetAsync(_orderItemName);
            orderItemResource = getOrderItemResourceResponse.Value;

            // Delete
            var deleteOrderItemByNameOperation = await orderItemResource.DeleteAsync(WaitUntil.Completed);
            await deleteOrderItemByNameOperation.WaitForCompletionResponseAsync();
        }

        private async Task CreateOrderItem()
        {
            _resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await EdgeOrderManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EdgeOrderManagementTestUtilities.DefaultResourceLocation, _resourceGroupName);
            _orderItemName = Recording.GenerateAssetName("Sdk-OrderItem");
            EdgeOrderAddressContactDetails contactDetails = GetDefaultContactDetails();
            EdgeOrderShippingAddress shippingAddress = GetDefaultShippingAddress();
            EdgeOrderItemAddressProperties addressProperties = new(contactDetails)
            {
                ShippingAddress = shippingAddress
            };
            EdgeOrderItemAddressDetails addressDetails = new(addressProperties);
            string orderId = string.Format(EdgeOrderManagementTestUtilities.OrderArmIdFormat,
                TestEnvironment.SubscriptionId, _resourceGroupName, EdgeOrderManagementTestUtilities.DefaultResourceLocation, _orderItemName);

            _orderItemResourceCollection = await GetOrderItemResourceCollectionAsync(_resourceGroupName);

            EdgeOrderItemData orderItemResourceData = new(EdgeOrderManagementTestUtilities.DefaultResourceLocation,
                GetDefaultOrderItemDetails(), addressDetails, new ResourceIdentifier(orderId));

            // Create
            var createOrderItemOperation = await _orderItemResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _orderItemName, orderItemResourceData);
            await createOrderItemOperation.WaitForCompletionAsync();
        }

        [TestCase, Order(1)]
        public async Task TestListOrdersAtSubscriptionLevel()
        {
            AsyncPageable<EdgeOrderResource> orders = EdgeOrderExtensions.GetEdgeOrdersAsync(Subscription);
            List<EdgeOrderResource> ordersResult = await orders.ToEnumerableAsync();

            Assert.NotNull(ordersResult);
            Assert.IsTrue(ordersResult.Count >= 1);
        }

        [TestCase, Order(2)]
        public async Task TestListOrdersAtResourceGroupLevel()
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(_resourceGroupName);
            AsyncPageable<EdgeOrderResource> orders = EdgeOrderExtensions.GetEdgeOrdersAsync(rg);
            List<EdgeOrderResource> ordersResult = await orders.ToEnumerableAsync();

            Assert.NotNull(ordersResult);
            Assert.IsTrue(ordersResult.Count >= 1);
        }
    }
}
