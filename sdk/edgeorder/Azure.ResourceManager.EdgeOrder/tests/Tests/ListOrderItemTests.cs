// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.EdgeOrder.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOrder.Tests.Tests
{
    [TestFixture]
    public class ListOrderItemTests : EdgeOrderManagementClientBase
    {
        private string _orderItemName;
        private EdgeOrderItemCollection _orderItemResourceCollection;

        public ListOrderItemTests() : base(true)
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

        private async Task CreateOrderItem()
        {
            string resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await EdgeOrderManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EdgeOrderManagementTestUtilities.DefaultResourceLocation, resourceGroupName);
            _orderItemName = Recording.GenerateAssetName("Sdk-OrderItem");
            EdgeOrderAddressContactDetails contactDetails = GetDefaultContactDetails();
            EdgeOrderShippingAddress shippingAddress = GetDefaultShippingAddress();
            EdgeOrderItemAddressProperties addressProperties = new(contactDetails)
            {
                ShippingAddress = shippingAddress
            };
            EdgeOrderItemAddressDetails addressDetails = new(addressProperties);
            string orderId = string.Format(EdgeOrderManagementTestUtilities.OrderArmIdFormat,
                TestEnvironment.SubscriptionId, resourceGroupName, EdgeOrderManagementTestUtilities.DefaultResourceLocation, _orderItemName);
            _orderItemResourceCollection = await GetOrderItemResourceCollectionAsync(resourceGroupName);

            EdgeOrderItemData orderItemResourceData = new(EdgeOrderManagementTestUtilities.DefaultResourceLocation,
                GetDefaultOrderItemDetails(), addressDetails, new ResourceIdentifier(orderId));

            // Create
            var createOrderItemOperation = await _orderItemResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _orderItemName, orderItemResourceData);
            await createOrderItemOperation.WaitForCompletionAsync();
        }

        [OneTimeTearDown]
        public async Task Cleanup()
        {
            CleanupResourceGroups();

            //Get
            Response<EdgeOrderItemResource> getOrderItemResourceResponse = await _orderItemResourceCollection.GetAsync(_orderItemName);
            EdgeOrderItemResource orderItemResource = getOrderItemResourceResponse.Value;

            //Cancel
            Response cancelOrderItemResponse = await orderItemResource.CancelAsync(
                new EdgeOrderItemCancellationReason("Test Order item cancelled"));

            //Get
            getOrderItemResourceResponse = await _orderItemResourceCollection.GetAsync(_orderItemName);
            orderItemResource = getOrderItemResourceResponse.Value;

            // Delete
            var deleteOrderItemByNameOperation = await orderItemResource.DeleteAsync(WaitUntil.Completed);
            await deleteOrderItemByNameOperation.WaitForCompletionResponseAsync();
        }

        [TestCase, Order(1)]
        public async Task TestListOrderItemsAtSubscriptionLevel()
        {
            AsyncPageable<EdgeOrderItemResource> orderItems = EdgeOrderExtensions.GetEdgeOrderItemsAsync(Subscription);
            List<EdgeOrderItemResource> orderItemsResult = await orderItems.ToEnumerableAsync();

            Assert.NotNull(orderItemsResult);
            Assert.IsTrue(orderItemsResult.Count >= 1);
        }

        [TestCase, Order(2)]
        public async Task TestListOrderItemsAtResourceGroupLevel()
        {
            AsyncPageable<EdgeOrderItemResource> orderItems = _orderItemResourceCollection.GetAllAsync();
            List<EdgeOrderItemResource> orderItemsResult = await orderItems.ToEnumerableAsync();

            Assert.NotNull(orderItemsResult);
            Assert.IsTrue(orderItemsResult.Count >= 1);
        }
    }
}
