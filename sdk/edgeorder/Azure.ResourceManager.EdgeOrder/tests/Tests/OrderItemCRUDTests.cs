﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.EdgeOrder.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOrder.Tests.Tests
{
    [TestFixture]
    public class OrderItemCRUDTests : EdgeOrderManagementClientBase
    {
        public OrderItemCRUDTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        public async Task TestOrderItemCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await EdgeOrderManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EdgeOrderManagementTestUtilities.DefaultResourceLocation, resourceGroupName);
            var orderItemName = Recording.GenerateAssetName("Sdk-OrderItem");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            AddressProperties addressProperties = new(contactDetails)
            {
                ShippingAddress = shippingAddress
            };
            AddressDetails addressDetails = new(addressProperties);
            string orderId = string.Format(EdgeOrderManagementTestUtilities.OrderArmIdFormat,
                TestEnvironment.SubscriptionId, resourceGroupName, EdgeOrderManagementTestUtilities.DefaultResourceLocation, orderItemName);

            OrderItemResourceCollection _orderItemResourceCollection = await GetOrderItemResourceCollectionAsync(resourceGroupName);

            OrderItemResourceData orderItemResourceData = new(EdgeOrderManagementTestUtilities.DefaultResourceLocation,
                GetDefaultOrderItemDetails(), addressDetails, orderId);

            // Create
            var createOrderItemOperation = await _orderItemResourceCollection.CreateOrUpdateAsync(true, orderItemName, orderItemResourceData);
            await createOrderItemOperation.WaitForCompletionAsync();
            Assert.IsTrue(createOrderItemOperation.HasCompleted);
            Assert.IsTrue(createOrderItemOperation.HasValue);

            // Get
            Response<OrderItemResource> getOrderItemResourceResponse = await _orderItemResourceCollection.GetAsync(orderItemName);
            OrderItemResource orderItemResource = getOrderItemResourceResponse.Value;
            Assert.IsNotNull(orderItemResource);

            // Update
            addressProperties.ContactDetails.ContactName = "Updated contact name";
            OrderItemUpdateParameter orderItemUpdateParameter = new()
            {
                ForwardAddress = addressProperties
            };
            var updateOrderItemOperation = await orderItemResource.UpdateAsync(true, orderItemUpdateParameter);
            await updateOrderItemOperation.WaitForCompletionAsync();
            Assert.IsTrue(updateOrderItemOperation.HasCompleted);
            Assert.IsTrue(updateOrderItemOperation.HasValue);

            // Get
            getOrderItemResourceResponse = await _orderItemResourceCollection.GetAsync(orderItemName);
            orderItemResource = getOrderItemResourceResponse.Value;
            Assert.IsNotNull(orderItemResource);

            //Cancel
            Response cancelOrderItemResponse = await orderItemResource.CancelOrderItemAsync(
                new CancellationReason("Order item cancelled"));
            Assert.AreEqual(cancelOrderItemResponse.Status, 204);

            // Get
            getOrderItemResourceResponse = await _orderItemResourceCollection.GetAsync(orderItemName);
            orderItemResource = getOrderItemResourceResponse.Value;
            Assert.IsNotNull(orderItemResource);

            // Delete
            var deleteOrderItemByNameOperation = await orderItemResource.DeleteAsync(true);
            await deleteOrderItemByNameOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteOrderItemByNameOperation.HasCompleted);
        }
    }
}
